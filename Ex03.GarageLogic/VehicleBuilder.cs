using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public enum eVehicleTypes
        {
            ElectricCar,
            FuelCar,
            ElectricBike,
            FuelBike,
            FuelTruck
        }

        public static ElectricCar ElectricCarBuilder(string i_ModelName,string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
        {
            return new ElectricCar(i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, i_TireManufacturerName, i_CurrentTirePressure);
        }

        public static FuelCar FuelCarBuilder(GarageEnums.eFuelType i_FuelType, GarageEnums.eColor i_CarColor, GarageEnums.eNumberOfDoors i_NumberOfDoors, string i_ModelName, string i_LicenseNumber, float i_LitersOfFuelLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
        {
            return new FuelCar(i_FuelType, i_CarColor, i_NumberOfDoors, i_ModelName, i_LicenseNumber, i_LitersOfFuelLeft, i_TireManufacturerName, i_CurrentTirePressure);
        }
        public static ElectricBike ElectricBikeBuilder(GarageEnums.eBikeLicenceType i_BikeLicenseType, int i_EngineCcVolume, string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
        {
            return new ElectricBike(i_BikeLicenseType, i_EngineCcVolume, i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, i_TireManufacturerName, i_CurrentTirePressure);
        }
        public static FuelBike FuelBikeBuilder(GarageEnums.eFuelType i_FuelType, GarageEnums.eBikeLicenceType i_BikeLicenseType, int i_EngineCcVolume, string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
        {
            return new FuelBike(i_FuelType, i_BikeLicenseType, i_EngineCcVolume, i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, i_TireManufacturerName, i_CurrentTirePressure);
        }
        public static FuelTruck FuelTruckBuilder(bool i_ContainsToxic, float i_MaxCarryWeight, string i_ModelName, string i_LicenseNumber, float i_LitersOfFuelLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
        {
            return new FuelTruck(i_ContainsToxic, i_MaxCarryWeight, i_ModelName, i_LicenseNumber, i_LitersOfFuelLeft, i_TireManufacturerName, i_CurrentTirePressure);
        }
    }
}
