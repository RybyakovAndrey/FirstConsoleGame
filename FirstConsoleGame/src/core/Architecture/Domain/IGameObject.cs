
namespace FirstConsoleGame.core.Architecture.Domain
{
    public interface IGameObject
    {
        T GetComponent<T>() where T : IBaseComponent;
        void OnCreate();

        void AddComponent(IBaseComponent component);

        void Update(float deltaTime);
        void Destroy();
    }

}
