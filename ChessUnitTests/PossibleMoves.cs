using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chess;
using System.Linq;

namespace ChessUnitTests
{
    [TestClass]
    public class PossibleMoves
    {
        [TestMethod]
        public void PossibleMoves1()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.H, Vertical.Five));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical.Eight));
            Rook blackRook = new Rook(game, Color.Black, new Field(Horizontal.H, Vertical.Eight));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackKing });


            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.H, Vertical.Seven));
            desiredFields.Add(new Field(Horizontal.H, Vertical.Six));
            desiredFields.Add(new Field(Horizontal.H, Vertical.Five));

            desiredFields.Add(new Field(Horizontal.G, Vertical.Eight));
            desiredFields.Add(new Field(Horizontal.F, Vertical.Eight));

            AssertFields(desiredFields, blackRook.PossibleMoves);
        }

        [TestMethod]
        public void PossibleMoves2()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.G, Vertical.Six));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.H, Vertical.Eight));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.G, Vertical.One));

            game.AddFigures(new List<IFigure>() { whiteKing, whiteRook, blackKing });


            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.G, Vertical.Eight));

            AssertFields(desiredFields, blackKing.PossibleMoves);
        }

        private void AssertFields(List<Field> desired, List<Field> actual)
        {
            CollectionAssert.AreEqual(
                actual.Select(x => x.Horizontal).ToList(),
                desired.Select(x => x.Horizontal).ToList());

            CollectionAssert.AreEqual(
                actual.Select(x => x.Vertical).ToList(),
                desired.Select(x => x.Vertical).ToList());
        }
    }
}
