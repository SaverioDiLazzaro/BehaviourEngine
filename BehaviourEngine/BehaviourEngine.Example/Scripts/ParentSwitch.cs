using Aiv.Fast2D;

namespace BehaviourEngine.Example
{
    public class ParentSwitch : Behaviour, IUpdatable
    {
        Transform originalParent;

        public ParentSwitch(Transform parent)
        {
            this.originalParent = parent;
        }

        void IUpdatable.Update()
        {
            if (Input.IsKeyDown(KeyCode.P))
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
