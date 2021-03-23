using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess.Players
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

            Enum.TryParse(input[1].ToString(), out Horizontal horizontal);
            Enum.TryParse("_"+input[2].ToString(), out Vertical vertical);

            Field field = new Field(horizontal, vertical);
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
