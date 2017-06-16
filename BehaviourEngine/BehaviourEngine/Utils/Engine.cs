using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public static class Engine
    {
        private static BehaviourEngine engine;
        public static void Init(Window window)
        {
            engine = new BehaviourEngine(window);
        }
        public static void Run()
        {
            engine.Run();
        }
        internal static void Add(Behaviour behaviour)
        {
            engine.Add(behaviour);
        }
        internal static void Remove(Behaviour behaviour)
        {
            engine.Remove(behaviour);
        }
    }
}
