using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class Move : Behaviour, IUpdatable
    {
        public float Speed = 3f;
        public KeyCode Left = KeyCode.A;
        public KeyCode Right = KeyCode.D;

        void IUpdatable.Update()
        {
            Vector2 pos = this.Owner.Transform.Position;

            if (Input.IsKeyPressed(Left))
            {
                pos.X -= Speed * Time.DeltaTime;
            }

            if (Input.IsKeyPressed(Right))
            {
                pos.X += Speed * Time.DeltaTime;
            }

            this.Owner.Transform.Position = pos;
        }
    }
}
