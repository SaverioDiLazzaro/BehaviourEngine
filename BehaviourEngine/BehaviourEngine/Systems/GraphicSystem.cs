using Aiv.Fast2D;
using System.Linq;

using EngineBuilder;

namespace BehaviourEngine
{
    public class GraphicSystem : System<IDrawable>
    {
        public Window Window;
        public GraphicSystem(Window window)
        {
            Window = window;
        }
        public override void Update()
        {
            base.Update();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].Draw();
                }
            }

            Window.Update();
        }

        protected override void Sort()
        {
            base.Sort();

            //TODO: too heavy sort
            items.OrderByDescending(item => item.RenderOffset);
        }
    }
}