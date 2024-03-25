
namespace ConsoleGameEngine.LogSystem
{
    public static class Log
    {
        private static Logger m_coreLogger;
        private static Logger m_clientLogger;
        
        public static Logger CoreLogger => m_coreLogger;
        public static Logger ClientLogger => m_clientLogger;

        internal static void Init()
        {
            m_coreLogger = new Logger("ConsoleEngine");
            m_clientLogger = new Logger("Client");
            Logger.Init(null, true, false);
            m_coreLogger.Logging("Initialized Log System", LogLevel.Info);
        }
    }
}
