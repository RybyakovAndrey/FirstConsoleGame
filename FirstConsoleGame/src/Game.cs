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

        public override void Destroy()
        {
            Console.WriteLine("Destroy Game");
            base.Destroy();
        }

        private void Initialization()
        {
            Console.WriteLine("Init Game");
        }

    }
}
