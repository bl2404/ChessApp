using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Chess
{
    public class King : Figure
    {
        public King(Game game,Color color, Field field): base(game,color,field){}

        protected override List<Field> FindVisibleFields()
        {
            List<Field> possibleMoves = new List<Field>();
            for (int i = 1; i <= 8; i++)
            {
                if (Math.Abs((int)Field.Horizontal - i) == 1 || Math.Abs((int)Field.Horizontal - i) == 0)
                {
                    for (int j = 1; j <= 8; j++)
                    {
                        if (Math.Abs((int)Field.Vertical - j) == 1 || Math.Abs((int)Field.Vertical - j) == 0)
                        {
                            possibleMoves.Add(new Field((Horizontal)i, (Vertical)j));
                        }
                    }
                }
            }
            possibleMoves.Remove(possibleMoves.First(x=>x.Horizontal==Field.Horizontal && x.Vertical==Field.Vertical));
            //foreach (var item in possibleMoves)
            //{
            //    Console.WriteLine("potential move:{2} K {0} {1}", item.Horizontal, item.Vertical, this.Color);
            //}
            return possibleMoves;
        }

        protected override List<Field> FindAttackedFields()
        {
            List<Field> attackedFields = new List<Field>();
            foreach (var figure in Game.Figures.Where(x => x.Color != this.Color))
            {
                foreach (var field in figure.VisibleFields)
                    attackedFields.Add(field);
            }
            return attackedFields;
        }
    }
}
