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

        public static ElectricCar ElectricCarBuilder(string i_ModelName,string i_LicenseNumber,float i_EnergyPercentageLeft )
        {
            return new ElectricCar(i_ModelName, i_LicenseNumber,i_EnergyPercentageLeft);
        }
    }
}
