using ConsoleGameEngine.Graphics.Factories;

namespace ConsoleGameEngine.Graphics.Vendor.CsharpConsole
{
    public class CsharpConsoleGraphicsContextFactory : GraphicsContextFactory
    {
        private readonly int m_width;
        private readonly int m_height;
        public CsharpConsoleGraphicsContextFactory(int width, int height) 
        {
            m_width = width;
            m_height = height;
        }

        public override IGraphicsContext GetGraphicsContext()
        {
            return new CsharpConsoleGraphicsContext(m_width, m_height);
        }
    }
}
