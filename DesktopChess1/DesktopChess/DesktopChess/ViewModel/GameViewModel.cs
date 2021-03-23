using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chess;

namespace DesktopChess.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        public GameViewModel()
        {
            foreach (var figure in model.Figures)
            {
                //new FigureViewModel();
            }
        }

        private Game model = new Game();


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
