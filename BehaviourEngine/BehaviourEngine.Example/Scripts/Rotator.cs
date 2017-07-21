using Aiv.Fast2D;

namespace BehaviourEngine.Example
{
    public class Rotator : Behaviour, IUpdatable
    {
        public float RotationSpeed = 50f;
        public KeyCode LeftKey     = KeyCode.A;
        public KeyCode RightKey    = KeyCode.D;

        void IUpdatable.Update()
        {
            if (Input.IsKeyPressed(LeftKey))
            {
                owner.Transform.EulerRotation -= RotationSpeed * Time.DeltaTime;
            }
            if (Input.IsKeyPressed(RightKey))
            {
                owner.Transform.EulerRotation += RotationSpeed * Time.DeltaTime;
            }
        }
    }
}
