using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Diagnostics;

namespace BehaviourEngine
{
    public class Rigidbody2D : Behaviour, IPhysical
    {
        public Vector2 Velocity;
        public bool IsGravityAffected;
        public float LinearFriction;

        void IPhysical.PhysicalUpdate()
        {
            if (IsGravityAffected)
            {
                this.AddForce(Physics.Instance.Gravity);
            }

            this.AddForce(-Velocity * LinearFriction);

            Owner.Transform.Position += Velocity * Graphics.Instance.Window.deltaTime;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force * Graphics.Instance.Window.deltaTime;
        }
    }
}
