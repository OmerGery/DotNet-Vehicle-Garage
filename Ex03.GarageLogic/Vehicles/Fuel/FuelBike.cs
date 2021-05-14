using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBike : FuelVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_MaxPsiOfWheels = 30;
        private const float k_MaxFuelTankInLiters = 6;
        private const GarageEnums.eFuelType k_FuelType = GarageEnums.eFuelType.Octan98;
        private Bike m_Bike;

        public FuelBike(Dictionary<string, VehicleParam> i_Parameters) :
            base(i_Parameters, k_MaxFuelTankInLiters, k_MaxPsiOfWheels, k_AmountOfWheels, k_FuelType)
        {
            m_Bike = new Bike(i_Parameters);
        }

        public static new List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(FuelVehicle.GetParams());
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