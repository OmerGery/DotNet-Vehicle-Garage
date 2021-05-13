using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricBike,
            FuelBike,
            FuelTruck
        }


        public static Vehicle BuildVehicle(eVehicleType i_SelectedType , Dictionary<string,VehicleParam> i_UniqueParameters, string i_LicenseNumber, 
        string i_ModelName, string i_WheelManufacturer, string i_OwnerPhone, string i_OwnerName,int i_CurrentPsi)
        {
            Vehicle newVehicle = null;
            switch(i_SelectedType)
            {
                case eVehicleType.FuelTruck:
                    newVehicle = new FuelTruck(i_UniqueParameters,i_LicenseNumber,i_ModelName,i_WheelManufacturer,i_OwnerPhone,i_OwnerName,i_CurrentPsi);
                    break;
                case eVehicleType.ElectricCar:
                    break;
            }

            return newVehicle;
        }

        public static List<VehicleParam> GetParams(eVehicleType i_SelectedType)
        {
            List<VehicleParam> paramaters = new List<VehicleParam>(); 
            switch (i_SelectedType)
            {
                case eVehicleType.FuelTruck:
                    paramaters = Truck.GetParams();
                    break;
                case eVehicleType.ElectricCar:
                    break;
            }

            return paramaters;
        }
    }
}
