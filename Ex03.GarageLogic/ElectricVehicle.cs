using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_HoursOfBatteryLeft;
        private float m_MaxTimeOfBattery;

        public void ChargeBattery(float i_HoursToCharge)
        {
            // EXCEPTION CHECK ! ! ! 
            m_HoursOfBatteryLeft += i_HoursToCharge;
        }

    }
}
