using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Players
{
    public abstract class AutoPlayer: Player
    {
        public AutoPlayer(Game game) : base(game) { }

        public override Color Color => Color.Black;

        protected abstract void Move();
    }
}
