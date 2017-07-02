using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class BoxCollider2D : Collider2D, IStartable
    {

        public Vector2 Size { get; set; }

        public Vector2 Center { get { return (ExtentMin + ExtentMax) * 0.5f; } }
        public Vector2 ExtentMin { get { return this.Position - PivotOffset; } }
        public Vector2 ExtentMax { get { return Position + Size - PivotOffset; } }

        private BoxCollider2DRenderer renderer;
        private Vector2 PivotOffset
        {
            get
            {
                if (renderer != null)
                {
                    return renderer.Sprite.pivot * Size;
                }
                return Vector2.Zero;
            }
        }


        public BoxCollider2D(Vector2 size) : base()
        {
            Size = size;
        }

        public override bool Contains(Vector2 point)
        {
            if (point.X > this.ExtentMin.X &&
                point.X < this.ExtentMax.X &&
                point.Y > this.ExtentMin.Y &&
                point.Y < this.ExtentMax.Y)
            {
                return true;
            }

            return false;
        }

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            renderer = Owner.GetBehaviour<BoxCollider2DRenderer>();
        }

        public override void PhysicalUpdate()
        {
            base.PhysicalUpdate();
            Owner.Transform.Scale = Size;
        }
    }
}
