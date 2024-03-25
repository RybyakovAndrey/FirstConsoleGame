using System;
using System.IO;

namespace ConsoleGameEngine.LogSystem.Core
{
    internal static class LoggerImpl
    {
        private const string BASIC_PATH = @".\Log\";
        private static string m_filePathLog;

        private static bool m_writeToFile = true;
        private static bool m_tested = false;

        internal static bool Tested { get => m_tested; set => m_tested = value; }
        internal static bool WriteToFile { get => m_writeToFile; set => m_writeToFile = value; }

        internal static void SetLogFilePath(string path) => m_filePathLog = path;

        internal static void Init()
        {
            if (m_tested)
            {
                Write("Massage test", LogLevel.Massage);
                Write("Info test", LogLevel.Info);
                Write("Warn test", LogLevel.Warn);
                Write("Error test", LogLevel.Error);
                Write("Critical test", LogLevel.Critical);
                Write("Off test", LogLevel.Off);
            }
        }

        internal static void Write(string massage, LogLevel logLevel)
        {
            if (m_writeToFile)
                WriteToFileLog(massage, logLevel);
        }

        private static void WriteToFileLog(string massage, LogLevel logLevel)
        {
            if (string.IsNullOrEmpty(m_filePathLog))
                m_filePathLog = BASIC_PATH;

            if (!Directory.Exists(m_filePathLog))
                Directory.CreateDirectory(m_filePathLog);

            var time = DateTime.Now;
            var path = $@"log-date({time.Day}_{time.Month}_{time.Year}).txt";

#if (DEBUG || UNITTEST)

            if (logLevel >= LogLevel.MinLevel)
            {
                using (var textWriter = File.AppendText(m_filePathLog + path))
                {
                    textWriter.WriteLine(Patern(massage, logLevel));
                }
            }
#else
            if (logLevel >= LogLevel.Warn)
            {
                using (var textWriter = File.AppendText(m_filePathLog + path))
                {
                    textWriter.WriteLine(Patern(massage, logLevel));
                }
            }
#endif
        }

        private static string Patern(in string msg, LogLevel level)
        {
            var time = DateTime.Now;
            return $"[{time.Hour}:{time.Minute}:{time.Second}] -> ({level.ToString()}) {msg}";
        }

    }
}
