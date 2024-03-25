using System;
using System.Threading;
using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Input;
using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Core
{
    public abstract class Application : IApplication
    {
        private InputSystem m_inputSystem;
        private bool m_isRunning;
        private LayerStack m_layerStack;
        public Application()
        {
            m_isRunning = true;
            m_layerStack = new LayerStack();

            // ----- Init System --------
            m_inputSystem = InputSystem.GetInputSystem(OnEvent);

            Log.CoreLogger.Logging("Create application engine", LogLevel.Info);
        }

        public virtual void Destroy()
        {
            m_inputSystem.Destroy();

            foreach (var layer in m_layerStack)
                layer.Destroy();
            m_layerStack.Clear();

            Log.CoreLogger.Logging("Destroy application", LogLevel.Info);
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

            layer?.Destroy();
            m_layerStack.Pop(layer);
        }

        public void PushLayer(ILayer layer)
        {
            
            m_layerStack.Push(layer);
            layer?.Start();
        }

        public virtual void Run()
        {
            while (m_isRunning)
            {

                foreach (var layer in m_layerStack)
                    layer.Update(0);

                Console.WriteLine("Update");
                Thread.Sleep(10);
            }
        }

        private void Close()
        {
            m_isRunning = false;
        }
    }

}
