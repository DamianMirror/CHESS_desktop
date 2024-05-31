using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;
        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static IEnumerable<Position> PotentialToPositions(Position from)
        {
            foreach(Direction vDir in new Direction[] { Direction.Up, Direction.Down })
            {
                foreach(Direction hDir in new Direction[] { Direction.Left, Direction.Right })
                {
                    yield return from + vDir + hDir + hDir;
                    yield return from + hDir + hDir + vDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Board board, Position from)
        {
            return PotentialToPositions(from).Where(to => Board.IsOnBoard(to) && (board.IsEmpty(to) || board[to].Color != Color));
        }

        public override IEnumerable<Move> GetMoves(Board board, Position from)
        {
            return MovePositions(board, from).Select(to => new NormalMove(from, to));
        }

    }
}
