using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class LayerTest
    {

        [TestCase]
        public void LayerTestStartAfterAdd()
        {
            IApplication application = new Application();
            var layer = new IFakeLayer.Base();

            application.AddLayer(layer);
            layer.CheckCalledStartTimes(1);
            
        }

        [TestCase]
        public void LayerTestDestroyAfterRemove()
        {
            IApplication application = new Application();
            var layer = new IFakeLayer.Base();

            application.RemoveLayer(layer);
            layer.CheckCalledDestroyTimes(1);
        }

    }


    internal interface IFakeLayer : ILayer
    {
        void CheckCalledStartTimes(int times);
        void CheckCalledDestroyTimes(int times);
        internal class Base() : IFakeLayer
        {
            private int m_timesStartCalled = 0;
            private int m_timesDestroyCalled = 0;

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
        }
    }
}
