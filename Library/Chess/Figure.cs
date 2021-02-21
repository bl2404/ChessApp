using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        public Field Field { get; protected set; }

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
    }
}
