using System;
using System.Collections.Generic;

using EngineBuilder;

namespace BehaviourEngine
{
    internal class UpdateSystem : System<IUpdatable>
    {
        public override void Update()
        {
            base.Update();

            Input.Update(Graphics.Window);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].Update();
                }
            }
        }
    }
}