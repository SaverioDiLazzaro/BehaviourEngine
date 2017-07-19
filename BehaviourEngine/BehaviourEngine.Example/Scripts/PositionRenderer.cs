using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class PositionRenderer : Behaviour, IUpdatable, IDrawable
    {
        private Sprite sprite;
        public PositionRenderer()
        {
            sprite = new Sprite(0.1f, 0.1f);
        }

        void IUpdatable.Update()
        {
            sprite.position = this.Owner.Transform.Position;
        }

        int IDrawable.RenderOffset { get; set; }
        void IDrawable.Draw()
        {
            sprite.DrawSolidColor(1f, 0f, 0f);
        }

      
    }
}
