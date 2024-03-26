using ConsoleGameEngine.Core;
using ConsoleGameEngine.FileSystems;
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
            EntryPoint.Initialization();

            var queue = new ConsoleGameEngine.Domain.Struct.Queue<string>();
            Assert.IsTrue(queue.Dequeue() is null);

            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3; 
            var textLog = FileSystem.ReadFromFile($@".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't dequeue item in Queue: null, don't have element"));
        }

        [TestCase]
        public void EnqueueNullTest()
        {
            EntryPoint.Initialization();

            var queue = new ConsoleGameEngine.Domain.Struct.Queue<string>();
            queue.Enqueue(null);

            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile($@".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't push item in Queue: null"));
        }
    }
}
