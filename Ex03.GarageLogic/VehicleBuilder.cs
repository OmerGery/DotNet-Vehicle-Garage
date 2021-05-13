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


        public static Vehicle BuildVehicle(eVehicleType i_SelectedType , Dictionary<string,VehicleParam> i_Parameters)
        {
            Vehicle newVehicle = null;
            switch(i_SelectedType)
            {
                case eVehicleType.FuelTruck:
                    newVehicle = new FuelTruck(i_Parameters);
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
                    paramaters = FuelTruck.GetParams();
                    break;
                case eVehicleType.ElectricCar:
                    break;
            }

            return paramaters;
        }
    }
}
