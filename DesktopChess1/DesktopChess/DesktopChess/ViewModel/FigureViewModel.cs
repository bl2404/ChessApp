using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Chess;
using System.Threading.Tasks;

namespace DesktopChess.ViewModel
{
    class FigureViewModel: INotifyPropertyChanged
    {
        private IFigure _figure;

        public FigureViewModel(IFigure figure)
        {
            _figure = figure;
            verticalLocation = 8 - (int)figure.Field.Vertical;
            horizontalLocation = (int)figure.Field.Horizontal - 1;
            this._figure.Game.MoveFinish += Game_MoveFinish;
            this._figure.IFigureMoved += _figure_IFigureMoved;
        }

        private void _figure_IFigureMoved(object source, EventArgs eventArgs)
        {
            VerticalLocation=8-(int)_figure.Field.Vertical;
            HorizontalLocation = (int)_figure.Field.Horizontal - 1;
        }

        private void Game_MoveFinish(object source, EventArgs eventArgs)
        {
            System.Diagnostics.Debug.WriteLine(
                "MOVE_INFO - " + _figure.GetType() + " " + _figure.Color + " " + _figure.Field.Horizontal + _figure.Field.Vertical);
            if (_figure.Color == Color.White)
                return;
            locked = true;
            VerticalLocation = 8 - (int)_figure.Field.Vertical;
            HorizontalLocation = (int)_figure.Field.Horizontal - 1;
            locked = false;
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


        public virtual void OnPropertyChanged(string propertyName)
        {
            //if (propertyName == nameof(VerticalLocation) && !locked)
            //{
            //    Horizontal horizontal = (Horizontal)Enum.Parse(typeof(Horizontal), (1 + HorizontalLocation).ToString());
            //    Vertical vertical = (Vertical)Enum.Parse(typeof(Vertical), (8 - VerticalLocation).ToString());
            //    Field field = new Field(horizontal, vertical);
            //    _figure.Move(field);
            //}

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }


        public void Move(int horizontal, int vertical)
        {
            Horizontal horizontalConverted = (Horizontal)Enum.Parse(typeof(Horizontal), (1 + horizontal).ToString());
            Vertical verticalConverted = (Vertical)Enum.Parse(typeof(Vertical), (8 - vertical).ToString());
            Field field = new Field(horizontalConverted, verticalConverted);
            _figure.Move(field);
        }

        private bool locked = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
