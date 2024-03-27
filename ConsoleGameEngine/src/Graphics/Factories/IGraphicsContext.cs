using ConsoleGameEngine.Domain.Struct;

namespace ConsoleGameEngine.Graphics.Factories
{
    public interface IGraphicsContext
    {
        
        void BeginDraw();
        void Draw(Texture texture, Vector2 bufferPostion);
        void EndDraw();
    }
}
