using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class RectangularObject : GameObject
    {
        public RectangularObject(Vector2 position, Vector2 size)
        {
            this.Transform.Position = position;

            this.AddBehaviour(new BoxCollider2D(size));
            this.AddBehaviour(new RectangularCollisionDebugger());
            this.AddBehaviour(new ClickableObject());
            this.AddBehaviour(new RectangularObjectScaler());
            GameObject.Spawn(this);
        }
    }
}
