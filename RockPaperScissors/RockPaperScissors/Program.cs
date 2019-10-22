using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            int userHand, compHand;
            int compScore = 0;
            int userScore = 0;

            while(!done)
            {
                int userWon = 0;

                Console.WriteLine("     User Score: {0}       Computer Score: {1}\n\n\n", userScore, compScore);
                Console.WriteLine("Please choose between Rock, Paper, or Scissors");
                Console.WriteLine("1. Rock\n" +
                    "2. Paper\n" +
                    "3. Scissors\n" +
                    "4. Quit\n\n");

                Console.Write("Choice: ");
                userHand = int.Parse(Console.ReadLine());

                Random compTurn = new Random();
                compHand = compTurn.Next(1, 4);

                switch(userHand)
                {
                    case 1:
                    case 2:
                    case 3:
                        userWon = findWinner(userHand, compHand);
                        break;
                    case 4:
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Not a Valid Input!");
                        break;
                }

                if (userWon != 0)
                {
                    if (userWon == 1)
                    {
                        Console.WriteLine("You Win!");
                        userScore++;
                    }
                    else if (userWon == 2)
                    {
                        Console.WriteLine("Uh Oh! Computer Won!");
                        compScore++;
                    }
                    else
                        Console.WriteLine("It's a tie!");
                }
            }
        }

        public static int findWinner(int user, int comp)
        {
            // 1 = User Won
            // 2 = Computer Won
            // 3 = Tie
            int won = 0;

            // 1 = Paper
            // 2 = Rock
            // 3 = Scissors

            if (user == 1)
            {
                if (comp == 1)
                    won = 3; // Tie
                else if (comp == 2)
                    won = 2; // Computer won
                else if (comp == 3)
                    won = 1; // User won
                else
                    Console.WriteLine("Computers Choice Out of Bounds! {0}", comp);
            }
            else if (user == 2)
            {
                if (comp == 1)
                    won = 2; // Computer won
                else if (comp == 2)
                    won = 3; // Tie
                else if (comp == 3)
                    won = 1; // User won
                else
                    Console.WriteLine("Computers Choice Out of Bounds! {0}", comp);
            }
            else if (user == 3)
            {
                if (comp == 1)
                    won = 1; // User won
                else if (comp == 2)
                    won = 2; // Computer won
                else if (comp == 3)
                    won = 3; // Tie
                else
                    Console.WriteLine("Computers Choice Out of Bounds! {0}", comp);
            }
            return won;
        }
    }
}
