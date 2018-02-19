using EngineBuilder;

namespace BehaviourEngine
{
    public abstract class Behaviour : IEntity
    {
        public GameObject Owner;

        public bool Enabled
        {
            get { return enabled && Owner.Active; }
            set { enabled = value; }
        }
        private bool enabled;

        internal void SetOwner(GameObject owner)
        {
            this.Owner = owner;
        }
    }
}