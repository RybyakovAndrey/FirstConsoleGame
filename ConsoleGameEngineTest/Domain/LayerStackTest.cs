using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngineTest.FakeType;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Domain
{
    public class LayerStackTest
    {
        [TestCase]
        public void CheckCalledPushWhenNull()
        {
            var layerStack = new LayerStack();
            layerStack.Push(null);
            Assert.Pass();

            //TODO Check Log
        }

        [TestCase]
        public void CheckCalledPopWhenNull()
        {
            var layerStack = new LayerStack();
            layerStack.Push(null);
            Assert.Pass();

            //TODO Check Log
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
