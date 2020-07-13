using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class NameTester
    {
        [Test]
        public void NamesAreNotNullAfterConstruction()
        {
            var name = new Name();

            Assert.IsNotNull(name.FirstName, "FirstName was null.");
            Assert.IsNotNull(name.MiddleName, "MiddleName was null.");
            Assert.IsNotNull(name.LastName, "LastName was null.");
        }

        [Test]
        public void FirstNameIsEmptyStringAfterConstruction()
        {
            var name = new Name();

            Assert.IsEmpty(name.FirstName, "FirstName defaulted to {0} instead of an empty string.", name.FirstName);
            Assert.IsEmpty(name.MiddleName, "MiddleName defaulted to {0} instead of an empty string.", name.MiddleName);
            Assert.IsEmpty(name.LastName, "LastName defaulted to {0} instead of an empty string.", name.LastName);
        }

        [Test]
        public void FullNameReturnsValueOfToString()
        {
            var name = new Name("F", "B", "K");

            Assert.AreEqual(name.ToString(), name.FullName);
        }

        [Test]
        public void ToStringReturnsFirstNameMiddleNameLastNameSeparatedBySpaces()
        {
            const string firstName = "B";
            const string middleName = "K";
            const string lastName = "V";
            const string expectedString = firstName + " " + middleName + " " + lastName;
            
            var name = new Name(firstName, middleName, lastName);
            
            Assert.AreEqual(expectedString, name.ToString());
        }

        [Test]
        public void ToStringReturnsFirstNameLastNameWhenMiddleNameIsEmpty()
        {
            const string firstName = "Bob";
            string middleName = string.Empty;
            const string lastName = "Mabel";
            const string expectedString = firstName + " " + lastName;

            var name = new Name(firstName, middleName, lastName);

            Assert.AreEqual(expectedString, name.ToString());
        }

        [Test]
        public void ToStringReturnsFirstNameWhenOtherNamesAreEmpty()
        {
            const string firstName = "Billy";

            var name = new Name(firstName, string.Empty, string.Empty);

            Assert.AreEqual(firstName, name.ToString());
        }

        [Test]
        public void ToStringReturnsMiddleNameWhenFirstAndLastNamesAreEmpty()
        {
            const string middleName = "Bobby";

            var name = new Name(string.Empty, middleName, string.Empty);

            Assert.AreEqual(middleName, name.ToString());
        }

        [Test]
        public void ToStringReturnsLastNameWhenFirstAndLastNamesAreEmpty()
        {
            const string lastName = "Bobby";

            var name = new Name(string.Empty, string.Empty, lastName);

            Assert.AreEqual(lastName, name.ToString());
        }

        [Test]
        public void ToStringReturnsEmptyStringWhenAllNamesAreEmpty()
        {
            var name = new Name();

            Assert.AreEqual(string.Empty, name.ToString());
        }
    }
}