using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class FlipAtMousePosition : Behaviour, IStartable, IUpdatable
    {
        private Vector2 originalScale;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            originalScale = this.Owner.Transform.Scale;
        }

        void IUpdatable.Update()
        {
            Vector2 scale = this.Owner.Transform.Scale;

            if (Input.MousePosition.X < this.Owner.Transform.Position.X)
            {
                //Flip left
                scale.X = -originalScale.X;
            }
            else
            {
                //Flip right
                scale.X = +originalScale.X;
            }

            this.Owner.Transform.Scale = scale;
        }
    }
}
