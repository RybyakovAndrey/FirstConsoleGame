using ConsoleGameEngine.Core;
using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.FileSystems;
using ConsoleGameEngineTest.FakeType;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Domain
{
    public class LayerStackTest
    {
        [TestCase]
        public void CheckCalledPushWhenNull()
        {
            EntryPoint.Initialization();

            var layerStack = new LayerStack();
            layerStack.Push(null);
            
            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't push layer in LayerStack: null"));
            
        }

        [TestCase]
        public void CheckCalledPopWhenNull()
        {
            EntryPoint.Initialization();

            var layerStack = new LayerStack();
            layerStack.Pop(null);

            var time = DateTime.Now;
            var countTime = (time.Hour / 10 > 0 ? 1 : 0) + (time.Minute / 10 > 0 ? 1 : 0) + (time.Second / 10 > 0 ? 1 : 0) + 3;
            var textLog = FileSystem.ReadFromFile(@$".\Log\log-date({time.Day}_{time.Month}_{time.Year}).txt", 0, 8 + countTime);
            Assert.IsFalse(textLog is null);
            Assert.IsTrue(textLog.Contains("(Warn)  ConsoleEngine: Error can't pop layer in LayerStack: null"));

        }

        [TestCase]
        public void CheckCalledPushLayerInLayerStack()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new IFakeLayer.Base(1);
            var fakeLayer2 = new IFakeLayer.Base(2);
            var fakeLayer3 = new IFakeLayer.Base(3);
            var layers = new ILayer[] { fakeLayer1, fakeLayer2, fakeLayer3 };
            layerStack.Push(fakeLayer1);
            layerStack.Push(fakeLayer2);
            layerStack.Push(fakeLayer3);
            CheckStackInHaveLayer(layerStack, layers);
        }

        [TestCase]
        public void CheckCalledPopLayerInLayerStack()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new IFakeLayer.Base(1);
            var fakeLayer2 = new IFakeLayer.Base(2);
            var fakeLayer3 = new IFakeLayer.Base(3);
            var layers = new ILayer[] { fakeLayer1, fakeLayer3 };
            layerStack.Push(fakeLayer1);
            layerStack.Push(fakeLayer2);
            layerStack.Push(fakeLayer3);
            layerStack.Pop(fakeLayer2);
            CheckStackInHaveLayer(layerStack, layers);
        }
        [TestCase]
        public void CheckCalledPopLayerInLayerStack2()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new IFakeLayer.Base(1);
            var fakeLayer2 = new IFakeLayer.Base(2);
            var fakeLayer3 = new IFakeLayer.Base(3);
            var layers = new ILayer[] { fakeLayer3 };
            layerStack.Push(fakeLayer1);
            layerStack.Push(fakeLayer2);
            layerStack.Push(fakeLayer3);
            layerStack.Pop(fakeLayer2);
            layerStack.Pop(fakeLayer1);
            layerStack.Pop(fakeLayer1);
            CheckStackInHaveLayer(layerStack, layers);
        }

        [TestCase]
        public void CheckCalledPopLayerInLayerStack3()
        {
            var layerStack = new LayerStack();
            var fakeLayer1 = new IFakeLayer.Base(1);
            var fakeLayer2 = new IFakeLayer.Base(2);
            var fakeLayer3 = new IFakeLayer.Base(3);
            var layers = new ILayer[] {  };
            layerStack.Push(fakeLayer1);
            layerStack.Push(fakeLayer2);
            layerStack.Push(fakeLayer3);
            layerStack.Pop(fakeLayer2);
            layerStack.Pop(fakeLayer1);
            layerStack.Pop(fakeLayer1);
            layerStack.Pop(fakeLayer3);
            CheckStackInHaveLayer(layerStack, layers);
        }

        private void CheckStackInHaveLayer(LayerStack layerStack, ILayer[] layers)
        {
            var index = 0;
            foreach (var layer in layerStack)
            {
                Assert.IsTrue(((IFakeLayer)layer).CheckEquals((IFakeLayer)layers[index++]));
            }

            Assert.Pass();
        }

    }
}
