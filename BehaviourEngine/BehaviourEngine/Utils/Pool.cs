using System;
using System.Collections.Generic;

namespace BehaviourEngine
{
    public static class Pool<T> where T : class
    {
        private static Queue<T> instances;
        private static Func<T> allocator;

        public static void Register(Func<T> allocator, int preallocations = 0)
        {
            if (instances != null)
                throw new Exception("Pool already registered");

            if (allocator == null)
                throw new NullReferenceException("Func<T> allocator can't be null");

            instances = new Queue<T>(preallocations);
            for (int i = 0; i < preallocations; i++)
            {
                instances.Enqueue(allocator.Invoke());
            }

            Pool<T>.allocator = allocator;
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
