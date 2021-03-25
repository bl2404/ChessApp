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
            Finish();
        }

        private void SetCurrentTurn()
        {
            if (CurrentPlayer == WhitePlayer)
                CurrentPlayer = BlackPlayer;
            else
                CurrentPlayer = WhitePlayer;
        }

        public delegate void OnMoveFinished(object source, EventArgs eventArgs);

        public event OnMoveFinished MoveFinish;

        public void Finish()
        {
            if (MoveFinish != null && CurrentPlayer==WhitePlayer)
                MoveFinish(this, EventArgs.Empty);
        }

        public List<IFigure> Figures { get; private set; }

        public Player WhitePlayer { get; set; }

        public Player BlackPlayer { get; set; }

        public Player CurrentPlayer { get; set; }
    }
}
