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
        private const float k_FuelTankInLiters = (float)6;
        private Bike m_Bike;

        public FuelBike(GarageEnums.eFuelType i_FuelType, GarageEnums.eBikeLicenceType i_BikeLicenseType,int i_EngineCcVolume, string i_ModelName, string i_LicenseNumber, float i_EnergyPercentageLeft, string i_TireManufacturerName, int i_CurrentTirePressure) :
            base(i_FuelType, k_FuelTankInLiters,  i_ModelName,  i_LicenseNumber,  i_EnergyPercentageLeft, i_TireManufacturerName, i_CurrentTirePressure, k_MaxPsiOfWheels, k_AmountOfWheels)
        {
            m_Bike = new Bike(i_BikeLicenseType, i_EngineCcVolume);
        }
        public override List<VehicleParam> GetParams()
        {
            return new List<VehicleParam>() { new VehicleParam() { Name = "m_ContainsToxic", FriendlyName = "Contains Toxic", Type = typeof(bool) } };
        }
    }
}