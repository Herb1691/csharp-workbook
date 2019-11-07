using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project4_PoCos
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class DriversLicense
    {
        private string firstName;
        private string lastName;
        private string gender;
        private string licenseNumber;

        private DriversLicense()
        {
            firstName = "Herb";
            lastName = "Wright";
            gender = "Male";
            licenseNumber = "098765432";
        }

        public string GetFullName()
        {
            return firstName + " " + lastName;
        }
    }

    class Book
    {
        public string title { get; set; }
        public string[] authors { get; set; }
        public int pages { get; set; }
        public int sku { get; set; }
        public string publisher { get; set; }
        public double price { get; set; }
    }

    class Airplane
    {
        public string manufacturer { get; set; }
        public string model { get; set; }
        public string variant { get; set; }
        public int capacity { get; set; }  // How many seats?
        public int engines { get; set; }  // How many engines?
    }

}
