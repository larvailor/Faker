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
        public void ClassWithOnlyBytes()
        {
            Faker faker = new Faker();
            OnlyBytes onlyBytes = faker.Create<OnlyBytes>();
            Assert.IsTrue(onlyBytes.x != 0);
            Assert.IsTrue(onlyBytes.y != 0);
            Assert.IsTrue(onlyBytes.z != 0);
        }



        [TestMethod]
        public void ClassWithOnlyInt()
        {
            Faker faker = new Faker();
            OnlyInt onlyInt = faker.Create<OnlyInt>();
            Assert.IsTrue(onlyInt.x != 0);
            Assert.IsTrue(onlyInt.y != 0);
            Assert.IsTrue(onlyInt.z != 0);
        }



        [TestMethod]
        public void ClassWithOnlyShort()
        {
            Faker faker = new Faker();
            OnlyShort onlyShort = faker.Create<OnlyShort>();
            Assert.IsTrue(onlyShort.x != 0);
            Assert.IsTrue(onlyShort.y != 0);
            Assert.IsTrue(onlyShort.z != 0);
        }



        [TestMethod]
        public void ClassWithAllTypes()
        {
            Faker faker = new Faker();
            AllTypes allTypes = faker.Create<AllTypes>();
            Assert.IsTrue(allTypes.X != 0);
            Assert.IsTrue(allTypes.Y != 0);
            Assert.IsTrue(allTypes.Z != 0);
        }



        [TestMethod]
        public void ClassWithInnerClass()
        {
            Faker faker = new Faker();
            TwoClasses twoClasses = faker.Create<TwoClasses>();
            Assert.IsTrue(twoClasses.x != 0);
            Assert.IsTrue(twoClasses.allTypes.X != 0);
            Assert.IsTrue(twoClasses.allTypes.Y != 0);
            Assert.IsTrue(twoClasses.allTypes.Z != 0);

        }



        [TestMethod]
        public void ClassWithOnlyFloat()
        {
            Faker faker = new Faker();
            OnlyFloat onlyFloat = faker.Create<OnlyFloat>();
            Assert.IsTrue(onlyFloat.X != 0);
            Assert.IsTrue(onlyFloat.Y != 0);
        }
    }
}
