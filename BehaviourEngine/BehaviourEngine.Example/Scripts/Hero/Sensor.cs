using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class Sensor : Behaviour, IStartable
    {
        private Collider2D collider;

        bool IStartable.IsStarted { get; set; }
        public bool IsGrounded { get; private set; }

        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<Collider2D>();

            collider.CollisionStay += OnCollisionStay;
            collider.CollisionExit += OnCollisionExit;
        }

        private void OnCollisionStay(Collider2D other, HitState hitState)
        {
            if(hitState.normal.Y < 0f)
            {
                IsGrounded = true;
            }
        }

        private void OnCollisionExit(Collider2D other, HitState hitState)
        {
            IsGrounded = false;
        }
    }
}
