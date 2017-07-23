using System.Collections.Generic;

namespace EngineBuilder
{
    public abstract class System<T> : ISystem
        where T : class, IEntity
    {
        protected List<T> items = new List<T>();
        private Queue<T> waitForAddItems = new Queue<T>();
        private Queue<T> waitForRemoveItems = new Queue<T>();

        protected enum SortingMode
        {
            AfterAddOnly,
            Always
        }
        protected SortingMode sortingMode = SortingMode.AfterAddOnly;

        public T[] GetItems()
        {
            T[] array = new T[items.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = items[i];
            }
            return array;
        }
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
                int count = waitForAddItems.Count;
                for (int i = 0; i < count; i++)
                {
                    items.Add(waitForAddItems.Dequeue());
                }

                if(count > 0 && sortingMode == SortingMode.AfterAddOnly)
                {
                    SortItems();
                }

                count = waitForRemoveItems.Count;
                for (int i = 0; i < count; i++)
                {
                    items.Remove(waitForRemoveItems.Dequeue());
                }
            }

            if(sortingMode == SortingMode.Always)
            {
                SortItems();
            }
        }

        public virtual int UpdateOffset { get; set; }
        public virtual void Update()
        {
            DeferredAddOrRemove();
        }
        protected virtual void SortItems() { }
    }
}
