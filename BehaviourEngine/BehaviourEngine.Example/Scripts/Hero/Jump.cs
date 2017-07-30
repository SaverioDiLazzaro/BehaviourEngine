using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class Jump : Behaviour, IStartable, IUpdatable
    {
        public float Force = 550f;
        public KeyCode Key = KeyCode.W;

        private Rigidbody2D rigidbody;
        private Sensor sensor;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            rigidbody = this.Owner.GetBehaviour<Rigidbody2D>();
            sensor = this.Owner.GetBehaviour<Sensor>();
        }

        void IUpdatable.Update()
        {
            if (Input.IsKeyDown(Key) && sensor.IsGrounded)
            {
                rigidbody.Velocity.Y = 0f;
                rigidbody.AddForce(-Vector2.UnitY * Force);
            }
        }
    }
}
