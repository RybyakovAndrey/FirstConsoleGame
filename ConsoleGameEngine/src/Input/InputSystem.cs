using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Input.Factories;
using ConsoleGameEngine.Input.Vendor.CsharpConsole;
using System;
using System.Threading;

namespace ConsoleGameEngine.Input
{
    public delegate void OnPressedEvent(Event e);
    public class InputSystem
    {
        private OnPressedEvent m_onPressedKey;
        private ConsoleKey m_currentKey;
        public InputSystem(OnPressedEvent callback)
        {
            m_onPressedKey = callback;
            m_currentKey = ConsoleKey.NoName;

            ThreadStart threadStart = new ThreadStart(UpdateInputSystem);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Console.WriteLine("Init InputSystem");
        }

        private void UpdateInputSystem()
        {
            while (true)
            {
                m_currentKey = Console.ReadKey().Key;

                var mapperKeyCode = GetMapperFactory().GetMapperKeyCode();
                var keyPressed = new KeyPressedEvent(mapperKeyCode.GetKeyCode());

                m_onPressedKey?.Invoke(keyPressed);
                Thread.Sleep(4);
            }
        }

        private MapperKeyCodeFactory GetMapperFactory()
        {
            return new CsharpConsoleMapperKeyCodeFactory(m_currentKey);
        }


    }
}
