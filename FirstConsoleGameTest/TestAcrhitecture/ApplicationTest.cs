using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class ApplicationTest
    {

        [TestCase]
        public void ApplicationTestLyaerCalledSartAfterAddLayer()
        {
            var application = new Application();
            var layer = new IFakeLayer.Base();

            application.AddLayer(layer);
            layer.CheckCalledStartTimes(1);
            
        }

        [TestCase]
        public void ApplicationTestLyaerCalledDestroyAfterRemoveLayer()
        {
            var application = new Application();
            var layer = new IFakeLayer.Base();

            application.RemoveLayer(layer);
            layer.CheckCalledDestroyTimes(1);
        }

        [TestCase]
        public void ApplicationTestCloseTest()
        {
            var application = new Application();

            application.Initialization();
            application.Close();
            application.Run();

            Assert.Pass();
        }

        [TestCase]
        public void ApplicationTestRemoveAndAddLayer()
        {
            var application = new Application();
            application.Initialization();
            
            var layer1 = new IFakeLayer.Base();
            var layer2 = new IFakeLayer.Base();
            var layer3 = new IFakeLayer.Base();

            application.AddLayer(layer1);
            application.AddLayer(layer2);
            application.AddLayer(layer3);

            application.RemoveLayer(layer3);

            layer3.CheckCalledDestroyTimes(1);
            layer2.CheckCalledDestroyTimes(0);
            layer1.CheckCalledDestroyTimes(0);

            application.RemoveLayer(layer2);

            layer3.CheckCalledDestroyTimes(1);
            layer2.CheckCalledDestroyTimes(1);
            layer1.CheckCalledDestroyTimes(0);
        }

        [TestCase]
        public void ApplicationTestGetLayerTest()
        {
            var application = new Application();
            application.Initialization();

            var layer1 = new IFakeLayer.Base(1);
            var layer2 = new IFakeLayer.Base(2);
            var layer3 = new IFakeLayer.Base(3);

            application.AddLayer(layer1);
            application.AddLayer(layer2);
            application.AddLayer(layer3);

            Assert.IsTrue(layer1 == application.GetLayer(1));
            Assert.IsTrue(layer2 == application.GetLayer(2));
            Assert.IsTrue(layer3 == application.GetLayer(3));
        }

        [TestCase]
        public void ApplicationTestGetNullLayerTest()
        {
            var application = new Application();
            application.Initialization();

            Assert.IsTrue(application.GetLayer(1) is null);
            
        }

        [TestCase]
        public void ApplicationTestGetNull2LayerTest()
        {
            var application = new Application();
            application.Initialization();

            var layer1 = new IFakeLayer.Base(1);
            var layer2 = new IFakeLayer.Base(2);

            application.AddLayer(layer1);
            application.AddLayer(layer2);

            Assert.IsTrue(application.GetLayer(3) is null);
            Assert.IsTrue(layer1 == application.GetLayer(1));
           
        }

    }


    internal interface IFakeLayer : ILayer
    {
        void CheckCalledStartTimes(int times);
        void CheckCalledDestroyTimes(int times);
        internal class Base() : IFakeLayer
        {
            public int Index { get; }
            private int m_timesStartCalled = 0;
            private int m_timesDestroyCalled = 0;

            public Base(int index) : this()
            {
                Index = index;
            }

            public void CheckCalledDestroyTimes(int times)
            {
                Assert.That(m_timesDestroyCalled, Is.EqualTo(times));
            }

            public void CheckCalledStartTimes(int times)
            {
                Assert.That(m_timesStartCalled, Is.EqualTo(times));
            }

            public void Destroy()
            {
                m_timesDestroyCalled++;
            }

            public void Start()
            {
                m_timesStartCalled++;
            }

            public void Update(float deltaTime)
            {
                
            }
        }
    }
}
