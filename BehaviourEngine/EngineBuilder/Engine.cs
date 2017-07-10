using System.Collections.Generic;
using EngineBuilder.Shared;
using System.Linq;

namespace EngineBuilder.Core
{
    public abstract class Engine
    {
        protected List<ISystem> systems = new List<ISystem>();
        public abstract bool IsRunning { get; set; }

        public void Run()
        {
            SortSystems();

            while (IsRunning)
            {
                for (int i = 0; i < systems.Count; i++)
                {
                    systems[i].Update();
                }
            }
        }

        public void Add(ISystem system)
        {
            systems.Add(system);
        }
        public bool Remove(ISystem system)
        {
            return systems.Remove(system);
        }
        public void Add(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Add(systems[i]);
            }
        }
        public void Remove(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Remove(systems[i]);
            }
        }
        public void Add(IEntity entity)
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Add(entity);
            }

            entity.Enabled = true;
        }
        public void Remove(IEntity entity)
        {
            for (int i = 0; i < systems.Count; i++)
            {
                systems[i].Remove(entity);
            }
        }

        protected void SortSystems()
        {
            //TODO: too heavy
            systems.OrderByDescending(item => item.UpdateOffset);
        }
    }
}
