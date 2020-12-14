using System;
using System.Collections.Generic;
using Chess;

namespace ChessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.H, Vertical.Five));
            King blackRook2 = new King(game, Color.Black, new Field(Horizontal.E, Vertical.Eight));
            Rook blackRook = new Rook(game, Color.Black, new Field(Horizontal.H, Vertical.Eight));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackRook2 });


            foreach (var item in blackRook.PossibleMoves)
            {
                Console.WriteLine(item.Horizontal+" "+item.Vertical);
            }
            Console.ReadKey();
        }
    }
}
