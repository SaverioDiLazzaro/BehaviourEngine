using OpenTK;
using System;
using System.Collections.Generic;

using EngineBuilder;

namespace BehaviourEngine
{
    sealed public class Physics : System<IPhysical>
    {
        public Vector2 Gravity = new Vector2(0f, 9.81f);

        public float FixedDeltaTime = 0.016f;
        private float accumulator = 0f;

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
            accumulator += Time.DeltaTime;

            while (accumulator >= FixedDeltaTime)
            {
                accumulator -= FixedDeltaTime;
                Integrate();
            }
        }

        private void Integrate()
        {
            base.Update();

            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Enabled)
                {
                    items[i].PhysicalUpdate();
                }
            }

            CheckAndResolveCollisions();
        }

        private void CheckAndResolveCollisions()
        {
            for (int i = 0; i < collisionPairs.Count; i++)
            {
                if (collisionPairs[i].IsPairEnabled)
                {
                    switch (collisionPairs[i].PairCollisionMode)
                    {
                        case CollisionMode.Trigger:
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

                            break;

                        case CollisionMode.Collision:
                            if (LayerManager.CanCollide(collisionPairs[i]))
                            {
                                if (collisionPairs[i].collider1 is BoxCollider2D && collisionPairs[i].collider2 is BoxCollider2D)
                                {
                                    BoxCollider2D boxA = collisionPairs[i].collider1 as BoxCollider2D;
                                    BoxCollider2D boxB = collisionPairs[i].collider2 as BoxCollider2D;

                                    HitState hitState = AABBvsAABB(boxA, boxB);

                                    collisionPairs[i].Collision(hitState);

                                    if (collisionPairs[i].collisionPairState.stay)
                                    {
                                        ResolveCollision(boxA, boxB, hitState.normal);
                                    }
                                }
                            }

                            break;
                    }
                }
            }
        }

        public override void Add(IEntity physicalObject)
        {
            base.Add(physicalObject);

            if (physicalObject is Collider2D collider)
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
        internal bool Intersect(BoxCollider2D box1, BoxCollider2D box2)
        {
            return (box1.ExtentMin.X < box2.ExtentMax.X &&
                    box1.ExtentMax.X > box2.ExtentMin.X &&
                    box1.ExtentMin.Y < box2.ExtentMax.Y &&
                    box1.ExtentMax.Y > box2.ExtentMin.Y);
        }

        internal bool Intersect(CircleCollider2D circle1, CircleCollider2D circle2)
        {
            float r2 = (circle1.Radius + circle2.Radius) * (circle1.Radius + circle2.Radius);
            float x2 = (circle1.Center.X + circle2.Center.X) * (circle1.Center.X + circle2.Center.X);
            float y2 = (circle1.Center.Y + circle2.Center.Y) * (circle1.Center.Y + circle2.Center.Y);
            return r2 < x2 + y2;
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

        #region Algorythms (Collision Detection)
        private HitState AABBvsAABB(BoxCollider2D a, BoxCollider2D b)
        {
            HitState hitState = new HitState();

            //evaluate x axis
            float dx = b.Center.X - a.Center.X;
            //calculate distance along x axis
            float px = (b.HalfSize.X + a.HalfSize.X) - Math.Abs(dx);    //difference between the sum of radius and the absolute value of dx
            //check collision on x axis
            if (px <= 0f)
            {
                //no collision
                return hitState;
            }

            //evaluate y axis
            float dy = b.Center.Y - a.Center.Y;
            //calculate distance along y axis
            float py = (b.HalfSize.Y + a.HalfSize.Y) - Math.Abs(dy);    //difference between the sum of radius and the absolute value of dy
            //check collision on y axis
            if (py <= 0f)
            {
                //no collision
                return hitState;
            }

            // if code reaches this point, the boxes enter on collision
            hitState.hit = true;

            if (px < py)
            {
                //normal is on x axis
                int sx = Math.Sign(dx);
                hitState.normal = new Vector2(-sx, 0f);
            }
            else
            {
                //normal is on x axis
                int sy = Math.Sign(dy);
                hitState.normal = new Vector2(0f, -sy);
            }

            return hitState;
        }
        #endregion

        #region Algorythms (Collision Resolution)
        private void ResolveCollision(BoxCollider2D boxA, BoxCollider2D boxB, Vector2 normal)
        {
            ChangePosition(boxA, boxB, normal);

            //invert normal
            normal *= -1;

            ChangePosition(boxB, boxA, normal);
        }
        private void ChangePosition(BoxCollider2D boxA, BoxCollider2D boxB, Vector2 normal)
        {
            if (boxA.rigidbody != null)
            {
                //Stop rigidbody
                Vector2 position = boxA.Owner.Transform.Position;

                //hit from dx
                if (normal.X > 0f)
                {
                    boxA.rigidbody.Velocity.X = 0f;
                    position.X = boxB.ExtentMax.X + boxA.HalfSize.X;
                }

                //hit from sx
                if (normal.X < 0f)
                {
                    boxA.rigidbody.Velocity.X = 0f;
                    position.X = boxB.ExtentMin.X - boxA.HalfSize.X;
                }

                //hit from top
                if (normal.Y < 0f)
                {
                    boxA.rigidbody.Velocity.Y = 0f;
                    position.Y = boxB.ExtentMin.Y - boxA.HalfSize.Y;
                }

                //hit from bottom
                if (normal.Y > 0f)
                {
                    boxA.rigidbody.Velocity.Y = 0f;
                    position.Y = boxB.ExtentMax.Y + boxA.HalfSize.Y;
                }

                //change pos
                boxA.Owner.Transform.Position = position;
            }
        }
        #endregion
    }
}