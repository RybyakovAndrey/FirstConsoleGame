
namespace FirstConsoleGame.core.Architecture
{
    public interface IApplication
    {

        void Initialization();

        void Run();

        void AddLayer(ILayer layer);

        ILayer GetLayer(int index);

        void RemoveLayer(ILayer layer);

        void Close();
    }
}
