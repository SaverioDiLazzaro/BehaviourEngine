using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class ZombieSpawner : GameObject
    {
        public float MinSpawnTime = 2f;
        public float MaxSpawnTime = 3f;
        Random random = new Random();

        private List<SpawnPoint> spawnPoints = new List<SpawnPoint>();

        public ZombieSpawner()
        {
            FSM fsm = new FSM();
            StateWaitForSpawn waitForSpawn = new StateWaitForSpawn(fsm, this);
            fsm.AddState("waitForSpawn", waitForSpawn);
            fsm.Init(waitForSpawn);
            this.AddBehaviour(fsm);
        }

        public void AddSpawnPoint(SpawnPoint spawnPoint)
        {
            spawnPoints.Add(spawnPoint);
        }

        public void Spawn()
        {
            int pointIndex = random.Next(this.spawnPoints.Count);
            SpawnPoint point = spawnPoints[pointIndex];
            Zombie zombie = Pool<Zombie>.GetInstance(z => z.OnGet());
            zombie.Transform.Position = point.Position;
            zombie.Direction = point.Direction;

            if (!zombie.IsSpawned)
            {
                GameObject.Spawn(zombie);
            }
        }
    }
}
