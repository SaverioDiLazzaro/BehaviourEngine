using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BehaviourEngine;
using Aiv.Fast2D;
using OpenTK;


namespace BehaviourEngine.Example
{
    public static class GameManager
    {
        public static void Init()
        {
            Window window = new Window(800, 600, "text");
            window.SetDefaultOrthographicSize(20f);

            Engine.Init(window);

            //STUFF
            GameObject box = new Box(new Vector2(1f, 1f), new Vector2(1f, 1f));
            GameObject circle = new Circle(new Vector2(3f, 3f), 1f);
            GameObject circle2 = new Circle(new Vector2(3f, 0f), 2f);

            circle2.AddBehaviour(new Rigidbody2D()
            {
                IsGravityAffected = true
            });
        }

        public static void Update()
        {
            Engine.Run();
        }
    }
}
