using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            bool userWon = false;
            string userGuess = "";

            // Create a dictionary of the colors Red, Yellow, and Blue
            // Using the keys 1, 2, and 3 to represent them respectively.
            Dictionary<int, string> colors = new Dictionary<int, string>();

            colors.Add(1, "RED");
            colors.Add(2, "YELLOW");
            colors.Add(3, "BLUE");

            //Console.WriteLine(colors[1]);
            //Console.ReadLine();

            // Randomly get a number between 1 and 3, this will be the computer's
            // first guess, then match that key to the dictionary and place
            // its' value onto the compStack.
            Stack compStack = new Stack();
            Stack userStack = new Stack();

            int compPick = 0;
            Random comp = new Random();
            compPick = comp.Next(1, 4);

            compStack.Push(colors[compPick]);
            // Repeat a second time and place that on the compStack as the
            // computer's second guess.
            compPick = comp.Next(1, 4);

            compStack.Push(colors[compPick]);

            Console.WriteLine("Hello!  Welcome to MasterMind!\n");
            Console.WriteLine("In this game, the computer chooses two of three colors,");
            Console.WriteLine("Red, Yellow, or Blue, and you, the player, have to guess");
            Console.WriteLine("which two colors it chose and in what order they chose them!\n");
            Console.WriteLine("But fret not! Will provide you with hints. Codes that will");
            Console.WriteLine("tell you if your guess was good and, if not, how far off you were!\n");
            Console.WriteLine("Here is the key! Remember it well...\n");
            Console.WriteLine("\"0 - 0\" - if you did not guess the correct colors at all");
            Console.WriteLine("\"1 - 0\" - if they guessed one of the colors correctly but not at the correct position");
            Console.WriteLine("\"0 - 1\" - if they guessed one of the colors correctly at the correct position");
            Console.WriteLine("\"2 - 0\" - if they guessed both colors correctly but at the wrong positions\n");

            Console.WriteLine("Okay! Let's start!");

            // Enter Game Loop
            while (!userWon)
            {
                // Accept user input one at a time and place each in the userStack
                // Use a switch..case statement, with ToUpper, to validate user input.
                bool firstGoodGuess = false;    // Was users first input valid?
                bool secondGoodGuess = false;   // Was users second input valid?
                bool firstColorMatch = false;   // Did users first guess match with one of the computers colors?
                bool secondColorMatch = false;  // Did users second guess match with one of the computers colors?
                bool firstPosition = false;     // Did users first choice also match the computers first choice?
                bool secondPosition = false;    // Did users second choice also match the computers second choice?

                if (userWon != true)
                {
                    while (!firstGoodGuess)
                    {
                        Console.WriteLine("What do you think the first color is? (Red, Yellow, or Blue)");
                        Console.WriteLine("Type Exit to quit or");
                        Console.Write("'R' To Repeat hint codes. Guess: ");
                        userGuess = Console.ReadLine();
                        userGuess = userGuess.ToUpper();

                        switch (userGuess)
                        {
                            case "RED":
                            case "YELLOW":
                            case "BLUE":
                                userStack.Push(userGuess);
                                firstGoodGuess = true;
                                break;
                            case "R":
                                PrintHintCodes();
                                break;
                            case "EXIT":
                                userWon = true;
                                firstGoodGuess = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid input!");
                                break;
                        }
                    }
                }

                if (userWon != true)
                {
                    while (!secondGoodGuess)
                    {
                        Console.WriteLine("What do you think the second color is? (Red, Yellow, or Blue)");
                        Console.Write("'R' To Repeat hint codes. Guess: ");
                        userGuess = Console.ReadLine();
                        userGuess = userGuess.ToUpper();

                        switch (userGuess)
                        {
                            case "RED":
                            case "YELLOW":
                            case "BLUE":
                                userStack.Push(userGuess);
                                secondGoodGuess = true;
                                break;
                            case "R":
                                PrintHintCodes();
                                break;
                            case "EXIT":
                                userWon = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid input!");
                                break;
                        }
                    }
                }

                // Use a nested foreach loop to compare both user inputs (inner loop) with
                // computer guesses (outer loop). Create compWord counter and userWord counter
                // to identify which words we're comparing and initialize it to 2.
                // Outer loop will set userWord counter to 2.
                // After comparing the first word in inner loop (which will be the second word
                // since we are using a stack) if both words are a match and if userWord counter
                // is equal to 2 then set secondGuess equal to true and if compWord counter is 
                // equal to 2 then set secondPosition equal to true else if compWord counter is
                // equal to 1 then set secondPosition equal to false and else if userWord counter
                // is equal to 1 then set firstGuess equal to true and if compWord counter is
                // equal to 1 then set firstPosition equal to true else if compWord counter is
                // equal to 2 then set firstPosition equal to false.

                int compWord = 2;
                int userWord = 2;

                foreach (string userColor in userStack)
                {
                    compWord = 2;
                    foreach (string compColor in compStack)
                    {
                        if (userColor == compColor)
                        {
                            if (userWord == 2)
                            {
                                secondColorMatch = true;
                                if (compWord == 2)
                                {
                                    secondPosition = true;
                                    break;
                                }
                                else
                                {
                                    secondPosition = false;
                                }

                            }
                            else
                            {
                                firstColorMatch = true;
                                if (compWord == 1)
                                {
                                    firstPosition = true;
                                }
                                else
                                {
                                    firstPosition = false;
                                }
                            }
                            compWord--;
                        }
                        else
                        {
                            if (userWord == 2)
                            {
                                secondColorMatch = false;
                                secondPosition = false;
                            }
                            else
                            {
                                firstColorMatch = false;
                                firstPosition = false;
                            }
                            compWord--;
                        }
                    }
                    userWord--;
                }

                if (firstColorMatch == true)
                {
                    if (secondColorMatch == true)
                    {
                        if (firstPosition == true)
                        {
                            if (secondPosition == true)
                            {
                                Console.WriteLine("Congratulations! You guessed correctly!");
                                Console.ReadLine();
                                userWon = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("2 - 0");
                        }
                    }
                    else
                    {
                        if (firstPosition == true)
                        {
                            Console.WriteLine("0 - 1");
                        }
                        else
                        {
                            Console.WriteLine("1 - 0");
                        }
                    }
                }
                else
                {
                    if (secondColorMatch == true)
                    {
                        if (secondPosition == true)
                        {
                            Console.WriteLine("0 - 1");
                        }
                        else
                        {
                            Console.WriteLine("1 - 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("0 - 0");
                    }
                }

                // If the stack isn't empty already
                if (userStack.Count != 0)
                {
                    int count = userStack.Count;    // Set count equal to the total number of values in the stack.
                    for (int i = 0; i < count; i++)
                    {
                        userStack.Pop();    // Remove the top value from the stack until the stack is empty again.
                    }
                }
            }
        }

        static void PrintHintCodes()
        {
            Console.WriteLine("\"0 - 0\" - if you did not guess the correct colors at all");
            Console.WriteLine("\"1 - 0\" - if they guessed one of the colors correctly but not at the correct position");
            Console.WriteLine("\"0 - 1\" - if they guessed one of the colors correctly at the correct position");
            Console.WriteLine("\"2 - 0\" - if they guessed both colors correctly but at the wrong positions\n");
        }
    }
}
