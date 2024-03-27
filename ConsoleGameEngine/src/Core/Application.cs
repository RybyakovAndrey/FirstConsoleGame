using System.Threading;
using ConsoleGameEngine.Domain;
using ConsoleGameEngine.Domain.Events;
using ConsoleGameEngine.Domain.Struct;
using ConsoleGameEngine.Graphics;
using ConsoleGameEngine.Input;
using ConsoleGameEngine.LogSystem;

namespace ConsoleGameEngine.Core
{
    public abstract class Application : IApplication
    {
        private InputSystem m_inputSystem;
        private bool m_isRunning;
        private LayerStack m_layerStack;
        private Camera2D m_camera2D;
        public Application()
        {
            m_isRunning = true;
            m_layerStack = new LayerStack();

            // ----- Init System --------
            m_inputSystem = InputSystem.GetInputSystem(OnEvent);
            m_camera2D = new Camera2D(new Vector2(160, 40), new Vector2(10, -10));

            Log.CoreLogger.Logging("Create application engine", LogLevel.Info);
        }

        public virtual void Destroy()
        {
            m_inputSystem.Destroy();
            m_camera2D.Destroy();

            foreach (var layer in m_layerStack)
                layer.Destroy();
            m_layerStack.Clear();

            Log.CoreLogger.Logging("Destroy application", LogLevel.Info);
        }

        public void OnEvent(Event e)
        {
            if (e is KeyPressedEvent keyEvent && keyEvent.GetKeyCode() == KeyCode.Escape)
                Close();

            foreach (var layer in m_layerStack)
                layer.OnEvent(e);

        }

        public void PopLayer(ILayer layer)
        {

            layer?.Destroy();
            m_layerStack.Pop(layer);
        }

        public void PushLayer(ILayer layer)
        {
            
            m_layerStack.Push(layer);
            layer?.Start();
        }

        public virtual void Run()
        {
            while (m_isRunning)
            {

                foreach (var layer in m_layerStack)
                    layer.Update(0);

                m_camera2D.StartRender();
                foreach (var layer in m_layerStack)
                    m_camera2D.RenderLayer(layer);
                m_camera2D.Render();

                Thread.Sleep(10);
            }
        }

        private void Close()
        {
            m_isRunning = false;
        }
    }

}
