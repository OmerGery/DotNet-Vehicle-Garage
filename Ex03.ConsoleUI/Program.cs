using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{

    public abstract class Animal
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    public class Dog : Animal
    {
        public string DogType { get; set; }
    }

    public class Cat : Animal
    {
        public double MustacheLength { get; set; }

        public Cat(double mustacheLength, int age, string name)
        {

        }
    }

    class Program
    {
        public static void Main()
        {

           // var animalTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsSubclassOf(typeof(Animal)));
            //foreach (Type animal in animalTypes)
            //{
            //    Console.WriteLine(animal.Name);
            //}

            //Console.WriteLine();
            //string userInput = "Cat";
            //Type t = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == userInput);
            //var ctor = t.GetConstructors().First();
            //List<object> o = new List<object>();
            //foreach (var param in ctor.GetParameters())
            //{

            //    Console.WriteLine("enter " + param.Name);
            //    var ctorParam = Convert.ChangeType(Console.ReadLine(), param.ParameterType);
            //    o.Add(ctorParam);
            //}

            //Animal a = (Animal)(ctor.Invoke(o.ToArray()));
            //var gggg = 5;


            //  GarageLogic.Garage garage = new Garage();
            //  UI.DisplayMenu();
            //   Console.WriteLine("You are adding e-bike , Please enter details for electric bike");
            //  UI.AddElectricBike(garage);
            //   List<Vehicle> a = garage.GetAllGarageVehicles();
            //try
            //{
            //    if(kelet not between 2 and 67
            //    throw new ValueOutOfRangeException(2, 67);
            //}
            //catch(ValueOutOfRangeException e)
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine("Pleaseeeeeeee enter value between "+  e.MinValue+" and " + e.MaxValue );
            //}f

            try
            {
                //get kelet from user
                //apply logic
                var kelet = Console.Read();
                throw new ValueOutOfRangeException(65, 23);
            }
            catch (FormatException f)
            {
                
            }
            catch (ArgumentException)
            { }
            catch { }

        }
    }
}
