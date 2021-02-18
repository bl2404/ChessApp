using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess.Players
{
    public abstract class Player
    {
        public Player(Game game)
        {
            Game = game;
        }

        public abstract void InitiateMove();

        public List<Move> PossibleMoves => FindPossibleMoves();

        public Game Game { get; private set; }

        public abstract Color Color { get; }

        private List<Move> FindPossibleMoves()
        {
            List<Move> moves = new List<Move>();
            foreach (var figure in Game.Figures.Where(x=>x.Color==this.Color))
            {
                foreach (var field in figure.PossibleMoves)
                {
                    moves.Add(new Move(figure, field));
                }
            }
            return moves;
        }
    }
}
