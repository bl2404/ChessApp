using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public class King : Figure
    {
        public King(Game game, Color color, Field field) : base(game, color, field) { }

        protected override List<Field> FindVisibleFields()
        {
            List<Field> potentialPossibleMoves = new List<Field>();
            for (int i = 1; i <= 8; i++)
            {
                if (Math.Abs((int)Field.Horizontal - i) == 1 || Math.Abs((int)Field.Horizontal - i) == 0)
                {
                    for (int j = 1; j <= 8; j++)
                    {
                        if (Math.Abs((int)Field.Vertical - j) == 1 || Math.Abs((int)Field.Vertical - j) == 0)
                        {
                            potentialPossibleMoves.Add(new Field((Horizontal)i, (Vertical)j));
                        }
                    }
                }
            }
            potentialPossibleMoves.Remove(potentialPossibleMoves.First(x => x.Horizontal == Field.Horizontal && x.Vertical == Field.Vertical));
            return potentialPossibleMoves;
        }

        protected override List<Field> FindAttackedFields()
        {
            List<Field> attackedFields = new List<Field>();
            foreach (var figure in Game.Figures.Where(x => x.Color != this.Color))
            {
                foreach (var field in ((Figure)figure).VisibleFields)
                    attackedFields.Add(field);
            }
            return attackedFields;
        }

        private List<Field> RemoveRoendgenAttackedFields(List<Field> potentialPossibleMoves)
        {
            List<Field> possibleMoves = new List<Field>();
            var initialField = Field;
            foreach (var field in potentialPossibleMoves)
            {
                Field = field;
                if (!FindAttackedFields().Any(f => f.IsFieldTheSame(field)))
                    possibleMoves.Add(field);
            }
            Field = initialField;
            return possibleMoves;
        }

        protected override List<Field> FindPossibleMoves()
        {
            List<Field> possibleFields = FindVisibleFields();
            List<Field> attackedFields = FindAttackedFields();

            foreach (Field field in attackedFields)
            {
                if (possibleFields.Any(f => f.IsFieldTheSame(field)))
                    possibleFields.Remove(possibleFields.First(f => f.IsFieldTheSame(field)));
            }

            return RemoveRoendgenAttackedFields(possibleFields);
        }
    }
}
