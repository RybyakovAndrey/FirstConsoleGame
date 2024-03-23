using System;

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
                return default(T);

            var value = m_head.Value;
            m_head = m_head.Next;
            return value;
        }
    }

    
}
