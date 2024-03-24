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
                case ConsoleKey.Z:
                    return KeyCode.Z;
                case ConsoleKey.X:
                    return KeyCode.X;
                case ConsoleKey.C:
                    return KeyCode.C;
                case ConsoleKey.V:
                    return KeyCode.V;
                case ConsoleKey.R:
                    return KeyCode.R;
                case ConsoleKey.F:
                    return KeyCode.F;
                case ConsoleKey.T:
                    return KeyCode.T;
                case ConsoleKey.G:
                    return KeyCode.G;
                case ConsoleKey.Y:
                    return KeyCode.Y;
                case ConsoleKey.H:
                    return KeyCode.H;
                case ConsoleKey.U:
                    return KeyCode.U;
                case ConsoleKey.J:
                    return KeyCode.J;
                case ConsoleKey.I:
                    return KeyCode.I;
                case ConsoleKey.K:
                    return KeyCode.K;
                case ConsoleKey.O:
                    return KeyCode.O;
                case ConsoleKey.L:
                    return KeyCode.L;
                case ConsoleKey.P:
                    return KeyCode.P;
                case ConsoleKey.N:
                    return KeyCode.N;
                case ConsoleKey.M:
                    return KeyCode.M;
                case ConsoleKey.Spacebar:
                    return KeyCode.SPACE;
                default:
                    return KeyCode.None;
            }
        }
    }
}
