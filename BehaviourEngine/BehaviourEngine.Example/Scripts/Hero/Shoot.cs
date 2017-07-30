using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class Shoot : Behaviour, IUpdatable
    {
        public float Force = 1000f;
        private Transform locator;

        public Shoot(Transform locator)
        {
            this.locator = locator;
        }

        void IUpdatable.Update()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                Vector2 dir;
                if(Input.MousePosition.X > this.Owner.Transform.Position.X)
                {
                    dir = Vector2.UnitX;
                }
                else
                {
                    dir = -Vector2.UnitX;
                }

                Bullet bullet = Pool<Bullet>.GetInstance(b => b.OnGet());
                bullet.Transform.Position = locator.Position;
                bullet.Shoot(dir, Force);

                if (!bullet.IsSpawned)
                {
                    GameObject.Spawn(bullet);
                }
            }
        }
    }
}
