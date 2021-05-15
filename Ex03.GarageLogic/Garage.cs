using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, GarageVehicle> m_GarageVehicles;

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, GarageVehicle>();
        }

        public void AddVehicle(string i_OwnerPhone, string i_OwnerName, Vehicle i_NewVehicle)
        {
            string newVehicleLicenseNumber = i_NewVehicle.LicenseNumber;
            if(m_GarageVehicles.ContainsKey(newVehicleLicenseNumber))
            {
                m_GarageVehicles[newVehicleLicenseNumber].FixState = GarageEnums.eFixState.BeingFixed;
                throw new ArgumentException("Vehicle Already exist - Moved the vehicle to being fixed state.");
            }

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

        public List<GarageVehicle> GetAllGarageVehicles()
        {
            List<GarageVehicle> vechilesWithRequestedFixState = new List<GarageVehicle>();
            foreach(KeyValuePair<string, GarageVehicle> garageVehicle in m_GarageVehicles)
            {
                vechilesWithRequestedFixState.Add(garageVehicle.Value);
            }

            return vechilesWithRequestedFixState;
        }

        public void ChangeVehicleState(string i_LicenseNumber, GarageEnums.eFixState i_FixState)
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
                tire.PumpTire(psiToAdd);
            }
        }

        public void RefuelVehicle(string i_LicenseNumber, GarageEnums.eFuelType i_FuelType, float i_LitersOfFuelToAdd)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            Vehicle vehicleToRefuel = m_GarageVehicles[i_LicenseNumber].VehicleInGarage;
            if (vehicleToRefuel is FuelVehicle fuelVehicleToRefuel)
            {
                if (fuelVehicleToRefuel.FuelType != i_FuelType)
                {
                    throw new ArgumentException("Wrong fuel type");
                }

                fuelVehicleToRefuel.Refuel(i_LitersOfFuelToAdd);
            }
            else
            {
                throw new ArgumentException("This is not a fuel vehicle.");
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_HoursToCharge)
        {
            checkLicenseNumberValidity(i_LicenseNumber);
            Vehicle vehicleToCharge = m_GarageVehicles[i_LicenseNumber].VehicleInGarage;
            if (vehicleToCharge is ElectricVehicle electricVehicleToCharge)
            {
                electricVehicleToCharge.ChargeBattery(i_HoursToCharge);
            }
            else
            {
                throw new ArgumentException("This is not an electric vehicle.");
            }
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
