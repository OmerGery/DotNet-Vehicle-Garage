using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBike : FuelVehicle
    {
        private const int k_AmountOfWheels = 2;
        private const int k_PsiOfWheels = 30;
        private Bike m_Bike;

        public FuelBike(GarageEnums.eFuelType i_FuelType, float i_MaxFuelLitersCapacity, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft) :
            base(GarageEnums.eFuelType.Octan98, i_MaxFuelLitersCapacity,  i_ModelName,  i_LicenseNumber,  i_EnergyPercentageLeft,  k_PsiOfWheels, k_AmountOfWheels)
        {
            m_Bike = new Bike(GarageEnums.eBikeLicenceType.A, 125);
        }
    }
}