using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Direction
    {
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction UpLeft = Up + Left;
        public readonly static Direction UpRight = Up + Right;
        public readonly static Direction DownLeft = Down + Left;
        public readonly static Direction DownRight = Down + Right;


        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta)
        {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        public static Direction operator +(Direction a, Direction b)
        {
            return new Direction(a.RowDelta + b.RowDelta, a.ColumnDelta + b.ColumnDelta);
        }

        public static Direction operator *(int scalar, Direction a)
        {
            return new Direction(scalar * a.RowDelta, scalar * a.ColumnDelta);
        }
    }
}
