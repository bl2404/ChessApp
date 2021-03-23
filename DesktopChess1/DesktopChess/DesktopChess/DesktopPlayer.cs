using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chess;
using Chess.Players;

namespace DesktopChess
{
    class DesktopPlayer : Player
    {
        public DesktopPlayer(Game game) : base(game) { }

        public override Color Color => Color.White;

        public override void InitiateMove()
        {
        }

        public void Move(IFigure figure, Field field)
        {
            var move = new Move(figure, field);
            if (PossibleMoves.Any(x => x.IsMoveTheSame(move)))
            {
                figure.Move(field);
                Console.WriteLine("your move: " + field.Horizontal, field.Vertical);
            }
            else
                Console.WriteLine("Illegal move");
        }
    }
}
