using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    public class CircleCollider2D : Collider2D
    {
        public float Radius { get; set; }
        public Vector2 Center { get { return new Vector2(Position.X + Radius, Position.Y + Radius); } }
        public CircleCollider2D(float radius)
        {
            this.Radius = radius;
        }
        public override bool Contains(Vector2 point)
        {
            return (point - Center).Length < Radius;
        }
    }
}