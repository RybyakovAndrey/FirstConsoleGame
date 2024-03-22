using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class ApplicationTest
    {

        [TestCase]
        public void ApplicationTestInit()
        {
            var application = new IFakeApplicaion.Base();
            IEntryPoint entrypoint = new EntryPoint(application);
            entrypoint.Initialization();
            application.CheckCalledInitTimes(1);
        }
    }

    internal interface IFakeApplicaion : IApplication
    {
        void CheckCalledInitTimes(int times);
        
        internal class Base() : IFakeApplicaion
        {
            private int m_times = 0;
            public void AddLayer(ILayer layer)
            {
                
            }

            public void CheckCalledInitTimes(int times)
            {
                Assert.That(m_times, Is.EqualTo(times));
            }

            public void Initialization()
            {
                m_times++;
            }

            public void RemoveLayer(ILayer layer)
            {
               
            }

            public void Run()
            {
                
            }
        }
    }

    
}
