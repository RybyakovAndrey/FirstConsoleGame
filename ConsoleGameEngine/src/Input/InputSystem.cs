using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Input.Factories;
using ConsoleGameEngine.Input.Vendor.CsharpConsole;
using ConsoleGameEngine.LogSystem;
using System;
using System.Threading;

namespace ConsoleGameEngine.Input
{
    public delegate void OnPressedEvent(Event e);
    public sealed class InputSystem
    {
        private static InputSystem m_instance;

        private OnPressedEvent m_onPressedKey;
        private ConsoleKey m_currentKey;
        private Thread m_thread;
        private InputSystem(OnPressedEvent callback)
        {
            m_onPressedKey = callback;
            m_currentKey = ConsoleKey.NoName;

            ThreadStart threadStart = new ThreadStart(UpdateInputSystem);
            m_thread = new Thread(threadStart);

#if (DEBUG || RELEASE)
            m_thread.Start();
#endif
            Log.CoreLogger.Logging("Init InputSystem", LogLevel.Info);
        }

        public static InputSystem GetInputSystem(OnPressedEvent callback)
        {
            if(m_instance is null)
                m_instance = new InputSystem(callback);

            return m_instance;
        }

        public void Destroy()
        {

#if (DEBUG || RELEASE) 
            m_thread.Abort();
#endif
            Log.CoreLogger.Logging("Distroy InputSystem", LogLevel.Info);
        }

        private void UpdateInputSystem()
        {
            while (true)
            {
                m_currentKey = Console.ReadKey(true).Key;

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
