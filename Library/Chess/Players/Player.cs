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
            NoMoveEvent = game.NoMoreMoveEvent;
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
            if (moves.Count == 0)
                RaiseNoMoveEvent();
            return moves;
        }

        public delegate void OnNoMoveSituation(object sender, EventArgs e);
        public EventHandler NoMoveEvent;
        
        private void RaiseNoMoveEvent()
        {
            if (NoMoveEvent != null)
                NoMoveEvent(this, EventArgs.Empty);
        }
    }
}
