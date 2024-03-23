using ConsoleGameEngine.Core;

namespace FirstConsoleGame
{
    public class Program
    {

        public static void Main()
        {
            EntryPoint.Initialization();
            EntryPoint.application = new Game();
            EntryPoint.Main();
        }
    }
}
