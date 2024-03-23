using ConsoleGameEngine.Input.Factories;
using System;

namespace ConsoleGameEngine.Input.Vendor.CsharpConsole
{
    public class CsharpConsoleMapperKeyCodeFactory : MapperKeyCodeFactory
    {
        private readonly ConsoleKey m_key;

        public CsharpConsoleMapperKeyCodeFactory(ConsoleKey key)
        {
            m_key = key;
        }

        public override IMapperKeyCode GetMapperKeyCode()
        {
            return new CsharpConsoleMapperKeyCode(m_key);
        }
    }
}
