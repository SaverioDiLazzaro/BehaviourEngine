using OpenTK;
using System;
using System.Collections.Generic;

using EngineBuilder.Core;
using EngineBuilder.Shared;

namespace BehaviourEngine
{
    sealed public class Physics : System<IPhysical>
    {
        public Vector2 Gravity = new Vector2(0f, 9.81f);

        //TODO: implement
        //public float FixedDeltaTime = 0.02f;

        private List<Collider2D> colliders;
        private List<CollisionPair2D> collisionPairs;

        #region Internal Stuff
        internal void Init()
        {
            colliders = new List<Collider2D>();
            collisionPairs = new List<CollisionPair2D>();
        }
        #endregion

        #region Singleton
        public static Physics Instance;
        static Physics()
        {
            Instance = new Physics();
        }
        private Physics() { }
        #endregion

        #region System<T>
        public override void Update()
        {
            base.Update();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].PhysicalUpdate();
                }
            }

            CheckCollisions();
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < collisionPairs.Count; i++)
            {
                if (collisionPairs[i].PairEnabled)
                {
                    if (collisionPairs[i].collider1 is BoxCollider2D && collisionPairs[i].collider2 is BoxCollider2D)
                    {
                        if (this.Intersect(collisionPairs[i].collider1 as BoxCollider2D, collisionPairs[i].collider2 as BoxCollider2D))
                        {
                            collisionPairs[i].Trigger(true);
                        }
                        else
                        {
                            collisionPairs[i].Trigger(false);
                        }
                    }

                    else if (collisionPairs[i].collider1 is CircleCollider2D && collisionPairs[i].collider2 is CircleCollider2D)
                    {
                        if (this.Intersect(collisionPairs[i].collider1 as CircleCollider2D, collisionPairs[i].collider2 as CircleCollider2D))
                        {
                            collisionPairs[i].Trigger(true);
                        }
                        else
                        {
                            collisionPairs[i].Trigger(false);
                        }
                    }

                    else if (collisionPairs[i].collider1 is CircleCollider2D && collisionPairs[i].collider2 is BoxCollider2D)
                    {
                        if (this.Intersect(collisionPairs[i].collider1 as CircleCollider2D, collisionPairs[i].collider2 as BoxCollider2D))
                        {
                            collisionPairs[i].Trigger(true);
                        }
                        else
                        {
                            collisionPairs[i].Trigger(false);
                        }
                    }

                    else if (collisionPairs[i].collider1 is BoxCollider2D && collisionPairs[i].collider2 is CircleCollider2D)
                    {
                        if (this.Intersect(collisionPairs[i].collider2 as CircleCollider2D, collisionPairs[i].collider1 as BoxCollider2D))
                        {
                            collisionPairs[i].Trigger(true);
                        }
                        else
                        {
                            collisionPairs[i].Trigger(false);
                        }
                    }
                }
            }
        }

        public override void Add(IEntity physicalObject)
        {
            base.Add(physicalObject);

            Collider2D collider = physicalObject as Collider2D;

            if (collider != null)
            {
                if (colliders.Count > 0)
                {
                    for (int i = 0; i < colliders.Count; i++)
                    {
                        collisionPairs.Add(new CollisionPair2D(collider, colliders[i]));
                    }
                }

                colliders.Add(collider);
            }
        }
        #endregion

        #region Algorythms (Trigger Detection)
        internal bool Intersect(BoxCollider2D collider1, BoxCollider2D collider2)
        {
            if (collider1.ExtentMin.X < collider2.ExtentMax.X &&
                collider1.ExtentMax.X > collider2.ExtentMin.X &&
                collider1.ExtentMin.Y < collider2.ExtentMax.Y &&
                collider1.ExtentMax.Y > collider2.ExtentMin.Y)
            {
                return true;
            }
            return false;
        }

        internal bool Intersect(CircleCollider2D collider1, CircleCollider2D collider2)
        {
            Vector2 distance = collider1.Center - collider2.Center;
            if (distance.Length <= collider1.Radius + collider2.Radius)
            {
                return true;
            }
            return false;
        }

        internal bool Intersect(CircleCollider2D circle, BoxCollider2D rectangle)
        {
            float xMin = Math.Min(rectangle.ExtentMax.X, circle.Center.X);
            float xNearest = Math.Max(rectangle.ExtentMin.X, xMin);

            float yMin = Math.Min(rectangle.ExtentMax.Y, circle.Center.Y);
            float yNearest = Math.Max(rectangle.ExtentMin.Y, yMin);

            Vector2 nearest = new Vector2(xNearest, yNearest);
            Vector2 distance = nearest - circle.Center;
            if (distance.Length < circle.Radius)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}