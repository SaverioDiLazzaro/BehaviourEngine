using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BehaviourEngine
{
    public static class Pool<T> where T : class
    {
        private static Queue<T> instances;
        private static Func<T> allocator;
        private static int count;

        public static void Register(Func<T> allocator, int capacity = 4)
        {
            if (instances != null)
                throw new Exception("Pool already registered");

            if (allocator == null)
                throw new NullReferenceException("Func<T> allocator can't be null");

            Pool<T>.allocator = allocator;
            instances = new Queue<T>(capacity);
        }

        public static T GetInstance(Action<T> onGet = null)
        {
            if (instances == null)
                throw new Exception("Pool is not registered");

            T toReturn = instances.Count == 0 ? allocator.Invoke() : instances.Dequeue();

            onGet?.Invoke(toReturn);
            return toReturn;
        }

        public static void RecycleInstance(T toRecycle, Action<T> onRecycle = null)
        {
            if (instances == null)
                throw new Exception("Pool is not registered");

            onRecycle?.Invoke(toRecycle);
            instances.Enqueue(toRecycle);
        }
    }
}
