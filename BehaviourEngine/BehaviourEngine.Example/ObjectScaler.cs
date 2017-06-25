using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public abstract class ObjectScaler : Behaviour, IUpdatable
    {
        protected static ObjectScaler currentTarget;
        protected bool trigger;

        public virtual void Update()
        {
            if(Input.IsMouseButtonPressed(MouseButton.Right))
            {
                if (IsCursorContained())
                {
                    if (!trigger)
                    {
                        trigger = true;
                    }
                }

                if (trigger)
                {
                    if (currentTarget == null)
                    {
                        ObjectScaler.currentTarget = this;
                    }
                    if (currentTarget == this)
                    {
                        ChangeScale();
                    }
                }
            }
            else
            {
                currentTarget = null;
                trigger = false;
            }
        }

        protected abstract bool IsCursorContained();
        protected abstract void ChangeScale();
    }
}
