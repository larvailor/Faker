using System;
using FakerLib;
using FakerTests.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FakerTests
{
    [TestClass]
    public class FakerTests
    {
        [TestMethod]
        public void GenerateClassWithOnlyBytes()
        {
            Faker faker = new Faker();
            OnlyBytes onlyBytes = faker.Create<OnlyBytes>();
            Assert.IsTrue(onlyBytes.x != 0);
            Assert.IsTrue(onlyBytes.y != 0);
            Assert.IsTrue(onlyBytes.z != 0);
        }
    }
}
