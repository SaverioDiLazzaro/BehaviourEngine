using System;

namespace BehaviourEngine
{
    internal class CollisionPair2D
    {
        internal Collider2D collider1;
        internal Collider2D collider2;
        internal CollisionPairState collisionPairState;

        internal bool IsPairEnabled
        {
            get
            {
                return collider1.Enabled && collider2.Enabled;
            }
        }

        internal CollisionMode PairCollisionMode
        {
            get
            {
                if (collider1.CollisionMode == CollisionMode.Collision && collider2.CollisionMode == CollisionMode.Collision)
                {
                    return CollisionMode.Collision;
                }

                return CollisionMode.Trigger;
            }
        }

        internal CollisionPair2D(Collider2D collider1, Collider2D collider2)
        {
            this.collider1 = collider1;
            this.collider2 = collider2;

            collisionPairState = new CollisionPairState();
        }

        internal void Trigger(bool trigger)
        {
            collisionPairState.Update(trigger);
            collider1.Trigger(collider2, collisionPairState);
            collider2.Trigger(collider1, collisionPairState);
        }

        internal void Collision(HitState hitState)
        {
            collisionPairState.Update(hitState.hit);
            collider1.Collision(collider2, collisionPairState, hitState);
            collider2.Collision(collider1, collisionPairState, hitState);
        }
    }
}
