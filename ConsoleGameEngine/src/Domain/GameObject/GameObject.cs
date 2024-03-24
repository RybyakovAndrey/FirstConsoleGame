using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using System;

namespace ConsoleGameEngine.Domain.GameObject
{
    public abstract class GameObject : IGameObject
    {

        public abstract void Start();

        public abstract void Destroy();

        public virtual void Update(float deltaTime)
        {

        }

        public virtual void OnEvent(Event e)
        {

        }

        public T GetComponent<T>() where T : BaseComponent
        {
            throw new NotImplementedException();
        }

        public void RemoveComponent(BaseComponent component)
        {
            
        }

        public void AddComponent(BaseComponent component)
        {

        }

    }
}
