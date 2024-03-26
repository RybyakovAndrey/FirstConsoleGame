using ConsoleGameEngine.LogSystem;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleGameEngine.FileSystems
{
    public static class FileSystem
    {

        internal static bool Init()
        {

            return true;
        }

        public static void CreateDirectory(string pathDirectory)
        {
            Directory.CreateDirectory(pathDirectory);
        }

        public static bool IsHaveDirectory(string pathDirectory)
        {
            return Directory.Exists(pathDirectory);
        }

        public static void WriteToFile(string massage, string filePath)
        {
            try
            {
                using (var textWriter = File.AppendText(filePath))
                {
                    textWriter.WriteLine(massage);
                }
            }
            catch (Exception ex)
            {
                Log.CoreLogger.Logging($"Error can't write to file: {filePath}. Exception {ex}", LogLevel.Warn);
            }
        }


        public static List<string> ReadFromFile(string filePath)
         {
            return ReadFromFile(filePath, 0, 0);
        }

        public static List<string> ReadFromFile(string filePath, int removeStart, int removeEnd)
        {
            try
            {
#if UNITTEST
                if (!File.Exists(filePath))
                {
                    Log.CoreLogger.Logging($"Error can't read file: {filePath}. ", LogLevel.Warn);
                    return null;
                }
#endif
                using (var textReader = File.OpenText(filePath))
                {
                    var result = new List<string>();
                    var textLine = textReader.ReadLine();
                    while (textLine != null)
                    {
                        result.Add(textLine.Remove(removeStart, removeEnd));
                        textLine = textReader.ReadLine();
                    }
                    textReader.Close();
                    textReader.Dispose();
                    return result;
                }
            }
            catch
            {
                Log.CoreLogger.Logging($"Error can't read file: {filePath}. ", LogLevel.Warn);
                return null;
            }
        }

     

    }
}
