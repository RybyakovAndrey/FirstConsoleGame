
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;
using System.Collections.Generic;

namespace ConsoleGameEngine.Domain
{
    public class BaseLayer : ILayer
    {
        private List<IGameObject> m_StaticGameObjects;
        private List<IGameObject> m_DynamicGameObjects;

        private string m_nameLayer;
        public BaseLayer(string name)
        {
            m_nameLayer = name;
        }
        public void Start()
        {

        }

        public void Destroy()
        {
            
        }

        public void Update(float deltaTime)
        {

        }

        public void OnEvent(Event e)
        {
            
        }
        public void RemoveGameObject(IGameObject gameObject, bool isStatic)
        {
            if (isStatic)
            {
                m_StaticGameObjects.Remove(gameObject);
                return;
            }
            m_DynamicGameObjects.Remove(gameObject);
        }

        public void AddGameObject(IGameObject gameObject, bool isStatic)
        {
            if (isStatic)
            {
                m_StaticGameObjects.Add(gameObject);
                return;
            }
            m_DynamicGameObjects.Add(gameObject);
        }

    }
}
