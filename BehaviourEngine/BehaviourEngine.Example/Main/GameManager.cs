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
            GameObject box = new Box(new Vector2(10f, 0.5f), new Vector2(1f, 1f));
            box.AddBehaviour(new Rotator());
            box.AddBehaviour(new PositionRenderer());
            box.AddBehaviour(new Rigidbody2D());

            //Box02
            GameObject box2 = new Box(new Vector2(14f, 10f), new Vector2(3f, 3f));
            box2.AddBehaviour(new ParentSwitch(box.Transform));
            box2.AddBehaviour(new PositionRenderer());
            box2.AddBehaviour(
            new Rotator()
            {
                LeftKey = KeyCode.Left,
                RightKey = KeyCode.Right
            });

            GameObject boxGround = new Box(new Vector2(10f, 20f), new Vector2(10f, 10f));
            boxGround.AddBehaviour(new PositionRenderer());

            //Circle01
            GameObject circle = new Circle(new Vector2(3f, 0f), 2f);
            //circle.AddBehaviour(new Rigidbody2D());

            circle.AddBehaviour(new PositionRenderer());
            circle.AddBehaviour(new ParentSwitch(box2.Transform));
            circle.GetBehaviour<Collider2D>().CollisionMode = CollisionMode.Trigger;


            TextureManager.AddTexture("mario", new Texture("Assets/mario.png"));
            box.AddBehaviour(new SpriteRenderer(TextureManager.GetTexture("mario")));


            //GameObject x = new GameObject();
            //LineRenderer line = new LineRenderer(1f, 1f, 2f, 2f, 1f / Graphics.Instance.Window.CurrentOrthoGraphicSize)
            //{
            //    Color = new Vector4(0f, 1f, 0f, 1f)
            //};
            //x.AddBehaviour(line);
            //GameObject.Spawn(x);
        }

        public static void Update()
        {
            Engine.Run();
        }
    }
}
