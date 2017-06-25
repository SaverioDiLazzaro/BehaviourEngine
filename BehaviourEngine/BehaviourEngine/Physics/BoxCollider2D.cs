using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class BoxCollider2D : Collider2D
    {
        public Vector2 Size { get; set; }
        public Vector2 Center { get { return Position + Size * 0.5f; } }
        public Vector2 ExtentMin { get { return this.Position; } }
        public Vector2 ExtentMax { get { return Position + Size; } }

        public BoxCollider2D(Vector2 size) : base()
        {
            Size = size;
        }

        public override bool Contains(Vector2 point)
        {
            if (point.X > this.Position.X &&
                point.X < this.Position.X + this.Size.X &&
                point.Y > this.Position.Y &&
                point.Y < this.Position.Y + this.Size.Y)
            {
                return true;
            }

            return false;
        }
    }
}
