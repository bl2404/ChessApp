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
        }

        public Field Field
        {
            get { return _figure.Field; }
            set
            {
                //_figure.Field = value;
                OnPropertyChanged(nameof(Field));
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
