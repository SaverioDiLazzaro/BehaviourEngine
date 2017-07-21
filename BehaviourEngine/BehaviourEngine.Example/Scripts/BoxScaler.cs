using OpenTK;

namespace BehaviourEngine.Example
{
    public class BoxScaler : ObjectScaler, IStartable
    {
        private BoxCollider2D collider;
        private float minSize = 1f;

        public override void Start()
        {
            base.Start();
            collider = owner.GetBehaviour<BoxCollider2D>();
        }

        protected override void ChangeScale()
        {
            float ratio = collider.Size.Y / collider.Size.X;
            float distance = Input.MousePosition.X - collider.Center.X;

            float tolerance = MathHelper.Clamp(distance, minSize, distance);
            Vector2 newSize = new Vector2(tolerance, ratio * tolerance);

            owner.Transform.Scale = newSize;
            collider.SetSize(newSize);
        }
    }
}
