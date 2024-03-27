using NUnit.Framework;
using ConsoleGameEngine.Graphics;
using ConsoleGameEngineTest.FakeType;
using ConsoleGameEngine.FileSystems;
using ConsoleGameEngine.Core;

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
            EntryPoint.Initialization();

            var gameObject = new FakeGameObject();
            gameObject.AddComponent(null);
            
            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't add a component in gameObject of the type: null"));
        }

        [TestCase]
        public void CheckCalledRemoveComponentWhenNull()
        {
            EntryPoint.Initialization();
            var gameObject = new FakeGameObject();
            gameObject.RemoveComponent(null);
                   
            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't delete the component in gameObject of the type: null"));
        }

        [TestCase]
        public void CheckCalledRemoveComponentWhenDontHaveInGameObject()
        {
            EntryPoint.Initialization();
            var gameObject = new FakeGameObject("TestObject");
            var fakeComponent = new FakeComponent();
            gameObject.RemoveComponent(fakeComponent);

            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't delete the component in TestObject of the type: FakeComponent"));
        }

        [TestCase]
        public void CheckCalledGetComponentWhenDontHaveComponentInGameObject()
        {
            EntryPoint.Initialization();
            var gameObject = new FakeGameObject();
            gameObject.GetComponent<FakeComponent>();
            
            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error don't have component in gameObject of the type: FakeComponent"));
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
}
