using System;

using Aiv.Fast2D;
using OpenTK;

namespace BehaviourEngine.Example
{
    public class Game
    {
        public static void Init()
        {
            #region Engine Setup
            Window window = new Window(800, 600, "PunksVSZombies");
            window.SetDefaultOrthographicSize(10f);

            Engine.Init(window);
            #endregion

            #region Physics Setup
            Physics.Instance.Gravity *= 2f;

            //Player collides with Wall
            LayerManager.AddLayer((uint)CollisionLayer.Hero, (uint)CollisionLayer.Wall);

            //Enemy collides with Wall & Bullet
            LayerManager.AddLayer((uint)CollisionLayer.Enemy, (uint)CollisionLayer.Wall + (uint)CollisionLayer.Bullet);
            #endregion

            #region Textures
            //Load Textures
            TextureManager.AddTexture("background", new Texture("Assets/Background.png"));
            TextureManager.AddTexture("platforms", new Texture("Assets/Platforms.png"));
            TextureManager.AddTexture("hero", new Texture("Assets/Hero.png"));
            TextureManager.AddTexture("zombie", new Texture("Assets/Zombie.png"));
            TextureManager.AddTexture("gun", new Texture("Assets/Gun.png"));
            TextureManager.AddTexture("bullet", new Texture("Assets/Bullet.png"));
            #endregion

            #region Audio
            AudioManager.AddAudioClip("shoot", new AudioClip("Assets/Shoot.wav"));
            AudioManager.AddAudioClip("bgmusic", new AudioClip("Assets/BgMusic.wav"));
            #endregion

            #region BgMusic
            GameObject bgMusic = new GameObject();
            AudioSource source = new AudioSource();
            source.AudioClip = AudioManager.GetAudioClip("bgmusic");
            source.Play(true);
            bgMusic.AddBehaviour(source);
            GameObject.Spawn(bgMusic);
            #endregion

            #region Pool Registrations
            Pool<Bullet>.Register(() => new Bullet()/*, 100*/);
            Pool<Zombie>.Register(() => new Zombie()/*, 100*/);
            #endregion

            #region Background (Graphics)
            //Background
            GameObject background = new GameObject();
            background.Transform.Scale = new Vector2(window.CurrentOrthoGraphicSize * window.aspectRatio, window.CurrentOrthoGraphicSize);

            SpriteRenderer backgroundRenderer = new SpriteRenderer(TextureManager.GetTexture("background"));
            backgroundRenderer.RenderOffset = (int)RenderLayer.Background;
            backgroundRenderer.Sprite.pivot = Vector2.Zero;
            background.AddBehaviour(backgroundRenderer);

            GameObject.Spawn(background);
            #endregion

            #region Platforms (Graphics)
            //Platforms
            GameObject platforms = new GameObject();
            platforms.Transform.Scale = new Vector2(window.CurrentOrthoGraphicSize * window.aspectRatio, window.CurrentOrthoGraphicSize);

            SpriteRenderer platformsRenderer = new SpriteRenderer(TextureManager.GetTexture("platforms"));
            platformsRenderer.RenderOffset = (int)RenderLayer.Platforms;
            platformsRenderer.Sprite.pivot = Vector2.Zero;
            platforms.AddBehaviour(platformsRenderer);

            GameObject.Spawn(platforms);
            #endregion

            #region LevelColliders

            //center
            GameObject.Spawn(new Wall(new Vector2(5.66f, 0.66f)), new Vector2(6.66f, 2.8f));
            //top sx
            GameObject.Spawn(new Wall(new Vector2(5.8f, 0.66f)), new Vector2(2.9f, 0.33f));
            //top dx
            GameObject.Spawn(new Wall(new Vector2(5.8f, 0.66f)), new Vector2(10.44f, 0.33f));
            //sx horizontal
            GameObject.Spawn(new Wall(new Vector2(3.4f, 0.66f)), new Vector2(1.7f, 4.68f));
            //dx horizontal
            GameObject.Spawn(new Wall(new Vector2(3.4f, 0.66f)), new Vector2(11.65f, 4.68f));
            //center sx
            GameObject.Spawn(new Wall(new Vector2(2.9f, 0.66f)), new Vector2(4.15f, 6.55f));
            //center dx
            GameObject.Spawn(new Wall(new Vector2(2.9f, 0.66f)), new Vector2(9.2f, 6.55f));
            //sx
            GameObject.Spawn(new Wall(new Vector2(0.63f, 10f)), new Vector2(0.25f, 5f));
            //dx
            GameObject.Spawn(new Wall(new Vector2(0.63f, 10f)), new Vector2(13.05f, 5f));
            //bottom sx
            GameObject.Spawn(new Wall(new Vector2(2.48f, 2f)), new Vector2(1.24f, 9.1f));
            //bottom dx
            GameObject.Spawn(new Wall(new Vector2(2.48f, 2f)), new Vector2(12.1f, 9.1f));
            //bottom center
            GameObject.Spawn(new Wall(new Vector2(2.3f, 2f)), new Vector2(6.66f, 9.1f));
            //bottom
            GameObject.Spawn(new Wall(new Vector2(5.6f, 1.5f)), new Vector2(6.66f, 9.5f));


            #endregion

            #region Hero
            //Hero
            Vector2 size = Vector2.One * 0.75f;

            GameObject hero = new GameObject();
            hero.Layer = (uint)CollisionLayer.Hero;

            hero.Transform.Scale = size;

            SpriteRenderer heroRenderer = new SpriteRenderer(TextureManager.GetTexture("hero"));
            heroRenderer.RenderOffset = (int)RenderLayer.Hero;
            hero.AddBehaviour(heroRenderer);

            Move move = new Move();
            hero.AddBehaviour(move);

            Jump jump = new Jump();
            hero.AddBehaviour(jump);

            Sensor sensor = new Sensor();
            hero.AddBehaviour(sensor);

            FlipAtMousePosition flipAtMousePosition = new FlipAtMousePosition();
            hero.AddBehaviour(flipAtMousePosition);

            Rigidbody2D heroRigidbody = new Rigidbody2D();
            hero.AddBehaviour(heroRigidbody);

            BoxCollider2D heroCollider = new BoxCollider2D(size);
            hero.AddBehaviour(heroCollider);

            BoxCollider2DRenderer heroColliderRenderer = new BoxCollider2DRenderer();
            heroColliderRenderer.RenderOffset = (int)RenderLayer.Collider;
            hero.AddBehaviour(heroColliderRenderer);

            GameObject.Spawn(hero, new Vector2(6.66f, 0f));
            #endregion

            #region Gun
            GameObject gun = new GameObject();
            gun.Transform.Scale = new Vector2(0.8f, 0.5f);

            SpriteRenderer gunRenderer = new SpriteRenderer(TextureManager.GetTexture("gun"));
            gunRenderer.RenderOffset = (int)RenderLayer.Gun;
            gun.AddBehaviour(gunRenderer);

            GameObject.Spawn(gun, hero.Transform.Position + new Vector2(0.8f, 0.1f));
            gun.Transform.SetParent(hero.Transform);

            #endregion

            #region Gun Locator
            GameObject gunLocator = new GameObject();

            PositionRenderer gunLocatorRenderer = new PositionRenderer();
            gunLocator.AddBehaviour(gunLocatorRenderer);

            GameObject.Spawn(gunLocator, gun.Transform.Position + new Vector2(0.5f, -0.25f));

            gunLocator.Transform.SetParent(gun.Transform);
            #endregion

            //Add shoot behaviour to hero
            Shoot shoot = new Shoot(gunLocator.Transform);
            hero.AddBehaviour(shoot);

            #region UnitSpawner
            ZombieSpawner spawner = new ZombieSpawner();
            spawner.AddSpawnPoint(new SpawnPoint() { Position = new Vector2(1f, -2f), Direction = Vector2.UnitX });
            spawner.AddSpawnPoint(new SpawnPoint() { Position = new Vector2(10f, -2f), Direction = -Vector2.UnitX });
            GameObject.Spawn(spawner);
            #endregion
        }

        public static void Run()
        {
            Engine.Run();
        }
    }
}