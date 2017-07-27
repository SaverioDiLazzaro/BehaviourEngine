using Aiv.Fast2D;

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
