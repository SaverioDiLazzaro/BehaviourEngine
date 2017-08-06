using System;
using System.Collections.Generic;

using OpenTK;

namespace BehaviourEngine
{
    public class GameObject
    {
        public uint Layer = LayerManager.DefaultLayer;
        public Transform Transform;
        public bool Active;

        public bool IsSpawned { get; private set; }

        private List<Behaviour> behaviours;

        public GameObject()
        {
            this.behaviours = new List<Behaviour>();
            this.Transform = new Transform();
            this.AddBehaviour(this.Transform);
        }

        public T AddBehaviour<T>(T behaviour) where T : Behaviour
        {
            behaviour.SetOwner(this);
            this.behaviours.Add(behaviour);

            if (this.IsSpawned)
            {
                Engine.Add(behaviour);
            }

            return behaviour;
        }

        public T GetBehaviour<T>() where T : Behaviour
        {
            for (int i = 0; i < behaviours.Count; i++)
            {
                if (behaviours[i] is T)
                {
                    return behaviours[i] as T;
                }
            }
            return null;
        }

        public Behaviour[] GetAllBehaviours()
        {
            Behaviour[] array = new Behaviour[behaviours.Count];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = behaviours[i];
            }
            return array;
        }
        public static GameObject Spawn(GameObject gameObject)
        {
            return gameObject.Spawn();
        }
        public static GameObject Spawn(GameObject gameObject, Vector2 position)
        {
            gameObject.Transform.Position = position;

            return GameObject.Spawn(gameObject);
        }
        public static GameObject Spawn(GameObject gameObject, Vector2 position, float eulerRotation)
        {
            gameObject.Transform.Position = position;
            gameObject.Transform.EulerRotation = eulerRotation;

            return GameObject.Spawn(gameObject);
        }
        private GameObject Spawn()
        {
            this.IsSpawned = true;
            this.Active = true;

            for (int i = 0; i < behaviours.Count; i++)
            {
                Engine.Add(behaviours[i]);
            }

            return this;
        }
    }
}