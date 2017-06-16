namespace EngineBuilder
{
    public interface ISystem
    {
        void Update();
        void Add(IEntity entity);
        void Remove(IEntity entity);
    }
}