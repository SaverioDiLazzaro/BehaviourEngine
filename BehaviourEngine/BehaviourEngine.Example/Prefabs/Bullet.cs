using OpenTK;

namespace BehaviourEngine.Example
{
    public class Bullet : GameObject
    {
        Rigidbody2D rigidbody;

        public Bullet()
        {
            this.Layer = (uint)CollisionLayer.Bullet;

            this.Transform.Scale = Vector2.One * 0.2f;

            SpriteRenderer renderer = new SpriteRenderer(TextureManager.GetTexture("bullet"));
            renderer.RenderOffset = (int)RenderLayer.Bullet;
            this.AddBehaviour(renderer);

            CircleCollider2D collider = new CircleCollider2D(0.1f);
            collider.CollisionMode = CollisionMode.Trigger;
            collider.TriggerEnter += OnTriggerEnter;
            this.AddBehaviour(collider);

            CircleCollider2DRenderer colliderRenderer = new CircleCollider2DRenderer();
            this.AddBehaviour(colliderRenderer);

            rigidbody = new Rigidbody2D();
            rigidbody.IsGravityAffected = false;
            this.AddBehaviour(rigidbody);

            RecycleWhenOutOfScreen<Bullet> poolOutOfScreen = new RecycleWhenOutOfScreen<Bullet>(this, b => b.OnRecycle());
            this.AddBehaviour(poolOutOfScreen);
        }

        private void OnTriggerEnter(Collider2D other)
        {
            //TODO: kill zombie       
            if (other.Owner is Zombie zombie)
            {
                zombie.Die();
            }
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

        public void Shoot(Vector2 direction, float force)
        {
            rigidbody.AddForce(direction * force);
        }
    }
}
