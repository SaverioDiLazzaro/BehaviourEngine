using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Graphics
    {
        public static Window Window { get { return graphicSystem.Window; } }
      
        private static GraphicSystem graphicSystem;
        internal static void Init(GraphicSystem graphicSystem)
        {
            Graphics.graphicSystem = graphicSystem;
        }
    }
}
