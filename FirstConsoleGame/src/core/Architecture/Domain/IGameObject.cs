
namespace FirstConsoleGame.core.Architecture.Domain
{
    public interface IGameObject
    {
        T GetComponent<T>() where T : class, IBaseComponent;
        void OnCreate();
        void Update(float deltaTime);
        void Destroy();
    }

}
