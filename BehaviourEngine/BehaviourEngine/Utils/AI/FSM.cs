using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public class FSM : Behaviour, IUpdatable
    {
        public string DebugCurrentState { get; private set; }

        private Dictionary<string, FSMState> states = new Dictionary<string, FSMState>();
        private FSMState currentState;

        public void SwitchState(string name)
        {
            FSMState nextState = states[name];

            currentState.OnStateExit();
            nextState.OnStateEnter();

            currentState = nextState;
        }
        public void Init(FSMState initialState)
        {
            currentState = initialState;
            currentState.OnStateEnter();
        }

        public void AddState(string name, FSMState state)
        {
            if (!states.ContainsKey(name))
            {
                states.Add(name, state);
            }
        }

        void IUpdatable.Update()
        {
            currentState = currentState.Update();
            DebugCurrentState = currentState.ToString();
        }
    }
}
