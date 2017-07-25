using System;
using NUnit.Framework;

namespace EngineBuilder.Tests
{
    [TestFixture]
    public class SystemTester
    {
        #region SetUp
        TestEntityA entityA;
        TestEntityB entityB;

        TestSystemA systemA;
        TestSystemB systemB;

        Random random;

        [SetUp]
        public void SetUp()
        {
            entityA = new TestEntityA();
            entityB = new TestEntityB();

            systemA = new TestSystemA();
            systemB = new TestSystemB();

            random = new Random();
        }
        #endregion

        #region DebugItems
        [Test]
        public void TestGreenLightDebugItems()
        {
            //add random number of elements to the system
            int elementsToAdd = random.Next(1, 100);
            for (int i = 0; i < elementsToAdd; i++)
            {
                systemA.Add(new TestEntityA());
            }

            //check num of elements before update
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //updates
            systemA.Update();

            //check num of elements after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(elementsToAdd));
        }

        [Test]
        public void TestRedLightDebugItems()
        {
            //add random number of elements to the system
            int elementsToAdd = random.Next(1, 100);
            for (int i = 0; i < elementsToAdd; i++)
            {
                systemA.Add(new TestEntityA());
            }

            //check num of elements before update
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(elementsToAdd));

            //updates
            systemA.Update();

            //check num of elements after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));
        }
        #endregion

        #region Add
        [Test]
        public void TestGreenLightAdd()
        {
            //add elements
            systemA.Add(entityA);

            //test number of items (before the system updates)
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(1));

            //test equality between object references
            Assert.That(items[0], Is.EqualTo(entityA));
        }

        [Test]
        public void TestRedLightAdd()
        {
            //add elements
            systemA.Add(entityA);
            TestEntityA otherEntityA = new TestEntityA();

            //test number of items (before the system updates)
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(1));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //test equality between object references
            Assert.That(items[0], Is.Not.EqualTo(otherEntityA));
        }
        #endregion

        #region Remove
        [Test]
        public void TestGreenLightRemove()
        {
            //add elements
            systemA.Add(this.entityA);
            TestEntityA entityA = new TestEntityA();
            systemA.Add(entityA);

            //test number of items (before the system updates)
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(2));

            //remove one item
            systemA.Remove(this.entityA);

            //test number of items (after remove)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(2));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(1));

            //test equality between object references
            Assert.That(items[0], Is.EqualTo(entityA));
        }

        [Test]
        public void TestRedLightRemove()
        {
            //add elements
            systemA.Add(this.entityA);
            TestEntityA entityA = new TestEntityA();
            systemA.Add(entityA);

            //test number of items (before the system updates)
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(2));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //remove one item
            systemA.Remove(this.entityA);

            //test number of items (after remove)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //system updates
            systemA.Update();

            //test number of items (after the system updates)
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(2));

            //test equality between object references
            Assert.That(items[0], Is.Not.EqualTo(this.entityA));
        }
        #endregion

        #region UpdateOffset
        [Test]
        public void TestGreenLightUpdateOffset()
        {
            //randomize
            int rnd = random.Next(int.MinValue, int.MaxValue);

            //set property
            systemA.UpdateOffset = rnd;

            //get property
            Assert.That(systemA.UpdateOffset, Is.EqualTo(rnd));
        }
        [Test]
        public void TestGreenLightUpdateOffsetWithZero()
        {
            //set property
            systemA.UpdateOffset = 0;

            //get property
            Assert.That(systemA.UpdateOffset, Is.EqualTo(0));
        }
        [Test]
        public void TestGreenLightUpdateOffsetWithOne()
        {
            //set property
            systemA.UpdateOffset = 1;

            //get property
            Assert.That(systemA.UpdateOffset, Is.EqualTo(1));
        }

        [Test]
        public void TestRedLightUpdateOffset()
        {
            //set property
            systemA.UpdateOffset = int.MaxValue;

            //get property
            Assert.That(systemA.UpdateOffset, Is.Not.EqualTo(int.MinValue));
        }
        [Test]
        public void TestRedLightUpdateOffsetWithZero()
        {
            //set property
            systemA.UpdateOffset = 0;

            //get property
            Assert.That(systemA.UpdateOffset, Is.Not.EqualTo(1));
        }
        [Test]
        public void TestRedLightUpdateOffsetWithOne()
        {
            //set property
            systemA.UpdateOffset = 1;

            //get property
            Assert.That(systemA.UpdateOffset, Is.Not.EqualTo(0));
        }
        #endregion

        #region Update
        [Test]
        public void TestGreenLightUpdate()
        {
            //add one entity
            systemA.Add(new TestEntityA());

            //test before update
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(0));

            //update
            systemA.Update();

            //test after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(1));

            //add another entity
            systemA.Add(new TestEntityA());

            //test before update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(1));

            //update
            systemA.Update();

            //test after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.EqualTo(2));
        }

        [Test]
        public void TestRedLightUpdate()
        {
            //add one entity
            systemA.Add(new TestEntityA());

            //test before update
            ITestEntityA[] items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(1));

            //update
            systemA.Update();

            //test after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(0));

            //add another entity
            systemA.Add(new TestEntityA());

            //test before update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(2));

            //update
            systemA.Update();

            //test after update
            items = systemA.DebugItems();
            Assert.That(items.Length, Is.Not.EqualTo(1));
        }
        #endregion
    }
}
