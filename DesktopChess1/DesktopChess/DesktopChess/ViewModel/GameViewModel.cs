using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Chess;
using Chess.Players;
using DesktopChess.View;

namespace DesktopChess.ViewModel
{
    class GameViewModel
    {
        public Game Model { get; private set; }
        public Board Board { get; set; }

        public EventHandler EventHandler;

        public GameViewModel(Board board)
        {
            Model = new Game();
            Board = board;
            //SetupExample();
            SetupExampleAutoAttack();
            Model.GameFinished += Model_GameFinished;
        }

        private void Model_GameFinished(object sender, ResultEventArgs e)
        {
            MessageBoxResult m=MessageBox.Show(e.Result.ToString());
        }

        void SetupExample()
        {
            Model = new Game();
            King whiteKing = new King(Model, Color.White, new Field(Horizontal.F, Vertical._6));
            Rook whiteRook = new Rook(Model, Color.White, new Field(Horizontal.E, Vertical._6));
            King blackKing = new King(Model, Color.Black, new Field(Horizontal.H, Vertical._8));

            Model.AddFigures(new List<IFigure>() { whiteKing, blackKing, whiteRook });

            //Model.AddFigures(new List<IFigure>() { whiteKing });

            Model.WhitePlayer = new DesktopPlayer(Model);
            Model.BlackPlayer = new AutoPlayerDefend(Model);
            Model.CurrentPlayer = Model.WhitePlayer;
            Model.CurrentPlayer.InitiateMove();
        }

        private void SetupExampleAutoAttack()
        {
            Model = new Game();
            King whiteKing = new King(Model, Color.White, new Field(Horizontal.E, Vertical._5));
            Rook blackRook = new Rook(Model, Color.Black, new Field(Horizontal.C, Vertical._3));
            King blackKing = new King(Model, Color.Black, new Field(Horizontal.D, Vertical._3));

            Model.AddFigures(new List<IFigure>() { whiteKing, blackKing, blackRook });

            //Model.AddFigures(new List<IFigure>() { whiteKing });

            Model.WhitePlayer = new DesktopPlayer(Model);
            Model.BlackPlayer = new AutoPlayerAttack(Model);
            Model.CurrentPlayer = Model.WhitePlayer;
            Model.CurrentPlayer.InitiateMove();
        }


        private void SetupExampleAutoAttack1()
        {
            Model = new Game();
            King whiteKing = new King(Model, Color.White, new Field(Horizontal.E, Vertical._4));
            Rook blackRook = new Rook(Model, Color.Black, new Field(Horizontal.E, Vertical._8));
            King blackKing = new King(Model, Color.Black, new Field(Horizontal.E, Vertical._6));

            Model.AddFigures(new List<IFigure>() { whiteKing, blackKing, blackRook });

            //Model.AddFigures(new List<IFigure>() { whiteKing });

            Model.WhitePlayer = new DesktopPlayer(Model);
            Model.BlackPlayer = new AutoPlayerAttack(Model);
            Model.CurrentPlayer = Model.WhitePlayer;
            Model.CurrentPlayer.InitiateMove();
        }
    }
}
