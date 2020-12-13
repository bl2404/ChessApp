using System;
using System.Collections.Generic;
using Chess;

namespace ChessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            King whiteKing = new King(Color.White, new Field(Horizontal.H, Vertical.Five));
            King blackRook2 = new King(Color.Black, new Field(Horizontal.E, Vertical.Eight));
            Rook blackRook = new Rook(Color.Black, new Field(Horizontal.H, Vertical.Eight));

            Game game = new Game(new List<IFigure>() { whiteKing,whiteKing,blackRook});

            foreach (var item in blackRook.PossibleMoves)
            {
                Console.WriteLine(item.Horizontal+" "+item.Vertical);
            }
            Console.ReadKey();
        }
    }
}
