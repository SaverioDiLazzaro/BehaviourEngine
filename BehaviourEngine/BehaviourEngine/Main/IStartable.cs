using EngineBuilder;

namespace BehaviourEngine
{
    internal interface IStartable : IEntity
    {
        bool IsStarted { get; set; }
        void Start();
    }
}