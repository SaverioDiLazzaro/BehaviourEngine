using Aiv.Fast2D;
using System;

namespace BehaviourEngine
{
    public static class Engine
    {
        public static event Action ApplicationShutDown;
        private static BehaviourEngine engine;
        static Engine()
        {
            engine = new BehaviourEngine();
            engine.ApplicationShutDown += OnApplicationShutDown;
        }

        private static void OnApplicationShutDown()
        {
            ApplicationShutDown?.Invoke();
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
