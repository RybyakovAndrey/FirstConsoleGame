using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.Graphics;
using System.Collections.Generic;

namespace ConsoleGameEngine.Domain
{
    public abstract class BaseLayer : ILayer
    {
        private List<IGameObject> m_StaticGameObjects;
        private List<IGameObject> m_DynamicGameObjects;

        private string m_nameLayer;
        public BaseLayer(string name)
        {
            m_nameLayer = name;
        }

        public abstract void Start();
        public abstract void Destroy();

        public virtual void Update(float deltaTime)
        {
            foreach (var gameObject in m_DynamicGameObjects)
            {
                gameObject.Update(deltaTime);
                RenderGameObject(gameObject);
            }

            foreach (var gameObject in m_StaticGameObjects)
            {
                RenderGameObject(gameObject);
            }
        }

        public virtual void OnEvent(Event e)
        {
            foreach (var gameObject in m_DynamicGameObjects)
            {
                gameObject.OnEvent(e);
            }
        }

        public void RemoveGameObject(IGameObject gameObject, bool isStatic)
        {
            gameObject.Destroy();
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
                gameObject.Start();
                return;
            }
            m_DynamicGameObjects.Add(gameObject);
            gameObject.Start();
        }

        public override string ToString()
        {
            return m_nameLayer;
        }

        private void RenderGameObject(IGameObject gameObject)
        {
            if (gameObject.GetComponent<RenderComponent>() is RenderComponent render)
                render.DrawGameObject();
        }

    }
}
