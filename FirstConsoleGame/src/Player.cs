using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Graphics;
using ConsoleGameEngine.Input;
using ConsoleGameEngine.LogSystem;
using System;

namespace FirstConsoleGame
{
    internal class Player : BaseComponent
    {
        private int m_direction;

        public override void Start()
        {
            m_direction = 0;
        }
        public override void Destroy()
        {
            Log.ClientLogger.Logging("Destroy Player", LogLevel.Info);
        }

        public override void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyEvent)
            {
                if (keyEvent.GetKeyCode() == KeyCode.W)
                    m_direction = 1;
                else if (keyEvent.GetKeyCode() == KeyCode.S)
                    m_direction = -1;  
            }            
        }

        public override void Update(float daltaTime)
        {
            if (m_direction != 0)
            {
                Console.WriteLine($"Player move: {m_direction}");
                m_direction = 0;
            }
        }
    }
}
