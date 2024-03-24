using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using System.Collections.Generic;

namespace ConsoleGameEngine.Domain.GameObject
{
    public abstract class GameObject : IGameObject
    {

        private List<BaseComponent> m_components;
        public GameObject()
        {
            m_components = new List<BaseComponent>();
        }

        public abstract void Start();

        public abstract void Destroy();

        public virtual void Update(float deltaTime)
        {
            foreach (var component in m_components)
            {
                component.Update(deltaTime);
            }
        }

        public virtual void OnEvent(Event e)
        {
            foreach (var component in m_components)
            {
                component.OnEvent(e);
            }
        }

        public T GetComponent<T>() where T : BaseComponent
        {
            foreach (var component in m_components)
            {
                if(component is T resutl)
                    return resutl;
            }
            return null;
        }

        public void RemoveComponent(BaseComponent component)
        {
            if (component is null)
                return;

            component.Destroy();
            m_components.Remove(component);
        }

        public void AddComponent(BaseComponent component)
        {
            if (component is null)
                return;

            component.GameObject = this;
            m_components.Add(component);
            component.Start();
        }

    }
}
