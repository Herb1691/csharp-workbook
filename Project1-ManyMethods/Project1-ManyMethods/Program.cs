using System;

namespace Project1_ManyMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuItem;
            Console.WriteLine("What would you like to do?");
            // Display Menu
            Console.WriteLine(
                "1)  Greetings\n" +
                "2)  Math\n" +
                "3)  Cat Or Dog\n" +
                "4)  Odd or Even\n" +
                "5)  Inches\n" +
                "6)  Echo\n" +
                "7)  Kilograms\n" +
                "8)  Date and Time\n" +
                "9)  What's your Age\n" +
                "10) Scrambler\n" +
                "11) Exit\n");

            // Stores Users choice as a string
            menuItem = Console.ReadLine();

            // Based on user input decides what to do next
            switch (menuItem)
            {
                case "1":
                    Hello();
                    break;
                case "2":
                    Addition();
                    break;
                case "3":
                    CatDog();
                    break;
                case "4":
                    OddEven();
                    break;
                case "5":
                    Inches();
                    break;
                case "6":
                    Echo();
                    break;
                case "7":
                    KillGrams();
                    break;
                case "8":
                    Date();
                    break;
                case "9":
                    Age();
                    break;
                case "10":
                    Guess();
                    break;
                case "11":
                    break;
                default:
                    Console.WriteLine("Error!  Number Invalid!");
                    break;
            }
        }

        static void Hello()
        {
            Console.WriteLine("Hello!  What is your name?");
            // Stores user input as a string
            string name = Console.ReadLine();
            // Displays user input within a message.
            Console.WriteLine("Bye " + name + "!");
        }

        static void Addition()
        {
            bool goodValue;
            int num1, num2;

            Console.WriteLine("Please Enter two numbers and we will give you their sum.");

            do
            {
                // Using Write allows user input to happen on the same line as the following message
                Console.Write("Number 1: ");
                string tempNum1 = Console.ReadLine();

                goodValue = int.TryParse(tempNum1, out num1);

                if (goodValue)
                {
                    do
                    {
                        Console.Write("Number 2: ");
                        string tempNum2 = Console.ReadLine();

                        goodValue = int.TryParse(tempNum2, out num2);

                        if (goodValue)
                        {
                            // int.Parse converts num1 and num2 string variables into an int so that mathmatical operation can be performed on them.
                            // Need to use an error handler in case a string or char input is entered that cannot be converted to an int.
                            int total = num1 + num2;

                            Console.WriteLine("\n\nThe sum of " + num1 + " and " + num2 + " is " + total);
                        }
                        else
                            Console.WriteLine("{0} is not a valid number.  Please try again!", tempNum2);
                    } while (goodValue == false);
                }
                else
                    Console.WriteLine("{0} is not a valid number.  Please try again!", tempNum1);
            } while (goodValue == false);
        }

        static void CatDog()
        {
            Console.WriteLine("Hello! Do you prefer a cat or dog?");
            string pet = Console.ReadLine();

            // Used ToLower() to ensure that the case of the input matches what I'm comparing it to.
            if (pet.ToLower() == "cat")
                Console.WriteLine("Meow...");
            else if (pet.ToLower() == "dog")
                Console.WriteLine("Ruff Ruff!");
            else
            {
                Console.WriteLine("Not a valid Pet Option!");
                return;
            }
        }

        static void OddEven()
        {
            int oddOrEven;
            bool goodValue;

            Console.WriteLine("Enter a number and we'll tell you if it's Odd or Even.");
            // do..while because I want to enter a conditional loop regardless of what the condition is
            // set to initially.
            do
            {
                Console.Write("What's your number: ");
                // Is the value a good number?
                goodValue = int.TryParse(Console.ReadLine(), out oddOrEven);
                if (goodValue) // If yes or true
                {
                    // If the modulus of the number divided by 2 is zero then it's even
                    if (oddOrEven % 2 == 0)
                    {
                        Console.Write("Your number is Even.");
                        Console.Read();
                    }
                    else  // Otherwise it's odd
                    {
                        Console.Write("Your number is Odd.");
                        Console.Read();
                    }
                }
                else // Bad value or false
                    Console.WriteLine("Incorrect Value Entered!");
            } while (goodValue == false); // Repeat Input if value was not a valid number.
        }

        static void Inches()
        {
            string userInput;
            double feet, inches;
            bool goodValue = true;

            Console.WriteLine("Gives us a length in feet and we'll convert it to inches.");
            do
            {
                Console.Write("Feet: ");
                userInput = Console.ReadLine();
                // Parsed the string value into a real number.  Need to add code to ensure user input is a valid number.
                goodValue = Double.TryParse(userInput, out feet);
                if (goodValue)
                {
                    inches = feet * 12;
                    Console.WriteLine("There are " + inches + " inches in " + feet + " feet");
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("{0} is not a valid number.  Please try again.", userInput);
                }
            } while (goodValue == false);
        }

        static void Echo()
        {
            string myWord;
            Console.WriteLine("Please type in a word.");
            myWord = Console.ReadLine();

            Console.WriteLine(myWord.ToUpper() + "\n" + myWord.ToLower() + "\n" + myWord.ToLower());
        }

        static void KillGrams()
        {
            double lbs, kgs;
            bool goodValue;

            Console.WriteLine("Please give me a weight in pounds and I will convert it to kilograms.");
            do
            {
                Console.Write("Enter your pounds: ");
                // Checks if user input is a valid number. If so, assigns True to goodValue
                goodValue = double.TryParse(Console.ReadLine(), out lbs);

                if (goodValue)
                {
                    kgs = lbs / 2.2046;

                    Console.WriteLine(lbs + " lbs is equal to " + kgs + " kg");
                }
                else
                    Console.WriteLine("Please enter a number.");
            } while (!goodValue);
        }

        static void Date()
        {
            // Prints the current date and time to the console window.
            Console.WriteLine(DateTime.Now);
        }

        static void Age()
        {
            DateTime dob, now;
            Console.WriteLine("Enter your date of birth and I will tell you your age.");
            Console.Write("Enter DoB in this format yyyy/mm/dd: ");
            // Takes the string text entered by the user and converts it to a valid date variable.
            dob = Convert.ToDateTime(Console.ReadLine());

            // Stores current date time into the now variable.
            now = DateTime.Now;

            int Years = new DateTime(DateTime.Now.Subtract(dob).Ticks).Year - 1;
            DateTime PastYearDate = dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= now)
                {
                    Months = i - 1;
                    break;
                }
            }

            int Days = now.Subtract(PastYearDate.AddMonths(Months)).Days;

            Console.WriteLine("Age: {0} Year(s), {1} Month(s), and {2} Day(s) old!",
                Years, Months, Days);
        }

        static void Guess()
        {
            bool guess = false;
            Console.WriteLine("Please descramble this word!");

            while (guess != true)
            {
                Console.WriteLine("The word is chsarp");
                string userGuess = Console.ReadLine();

                if (userGuess == "csharp")
                {
                    Console.WriteLine("CORRECT!!");
                    guess = true;
                }
                else
                {
                    Console.WriteLine("WRONG!!");
                }
            }
        }
    }
}
