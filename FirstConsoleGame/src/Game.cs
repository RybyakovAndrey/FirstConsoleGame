using ConsoleGameEngine.Core;
using System;

namespace FirstConsoleGame
{
    public class Game : Application
    {
        public Game()
        {
            Initialization();
            Console.WriteLine("Create Game");
        }

        private void Initialization()
        {
            Console.WriteLine("Init Game");
        }

    }
}
