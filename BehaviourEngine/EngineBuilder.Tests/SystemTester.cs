using NUnit.Framework;

namespace EngineBuilder.Tests
{
    #region Test Items
    public interface ITestEntity : IEntity { }
    public class EntityA : ITestEntity
    {
        public bool Enabled { get; set; }
    }
    
    public class SystemA : System<ITestEntity> { }
    #endregion

    [TestFixture]
    public class SystemTester
    {
        #region SetUp
        EntityA entity;
        SystemA system;

        [SetUp]
        public void SetUp()
        {
            entity = new EntityA();
            system = new SystemA();
        }
        #endregion

        #region Add
        [Test]
        public void TestGreenLightAdd()
        {
            //add elements
            system.Add(entity);

            //test number of items (before the system updates)
            ITestEntity[] items = system.GetItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //system updates
            system.Update();

            items = system.GetItems();
            //test number of items (after the system updates)
            Assert.That(items.Length, Is.EqualTo(1));

            //test equality between object references
            Assert.That(items[0], Is.EqualTo(entity));
        }

        [Test]
        public void TestRedLightAdd()
        {
            //add elements
            system.Add(entity);
            EntityA entityA = new EntityA();

            //test number of items (before the system updates)
            ITestEntity[] items = system.GetItems();
            Assert.That(items.Length, Is.Not.EqualTo(1));

            //system updates
            system.Update();

            items = system.GetItems();
            //test number of items (after the system updates)
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //test equality between object references
            Assert.That(items[0], Is.Not.EqualTo(entityA));
        }
        #endregion

        #region Remove
        [Test]
        public void TestGreenLightRemove()
        {
            //add elements
            system.Add(entity);
            EntityA entityA = new EntityA();
            system.Add(entityA);

            //test number of items (before the system updates)
            ITestEntity[] items = system.GetItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //system updates
            system.Update();

            //test number of items (after the system updates)
            items = system.GetItems();
            Assert.That(items.Length, Is.EqualTo(2));

            //remove one item
            system.Remove(entity);

            //test number of items (after remove)
            items = system.GetItems();
            Assert.That(items.Length, Is.EqualTo(2));

            //system updates
            system.Update();

            //test number of items (after the system updates)
            items = system.GetItems();
            Assert.That(items.Length, Is.EqualTo(1));

            //test equality between object references
            Assert.That(items[0], Is.EqualTo(entityA));
        }

        [Test]
        public void TestRedLightRemove()
        {
            //add elements
            system.Add(entity);
            EntityA entityA = new EntityA();
            system.Add(entityA);

            //test number of items (before the system updates)
            ITestEntity[] items = system.GetItems();
            Assert.That(items.Length, Is.Not.EqualTo(2));

            //system updates
            system.Update();

            //test number of items (after the system updates)
            items = system.GetItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //remove one item
            system.Remove(entity);

            //test number of items (after remove)
            items = system.GetItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //system updates
            system.Update();

            //test number of items (after the system updates)
            items = system.GetItems();
            Assert.That(items.Length, Is.Not.EqualTo(2));

            //test equality between object references
            Assert.That(items[0], Is.Not.EqualTo(entity));
        }
        #endregion
    }
}
