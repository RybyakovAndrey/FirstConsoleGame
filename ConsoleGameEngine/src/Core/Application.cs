using System;
using ConsoleGameEngine.Domain;

namespace ConsoleGameEngine.Core
{
    public abstract class Application : IApplication
    {

        public Application()
        {
            Console.WriteLine("Create application engine");
        }

        public void OnEvent(Event e)
        {
            
        }

        public void PopLayer(ILayer layer)
        {
            
        }

        public void PushLayer(ILayer layer)
        {
           
        }

        public void Run()
        {
            Console.ReadKey();
        }
    }
}
