using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class Circle : GameObject
    {
        public Circle(Vector2 position, float radius)
        {
            this.AddBehaviour(new CircleCollider2D(radius));
            this.AddBehaviour(new CircleCollider2DRenderer());

            this.AddBehaviour(new DraggableObject());
            this.AddBehaviour(new CircleScaler());

            this.AddBehaviour(new Sensor());

            GameObject.Spawn(this, position);
        }
    }
}
