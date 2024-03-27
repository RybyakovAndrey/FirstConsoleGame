using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Graphics;

namespace ConsoleGameEngine.Domain.GameObject
{
    public class BaseGameObject : GameObject
    {

        public BaseGameObject(string name = "gameObject") : base(name) 
        {
            AddComponent(new MeshComponent());
            AddComponent(new Transform());
        }
        public override void Destroy()
        {

            base.Destroy();
        }

        public override void Start()
        {
           
        }
    }
}
