using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_HoursOfBatteryLeft;
        private float m_MaxHoursOfBattery;

        public ElectricVehicle(float i_MaxHoursOfBattery, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, int i_TirePressure, int i_AmountOfTire) : 
            base(i_ModelName,  i_LicenseNumber, i_EnergyPercentageLeft, i_TirePressure,  i_AmountOfTire)
        {

        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            // EXCEPTION CHECK ! ! ! 
            m_HoursOfBatteryLeft += i_HoursToCharge;
        }

    }
}
