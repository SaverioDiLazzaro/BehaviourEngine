using EngineBuilder;

namespace BehaviourEngine
{
    public abstract class Behaviour : IEntity
    {
        public bool Enabled
        {
            get { return enabled && Owner.Active; }
            set { enabled = value; }
        }
        private bool enabled;

        public GameObject Owner;

        internal void SetOwner(GameObject gameObject)
        {
            Owner = gameObject;
        }
    }
}