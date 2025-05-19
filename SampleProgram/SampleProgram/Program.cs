using ChessLib;
using System;
using System.Collections.Generic;

namespace SampleProgram
{
    public static class Program
    {
        public static void Main()
        {
            var game = new Game();
            // var game = new ComplexGame();

            game.Setup();
            game.Play(15);



            //var pieces = new List<GamePiece>
            //        {
            //            new Knight(new Position(2, 2)),
            //            new Bishop(new Position(3, 3)),
            //            new Queen(new Position(4, 4))
            //        };

            //var board = new GameBoard(pieces);
            //for (int i = 0; i < 10; i++)
            //{
            //    board.MoveRandomPiece();
            //}

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}