﻿using System;
using System.Threading;
using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Input;


namespace ConsoleGameEngine.Core
{
    public abstract class Application : IApplication
    {
        protected InputSystem m_inputSystem;
        private bool m_isRunning;
        private LayerStack m_layerStack;
        public Application()
        {
            m_isRunning = true;
            m_layerStack = new LayerStack();

            // ----- Init System --------
            m_inputSystem = new InputSystem(OnEvent);

            Console.WriteLine("Create application engine");
        }

        public virtual void Destroy()
        {
            m_inputSystem.Destroy();
            Console.WriteLine("Destroy application");
        }

        public void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyEvent && keyEvent.GetKeyCode() == KeyCode.Escape)
                Close();

            foreach (var layer in m_layerStack)
                layer.OnEvent(e);

            Console.WriteLine(e.ToString());
        }

        public void PopLayer(ILayer layer)
        {
            layer.Destroy();
            m_layerStack.Pop(layer);
        }

        public void PushLayer(ILayer layer)
        {
            m_layerStack.Push(layer);
            layer.Start();
        }

        public void Run()
        {
            while (m_isRunning)
            {

                foreach (var layer in m_layerStack)
                    layer.Update(0);

                Console.WriteLine("Update");
                Thread.Sleep(500);
            }
        }

        private void Close()
        {
            m_isRunning = false;
        }
    }
}
