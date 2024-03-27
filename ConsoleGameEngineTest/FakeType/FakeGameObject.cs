using ConsoleGameEngine.Domain.GameObject;

namespace ConsoleGameEngineTest.FakeType
{
    internal class FakeGameObject : GameObject
    {
        public FakeGameObject(string name = "gameObject"): base(name) { }
        public override void Destroy()
        {

        }

        public override void Start()
        {

        }
    }
}
