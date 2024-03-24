using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;

namespace ConsoleGameEngine.Domain.GameObject
{
    public interface IGameObject
    {
        T GetComponent<T>() where T : BaseComponent;
        void AddComponent(BaseComponent component);
        void RemoveComponent(BaseComponent component);
        void Update(float deltaTime);
        void OnEvent(Event e);
        void Start();
        void Destroy();

    }
}
