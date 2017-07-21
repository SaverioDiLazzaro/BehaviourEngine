namespace BehaviourEngine.Example
{
    public class Sensor : Behaviour, IStartable
    {
        private Collider2D collider;
        private SpriteRenderer renderer;
        private int triggerCount;
        private int collisionCount;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = owner.GetBehaviour<Collider2D>();
            renderer = owner.GetBehaviour<SpriteRenderer>();

            collider.TriggerEnter += OnTriggerEnter;
            collider.TriggerExit  += OnTriggerExit;

            collider.CollisionEnter += OnCollisionEnter;
            collider.CollisionExit  += OnCollisionExit;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            triggerCount++;
            if (triggerCount > 0)
                renderer.Sprite.SetAdditiveTint(+1f, -1f, 0f, 0f);
        }
        private void OnTriggerExit(Collider2D other)
        {
            triggerCount--;
            if (triggerCount == 0)
                renderer.Sprite.SetAdditiveTint(-1f, +1f, 0f, 0f);
        }
        private void OnCollisionEnter(Collider2D other, HitState hitState)
        {
            collisionCount++;
            if (collisionCount > 0)
                renderer.Sprite.SetAdditiveTint(0f, -1f, +1f, 0f);
        }
        private void OnCollisionExit(Collider2D other, HitState hitState)
        {
            collisionCount--;
            if (collisionCount == 0)
                renderer.Sprite.SetAdditiveTint(0f, +1f, -1f, 0f);
        }
    }
}
