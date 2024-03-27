using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Graphics.Factories;
using System;

namespace ConsoleGameEngine.Graphics.Vendor.CsharpConsole
{
    public class CsharpConsoleGraphicsContext : IGraphicsContext
    {
        private char[] m_buffer;
        private int m_width;
        private int m_height;
        public CsharpConsoleGraphicsContext(int width, int height)
        {
            m_width = width;
            m_height = height;
            Console.SetWindowSize(width, height + 2);
            Console.SetBufferSize(width, height + 2);
            Console.CursorVisible = false;
            m_buffer = new char[m_width * m_height];
        }

        public void BeginDraw()
        {
            Reset();
            Console.SetCursorPosition(0, 0);
        }

        public void Draw(Texture texture, Vector2 bufferPosition)
        {
            char[] sprite = texture.GetTexture();
            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    m_buffer[(y + (int)bufferPosition.Y) * m_width + x + (int)bufferPosition.X] = sprite[y * texture.Width + x];
                }
            }
            
        }

        public void EndDraw()
        {
            Console.Write(m_buffer);
        }

        private void Reset()
        {
            m_buffer = new char[m_width * m_height];
        }
    }
}
