using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.Domain;
using NUnit.Framework;
using ConsoleGameEngine.Domain.Events;

namespace ConsoleGameEngineTest.FakeType
{
    internal interface IFakeLayer : ILayer
    {
        int Index { get; }
        void CheckCalledStart(int times);
        void CheckCalledDestroy(int times);
        bool CheckEquals(IFakeLayer layer);
        internal class Base : IFakeLayer
        {
            public int Index { get; }
            private int m_startTimes;
            private int m_destroyTimes;

            internal Base() : this(1) { }
            internal Base(int index)
            {
                Index = index;

                m_startTimes = 0;
                m_destroyTimes = 0;
            }
            public void AddGameObject(IGameObject gameObject, bool isStatic)
            {

            }

            public void CheckCalledDestroy(int times)
            {
                Assert.That(m_destroyTimes, Is.EqualTo(times));
            }

            public void CheckCalledStart(int times)
            {
                Assert.That(m_startTimes, Is.EqualTo(times));
            }

            public bool CheckEquals(IFakeLayer layer)
            {
                return Index.Equals(layer.Index);
            }

            public void Destroy()
            {
                m_destroyTimes++;
            }

            public void OnEvent(Event e)
            {

            }

            public void RemoveGameObject(IGameObject gameObject, bool isStatic)
            {

            }

            public void Start()
            {
                m_startTimes++;
            }

            public void Update(float deltaTime)
            {

            }
        }
    }
}
