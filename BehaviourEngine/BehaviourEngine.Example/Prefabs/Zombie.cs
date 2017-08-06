using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;

namespace BehaviourEngine.Example
{
    public class Zombie : GameObject
    {
        public Vector2 Size = Vector2.One * 0.75f;
        private Vector2 direction = -Vector2.UnitX;
        public Vector2 Direction
        {
            get { return direction; }
            set { direction = value; Flip(); }
        }

        public float Speed = 2f;

        private Vector2 originalScale;
        private Rigidbody2D rigidbody;

        public Zombie()
        {
            this.Layer = (uint)CollisionLayer.Enemy;

            this.Transform.Scale = Size;
            originalScale = this.Transform.Scale;
            Flip();

            FSM fsm = new FSM();
            StateMove move = new StateMove(fsm, this);
            fsm.AddState("move", move);
            fsm.Init(move);
            this.AddBehaviour(fsm);

            BoxCollider2D collider = new BoxCollider2D(Size);
            collider.CollisionEnter += OnCollisionEnter;
            this.AddBehaviour(collider);

            BoxCollider2DRenderer colliderRenderer = new BoxCollider2DRenderer();
            colliderRenderer.RenderOffset = (int)RenderLayer.Collider;
            this.AddBehaviour(colliderRenderer);

            SpriteRenderer spriteRenderer = new SpriteRenderer(TextureManager.GetTexture("zombie"));
            spriteRenderer.RenderOffset = (int)RenderLayer.Zombie;
            this.AddBehaviour(spriteRenderer);

            rigidbody = new Rigidbody2D();
            this.AddBehaviour(rigidbody);
        }

        public void Die()
        {
            Pool<Zombie>.RecycleInstance(this, z => z.OnRecycle());
        }

        public void OnGet()
        {
            this.Active = true;
            rigidbody.Velocity = Vector2.Zero;
        }

        public void OnRecycle()
        {
            this.Active = false;
            rigidbody.Velocity = Vector2.Zero;
        }

        private void OnCollisionEnter(Collider2D other, HitState hitState)
        {
            if (other.Owner is Wall)
            {
                if (hitState.normal.X != 0f)
                {
                    //Change Direction
                    direction.X *= -1f;
                    Flip();
                }
            }
        }

        private void Flip()
        {
            Vector2 scale = this.Transform.Scale;
            if (Direction.X > 0f)
            {
                scale.X = +originalScale.X;
            }
            else
            {
                scale.X = -originalScale.X;
            }
            this.Transform.Scale = scale;
        }
    }
}
