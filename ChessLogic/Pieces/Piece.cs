using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false;
        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Board board, Position from);

        protected IEnumerable<Position> MovePosiotionsInDir(Board board, Position from, Direction dir)
        {
            for(Position pos = from + dir; Board.IsOnBoard(pos); pos += dir)
            {
                if (board[pos] == null)
                {
                    yield return pos;
                    continue;
                }
                else
                {
                    if (board[pos].Color != Color)
                    {
                        yield return pos;
                    }
                    yield break;
                }
            }
        }
        protected IEnumerable<Position> MovePositionsInDirs(Board board, Position from, Direction[] dirs)
        {
           return dirs.SelectMany(dir => MovePosiotionsInDir(board, from, dir));
        }
    }
}
