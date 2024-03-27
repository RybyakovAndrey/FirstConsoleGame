using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.LogSystem;
using System.Collections.Generic;

namespace ConsoleGameEngine.Domain.GameObject
{
    public abstract class GameObject : IGameObject
    {
        public string Name { get; }
        private List<BaseComponent> m_components;
        public GameObject(string name = "gameObject")
        {
            Name = name;
            m_components = new List<BaseComponent>();
        }

        public abstract void Start();

        public virtual void Destroy()
        {
            foreach(var component in m_components)
                component.Destroy();
            m_components.Clear();
        }

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
            Log.CoreLogger.Logging($"Error don't have component in {Name} of the type: {typeof(T).Name}", LogLevel.Warn);
            return null;
        }

        public void RemoveComponent(BaseComponent component)
        {
            if (component is null || !m_components.Contains(component))
            {
                Log.CoreLogger.Logging($"Error can't delete the component in {Name} of the type: {component?.GetType().Name ?? "null"}", LogLevel.Warn);
                return;
            }
            component.Destroy();
            m_components.Remove(component);
        }

        public void AddComponent(BaseComponent component)
        {
            if (component is null)
            {
                Log.CoreLogger.Logging($"Error can't add a component in {Name} of the type: null", LogLevel.Warn);
                return;
            }

            component.GameObject = this;
            m_components.Add(component);
            component.Start();
        }

    }
}
