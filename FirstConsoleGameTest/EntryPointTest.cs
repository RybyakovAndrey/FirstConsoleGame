using FirstConsoleGame;
using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest
{
    public class EntryPointTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [TestCase]
        public void EntryPointTestInit()
        {
            var entryPoint  = new IFakeEntryPoint.Base();
            Program.EntryPoint = entryPoint;
            Program.Main();
            entryPoint.CheckCalledTimes(1);
            
        }
    }

    internal interface IFakeEntryPoint : IEntryPoint
    {
        void CheckCalledTimes(int times);

        internal class Base() : IFakeEntryPoint
        {
            private int m_times = 0;
            public void CheckCalledTimes(int times)
            {
                Assert.That(m_times, Is.EqualTo(times));
            }

            public void Initialization()
            {
                m_times++;
            }
        }
    }
}