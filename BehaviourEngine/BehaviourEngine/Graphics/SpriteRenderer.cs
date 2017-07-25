using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class SpriteRenderer : Behaviour, IStartable, IUpdatable, IDrawable
    {
        public Texture Texture;
        public Sprite Sprite = new Sprite(1f, 1f)
        {
            pivot = Vector2.One * 0.5f
        };

        protected Transform internalTransform;

        public SpriteRenderer(Texture texture) : base()
        {
            this.Texture = texture;
        }

        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.owner);
        }

        public virtual void Update()
        {
            this.Sprite.position = internalTransform.Position;
            this.Sprite.Rotation = internalTransform.Rotation;
            this.Sprite.scale    = internalTransform.Scale;
        }

        public int RenderOffset { get; set; }
        public virtual void Draw()
        {
            Sprite.DrawTexture(Texture);
        }
    }
}
