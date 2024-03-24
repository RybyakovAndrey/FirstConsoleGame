using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using NUnit.Framework;

namespace ConsoleGameEngineTest.FakeType
{
    internal class FakeComponent : BaseComponent, IFakeComponent
    {
        private int m_timesStart;
        private int m_timesDestroy;

        public FakeComponent()
        {
            m_timesStart = 0;
            m_timesDestroy = 0;
        }
        public void CheckCalledDestroyTimes(int times)
        {
            Assert.That(m_timesDestroy, Is.EqualTo(times));
        }

        public void CheckCalledStartTimes(int times)
        {
            Assert.That(m_timesStart, Is.EqualTo(times));
        }

        public override void Destroy()
        {
            m_timesDestroy++;
        }

        public override void OnEvent(Event e)
        {

        }
        public override void Start()
        {
            m_timesStart++;
        }

        public override void Update(float daltaTime)
        {

        }
    }
}
