using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Time
    {
        public static float DeltaTime { get { return Graphics.Instance.Window.deltaTime; } }
    }
}
