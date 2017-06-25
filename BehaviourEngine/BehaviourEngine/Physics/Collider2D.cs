using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public abstract class Collider2D : Behaviour, IPhysical
    {
        public Vector2 Position { get; protected set; }
        public float Rotation { get; protected set; }
        public Vector2 Scale { get; protected set; }


        public delegate void TriggerHandler(Collider2D other);
        public event TriggerHandler TriggerEnter;
        public event TriggerHandler TriggerStay;
        public event TriggerHandler TriggerExit;

        internal void Trigger(Collider2D other, CollisionPairState state)
        {
            if (state.Enter)
            {
                TriggerEnter?.Invoke(other);
            }
            if (state.Stay)
            {
                TriggerStay?.Invoke(other);
            }
            if (state.Exit)
            {
                TriggerExit?.Invoke(other);
            }
        }

        public abstract bool Contains(Vector2 point);
        
        public virtual void PhysicalUpdate()
        {
            Position = Owner.Transform.Position;
            Rotation = Owner.Transform.Rotation;
            Scale    = Owner.Transform.Scale;
        }
    }
}
