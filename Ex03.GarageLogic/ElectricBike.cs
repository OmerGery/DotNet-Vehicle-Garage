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

        public ElectricBike(GarageEnums.eBikeLicenceType i_BikeLicenseType, int i_EngineCcVolume, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
            : base(k_MaxHoursOfBattery, i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, i_TireManufacturerName, i_CurrentTirePressure, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Bike = new Bike(i_BikeLicenseType, i_EngineCcVolume);
        }
    }
}
