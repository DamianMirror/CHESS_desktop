using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public enum Player
    {
        None,
        White,
        Black
    }

    public static class PlayerExtensions
    {
        public static Player GetOpponent(this Player player) 
        {
            return player == Player.White ? Player.Black : Player.White;
        }
    }
}
