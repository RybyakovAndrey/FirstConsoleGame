using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;

namespace ConsoleGameEngine.Graphics
{
    public class MeshComponent : BaseComponent
    {
        public Texture Texture { get; set; }

        public MeshComponent()
        {
            Texture = new Texture();
        }
        public override void Start()
        {
            
        }
        public override void Destroy()
        {
            
        }

        public override void Update(float daltaTime)
        {

        }

        public override void OnEvent(Event e)
        {
           
        }
        
    }
}
