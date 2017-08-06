using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace BehaviourEngine.Example
{
    public class Wall : GameObject
    {
        public Wall(Vector2 size)
        {
            this.Layer = (uint)CollisionLayer.Wall;

            BoxCollider2D collider = new BoxCollider2D(size);
            this.AddBehaviour(collider);

            BoxCollider2DRenderer renderer = new BoxCollider2DRenderer();
            renderer.RenderOffset = (int)RenderLayer.Collider;
            this.AddBehaviour(renderer);
        }
    }
}
