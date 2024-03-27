using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Graphics;
using ConsoleGameEngine.Input;
using ConsoleGameEngine.LogSystem;

namespace FirstConsoleGame
{
    internal class Player : BaseComponent
    {
        private Vector2 m_direction;
        private MeshComponent m_mesh;
        private Transform m_transform;
        public override void Start()
        {
            m_direction = Vector2.Zero;
            m_mesh = GameObject.GetComponent<MeshComponent>();
            m_transform = GameObject.GetComponent<Transform>();
            m_mesh.texture.LoadTextureFromFileTxt(@".\src\Texture\player.txt");
        }
        public override void Destroy()
        {
            Log.ClientLogger.Logging("Destroy Player", LogLevel.Info);
        }

        public override void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyEvent)
            {
                if (keyEvent.GetKeyCode() == KeyCode.W)
                    m_direction.Y = 1;
                else if (keyEvent.GetKeyCode() == KeyCode.S)
                    m_direction.Y = -1;
                else if (keyEvent.GetKeyCode() == KeyCode.A)
                    m_direction.X = -1;
                else if (keyEvent.GetKeyCode() == KeyCode.D)
                    m_direction.X = 1;

            }            
        }

        public override void Update(float daltaTime)
        {
            if (m_direction != Vector2.Zero)
            {
                m_transform.Position += m_direction;
                m_direction.X = 0;
                m_direction.Y = 0;
            }
        }
    }
}
