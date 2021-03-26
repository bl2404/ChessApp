using System;
using System.Collections.Generic;
using System.Text;
using Chess.Players;
using System.Linq;

namespace Chess
{
    public class Game
    {
        public Game()
        {
        }

        public void SetupExample()
        {
            King whiteKing = new King(this, Color.White, new Field(Horizontal.F, Vertical._6));
            Rook whiteRook = new Rook(this, Color.White, new Field(Horizontal.E, Vertical._6));
            King blackKing = new King(this, Color.Black, new Field(Horizontal.H, Vertical._8));

            AddFigures(new List<IFigure>() { whiteKing, blackKing, whiteRook });
        }

        internal void NoMoreEvent(object sender, EventArgs e)
        {
            var result = Result.White_Win;
            if (!Check)
                result = Result.Draw;
            RaiseGameFinished(result);
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
            FinishMove();
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

        public void FinishMove()
        {
            if (MoveFinish != null && CurrentPlayer==WhitePlayer)
                MoveFinish(this, EventArgs.Empty);
        }


        //public delegate OnGameFinished(object sender, ResultEventArgs eventArgs);
        public event EventHandler<ResultEventArgs> GameFinished;
        private void RaiseGameFinished(Result result)
        {
            var eventArgs = new ResultEventArgs(result);
            if (GameFinished != null)
                GameFinished(this, eventArgs);
        }

        public bool Check => CheckForCheck();
        private bool CheckForCheck()
        {
            King king = (King)Figures.First(x => x is King && x.Color == CurrentPlayer.Color);
            foreach (var figure in Figures.Where(x=>x.Color != CurrentPlayer.Color))
            {
                foreach (var field in figure.PossibleMoves)
                {
                    if (field.IsFieldTheSame(king.Field))
                        return true;
                }
            }
            return false;
        }

        public List<IFigure> Figures { get; private set; }

        public Player WhitePlayer { get; set; }

        public Player BlackPlayer { get; set; }

        public Player CurrentPlayer { get; set; }
    }

    public class ResultEventArgs:EventArgs
    {
        public ResultEventArgs(Result result)
        {
            Result = result;
        }
        public Result Result { get; private set; }
    }

    public enum Result
    {
        White_Win,
        Black_Win,
        Draw
    }
}
