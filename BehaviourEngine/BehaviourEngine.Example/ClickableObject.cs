using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

using EngineBuilder.Shared;

namespace BehaviourEngine.Example
{
    public class ClickableObject : Behaviour, IStartable, IUpdatable
    {
        private Collider2D collider;
        private bool isTrigger;
        private static ClickableObject currentTarget;
        private Vector2 distance;

        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            this.collider = Owner.GetBehaviour<Collider2D>();
        }

        void IUpdatable.Update()
        {
            Vector2 mousePosition = Graphics.Window.mousePosition;

            if (Graphics.Window.mouseLeft)
            {
                if (this.collider.Contains(mousePosition))
                {
                    if (!isTrigger)
                    {
                        isTrigger = true;
                        distance = this.Owner.Transform.Position - mousePosition;
                    }
                }

                if (isTrigger)
                {
                    if (currentTarget == null)
                    {
                        ClickableObject.currentTarget = this;
                    }
                    if (currentTarget == this)
                    {
                        this.Owner.Transform.Position = mousePosition + distance;
                    }
                }
            }
            else
            {
                isTrigger = false;
                currentTarget = null;
            }
        }
    }
}
