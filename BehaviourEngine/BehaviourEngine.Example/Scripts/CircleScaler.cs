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
    public class CircleScaler : ObjectScaler
    {
        private SpriteRenderer renderer;
        private CircleCollider2D collider;

        public override void Start()
        {
            base.Start();
            collider = Owner.GetBehaviour<CircleCollider2D>();
            renderer = Owner.GetBehaviour<SpriteRenderer>();
        }

        protected override void ChangeScale()
        {
            float newRadius = MathHelper.Clamp((collider.Center - Input.MousePosition).Length, 1f, (collider.Center - Input.MousePosition).Length);
            Owner.Transform.Scale = Vector2.One * newRadius;
        }
    }
}
