using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public class CircleCollider2D : Collider2D, IStartable, IUpdatable
    {
        SpriteRenderer renderer;
        public float Radius { get; set; }
        public Vector2 Center
        {
            get
            {
                return new Vector2(Position.X + Radius, Position.Y + Radius);
            }
        }

        public CircleCollider2D(float radius)
        {
            this.Radius = radius;
        }
        public override bool Contains(Vector2 point)
        {
            return (point - Center).Length < Radius;
        }


        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            renderer = Owner.GetBehaviour<SpriteRenderer>();
        }
        public override void Update()
        {
            base.Update();
            if (renderer != null)
            {
                Position = Owner.Transform.Position - Vector2.One * Radius;
            }
            else
            {
                Position = Owner.Transform.Position;
            }
            Owner.Transform.Scale = Vector2.One * this.Radius * 2f;
        }
    }
}