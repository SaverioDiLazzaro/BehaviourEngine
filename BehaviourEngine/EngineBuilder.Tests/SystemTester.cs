using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using EngineBuilder.Core;
using EngineBuilder.Shared;

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

        [Test]
        public void TestGreenLightAdd()
        {
            system.Add(entity);
        }
    }
}
