using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {


        private GarageEnums.eBikeLicenceType m_LicenceType;
        private int m_EngineCcVolume;

        public Bike(GarageEnums.eBikeLicenceType i_LicenceType,int i_EngineCcVolume)
        {
            m_LicenceType = i_LicenceType;
            m_EngineCcVolume = i_EngineCcVolume;
        }

    }
}