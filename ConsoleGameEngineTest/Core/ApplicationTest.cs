using ConsoleGameEngine.Core;
using ConsoleGameEngineTest.FakeType;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Core
{
    public class ApplicationTest
    {

        [TestCase]
        public void CheckCalledPushLayerWhenNull()
        {
            EntryPoint.Initialization();
            var app = new FakeApplication();
            app.PushLayer(null);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledPopLayerWhenNull()
        {
            EntryPoint.Initialization();
            var app = new FakeApplication();
            app.PopLayer(null);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledPopLayerWhenDontHaveLayerInStack()
        {
            EntryPoint.Initialization();
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            app.PopLayer(fakeLayer);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledLayerStartWhenAddLayer()
        {
            EntryPoint.Initialization();
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            fakeLayer.CheckCalledStart(0);
            app.PushLayer(fakeLayer);
            fakeLayer.CheckCalledStart(1);
        }

        [TestCase]
        public void CheckCalledLayerDestroyWhenPopLayer()
        {
            EntryPoint.Initialization();
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            app.PushLayer(fakeLayer);
            fakeLayer.CheckCalledDestroy(0);
            app.PopLayer(fakeLayer);
            fakeLayer.CheckCalledDestroy(1);
        }

    }


}
