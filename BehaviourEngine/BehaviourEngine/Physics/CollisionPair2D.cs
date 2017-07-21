namespace BehaviourEngine
{
    internal class CollisionPair2D
    {
        internal Collider2D collider1;
        internal Collider2D collider2;
        internal CollisionPairState state;

        internal bool PairEnabled { get { return collider1.Enabled && collider2.Enabled; } }

        internal CollisionPair2D(Collider2D collider1, Collider2D collider2)
        {
            this.collider1 = collider1;
            this.collider2 = collider2;

            state = new CollisionPairState();
        }

        internal void Trigger(bool trigger)
        {
            state.Update(trigger);
            collider1.Trigger(collider2, state);
            collider2.Trigger(collider1, state);
        }
    }
}
