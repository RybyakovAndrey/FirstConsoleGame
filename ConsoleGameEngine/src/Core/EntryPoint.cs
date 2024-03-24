#define UNIT_TEST

using System;

namespace ConsoleGameEngine.Core
{
    public static class EntryPoint
    {
        public static Application application { get; set; }
        public static void Initialization()
        {
            Console.WriteLine("Init Engine");
        }

        public static void Destroy()
        {
            application.Destroy();
        }

        public static void Main()
        {
            application.Run();
            Destroy();
        }

    }
}
