using ConsoleGameEngine.Domain.Events;

namespace ConsoleGameEngine.Input
{
    public sealed class KeyPressedEvent : Event
    {
        private KeyCode m_key;

        public KeyPressedEvent(KeyCode key)
        {
            m_key = key;
        }

        public override EventType GetEventType()
        {
            return EventType.PressedKey;
        }

        public KeyCode GetKeyCode()
        {
            return m_key;
        }

        public override string ToString()
        {
            return $"{m_key}";
        }
    }
}
