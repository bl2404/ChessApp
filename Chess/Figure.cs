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
        }
        public Field Field { get; protected set; }

        public Color Color { get; protected set; }

        public List<Field> PossibleMoves => FindPossibleMoves();

        public List<Field> VisibleFields => FindVisibleFields();

        public Game Game { get; protected set; }

        public void Move(Field field)
        {
            Field = field;
        }

        protected abstract List<Field> FindVisibleFields();

        private List<Field> FindPossibleMoves()
        {
            List<Field> possibleFields = FindVisibleFields();
            List<Field> attackedFields = FindAttackedFields();

            foreach (Field field in attackedFields)
            {
                if (possibleFields.Any(x => x.Horizontal == field.Horizontal && x.Vertical == field.Vertical))
                    possibleFields.Remove(possibleFields.First(x => x.Horizontal == field.Horizontal && x.Vertical == field.Vertical));
            }
            foreach (var item in possibleFields)
            {
                Console.WriteLine("possible: " + item.Horizontal + " " + item.Vertical);
            }
            return possibleFields;

        }

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
    }
}
