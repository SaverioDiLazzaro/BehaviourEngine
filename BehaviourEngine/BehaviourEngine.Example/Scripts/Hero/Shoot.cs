using OpenTK;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class Shoot : Behaviour, IUpdatable
    {
        public float Force = 10f;
        private Transform locator;

        private static AudioSource audioSource;

        public Shoot(Transform locator)
        {
            this.locator = locator;
            audioSource = new AudioSource();
            audioSource.AudioClip = AudioManager.GetAudioClip("shoot");
        }

        void IUpdatable.Update()
        {
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                audioSource.Play();
                
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
