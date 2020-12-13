using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Board
    {
        public List<Field> Fields { get; private set; }
        public Board()
        {
            Fields = new List<Field>();
            foreach (Horizontal x in Enum.GetValues(typeof(Horizontal)))
            {
                foreach (Vertical y in Enum.GetValues(typeof(Vertical)))
                {
                    Fields.Add(new Field((Horizontal)x, (Vertical)y));
                }
            }
        }
    }
}
