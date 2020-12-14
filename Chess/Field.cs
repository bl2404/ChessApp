﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess
{
    public class Field
    {
        public Field(Horizontal horizontal, Vertical vertical)
        {
            Horizontal = horizontal;
            Vertical = vertical;
        }
        public Horizontal Horizontal { get; private set; }
        public Vertical Vertical { get; private set; }
    }
}
