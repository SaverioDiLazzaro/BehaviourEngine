using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    public class Sensor : Behaviour, IStartable
    {
        private Collider2D collider;
        private SpriteRenderer renderer;
        private int triggerCount;

        bool IStartable.IsStarted { get; set; }
        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<Collider2D>();
            renderer = Owner.GetBehaviour<SpriteRenderer>();

            collider.TriggerEnter += OnTriggerEnter;
            collider.TriggerExit  += OnTriggerExit;
        }
        private void OnTriggerEnter(Collider2D other)
        {
            triggerCount++;
            if(triggerCount > 0)
                renderer.Sprite.SetAdditiveTint(1f, -1f, 0f, 0f);
        }
        private void OnTriggerExit(Collider2D other)
        {
            triggerCount--;
            if (triggerCount == 0)
                renderer.Sprite.SetAdditiveTint(-1f, 1f, 0f, 0f);
        }
    }
}
