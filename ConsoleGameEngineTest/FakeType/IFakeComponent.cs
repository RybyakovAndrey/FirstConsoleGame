
namespace ConsoleGameEngineTest.FakeType
{
    internal interface IFakeComponent
    {
        void CheckCalledStartTimes(int times);
        void CheckCalledDestroyTimes(int times);
    }
}
