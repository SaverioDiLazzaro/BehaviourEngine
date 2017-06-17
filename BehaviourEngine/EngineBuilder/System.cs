using System.Collections.Generic;
using EngineBuilder.Shared;

namespace EngineBuilder.Core
{
    public abstract class System<T> : ISystem
        where T : class, IEntity
    {
        protected List<T> items = new List<T>();
        private Queue<T> waitForAddItems = new Queue<T>();
        private Queue<T> waitForRemoveItems = new Queue<T>();

        public virtual void Add(IEntity entity)
        {
            T item = entity as T;
            if (item != null)
            {
                waitForAddItems.Enqueue(item);
            }
        }
        public virtual void Remove(IEntity entity)
        {
            T item = entity as T;
            if (item != null)
            {
                waitForRemoveItems.Enqueue(item);
            }
        }
        private void DeferredAddOrRemove()
        {
            //actual add objects to the system
            if (waitForAddItems.Count > 0 || waitForRemoveItems.Count > 0)
            {
                for (int i = 0; i < waitForAddItems.Count; i++)
                {
                    items.Add(waitForAddItems.Dequeue());
                }

                for (int i = 0; i < waitForRemoveItems.Count; i++)
                {
                    items.Remove(waitForRemoveItems.Dequeue());
                }

                Sort();
            }
        }
        public virtual void Update()
        {
            DeferredAddOrRemove();
        }
        protected virtual void Sort() { }
    }
}
