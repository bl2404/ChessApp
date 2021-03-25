using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace Chess
{
    public abstract class Figure : IFigure
    {
        public Figure(Game game, Color color, Field field)
        {
            Game = game;
            Field = field;
            Color = color;
            IFigureMoved += game.OnIFigureMoved;
        }
        //public Field Field { get; protected set; }

        private Field field;

        public Field Field
        {
            get { return field; }
            set 
            { 
                field = value; 
                OnPropertyChanged(nameof(Field)); 
            }
        }


        public Color Color { get; protected set; }

        public List<Field> PossibleMoves => FindPossibleMoves();

        public List<Field> VisibleFields => FindVisibleFields();

        public Game Game { get; protected set; }

        public event IFigure.IFigureMovedEventHandler IFigureMoved;

        public void Move(Field field)
        {
            Field = field;
            OnIFigureMoved();
        }

        protected abstract List<Field> FindVisibleFields();

        protected abstract List<Field> FindPossibleMoves();

        protected abstract List<Field> FindAttackedFields();

        protected bool IsFieldOccupated(Field field)
        {
            if (Game.Figures.Any(f => f.Field.Horizontal == field.Horizontal && f.Field.Vertical == field.Vertical))
                return true;
            else
                return false;
        }

        protected bool IsFieldOccupatedBySameColor(Field field)
        {
            if (Game.Figures.Any(f =>f.Color==Color && f.Field.Horizontal == field.Horizontal && f.Field.Vertical == field.Vertical))
                return true;
            else
                return false;
        }

        public virtual void OnIFigureMoved()
        {
            if (IFigureMoved != null)
                IFigureMoved(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {

            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null && Game.CurrentPlayer==Game.BlackPlayer)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
