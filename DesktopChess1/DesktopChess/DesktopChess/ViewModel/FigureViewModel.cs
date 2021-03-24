using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chess;

namespace DesktopChess.ViewModel
{
    class FigureViewModel : INotifyPropertyChanged
    {
        private IFigure _figure;

        public FigureViewModel(IFigure figure)
        {
            _figure = figure;
            verticalLocation = 8 - (int)figure.Field.Vertical;
            horizontalLocation = (int)figure.Field.Horizontal;
        }

        private int verticalLocation;
        public int VerticalLocation 
        {
            get { return verticalLocation; }
            set
            {
                verticalLocation = value;
                OnPropertyChanged(nameof(VerticalLocation));
            }
        }

        private int horizontalLocation;
        public int HorizontalLocation
        {
            get { return horizontalLocation; }
            set
            {
                horizontalLocation = value;
                OnPropertyChanged(nameof(HorizontalLocation));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
