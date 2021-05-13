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

        public Car(Dictionary<string, VehicleParam> i_Parameters)
        {
            m_CarColor = (GarageEnums.eColor)i_Parameters["m_CarColor"].Value;
            m_NumberOfDoors = (GarageEnums.eNumberOfDoors)i_Parameters["m_NumberOfDoors"].Value; ;
        }
        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_CarColor", "Car Color", typeof(GarageEnums.eColor)),
                           new VehicleParam("m_NumberOfDoors", "Number of Doors", typeof(GarageEnums.eNumberOfDoors))
                       };
        }
    }
}
