
namespace ConsoleGameEngine.Domain.GameObject
{
    public class BaseGameObject : GameObject
    {

        public BaseGameObject(string name = "gameObject") : base(name) { }
        public override void Destroy()
        {

            base.Destroy();
        }

        public override void Start()
        {
            
        }
    }
}
