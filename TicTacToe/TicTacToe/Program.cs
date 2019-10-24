using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Game Board
            char[,] board = InitializeBoard();
            // Enter Game Loop
            Game(board);
        }

        static char[,] InitializeBoard()
        {
            char[,] tttBoard = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
            return tttBoard;
        }

        static void Game(char[,] gameBoard)
        {
            bool done = false;
            int playerScore = 0;
            int compScore = 0;
            int whoWon = -1;

            // Computer's choice.  Will be randomized.
            int compTurnR = 0;
            int compTurnC = 0;

            Console.WriteLine("Please enter the number of the row and the column");
            Console.WriteLine("where you want to enter your X\n");

            Console.WriteLine("For example, Row: 2 Col: 2 to enter an X at the center like so: ");
            gameBoard[1, 1] = 'X';
            PrintBoard(gameBoard);
            Console.WriteLine("\n");
            gameBoard[1, 1] = ' ';

            // Game Loop
            do
            {
                // Display Board
                Console.WriteLine("\n\n");
                PrintScore(playerScore, compScore);
                PrintBoard(gameBoard);
                //Console.ReadLine();
                //done = true;

                if (done == false)
                {
                    // Check for win
                    whoWon = HasWon(gameBoard);

                    if (whoWon == 0)
                    {
                        playerScore++;
                        PrintScore(playerScore, compScore);
                        PrintBoard(gameBoard);

                        Console.WriteLine("Congratulations Player!");
                        Console.WriteLine("Do you want to play again?");

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else if (whoWon == 1)
                    {
                        compScore++;
                        PrintScore(playerScore, compScore);
                        PrintBoard(gameBoard);

                        Console.WriteLine("Too Bad!  Computer Won This Time!");
                        Console.WriteLine("Do you want to play again?");

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else if (whoWon == 3)
                    {
                        Console.WriteLine("No more moves left!  It's a tie!");
                        Console.WriteLine("Do you want to play again?");
                        PrintBoard(gameBoard);

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else
                        Console.WriteLine("Your move");

                    // Take user's input.  Loop user input until correct values are received.
                    PlaceMark(gameBoard);
                }

                if (done == false)
                {
                    // Check for win
                    whoWon = HasWon(gameBoard);

                    if (whoWon == 0)
                    {
                        playerScore++;
                        PrintScore(playerScore, compScore);
                        PrintBoard(gameBoard);

                        Console.WriteLine("Congratulations Player!");
                        Console.WriteLine("Do you want to play again?");

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else if (whoWon == 1)
                    {
                        compScore++;
                        PrintScore(playerScore, compScore);
                        PrintBoard(gameBoard);

                        Console.WriteLine("Too Bad!  Computer Won This Time!");
                        Console.WriteLine("Do you want to play again?");

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else if (whoWon == 3)
                    {
                        Console.WriteLine("No more moves left!  It's a tie!");
                        Console.WriteLine("Do you want to play again?");
                        PrintBoard(gameBoard);

                        bool isValid = false;
                        while (!isValid)
                        {
                            Console.Write("Yes or No: ");
                            string keepPlaying = Console.ReadLine();

                            if (keepPlaying.ToLower() == "yes")
                            {
                                done = false;
                                isValid = true;
                                gameBoard = InitializeBoard();
                            }
                            else if (keepPlaying.ToLower() == "no")
                            {
                                done = true;
                                isValid = true;
                            }
                            else
                            {
                                Console.WriteLine("Please Enter Yes or No");
                                isValid = false;
                            }
                        }
                    }
                    else
                        Console.WriteLine("Your move");

                    // Computer's turn
                    Console.WriteLine("Computer's Turn!");

                    bool goodRoll = false;

                    if (whoWon != 0 || whoWon != 1 || whoWon != 3)
                    {
                        while (!goodRoll)
                        {
                            Random compRow = new Random();
                            compTurnR = compRow.Next(0, 3);
                            Random compCol = new Random();
                            compTurnC = compCol.Next(0, 3);

                            if (gameBoard[compTurnR, compTurnC] == ' ')
                            {
                                gameBoard[compTurnR, compTurnC] = 'O';
                                goodRoll = true;
                            }
                        }
                        PrintBoard(gameBoard);
                    }
                    else if (done == true)
                    {
                        continue;
                    }
                }
            } while (!done);
        }

        static void PrintScore(int player, int computer)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("       Player's Score: {0}       Computer's Score: {1}\n\n", player, computer);
        }

        static void PrintBoard(char[,] board)
        {
            Console.WriteLine(" {0} | {1} | {2} ", board[0, 0], board[0, 1], board[0, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[1, 0], board[1, 1], board[1, 2]);
            Console.WriteLine("---|---|---");
            Console.WriteLine(" {0} | {1} | {2} ", board[2, 0], board[2, 1], board[2, 2]);
        }

        static char[,] PlaceMark(char[,] updatedBoard)
        {
            bool success = false;
            bool rightChoice = false;
            int row = 0;
            int col = 0;

            while (!success)
            {
                Console.WriteLine("Where do you want to place your 'X'?");
                Console.Write("Row: ");
                success = int.TryParse(Console.ReadLine(), out row);
                if (success)
                {
                    if (row > 0 && row < 4)
                    {
                        Console.Write("Column: ");
                        success = int.TryParse(Console.ReadLine(), out col);

                        if (success)
                        {
                            if (col > 0 && col < 4)
                            {
                                if (updatedBoard[row - 1, col - 1] == ' ')
                                    updatedBoard[row - 1, col - 1] = 'X';
                                else
                                    Console.WriteLine("{0} is already in that space!", updatedBoard[row - 1, col - 1]);
                                // Below is For Testing  Comment out for completed project
                                //PrintBoard(updatedBoard);
                                //Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("The value of Column must be 1 to 3.  Please try again.");
                                success = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid number");
                            success = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("The value of Row must be 1 to 3.  Please try again.");
                        success = false;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid number");
                    success = false;
                }
            }
            return updatedBoard;
        }

        static int HasWon(char[,] victoryBoard)
        {
            int winner = 0;
            bool fullBoard = false;

            // 0 = Player Won
            // 1 = Computer Won
            // 2 = No Winners - Game On
            // 3 = Tie - Full Board

            if ((winner = IsHorizontalWin(victoryBoard)) != 2)
            {
                return winner;
            }
            else if ((winner = IsVerticalWin(victoryBoard)) != 2)
            {
                return winner;
            }
            else if ((winner = IsDiagonalWin(victoryBoard)) != 2)
            {
                return winner;
            }
            else if ((fullBoard = IsTie(victoryBoard)) == true)
            {
                return 3;
            }
            else
                return winner;

        }

        static int IsHorizontalWin(char[,] horizontalBoard)
        {
            char winnerIs = 'X';
            char[] winningRow = new char[3];
            bool match = false;

            for (int row = 0; row < 3; row++)
            {
                winnerIs = horizontalBoard[row, 0];

                if (winnerIs != ' ')
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if (horizontalBoard[row, col] != ' ')
                        {
                            winningRow[col] = horizontalBoard[row, col];
                        }
                        else
                            col = 3;

                        if (col != 3)
                        {
                            if (winnerIs != winningRow[col])
                            {
                                col = 3;
                            }
                            else if ((col + 1) == 3)
                            {
                                match = true;
                                col = 3;
                            }
                        }
                    }
                }
                else
                {
                    match = false;
                }

                if (match == true)
                {
                    break;
                }
            }

            if (match == true)
            {
                if (winnerIs == 'X')
                    return 0;
                else
                    return 1;
            }
            else
                return 2;
        }

        static int IsVerticalWin(char[,] verticalBoard)
        {
            char winnerIs = 'X';
            char[] winningRow = new char[3];
            bool match = false;

            for (int col = 0; col < 3; col++)
            {
                winnerIs = verticalBoard[0, col];

                if (winnerIs != ' ')
                {
                    for (int row = 0; row < 3; row++)
                    {
                        if (verticalBoard[row, col] != ' ')
                        {
                            winningRow[row] = verticalBoard[row, col];
                        }
                        else
                            row = 3;

                        if (row != 3)
                        {
                            if (winnerIs != winningRow[row])
                            {
                                row = 3;
                            }
                            else if ((row + 1) == 3)
                            {
                                match = true;
                                row = 3;
                            }
                        }
                    }
                }
                else
                {
                    match = false;
                }

                if (match == true)
                {
                    break;
                }
            }

            if (match == true)
            {
                if (winnerIs == 'X')
                    return 0;
                else
                    return 1;
            }
            else
                return 2;
        }

        static int IsDiagonalWin(char[,] diagonalBoard)
        {
            int winnerIs = 0;
            bool topMatch = false;
            bool bottomMatch = false;

            char topDiagonal = diagonalBoard[0, 0];
            char bottomDiagonal = diagonalBoard[2, 0];

            if (topDiagonal != ' ')
            {
                if (diagonalBoard[1, 1] == topDiagonal && diagonalBoard[2, 2] == topDiagonal)
                {
                    topMatch = true;
                    if (topDiagonal == 'X')
                        winnerIs = 0;
                    else
                        winnerIs = 1;
                }
                else
                    topMatch = false;
            }
            else
            {
                topMatch = false;
            }

            if (topMatch == false)
            {
                if (bottomDiagonal != ' ')
                {
                    if (diagonalBoard[1, 1] == bottomDiagonal && diagonalBoard[0, 2] == bottomDiagonal)
                    {
                        bottomMatch = true;
                        if (bottomDiagonal == 'X')
                            winnerIs = 0;
                        else
                            winnerIs = 1;
                    }
                    else
                        bottomMatch = false;
                }
                else
                    bottomMatch = false;
            }

            if (topMatch == false && bottomMatch == false)
                winnerIs = 2;

            return winnerIs;
        }

        static bool IsTie(char[,] isFullBoard)
        {
            bool isFull = false;
            bool spaceFound = false;

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (isFullBoard[row, col] == ' ')
                    {
                        spaceFound = true;
                        isFull = false;
                        break;
                    }
                }

                if (spaceFound == true)
                    break;
                else
                {
                    if ((row + 1) == 3)
                    {
                        isFull = true;
                        break;
                    }
                }
            }

            if (spaceFound == true)
                return isFull;
            else
                return isFull;
        }
    }
}
