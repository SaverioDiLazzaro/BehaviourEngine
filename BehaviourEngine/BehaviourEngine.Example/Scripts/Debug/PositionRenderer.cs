using Aiv.Fast2D;

namespace BehaviourEngine.Example
{
    public class PositionRenderer : SpriteRenderer
    {
        public PositionRenderer() : base(null)
        {
            Sprite = new Sprite(0.1f, 0.1f);
        }

        public override void Update()
        {
            Sprite.position = this.Owner.Transform.Position;
        }

        public override void Draw()
        {
            Sprite.DrawSolidColor(1f, 0f, 0f);
        }
    }
}
