using FirstConsoleGame;
using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class ProgramTest
    {
       
        [TestCase]
        public void ProgramTestCalledInitEntryPoint()
        {
            var entryPoint = new IFakeEntryPoint.Base();
            Program.EntryPoint = entryPoint;
            Program.Main();
            entryPoint.CheckCalledTimes(1);
        }

        [TestCase]
        public void ProgramTestCalledInitEntryPointIsNullTest()
        {
            Program.EntryPoint = null;
            Assert.Throws<InvalidOperationException>(() => Program.Main(), "Program can't found entryPoint");
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