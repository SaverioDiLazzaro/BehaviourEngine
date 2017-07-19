using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Aiv.Fast2D;
using OpenTK;

using EngineBuilder.Shared;

namespace BehaviourEngine
{
    public class CircleCollider2DRenderer : SpriteRenderer, IStartable
    {
        CircleCollider2D collider;
        static CircleCollider2DRenderer()
        {
            TextureManager.AddTexture("Circle2D", new Texture("Assets/Circle2D.png"));
        }
        public CircleCollider2DRenderer() : base(TextureManager.GetTexture("Circle2D")) { }

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
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
