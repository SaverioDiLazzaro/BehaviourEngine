namespace BehaviourEngine
{
    internal class CollisionPairState
    {
        internal bool enter;
        internal bool stay;
        internal bool exit;

        internal void Update(bool trigger)
        {
            if (trigger)
            {
                this.enter = !this.stay;
                this.stay = true;
            }
            else
            {
                this.exit = this.stay;
                this.enter = false;
                this.stay = false;
            }
        }
    }
}
