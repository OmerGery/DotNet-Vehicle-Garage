using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        private GarageEnums.eBikeLicenceType m_LicenseType;
        private int m_EngineCcVolume;
        public Bike(Dictionary<string, VehicleParam> i_Parameters)
        {
            m_LicenseType = (GarageEnums.eBikeLicenceType)i_Parameters["m_LicenseType"].Value;
            m_EngineCcVolume = (int)i_Parameters["m_EngineCcVolume"].Value;
        }

        public static List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>()
                       {
                           new VehicleParam("m_LicenseType", "Kind of Bike License", typeof(GarageEnums.eBikeLicenceType)),
                           new VehicleParam("m_EngineCcVolume", "Engine Volume", typeof(int))
                       };
        }

        public override string ToString()
        {
            string details = string.Format(
@"Engine Volume: {0} cc
License Type: {1}",
m_EngineCcVolume,
m_LicenseType);
            return details;
        }
    }
}