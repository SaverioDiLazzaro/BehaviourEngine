namespace BehaviourEngine.Example
{
    public abstract class ObjectScaler : Behaviour, IStartable, IUpdatable
    {
        protected static ObjectScaler currentTarget;
        protected bool trigger;
        private Collider2D collider;

        bool IStartable.IsStarted { get; set; }
        public virtual void Start()
        {
            collider = Owner.GetBehaviour<Collider2D>();
        }

        public virtual void Update()
        {
            if (Input.IsMouseButtonPressed(MouseButton.Right))
            {
                if (IsCursorContained())
                {
                    if (!trigger)
                    {
                        trigger = true;
                    }
                }

                if (trigger)
                {
                    if (currentTarget == null)
                    {
                        ObjectScaler.currentTarget = this;
                    }
                    if (currentTarget == this)
                    {
                        ChangeScale();
                    }
                }
            }
            else
            {
                currentTarget = null;
                trigger = false;
            }
        }

        private bool IsCursorContained()
        {
            return collider.Contains(Input.MousePosition);
        }
        protected abstract void ChangeScale();
    }
}
