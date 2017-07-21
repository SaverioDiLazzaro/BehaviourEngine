﻿using OpenTK;

namespace BehaviourEngine.Example
{
    public class CircleScaler : ObjectScaler
    {
        private CircleCollider2D collider;

        public override void Start()
        {
            base.Start();
            collider = owner.GetBehaviour<CircleCollider2D>();
        }

        protected override void ChangeScale()
        {
            float newRadius = MathHelper.Clamp((collider.Center - Input.MousePosition).Length, 1f, (collider.Center - Input.MousePosition).Length);

            owner.Transform.Scale = Vector2.One * newRadius;
            collider.SetRadius(newRadius);
        }
    }
}
