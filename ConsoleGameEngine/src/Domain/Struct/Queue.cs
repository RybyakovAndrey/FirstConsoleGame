using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Domain.Struct
{
    public class Queue<T>
    {
        private QueueItem<T> m_head;
        private QueueItem<T> m_tail;
        public Queue()
        {

        }

        public void Enqueue(T value)
        {

            if (value as object is null)
            {
                Log.CoreLogger.Logging("Error can't push item in Queue: null", LogLevel.Warn);
                return;
            }

            if (m_head == null)
            {
                m_head = new QueueItem<T>(value, null);
                m_tail = m_head;
            }
            else
            {
                m_tail.Next = new QueueItem<T>(value, null);
                m_tail = m_tail.Next;
            }
            
        }

        public T Dequeue()
        {
            if (m_head == null)
            {
                Log.CoreLogger.Logging("Error can't dequeue item in Queue: null, don't have element", LogLevel.Warn);
                return default(T);
            }
            var value = m_head.Value;
            m_head = m_head.Next;
            return value;
        }
    }

    
}
