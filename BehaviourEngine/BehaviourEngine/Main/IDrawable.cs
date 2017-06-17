using EngineBuilder;
using EngineBuilder.Shared;

namespace BehaviourEngine
{
    public interface IDrawable : IEntity
    {
        int RenderOffset { get; set; }
        void Draw();
    }
}