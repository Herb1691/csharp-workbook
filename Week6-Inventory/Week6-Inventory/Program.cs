using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> rentables = new List<IRentable>();

            Boat boat1 = new Boat(5);
            Boat boat2 = new Boat(24);

            Car car1 = new Car(1);
            Car car2 = new Car(3);
            Car car3 = new Car(14);
            Car car4 = new Car(5);

            House house1 = new House(1);
            House house2 = new House(5);
            House house3 = new House(2);

            rentables.Add(boat1);
            rentables.Add(boat2);
            rentables.Add(car1);
            rentables.Add(car2);
            rentables.Add(car3);
            rentables.Add(car4);
            rentables.Add(house1);
            rentables.Add(house2);
            rentables.Add(house3);

            foreach (var rental in rentables)
            {
                rental.GetDescription();
            }

            Console.ReadLine();
        }
    }

    public interface IRentable
    {
        double rate { get; set; }
        void GetDailyRate();
        void GetDescription();
    }

    public class Boat : IRentable
    {
        public double rate { get; set; }
        public int hours { get; set; }

        public Boat (int rentHours)
        {
            this.hours = rentHours;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            rate = 29.99 * hours;
        }

        public void GetDescription()
        {
            Console.WriteLine("To rent this boat for {0} hour(s), the rate would be ${1}", hours, rate);
        }
    }

    public class Car : IRentable
    {
        public double rate { get; set; }
        public int days { get; set; }

        public Car(int rentDays)
        {
            this.days = rentDays;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            rate = 24.99 * days;
        }

        public void GetDescription()
        {
            Console.WriteLine("To rent this car for {0} day(s), the rate would be ${1}", days, rate);
        }
    }

    public class House : IRentable
    {
        public double rate { get; set; }
        public int weeks { get; set; }

        public House(int rentWeeks)
        {
            this.weeks = rentWeeks;
            GetDailyRate();
        }
        public void GetDailyRate()
        {
            rate = 289.99 * weeks;
        }

        public void GetDescription()
        {
            Console.WriteLine("To rent this house for {0} week(s), the rate would be ${1}", weeks, rate);
        }
    }
}
