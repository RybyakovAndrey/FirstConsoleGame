using System;
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

        private float m_deltaTime;
        private int m_framePerSecond;
        private int m_lastFps;
        private float m_flagSecond;

        public Application()
        {
            m_isRunning = true;
            m_deltaTime = 0;
            m_framePerSecond = 0;
            m_lastFps = 0;
            m_flagSecond = 0;
            m_layerStack = new LayerStack();

            // ----- Init System --------
            m_inputSystem = InputSystem.GetInputSystem(OnEvent);
            m_camera2D = new Camera2D(new Vector2(180, 54), new Vector2(10, -10));

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
            int currentTime;
            while (m_isRunning)
            {
                currentTime = DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
                foreach (var layer in m_layerStack)
                    layer.Update(m_deltaTime);

                m_camera2D.StartRender();
                foreach (var layer in m_layerStack)
                    m_camera2D.RenderLayer(layer);
                m_camera2D.Render();

                Thread.Sleep(6);
                m_deltaTime = (DateTime.Now.Second * 1000 + DateTime.Now.Millisecond - currentTime) / 1000.0f;
                FPS(m_deltaTime);
            }
        }

        private void Close()
        {
            m_isRunning = false;
        }


        private void FPS(float deltaTime)
        {
            m_flagSecond += deltaTime;
            m_framePerSecond++;
            if (m_flagSecond >= 1)
            {
                m_lastFps = m_framePerSecond;
                m_flagSecond = 0;
                m_framePerSecond = 0;
            }
            Console.WriteLine($"fps: {m_lastFps} ");
        }
    }

}
