using System;
using NUnit.Framework;

namespace EngineBuilder.Tests
{
    [TestFixture]
    public class EngineTester
    {
        #region SetUp
        TestEntityA entityA;
        TestEntityB entityB;

        TestSystemA systemA;
        TestSystemB systemB;

        TestEngine engine;

        Random random;

        [SetUp]
        public void SetUp()
        {
            entityA = new TestEntityA();
            entityB = new TestEntityB();

            systemA = new TestSystemA();
            systemB = new TestSystemB();

            engine = new TestEngine();

            random = new Random();
        }
        #endregion

        #region IsRunning
        [Test]
        public void TestGreenLightIsRunning()
        {
            //test in the beginning
            Assert.That(engine.IsRunning, Is.EqualTo(false));

            //change value
            engine.IsRunning = true;

            //test it after value changed
            Assert.That(engine.IsRunning, Is.EqualTo(true));
        }
        [Test]
        public void TestRedLightIsRunning()
        {
            //test in the beginning
            Assert.That(engine.IsRunning, Is.Not.EqualTo(true));

            //change value
            engine.IsRunning = true;

            //test it after value changed
            Assert.That(engine.IsRunning, Is.Not.EqualTo(false));
        }
        #endregion

        #region Run
        [Test]
        public void TestGreenLightRun()
        {
            //call method
            engine.Run();

            //assert engine isrunning
            Assert.That(engine.IsRunning, Is.EqualTo(true));
        }

        [Test]
        public void TestRedLightRun()
        {
            //call method
            engine.Run();

            //assert engine isrunning
            Assert.That(engine.IsRunning, Is.Not.EqualTo(false));
        }
        #endregion

        #region DebugSystems and SystemAdd
        [Test]
        public void TestGreenLightDebugSystems()
        {
            //beginning assertion
            ISystem[] systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.EqualTo(0));

            //initialize with a system
            engine.Init(systemA);

            //verify after add
            systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.EqualTo(1));

            //test equality between systems
            Assert.That(systemA, Is.EqualTo(systems[0]));
        }

        [Test]
        public void TestRedLightDebugSystems()
        {
            //beginning assertion
            ISystem[] systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.Not.EqualTo(1));

            //initialize with a system
            engine.Init(systemA);

            //verify after add
            systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.Not.EqualTo(0));

            //initialize with another system
            engine.Init(systemB);

            //verify after add
            systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.Not.EqualTo(1));

            //test inequality between systems
            Assert.That(systemA, Is.Not.EqualTo(systems[1]));
        }
        #endregion

        #region AddEntity
        [Test]
        public void TestGreenLightAddEntity()
        {
            //init engine with two systems
            engine.Init(systemA, systemB);

            //assert number of systems
            ISystem[] systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.EqualTo(2));

            //entity is enabled?
            Assert.That(entityA.Enabled, Is.EqualTo(false));
            //add entity
            engine.Add(entityA);
            //entity is enabled?
            Assert.That(entityA.Enabled, Is.EqualTo(false));

            //entity is enabled?
            Assert.That(entityB.Enabled, Is.EqualTo(false));
            //add entity
            engine.Add(entityB);
            //entity is enabled?
            Assert.That(entityB.Enabled, Is.EqualTo(false));

            //debug entities in system A
            IEntity[] entitiesA = systemA.DebugItems();
            Assert.That(entitiesA.Length, Is.EqualTo(0));

            //debug entities in system B
            IEntity[] entitiesB = systemB.DebugItems();
            Assert.That(entitiesB.Length, Is.EqualTo(0));

            //engine run (one step)
            engine.Run();

            //entity is enabled?
            Assert.That(entityA.Enabled, Is.EqualTo(true));

            //entity is enabled?
            Assert.That(entityB.Enabled, Is.EqualTo(true));

            //debug entities in system A
            entitiesA = systemA.DebugItems();
            Assert.That(entitiesA.Length, Is.EqualTo(1));

            //debug entities in system B
            entitiesB = systemB.DebugItems();
            Assert.That(entitiesB.Length, Is.EqualTo(1));
        }

        [Test]
        public void TestRedLightAddEntity()
        {
            //init engine with two systems
            engine.Init(systemA, systemB);

            //assert number of systems
            ISystem[] systems = engine.DebugSystems();
            Assert.That(systems.Length, Is.Not.EqualTo(0));

            //entity is enabled?
            Assert.That(entityA.Enabled, Is.Not.EqualTo(true));
            //add entity
            engine.Add(entityA);
            //entity is enabled?
            Assert.That(entityA.Enabled, Is.Not.EqualTo(true));

            //entity is enabled?
            Assert.That(entityB.Enabled, Is.Not.EqualTo(true));
            //add entity
            engine.Add(entityB);
            //entity is enabled?
            Assert.That(entityB.Enabled, Is.Not.EqualTo(true));

            //debug entities in system A
            IEntity[] entitiesA = systemA.DebugItems();
            Assert.That(entitiesA.Length, Is.Not.EqualTo(1));

            //debug entities in system B
            IEntity[] entitiesB = systemB.DebugItems();
            Assert.That(entitiesB.Length, Is.Not.EqualTo(1));

            //engine run (ONE STEP)
            engine.Run();

            //entity is enabled?
            Assert.That(entityA.Enabled, Is.Not.EqualTo(false));

            //entity is enabled?
            Assert.That(entityB.Enabled, Is.Not.EqualTo(false));

            //debug entities in system A
            entitiesA = systemA.DebugItems();
            Assert.That(entitiesA.Length, Is.Not.EqualTo(2));

            //debug entities in system B
            entitiesB = systemB.DebugItems();
            Assert.That(entitiesB.Length, Is.Not.EqualTo(2));
        }
        #endregion

        #region RemoveEntity
        [Test]
        public void TestGreenLightRemoveEntity()
        {
            //init engine with two systems
            engine.Init(systemA, systemB);
            
            //add entity
            engine.Add(entityA);
            
            //add entity
            engine.Add(entityB);

            //engine run (one step)
            engine.Run();

            //until here is the same code of AddEntity
            //then...

            //remove one item from engine
            engine.Remove(entityA);

            //nothing changed
            IEntity[] entititesA = systemA.DebugItems();
            Assert.That(entititesA.Length, Is.EqualTo(1));

            IEntity[] entititesB = systemB.DebugItems();
            Assert.That(entititesB.Length, Is.EqualTo(1));

            //engine run (one step)
            engine.Run();

            //systemA changed, systemB does not
            entititesA = systemA.DebugItems();
            Assert.That(entititesA.Length, Is.EqualTo(0));
            entititesB = systemB.DebugItems();
            Assert.That(entititesB.Length, Is.EqualTo(1));
        }

        [Test]
        public void TestRedLightRemoveEntity()
        {

            //init engine with two systems
            engine.Init(systemA, systemB);

            //add entity
            engine.Add(entityA);

            //add entity
            engine.Add(entityB);

            //engine run (one step)
            engine.Run();

            //until here is the same code of AddEntity
            //then...

            //remove one item from engine
            engine.Remove(entityA);

            //nothing changed
            IEntity[] entititesA = systemA.DebugItems();
            Assert.That(entititesA.Length, Is.Not.EqualTo(0));

            IEntity[] entititesB = systemB.DebugItems();
            Assert.That(entititesB.Length, Is.Not.EqualTo(0));

            //engine run (one step)
            engine.Run();

            //systemA changed, systemB does not
            entititesA = systemA.DebugItems();
            Assert.That(entititesA.Length, Is.Not.EqualTo(1));
            entititesB = systemB.DebugItems();
            Assert.That(entititesB.Length, Is.Not.EqualTo(0));
        }
        #endregion
    }
}
