using ConsoleGameEngine.Input.Factories;
using System;

namespace ConsoleGameEngine.Input.Vendor.CsharpConsole
{
    public sealed class CsharpConsoleMapperKeyCode : IMapperKeyCode
    {
        private ConsoleKey m_key;
        public CsharpConsoleMapperKeyCode(ConsoleKey key) 
        {
            m_key = key;
        }

        public KeyCode GetKeyCode()
        {
            return MapConsoleKey(m_key);
        }

        private static KeyCode MapConsoleKey(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A:
                    return KeyCode.A;
                case ConsoleKey.B:
                    return KeyCode.B;
                case ConsoleKey.S:
                    return KeyCode.S;
                case ConsoleKey.D:
                    return KeyCode.D;
                case ConsoleKey.E:
                    return KeyCode.E;
                case ConsoleKey.W: 
                    return KeyCode.W;
                case ConsoleKey.Q:
                    return KeyCode.Q;
                case ConsoleKey.Escape:
                    return KeyCode.Escape;
                default:
                    return KeyCode.None;
            }
        }
    }
}
