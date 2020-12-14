using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Game
    {
        public void AddFigures(List<IFigure> figures)
        {
            Figures = figures;
        }
        public List<IFigure> Figures { get; private set; }
    }
}
