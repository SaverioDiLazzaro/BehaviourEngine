using Aiv.Fast2D;

namespace BehaviourEngine.Example
{
    public class ParentSwitch : Behaviour, IUpdatable
    {
        Transform originalParent;
        private KeyCode key = KeyCode.P;

        public ParentSwitch(Transform parent)
        {
            this.originalParent = parent;
        }

        void IUpdatable.Update()
        {
            if (Input.IsKeyDown(key))
            {
                if(this.Owner.Transform.Parent == null)
                {
                    this.Owner.Transform.SetParent(originalParent);
                }
                else
                {
                    this.Owner.Transform.SetParent(null);
                }
            }

        }
    }
}
