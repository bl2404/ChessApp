using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public class Rook : Figure
    {
        public Rook(Game game, Color color, Field field) : base(game, color, field) { }
        protected override List<Field> FindVisibleFields()
        {
            List<Field> possibleMoves = new List<Field>();
            Horizontal horizontal = Field.Horizontal;
            Vertical vertical = Field.Vertical;
            
            //add veritcal increasing
            for (int i = (int)vertical+1; i <= 8; i++)
            {
                Field field = new Field(horizontal, (Vertical)i);
                if (IsFieldOccupatedBySameColor(field))
                    break;
                else
                {
                    possibleMoves.Add(field);
                    if (IsFieldOccupated(field))
                        break;
                }           
            }

            //add vertical decreasing
            for (int i = (int)vertical - 1; i >= 1; i--)
            {
                Field field = new Field(horizontal, (Vertical)i);
                if (IsFieldOccupatedBySameColor(field))
                    break;
                else
                {
                    possibleMoves.Add(field);
                    if (IsFieldOccupated(field))
                        break;
                }
            }

            //add horizontal increasing
            for (int i = (int)horizontal + 1; i <= 8; i++)
            {
                Field field = new Field((Horizontal)i, vertical);
                if (IsFieldOccupatedBySameColor(field))
                    break;
                else
                {
                    possibleMoves.Add(field);
                    if (IsFieldOccupated(field))
                        break;
                }
            }


            //add horizontal decreasing
            for (int i = (int)horizontal - 1; i >= 1; i--)
            {
                Field field = new Field((Horizontal)i, vertical);
                if (IsFieldOccupatedBySameColor(field))
                    break;
                else
                {
                    possibleMoves.Add(field);
                    if (IsFieldOccupated(field))
                        break;
                }
            }
            return possibleMoves;
        }

        protected override List<Field> FindAttackedFields()
        {
            return new List<Field>();
        }
    }
}
