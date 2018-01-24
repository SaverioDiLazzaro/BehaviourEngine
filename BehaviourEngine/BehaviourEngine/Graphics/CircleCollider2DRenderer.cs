using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class CircleCollider2DRenderer : SpriteRenderer, IStartable
    {
        CircleCollider2D collider;
        public CircleCollider2DRenderer() : base(TextureManager.GetTexture("Circle2D")) { }

        void IStartable.Start()
        {
            base.Start();
            collider = this.Owner.GetBehaviour<CircleCollider2D>();
        }

        public override void Update()
        {
            this.Sprite.position = collider.internalTransform.Position;
            this.Sprite.Rotation = collider.internalTransform.Rotation;
            this.Sprite.scale = Vector2.One * collider.Radius * 2f;
        }
    }
}
