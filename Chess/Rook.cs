using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public class Rook : Figure
    {
        public Rook(Color color, Field field)
        {
            Field = field;
            Color = color;
        }

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


        private List<Field> FindPossibleMovesOnEmptyBoard()
        {
            List<Field> possibleMoves = new List<Field>();
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    //Field field = new Field((Horizontal)i, (Vertical)j);
                    if ((Horizontal)i == Field.Horizontal || (Vertical)j==Field.Vertical)
                    {
                        possibleMoves.Add(new Field((Horizontal)i, (Vertical)j));
                    }
                }
            }

            possibleMoves.Remove(possibleMoves.First(x => x.Horizontal == Field.Horizontal && x.Vertical == Field.Vertical));
            //foreach (var item in possibleMoves)
            //{
            //    Console.WriteLine("potential move:{2} R {0} {1}", item.Horizontal, item.Vertical, this.Color);
            //}
            return possibleMoves;
        }
    }
}
