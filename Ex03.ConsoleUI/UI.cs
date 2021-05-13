﻿using System;
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

        public void GetWheelInformation(out string o_Manufacturer, out int o_CurrentPsi)
        {
            Console.WriteLine("Please enter the wheel manufacturer name:");
            o_Manufacturer = Console.ReadLine();
            Console.WriteLine("Please enter the current PSI of the wheels:");
            int.TryParse(Console.ReadLine(), out o_CurrentPsi);
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

        public string GetVehicleLicenseNumber()
        {
            Console.WriteLine("Please Enter the vehicle's license number");
            string licenseNumber = Console.ReadLine();

            return licenseNumber;
        }

        public void AddVehicle()
        {
            VehicleBuilder.eVehicleType i_TypeSelected;
            string licenseNumber, modelName, wheelManufacturer,ownerPhone,ownerName;
            int engineVolume, currentPsi;
            GetGeneralVehicleDetails(
                out ownerPhone,
                out ownerName, out licenseNumber, out modelName, out wheelManufacturer, out currentPsi);
            // select type
            i_TypeSelected = VehicleBuilder.eVehicleType.FuelTruck;
            List<VehicleParam> parametersList = VehicleBuilder.GetParams(i_TypeSelected);
            Dictionary<string, VehicleParam> paramsDictionary = new Dictionary<string, VehicleParam>();
            foreach(VehicleParam param in parametersList)
            {
                Console.WriteLine("Please enter {0}", param.m_FriendlyName);
                //string userInput = Console.ReadLine();

                param.m_Value = Console.ReadLine();
                paramsDictionary.Add(param.m_Name,param);
            }

            //}
            //Vehicle vehicleToAdd = VehicleBuilder.BuildVehicle(i_TypeSelected, paramerList);
            //    licenseType,
            //    engineVolume, modelName, licenseNumber, 1, wheelManufacturer,
            //    currentPsi);
            //    m_Garage.AddVehicle(ownerPhone,ownerName, bikeToAdd);
        }

        public static void DisplayEnumOptions<T>()
        {
            foreach (string options in Enum.GetNames(typeof(T)))
            {
                Console.WriteLine("For {0} press {1:D}", options,
                    Enum.Parse(typeof(T), options));
            }
        }

        public int GetEnumChoiceFromUser<T>()
        {
            int amountOfOptions = Enum.GetNames(typeof(T)).Length;
            int.TryParse(Console.ReadLine(), out int userRequestedFuelType);
            if(userRequestedFuelType < 1 || userRequestedFuelType > amountOfOptions)
            {
                throw new ValueOutOfRangeException(1, amountOfOptions);
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

            m_Garage.RefuelVehicle(licenseNumber, userRequestedFuelType , litersOfFuelToAdd);
        }

        public void ChargeVehicle()
        {
            Console.WriteLine(@"please enter license number and minutes to charge");
            string licenseNumber = GetVehicleLicenseNumber();
            float.TryParse(Console.ReadLine(), out float minutesToCharge);
            m_Garage.ChargeVehicle(licenseNumber, minutesToCharge / 60);
        }

        private void ChangeVehicleStatus()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            Console.WriteLine("Please Enter the vehicle's new fix state out of the following options");
            DisplayEnumOptions<GarageEnums.eFixState>();
            GarageEnums.eFixState newFixState = (GarageEnums.eFixState)GetEnumChoiceFromUser<GarageEnums.eFixState>();
        }

        private void PumpVehicleTires()
        {
            string licenseNumber = GetVehicleLicenseNumber();
            m_Garage.PumpVehicle(licenseNumber);
        }

        public void DisplayVehiclesDetails()
        {
            Console.WriteLine("kelev");
        }

        public void DisplayCertainVehicle()
        {
            GarageVehicle vehicle = m_Garage.GetVehicleDetails(GetVehicleLicenseNumber());

            string vechileDetails = string.Format(
                @"License number:  {0}
Model Name: {1}

...
...
", vehicle.VehicleInGarage.LicenseNumber);
            //Owner's Name:  {2}
            //Fix state in the garage: { 3}
            //Tires model: { 4}
            //Tires Psi: { 5}
        }
        public void DisplayMainMenu()
        {
            while(!m_quitFlag)
            {
                Console.WriteLine(@"Please choose an option from the menu");
                try
                {
                    DisplayEnumOptions<eMainMenuOptions>();
                    eMainMenuOptions userSelection = (eMainMenuOptions)GetEnumChoiceFromUser<eMainMenuOptions>();
                    switch(userSelection)
                    {
                        case eMainMenuOptions.AddVehicle:
                            AddVehicle();
                            break;
                        case eMainMenuOptions.DisplayVehiclesDetails:
                            DisplayVehiclesDetails();
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
                catch(FormatException formatException)
                {
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                }

                catch(ArgumentException argumentException)
                {
                    Console.Clear();
                    Console.WriteLine("Please select a valid option");
                }
                catch(ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }
        }
    }
}
