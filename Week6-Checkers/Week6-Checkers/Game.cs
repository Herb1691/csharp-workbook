using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Checkers
{
    public class Game
    {
        private Board board;
        public Game()
        {
            this.board = new Board();
        }

        public void Start()
        {
            bool done = false;
            bool winner = false;

            int pieceRow = 0;
            int pieceCol = 0;

            Checker selectedPiece = new Checker();
            Position selectedPos = new Position();
            Position destPos = new Position();

            while (!done)
            {
                bool success = false;
                bool isLegalMove = false;

                DrawBoard();

                Console.WriteLine("Please enter the row and column of the piece that you want to move.");
                Console.Write("Row: ");
                success = Int32.TryParse(Console.ReadLine(), out pieceRow);

                if (success)
                {
                    if (pieceRow >= 0 || pieceRow <= 7)
                    {
                        Console.Write("Column: ");
                        success = Int32.TryParse(Console.ReadLine(), out pieceCol);

                        if (success)
                        {
                            if (pieceCol >= 0 || pieceCol <= 7)
                            {
                                selectedPos = new Position(pieceRow, pieceCol);
                                selectedPiece = board.GetChecker(selectedPos);

                                if (selectedPiece != null)
                                {
                                    destPos = ProcessInput();
                                    isLegalMove = IsLegalMove(selectedPiece.team, selectedPiece.position, destPos);

                                    if (isLegalMove)
                                    {
                                        board.MoveChecker(selectedPiece, destPos);
                                        winner = board.CheckForWin();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cannot move to that position!  Please try again.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Not a valid piece!  Please select another one.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter a column from 0 to 7.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Column not valid.  Please try again.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a row from 0 to 7.");
                    }
                }
                else
                {
                    Console.WriteLine("Row not valid.  Please try again.");
                }

                if (winner)
                {
                    Console.WriteLine("You won!  Congratulations!");
                    Console.WriteLine("Would you like to play again?");

                    bool answer = false;

                    while(!answer)
                    {
                        Console.Write("\nContinue? (Y or N) ");
                        string quit = Console.ReadLine();

                        if (quit.ToUpper() == "Y")
                        {
                            done = false;
                            this.board = new Board();
                            answer = true;
                        }
                        else if (quit.ToUpper() == "N")
                        {
                            done = true;
                            Console.WriteLine("Thanks for playing!");
                            Console.ReadLine();
                            answer = true;
                        }
                        else
                        {
                            answer = false;
                        }
                    }
                }
            }
        }// End Start

        public bool IsLegalMove(Color player, Position src, Position dest)
        {
            bool legalMove = false;
            Checker oopsPiece = new Checker();  // Check if destination already has a piece.

            oopsPiece = board.GetChecker(dest);

            if (oopsPiece == null)  // If the destination doesn't already contain a piece.
            {
                if (player == Color.Black)
                {
                    if ((src.row - dest.row) == 1)
                    {
                        if ((src.col - dest.col) == 1)  // Check if the player moved one space diagonally to the left
                        {
                            legalMove = true;
                        }
                        else if ((src.col - dest.col) == -1) // Check if the player moved one space diagonally to the right
                        {
                            legalMove = true;
                        }
                        else
                        {
                            legalMove = false;
                        }
                    }
                    else if ((src.row - dest.row) == 2)
                    {
                        if ((src.col - dest.col) == 2) // Check if the player moved two spaces diagonally to the left
                        {
                            legalMove = IsCapture(src, dest);
                        }
                        else if ((src.col - dest.col) == -2) // Check if the player moved two spaces diagonally to the right
                        {
                            legalMove = IsCapture(src, dest);
                        }
                        else
                        {
                            legalMove = false;
                        }
                    }
                    else
                    {
                        legalMove = false;
                    }
                }
                else if (player == Color.White)
                {
                    if ((src.row - dest.row) == -1)
                    {
                        if ((src.col - dest.col) == -1) // Check if the player moved one space diagonally to the left
                        {
                            legalMove = true;
                        }
                        else if ((src.col - dest.col) == 1) // Check if the player moved one space diagonally to the right
                        {
                            legalMove = true;
                        }
                        else
                        {
                            legalMove = false;
                        }
                    }
                    else if ((src.row - dest.row) == -2)
                    {
                        if ((src.col - dest.col) == -2) // Check if the player moved two spaces diagonally to the left
                        {
                            legalMove = IsCapture(src, dest);
                        }
                        else if ((src.col - dest.col) == 2) // Check if the player moved two spaces diagonally to the right
                        {
                            legalMove = IsCapture(src, dest);
                        }
                        else
                        {
                            legalMove = false;
                        }
                    }
                    else
                    {
                        legalMove = false;
                    }
                }
            }
            else
            {
                legalMove = false;
            }
            return legalMove;
        }// End IsLegalMove

        public bool IsCapture(Position src, Position dest)
        {
            bool cap = false;

            Checker capturedPiece = GetCaptureChecker(src, dest);

            if (capturedPiece != null)
            {
                board.RemoveChecker(capturedPiece);
                cap = true;
            }
            else
            {
                cap = false;
            }

            return cap;
        }

        public Checker GetCaptureChecker(Position src, Position dest)
        {
            Checker capPiece = new Checker();
            Checker srcPiece = board.GetChecker(src);
            Position capPosition = new Position();

            if (src.row < dest.row)
            {
                if (src.col < dest.col)
                {
                    capPosition = new Position(src.row + 1, src.col + 1);
                }
                else if (src.col > dest.col)
                {
                    capPosition = new Position(src.row + 1, src.col - 1);
                }
            }
            else if (src.row > dest.row)
            {
                if (src.col < dest.col)
                {
                    capPosition = new Position(src.row - 1, src.col + 1);
                }
                else if (src.col > dest.col)
                {
                    capPosition = new Position(src.row - 1, src.col - 1);
                }
            }

            capPiece = board.GetChecker(capPosition);

            if (srcPiece.team == capPiece.team)
            {
                capPiece = null;
            }

            //foreach (Checker piece in board.checkers)
            //{
            //    if (piece.position.row == capPosition.row && piece.position.col == capPosition.col)
            //    {
            //        capPiece = piece;
            //        break;
            //    }
            //    else
            //    {
            //        capPiece = null;
            //    }
            //}

            return capPiece;
        }

        public Position ProcessInput()
        {
            int destRow = 0;
            int destCol = 0;

            bool goodInput = false;
            Position destPosition = new Position();

            Console.WriteLine("\nPlease enter the row and column of where you want to move the piece to.");
            Console.Write("Row: ");
            goodInput = Int32.TryParse(Console.ReadLine(), out destRow);

            if (goodInput)
            {
                Console.Write("Column: ");
                goodInput = Int32.TryParse(Console.ReadLine(), out destCol);

                if (goodInput)
                {
                    destPosition = new Position(destRow, destCol);
                }
            }

            return destPosition;
        }

        public void DrawBoard()
        {
            String[][] grid = new String[8][];
            for (int r = 0; r < 8; r++)
            {
                grid[r] = new String[8];
                for (int c = 0; c < 8; c++)
                {
                    grid[r][c] = " ";
                }
            }
            foreach (Checker c in board.checkers)
            {
                grid[c.position.row][c.position.col] = c.symbol;
            }

            Console.WriteLine("  0 1 2 3 4 5 6 7");
            for (int r = 0; r < 8; r++)
            {
                Console.Write(r);
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(" {0}", grid[r][c]);
                }
                Console.WriteLine();
            }
        }
    }
}
