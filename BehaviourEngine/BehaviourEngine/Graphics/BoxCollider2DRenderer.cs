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
    public class BoxCollider2DRenderer : SpriteRenderer, IStartable
    {
        BoxCollider2D collider;
        static BoxCollider2DRenderer()
        {
            TextureManager.AddTexture("Box2D", new Texture("Assets/Box2D.png"));
        }

        public BoxCollider2DRenderer() : base(TextureManager.GetTexture("Box2D")) { }

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = this.Owner.GetBehaviour<BoxCollider2D>();
        }

        public override void Update()
        {
            this.Sprite.position = Owner.Transform.Position;
            this.Sprite.Rotation = Owner.Transform.Rotation;
            this.Sprite.scale    = Owner.Transform.Scale;
        }
    }
}
