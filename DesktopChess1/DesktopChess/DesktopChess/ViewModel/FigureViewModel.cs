using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chess;

namespace DesktopChess.ViewModel
{
    class FigureViewModel : INotifyPropertyChanged
    {

        private string imagePath;

        private IFigure _figure;

        public FigureViewModel(Game game, IFigure figure)
        {
            _figure = figure;
        }

        //public int VerticalLocation
        //{
        //    get { return _figure.Field.Vertical; }
        //}


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
