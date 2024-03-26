using ConsoleGameEngine.Core;
using ConsoleGameEngine.LogSystem;

namespace FirstConsoleGame
{
    public class Game : Application
    {
        public Game()
        {
            Log.ClientLogger.Logging("Create Game", LogLevel.Info);
            Initialization();

        }

        public override void Destroy()
        {
            //First Destroy base App
            base.Destroy();

            Log.ClientLogger.Logging("Destroy Game", LogLevel.Info);
            
        }

        private void Initialization()
        {
            PushLayer(new ExampleLayer());

            Log.ClientLogger.Logging("Init Game", LogLevel.Info);
        }

    }
}
