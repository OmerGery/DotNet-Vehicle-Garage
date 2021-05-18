using System;
using System.Collections.Generic;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private const int k_SleepTime = 3000;
        private bool m_QuitFlag;
        private Garage m_Garage;

        private enum eMainMenuOptions
        {
            AddVehicle = 1,
            DisplayVehiclesLicenseNumbers,
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

        private static void displayEnumOptions<T>()
        {
            foreach (string options in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("For {0} press {1:D}", options, Enum.Parse(typeof(T), options));
            }
        }

        private void getOwnerDetails(out string o_OwnerPhone, out string o_OwnerName)
        {
            Console.WriteLine("Please enter the owner phone number:");
            o_OwnerPhone = Console.ReadLine();
            Console.WriteLine("Please enter the owner name:");
            o_OwnerName = Console.ReadLine();
        }

        private string getVehicleLicenseNumber()
        {
            Console.WriteLine("Please Enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        private void addVehicle()
        {
            getOwnerDetails(out string ownerPhone, out string ownerName);
            Console.WriteLine("Please choose the vehicle type out of the following options");
            displayEnumOptions<VehicleBuilder.eVehicleType>();
            VehicleBuilder.eVehicleType userRequestedVehicleType =
                (VehicleBuilder.eVehicleType)getEnumChoiceFromUser<VehicleBuilder.eVehicleType>();
            Dictionary<string, VehicleParam> paramsDictionary = new Dictionary<string, VehicleParam>();
            Vehicle vehicleToAdd = VehicleBuilder.BuildVehicle(userRequestedVehicleType);
            List<VehicleParam> parametersList = vehicleToAdd.GetNewVehicleParams();
            foreach(VehicleParam param in parametersList)
            {
                Console.WriteLine("Please enter {0}", param.FriendlyName);
                if(param.Type.IsEnum)
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

            vehicleToAdd.InitNewVehicle(paramsDictionary);
            m_Garage.AddVehicle(ownerPhone, ownerName, vehicleToAdd);
            Console.WriteLine("Vehicle was added to the garage");
        }

        private int getEnumChoiceFromUser<T>()
        {
            int amountOfOptions = Enum.GetNames(typeof(T)).Length;
            if(!int.TryParse(Console.ReadLine(), out int userRequestedFuelType))
            {
                throw new FormatException("You must enter a number for the selection of the requested option.");
            }

            if (userRequestedFuelType < 1 || userRequestedFuelType > amountOfOptions)
            {
                throw new ValueOutOfRangeException(1, amountOfOptions, "options");
            }

            return userRequestedFuelType;
        }

        private void refuelVehicle()
        {
            string licenseNumber = getVehicleLicenseNumber();
            Console.WriteLine("Please choose fuel type out of the following options");
            displayEnumOptions<GarageEnums.eFuelType>();
            GarageEnums.eFuelType userRequestedFuelType = (GarageEnums.eFuelType) getEnumChoiceFromUser<GarageEnums.eFuelType>();
            Console.WriteLine("Please enter how many liters of fuel you would like to add");
            if (!float.TryParse(Console.ReadLine(), out float litersOfFuelToAdd))
            {
                throw new FormatException("You must enter a number for the liters amount.");
            }

            m_Garage.RefuelVehicle(licenseNumber, userRequestedFuelType, litersOfFuelToAdd);
            Console.WriteLine("Vehicle has been refueled");
        }

        private void chargeVehicle()
        {
            string licenseNumber = getVehicleLicenseNumber();
            Console.WriteLine("Please enter how many minutes to charge:");
            if(!float.TryParse(Console.ReadLine(), out float minutesToCharge))
            {
                throw new FormatException("You must enter a number for the minutes amount.");
            }

            m_Garage.ChargeVehicle(licenseNumber, minutesToCharge / 60);
            Console.WriteLine("Vehicle has been recharged");
        }

        private void changeVehicleStatus()
        {
            string licenseNumber = getVehicleLicenseNumber();
            Console.WriteLine("Please Enter the vehicle's new fix state out of the following options");
            displayEnumOptions<GarageEnums.eFixState>();
            GarageEnums.eFixState newFixState = (GarageEnums.eFixState)getEnumChoiceFromUser<GarageEnums.eFixState>();
            m_Garage.ChangeVehicleState(licenseNumber, newFixState);
            Console.WriteLine("Vehicle status was changed");
        }

        private void pumpVehicleTires()
        {
            string licenseNumber = getVehicleLicenseNumber();
            m_Garage.PumpVehicle(licenseNumber);
            Console.WriteLine("All vehicle tires were inflated");
        }

        private void displayVehiclesLicenseNumbers()
        {
            List<GarageVehicle> garageVehiclesToDisplay = new List<GarageVehicle>();
            Console.WriteLine(@"Do you want to filter the license numbers by fix state?");
            displayEnumOptions<eVehicleDisplayOptions>();
            eVehicleDisplayOptions userSelection = (eVehicleDisplayOptions)getEnumChoiceFromUser<eVehicleDisplayOptions>();
            switch(userSelection)
            {
                case eVehicleDisplayOptions.NoFilter:
                    garageVehiclesToDisplay = m_Garage.GetAllGarageVehicles();
                    break;
                case eVehicleDisplayOptions.WithFilter:
                    displayEnumOptions<GarageEnums.eFixState>();
                    GarageEnums.eFixState fixState = (GarageEnums.eFixState)getEnumChoiceFromUser<GarageEnums.eFixState>();
                    garageVehiclesToDisplay = m_Garage.GetGarageVehiclesByFixState(fixState);
                    break;
            }

            printGarageVechilesLicenseNumbers(garageVehiclesToDisplay);
        }

        private void printGarageVechilesLicenseNumbers(List<GarageVehicle> i_GarageGarageVehicles)
        {
            foreach (GarageVehicle garageVehicle in i_GarageGarageVehicles)
            {
                Console.WriteLine(garageVehicle.VehicleInGarage.LicenseNumber);
            }
        }

        private void displayCertainVehicle()
        {
            string licenseNumber = getVehicleLicenseNumber();
            GarageVehicle vehicle = m_Garage.GetVehicleDetails(licenseNumber);
            Console.WriteLine(vehicle.ToString());
        }

        public void DisplayMainMenu()
        {
            while (!m_QuitFlag)
            {
                Console.Clear();
                Console.WriteLine(@"Please choose an option from the menu");
                try
                {
                    displayEnumOptions<eMainMenuOptions>();
                    eMainMenuOptions userSelection = (eMainMenuOptions)getEnumChoiceFromUser<eMainMenuOptions>();
                    Console.Clear();

                    switch (userSelection)
                    {
                        case eMainMenuOptions.AddVehicle:
                            addVehicle();
                            break;
                        case eMainMenuOptions.DisplayVehiclesLicenseNumbers:
                            displayVehiclesLicenseNumbers();
                            break;
                        case eMainMenuOptions.ChangeVehicleStatus:
                            changeVehicleStatus();
                            break;
                        case eMainMenuOptions.PumpVehicleTires:
                            pumpVehicleTires();
                            break;
                        case eMainMenuOptions.RefuelVehicle:
                            refuelVehicle();
                            break;
                        case eMainMenuOptions.ChargeVehicle:
                            chargeVehicle();
                            break;
                        case eMainMenuOptions.DisplayCertainVehicle:
                            displayCertainVehicle();
                            Thread.Sleep(k_SleepTime);
                            break;
                        case eMainMenuOptions.Quit:
                            Console.WriteLine("Bye Bye :-)");
                            m_QuitFlag = true;
                            break;
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("There was an error with the input format.{0}{1}", Environment.NewLine, formatException.Message);
                }
                catch (ArgumentException argumentExceptionException)
                {
                    Console.WriteLine("There was a logic error with the selected input.{0}{1}", Environment.NewLine, argumentExceptionException.Message);
                }
                catch (ValueOutOfRangeException outOfRangeException)
                {
                    Console.WriteLine("There selected input was out of range.{0}{1}", Environment.NewLine, outOfRangeException.Message);
                }

                Thread.Sleep(k_SleepTime);
            }
        }
    }
}
