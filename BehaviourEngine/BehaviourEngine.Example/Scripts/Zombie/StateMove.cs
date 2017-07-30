using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class StateMove : FSMState
    {
        Zombie zombie;

        public StateMove(FSM fsm, Zombie owner) : base(fsm)
        {
            this.zombie = owner;
        }

        public override FSMState Update()
        {
            zombie.Transform.Position += zombie.Direction * zombie.Speed * Time.DeltaTime;

            if(zombie.Transform.Position.Y - zombie.Size.Y > Graphics.Instance.Window.OrthoHeight)
            {
                zombie.Die();
            }

            return this;
        }
    }
}
