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
            get { return Graphics.Window.IsOpened; }
            set { Graphics.Window.opened = value; }
        }

        public BehaviourEngine(Window window)
        {
            StartSystem startSystem = new StartSystem();
            UpdateSystem updateSystem = new UpdateSystem();
            GraphicSystem graphicSystem = new GraphicSystem(window);
            PhysicSystem physicSystem = new PhysicSystem();

            Physics.Init(physicSystem);
            Graphics.Init(graphicSystem);

            this.Add(startSystem, updateSystem, physicSystem, graphicSystem);
        }
    }
}
