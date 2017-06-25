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
    public class CircleScaler : ObjectScaler, IStartable
    {
        private SpriteRenderer renderer;
        private CircleCollider2D collider;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<CircleCollider2D>();
            renderer = Owner.GetBehaviour<SpriteRenderer>();
        }

        protected override bool IsCursorContained()
        {
            if (collider.Contains(Input.MousePosition))
                return true;
            else
                return false;
        }

        protected override void ChangeScale()
        {
            collider.Radius = MathHelper.Clamp((collider.Center - Input.MousePosition).Length, 1f, (collider.Center - Input.MousePosition).Length);
        }
    }
}
