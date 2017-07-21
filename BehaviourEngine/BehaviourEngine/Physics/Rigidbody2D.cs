using OpenTK;

namespace BehaviourEngine
{
    public class Rigidbody2D : Behaviour, IPhysical
    {
        public Vector2 Velocity;
        public bool IsGravityAffected;
        public float LinearFriction;

        void IPhysical.PhysicalUpdate()
        {
            if (IsGravityAffected)
            {
                this.AddForce(Physics.Instance.Gravity);
            }

            this.AddForce(-Velocity * LinearFriction);

            owner.Transform.Position += Velocity * Time.DeltaTime;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force * Time.DeltaTime;
        }
    }
}
