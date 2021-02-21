using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Move
    {
        public Move(IFigure figure, Field field)
        {
            Figure = figure;
            Field = field;
        }

        public bool IsMoveTheSame(Move move)
        {
            if (move.Field.IsFieldTheSame(this.Field))
            {
                if (move.Figure.Field.IsFieldTheSame(this.Figure.Field))
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public IFigure Figure { get; private set; }
        public Field Field { get; private set; }
    }
}
