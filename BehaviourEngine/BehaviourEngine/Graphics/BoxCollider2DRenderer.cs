using Aiv.Fast2D;

namespace BehaviourEngine
{
    public class BoxCollider2DRenderer : SpriteRenderer, IStartable
    {
        BoxCollider2D collider;
        static BoxCollider2DRenderer()
        {
            //TODO: change with Segment
            TextureManager.AddTexture("Box2D", new Texture("Assets/Box2D.png"));
        }
        public BoxCollider2DRenderer() : base(TextureManager.GetTexture("Box2D")) { }
        void IStartable.Start()
        {
            base.Start();
            collider = this.owner.GetBehaviour<BoxCollider2D>();
        }
        public override void Update()
        {
            this.Sprite.position = collider.internalTransform.Position;
            this.Sprite.Rotation = collider.internalTransform.Rotation;
            this.Sprite.scale    = collider.Size;
        }
    }
}
