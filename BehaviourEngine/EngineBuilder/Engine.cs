using System.Collections.Generic;
using EngineBuilder.Shared;

namespace EngineBuilder.Core
{
    public abstract class Engine
    {
        protected List<ISystem> systems = new List<ISystem>();
        public abstract bool IsRunning { get; set; }
        public void Run()
        {
            while (IsRunning)
            {
                //Update Systems
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
        public void Add(params ISystem[] systems)
        {
            for (int i = 0; i < systems.Length; i++)
            {
                this.Add(systems[i]);
            }
        }
        public bool Remove(ISystem system)
        {
            return systems.Remove(system);
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
    }
}
