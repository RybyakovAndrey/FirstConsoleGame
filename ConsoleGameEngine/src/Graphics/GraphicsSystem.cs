using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Graphics.Factories;
using ConsoleGameEngine.Graphics.Vendor.CsharpConsole;
using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Graphics
{
    public class GraphicsSystem
    {
        private int m_width;
        private int m_height;
        private IGraphicsContext m_graphicsContext;
        public GraphicsSystem(GraphicsType graphicsType, int width, int height)
        {
            m_width = width;
            m_height = height;
            switch (graphicsType)
            {
                case GraphicsType.TWO_D:
                    InitTwoDGraphics();
                    break;
                case GraphicsType.THREE_D:
                    InitThreeDGraphics();
                    break;
                case GraphicsType.RAYCASTING:
                    InitRayCastingGraphics();
                    break;
            }

            Log.CoreLogger.Logging("Init GraphicsSystem", LogLevel.Info);
        }

        public void Destroy()
        {
            Log.CoreLogger.Logging("Destroy GraphicsSystem", LogLevel.Info);
        }

        public void BeginRender()
        {
            m_graphicsContext.BeginDraw();
        }

        public void AddSprite(Texture texture, Vector2 bufferPosition)
        {
            m_graphicsContext.Draw(texture, bufferPosition);
        }

        public void EndRender()
        {
            m_graphicsContext.EndDraw();
        }


        private void InitTwoDGraphics()
        {
            m_graphicsContext = GetGraphicsContext().GetGraphicsContext();
        }

        private void InitThreeDGraphics()
        {

        }

        private void InitRayCastingGraphics()
        {
            
        }

        private GraphicsContextFactory GetGraphicsContext()
        {
            return new CsharpConsoleGraphicsContextFactory(m_width, m_height);
        }

    }
}
