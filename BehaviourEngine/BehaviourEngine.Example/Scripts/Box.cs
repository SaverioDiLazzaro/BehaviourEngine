using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class Box : GameObject
    {
        public Box(Vector2 position, Vector2 size)
        {
            this.Transform.Position = position;

            this.AddBehaviour(new BoxCollider2D(size));
            this.AddBehaviour(new BoxCollider2DRenderer());

            this.AddBehaviour(new DraggableObject());
            this.AddBehaviour(new BoxScaler());

            this.AddBehaviour(new Sensor());

            GameObject.Spawn(this);
        }
    }
}
