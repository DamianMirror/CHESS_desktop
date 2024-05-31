using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }
        private readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;
            if(color == Player.White)
            {
                forward = Direction.Up;
            }
            else
            {
                forward = Direction.Down;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsOnBoard(pos) && board.IsEmpty(pos);
        }

        private bool CanCapture(Position pos, Board board, Player color)
        {
            return Board.IsOnBoard(pos) && !board.IsEmpty(pos) && board[pos].Color != color;
        }

        private IEnumerable<Move> ForwardMoves(Board board, Position from)
        {
            Position oneMovePos = from + forward;
            if (CanMoveTo(oneMovePos, board))
            {
                yield return new NormalMove(from, oneMovePos);
                Position twoMovePos = oneMovePos + forward;
                if (!HasMoved && CanMoveTo(twoMovePos, board))
                {
                    yield return new NormalMove(from, twoMovePos);
                }
            }
        }

        private IEnumerable<Move> CaptureMoves(Board board, Position from)
        {
            foreach(Direction dir in new Direction[] { Direction.Left, Direction.Right })
            {
                Position to = from + forward + dir;
                if (CanCapture(to, board, Color))
                {
                    yield return new NormalMove(from, to);
                }
            }
        }

        public override IEnumerable<Move> GetMoves(Board board, Position from)
        {
            return ForwardMoves(board, from).Concat(CaptureMoves(board, from));
        }
    }
}
