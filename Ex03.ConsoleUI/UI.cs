using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_Garage;

        public UI()
        {
            m_Garage = new Garage();
        }
        public void GetLicenseNumberAndModelNameFromUser(out string o_LicenseNumber, out string o_ModelName)
        {
            Console.WriteLine("Please enter the vehicle license number:");
            o_LicenseNumber = Console.ReadLine();
            Console.WriteLine("Please enter the vehicle model name:");
            o_ModelName = Console.ReadLine();
        }

        public void GetWheelInformation(out string o_Manufacturer, out int o_CurrentPsi)//, out int o_MaxPsi)
        {
            Console.WriteLine("Please enter the wheel manufacturer name:");
            o_Manufacturer = Console.ReadLine();
            Console.WriteLine("Please enter the current PSI of the wheels:");
            int.TryParse(Console.ReadLine(), out o_CurrentPsi);
            //Console.WriteLine("Please enter the max PSI of the wheels:");
            //int.TryParse(Console.ReadLine(), out o_MaxPsi);
        }

        public void GetOwnerDetails(out string o_OwnerPhone, out string o_OwnerName)
        {
            Console.WriteLine("Please enter the owner phone number:");
            o_OwnerPhone = Console.ReadLine();
            Console.WriteLine("Please enter the owner name:");
            o_OwnerName = Console.ReadLine();
        }
        public void GetGeneralVehicleDetails(out string o_OwnerPhone,out string o_OwnerName, out string o_LicenseNumber, out string o_ModelName, out string o_WheelManufacturer, out int o_CurrentPsi)//, out int o_MaxPsi)
        {
            GetOwnerDetails(out o_OwnerPhone,out o_OwnerName);
            GetLicenseNumberAndModelNameFromUser(out o_LicenseNumber, out o_ModelName);
            GetWheelInformation(out o_WheelManufacturer, out o_CurrentPsi);
        }

        public void GetBikeDetails(out int o_EngineVolume,out GarageEnums.eBikeLicenceType o_LicenseType)
        {
            Console.WriteLine("Please enter the engine volume:");
            int.TryParse(Console.ReadLine(), out o_EngineVolume);
            Console.WriteLine("Please enter the license type (A/AA/B1/BB");
            //GarageEnums.eBikeLicenceType.TryParse(Console.ReadLine(), out o_LicenseType);
            o_LicenseType = GarageEnums.eBikeLicenceType.A;
        }
        public void AddElectricBike()
        {
            string licenseNumber, modelName, wheelManufacturer,ownerPhone,ownerName;
            int engineVolume, currentPsi;
            GarageEnums.eBikeLicenceType licenseType;
            GetGeneralVehicleDetails(
                out ownerPhone,
                out ownerName, out licenseNumber, out modelName, out wheelManufacturer, out currentPsi);//,out maxPsi);
            GetBikeDetails(out engineVolume, out licenseType);
            ElectricBike bikeToAdd = VehicleBuilder.ElectricBikeBuilder(
                licenseType,
                engineVolume, modelName, licenseNumber, 1, wheelManufacturer,
                currentPsi);
            m_Garage.AddVehicle(ownerPhone,ownerName, bikeToAdd);
        }

        public void RefuelVehicle()
        {
            //string i_LicenseNumber, GarageEnums.eFuelType i_FuelType,float i_LitersOfFuelToAd
            //Console.ReadLine()
        }

        public void ChargeVehicle()
        {
            string licenseNumber;
            float minutesToCharge;
            Console.WriteLine(@"please enter license number and minutes to charge");

            try
            {
                licenseNumber = Console.ReadLine();
                float.TryParse(Console.ReadLine(), out minutesToCharge);
                m_Garage.ChargeVehicle(licenseNumber, minutesToCharge);
            }
            catch(ValueOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }

            
        }

        public void DisplayMenu()
        {
            Console.WriteLine(@"The Garage Menu:
For Adding Electric Bike : Press 1
For  Other stuff..... there is time");
        }
    }
}
