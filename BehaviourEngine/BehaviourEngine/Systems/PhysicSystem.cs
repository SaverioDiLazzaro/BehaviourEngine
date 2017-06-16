using OpenTK;
using System;
using System.Collections.Generic;

using EngineBuilder;

namespace BehaviourEngine
{
    internal class PhysicSystem : System<IPhysical>
    {
        public Vector2 Gravity       = new Vector2(0f, 9.81f);
        public float FixedDeltaTime  = 0.02f;
        public override void Update()
        {
            base.Update();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].PhysicalUpdate();
                }
            }
        }
    }
}