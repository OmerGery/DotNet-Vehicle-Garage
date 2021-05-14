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

        public float CurrentHoursOfBatteryLeft
        {
            get
            {
                return m_CurrentHoursOfBatteryLeft;
            }

            set
            {
                if (value > m_MaxHoursOfBattery || value < 0)
                {
                    throw new ValueOutOfRangeException(0, m_MaxHoursOfBattery - m_CurrentHoursOfBatteryLeft, "Battery Amount");
                }

                m_CurrentHoursOfBatteryLeft = value;
            }
        }

        public static new List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_CurrentHoursOfBatteryLeft", "Hours of Battery Left", typeof(float))
                       };
        }

        public void ChargeBattery(float i_HoursOfBatteryToCharge)
        {
            CurrentHoursOfBatteryLeft += i_HoursOfBatteryToCharge;
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string details = string.Format(
@"Hours Of Battery Left: {0}
Max Hours Of Battery: {1}
",
m_CurrentHoursOfBatteryLeft,
m_MaxHoursOfBattery);
            return baseDetails + details;
        }

        public override float EnergyOfPrecentageLeft
        {
            get
            {
                return m_CurrentHoursOfBatteryLeft * 100 / m_MaxHoursOfBattery;
            }
        }

        public ElectricVehicle(Dictionary<string, VehicleParam> i_Parameters, float i_MaxHoursOfBattery, int i_MaxTirePressure, int i_AmountOfTire) : 
            base(i_Parameters, i_MaxTirePressure, i_AmountOfTire)
        {
            m_MaxHoursOfBattery = i_MaxHoursOfBattery;
            CurrentHoursOfBatteryLeft = (float)i_Parameters["m_CurrentHoursOfBatteryLeft"].Value;
        }
    }
}
