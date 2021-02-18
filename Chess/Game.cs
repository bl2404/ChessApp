using System;
using System.Collections.Generic;
using System.Text;
using Chess.Players;

namespace Chess
{
    public class Game
    {
        public void SetupExample()
        {
            King whiteKing = new King(this, Color.White, new Field(Horizontal.F, Vertical._6));
            Rook whiteRook = new Rook(this, Color.White, new Field(Horizontal.E, Vertical._6));
            King blackKing = new King(this, Color.Black, new Field(Horizontal.H, Vertical._8));

            AddFigures(new List<IFigure>() { whiteKing, blackKing, whiteRook });

            WhitePlayer = new ConsolePlayer(this);
            BlackPlayer = new AutoPlayerDefend(this);
            CurrentPlayer = WhitePlayer;
            CurrentPlayer.InitiateMove();
        }

        public void AddFigures(List<IFigure> figures)
        {
            Figures = figures;
        }

        public void OnIFigureMoved(object sender, EventArgs eventArgs)
        {
            IFigure figure = (IFigure)sender;
            SetCurrentTurn();
            CurrentPlayer.InitiateMove();
        }

        private void SetCurrentTurn()
        {
            if (CurrentPlayer == WhitePlayer)
                CurrentPlayer = BlackPlayer;
            else
                CurrentPlayer = WhitePlayer;
        }


        public List<IFigure> Figures { get; private set; }

        public Player WhitePlayer { get; private set; }

        public Player BlackPlayer { get; private set; }

        public Player CurrentPlayer { get; private set; }
    }
}
