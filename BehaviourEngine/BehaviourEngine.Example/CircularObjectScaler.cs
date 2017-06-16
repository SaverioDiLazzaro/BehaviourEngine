using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class CircularObjectScaler : ObjectScaler, IStartable, IUpdatable
    {
        private SpriteRenderer renderer;
        private CircleCollider2D collider;

        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<CircleCollider2D>();
            renderer = Owner.GetBehaviour<SpriteRenderer>();
            renderer.Pivot = Vector2.One * 0.5f;
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
            collider.Radius = MathHelper.Clamp((collider.Center - mousePos).Length, 1f, (collider.Center - mousePos).Length);
        }

        //private bool IsMouseOverEdge(Vector2 point)
        //{
        //    float distance = (collider.Center - point).Length;
        //    return distance < collider.Radius + tolerance && distance > collider.Radius - tolerance;
        //}


    }
}
