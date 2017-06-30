﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class SpriteRenderer : Behaviour, IUpdatable, IDrawable
    {
        public Texture Texture;
        public Sprite Sprite;

        public SpriteRenderer(Texture texture) : base()
        {
            this.Texture = texture;
            Sprite = new Sprite(1f, 1f);
        }

        public virtual void Update()
        {
            Sprite.position = Owner.Transform.Position;
            Sprite.Rotation = Owner.Transform.Rotation;
            Sprite.scale    = Owner.Transform.Scale;
        }

        public int RenderOffset { get; set; }
        void IDrawable.Draw()
        {
            Sprite.DrawTexture(Texture);
        }
    }
}
