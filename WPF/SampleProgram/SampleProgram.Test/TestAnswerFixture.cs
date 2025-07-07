using ChessLib;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SampleProgram.Test
{
    [TestClass]
    public class TestAnswerFixture
    {
        // TODO: add additional tests for your answer
        [TestMethod]
        public void TestKnightMoveFromInsideBoard()
        {
            Position pos = new Position(2, 5);

            GamePiece gp = new Knight(pos);
            List<GamePiece> gpList = new List<GamePiece>();
            gpList.Add(gp);

            List<Position> moves = gp.GetValidMoves(new GameBoard(gpList));

            Assert.IsNotNull(moves);
            Assert.AreEqual(4, moves.Count);

            var possibles = new[] {
                new Position(3,7),
                new Position(3,3),
                new Position(4,6),
                new Position(4,4)};

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }

        [TestMethod]
        public void TestBishopMoveFromInsideBoard()
        {
            Position pos = new Position(2, 3);

            GamePiece gp = new Bishop(pos);
            List<GamePiece> gpList = new List<GamePiece>();
            gpList.Add(gp);

            List<Position> moves = gp.GetValidMoves(new GameBoard(gpList));

            Assert.IsNotNull(moves);
            Assert.AreEqual(5, moves.Count);

            foreach (var move in moves)
            {
                switch (Math.Abs(move.X - pos.X))
                {
                    case 1:
                        Assert.AreEqual(1, Math.Abs(move.Y - pos.Y));
                        break;
                    case 2:
                        Assert.AreEqual(2, Math.Abs(move.Y - pos.Y));
                        break;
                    case 3:
                        Assert.AreEqual(3, Math.Abs(move.Y - pos.Y));
                        break;
                    case 4:
                        Assert.AreEqual(4, Math.Abs(move.Y - pos.Y));
                        break;
                    case 5:
                        Assert.AreEqual(5, Math.Abs(move.Y - pos.Y));
                        break;
                    default:
                        Assert.Fail();
                        break;
                }
            }
        }

        [TestMethod]
        /// Queen Diagonal Move
        public void TestQueenDiagonalMoveFromInsideBoard()
        {
            Position pos = new Position(1,1);

            GamePiece gp = new Queen(pos);
            List<GamePiece> gpList = new List<GamePiece>();
            gpList.Add(gp);

            List<Position> moves = gp.GetValidMoves(new GameBoard(gpList));

            Assert.IsNotNull(moves);
            Assert.AreEqual(6, moves.Count);

            var possibles = new[] {
                new Position(2, 2),
                new Position(3, 3),
                new Position(4, 4),
                new Position(5, 5),
                new Position(6, 6),
                new Position(7, 7)};

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }

        [TestMethod]
        /// Queen Horizontal Move
        public void TestQueenHorizontalMoveFromInsideBoard()
        {
            Position pos = new Position(1, 2);

            GamePiece gp = new Queen(pos);
            List<GamePiece> gpList = new List<GamePiece>();
            gpList.Add(gp);

            List<Position> moves = gp.GetValidMoves(new GameBoard(gpList));

            Assert.IsNotNull(moves);
            Assert.AreEqual(11, moves.Count);

            var possibles = new[] {
                new Position(2,2),
                new Position(3,2),
                new Position(4,2),
                new Position(5,2),
                new Position(6,2),
                new Position(2,3),
                new Position(3,4),
                new Position(4,5),
                new Position(5,6),
                new Position(6,7)};

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }

        [TestMethod]
        /// Queen Vertical Move
        public void TestQueenVerticalMoveFromInsideBoard()
        {
            Position pos = new Position(2,1);

            GamePiece gp = new Queen(pos);
            List<GamePiece> gpList = new List<GamePiece>();
            gpList.Add(gp);

            List<Position> moves = gp.GetValidMoves(new GameBoard(gpList));

            Assert.IsNotNull(moves);
            Assert.AreEqual(11, moves.Count);

            var possibles = new[] {
                new Position(2,2),
                new Position(2,3),
                new Position(2,4),
                new Position(2,5),
                new Position(2,6),
                new Position(2,7),
                new Position(3,2),
                new Position(4,3),
                new Position(5,4),
                new Position(6,5),
                new Position(7,6)};

            foreach (var possible in possibles)
            {
                Assert.IsTrue(moves.Contains(possible));
            }
        }
    }
}
