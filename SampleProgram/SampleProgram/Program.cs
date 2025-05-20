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
            game.Setup();
            game.Play(15);

            var complexGame = new ComplexGame();
            complexGame.Setup();
            complexGame.Play(15);

            Console.WriteLine("Press any key ...");
            Console.ReadKey();
        }
    }
}