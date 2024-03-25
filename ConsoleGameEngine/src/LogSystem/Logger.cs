using ConsoleGameEngine.LogSystem.Core;

namespace ConsoleGameEngine.LogSystem
{
    public class Logger : ILogger
    {
        private string m_name;

        internal Logger(string name)
        {
            m_name = name;
        }

        internal static void Init(string logFilePath, bool writeToFile, bool tested)
        {
            LoggerImpl.SetLogFilePath(logFilePath);
            LoggerImpl.WriteToFile = writeToFile;
            LoggerImpl.Tested = tested;
            LoggerImpl.Init();

        }

        public void Logging(string massage, LogLevel logLevel)
        {

            LoggerImpl.Write($" {m_name}: {massage}", logLevel);
        }
    }
}
