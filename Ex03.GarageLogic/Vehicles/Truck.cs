using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck
    {
        protected bool m_ContainsToxic;
        protected float m_MaxCarryWeight;

        public Truck(bool i_ContainsToxic, float i_MaxCarryWeight)
        {
            m_ContainsToxic = i_ContainsToxic;
            m_MaxCarryWeight = i_MaxCarryWeight;
        }
    }
}
