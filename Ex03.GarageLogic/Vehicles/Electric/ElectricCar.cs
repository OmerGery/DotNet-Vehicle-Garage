using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_MaxPsiOfWheels = 32;
        private const float k_MaxHoursOfBattery = (float)3.2;
        private Car m_Car;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
            : base(k_MaxHoursOfBattery, i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, i_TireManufacturerName, i_CurrentTirePressure, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Car = new Car(GarageEnums.eColor.Black, GarageEnums.eNumberOfDoors.Five);
        }
        //public static List<VehicleParam> GetParams()
        //{
        //    return new List<VehicleParam>() { new VehicleParam() { Name = "m_ContainsToxic", FriendlyName = "Contains Toxic", Type = typeof(bool) } };
        //}
    }
}
