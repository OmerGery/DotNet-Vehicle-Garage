using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            GarageLogic.Garage garage = new Garage();
          //  UI.DisplayMenu();
            Console.WriteLine("You are adding e-bike , Please enter details for electric bike");
            UI.AddElectricBike(garage);
           List<Vehicle> a = garage.GetAllGarageVehicles();

            
        }
    }
}
