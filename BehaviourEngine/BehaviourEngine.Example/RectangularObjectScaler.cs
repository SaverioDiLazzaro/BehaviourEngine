using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class RectangularObjectScaler : ObjectScaler, IStartable, IUpdatable
    {
        private BoxCollider2D collider;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<BoxCollider2D>();
            //renderer = Owner.GetBehaviour<SpriteRenderer>();
            //renderer.Pivot = Vector2.One * 0.5f;
        }

        protected override bool CursorContained()
        {
            if (collider.Contains(this.mousePos))
                return true;
            else
                return false;
        }

        protected override void Alghoritm()
        {
            float ratio = collider.Size.Y / collider.Size.X;
            float distance = mousePos.X - collider.Center.X;
            
            float tolerance = MathHelper.Clamp(distance, 1f, distance);
            collider.Size = new Vector2(tolerance, ratio * tolerance);
        }

       // protected void AlghoritmOverRight()
       // {
       //     collider.Size = new Vector2(this.mousePos.X + this.distance.X, collider.Size.Y);
       // }
    }
}
