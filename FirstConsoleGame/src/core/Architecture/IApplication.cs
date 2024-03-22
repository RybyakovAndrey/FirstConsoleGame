
namespace FirstConsoleGame.core.Architecture
{
    public interface IApplication
    {

        void Initialization();

        void Run();

        void AddLayer(ILayer layer);

        void RemoveLayer(ILayer layer);
    }
}
