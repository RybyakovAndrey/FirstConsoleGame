
namespace ConsoleGameEngine.Domain
{
    internal class QueueItem<T>
    {
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }

        public QueueItem(T value, QueueItem<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
