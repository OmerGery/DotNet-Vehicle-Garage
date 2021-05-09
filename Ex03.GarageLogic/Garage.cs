using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageEnums
    {
        public enum eFixState
        {
            BeingFixed,
            Fixed,
            Payed
        }
        public enum eFuelType
        {
            Soler,
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

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, GarageVehicle>();
        }
        public void AddVehicle(GarageVehicle i_NewVehicle)
        {
            // to add exception , to check
            m_GarageVehicles.Add(i_NewVehicle.VehicleInGarage.LicenseNumber, i_NewVehicle);
        }

        public void AddElectricBike(string i_OwnerPhone, string i_OwnerName, float i_HoursOfBatteryLeft,int i_EngineVolume,GarageEnums.eBikeLicenceType i_LicenseType, 
                                    string i_LicenseNumber, string i_ModelName, string i_WheelManufacturer, int i_CurrentPsi)//, float i_MaxPsi)
        {
            ElectricBike bikeToAdd = VehicleBuilder.ElectricBikeBuilder(
                i_LicenseType,
                i_EngineVolume, i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, i_WheelManufacturer,
                i_CurrentPsi);
            GarageVehicle bikeAsGarageVehicle = new GarageVehicle(i_OwnerName, i_OwnerPhone, bikeToAdd);
            AddVehicle(bikeAsGarageVehicle);
        }
        public List<Vehicle> GetGarageVehiclesByFixState(GarageEnums.eFixState i_FixState)
        {
            List<Vehicle> vechilesWithRequestedFixState = new List<Vehicle>();
            foreach (KeyValuePair<string, GarageVehicle> garageVehicle in m_GarageVehicles)
            {
                if(garageVehicle.Value.FixState == i_FixState)
                {
                    vechilesWithRequestedFixState.Add(garageVehicle.Value.VehicleInGarage);
                }
            }

            return vechilesWithRequestedFixState;
        }

        public List<Vehicle> GetAllGarageVehicles()
        {
            List<Vehicle> allVehicles = new List<Vehicle>();
            foreach (KeyValuePair<string, GarageVehicle> garageVehicle in m_GarageVehicles)
            {
                allVehicles.Add(garageVehicle.Value.VehicleInGarage);
            }

            return allVehicles;
        }
        public void ChangeVehicleState(string i_LicenseNumber , GarageEnums.eFixState i_FixState)
        {
            m_GarageVehicles[i_LicenseNumber].FixState = i_FixState;
        }

        public void PumpVehicle(string i_LicenseNumber)
        {
            List<Tire> tiresToPump = m_GarageVehicles[i_LicenseNumber].VehicleInGarage.Tires;
            foreach(Tire tire in tiresToPump)
            {
                float psiToAdd = tire.MaxPsiTirePressure - tire.CurrentPsiTirePressure;
                tire.PumpTire(psiToAdd);
            }
        }

        public void RefuelVehicle(string i_LicenseNumber,GarageEnums.eFuelType i_FuelType,float i_LitersOfFuelToAdd)
        {
            FuelVehicle vehicleToRefuel = m_GarageVehicles[i_LicenseNumber].VehicleInGarage as FuelVehicle;
            vehicleToRefuel.Refuel(i_LitersOfFuelToAdd, i_FuelType);
        }
        public void ChargeVehicle(string i_LicenseNumber,float i_MinutesToCharge)
        {
            float hoursToCharge = i_MinutesToCharge / 60;
            ElectricVehicle vehicleToChrage = m_GarageVehicles[i_LicenseNumber].VehicleInGarage as ElectricVehicle;
            vehicleToChrage.ChargeBattery(hoursToCharge);
        }

        public GarageVehicle GetVehicleDetails(string i_LicenseNumber)
        {
            return m_GarageVehicles[i_LicenseNumber];
        }

    }
}
