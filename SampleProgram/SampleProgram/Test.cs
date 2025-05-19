using ChessLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProgram
{
    // Abstract base class for all game pieces 
    public abstract class GamePiece
    {
        public Position CurrentPosition { get; set; }

        public GamePiece(Position position)
        {
            CurrentPosition = position;
        }

        public abstract List<Position> GetValidMoves(GameBoard board);
    }

    // Represents a Knight piece 
    public class Knight : GamePiece
    {
        public Knight(Position position) : base(position) { }

        public override List<Position> GetValidMoves(GameBoard board)
        {
            var knight = new KnightMove();
            var validMoves = new List<Position>();
            var knightMoves = knight.ValidMovesFor(CurrentPosition);
            foreach (var move in knightMoves)
            {
                var newPos = new Position(move.X, move.Y);
                if (board.IsValidPosition(newPos) && !board.IsPositionOccupied(newPos))
                {
                    validMoves.Add(newPos);
                }
            }
            return validMoves;
        }
    }

    // Represents a Bishop piece 
    public class Bishop : GamePiece
    {
        public Bishop(Position position) : base(position) { }

        public override List<Position> GetValidMoves(GameBoard board)
        {
            var validMoves = new List<Position>();
            int[] dx = { 1, 1, -1, -1 };
            int[] dy = { 1, -1, 1, -1 };

            for (int i = 0; i < 4; i++)
            {
                for (int step = 1; step < 8; step++)
                {
                    int newX = CurrentPosition.X + dx[i] * step;
                    int newY = CurrentPosition.Y + dy[i] * step;
                    var newPos = new Position(newX, newY);
                    if (board.IsValidPosition(newPos) && !board.IsPositionOccupied(newPos))
                    {
                        validMoves.Add(newPos);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return validMoves;
        }
    }

    // Represents a Queen piece 
    public class Queen : GamePiece
    {
        public Queen(Position position) : base(position) { }

        public override List<Position> GetValidMoves(GameBoard board)
        {
            var validMoves = new List<Position>();
            int[][] directions = new int[][]
            {
                new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 },
                new int[] { 1, 1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { -1, -1 }
            };

            foreach (var dir in directions)
            {
                for (int step = 1; step < 8; step++)
                {
                    int newX = CurrentPosition.X + dir[0] * step;
                    int newY = CurrentPosition.Y + dir[1] * step;
                    var newPos = new Position(newX, newY);
                    if (board.IsValidPosition(newPos) && !board.IsPositionOccupied(newPos))
                    {
                        validMoves.Add(newPos);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return validMoves;
        }
    }

    // Represents the 8x8 game board 
    public class GameBoard
    {
        private List<GamePiece> pieces;

        public GameBoard(List<GamePiece> initialPieces)
        {
            pieces = initialPieces;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X > 1 && position.X < 8 && position.Y > 1 && position.Y < 8;
        }

        public bool IsPositionOccupied(Position position)
        {
            return pieces.Any(piece => piece.CurrentPosition.Equals(position));
        }

        public void MoveRandomPiece()
        {
            var random = new Random();
            var availablePieces = pieces.Where(piece => piece.GetValidMoves(this).Count > 0).ToList();
            if (availablePieces.Count == 0) return;

            var selectedPiece = availablePieces[random.Next(availablePieces.Count)];
            var validMoves = selectedPiece.GetValidMoves(this);
            var selectedMove = validMoves[random.Next(validMoves.Count)];
            selectedPiece.CurrentPosition = selectedMove;
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var pieces = new List<GamePiece>
    //        {
    //            new Knight(new Position(0, 0)),
    //            new Bishop(new Position(2, 2)),
    //            new Queen(new Position(4, 4))
    //        };

    //        var board = new GameBoard(pieces);
    //        for (int i = 0; i < 10; i++)
    //        {
    //            board.MoveRandomPiece();
    //        }
    //    }
    //}
}