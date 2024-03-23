using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain;

namespace ConsoleGameEngine.Core
{
    public interface IApplication
    {
        void Run();

        void OnEvent(Event e);

        void PushLayer(ILayer layer);

        void PopLayer(ILayer layer);
    }
}
