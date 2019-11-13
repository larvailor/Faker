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
        }
    }
}
