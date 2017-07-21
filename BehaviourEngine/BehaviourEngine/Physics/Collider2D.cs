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

        public abstract Vector2 Center { get; }

        internal void Trigger(Collider2D other, CollisionPairState state)
        {
            if (state.enter)
            {
                TriggerEnter?.Invoke(other);
            }
            if (state.stay)
            {
                TriggerStay?.Invoke(other);
            }
            if (state.exit)
            {
                TriggerExit?.Invoke(other);
            }
        }
        public abstract bool Contains(Vector2 point);
        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.owner);
        }
        public abstract void PhysicalUpdate();
    }
}
