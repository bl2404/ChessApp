using System;
using System.Collections.Generic;
using Chess;
using Chess.Players;

namespace ChessConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            SetupExample();
            Console.WriteLine("end");
            Console.ReadKey();
        }

        static void SetupExample()
        {
            Game game = new Game();
            King whiteKing = new King(game, Color.White, new Field(Horizontal.F, Vertical._6));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.E, Vertical._6));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.H, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, blackKing, whiteRook });

            game.WhitePlayer = new ConsolePlayer(game);
            game.BlackPlayer = new AutoPlayerDefend(game);
            game.CurrentPlayer = game.WhitePlayer;
            game.CurrentPlayer.InitiateMove();
        }
    }
}
