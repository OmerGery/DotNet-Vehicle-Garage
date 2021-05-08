using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_PsiOfWheels = 32;
        private const float k_MaxHoursOfBattery = (float)3.2;
        private Car m_Car;

        public ElectricCar(string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft)
            : base(k_MaxHoursOfBattery, i_ModelName, i_LicenseNumber, i_HoursOfBatteryLeft, k_PsiOfWheels, k_AmountOfWheels)
        {

        }
    }
}
