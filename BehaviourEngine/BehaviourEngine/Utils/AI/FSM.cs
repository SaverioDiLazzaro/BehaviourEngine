using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine
{
    public class FSM : Behaviour, IUpdatable, IPhysical
    {
        public string DebugCurrentState { get; private set; }

        public enum FSMUpdateType
        {
            DeltaUpdate,
            FixedUpdate
        }
        public FSMUpdateType UpdateType = FSMUpdateType.DeltaUpdate;

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
            if(this.UpdateType == FSMUpdateType.DeltaUpdate)
            {
                this.Update();
            }
        }

        void IPhysical.PhysicalUpdate()
        {
            if (this.UpdateType == FSMUpdateType.FixedUpdate)
            {
                this.Update();
            }
        }
        private void Update()
        {
            currentState = currentState.Update();
            DebugCurrentState = currentState.ToString();
        }
    }
}
