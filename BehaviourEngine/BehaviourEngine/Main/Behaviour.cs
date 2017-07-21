using EngineBuilder.Shared;

namespace BehaviourEngine
{
    public class Behaviour : IEntity
    {
        public bool Enabled
        {
            get { return enabled && owner.Active; }
            set { enabled = value; }
        }
        private bool enabled;

        protected GameObject owner;

        internal void SetOwner(GameObject gameObject)
        {
            owner = gameObject;
        }
    }
}