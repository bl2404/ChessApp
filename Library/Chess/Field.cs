using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace Chess
{
    public class Field
    {
        public Field(Horizontal horizontal, Vertical vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }

        public bool IsFieldTheSame(Field field)
        {
            if (field.Horizontal == this.Horizontal && field.Vertical == Vertical)
                return true;
            else
                return false;
        }

        public Horizontal Horizontal { get; private set; }
        public Vertical Vertical { get; private set; }
    }
}
