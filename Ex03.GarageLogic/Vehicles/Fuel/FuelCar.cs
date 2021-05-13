using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_MaxPsiOfWheels = 32;   
        private const float k_MaxFuelTankInLiters = 45;

        private Car m_Car;

        public FuelCar(Dictionary<string, VehicleParam> i_Parameters) :
            base(i_Parameters, k_MaxFuelTankInLiters, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Car = new Car(i_Parameters);
        }

        public static List<VehicleParam> GetParams()
        {
            List<VehicleParam> parmatersList = new List<VehicleParam>();
            parmatersList.AddRange(Vehicle.GetParams());
            parmatersList.AddRange(FuelVehicle.GetParams());
            parmatersList.AddRange(Car.GetParams());

            return parmatersList;
        }
    }
}