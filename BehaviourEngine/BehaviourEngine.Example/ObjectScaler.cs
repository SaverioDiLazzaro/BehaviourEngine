using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public abstract class ObjectScaler : Behaviour, IStartable, IUpdatable
    {
        protected static ObjectScaler currentTarget;
        protected bool trigger;
        //protected Vector2 distance;
        internal Vector2 mousePos => Graphics.Window.mousePosition;

        bool IStartable.IsStarted { get; set; }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            if (Graphics.Window.mouseRight)
            {
                if (CursorContained())
                {
                    if (!trigger)
                    {
                        trigger = true;
                       // distance = this.Owner.Transform.Position - mousePos;
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
                        Alghoritm();
                    }
                }
            }
           
            else
            {
                currentTarget = null;
                trigger = false;
            }
        }

        protected abstract bool CursorContained();

        protected abstract void Alghoritm();
    }
}
