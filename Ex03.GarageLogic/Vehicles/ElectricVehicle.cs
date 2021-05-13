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

        public override float EnergyOfPrecentageLeft
        {
            get
            {
                return m_CurrentHoursOfBatteryLeft * 100 / m_MaxHoursOfBattery;
            }
        }

        public ElectricVehicle(Dictionary<string, VehicleParam> i_Parameters, float i_MaxHoursOfBattery,int i_MaxTirePressure, int i_AmountOfTire) : 
            base(i_Parameters, i_MaxTirePressure, i_AmountOfTire)
        {
            m_CurrentHoursOfBatteryLeft = (float)i_Parameters["m_CurrentHoursOfBatteryLeft"].Value;
            m_MaxHoursOfBattery = i_MaxHoursOfBattery;
        }
        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_CurrentHoursOfBatteryLeft", "Hours of Battery Left", typeof(float))
                       };
        }
    }
}
