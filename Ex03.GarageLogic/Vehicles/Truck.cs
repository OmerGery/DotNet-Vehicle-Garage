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

        public Truck(bool i_ContainsToxic , float i_MaxCarryWeight)
        {
            m_ContainsToxic = i_ContainsToxic;
            m_MaxCarryWeight = i_MaxCarryWeight;
        }
        public static List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            VehicleParam containsToxic = new VehicleParam("m_ContainsToxic","Does it contain toxic?",true,typeof(bool));
            VehicleParam maxCarryWeight = new VehicleParam("m_MaxCarryWeight", "The max carry weight", 0, typeof(float));
            parmatersList.Add(containsToxic);
            parmatersList.Add(maxCarryWeight);
            return parmatersList;
        }

    }

}
