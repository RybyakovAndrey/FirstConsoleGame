using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;

namespace ConsoleGameEngine.src.Graphics
{
    public class UIComponent : BaseComponent
    {
        public Texture TextureUI { get; set; }

        public UIComponent()
        {
            TextureUI = new Texture();

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
