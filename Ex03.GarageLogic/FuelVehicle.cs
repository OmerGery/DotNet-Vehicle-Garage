using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class FuelVehicle : Vehicle
    {


        private float m_LitersOfFuelLeft;
        private float m_MaxFuelLitersCapacity;
        private GarageEnums.eFuelType m_fuelType;

        public FuelVehicle(GarageEnums.eFuelType i_FuelType, float i_MaxFuelLitersCapacity, string i_ModelName, string i_LicenseNumber, float i_LitersOfFuelLeft, string i_TireManufacturerName, int i_CurrentTirePressure, int i_MaxTirePressure, int i_AmountOfTire) : 
            base(i_ModelName, i_LicenseNumber, (i_LitersOfFuelLeft / i_MaxFuelLitersCapacity) * 100, i_TireManufacturerName, i_CurrentTirePressure, i_MaxTirePressure, i_AmountOfTire)
        {
            m_LitersOfFuelLeft = i_MaxFuelLitersCapacity;
            m_MaxFuelLitersCapacity = i_MaxFuelLitersCapacity;
            m_fuelType = i_FuelType;
        }
        public void Refuel(float i_LitersOfFuelToAdd, GarageEnums.eFuelType i_FuelType)
        {
            /// !!!! EXCEPTIONS 
            m_MaxFuelLitersCapacity += i_LitersOfFuelToAdd;
        }
    }
}
