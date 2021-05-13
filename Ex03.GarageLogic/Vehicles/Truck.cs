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

        public Truck(Dictionary<string, VehicleParam> i_UniqueParameters)
        {
            bool.TryParse(i_UniqueParameters["m_ContainsToxic"].m_Value,out m_ContainsToxic);
            // m_ContainsToxic =(bool) i_UniqueParameters["m_ContainsToxic"].m_Value;
            float.TryParse(i_UniqueParameters["m_MaxCarryWeight"].m_Value, out m_MaxCarryWeight);
        }
        public static List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            VehicleParam containsToxic = new VehicleParam("m_ContainsToxic","Does it contain toxic?",typeof(bool));
            VehicleParam maxCarryWeight = new VehicleParam("m_MaxCarryWeight", "The max carry weight", typeof(float));
            parmatersList.Add(containsToxic);
            parmatersList.Add(maxCarryWeight);
            return parmatersList;
        }

    }

}
