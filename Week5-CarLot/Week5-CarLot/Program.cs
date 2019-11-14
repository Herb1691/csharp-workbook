using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_CarLot
{
    class Program
    {
        static void Main(string[] args)
        {
            // List of Vehicles for the first lot
            List<Vehicle> vehicles1 = new List<Vehicle>();

            // Instantiating vehicles for the first lot
            Car veh1 = new Car("Dodge", "Neon", "1234FT", 4999.99, "Sedan", 4);
            Car veh2 = new Car("Dodge", "Stratus", "1234GT", 7999.99, "Sedan", 2);
            Car veh3 = new Car("Dodge", "Challenger", "1234HT", 10999.99, "Coup", 2);

            Truck veh4 = new Truck("Dodge", "Ram", "1234IT", 12999.99, "Large");

            // Adding instantiated vehicles to the vehicle list
            vehicles1.Add(veh1);
            vehicles1.Add(veh2);
            vehicles1.Add(veh3);
            vehicles1.Add(veh4);

            // Instantiating vehicles for the second lot
            Car veh5 = new Car("Ford", "Escort", "5678FT", 3999.99, "Sedan", 4);

            Truck veh6 = new Truck("Ford", "F-150", "5678GT", 9999.99, "Small");
            Truck veh7 = new Truck("Ford", "F-250", "5678HT", 13999.99, "Medium");
            Truck veh8 = new Truck("Ford", "F-350", "5678IT", 20999.99, "Large");

            // Instantiating the first lot and using the overloaded constructor to set the name and vehicle list.
            CarLot lot1 = new CarLot("Herb Dodge", vehicles1);

            // Instianting the second lot and using the overloaded constructor to set the name.
            CarLot lot2 = new CarLot("Herb Ford");

            // Adding the second set of instantiated vehicles to the second lot using its AddVehicle method.
            lot2.AddVehicle(veh5);
            lot2.AddVehicle(veh6);
            lot2.AddVehicle(veh7);
            lot2.AddVehicle(veh8);

            // Printing the description of each vehicle in the two lots.
            lot1.PrintInventory();
            Console.WriteLine();
            lot2.PrintInventory();
            Console.ReadLine();
        }
    }

    class CarLot
    {
        public string lotName { get; private set; }
        public List<Vehicle> vehicles;

        /// <summary>
        /// Constructor that takes no input and sets defaults to the lotName and vehicle list.
        /// </summary>
        public CarLot()
        {
            lotName = "unknown";
            this.vehicles = new List<Vehicle>();
        }
        /// <summary>
        /// Overloaded constructor that accepts the lot name and initializes the vehicle list to be filled later. 
        /// </summary>
        /// <param name="lName"></param>
        public CarLot(string lName)
        {
            lotName = lName;
            this.vehicles = new List<Vehicle>();
        }
        /// <summary>
        /// Overloaded Constructor that accepts and assigns the lot name as well as populating the vehicle list.
        /// </summary>
        /// <param name="lName"></param>
        /// <param name="vehicleList"></param>
        public CarLot(string lName, List<Vehicle> vehicleList)
        {
            lotName = lName;
            this.vehicles = vehicleList;
        }

        /// <summary>
        /// Function to allow the user to add a vehicle to the list after the class has been instantiated.
        /// </summary>
        /// <param name="veh"></param>
        public void AddVehicle(Vehicle veh)
        {
            // Adds input value to the vehicle list
            this.vehicles.Add(veh);
        }

        /// <summary>
        /// Function that prints to the console window the name of the lot as well as its list of vehicles.
        /// </summary>
        public void PrintInventory()
        {
            Console.WriteLine("{0}: \n", lotName);
            foreach (Vehicle car in this.vehicles)
            {
                Console.WriteLine(car.Description());
            }
        }
    }

    public abstract class Vehicle
    {
        public string license;
        public string make;
        public string model;
        public double price;

        public virtual string Description()
        {
            return "Your vehicle is a " + make + " " + model + ", license plate #" + license + ". Its listed value is at $" + price + ".";
        }
    }

    class Truck : Vehicle
    {
        // Size of truck bed. Large, Medium, or Small
        public string bedSize { get; set; }

        /// <summary>
        /// Function that returns a string with the description of the instantiated truck object.
        /// </summary>
        /// <returns></returns>
        public override string Description()
        {
            return "Your Truck is a " + make + " " + model + ", license plate #" + license + ". With a " + bedSize + " bed. Its listed value is at $" + price + ".";
        }

        /// <summary>
        /// Constructor.  Must receive the make, model, license, price, and bed size of the truck.
        /// </summary>
        /// <param name="trMake"></param>
        /// <param name="trModel"></param>
        /// <param name="trLicense"></param>
        /// <param name="trPrice"></param>
        /// <param name="trBedSize"></param>
        public Truck(string trMake, string trModel, string trLicense, double trPrice, string trBedSize)
        {
            make = trMake;
            model = trModel;
            license = trLicense;
            price = trPrice;
            bedSize = trBedSize;
        }
    }

    class Car : Vehicle
    {
        // Can be Coupe, Hatchback, or Sedan
        public string type { get; set; }
        // How many doors?
        public int doors { get; set; }

        /// <summary>
        /// Function that returns a string with the description of the instantiated car object.
        /// </summary>
        /// <returns></returns>
        public override string Description()
        {
            return "Your Car is a " + make + " " + model + ", license plate #" + license + ". It's a " + type + " with " + doors + " doors. Its listed value is at $" + price + ".";
        }

        /// <summary>
        /// Constructor.  Must receive the make, model, license, price, car type, and number of doors of the car.
        /// </summary>
        /// <param name="carMake"></param>
        /// <param name="carModel"></param>
        /// <param name="carLicense"></param>
        /// <param name="carPrice"></param>
        /// <param name="carType"></param>
        /// <param name="carDoors"></param>
        public Car(string carMake, string carModel, string carLicense, double carPrice, string carType, int carDoors)
        {
            make = carMake;
            model = carModel;
            license = carLicense;
            price = carPrice;
            type = carType;
            doors = carDoors;
        }
    }
}
