using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;

namespace ConsoleGameEngine.Domain
{
    public interface ILayer
    {
        void Start();
        void Destroy();
        void AddGameObject(IGameObject gameObject, bool isStatic);
        void RemoveGameObject(IGameObject gameObject, bool isStatic);
        void Update(float deltaTime);
        void OnEvent(Event e);
    }
}
