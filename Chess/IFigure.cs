using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public interface IFigure
    {
        void Move(Field field);

        Game Game { get; }
       
        List<Field> PossibleMoves { get; }

        List<Field> VisibleFields { get; }

        Field Field { get; }

        Color Color { get; }
    }
}
