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
            this._figure.PropertyChanged += new PropertyChangedEventHandler(model_PropertyChanged);
            this._figure.IFigureMoved += _figure_IFigureMoved;
            this._figure.Game.MoveFinish += Game_MoveFinish;
            Task task = new Task(() => DoAction());
            //task.Start();
        }

        public void DoAction()
        {
            System.Threading.Thread.Sleep(4000);
            VerticalLocation = 3;
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

        private void _figure_IFigureMoved(object source, EventArgs eventArgs)
        {
            //locked = true;
            //Figure movedFigure = (Figure)source;
            //if (movedFigure.Color == Color.Black)
            //{
            //    VerticalLocation = 8 - (int)movedFigure.Field.Vertical;
            //    HorizontalLocation = (int)movedFigure.Field.Horizontal;
            //}
            //locked = false;
        }

        private void model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

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


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName == nameof(VerticalLocation) && !locked)
            {
                Horizontal horizontal = (Horizontal)Enum.Parse(typeof(Horizontal), (1 + HorizontalLocation).ToString());
                Vertical vertical = (Vertical)Enum.Parse(typeof(Vertical), (8 - VerticalLocation).ToString());
                Field field = new Field(horizontal, vertical);
                _figure.Move(field);
            }

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        private bool locked = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
