using System;
using System.Collections.Generic;
using System.Text;
using Chess;
using Chess.Players;

namespace ChessUnitTests
{
    class MockBlackPlayer : Player
    {
        public MockBlackPlayer(Game game) : base(game) { }
        public override Color Color => Color.Black;

        public override void InitiateMove()
        {
        }
    }
}
