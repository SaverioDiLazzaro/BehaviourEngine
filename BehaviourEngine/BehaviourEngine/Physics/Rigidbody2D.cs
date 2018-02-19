using OpenTK;

namespace BehaviourEngine
{
    public class Rigidbody2D : Behaviour, IPhysical
    {
        public Vector2 Velocity;
        public bool IsGravityAffected = true;
        public float LinearFriction;

        public float Mass = 1f;

        void IPhysical.PhysicalUpdate()
        {
            //gravity
            if (this.IsGravityAffected)
            {
                this.AddForce(Physics.Instance.Gravity);
            }

            //friction
            this.AddForce(-this.Velocity * this.LinearFriction);

            //actually change position
            this.Owner.Transform.Position += this.Velocity * Time.FixedDeltaTime;
        }

        //TODO: handle ForceModes
        public void AddForce(Vector2 force)
        {
            this.Velocity += (force / this.Mass) * Time.FixedDeltaTime ;
        }

        public void AddForceImpulse(Vector2 force)
        {
            this.Velocity += (force / this.Mass);
        }
    }
}