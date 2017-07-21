using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public abstract class Collider2D : Behaviour, IStartable, IPhysical
    {
        public delegate void TriggerHandler(Collider2D other);
        public event TriggerHandler TriggerEnter;
        public event TriggerHandler TriggerStay;
        public event TriggerHandler TriggerExit;

        internal Transform internalTransform;

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

        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.Owner);
        }

        public abstract void PhysicalUpdate();
    }
}
