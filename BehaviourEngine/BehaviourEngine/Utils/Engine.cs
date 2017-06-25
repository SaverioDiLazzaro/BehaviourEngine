using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aiv.Fast2D;

namespace BehaviourEngine
{
    public static class Engine
    {
        private static BehaviourEngine engine;
        static Engine()
        {
            engine = new BehaviourEngine();
        }
        public static void Init(Window window)
        {
            engine.Init(window);
        }
        public static void Add(Behaviour behaviour)
        {
            engine.Add(behaviour);
        }
        public static void Remove(Behaviour behaviour)
        {
            engine.Remove(behaviour);
        }
        public static void Run()
        {
            engine.Run();
        }
    }
}
