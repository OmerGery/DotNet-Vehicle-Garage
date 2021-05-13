using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_CurrentHoursOfBatteryLeft;

        public float CurrentHoursOfBatteryLeft
        {
            get
            {
                return m_CurrentHoursOfBatteryLeft;
            }
            set
            {
                if (value + m_CurrentHoursOfBatteryLeft > m_MaxHoursOfBattery || value < 0)
                {
                    throw new ValueOutOfRangeException(0, m_MaxHoursOfBattery - m_CurrentHoursOfBatteryLeft);
                }
                else
                {
                    m_CurrentHoursOfBatteryLeft += value;
                }
            }
        }
        private float m_MaxHoursOfBattery;

        public ElectricVehicle(float i_MaxHoursOfBattery, string i_ModelName, string i_LicenseNumber, float i_HoursOfBatteryLeft, string i_TireManufacturerName, int i_CurrentTirePressure, int i_TirePressure, int i_AmountOfTire) : 
            base(i_ModelName,  i_LicenseNumber, (i_HoursOfBatteryLeft/i_MaxHoursOfBattery) * 100,i_TireManufacturerName,i_CurrentTirePressure, i_TirePressure,  i_AmountOfTire)
        {
            m_CurrentHoursOfBatteryLeft = i_HoursOfBatteryLeft;
            m_MaxHoursOfBattery = i_MaxHoursOfBattery;
        }

    }
}
