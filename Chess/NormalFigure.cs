using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public abstract class NormalFigure : Figure
    {
        public NormalFigure(Game game, Color color, Field field) : base(game, color, field) { }

        protected override List<Field> FindPossibleMoves()
        {
            List<Field> possibleFields = FindVisibleFields();
            List<Field> attackedFields = FindAttackedFields();

            foreach (Field field in attackedFields)
            {
                if (possibleFields.Any(f => f.IsFieldTheSame(field))) ;
                possibleFields.Remove(possibleFields.First(f => f.IsFieldTheSame(field)));
            }

            return possibleFields;
        }
    }
}
