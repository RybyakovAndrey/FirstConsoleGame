using System;
using System.Threading;
using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Input;


namespace ConsoleGameEngine.Core
{
    public abstract class Application : IApplication
    {
        protected InputSystem m_inputSystem;
        private bool m_isRunning;
        public Application()
        {
            m_isRunning = true;
            m_inputSystem = new InputSystem(OnEvent);

            Console.WriteLine("Create application engine");
        }

        public void Destroy()
        {
            m_inputSystem.Destroy();
            Console.WriteLine("Destroy application");
        }

        public void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyEvent && keyEvent.GetKeyCode() == KeyCode.Escape)
                Close();

            Console.WriteLine(e.ToString());
        }

        public void PopLayer(ILayer layer)
        {
            
        }

        public void PushLayer(ILayer layer)
        {
           
        }

        public void Run()
        {
            while (m_isRunning)
            {
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
