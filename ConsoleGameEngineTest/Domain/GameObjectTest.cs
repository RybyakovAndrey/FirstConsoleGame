using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;
using NUnit.Framework;
using ConsoleGameEngine.Graphics;

namespace ConsoleGameEngineTest.Domain
{
    public class GameObjectTest
    {

        [TestCase]
        public void CheckCalledStartWhenAddComponent()
        {
            var gameObject = new FakeGameObject();
            var fakeComponent = new FakeComponent();
            fakeComponent.CheckCalledStartTimes(0);
            gameObject.AddComponent(fakeComponent);
            fakeComponent.CheckCalledStartTimes(1);

        }

        [TestCase]
        public void CheckCalledDestroyWhenRemoveComponent()
        {
            var gameObject = new FakeGameObject();
            var fakeComponent = new FakeComponent();
            gameObject.AddComponent(fakeComponent);
            fakeComponent.CheckCalledDestroyTimes(0);
            gameObject.RemoveComponent(fakeComponent);
            fakeComponent.CheckCalledDestroyTimes(1);

        }

        [TestCase]
        public void CheckCalledAddComponentWhenNull()
        {
            var gameObject = new FakeGameObject();
            gameObject.AddComponent(null);
            Assert.Pass();

            //TODO Check Log
        }

        [TestCase]
        public void CheckCalledRemoveComponentWhenNull()
        {
            var gameObject = new FakeGameObject();
            gameObject.RemoveComponent(null);
            Assert.Pass();

            //TODO Check Log
        }

        [TestCase]
        public void CheckCalledGetComponentWhenDontHaveComponentInGameObject()
        {
            var gameObject = new FakeGameObject();
            gameObject.GetComponent<FakeComponent>();
            Assert.Pass();

            // TODO Check Log
        }

        [TestCase]
        public void CheckCalledGetComponent()
        {
            var gameObject = new FakeGameObject();
            var fakeComponent = new FakeComponent();
            gameObject.AddComponent(fakeComponent);
            var actualComponent = gameObject.GetComponent<FakeComponent>();
            Assert.IsTrue(actualComponent is FakeComponent);

        }

        [TestCase]
        public void CheckCalledGetComponent2()
        {
            var gameObject = new FakeGameObject();
            var fakeComponent = new FakeComponent();
            var fakeComponent2 = new FakeComponent();
            gameObject.AddComponent(fakeComponent);
            gameObject.AddComponent(fakeComponent2);
            var actualComponent = gameObject.GetComponent<RenderComponent>();
            Assert.IsFalse(actualComponent is RenderComponent);

        }

        [TestCase]
        public void CheckCalledGetComponent3()
        {
            var gameObject = new FakeGameObject();
            var fakeComponent = new FakeComponent();
            var fakeComponent2 = new RenderComponent();
            gameObject.AddComponent(fakeComponent);
            gameObject.AddComponent(fakeComponent2);
            var actualComponent = gameObject.GetComponent<RenderComponent>();
            Assert.IsTrue(actualComponent is RenderComponent);
            gameObject.RemoveComponent(fakeComponent);
            actualComponent = gameObject.GetComponent<RenderComponent>();
            Assert.IsTrue(actualComponent is RenderComponent);
            gameObject.RemoveComponent(fakeComponent2);
            gameObject.AddComponent(fakeComponent);
            actualComponent = gameObject.GetComponent<RenderComponent>();
            Assert.IsFalse(actualComponent is RenderComponent);
        }

    }

    internal class FakeGameObject : GameObject
    {
        public override void Destroy()
        {
            
        }

        public override void Start()
        {
            
        }
    }

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

    internal interface IFakeComponent
    {
        void CheckCalledStartTimes(int times);
        void CheckCalledDestroyTimes(int times);
    }
}
