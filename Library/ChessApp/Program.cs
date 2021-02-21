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
            game.SetupExample();
            Console.WriteLine("end");
            Console.ReadKey();
        }
    }
}
