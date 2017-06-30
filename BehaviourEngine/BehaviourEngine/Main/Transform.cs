using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine
{
    public class Transform : Behaviour, IUpdatable
    {
        public Transform Parent { get; protected set; }

        #region Position
        private Vector2 position;
        private Vector2 positionOffset;
        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                if (Parent != null)
                {
                    positionOffset = this.Position - Parent.Position;
                }
            }
        }
        //public Vector2 LocalPosition
        //{
        //    get
        //    {
        //        if (Parent != null)
        //        {
        //            return this.Position - Parent.Position;
        //        }
        //        return Position;
        //    }
        //    set
        //    {
        //        Position += value - LocalPosition;
        //    }
        //}
        #endregion

        #region Rotation
        //private float rotation;
        private float rotationOffset;
        private float localRotationOffset;
        public float Rotation;
        public float EulerRotation
        {
            get
            {
                //deg
                return Rotation.RadToDeg();
            }
            set
            {
                //rad
                Rotation = value.DegToRad();
            }
        }
        #endregion

        public Vector2 Scale = Vector2.One;

        public void SetParent(Transform parent)
        {
            this.Parent = parent;

            if (parent != null)
            {
                positionOffset = this.Position - parent.Position;

                rotationOffset = parent.Rotation;
                localRotationOffset = this.Rotation;
            }
        }

        void IUpdatable.Update()
        {
            if (Parent != null)
            {
                //Change Child Position
                this.Position = Parent.Position + positionOffset;

                //Change Child Rotation
                float angle = Parent.Rotation - rotationOffset;

                float newX = this.Parent.position.X + (positionOffset.X) * (float)Math.Cos(angle) - (positionOffset.Y) * (float)Math.Sin(angle);
                float newY = this.Parent.position.Y + (positionOffset.X) * (float)Math.Sin(angle) + (positionOffset.Y) * (float)Math.Cos(angle);

                position = new Vector2(newX, newY);

                Console.WriteLine("OLD: " + this.Rotation.RadToDeg() + " NEW: " + angle.RadToDeg());

                this.Rotation = angle + localRotationOffset;

                //Change Scale
            }
        }
    }
}
