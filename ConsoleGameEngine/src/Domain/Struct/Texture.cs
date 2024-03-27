using ConsoleGameEngine.FileSystems;
using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Domain.Struct
{
    public class Texture
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

        private char[] m_buffer;

        public Texture() : this(null) { }
        public Texture(char[] buffer)
        {
            m_buffer = buffer;
        }


        public void SetTexture(char[] buffer, int width, int height)
        {
            Width = width;
            Height = height;
            m_buffer = buffer;
        }

        public char[] GetTexture()
        {
            return m_buffer;
        }

        public void LoadTextureFromFileTxt(string filePath)
        {
            var textureFile = FileSystem.ReadFromFile(filePath);

            if (textureFile == null)
            {
                Log.CoreLogger.Logging($"Don't Load Texture from {filePath}", LogLevel.Error);
                return;
            }

            Height = textureFile.Count;
            Width = textureFile[0].Length;

            m_buffer = new char[Width * Height];

            for(int y = 0; y < Height; y++) 
            {
                for (int x = 0; x < Width; x++)
                {
                    m_buffer[y * Width + x] = textureFile[y][x];
                }
            }
        }

    }
}
