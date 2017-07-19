using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public class CircleCollider2D : Collider2D, IStartable
    {
        public float Radius { get; private set; }
        public Vector2 Center { get { return internalTransform.Position + Vector2.One * Radius - PivotOffset; } }

        private CircleCollider2DRenderer renderer;
        private Vector2 PivotOffset
        {
            get
            {
                if (renderer != null)
                {
                    return renderer.Sprite.pivot * Vector2.One * Radius * 2f;
                }
                return Vector2.Zero;
            }
        }

        public CircleCollider2D(float radius)
        {
            this.Radius = radius;
        }

        public void SetRadius(float radius)
        {
            Radius = radius;
            internalTransform.Scale = Vector2.One * radius;
        }

        public override bool Contains(Vector2 point)
        {
            return (point - Center).Length < Radius;
        }

        void IStartable.Start()
        {
            base.Start();
            renderer = Owner.GetBehaviour<CircleCollider2DRenderer>();

            SetRadius(Radius);
        }

        public override void PhysicalUpdate()
        {
            Radius = internalTransform.Scale.X;
        }
    }
}