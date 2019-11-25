using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Checkers
{
    public class Board
    {
        public List<Checker> checkers { get; private set; }
        public Board()
        {
            checkers = new List<Checker>();
            for (int r = 0; r < 3; r++)
            {
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.White, r, (r + 1) % 2 + i);
                    checkers.Add(c);
                }
                for (int i = 0; i < 8; i += 2)
                {
                    Checker c = new Checker(Color.Black, 5 + r, (r) % 2 + i);
                    checkers.Add(c);
                }
            }
        }

        public Checker GetChecker(Position pos)
        {
            bool match = false;
            Checker matchedPiece = new Checker();

            foreach (Checker piece in checkers)
            {
                if (piece.position.row == pos.row)
                {
                    if (piece.position.col == pos.col)
                    {
                        matchedPiece = piece;
                        match = true;
                        break;
                    }
                    else
                    {
                        match = false;
                    }
                }
                else
                {
                    match = false;
                }
            }

            if (match)
                return matchedPiece;
            else
                return null;
        }

        public void RemoveChecker(Checker checker)
        {
            checkers.Remove(checker);
        }

        public void MoveChecker(Checker checker, Position dest)
        {
            checker.position = dest;
        }
        public bool CheckForWin()
        {
            //bool bWinner = false;
            //bool wWinner = false;
            //bool noWinner = false;
            bool winner = false;

            bool wpFound = false;
            bool bpFound = false;

            foreach (Checker piece in checkers)
            {
                switch (piece.team)
                {
                    case Color.Black:
                        bpFound = true;
                        break;
                    case Color.White:
                        wpFound = true;
                        break;
                }
            }

            if (bpFound)
            {
                if (wpFound)
                {
                    winner = false;
                }
                else
                {
                    winner = true;
                }
            }
            else if (wpFound)
            {
                winner = true;
            }
            return winner;
        }
    }
}
