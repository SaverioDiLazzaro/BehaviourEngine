using EngineBuilder.Core;

namespace BehaviourEngine
{
    internal class UpdateSystem : System<IUpdatable>
    {
        public override void Update()
        {
            base.Update();

            Input.Update(Graphics.Instance.Window);

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].Update();
                }
            }
        }
    }
}