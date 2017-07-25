using Aiv.Fast2D;
using System.Linq;

using EngineBuilder;

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

            this.SortItems();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].Draw();
                }
            }

            Window.Update();
        }

        private void SortItems()
        {
            //orderbydescending
            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = i + 1; j < items.Count; j++)
                {
                    if (items[i].RenderOffset < items[j].RenderOffset)
                    {
                        IDrawable temp = items[i];
                        items[i] = items[j];
                        items[j] = temp;
                    }
                }
            }
        }
        #endregion
    }
}