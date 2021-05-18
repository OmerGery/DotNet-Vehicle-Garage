using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class ElectricVehicle : Vehicle
    {
        private float m_MaxHoursOfBattery;
        private float m_CurrentHoursOfBatteryLeft;

        public static new List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_CurrentHoursOfBatteryLeft", "Hours of Battery Left", typeof(float))
                       };
        }

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
                    throw new ValueOutOfRangeException(0, m_MaxHoursOfBattery - m_CurrentHoursOfBatteryLeft, "Battery Amount Hours");
                }

                m_CurrentHoursOfBatteryLeft = value;
            }
        }

        public void ChargeBattery(float i_HoursOfBatteryToCharge)
        {
            if(i_HoursOfBatteryToCharge + m_CurrentHoursOfBatteryLeft > m_MaxHoursOfBattery || i_HoursOfBatteryToCharge <= 0)
            {
                throw new ValueOutOfRangeException(0, m_MaxHoursOfBattery - m_CurrentHoursOfBatteryLeft, "Battery hours to add");
            }

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

        public void Init(Dictionary<string, VehicleParam> i_Parameters, float i_MaxHoursOfBattery, int i_MaxTirePressure, int i_AmountOfTire)
        {
            (this as Vehicle).Init(i_Parameters, i_MaxTirePressure, i_AmountOfTire);
            m_MaxHoursOfBattery = i_MaxHoursOfBattery;
            CurrentHoursOfBatteryLeft = (float)i_Parameters["m_CurrentHoursOfBatteryLeft"].Value;
        }
    }
}
