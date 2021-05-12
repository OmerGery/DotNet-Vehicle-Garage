using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBike : ElectricVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_MaxPsiOfWheels = 30;
        private const float k_MaxHoursOfBattery =(float) 1.8;
        private Bike m_Bike;
        public ElectricBike(GarageEnums.eBikeLicenceType i_BikeLicenseType, int i_EngineCcVolume, string i_ModelName, string i_LicenseNumber, string i_TireManufacturerName, int i_CurrentTirePressure,float i_HoursOfBatteryLeft)
            : base(k_MaxHoursOfBattery,i_ModelName,i_LicenseNumber,i_HoursOfBatteryLeft,
                i_TireManufacturerName,i_CurrentTirePressure,k_MaxPsiOfWheels,k_AmountOfWheels)
        {
            m_Bike = new Bike(i_BikeLicenseType, i_EngineCcVolume);
        }
        //public static List<VehicleParam> GetParams()
        //{
        //    return new List<VehicleParam>() { new VehicleParam() { Name = "m_ContainsToxic", FriendlyName = "Contains Toxic", Type = typeof(bool) } };
        //}
    }
}
