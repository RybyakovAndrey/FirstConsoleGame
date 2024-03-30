using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Component;
using ConsoleGameEngine.Domain.GameObject;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Graphics;
using ConsoleGameEngine.LogSystem;
using ConsoleGameEngine.src.Graphics;
using System.Net.Http.Headers;

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
            var testUI = new BaseGameObject();
            testUI.GetComponent<MeshComponent>()?.Disable();
            var ui = new UIComponent();
            ui.TextureUI.SetTexture(new char[] { '+', '-', '-', '-', '-', '+',
                                                 '|', ' ', ' ', ' ', ' ', '|',
                                                 '|', 'H', 'i', '!', ' ', '|',
                                                 '+', '-', '-', '-', '-', '+' }, 6, 4);
            testUI.AddComponent(ui);
            testUI.GetComponent<Transform>().Position = new Vector2(0, 0);
            AddGameObject(player, false);
            AddGameObject(testUI, true);
        }
        public override void Destroy()
        {

            base.Destroy();
        }
    }
}
