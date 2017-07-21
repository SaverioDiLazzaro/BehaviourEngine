using OpenTK;

namespace BehaviourEngine
{
    public class BoxCollider2D : Collider2D, IStartable
    {
        public Vector2 Size { get; private set; }

        //TODO:implement
        //public Vector2 Offset;
        public override Vector2 Center { get { return (ExtentMin + ExtentMax) * 0.5f; } }
        public Vector2 ExtentMin { get { return internalTransform.Position - Size * 0.5f; } }
        public Vector2 ExtentMax { get { return internalTransform.Position + Size * 0.5f; } }

        public BoxCollider2D(Vector2 size) : base()
        {
            Size = size;
        }
        public void SetSize(Vector2 size)
        {
            Size = size;
            internalTransform.Scale = Size;
        }
        public override bool Contains(Vector2 point)
        {
            if (point.X > this.ExtentMin.X &&
                point.X < this.ExtentMax.X &&
                point.Y > this.ExtentMin.Y &&
                point.Y < this.ExtentMax.Y)
            {
                return true;
            }

            return false;
        }
        void IStartable.Start()
        {
            base.Start();
            SetSize(Size);
        }
        public override void PhysicalUpdate()
        {
            Size = internalTransform.Scale;
        }
    }
}
