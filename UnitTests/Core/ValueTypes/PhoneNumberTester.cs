using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.ValueTypes
{
    [TestFixture]
    public class PhoneNumberTester
    {
        [Test]
        public void CountryCodeDefaultsToUnitedStatesIfNoneSpecified()
        {
            const CountryCode expectedCountryCode = CountryCode.UnitedStatesAndCanada;
            
            var phoneNumber = new PhoneNumber("123", "456-7890", PhoneNumberType.Home);
            
            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void CountryCodeIsSetToGivenCountryCode()
        {
            const CountryCode expectedCountryCode = CountryCode.Australia;

            var phoneNumber = new PhoneNumber(expectedCountryCode, "123", "45-67890", PhoneNumberType.Mobile);

            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void ToStringReturnsValueOfDomesticPhoneNumber()
        {
            var phoneNumber = new PhoneNumber("22", "383-2332", PhoneNumberType.Office);
            string expectedString = phoneNumber.DomesticPhoneNumber;

            string phoneNumberString = phoneNumber.ToString();

            Assert.AreEqual(expectedString, phoneNumberString);
        }

        [Test]
        public void DomesticPhoneNumberConcatenatesAreaCodeAndNumberWithDash()
        {
            const string areaCode = "330";
            const string number = "867-5309";
            const string expectedDomesticNumber = areaCode + "-" + number;

            var phoneNumber = new PhoneNumber(areaCode, number, PhoneNumberType.Mobile);

            Assert.AreEqual(expectedDomesticNumber, phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void DomesticPhoneNumberDoesNotInsertDashWhenAreaCodeIsEmpty()
        {
            string areaCode = string.Empty;
            const string number = "8675309";
            const string expectedDomesticNumber = number;

            var phoneNumber = new PhoneNumber(areaCode, number, PhoneNumberType.Mobile);

            Assert.AreEqual(expectedDomesticNumber, phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void InternationalPhoneNumberPrependsReturnedStringWithPlusSign()
        {
            const char expectedCharacter = '+';

            var phoneNumber = new PhoneNumber("1", "2", PhoneNumberType.Office);
            
            Assert.AreEqual(expectedCharacter, phoneNumber.InternationalPhoneNumber[0]);
        }

        [Test]
        public void InternationalPhoneNumberContatenatesCountryCodeAreaCodeNumberWithSpaces()
        {
            const CountryCode countryCode = CountryCode.Mexico;
            const string areaCode = "876";
            const string number = "55 50125";
            string expectedInternationalPhoneNumber = "+" + (int)countryCode + " " + areaCode + " " + number;

            var phoneNumber = new PhoneNumber(countryCode, areaCode, number, PhoneNumberType.Home);

            Assert.AreEqual(expectedInternationalPhoneNumber, phoneNumber.InternationalPhoneNumber);
        }
    }
}