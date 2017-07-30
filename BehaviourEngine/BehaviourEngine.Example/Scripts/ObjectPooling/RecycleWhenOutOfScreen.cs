using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class RecycleWhenOutOfScreen<T> : Behaviour, IUpdatable
        where T : GameObject
    {
        private T toPool;
        private Action<T> onRecycle;

        public RecycleWhenOutOfScreen(T toPool, Action<T> onRecycle = null)
        {
            this.toPool = toPool;
            this.onRecycle = onRecycle;
        }
        void IUpdatable.Update()
        {
            if (Screen.IsOutOfScreen(this.Owner.Transform.Position))
            {
                Pool<T>.RecycleInstance(toPool, onRecycle);
            }
        }
    }
}
