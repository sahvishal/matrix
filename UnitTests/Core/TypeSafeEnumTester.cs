using System;
using Falcon.App.Core;
using HealthYes.Web.UnitTests.Fakes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core
{
    [TestFixture]
    public class TypeSafeEnumTester
    {
        [Test]
        public void ToStringReturnsName()
        {
            const string expectedName = "TestName";
            TypeSafeEnum typeSafeEnum = new FakeTypeSafeEnum(expectedName);
            Assert.AreEqual(expectedName, typeSafeEnum.Name, "ToString did not return Name.");
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorThrowsExceptionWhenGivenNullStringForName()
        {
            new FakeTypeSafeEnum(null);
        }
    }
}