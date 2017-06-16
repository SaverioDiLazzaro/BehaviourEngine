using EngineBuilder;

namespace BehaviourEngine
{
    public interface IDrawable : IEntity
    {
        int RenderOffset { get; set; }
        void Draw();
    }
}