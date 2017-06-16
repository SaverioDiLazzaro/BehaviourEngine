using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    internal class CollisionPairState
    {
        internal bool Enter;
        internal bool Stay;
        internal bool Exit;

        internal void Update(bool trigger)
        {
            if (trigger)
            {
                this.Enter = !this.Stay;
                this.Stay = true;
            }
            else
            {
                this.Exit = this.Stay;
                this.Enter = false;
                this.Stay = false;
            }
        }
    }
}
