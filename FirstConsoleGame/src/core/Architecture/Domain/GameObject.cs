
namespace FirstConsoleGame.core.Architecture.Domain
{
    public class GameObject : IGameObject
    {
        public void AddComponent(IBaseComponent component)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Destroy()
        {
            
        }

        public T GetComponent<T>() where T : IBaseComponent
        {
            throw new System.NotImplementedException();
        }

        public virtual void OnCreate()
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            
        }
    }
}
