using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricBike : ElectricVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_MaxPsiOfWheels = 30;
        private const float k_MaxHoursOfBattery = (float)1.8;
        private Bike m_Bike;

        public ElectricBike(Dictionary<string, VehicleParam> i_Parameters)
            : base(i_Parameters, k_MaxHoursOfBattery, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Bike = new Bike(i_Parameters);
        }

        public static new List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(ElectricVehicle.GetParams());
            parmatersList.AddRange(Bike.GetParams());

            return parmatersList;
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string bikeDetails = m_Bike.ToString();
            string details = baseDetails + bikeDetails;
            return details;
        }
    }
}
