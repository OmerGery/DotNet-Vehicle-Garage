using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBike : ElectricVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_PsiOfWheels = 30;
        private const float k_MaxHoursOfBattery =(float) 1.8;
        private Bike m_Bike;

        public ElectricBike(float i_MaxHoursOfBattery, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft)
            : base(i_MaxHoursOfBattery, i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, k_PsiOfWheels, k_AmountOfWheels)
        {
            m_Bike = new Bike(GarageEnums.eBikeLicenceType.A, 125);
        }
    }
}
