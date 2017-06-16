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
    public class RectangularCollisionDebugger : Behaviour, IStartable, IDrawable
    {
        private BoxCollider2D RectangleCollider;
        private int triggerCount;
        public Vector3 DebugColor { get; set; }
        private Mesh mesh;

        public RectangularCollisionDebugger()
        {
            DebugColor = new Vector3(0f, 1f, 0f);
        }

        bool IStartable.IsStarted { get; set; }

        void IStartable.Start()
        {
            RectangleCollider = Owner.GetBehaviour<BoxCollider2D>();
            RectangleCollider.TriggerEnter += OnTriggerEnter;
            RectangleCollider.TriggerExit += OnTriggerExit;
        }

        private void OnTriggerEnter(Collider2D other)
        {
            triggerCount++;
            DebugColor = new Vector3(1f, 0f, 0f);
        }
        private void OnTriggerExit(Collider2D other)
        {
            if (--triggerCount == 0)
            {
                DebugColor = new Vector3(0f, 1f, 0f);

            }
        }

        public int RenderOffset { get; set; }
        void IDrawable.Draw()
        {
            Vector2 position = RectangleCollider.Position;
            Vector2 size = RectangleCollider.Size;

            mesh = new Mesh();
            mesh.v = new[]
            {
                position.X, position.Y,
                position.X + size.X, position.Y,
                position.X, position.Y + size.Y,
                position.X + size.X, position.Y,
                position.X, position.Y + size.Y,
                position.X + size.X, position.Y +size.Y
            };
            mesh.pivot = position;
            mesh.position = position;
            mesh.Update();

            mesh.DrawWireframe(DebugColor.X, DebugColor.Y, DebugColor.Z);
        }


    }
}
