namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentPsiTirePressure;
        private float m_MaxPsiTirePressure;

        public Tire(string i_ManufacturerName, float i_CurrentPsiTirePressure, float i_MaxPsiTirePressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentPsiTirePressure = i_CurrentPsiTirePressure;
            m_MaxPsiTirePressure = i_MaxPsiTirePressure;
        }
        
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                m_ManufacturerName = value;
            }
        }

        public float MaxPsiTirePressure
        {
            get
            {
                return m_MaxPsiTirePressure;
            }

            set
            {
                m_MaxPsiTirePressure = value;
            }
        }

        public float CurrentPsiTirePressure
        {
            get
            {
                return m_CurrentPsiTirePressure;
            }

            set
            {
                if (value > m_MaxPsiTirePressure || value < 0)
                {
                    throw new ValueOutOfRangeException(0, m_MaxPsiTirePressure, "Tire Psi");
                }

                m_CurrentPsiTirePressure = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Wheel Manufacturer Name: {0} 
Current Psi Tire Pressure: {1}
Max Psi Tire Pressure: {2}
",
m_ManufacturerName,
m_CurrentPsiTirePressure,
m_MaxPsiTirePressure);
        }
    }
}