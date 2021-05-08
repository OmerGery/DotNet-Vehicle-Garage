using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary <string,GarageVehicle> m_GarageVehicles;

        public void AddVehicle(GarageVehicle i_NewVehicle)
        {
            // to add exception , to check
            m_GarageVehicles.Add(i_NewVehicle.VehicleInGarage.LicenseNumber, i_NewVehicle);
        }

        public List<Vehicle> GetGarageVehiclesByFixState(GarageVehicle.eFixState i_FixState)
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
        public void ChangeVehicleState(string i_LicenseNumber , GarageVehicle.eFixState i_FixState)
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

        public void RefuelVehicle(string i_LicenseNumber,FuelVehicle.eFuelType i_FuelType,float i_LitersOfFuelToAdd)
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
