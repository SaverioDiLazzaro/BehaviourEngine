using EngineBuilder.Shared;

namespace EngineBuilder.Core
{
    public interface ISystem
    {
        int UpdateOffset { get; set; }
        void Update();
        void Add(IEntity entity);
        void Remove(IEntity entity);
    }
}