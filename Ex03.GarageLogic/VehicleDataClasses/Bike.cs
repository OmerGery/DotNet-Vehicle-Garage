using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Bike
    {
        private readonly GarageEnums.eBikeLicenceType r_LicenseType;
        private int m_EngineCcVolume;
        public Bike(Dictionary<string, VehicleParam> i_Parameters)
        {
            r_LicenseType = (GarageEnums.eBikeLicenceType)i_Parameters["m_LicenseType"].Value;
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
@"Engine Volume: {0}cc
License Type: {1}",
m_EngineCcVolume,
r_LicenseType);
            return details;
        }
    }
}