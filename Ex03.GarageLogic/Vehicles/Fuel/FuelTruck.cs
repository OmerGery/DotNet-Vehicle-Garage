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

        public FuelTruck(Dictionary<string, VehicleParam> i_UniqueParameters, string i_LicenseNumber,
                         string i_ModelName, string i_WheelManufacturer, string i_OwnerPhone, string i_OwnerName, int i_CurrentPsi)
            : base(GarageEnums.eFuelType.Soler,k_MaxLitersOfFuel,i_ModelName,i_LicenseNumber, 0, "omer", 0, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Truck = new Truck(i_UniqueParameters);
        }

    }
}
