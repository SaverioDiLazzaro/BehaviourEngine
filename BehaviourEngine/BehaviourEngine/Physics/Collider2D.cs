using System;
using OpenTK;

namespace BehaviourEngine
{
    public abstract class Collider2D : Behaviour, IStartable, IPhysical
    {
        public CollisionMode CollisionMode = CollisionMode.Collision;

        internal Transform internalTransform;
        //internal Rigidbody2D rigidbody; //TODO: use for sweep test

        public abstract Vector2 Center { get; }

        public abstract bool Contains(Vector2 point);
        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.owner);
        }
        public abstract void PhysicalUpdate();

        #region Trigger
        public delegate void TriggerHandler(Collider2D other);
        public event TriggerHandler TriggerEnter;
        public event TriggerHandler TriggerStay;
        public event TriggerHandler TriggerExit;
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
        #endregion

        #region Collision
        public delegate void CollisionHandler(Collider2D other, HitState hitState);
        public event CollisionHandler CollisionEnter;
        public event CollisionHandler CollisionStay;
        public event CollisionHandler CollisionExit;
        internal void Collision(Collider2D other, CollisionPairState state, HitState hitState)
        {
            if (state.enter)
            {
                //TODO: implement resolution
                CollisionEnter?.Invoke(other, hitState);
            }
            if (state.stay)
            {
                CollisionStay?.Invoke(other, hitState);
            }
            if (state.exit)
            {
                CollisionExit?.Invoke(other, hitState);
            }
        }
        #endregion
    }
}
