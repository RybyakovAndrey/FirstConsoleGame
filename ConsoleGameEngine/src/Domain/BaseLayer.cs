﻿using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.LogSystem;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleGameEngine.Domain
{
    public abstract class BaseLayer : ILayer
    {
        private List<IGameObject> m_staticGameObjects;
        private List<IGameObject> m_dynamicGameObjects;

        private string m_nameLayer;
        public BaseLayer(string name)
        {
            m_nameLayer = name;
            m_staticGameObjects = new List<IGameObject>();
            m_dynamicGameObjects = new List<IGameObject>();
        }

        public abstract void Start();
        public virtual void Destroy()
        {
            foreach (var gameObject in m_staticGameObjects)
                gameObject.Destroy();
            m_staticGameObjects.Clear();

            foreach(var gameObject in m_dynamicGameObjects)
                gameObject.Destroy();
            m_dynamicGameObjects.Clear();

            Log.CoreLogger.Logging("DestroyLayer", LogLevel.Info);
        }

        public virtual void Update(float deltaTime)
        {
            foreach (var gameObject in m_dynamicGameObjects)
            {
                gameObject.Update(deltaTime);
            }

        }

        public virtual void OnEvent(Event e)
        {
            foreach (var gameObject in m_dynamicGameObjects)
            {
                gameObject.OnEvent(e);
            }
        }

        public void RemoveGameObject(IGameObject gameObject, bool isStatic)
        {
            gameObject.Destroy();
            if (isStatic)
            {
                m_staticGameObjects.Remove(gameObject);
                return;
            }
            m_dynamicGameObjects.Remove(gameObject);
        }

        public void AddGameObject(IGameObject gameObject, bool isStatic)
        {  
            if (isStatic)
            {
                m_staticGameObjects.Add(gameObject);
                gameObject.Start();
                return;
            }
            m_dynamicGameObjects.Add(gameObject);
            gameObject.Start();
        }

        public override string ToString()
        {
            return m_nameLayer;
        }

        public IEnumerable<IGameObject> GetObjects()
        {
            return m_dynamicGameObjects.Union(m_staticGameObjects); 
        }
    }
}
