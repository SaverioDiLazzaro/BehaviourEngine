using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class BoxScaler : ObjectScaler, IStartable
    {
        private BoxCollider2D collider;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<BoxCollider2D>();
        }

        protected override bool IsCursorContained()
        {
            if (collider.Contains(Input.MousePosition))
                return true;
            else
                return false;
        }

        protected override void ChangeScale()
        {
            float ratio = collider.Size.Y / collider.Size.X;
            float distance = Input.MousePosition.X - collider.Center.X;

            float tolerance = MathHelper.Clamp(distance, 1f, distance);
            collider.Size = new Vector2(tolerance, ratio * tolerance);
        }
    }
}
