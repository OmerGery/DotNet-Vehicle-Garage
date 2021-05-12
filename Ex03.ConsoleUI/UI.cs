using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
            bool isValid = false;
            string licenseNumber;
            float minutesToCharge;
            Console.WriteLine(@"please enter license number and minutes to charge");
            while(!isValid)
            {
                isValid = true;
                try
                {
                    licenseNumber = Console.ReadLine();
                    float.TryParse(Console.ReadLine(), out minutesToCharge);
                    m_Garage.ChargeVehicle(licenseNumber, minutesToCharge / 60);
                }
                catch(ValueOutOfRangeException rangeException)
                {
                    Console.WriteLine(
                        @"The amount of minutes to charge you can select is between {0} and {1} , please try again.",
                        rangeException.MinValue*60,
                        rangeException.MaxValue*60);
                    isValid = false;
                }
                catch(FormatException formatException)
                {
                    Console.WriteLine("Format Exception");
                    isValid = false;
                }
                catch(ArgumentException argumentException)
                {
                    Console.WriteLine("Argu exception");
                    isValid = false;
                }
            }


        }

        private enum eMainMenuOptions
        {
            GarageMenu = 1,
            VehicleMaintenance,
            DisplayVehicleDetails
        }
        private enum eDisplayMenuOptions
        {
            DisplayAllVehicles = 1,
            DisplayCertainVehicle,
        }
        private enum eMaintenanceMenu
        {
            RefuelVehicle = 1,
            ChargeVehicle,
            PumpVehicleTires
        }
        private enum eGarageMenu
        {
            AddVehicle = 1,
            ChangeVehicleStatus
        }

        private void AddVehicle()
        {
            // mitragshim mize
        }
        private void ChangeVehicleStatus()
        {
            // mitragshim mize
        }

        private void PumpVehicleTires()
        {

        }
        public void GarageMenu()
        {
            eGarageMenu UserSelection = eGarageMenu.AddVehicle;
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                Console.WriteLine(
                    @"The Garage Menu:
1:Add vehicle.
2:Change vehicle status");
                try
                {
                    eGarageMenu.TryParse(Console.ReadLine(), out UserSelection);
                }
                catch (ArgumentException argumentException)
                {
                    isValid = false;
                    Console.WriteLine("Please select a number between 1 and 3");
                }
            }

            switch (UserSelection)
            {
                case eGarageMenu.AddVehicle:
                    AddVehicle();
                    break;
                case eGarageMenu.ChangeVehicleStatus:
                    ChangeVehicleStatus();
                    break;
            }
        }

        public void VehicleMaintenance()
        {
            eMaintenanceMenu UserSelection = eMaintenanceMenu.ChargeVehicle;
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                Console.WriteLine(
                    @"The Maintenance Menu:
1: Refuel a vehicle,
2: Charge a vehicle,
3: Pump  vehicle tires");
                try
                {
                    eGarageMenu.TryParse(Console.ReadLine(), out UserSelection);
                }
                catch (ArgumentException argumentException)
                {
                    isValid = false;
                    Console.WriteLine("Please select an option from the menu.");
                }
            }

            switch (UserSelection)
            {
                case eMaintenanceMenu.RefuelVehicle:
                    AddVehicle();
                    break;
                case eMaintenanceMenu.ChargeVehicle:
                    ChangeVehicleStatus();
                    break;
                case eMaintenanceMenu.PumpVehicleTires:
                    PumpVehicleTires();
                    break;
            }
        }

        public void DisplayDetailsMenu()
        {
            eDisplayMenuOptions UserSelection = eDisplayMenuOptions.DisplayAllVehicles;
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                Console.WriteLine(
                    @"The Display Menu:
1:Display all vehicles.
2:Display details about a certain vehicle.");
                try
                {
                    eDisplayMenuOptions.TryParse(Console.ReadLine(), out UserSelection);
                }
                catch (ArgumentException argumentException)
                {
                    isValid = false;
                    Console.WriteLine("Please select an option from the menu.");
                }
            }

            switch (UserSelection)
            {
                case eDisplayMenuOptions.DisplayAllVehicles:
                    //DisplayAllVehicles();
                    break;
                case eDisplayMenuOptions.DisplayCertainVehicle:
                    //DisplayCertainVehicle();
                    break;
            }
        }

        private void invalidMenuOptionSelection(out bool o_Validity)
        {
            Console.Clear();
            o_Validity = false;
            Console.WriteLine("Please select an option from the menu.");
        }


        public void DisplayMainMenu()
        {
            int amountOfOptions = Enum.GetNames(typeof(eMainMenuOptions)).Length;
            eMainMenuOptions UserSelection = eMainMenuOptions.GarageMenu;
            bool isValid = false;
            while(!isValid)
            {
                isValid = true;
                Console.WriteLine(
                    @"The Garage Menu:
1:Garage actions menu(add/change status of vehicle).
2:Preform a maintenance action.
3:Display details about a vehicle.");
                try
                {
                    UserSelection = (eMainMenuOptions)Enum.Parse(typeof(eMainMenuOptions), Console.ReadLine());
                    if((int)UserSelection < 1 || (int)UserSelection > amountOfOptions)
                        throw new ValueOutOfRangeException(1, amountOfOptions);
                }
                catch(ArgumentException argumentException)
                {
                    invalidMenuOptionSelection(out isValid);
                    
                }
                catch(ValueOutOfRangeException valueOutOfRangeException)
                {
                    invalidMenuOptionSelection(out isValid);
                }
            }

            switch(UserSelection)
            {
                case eMainMenuOptions.GarageMenu:
                    GarageMenu();
                    break;
                case eMainMenuOptions.DisplayVehicleDetails:
                    DisplayDetailsMenu();
                    break;
                case eMainMenuOptions.VehicleMaintenance:
                    VehicleMaintenance();
                    break;
            }
        }
    }
}
