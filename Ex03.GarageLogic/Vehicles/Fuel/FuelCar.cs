using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_MaxPsiOfWheels = 32;   
        private const float k_FuelTankInLiters = (float)45;

        private Car m_Car;

        public FuelCar (GarageEnums.eFuelType i_FuelType, GarageEnums.eColor i_CarColor,GarageEnums.eNumberOfDoors i_NumberOfDoors, string i_ModelName, string i_LicenseNumber, float i_LitersOfFuelLeft, string i_TireManufacturerName, int i_CurrentTirePressure) :
            base(i_FuelType, k_FuelTankInLiters, i_ModelName, i_LicenseNumber, i_LitersOfFuelLeft, i_TireManufacturerName, i_CurrentTirePressure, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Car = new Car(i_CarColor,i_NumberOfDoors);
        }
        //public static List<VehicleParam> GetParams()
        //{
        //    return new List<VehicleParam>() { new VehicleParam() { Name = "m_ContainsToxic", FriendlyName = "Contains Toxic", Type = typeof(bool) } };
        //}
    }
}