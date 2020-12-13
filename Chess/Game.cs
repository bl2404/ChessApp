using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Game
    {
        public Game(List<IFigure> figures)
        {
            Figures = figures;
            Board = new Board();
            Instance = this;
        }

        public Board Board { get; private set; }

        public List<IFigure> Figures { get; private set; }

        public static Game Instance { get; private set; }
    }
}
