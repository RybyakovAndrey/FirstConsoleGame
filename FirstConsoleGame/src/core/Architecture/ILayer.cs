
namespace FirstConsoleGame.core.Architecture
{
    public interface ILayer
    {
        int Index { get; }
        void Start();

        void Destroy();

        void Update(float deltaTime);
    }
}
