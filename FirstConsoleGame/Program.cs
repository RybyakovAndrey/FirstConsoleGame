using FirstConsoleGame.core.Architecture;

namespace FirstConsoleGame
{
    public class Program
    {
        public static IEntryPoint EntryPoint { get; set; }

        public static void Main()
        {
            EntryPoint.Initialization();
        }
    }
}
