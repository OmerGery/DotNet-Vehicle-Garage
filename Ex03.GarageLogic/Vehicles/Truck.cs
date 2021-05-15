using System.Collections.Generic;

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
                           new VehicleParam("m_ContainsToxic", "Does it contain toxic? (True/False)", typeof(bool)),
                           new VehicleParam("m_MaxCarryWeight", "The max carry weight", typeof(float))
                       };
        }

        public override string ToString()
        {
            string details = string.Format(
@"Toxic Contents: {0}
Maximum Carry Weight: {1}",
m_ContainsToxic,
m_MaxCarryWeight);

            return details;
        }
    }
}
