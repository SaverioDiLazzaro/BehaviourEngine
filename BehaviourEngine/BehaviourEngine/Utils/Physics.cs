using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Physics
    {
        public static Vector2 Gravity
        {
            get { return physicSystem.Gravity; }
            set { physicSystem.Gravity = value; }
        }
        public static float FixedDeltaTime
        {
            get { return physicSystem.FixedDeltaTime; }
            set { physicSystem.FixedDeltaTime = value; }
        }

        private static PhysicSystem physicSystem;

        internal static void Init(PhysicSystem physicSystem)
        {
            Physics.physicSystem = physicSystem;
        }
    }
}
