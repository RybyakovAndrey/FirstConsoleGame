using ConsoleGameEngine.FileSystems;
using ConsoleGameEngine.LogSystem;
using System;

namespace ConsoleGameEngine.Core
{
    public static class EntryPoint
    {
        public static Application application { get; set; }
        public static void Initialization()
        {
            Log.Init();
            InitFileSystem();
            
            Log.CoreLogger.Logging("Init ConsoleGameEngine", LogLevel.Info);
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

        private static void InitFileSystem()
        {
            if (FileSystem.Init())
                Log.CoreLogger.Logging("Init FileSystem", LogLevel.Info);
            else
            {
                Log.CoreLogger.Logging("Error initializaition FileSystem", LogLevel.Error);
                throw new MethodAccessException("didn't work out initialization FileSystem");
            }
        }

    }
}
