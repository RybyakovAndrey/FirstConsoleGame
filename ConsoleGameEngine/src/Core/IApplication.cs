﻿using ConsoleGameEngine.Domain;

namespace ConsoleGameEngine.Core
{
    public interface IApplication
    {
        void Inintialization();
        void Run();

        void OnEvent(Event e);

        void PushLayer(ILayer layer);

        void PopLayer(ILayer layer);
    }
}
