
namespace ConsoleGameEngine.Domain.Struct
{
    public class Texture
    {
        private char[] m_buffer;

        public Texture() : this(null) { }
        public Texture(char[] buffer)
        {
            m_buffer = buffer;
        }


        public void SetTexture(char[] buffer)
        {
            m_buffer = buffer;
        }

        public void LoadTextureFromFile(string filePath)
        {

        }

    }
}
