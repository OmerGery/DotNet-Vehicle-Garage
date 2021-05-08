using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Tire
    {
        private string m_ManufacturerName;
        private float m_CurrentPsiTirePressure;
        private float m_MaxPsiTirePressure;

        public Tire(string i_ManufacturerName, float i_MaxPsiTirePressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_MaxPsiTirePressure = m_CurrentPsiTirePressure = i_MaxPsiTirePressure;
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
                m_CurrentPsiTirePressure = value;
            }
        }
        public void PumpTire(float i_PsiOfAirToAdd)
        {
            // CHECK STUFFFFFF EXCEPTION!!!!
            m_CurrentPsiTirePressure += i_PsiOfAirToAdd;
        }
    }
}

