
namespace ConsoleGameEngineTest.FakeType
{
    internal interface IFakeApplication
    {
        void CheckCalledTimesInit(int times);
        void CheckCalledTimesDestroy(int times);
        void CheckCalledTimesRun(int times);
        void CheckSequenceCalledInitAndRunAndDestroy(string firstCall, string secondCall, string thirdCall);
    }
}
