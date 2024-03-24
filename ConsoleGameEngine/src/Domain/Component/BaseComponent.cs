using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;

namespace ConsoleGameEngine.Domain.Component
{
    public abstract class BaseComponent : IComponent
    {
        public IGameObject GameObject { get; set; }
        private bool m_activeComponent;
        public BaseComponent()
        {
            m_activeComponent = true;
        }

        public abstract void Destroy();
        public abstract void Start();
        public abstract void Update(float daltaTime);
        public abstract void OnEvent(Event e);
        public virtual void Disable()
        {
            m_activeComponent = false;
        }

        public void Enable()
        {
            m_activeComponent = true;
        }

        public bool IsActiveComponent() => m_activeComponent;

        
    }
}
