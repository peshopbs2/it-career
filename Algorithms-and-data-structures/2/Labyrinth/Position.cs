using System;
using System.Collections.Generic;
using System.Text;

namespace Labyrinth
{
    class Position
    {
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public int Row { get; set; }
        public int Column { get; set; }

        public static bool operator ==(Position alpha, Position betta)
        {
            return (alpha.Row == betta.Row && alpha.Column == betta.Column);
        }
        public static bool operator !=(Position alpha, Position betta)
        {
            return !(alpha.Row == betta.Row && alpha.Column == betta.Column);
        }

    }
}
