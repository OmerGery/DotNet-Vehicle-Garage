﻿using System;
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

        public float MaxPsiTirePressure
        {
            get
            {
                return m_MaxPsiTirePressure;
            }
        }

        public float CurrentPsiTirePressure
        {
            get
            {
                return m_CurrentPsiTirePressure;
            }
        }
        public void PumpTire(float i_PsiOfAirToAdd)
        {
            // CHECK STUFFFFFF EXCEPTION!!!!
            m_CurrentPsiTirePressure += i_PsiOfAirToAdd;
        }
    }
}

