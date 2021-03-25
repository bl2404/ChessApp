using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Chess
{
    public interface IFigure: INotifyPropertyChanged
    {
        delegate void IFigureMovedEventHandler(object source, EventArgs eventArgs);

        event IFigureMovedEventHandler IFigureMoved;

        void OnIFigureMoved();

        void Move(Field field);

        Game Game { get; }
       
        List<Field> PossibleMoves { get; }

        List<Field> VisibleFields { get; } 

        Field Field { get; }

        Color Color { get; }
    }
}
