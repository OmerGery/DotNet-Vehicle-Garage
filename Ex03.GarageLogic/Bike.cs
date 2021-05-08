using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Bike
    {
        public enum eLicenceType
        {
            A,
            B1,
            AA,
            BB
        }

        private eLicenceType m_LicenceType;
        private int m_EngineCcVolume;

        public Bike(eLicenceType i_LicenceType,int i_EngineCcVolume)
        {
            m_LicenceType = i_LicenceType;
            m_EngineCcVolume = i_EngineCcVolume;
        }

    }
}