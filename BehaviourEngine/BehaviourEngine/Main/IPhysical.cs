using EngineBuilder;
using EngineBuilder.Shared;

namespace BehaviourEngine
{
    public interface IPhysical : IEntity
    {
        void PhysicalUpdate();
    }
}