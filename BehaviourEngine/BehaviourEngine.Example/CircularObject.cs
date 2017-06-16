using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class CircularObject : GameObject
    {
        public CircularObject(Vector2 position, float radius)
        {
            CircleCollider2D collider = new CircleCollider2D(radius);
            this.AddBehaviour(collider);

            this.AddBehaviour(new ClickableObject());

            SpriteRenderer renderer = new SpriteRenderer(TextureManager.GetTexture("greencircle"));
            this.AddBehaviour(renderer);

            CircularCollisionDebugger d = new CircularCollisionDebugger();
            this.AddBehaviour(d);

            CircularObjectScaler scaler = new CircularObjectScaler();
            this.AddBehaviour(scaler);

            GameObject.Spawn(this, position);
        }
    }
}
