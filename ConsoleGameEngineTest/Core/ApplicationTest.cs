using ConsoleGameEngine.Core;
using ConsoleGameEngineTest.Domain;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Core
{
    public class ApplicationTest
    {

        [TestCase]
        public void CheckCalledPushLayerWhenNull()
        {
            var app = new FakeApplication();
            app.PushLayer(null);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledPopLayerWhenNull()
        {
            var app = new FakeApplication();
            app.PopLayer(null);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledPopLayerWhenDontHaveLayerInStack()
        {
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            app.PopLayer(fakeLayer);
            Assert.Pass();
        }

        [TestCase]
        public void CheckCalledLayerStartWhenAddLayer()
        {
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            fakeLayer.CheckCalledStart(0);
            app.PushLayer(fakeLayer);
            fakeLayer.CheckCalledStart(1);
        }

        [TestCase]
        public void CheckCalledLayerDestroyWhenPopLayer()
        {
            var app = new FakeApplication();
            var fakeLayer = new IFakeLayer.Base();
            app.PushLayer(fakeLayer);
            fakeLayer.CheckCalledDestroy(0);
            app.PopLayer(fakeLayer);
            fakeLayer.CheckCalledDestroy(1);
        }

    }

    internal class FakeApplication : Application
    {


    }

}
