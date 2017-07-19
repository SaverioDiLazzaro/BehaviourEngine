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
    public class DraggableObject : Behaviour, IStartable, IUpdatable
    {
        private static DraggableObject currentTarget;

        private Collider2D collider;
        private Vector2 distance;
        private bool isTrigger;

        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            this.collider = Owner.GetBehaviour<Collider2D>();
        }
        void IUpdatable.Update()
        {
            if (Input.IsMouseButtonPressed(MouseButton.Left))
            {
                if (this.collider.Contains(Input.MousePosition))
                {
                    if (!isTrigger)
                    {
                        isTrigger = true;
                        distance = this.Owner.Transform.Position - Input.MousePosition;
                    }
                }

                if (isTrigger)
                {
                    if (currentTarget == null)
                    {
                        DraggableObject.currentTarget = this;
                    }
                    if (currentTarget == this)
                    {
                        this.Owner.Transform.Position = Input.MousePosition + distance;
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
