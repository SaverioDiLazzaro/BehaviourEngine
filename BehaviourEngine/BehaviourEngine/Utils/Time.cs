using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Time
    {
        //TODO: timer since game started
        public static float DeltaTime
        {
            get { return Graphics.Window.deltaTime; }
        }
        public static float FixedDeltaTime
        {
            get { return Physics.FixedDeltaTime; }
        }
    }
}
