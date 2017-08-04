using System;
using System.Collections.Generic;
using System.Linq;

namespace EngineBuilder
{
    public abstract class Engine
    {
        public abstract bool IsRunning { get; set; }
        public event Action ApplicationShutDown;

        protected List<ISystem> systems = new List<ISystem>();

        private Queue<IEntity> waitForAddEntities = new Queue<IEntity>();
        private Queue<IEntity> waitForRemoveEntities = new Queue<IEntity>();

        public void Run()
        {
            this.IsRunning = true;
            this.SortSystems();

            while (IsRunning)
            {
                this.DeferredAddOrRemoveEntities();

                for (int i = 0; i < systems.Count; i++)
                {
                    systems[i].Update();
                }
            }
            
            ApplicationShutDown?.Invoke();
        }

        public ISystem[] DebugSystems()
        {
            ISystem[] array = new ISystem[systems.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = systems[i];
            }
            return array;
        }

        protected void Add(ISystem system)
        {
            systems.Add(system);
        }
        protected bool Remove(ISystem system)
        {
            return systems.Remove(system);
        }
        protected void Add(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Add(systems[i]);
            }
        }
        protected void Remove(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Remove(systems[i]);
            }
        }

        public void Add(IEntity entity)
        {
            waitForAddEntities.Enqueue(entity);
        }
        public void Remove(IEntity entity)
        {
            waitForRemoveEntities.Enqueue(entity);
        }
        private void TrueAdd(IEntity entity)
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Add(entity);
            }

            entity.Enabled = true;
        }
        private void TrueRemove(IEntity entity)
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Remove(entity);
            }
        }

        private void DeferredAddOrRemoveEntities()
        {
            //actual add objects to the engine
            int count;
            if (waitForAddEntities.Count > 0)
            {
                count = waitForAddEntities.Count;
                for (int i = 0; i < count; i++)
                {
                    this.TrueAdd(waitForAddEntities.Dequeue());
                }
            }

            if (waitForRemoveEntities.Count > 0)
            {
                count = waitForRemoveEntities.Count;
                for (int i = 0; i < count; i++)
                {
                    this.TrueRemove(waitForRemoveEntities.Dequeue());
                }
            }
        }
        protected void SortSystems()
        {
            //orderby
            for (int i = 0; i < systems.Count - 1; i++)
            {
                for (int j = i + 1; j < systems.Count; j++)
                {
                    if (systems[i].UpdateOffset > systems[j].UpdateOffset)
                    {
                        ISystem temp = systems[i];
                        systems[i] = systems[j];
                        systems[j] = temp;
                    }
                }
            }
        }
    }
}
