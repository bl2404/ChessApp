using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chess;

namespace DesktopChess.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        public Game Model { get; private set; }

        public GameViewModel()
        {
            Model = new Game();
            Model.SetupExample1();
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
