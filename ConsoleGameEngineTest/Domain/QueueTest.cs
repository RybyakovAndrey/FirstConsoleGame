using NUnit.Framework;

namespace ConsoleGameEngineTest.Domain
{
    public class QueueTest
    {
        [TestCase]
        public void QueueEmptyTest()
        {
            var queue = new ConsoleGameEngine.Domain.Struct.Queue<string>();
            Assert.That(queue.Dequeue(), Is.EqualTo(default(string)));
        }

        [TestCase]
        public void QueueIntTest()
        {
            var queue = new ConsoleGameEngine.Domain.Struct.Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.That(queue.Dequeue(), Is.EqualTo(1));
            Assert.That(queue.Dequeue(), Is.EqualTo(2));
            Assert.That(queue.Dequeue(), Is.EqualTo(3));
        }

        [TestCase]
        public void QueueStringTest()
        {
            var queue = new ConsoleGameEngine.Domain.Struct.Queue<string>();
            queue.Enqueue("abs");
            queue.Enqueue("isp");
            queue.Enqueue("data");
            
            Assert.That(queue.Dequeue(), Is.EqualTo("abs"));
            Assert.That(queue.Dequeue(), Is.EqualTo("isp"));
            Assert.That(queue.Dequeue(), Is.EqualTo("data"));
        }

        [TestCase]
        public void DequeueNullTest()
        {
            var queue = new ConsoleGameEngine.Domain.Struct.Queue<string>();
            Assert.IsTrue(queue.Dequeue() is null);

            //TODO Check log
        }
    }
}
