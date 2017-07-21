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
                if(this.owner.Transform.Parent == null)
                {
                    this.owner.Transform.SetParent(originalParent);
                }
                else
                {
                    this.owner.Transform.SetParent(null);
                }
            }

        }
    }
}
