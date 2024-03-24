using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.GameObject;
using System;

namespace FirstConsoleGame
{
    public class ExampleLayer : BaseLayer
    {
        public ExampleLayer() : base("Example Layer")
        {
            Console.WriteLine("Create Example Layer");
        }

        public override void Start()
        {
            var player = new BaseGameObject();
            var playerComponent = new Player();
            player.AddComponent(playerComponent);
            AddGameObject(player, false);
        }
        public override void Destroy()
        {
            
        }
    }
}
