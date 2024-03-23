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
        public Application()
        {
            m_inputSystem = new InputSystem(OnEvent);
            Console.WriteLine("Create application engine");
        }

        public void OnEvent(Event e)
        {
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
            while (true)
            {
                Console.WriteLine("Update");
                Thread.Sleep(500);
            }
        }
    }
}
