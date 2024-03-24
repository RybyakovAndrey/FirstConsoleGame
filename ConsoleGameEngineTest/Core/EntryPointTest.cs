﻿using ConsoleGameEngine.Core;
using ConsoleGameEngine.Input;
using ConsoleGameEngineTest.FakeType;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Core
{
    public class EntryPointTest
    {

        [TestCase]
        public void CheckCalledInitTimesTest()
        {
            var app = new FakeApplication();
            EntryPoint.application = app;
            app.OnEvent(new KeyPressedEvent(KeyCode.Escape));
            EntryPoint.Main();
            app.CheckCalledTimesInit(1);
        }

        [TestCase]
        public void CheckCalledRunTimesTest()
        {
            var app = new FakeApplication();
            EntryPoint.application = app;
            app.CheckCalledTimesRun(0);
            app.OnEvent(new KeyPressedEvent(KeyCode.Escape));
            EntryPoint.Main();
            app.CheckCalledTimesRun(1);

        }

        [TestCase]
        public void CheckCalledDestroyTimesTest()
        {
            var app = new FakeApplication();
            EntryPoint.application = app;
            app.CheckCalledTimesDestroy(0);
            app.OnEvent(new KeyPressedEvent(KeyCode.Escape));
            EntryPoint.Main();
            app.CheckCalledTimesDestroy(1);
        }

        [TestCase]
        public void CheckSequenceCalledTest()
        {
            var app = new FakeApplication();
            EntryPoint.application = app;
            app.OnEvent(new KeyPressedEvent(KeyCode.Escape));
            EntryPoint.Main();
            app.CheckSequenceCalledInitAndRunAndDestroy(FakeApplication.INIT, FakeApplication.RUN, FakeApplication.DESTROY);

        }


    }
}
