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

        public Truck(Dictionary<string, VehicleParam> i_Parameters)
        {
             m_ContainsToxic = (bool)i_Parameters["m_ContainsToxic"].Value;
             m_MaxCarryWeight = (float)i_Parameters["m_MaxCarryWeight"].Value;
        }
        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_ContainsToxic", "Does it contain toxic?", typeof(bool)),
                           new VehicleParam("m_MaxCarryWeight", "The max carry weight", typeof(float))
                       };
        }

    }

}
