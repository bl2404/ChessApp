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

            King whiteKing = new King(game, Color.White, new Field(Horizontal.H, Vertical._5));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical._8));
            Rook blackRook = new Rook(game, Color.Black, new Field(Horizontal.H, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, blackRook, blackKing });


            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.H, Vertical._7));
            desiredFields.Add(new Field(Horizontal.H, Vertical._6));
            desiredFields.Add(new Field(Horizontal.H, Vertical._5));

            desiredFields.Add(new Field(Horizontal.G, Vertical._8));
            desiredFields.Add(new Field(Horizontal.F, Vertical._8));

            AssertFields(desiredFields, blackRook.PossibleMoves);
        }

        [TestMethod]
        public void PossibleMoves2()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.G, Vertical._6));
            King blackKing = new King(game, Color.Black, new Field(Horizontal.H, Vertical._8));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.G, Vertical._1));

            game.AddFigures(new List<IFigure>() { whiteKing, whiteRook, blackKing });


            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.G, Vertical._8));

            AssertFields(desiredFields, blackKing.PossibleMoves);
        }

        [TestMethod]
        public void PossibleMoves3()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.C, Vertical._6));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.D, Vertical._7));

            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, whiteRook, blackKing });


            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.F, Vertical._8));
            AssertFields(desiredFields, blackKing.PossibleMoves);
        }

        [TestMethod]
        public void PossibleMoves4()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.E, Vertical._6));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.A, Vertical._8));

            King blackKing = new King(game, Color.Black, new Field(Horizontal.E, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, whiteRook, blackKing });


            Assert.AreEqual(0, blackKing.PossibleMoves.Count);
        }

        [TestMethod]
        public void PossibleMoves5()
        {
            Game game = new Game();

            King whiteKing = new King(game, Color.White, new Field(Horizontal.G, Vertical._7));
            Rook whiteRook = new Rook(game, Color.White, new Field(Horizontal.E, Vertical._8));

            Rook blackRook = new Rook(game, Color.Black, new Field(Horizontal.G, Vertical._8));

            game.AddFigures(new List<IFigure>() { whiteKing, whiteRook, blackRook });

            List<Field> desiredFields = new List<Field>();
            desiredFields.Add(new Field(Horizontal.E, Vertical._8));
            desiredFields.Add(new Field(Horizontal.F, Vertical._8));
            desiredFields.Add(new Field(Horizontal.H, Vertical._8));
            desiredFields.Add(new Field(Horizontal.G, Vertical._7));
            AssertFields(desiredFields, blackRook.PossibleMoves);
        }

        private void AssertFields(List<Field> desired, List<Field> actual)
        {
            CollectionAssert.AreEquivalent(
                actual.Select(x => x.Horizontal).ToList(),
                desired.Select(x => x.Horizontal).ToList());

            CollectionAssert.AreEquivalent(
                actual.Select(x => x.Vertical).ToList(),
                desired.Select(x => x.Vertical).ToList());
        }
    }
}
