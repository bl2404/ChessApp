using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using Chess.Players;
using System.Linq;

namespace ChessUnitTests
{
    [TestClass]
    public class CheckForCheck
    {
        [TestMethod]
        public void CheckTest1()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.E, Vertical._5));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical._8));
            Rook blackRook = new Rook(game, Color.White, new Field(Horizontal.H, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackKing });

            game.WhitePlayer = new MockWhitePlayer(game);
            game.BlackPlayer = new MockBlackPlayer(game);
            game.CurrentPlayer = game.BlackPlayer;

            Assert.AreEqual(game.Check, true);
        }

        [TestMethod]
        public void CheckTest2()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.G, Vertical._8));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical._8));
            Rook blackRook = new Rook(game, Color.White, new Field(Horizontal.H, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackKing });

            game.WhitePlayer = new MockWhitePlayer(game);
            game.BlackPlayer = new MockBlackPlayer(game);
            game.CurrentPlayer = game.BlackPlayer;

            Assert.AreEqual(game.Check, false);
        }

        [TestMethod]
        public void CheckTest3()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.F, Vertical._6));
            Rook blackRook = new Rook(game, Color.White, new Field(Horizontal.G, Vertical._7));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.H, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackKing });

            game.WhitePlayer = new MockWhitePlayer(game);
            game.BlackPlayer = new MockBlackPlayer(game);
            game.CurrentPlayer = game.BlackPlayer;

            Assert.AreEqual(game.Check, false);
        }
    }
}
