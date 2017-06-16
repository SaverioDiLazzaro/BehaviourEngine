using EngineBuilder;

namespace BehaviourEngine
{
    public interface IStartable : IEntity
    {
        bool IsStarted { get; set; }
        void Start();
    }
}