using Aiv.Fast2D;
using System.Linq;

using EngineBuilder.Core;

namespace BehaviourEngine
{
    sealed public class Graphics : System<IDrawable>
    {
        public Window Window;

        #region Internal Stuff
        internal void Init(Window window)
        {
            Window = window;
        }
        #endregion

        #region Singleton
        public static Graphics Instance;
        static Graphics()
        {
            Instance = new Graphics();
        }
        private Graphics() { }
        #endregion

        #region System<T>
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

        protected override void SortItems()
        {
            //TODO: too heavy
            items.OrderByDescending(item => item.RenderOffset);
        }
        #endregion
    }
}