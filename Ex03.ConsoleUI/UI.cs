using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private const int k_SleepTime = 3000;
        private bool m_quitFlag;
        private Garage m_Garage;

        private enum eMainMenuOptions
        {
            AddVehicle = 1,
            DisplayVehiclesDetails,
            ChangeVehicleStatus,
            PumpVehicleTires,
            RefuelVehicle,
            ChargeVehicle,
            DisplayCertainVehicle,
            Quit
        }

        private enum eVehicleDisplayOptions
        {
            NoFilter = 1,
            WithFilter
        }

        public UI()
        {
            m_Garage = new Garage();
        }

        public static void DisplayEnumOptions<T>()
        {
            foreach (string options in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("For {0} press {1:D}", options, Enum.Parse(typeof(T), options));
            }
        }

        public void GetOwnerDetails(out string o_OwnerPhone, out string o_OwnerName)
        {
            Console.WriteLine("Please enter the owner phone number:");
            o_OwnerPhone = Console.ReadLine();
            Console.WriteLine("Please enter the owner name:");
            o_OwnerName = Console.ReadLine();
        }

        public string GetVehicleLicenseNumber()
        {
            Console.WriteLine("Please Enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public void AddVehicle()
        {
            GetOwnerDetails(out string ownerPhone, out string ownerName);
            Console.WriteLine("Please choose the vehicle type out of the following options");
            DisplayEnumOptions<VehicleBuilder.eVehicleType>();
            VehicleBuilder.eVehicleType userRequestedVehicleType = (VehicleBuilder.eVehicleType)GetEnumChoiceFromUser<VehicleBuilder.eVehicleType>();
            List<VehicleParam> parametersList = VehicleBuilder.GetParams(userRequestedVehicleType);
            Dictionary<string, VehicleParam> paramsDictionary = new Dictionary<string, VehicleParam>();
            foreach (VehicleParam param in parametersList)
            {
                Console.WriteLine("Please enter {0}", param.FriendlyName);
                if (param.Type.IsEnum)
                {
                    Console.WriteLine("Options: " + string.Join(",", Enum.GetNames(param.Type)));
                    string userInput = Console.ReadLine();
                    param.Value = Enum.Parse(param.Type, userInput);
                }
                else
                {
                    string userInput = Console.ReadLine();
                    param.Value = Convert.ChangeType(userInput, param.Type);
                }

                paramsDictionary.Add(param.Name, param);
            }

            Vehicle vehicleToAdd = VehicleBuilder.BuildVehicle(userRequestedVehicleType, paramsDictionary);
            m_Garage.AddVehicle(ownerPhone, ownerName, vehicleToAdd);
            Console.WriteLine("Vehicle was added to the garage");
        }

        public int GetEnumChoiceFromUser<T>()
        {
            int amountOfOptions = Enum.GetNames(typeof(T)).Length;
            int.TryParse(Console.ReadLine(), out int userRequestedFuelType);
            if (userRequestedFuelType < 1 || userRequestedFuelType > amountOfOptions)
            {
                throw new ValueOutOfRangeException(1, amountOfOptions, "options");
            }

            return userRequestedFuelType;
        }

        public void RefuelVehicle()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            Console.WriteLine("Please choose fuel type out of the following options");
            DisplayEnumOptions<GarageEnums.eFuelType>();
            GarageEnums.eFuelType userRequestedFuelType = (GarageEnums.eFuelType) GetEnumChoiceFromUser<GarageEnums.eFuelType>();

            Console.WriteLine("Please enter how many liters of fuel you would like to add");
            float.TryParse(Console.ReadLine(), out float litersOfFuelToAdd);

            m_Garage.RefuelVehicle(licenseNumber, userRequestedFuelType, litersOfFuelToAdd);
        }

        public void ChargeVehicle()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            Console.WriteLine("Please enter how many minutes to charge:");
            float.TryParse(Console.ReadLine(), out float minutesToCharge);
            m_Garage.ChargeVehicle(licenseNumber, minutesToCharge / 60);
        }

        private void ChangeVehicleStatus()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            Console.WriteLine("Please Enter the vehicle's new fix state out of the following options");
            DisplayEnumOptions<GarageEnums.eFixState>();
            GarageEnums.eFixState newFixState = (GarageEnums.eFixState)GetEnumChoiceFromUser<GarageEnums.eFixState>();
            m_Garage.ChangeVehicleState(licenseNumber, newFixState);
        }

        private void PumpVehicleTires()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            m_Garage.PumpVehicle(licenseNumber);
        }

        public void DisplayVehiclesLicenseNumbers()
        {
            List<GarageVehicle> garageVehiclesToDisplay = new List<GarageVehicle>();
            Console.WriteLine(@"Do you want to filter the license numbers?");
            DisplayEnumOptions<eVehicleDisplayOptions>();
            eVehicleDisplayOptions userSelection = (eVehicleDisplayOptions)GetEnumChoiceFromUser<eVehicleDisplayOptions>();
            switch(userSelection)
            {
                case eVehicleDisplayOptions.NoFilter:
                    garageVehiclesToDisplay = m_Garage.GetAllGarageVehicles();
                    break;
                case eVehicleDisplayOptions.WithFilter:
                    DisplayEnumOptions<GarageEnums.eFixState>();
                    GarageEnums.eFixState fixState = (GarageEnums.eFixState)GetEnumChoiceFromUser<GarageEnums.eFixState>();
                    garageVehiclesToDisplay = m_Garage.GetGarageVehiclesByFixState(fixState);
                    break;
            }

            PrintGarageVechilesLicenseNumbers(garageVehiclesToDisplay);
        }

        private void PrintGarageVechilesLicenseNumbers(List<GarageVehicle> i_GarageGarageVehicles)
        {
            foreach (GarageVehicle garageVehicle in i_GarageGarageVehicles)
            {
                Console.WriteLine(garageVehicle.VehicleInGarage.LicenseNumber);
            }
        }

        public void DisplayCertainVehicle()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            GarageVehicle vehicle = m_Garage.GetVehicleDetails(licenseNumber);
            Console.WriteLine(vehicle.ToString());
        }

        public void DisplayMainMenu()
        {
            while(!m_quitFlag)
            {
                Console.Clear();
                Console.WriteLine(@"Please choose an option from the menu");
                try
                {
                    DisplayEnumOptions<eMainMenuOptions>();
                    eMainMenuOptions userSelection = (eMainMenuOptions)GetEnumChoiceFromUser<eMainMenuOptions>();
                    Console.Clear();

                    switch (userSelection)
                    {
                        case eMainMenuOptions.AddVehicle:
                            AddVehicle();
                            break;
                        case eMainMenuOptions.DisplayVehiclesDetails:
                            DisplayVehiclesLicenseNumbers();
                            break;
                        case eMainMenuOptions.ChangeVehicleStatus:
                            ChangeVehicleStatus();
                            break;
                        case eMainMenuOptions.PumpVehicleTires:
                            PumpVehicleTires();
                            break;
                        case eMainMenuOptions.RefuelVehicle:
                            RefuelVehicle();
                            break;
                        case eMainMenuOptions.ChargeVehicle:
                            ChargeVehicle();
                            break;
                        case eMainMenuOptions.DisplayCertainVehicle:
                            DisplayCertainVehicle();
                            break;
                        case eMainMenuOptions.Quit:
                            m_quitFlag = true;
                            break;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Please select a valid option");
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }

                Thread.Sleep(k_SleepTime);
            }
        }
    }
}
