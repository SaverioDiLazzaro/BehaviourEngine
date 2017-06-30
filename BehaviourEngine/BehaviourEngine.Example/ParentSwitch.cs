using Aiv.Fast2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
