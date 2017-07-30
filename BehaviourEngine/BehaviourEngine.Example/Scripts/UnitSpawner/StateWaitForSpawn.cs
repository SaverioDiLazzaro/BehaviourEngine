using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class StateWaitForSpawn : FSMState
    {
        private ZombieSpawner spawner;
        private float currentTime;
        private float spawnTime;
        private Random random;

        public StateWaitForSpawn(FSM fsm, ZombieSpawner spawner) : base(fsm)
        {
            this.spawner = spawner;

            random = new Random();
        }

        private void Init()
        {
            currentTime -= spawnTime;
            spawnTime = spawner.MinSpawnTime + (float)random.NextDouble() * (spawner.MaxSpawnTime - spawner.MinSpawnTime);
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Init();
        }

        public override FSMState Update()
        {
            currentTime += Time.DeltaTime;
            if (currentTime >= spawnTime)
            {
                spawner.Spawn();
                Init();
            }
            return this;
        }
    }
}
