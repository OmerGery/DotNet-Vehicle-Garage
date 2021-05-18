using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricCar : ElectricVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_MaxPsiOfWheels = 32;
        private const float k_MaxHoursOfBattery = (float)3.2;
        private Car m_Car;

        public override void InitNewVehicle(Dictionary<string, VehicleParam> i_Parameters)
        {
            Init(i_Parameters, k_MaxHoursOfBattery, k_MaxPsiOfWheels, k_AmountOfWheels);
            m_Car = new Car(i_Parameters);
        }

        public override List<VehicleParam> GetNewVehicleParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(ElectricVehicle.GetParams());
            parmatersList.AddRange(Car.GetParams());
            return parmatersList;
        }

        public override string ToString()
        {
            string baseDetails = base.ToString();
            string carDetails = m_Car.ToString();
            string details = baseDetails + carDetails;
            return details;
        }
    }
}
