using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    #region New
    //TODO: to finish
    //public class BoxCollider2DRenderer : SpriteRenderer, IStartable
    //{
    //    BoxCollider2D collider;

    //    LineRenderer lineTop;
    //    LineRenderer lineRight;
    //    LineRenderer lineBottom;
    //    LineRenderer lineLeft;

    //    public BoxCollider2DRenderer() : base(null) { }
    //    void IStartable.Start()
    //    {
    //        base.Start();

    //        collider = this.owner.GetBehaviour<BoxCollider2D>();

    //        float lineWidth = 1f / Graphics.Instance.Window.CurrentOrthoGraphicSize;
    //        Vector4 lineColor = new Vector4(0f, 1f, 0f, 1f);

    //        this.lineTop = new LineRenderer(-0.5f, -0.5f, +0.5f, -0.5f, lineWidth) { Color = new Vector4(0f, 1f, 0f, 1f) };
    //        this.lineRight = new LineRenderer(+0.5f, -0.5f, +0.5f, +0.5f, lineWidth) { Color = new Vector4(0f, 1f, 0f, 1f) };
    //        this.lineBottom = new LineRenderer(+0.5f, +0.5f, -0.5f, +0.5f, lineWidth) { Color = new Vector4(0f, 1f, 0f, 1f) };
    //        this.lineLeft = new LineRenderer(-0.5f, +0.5f, -0.5f, -0.5f, lineWidth) { Color = new Vector4(0f, 1f, 0f, 1f) };

    //        this.owner.AddBehaviour(lineTop);
    //        this.owner.AddBehaviour(lineRight);
    //        this.owner.AddBehaviour(lineBottom);
    //        this.owner.AddBehaviour(lineLeft);
    //    }
    //    public override void Update()
    //    {
    //        this.Sprite.position = collider.internalTransform.Position;
    //        this.Sprite.Rotation = collider.internalTransform.Rotation;
    //        this.Sprite.scale = collider.Size;
    //    }
    //    public override void Draw()
    //    {
    //    }
    //}
    #endregion

    public class BoxCollider2DRenderer : SpriteRenderer, IStartable
    {
        BoxCollider2D collider;
        public BoxCollider2DRenderer() : base(TextureManager.GetTexture("Box2D")) { }
        void IStartable.Start()
        {
            base.Start();
            collider = this.Owner.GetBehaviour<BoxCollider2D>();
        }
        public override void Update()
        {
            this.Sprite.position = collider.internalTransform.Position;
            this.Sprite.Rotation = collider.internalTransform.Rotation;
            this.Sprite.scale = collider.Size;
        }
    }
}
