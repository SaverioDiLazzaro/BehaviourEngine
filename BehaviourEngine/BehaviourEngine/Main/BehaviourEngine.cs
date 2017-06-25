using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aiv.Fast2D;

namespace BehaviourEngine
{
    internal class BehaviourEngine : EngineBuilder.Core.Engine
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

            this.Add(startSystem, updateSystem, Physics.Instance, Graphics.Instance);
        }
    }

}
