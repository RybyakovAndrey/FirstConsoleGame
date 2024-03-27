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
                m_graphicsSystem.AddSprite(meshComponent.texture, transform.Position);
        }


        private bool CheckDrawObject()
        {

            return false;
        }
    }
}
