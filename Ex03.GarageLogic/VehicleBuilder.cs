namespace Ex03.GarageLogic
{
    public class VehicleBuilder
    {
        public enum eVehicleType
        {
            ElectricCar = 1,
            FuelCar,
            ElectricBike,
            FuelBike,
            FuelTruck
        }

        public static Vehicle BuildVehicle(eVehicleType i_SelectedType)
        {
            Vehicle newVehicle = null;
            switch(i_SelectedType)
            {
                case eVehicleType.FuelTruck:
                    newVehicle = new FuelTruck();
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new ElectricCar();
                    break;
                case eVehicleType.ElectricBike:
                    newVehicle = new ElectricBike();
                    break;
                case eVehicleType.FuelBike:
                    newVehicle = new FuelBike();
                    break;
                case eVehicleType.FuelCar:
                    newVehicle = new FuelCar();
                    break;
            }

            return newVehicle;
        }
    }
}
