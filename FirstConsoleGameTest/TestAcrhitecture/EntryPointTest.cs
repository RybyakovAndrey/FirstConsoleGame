using FirstConsoleGame.core.Architecture;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class EntryPointTest
    {
        public const string RUN = "runMethod";
        public const string INIT = "initMethod";

        [TestCase]
        public void EntryPointTestInit()
        {
            var application = new IFakeApplicaion.Base();
            IEntryPoint entryPoint = new EntryPoint(application);
            entryPoint.Initialization();
            application.CheckCalledInitTimes(1);
        }


        [TestCase]
        public void EntryPointTestRun()
        {
            var application = new IFakeApplicaion.Base();
            IEntryPoint entryPoint = new EntryPoint(application);
            entryPoint.Initialization();
            application.CheckCalledRunTimes(1);
        }

        [TestCase]
        public void EntryPointTestCalledInit()
        {
            var application = new IFakeApplicaion.Base();
            IEntryPoint entryPoint = new EntryPoint(application);
            entryPoint.Initialization();
            application.CheckCalledInit(INIT, RUN);
        }

        [TestCase]
        public void EntryPointTakeApplicationIsNull()
        {
            IEntryPoint entryPoint = new EntryPoint(null);
            Assert.Throws<InvalidOperationException>(() => entryPoint.Initialization(), "entryPoint can't found Application");
        }
    }

    internal interface IFakeApplicaion : IApplication
    {
        void CheckCalledInitTimes(int times);

        void CheckCalledRunTimes(int times);

        void CheckCalledInit(string firstCalledMethod, string secondCalledMethod);

        internal class Base() : IFakeApplicaion
        {
            
            private int m_timesInit = 0;
            private int m_timesRun = 0;

            private List<string> m_calledMethod = new List<string>();

            public void AddLayer(ILayer layer)
            {
                
            }

            public void CheckCalledInit(string firstCalledMethod, string secondCalledMethod)
            {
                Assert.That(m_calledMethod.Count, Is.EqualTo(2));
                Assert.That(m_calledMethod[0], Is.EqualTo(firstCalledMethod));
                Assert.That(m_calledMethod[1], Is.EqualTo(secondCalledMethod));
            }

            public void CheckCalledInitTimes(int times)
            {
                Assert.That(m_timesInit, Is.EqualTo(times));
            }

            public void CheckCalledRunTimes(int times)
            {
                Assert.That(m_timesRun, Is.EqualTo(times));
            }

            public void Close()
            {
                
            }

            public void Initialization()
            {
                m_timesInit++;
                m_calledMethod.Add(EntryPointTest.INIT);
            }

            public void RemoveLayer(ILayer layer)
            {
                
            }

            public void Run()
            {
                m_timesRun++;
                m_calledMethod.Add(EntryPointTest.RUN);
            }
        }
    }

    
}
