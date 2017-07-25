using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineBuilder.Tests
{
    //duplicated class due to while loop
    public class TestEngine /*: Engine*/
    {
        public bool IsRunning { get; set; }

        public void Init(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Add(systems[i]);
            }
        }

        public void Run()
        {
            this.IsRunning = true;
            this.SortSystems();

            //one step instead of "while (IsRunning)"
            if (IsRunning)
            {
                this.DeferredAddOrRemoveEntities();

                for (int i = 0; i < systems.Count; i++)
                {
                    systems[i].Update();
                }
            }
        }

        #region code duplicated without while loop
        protected List<ISystem> systems = new List<ISystem>();

        private Queue<IEntity> waitForAddEntities = new Queue<IEntity>();
        private Queue<IEntity> waitForRemoveEntities = new Queue<IEntity>();

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

        #endregion
    }
}
