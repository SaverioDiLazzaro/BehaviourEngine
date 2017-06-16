using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using Aiv.Fast2D;
using OpenTK;
using System.Diagnostics;

namespace BehaviourEngine.Example
{
    public static class GameManager
    {
        public static void Init()
        {
            Window window = new Window(800, 600, "text");
            window.SetDefaultOrthographicSize(20f);

            Engine.Init(window);

            TextureManager.AddTexture("greencircle", new Texture("Assets/greencircle.png"));

            RectangularObject shape = new RectangularObject(new Vector2(3f, 1f), new Vector2(3f, 1f));
            RectangularObject shape2 = new RectangularObject(new Vector2(1f, 1f), new Vector2(1f, 3f));

            CircularObject shape3 = new CircularObject(new Vector2(5f, 5f), 1f);
            CircularObject shape4 = new CircularObject(new Vector2(11f, 1f), 0.5f);
            CircularObject shape5 = new CircularObject(new Vector2(7f, 7f), 2f);

            Rigidbody2D rigidbody = new Rigidbody2D()
            {
                IsGravityAffected = true,
                LinearFriction = 0f
            };
            shape4.AddBehaviour(rigidbody);
        }

        public static void Update()
        {
            Engine.Run();
        }
    }
}
