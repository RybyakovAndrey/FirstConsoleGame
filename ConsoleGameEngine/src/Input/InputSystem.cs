﻿using ConsoleGameEngine.Domain.Events;
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
        private Thread m_thread;
        public InputSystem(OnPressedEvent callback)
        {
            m_onPressedKey = callback;
            m_currentKey = ConsoleKey.NoName;

            ThreadStart threadStart = new ThreadStart(UpdateInputSystem);
            m_thread = new Thread(threadStart);
            m_thread.Start();

            Console.WriteLine("Init InputSystem");
        }

        public void Destroy()
        {
            m_thread.Abort();
            Console.WriteLine("Distroy InputSystem");
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
