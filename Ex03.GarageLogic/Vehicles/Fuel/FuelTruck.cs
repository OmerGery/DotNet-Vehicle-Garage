using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelTruck : FuelVehicle
    {
        private const int k_AmountOfWheels = 16;
        private const int k_MaxPsiOfWheels = 26;
        private const float k_MaxLitersOfFuel = (float)120;
        public Truck m_Truck;

        public FuelTruck(bool i_ContainsToxic,float i_MaxCarryWeight,string i_ModelName, string i_LicenseNumber,float i_LitersOfFuelLeft, string i_TireManufacturerName, int i_CurrentTirePressure)
            : base(GarageEnums.eFuelType.Soler,k_MaxLitersOfFuel,i_ModelName,i_LicenseNumber, i_LitersOfFuelLeft, i_TireManufacturerName, i_CurrentTirePressure, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Truck = new Truck(i_ContainsToxic, i_MaxCarryWeight);
        }

    }
}
