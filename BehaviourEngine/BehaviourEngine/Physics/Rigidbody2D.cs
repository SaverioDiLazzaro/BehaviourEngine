﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using System.Diagnostics;

namespace BehaviourEngine
{
    public class Rigidbody2D : Behaviour, IUpdatable
    {
        public Vector2 Velocity;
        public bool IsGravityAffected;
        public float LinearFriction;

        void IUpdatable.Update()
        {
            if (IsGravityAffected)
            {
                this.AddForce(Physics.Gravity);
            }

            this.AddForce(-Velocity * LinearFriction);

            Owner.Transform.Position += Velocity * Time.DeltaTime;
        }

        public void AddForce(Vector2 force)
        {
            Velocity += force * Time.DeltaTime;
        }
    }
}
