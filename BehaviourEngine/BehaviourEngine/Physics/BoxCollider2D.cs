using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class BoxCollider2D : Collider2D, /*IStartable,*/ IUpdatable
    {
        //private SpriteRenderer renderer;
        public Vector2 Size { get; set; }
        public Vector2 ExtentMin
        {
            get
            {
                return this.Position;
            }
        }

        public Vector2 ExtentMax
        {
            get
            {
                return Position + Size;
            }
        }

        public Vector2 Center { get { return Position + Size * 0.5f; } }

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


        //bool IStartable.IsStarted { get; set; }

        //void IStartable.Start()
        //{
        //    renderer = Owner.GetBehaviour<SpriteRenderer>();
        //}
        //public override void Update()
        //{
        //    base.Update();
        //    if (renderer != null)
        //    {
        //        Position = Owner.Transform.Position - Vector2.One * Radius;
        //    }
        //    else
        //    {
        //        Position = Owner.Transform.Position;
        //    }
        //    Owner.Transform.Scale = Vector2.One * this.Radius * 2f;
        //}
    }
}
