using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using OpenTK;
using Aiv.Fast2D;

namespace BehaviourEngine.Example
{
    public class CircularCollisionDebugger : Behaviour, IStartable
    {
        private CircleCollider2D collider;
        private SpriteRenderer renderer;

        private int triggerCount;

        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            collider = Owner.GetBehaviour<CircleCollider2D>();
            collider.TriggerEnter += OnTriggerEnter;
            collider.TriggerExit += OnTriggerExit;

            renderer = Owner.GetBehaviour<SpriteRenderer>();
        }

        private void OnTriggerEnter(Collider2D other)
        {
            triggerCount++;
            renderer.Sprite.SetAdditiveTint(1f, -1f, 0f, 0f);
        }
        private void OnTriggerExit(Collider2D other)
        {
            if(--triggerCount == 0)
                renderer.Sprite.SetAdditiveTint(-1f, +1f, 0f, 0f);

        }
    }
}
