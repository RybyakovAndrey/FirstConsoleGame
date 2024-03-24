using ConsoleGameEngine.Domain.Events;

namespace ConsoleGameEngine.Domain.Component
{
    public interface IComponent
    {

        void Start();
        void Destroy();

        void Update(float daltaTime);

        void OnEvent(Event e);
        void Enable();
        void Disable();


    }
}
