using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelCar : FuelVehicle
    {
        private const int k_AmountOfWheels = 4;
        private const int k_PsiOfWheels = 32;   
        private const float k_FuelTankInLiters = (float)45;

        private Car m_Car;

        public FuelCar (GarageEnums.eColor i_CarColor,GarageEnums.eNumberOfDoors i_NumberOfDoors,GarageEnums.eFuelType i_FuelType, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft) :
            base(GarageEnums.eFuelType.Octan95, k_FuelTankInLiters, i_ModelName, i_LicenseNumber, i_EnergyPercentageLeft, k_PsiOfWheels, k_AmountOfWheels)
        {
            m_Car = new Car(i_CarColor,i_NumberOfDoors);
        }
    }
}