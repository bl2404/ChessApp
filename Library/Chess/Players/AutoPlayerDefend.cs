﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Players
{
    public class AutoPlayerDefend : AutoPlayer
    {
        public AutoPlayerDefend(Game game) : base(game) { }

        public override void InitiateMove()
        {
            Move();
        }

        protected override void Move()
        {
            int random = new Random().Next(PossibleMoves.Count - 1);
            var move = PossibleMoves[random];
            Console.WriteLine("computer: K " + move.Field.Horizontal + move.Field.Vertical);
            move.Figure.Move(move.Field);
        }
    }
}