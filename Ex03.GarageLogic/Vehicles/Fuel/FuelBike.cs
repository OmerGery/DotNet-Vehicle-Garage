using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelBike : FuelVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_MaxPsiOfWheels = 30;
        private const float k_MaxFuelTankInLiters = 6;
        private const GarageEnums.eFuelType k_FuelType = GarageEnums.eFuelType.Octan98;
        private Bike m_Bike;

        public override void InitNewVehicle(Dictionary<string, VehicleParam> i_Parameters)
        {
            Init(i_Parameters, k_MaxFuelTankInLiters, k_MaxPsiOfWheels, k_AmountOfWheels, k_FuelType);
            m_Bike = new Bike(i_Parameters);
        }

        public override List<VehicleParam> GetNewVehicleParams()
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