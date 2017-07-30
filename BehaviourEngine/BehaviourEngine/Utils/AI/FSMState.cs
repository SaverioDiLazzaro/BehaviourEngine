using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public abstract class FSMState
    {
        protected FSM fsm;
       
        public FSMState(FSM fsm)
        {
            this.fsm = fsm;
        }
        public virtual void OnStateExit() { }

        public virtual void OnStateEnter() { }

        public abstract FSMState Update();
    }
}
