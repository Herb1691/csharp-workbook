using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Checkers
{
    public struct Position
    {
        public int row { get; private set; }
        public int col { get; private set; }
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    public enum Color { White, Black }

    public class Checker
    {
        // If White a open dot, if Black a closed dot
        public String symbol { get; private set; }
        // Either White or Black
        public Color team { get; private set; }
        public Position position { get; set; }

        public Checker()
        {
            team = Color.Black;
            position = new Position(0, 0);

            int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
            symbol = char.ConvertFromUtf32(closedCircleId);
            //string closedCircle = char.ConvertFromUtf32(closedCircleId);
            //symbol = char.Parse(closedCircle);
        }
        public Checker(Color team, int row, int col)
        {
            this.team = team;
            position = new Position(row, col);

            switch (team)
            {
                case Color.White:
                    int openCircleId = int.Parse("25CB", System.Globalization.NumberStyles.HexNumber);
                    symbol = char.ConvertFromUtf32(openCircleId);
                    //string openCircle = char.ConvertFromUtf32(openCircleId);
                    //symbol = char.Parse(openCircle);
                    break;

                case Color.Black:
                    int closedCircleId = int.Parse("25CF", System.Globalization.NumberStyles.HexNumber);
                    symbol = char.ConvertFromUtf32(closedCircleId);
                    //string closedCircle = char.ConvertFromUtf32(closedCircleId);
                    //symbol = char.Parse(closedCircle);
                    break;
            }
        }

    }
}
