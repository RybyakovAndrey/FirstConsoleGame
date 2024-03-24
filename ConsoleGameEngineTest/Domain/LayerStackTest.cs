using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.Domain.Struct;
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
        }

        [TestCase]
        public void CheckCalledPopWhenNull()
        {
            var layerStack = new LayerStack();
            layerStack.Push(null);
            Assert.Pass();
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


        private void CheckStackInHaveLayer(LayerStack layerStack, ILayer[] layers)
        {
            var index = 0;
            foreach (var layer in layerStack)
            {
                Assert.IsTrue(((IFakeLayer)layer).CheckEquals((IFakeLayer)layers[index++]));
            }
        }

    }


    internal interface IFakeLayer : ILayer
    {
        int Index { get; }
        void CheckCalledStart(int times);
        void CheckCalledDestroy(int times);
        bool CheckEquals(IFakeLayer layer);
        internal class Base() : IFakeLayer
        {
            public int Index { get; }
            private int m_startTimes;
            private int m_destroyTimes;
             
            internal Base(int index) : this() 
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
                return Index == layer.Index;
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
