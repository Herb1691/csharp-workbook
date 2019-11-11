using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            //string block1 = "XXX0XXX";
            //string block2 = "XX000XX";
            //string block3 = "X00000X";
            //string block4 = "0000000";
            
            // Board Pieces/Blocks
            string block1 = "0";
            string block2 = "000";
            string block3 = "00000";
            string block4 = "0000000";

            // Game Pegs
            Stack<string> pegA = new Stack<string>();
            Stack<string> pegB = new Stack<string>();
            Stack<string> pegC = new Stack<string>();

            pegA.Push(block4);
            pegA.Push(block3);
            pegA.Push(block2);
            pegA.Push(block1);

            string moveFrom = string.Empty;
            string moveTo = string.Empty;

            // To check to make sure player doesn't just remove from start and place back on it.
            string startingPos = "A";

            // Has the player won or are they finished?
            bool isDone = false;

            Console.WriteLine("Welcome to the game Tower of Hanoi");
            Console.WriteLine("In this game you have to move all of the blocks");
            Console.WriteLine("from Peg A and move them to another peg from");
            Console.WriteLine("highest to lowest.  Sounds easy right?");
            Console.WriteLine("However, you cannot stack larger blocks on top");
            Console.WriteLine("of smaller blocks.  You win by getting the blocks");
            Console.WriteLine("to a new peg in the Wright order.");

            while (!isDone)
            {
                bool notEmpty = false;              // Checks that user is moving from a stack that has items in it.
                bool hasWon = false;                // Victory condition
                string movingBlock = string.Empty;  // Block that is moving
                string topBlock = string.Empty;     // To confirm if stacking on the next peg is valid.
                string playAgain = "NO";            // Ask the user if they want to play again after winning.

                PrintBoard(pegA, pegB, pegC);
                //Console.ReadLine();
                //isDone = true;

                Console.WriteLine("\nChoose the Peg that you want to");
                Console.WriteLine("move the block from.");
                Console.Write("(A, B, or C): ");
                moveFrom = Console.ReadLine();

                switch (moveFrom.ToUpper())
                {
                    case "A":
                        if (pegA.Count > 0)
                        {
                            movingBlock = pegA.Pop();
                            notEmpty = true;
                        }
                        else
                            notEmpty = false;
                        break;
                    case "B":
                        if (pegB.Count > 0)
                        {
                            movingBlock = pegB.Pop();
                            notEmpty = true;
                        }
                        else
                            notEmpty = false;
                        break;
                    case "C":
                        if (pegC.Count > 0)
                        {
                            movingBlock = pegC.Pop();
                            notEmpty = true;
                        }
                        else
                            notEmpty = false;
                        break;
                    default:
                        Console.WriteLine("Please select either A B or C.");
                        notEmpty = false;
                        break;
                }

                if (notEmpty)
                {
                    Console.WriteLine("Where would you like to move the block to?");
                    Console.Write("(A, B, or C): ");
                    moveTo = Console.ReadLine();

                    switch (moveTo.ToUpper())
                    {
                        case "A":
                        case "B":
                        case "C":
                            if (moveTo != moveFrom)
                            {
                                if (moveTo.ToUpper() == "A")
                                {
                                    if (pegA.Count == 0)
                                    {
                                        pegA.Push(movingBlock);
                                    }
                                    else if (pegA.Count >= 1)
                                    {
                                        topBlock = pegA.Peek();

                                        if (movingBlock.Length < topBlock.Length)
                                        {
                                            if (pegA.Count < 3)
                                            {
                                                pegA.Push(movingBlock);
                                            }
                                            else if (pegA.Count == 3)
                                            {
                                                pegA.Push(movingBlock);
                                                hasWon = CheckForWin(pegA);

                                                if (hasWon)
                                                {
                                                    if (startingPos != moveTo.ToUpper())
                                                        startingPos = "A";
                                                    else
                                                    {
                                                        Console.WriteLine("Please try to move the block to a different peg and in the correct order!");
                                                        hasWon = false;
                                                    }
                                                }
                                            }
                                            else
                                                Console.WriteLine("Not sure how it happened, but...ERROR! Peg is full!!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Larger blocks cannot be placed on smaller blocks!");
                                            Console.WriteLine("Please try again.");
                                            if (moveFrom.ToUpper() == "A")
                                                pegA.Push(movingBlock);
                                            else if (moveFrom.ToUpper() == "B")
                                                pegB.Push(movingBlock);
                                            else
                                                pegC.Push(movingBlock);
                                        }
                                    }
                                }
                                else if (moveTo.ToUpper() == "B")
                                {
                                    if (pegB.Count == 0)
                                    {
                                        pegB.Push(movingBlock);
                                    }
                                    else if (pegB.Count >= 1)
                                    {
                                        topBlock = pegB.Peek();

                                        if (movingBlock.Length < topBlock.Length)
                                        {
                                            if (pegB.Count < 3)
                                            {
                                                pegB.Push(movingBlock);
                                            }
                                            else if (pegB.Count == 3)
                                            {
                                                pegB.Push(movingBlock);
                                                hasWon = CheckForWin(pegB);

                                                if (hasWon)
                                                {
                                                    if (startingPos != moveTo.ToUpper())
                                                        startingPos = "B";
                                                    else
                                                    {
                                                        Console.WriteLine("Please try to move the block to a different peg and in the correct order!");
                                                        hasWon = false;
                                                    }
                                                }
                                            }
                                            else
                                                Console.WriteLine("Not sure how it happened, but...ERROR! Peg is full!!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Larger blocks cannot be placed on smaller blocks!");
                                            Console.WriteLine("Please try again.");
                                            if (moveFrom.ToUpper() == "A")
                                                pegA.Push(movingBlock);
                                            else if (moveFrom.ToUpper() == "B")
                                                pegB.Push(movingBlock);
                                            else
                                                pegC.Push(movingBlock);
                                        }
                                    }
                                }
                                else if (moveTo.ToUpper() == "C")
                                {
                                    if (pegC.Count == 0)
                                    {
                                        pegC.Push(movingBlock);
                                    }
                                    else if (pegC.Count >= 1)
                                    {
                                        topBlock = pegC.Peek();

                                        if (movingBlock.Length < topBlock.Length)
                                        {
                                            if (pegC.Count < 3)
                                            {
                                                pegC.Push(movingBlock);
                                            }
                                            else if (pegC.Count == 3)
                                            {
                                                pegC.Push(movingBlock);
                                                hasWon = CheckForWin(pegC);

                                                if (hasWon)
                                                {
                                                    if (startingPos != moveTo.ToUpper())
                                                        startingPos = "C";
                                                    else
                                                    {
                                                        Console.WriteLine("Please try to move the block to a different peg and in the correct order!");
                                                        hasWon = false;
                                                    }
                                                }
                                            }
                                            else
                                                Console.WriteLine("Not sure how it happened, but...ERROR! Peg is full!!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Larger blocks cannot be placed on smaller blocks!");
                                            Console.WriteLine("Please try again.");
                                            if (moveFrom.ToUpper() == "A")
                                                pegA.Push(movingBlock);
                                            else if (moveFrom.ToUpper() == "B")
                                                pegB.Push(movingBlock);
                                            else
                                                pegC.Push(movingBlock);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (moveFrom.ToUpper() == "A")
                                    pegA.Push(movingBlock);
                                else if (moveFrom.ToUpper() == "B")
                                    pegB.Push(movingBlock);
                                else
                                    pegC.Push(movingBlock);
                            }
                            break;
                        default:
                            Console.WriteLine("Please Choose a Valid Input!");
                            break;
                    }
                }
                else
                    Console.WriteLine("Please choose a peg with blocks on it!");

                if (hasWon)
                {
                    PrintBoard(pegA, pegB, pegC);
                    Console.WriteLine("You won!  Congratulations!");
                    Console.WriteLine("Would you like to play again?");
                    Console.Write("Yes or No: ");
                    playAgain = Console.ReadLine();

                    switch(playAgain.ToUpper())
                    {
                        case "YES":
                            isDone = false;
                            break;
                        case "NO":
                            isDone = true;
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                }
            } // End Game Loop
        } // End Main
        /// <summary>
        /// Displays the current state of the gameboard to the screen.  Extra spaces are for formatting to align output cleanly.
        /// If the stack is empty, empty spaces will be placed on the appropriate rows. Otherwise the correctly formatted string
        /// will be place in the appropriate row.
        /// </summary>
        /// <param name="A">PegA Stack</param>
        /// <param name="B">PegB Stack</param>
        /// <param name="C">PegC Stack</param>
        static void PrintBoard(Stack<string> A, Stack<string> B, Stack<string> C)
        {
            // At a minimum, each row should have 23 empty spaces
            string row1 = string.Empty;
            string row2 = string.Empty;
            string row3 = string.Empty;
            string row4 = string.Empty;
            string toprow = "   |       |       |   ";
            string bottomrow1 = "=======================";
            string bottomrow2 = "   A       B       C   ";

            List<string> pegA = new List<string> { "   |   ", "   |   ", "   |   ", "   |   " };
            List<string> pegB = new List<string> { "   |   ", "   |   ", "   |   ", "   |   " };
            List<string> pegC = new List<string> { "   |   ", "   |   ", "   |   ", "   |   " };

            int countA = 4 - A.Count;
            int countB = 4 - B.Count;
            int countC = 4 - C.Count;

            if (countA < 4)
            {
                foreach (string block in A)
                {
                    if (block.Length == 1)
                    {
                        pegA[countA] = "   " + block + "   ";
                    }
                    else if (block.Length == 3)
                    {
                        pegA[countA] = "  " + block + "  ";
                    }
                    else if (block.Length == 5)
                    {
                        pegA[countA] = " " + block + " ";
                    }
                    else if (block.Length == 7)
                    {
                        pegA[countA] = block;
                    }
                    countA++;
                }
            }

            if (countB < 4)
            {
                foreach (string block in B)
                {
                    if (block.Length == 1)
                    {
                        pegB[countB] = "   " + block + "   ";
                    }
                    else if (block.Length == 3)
                    {
                        pegB[countB] = "  " + block + "  ";
                    }
                    else if (block.Length == 5)
                    {
                        pegB[countB] = " " + block + " ";
                    }
                    else if (block.Length == 7)
                    {
                        pegB[countB] = block;
                    }
                    countB++;
                }
            }

            if (countC < 4)
            {
                foreach (string block in C)
                {
                    if (block.Length == 1)
                    {
                        pegC[countC] = "   " + block + "   ";
                    }
                    else if (block.Length == 3)
                    {
                        pegC[countC] = "  " + block + "  ";
                    }
                    else if (block.Length == 5)
                    {
                        pegC[countC] = " " + block + " ";
                    }
                    else if (block.Length == 7)
                    {
                        pegC[countC] = block;
                    }
                    countC++;
                }
            }

            Console.WriteLine(toprow);
            Console.WriteLine(pegA[0] + " " + pegB[0] + " " + pegC[0]);
            Console.WriteLine(pegA[1] + " " + pegB[1] + " " + pegC[1]);
            Console.WriteLine(pegA[2] + " " + pegB[2] + " " + pegC[2]);
            Console.WriteLine(pegA[3] + " " + pegB[3] + " " + pegC[3]);
            Console.WriteLine(bottomrow1);
            Console.WriteLine(bottomrow2);
        }// End of PrintBoard

        static bool CheckForWin(Stack<string> peg)
        {
            bool winner = false;
            int total = 0;

            foreach (string piece in peg)
            {
                if (piece.Length > total)
                {
                    total = piece.Length;
                    winner = true;
                }
                else
                    winner = false;
            }

            return winner;
        }
    }
}
