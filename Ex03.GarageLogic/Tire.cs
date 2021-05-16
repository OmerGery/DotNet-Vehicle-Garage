namespace Ex03.GarageLogic
{
    public class Tire
    {
        private readonly float r_MaxPsiTirePressure;
        private string m_ManufacturerName;
        private float m_CurrentPsiTirePressure;

        public Tire(string i_ManufacturerName, float i_CurrentPsiTirePressure, float i_MaxPsiTirePressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentPsiTirePressure = i_CurrentPsiTirePressure;
            r_MaxPsiTirePressure = i_MaxPsiTirePressure;
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
                return r_MaxPsiTirePressure;
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
                if (value > r_MaxPsiTirePressure || value < 0)
                {
                    throw new ValueOutOfRangeException(0, r_MaxPsiTirePressure, "Tire Psi");
                }

                m_CurrentPsiTirePressure = value;
            }
        }

        public void PumpTire(float i_PsiToAdd)
        {
            if(i_PsiToAdd + m_CurrentPsiTirePressure > r_MaxPsiTirePressure || i_PsiToAdd <= 0)
            {
                throw new ValueOutOfRangeException(0, r_MaxPsiTirePressure - m_CurrentPsiTirePressure, "PSI to add to tire");
            }

            CurrentPsiTirePressure += i_PsiToAdd;
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
r_MaxPsiTirePressure);
        }
    }
}