using Aiv.Fast2D;

namespace BehaviourEngine
{
    internal class BehaviourEngine : EngineBuilder.Engine
    {
        public override bool IsRunning
        {
            get { return Graphics.Instance.Window.opened; }
            set { Graphics.Instance.Window.opened = value; }
        }

        public void Init(Window window)
        {
            StartSystem startSystem = new StartSystem();
            UpdateSystem updateSystem = new UpdateSystem();

            Physics.Instance.Init();
            Graphics.Instance.Init(window);

            //Systems are updated by the order they are added to the engine
            this.Add(startSystem, updateSystem, Physics.Instance, Graphics.Instance);
        }
    }
}
