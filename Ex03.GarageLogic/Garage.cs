using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Ex03.GarageLogic
{
    public class GarageEnums
    {
        public enum eFixState
        {
            BeingFixed = 1,
            Fixed,
            Payed
        }

        public enum eFuelType
        {
            Soler = 1,
            Octan96,
            Octan95,
            Octan98
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three,
            Four,
            Five
        }

        public enum eColor
        {
            Red,
            Silver,
            White,
            Black
        }

        public enum eBikeLicenceType
        {
            A,
            B1,
            AA,
            BB
        }

    }
    public class Garage
    {
        private Dictionary <string,GarageVehicle> m_GarageVehicles;

        public List<GarageVehicle> GarageVehicles
        {
            get
            {
                List<GarageVehicle> garageVehiclesList = new List<GarageVehicle>(m_GarageVehicles.Keys.Count);
                return garageVehiclesList;
            }
        }

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, GarageVehicle>();
        }
        public void AddVehicle(string i_OwnerPhone,string i_OwnerName,Vehicle i_NewVehicle)
        {
            // to add exception , to check
            GarageVehicle newVehicle = new GarageVehicle(i_OwnerName, i_OwnerPhone, i_NewVehicle);
            m_GarageVehicles.Add(i_NewVehicle.LicenseNumber, newVehicle);
        }

        public List<GarageVehicle> GetGarageVehiclesByFixState(GarageEnums.eFixState i_FixState)
        {
            List<GarageVehicle> vechilesWithRequestedFixState = new List<GarageVehicle>();
            foreach (KeyValuePair<string, GarageVehicle> garageVehicle in m_GarageVehicles)
            {
                if(garageVehicle.Value.FixState == i_FixState)
                {
                    vechilesWithRequestedFixState.Add(garageVehicle.Value);
                }
            }

            return vechilesWithRequestedFixState;
        }

        public void ChangeVehicleState(string i_LicenseNumber , GarageEnums.eFixState i_FixState)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            m_GarageVehicles[i_LicenseNumber].FixState = i_FixState;
        }

        public void PumpVehicle(string i_LicenseNumber)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            List<Tire> tiresToPump = m_GarageVehicles[i_LicenseNumber].VehicleInGarage.Tires;
            foreach(Tire tire in tiresToPump)
            {
                float psiToAdd = tire.MaxPsiTirePressure - tire.CurrentPsiTirePressure;
                tire.CurrentPsiTirePressure += psiToAdd;
            }
        }

        public void RefuelVehicle(string i_LicenseNumber,GarageEnums.eFuelType i_FuelType,float i_LitersOfFuelToAdd)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            if (!(m_GarageVehicles[i_LicenseNumber].VehicleInGarage is FuelVehicle))
            {
                throw new ArgumentException("This is not a fuel vehicle.");
            }
            FuelVehicle vehicleToRefuel = m_GarageVehicles[i_LicenseNumber].VehicleInGarage as FuelVehicle;
            if(vehicleToRefuel.FuelType != i_FuelType)
            {
                throw new ArgumentException("Wrong fuel type");
            }

            vehicleToRefuel.LitersOfFuelLeft += i_LitersOfFuelToAdd;
        }
        public void ChargeVehicle(string i_LicenseNumber,float i_HoursToCharge)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            if (!(m_GarageVehicles[i_LicenseNumber].VehicleInGarage is ElectricVehicle))
            {
                throw new ArgumentException("This is not an electric vehicle.");
            }
            ElectricVehicle vehicleToChrage = m_GarageVehicles[i_LicenseNumber].VehicleInGarage as ElectricVehicle;
            vehicleToChrage.CurrentHoursOfBatteryLeft += i_HoursToCharge;
        }

        public GarageVehicle GetVehicleDetails(string i_LicenseNumber)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            return m_GarageVehicles[i_LicenseNumber];
        }

        private void checkLicenseNumberValidity(string i_LicenseNumber)
        {
            if (!m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                throw new ArgumentException("this vehicle doesn't exist in the garage");
            }
        }
    }
}
