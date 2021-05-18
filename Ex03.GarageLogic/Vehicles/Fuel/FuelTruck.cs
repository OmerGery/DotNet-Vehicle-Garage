using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelTruck : FuelVehicle
    {
        private const int k_AmountOfWheels = 16;
        private const int k_MaxPsiOfWheels = 26;
        private const float k_MaxLitersOfFuel = 120;
        private const GarageEnums.eFuelType k_FuelType = GarageEnums.eFuelType.Soler;
        public Truck m_Truck;

        public override void InitNewVehicle(Dictionary<string, VehicleParam> i_Parameters)
        {
            Init(i_Parameters, k_MaxLitersOfFuel, k_MaxPsiOfWheels, k_AmountOfWheels, k_FuelType);
            m_Truck = new Truck(i_Parameters);
        }

        public override List<VehicleParam> GetNewVehicleParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(GetParams());
            parmatersList.AddRange(Truck.GetParams());
            return parmatersList;
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string truckDetails = m_Truck.ToString();
            string details = baseDetails + truckDetails;
            return details;
        }
    }
}
