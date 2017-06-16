using EngineBuilder;
namespace BehaviourEngine
{
    public class Behaviour : IEntity
    {
        public bool Enabled { get { return enabled && Owner.Active; } set { enabled = value; } }
        private bool enabled;

        protected GameObject Owner;

        internal void SetOwner(GameObject gameObject)
        {
            Owner = gameObject;
        }
    }
}