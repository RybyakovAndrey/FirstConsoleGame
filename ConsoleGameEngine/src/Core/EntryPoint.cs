using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Core
{
    public static class EntryPoint
    {
        public static Application application { get; set; }
        public static void Initialization()
        {
            Log.Init();
            Log.CoreLogger.Logging("Init Engine", LogLevel.Info);
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
