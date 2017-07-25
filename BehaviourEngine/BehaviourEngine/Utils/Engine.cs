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
