using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class FuelTruck : FuelVehicle
    {
        private const int k_AmountOfWheels = 16;
        private const int k_MaxPsiOfWheels = 26;
        private const float k_MaxLitersOfFuel = (float)120;
        private const GarageEnums.eFuelType k_FuelType = GarageEnums.eFuelType.Soler;
        public Truck m_Truck;

        public FuelTruck(Dictionary<string, VehicleParam> i_Parameters)
            : base(i_Parameters, k_MaxLitersOfFuel, k_MaxPsiOfWheels, k_AmountOfWheels, k_FuelType)
        {
            m_Truck = new Truck(i_Parameters);
        }

        public static new List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(FuelVehicle.GetParams());
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
