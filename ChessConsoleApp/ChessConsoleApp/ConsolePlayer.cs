using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Chess;
using Chess.Players;

namespace ChessConsoleApp
{
    public class ConsolePlayer : Player
    {
        public ConsolePlayer(Game game) : base(game) { }

        public override Color Color => Color.White;

        public override void InitiateMove()
        {
            IFigure figure;
            char[] input = Console.ReadLine().ToCharArray();
            if (input[0] == 'K')
                figure = Game.Figures.First(x => x.Color == this.Color && x is King);
            else
                figure = Game.Figures.First(x => x.Color == this.Color && x is Rook);

            Horizontal a=(Horizontal)Enum.Parse(typeof(Horizontal),input[1].ToString());
            Vertical b=(Vertical)Enum.Parse(typeof(Vertical),"_"+input[2].ToString());

            Field field = new Field(a, b);
            Move(figure, field);
        }

        private void Move(IFigure figure, Field field)
        {
            var move = new Move(figure, field);
            if (PossibleMoves.Any(x => x.IsMoveTheSame(move)))
            {
                figure.Move(field);
                Console.WriteLine("your move: "+field.Horizontal,field.Vertical);
            }
            else
                Console.WriteLine("Illegal move");
        }
    }
}
