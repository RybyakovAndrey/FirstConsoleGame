using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.LogSystem;

namespace FirstConsoleGame
{
    public class ExampleLayer : BaseLayer
    {
        public ExampleLayer() : base("Example Layer")
        {
            Log.ClientLogger.Logging("Create Example Layer", LogLevel.Info);
        }

        public override void Start()
        {
            var player = new BaseGameObject("Player");
            var playerComponent = new Player();
            player.AddComponent(playerComponent);
            AddGameObject(player, false);
        }
        public override void Destroy()
        {

            base.Destroy();
        }
    }
}
