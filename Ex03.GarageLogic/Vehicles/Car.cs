using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car
    {
        private GarageEnums.eColor m_CarColor;
        private GarageEnums.eNumberOfDoors m_NumberOfDoors;

        public Car(GarageEnums.eColor i_CarColor,GarageEnums.eNumberOfDoors i_NumberOfDoors)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }
    }
}
