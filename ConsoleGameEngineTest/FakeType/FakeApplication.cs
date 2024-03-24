using ConsoleGameEngine.Core;
using NUnit.Framework;

namespace ConsoleGameEngineTest.FakeType
{
    internal class FakeApplication : Application, IFakeApplication
    {
        public const string INIT = "intiMethod";
        public const string RUN = "runMethod";
        public const string DESTROY = "destroyMethod";

        private int m_timesInit;
        private int m_timesRun;
        private int m_timesDestroy;

        private List<string> m_commads;
        public FakeApplication() 
        {
            m_commads = new List<string>() { INIT };
            m_timesInit = 1;
            m_timesRun = 0;
            m_timesDestroy = 0;
        }

        public override void Destroy()
        {
            m_timesDestroy++;
            m_commads.Add(DESTROY);
            base.Destroy();
        }

        public override void Run()
        {
            m_timesRun++;
            m_commads.Add(RUN);
            base.Run();
        }

        public void CheckCalledTimesDestroy(int times)
        {
            Assert.That(m_timesDestroy, Is.EqualTo(times));
        }

        public void CheckCalledTimesInit(int times)
        {
            Assert.That(m_timesInit, Is.EqualTo(times));
        }

        public void CheckCalledTimesRun(int times)
        {
            Assert.That(m_timesRun, Is.EqualTo(times));
        }

        public void CheckSequenceCalledInitAndRunAndDestroy(string firstCall, string secondCall, string thirdCall)
        {
            Assert.That(m_commads[0], Is.EqualTo(firstCall));
            Assert.That(m_commads[1], Is.EqualTo(secondCall));
            Assert.That(m_commads[2], Is.EqualTo(thirdCall));
        }

    }
}
