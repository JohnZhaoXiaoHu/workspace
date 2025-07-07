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
                new int[] { 1, 1 }, new int[] { 1, -1 }, new int[] { -1, 1 }, new int[] { -1, -1 },
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

    // Represents a Game board
    public class GameBoard
    {
        private readonly List<GamePiece> _Pieces;

        public GameBoard(List<GamePiece> pieces)
        {
            _Pieces = pieces;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X > 1 && position.X < 8 && position.Y > 1 && position.Y < 8;
        }

        public bool IsPositionOccupied(Position position)
        {
            return _Pieces.Any(piece => piece.CurrentPosition.Equals(position));
        }

        public void RandomMovePiece()
        {
            var random = new Random();
            var availablePieces = _Pieces.Where(piece => piece.GetValidMoves(this).Count > 0).ToList();
            if (availablePieces.Count == 0) return;

            var selectedPiece = availablePieces[random.Next(availablePieces.Count)];
            var validMoves = selectedPiece.GetValidMoves(this);
            var selectedMove = validMoves[random.Next(validMoves.Count)];
            selectedPiece.CurrentPosition = selectedMove;
        }
    }

    public class ComplexGame
    {
        private List<GamePiece> pieces;

        public void Setup()
        {
            // TODO: Set up the state of the game here

            pieces = new List<GamePiece>();

            int numKnights = 2;
            int numBishops = 2;
            int numQueens = 1;

            List<Position> availablePositions = new List<Position>();
            for (int x = 1; x <= 8; x++)
            {
                for (int y = 1; y <= 8; y++)
                {
                    availablePositions.Add(new Position(x, y));
                }
            }

            ShuffleList(availablePositions);

            for (int i = 0; i < numKnights && availablePositions.Count > 0; i++)
            {
                Position position = availablePositions[0];
                availablePositions.RemoveAt(0);
                pieces.Add(new Knight(position));
            }

            for (int i = 0; i < numBishops && availablePositions.Count > 0; i++)
            {
                Position position = availablePositions[0];
                availablePositions.RemoveAt(0);
                pieces.Add(new Bishop(position));
            }

            for (int i = 0; i < numQueens && availablePositions.Count > 0; i++)
            {
                Position position = availablePositions[0];
                availablePositions.RemoveAt(0);
                pieces.Add(new Queen(position));
            }
        }

        public void Play(int moves)
        {
            // TODO: Play the game moves here
            GameBoard gb = new GameBoard(pieces);
            for (var move = 1; move <= moves; move++)
            {
                gb.RandomMovePiece();
            }
        }

        private void ShuffleList<T>(List<T> list)
        {
            Random random = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
