using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class SpriteRenderer : Behaviour, IStartable, IUpdatable, IDrawable
    {
        public Texture Texture;
        public Sprite Sprite;

        protected Transform internalTransform;

        public SpriteRenderer(Texture texture) : base()
        {
            this.Texture = texture;
            Sprite = new Sprite(1f, 1f);
            Sprite.pivot = Vector2.One * 0.5f;
        }

        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            internalTransform = Transform.InitInternalTransform(this.Owner);
        }

        public virtual void Update()
        {
            Sprite.position = internalTransform.Position;
            Sprite.Rotation = internalTransform.Rotation;
            Sprite.scale    = internalTransform.Scale;
        }

        public int RenderOffset { get; set; }
        void IDrawable.Draw()
        {
            Sprite.DrawTexture(Texture);
        }
    }
}
