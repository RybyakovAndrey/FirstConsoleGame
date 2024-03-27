using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;

namespace ConsoleGameEngine.Domain.Component
{
    public class Transform : BaseComponent
    {
        public Vector2 Position { get; set; }

        public Transform()
        {
            Position = new Vector2();
        }

        public override void Destroy()
        {
            
        }

        public override void OnEvent(Event e)
        {
            
        }

        public override void Start()
        {
            
        }

        public override void Update(float daltaTime)
        {
            
        }
    }
}
