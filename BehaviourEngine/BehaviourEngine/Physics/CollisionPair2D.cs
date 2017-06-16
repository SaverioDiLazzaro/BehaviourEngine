using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    internal class CollisionPair2D
    {
        internal Collider2D Collider1;
        internal Collider2D Collider2;
        internal CollisionPairState State;

        internal bool PairEnabled
        {
            get
            {
                return Collider1.Enabled && Collider2.Enabled;
            }
        }

        internal CollisionPair2D(Collider2D collider1, Collider2D collider2)
        {
            this.Collider1 = collider1;
            this.Collider2 = collider2;

            State = new CollisionPairState();
        }

        internal void Trigger(bool trigger)
        {
            State.Update(trigger);
            Collider1.Trigger(Collider2, State);
            Collider2.Trigger(Collider1, State);
        }
    }
}
