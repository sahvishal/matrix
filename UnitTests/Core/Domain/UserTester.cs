using Falcon.App.Core.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Domain
{
    [TestFixture]
    public class UserTester
    {
        [Test]
        public void NameAsStringReturnsValueOfNameToString()
        {
            var user = new User { Name = new Name("Bob", "Bill", "Boss")};
            string expectedName = user.Name.ToString();

            string nameAsString = user.NameAsString;

            Assert.AreEqual(expectedName, nameAsString, "Name As String returned incorrect value.");
        }

        [Test]
        public void NameAsStringReturnsEmptyStringWhenNameIsNull()
        {
            var user = new User {Name = null};
            string expectedName = string.Empty;

            string nameAsString = user.NameAsString;

            Assert.AreEqual(expectedName, nameAsString, "Name As String returned incorrect value.");
        }
    }
}