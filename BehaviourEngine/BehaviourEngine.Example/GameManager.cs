﻿using System;
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

            //Box01
            GameObject box      = new Box(new Vector2(10f, 10f), new Vector2(1f, 1f));
            box.AddBehaviour(
            new Rotator()
            {
                RotationSpeed = 50
            });
            box.AddBehaviour(new PositionRenderer());
            box.GetBehaviour<BoxCollider2DRenderer>().Sprite.pivot = Vector2.One * 0.5f;

            //Box02
            GameObject box2 = new Box(new Vector2(14f, 10f), new Vector2(3f, 3f));
            box2.AddBehaviour(new ParentSwitch(box.Transform));
            box2.AddBehaviour(new PositionRenderer());
            box2.GetBehaviour<BoxCollider2DRenderer>().Sprite.pivot = Vector2.One * 0.5f;

            //Circle01
            GameObject circle = new Circle(new Vector2(3f, 0f), 2f);
            circle.AddBehaviour(new Rigidbody2D()
            {
                IsGravityAffected = true
            });
            circle.AddBehaviour(new PositionRenderer());
            circle.GetBehaviour<CircleCollider2DRenderer>().Sprite.pivot = Vector2.One * 0.5f;
        }

        public static void Update()
        {
            Engine.Run();
        }
    }
}
