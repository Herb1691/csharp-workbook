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
            List<Vehicle> vehicles1 = new List<Vehicle>();
            List<Vehicle> vehicles2 = new List<Vehicle>();

            Car veh1 = new Car("Dodge", "Neon", "1234FT", 4999.99, "Sedan", 4);
            Car veh2 = new Car("Dodge", "Stratus", "1234GT", 7999.99, "Sedan", 2);
            Car veh3 = new Car("Dodge", "Challenger", "1234HT", 10999.99, "Coup", 2);

            Truck veh4 = new Truck("Dodge", "Ram", "1234IT", 12999.99, "Large");

            vehicles1.Add(veh1);
            vehicles1.Add(veh2);
            vehicles1.Add(veh3);
            vehicles1.Add(veh4);

            Car veh5 = new Car("Ford", "Escort", "5678FT", 3999.99, "Sedan", 4);

            Truck veh6 = new Truck("Ford", "F-150", "5678GT", 9999.99, "Small");
            Truck veh7 = new Truck("Ford", "F-250", "5678HT", 13999.99, "Medium");
            Truck veh8 = new Truck("Ford", "F-350", "5678IT", 20999.99, "Large");

            CarLot lot1 = new CarLot("Herb Dodge", vehicles1);
            CarLot lot2 = new CarLot("Herb Ford");

            lot2.AddVehicle(veh5);
            lot2.AddVehicle(veh6);
            lot2.AddVehicle(veh7);
            lot2.AddVehicle(veh8);

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

        public CarLot()
        {
            lotName = "unknown";
            this.vehicles = new List<Vehicle>();
        }

        public CarLot(string lName)
        {
            lotName = lName;
            this.vehicles = new List<Vehicle>();
        }

        public CarLot(string lName, List<Vehicle> vehicleList)
        {
            lotName = lName;
            this.vehicles = vehicleList;
        }


        public void AddVehicle(Vehicle veh)
        {
            this.vehicles.Add(veh);
        }

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

        public override string Description()
        {
            return "Your Truck is a " + make + " " + model + ", license plate #" + license + ". With a " + bedSize + " bed. Its listed value is at $" + price + ".";
        }

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

        public override string Description()
        {
            return "Your Car is a " + make + " " + model + ", license plate #" + license + ". It's a " + type + " with " + doors + " doors. Its listed value is at $" + price + ".";
        }

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
