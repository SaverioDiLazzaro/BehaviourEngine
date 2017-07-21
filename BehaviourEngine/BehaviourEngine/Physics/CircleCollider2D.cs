using OpenTK;

namespace BehaviourEngine
{
    public class CircleCollider2D : Collider2D, IStartable
    {
        public float Radius { get; private set; }

        //TODO: implement
        //public Vector2 Offset;
        public override Vector2 Center
        {
            get
            {
                return internalTransform.Position;
            }
        }
        public CircleCollider2D(float radius)
        {
            this.Radius = radius;
        }
        public void SetRadius(float radius)
        {
            Radius = radius;
            internalTransform.Scale = Vector2.One * radius;
        }
        public override bool Contains(Vector2 point)
        {
            return (point - Center).Length < Radius;
        }
        void IStartable.Start()
        {
            base.Start();
            SetRadius(Radius);
        }
        public override void PhysicalUpdate()
        {
            Radius = internalTransform.Scale.X;
        }
    }
}