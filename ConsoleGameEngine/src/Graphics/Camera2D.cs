using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.Domain.Struct;

namespace ConsoleGameEngine.Graphics
{
    public class Camera2D
    {
        public Vector2 Position { get; }
        public Vector2 FieldOfView { get; }

        private GraphicsSystem m_graphicsSystem;
        private Vector2 m_halfFieldOfView => FieldOfView / 2;

        public Camera2D() : this(new Vector2(120, 30)) { }

        public Camera2D(Vector2 fieldOfView) : this(fieldOfView, Vector2.Zero) { }

        public Camera2D(Vector2 fieldOfView, Vector2 position)
        {
            Position = position;
            FieldOfView = fieldOfView;
            m_graphicsSystem = new GraphicsSystem(GraphicsType.TWO_D, (int)FieldOfView.X, (int)FieldOfView.Y);
        }

        public void Destroy()
        {
            m_graphicsSystem.Destroy();
        }

        public void StartRender()
        {
            m_graphicsSystem.BeginRender();
        }

        public void RenderLayer(ILayer layer)
        {
            foreach (var gameObject in layer.GetObjects())
            {
                RenderObject(gameObject);
            }
        }

        public void Render()
        {
            m_graphicsSystem.EndRender();
        }

        private void RenderObject(IGameObject gameObject)
        {
            var transform = gameObject.GetComponent<Transform>();
            if (gameObject.GetComponent<MeshComponent>() is MeshComponent meshComponent)
                if(CheckDrawObject(transform.Position, meshComponent.texture, out var newTexture))
                    m_graphicsSystem.AddSprite(newTexture, ConvertPosition(transform.Position));
        }


        private bool CheckDrawObject(Vector2 gameObjectPosition, Texture meshTexture, out Texture texture)
        {
            texture = new Texture();
          
            if (Position.X - m_halfFieldOfView.X < gameObjectPosition.X + meshTexture.Size.X && Position.X + m_halfFieldOfView.X > gameObjectPosition.X &&
                Position.Y + m_halfFieldOfView.Y > gameObjectPosition.Y - meshTexture.Size.Y && Position.Y - m_halfFieldOfView.Y < gameObjectPosition.Y)
            {
                
                int StartIndexX = gameObjectPosition.X > Position.X - m_halfFieldOfView.X ? 0 : (int)(Position.X - m_halfFieldOfView.X - gameObjectPosition.X);
                int EndIndexX = gameObjectPosition.X + meshTexture.Size.X < Position.X + m_halfFieldOfView.X ? meshTexture.Width : (int)(Position.X + m_halfFieldOfView.X - gameObjectPosition.X);

                int StartIndexY = gameObjectPosition.Y < Position.Y + m_halfFieldOfView.Y ? 0 : (int)(gameObjectPosition.Y - (Position.Y + m_halfFieldOfView.Y));
                int EndIndexY = gameObjectPosition.Y - meshTexture.Size.Y > Position.Y - m_halfFieldOfView.Y ? meshTexture.Height : (int)(gameObjectPosition.Y - (Position.Y - m_halfFieldOfView.Y));

                var newWidth = EndIndexX - StartIndexX;
                var newHeight = EndIndexY - StartIndexY;

                var newBuffer = new char[newWidth * newHeight];
                var oldBuffer = meshTexture.GetTexture();

                for (int y = StartIndexY; y < EndIndexY; y++)
                {
                    for (int x = StartIndexX; x < EndIndexX; x++)
                    {
                        newBuffer[(y - StartIndexY) * newWidth + x - StartIndexX] = oldBuffer[y * meshTexture.Width + x];
                    }
                }
                
                texture.SetTexture(newBuffer, newWidth, newHeight);
                return true;
            }

            return false;
        }

        private Vector2 ConvertPosition(Vector2 position)
        {
            float resultX = position.X - (Position.X - m_halfFieldOfView.X);
            float resultY = position.Y - (Position.Y + m_halfFieldOfView.Y);
            if(resultX < 0) resultX = 0;
            if(-resultY < 0) resultY = 0;
            return new Vector2(resultX, -resultY);
        }
    }
}
