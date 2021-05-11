using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentHoursOfBatteryLeft;
        private float m_MaxHoursOfBattery;

        public ElectricVehicle(float i_MaxHoursOfBattery, string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure, int i_TirePressure, int i_AmountOfTire) : 
            base(i_ModelName,  i_LicenseNumber, (i_HoursOfBatteryLeft/i_MaxHoursOfBattery) * 100,i_TireManufacturerName,i_CurrentTirePressure, i_TirePressure,  i_AmountOfTire)
        {
            m_CurrentHoursOfBatteryLeft = i_HoursOfBatteryLeft;
            m_MaxHoursOfBattery = i_MaxHoursOfBattery;
        }

        public void ChargeBattery(float i_HoursToCharge)
        {
            if(i_HoursToCharge + m_CurrentHoursOfBatteryLeft > m_MaxHoursOfBattery)
            {
                throw new ValueOutOfRangeException(0, m_MaxHoursOfBattery - m_CurrentHoursOfBatteryLeft);
            }
            else
            {
                m_CurrentHoursOfBatteryLeft += i_HoursToCharge;
            }
            
        }

    }
}
