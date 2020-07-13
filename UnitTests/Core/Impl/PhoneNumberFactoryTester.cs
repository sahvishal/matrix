using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.ValueTypes;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class PhoneNumberFactoryTester
    {
        private readonly IPhoneNumberFactory _factory = new PhoneNumberFactory();

        [Test]
        public void CreatePhoneNumberSetsPhoneNumberTypeToGivenType()
        {
            const PhoneNumberType expectedPhoneNumberType = PhoneNumberType.Mobile;

            PhoneNumber phoneNumber = _factory.CreatePhoneNumber("000-000-00000", expectedPhoneNumberType);

            Assert.AreEqual(expectedPhoneNumberType, phoneNumber.PhoneNumberType);
        }

        [Test]
        public void CreatePhoneNumberReturnsEmptyStringWhenGivenEmptyPhoneNumberString()
        {
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber(string.Empty, 0);

            Assert.IsNotNull(phoneNumber);
            Assert.IsEmpty(phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void CreatePhoneNumberReturnsEmptyStringWhenGivenNullPhoneNumberString()
        {
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber(null, 0);

            Assert.IsNotNull(phoneNumber);
            Assert.IsEmpty(phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void CreatePhoneNumberSetsTypeToUnknownWhenReturningEmptyPhoneNumber()
        {
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber(null, 0);

            Assert.AreEqual(PhoneNumberType.Unknown, phoneNumber.PhoneNumberType);
        }

        [Test]
        public void CreatePhoneNumberReturnsEmptyNumberWhenGivenStringHasLessThan10Numbers()
        {
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber("123456789", 0);

            Assert.IsNotNull(phoneNumber);
            Assert.IsEmpty(phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void CreatePhoneNumberSetsCountryCodeToUnitedStatesForStringWith10Characters()
        {
            const CountryCode expectedCountryCode = CountryCode.UnitedStatesAndCanada;
            
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber("0000000000", 0);

            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void CreatePhoneNumberSetsCountryCodeToFirstNumberInStringWith11Numbers()
        {
            const CountryCode expectedCountryCode = CountryCode.UnitedStatesAndCanada;
            
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber((int)expectedCountryCode + "0000000000", 0);

            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void CreatePhoneNumberSetsCountryCodeToFirstTwoNumbersInStringWith12Numbers()
        {
            const CountryCode expectedCountryCode = CountryCode.India;
            
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber((int)expectedCountryCode + "0000000000", 0);

            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void CreatePhoneNumberSetsCountryCodeToFirstThreeNumbersInStringWith13Numbers()
        {
            const CountryCode expectedCountryCode = CountryCode.Nauru;

            PhoneNumber phoneNumber = _factory.CreatePhoneNumber((int)expectedCountryCode + "0000000000", 0);

            Assert.AreEqual(expectedCountryCode, phoneNumber.CountryCode);
        }

        [Test]
        public void CreatePhoneNumberReturnsEmptyNumberWhenStringWithMoreThan13NumbersGiven()
        {
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber("12345678901234", 0);

            Assert.IsNotNull(phoneNumber);
            Assert.IsEmpty(phoneNumber.DomesticPhoneNumber);
        }

        [Test]
        public void CreatePhoneNumberStripsAllNonNumericCharactersFromGivenPhoneNumberString()
        {
            _factory.CreatePhoneNumber("(333) 867-5309", 0);
        }

        [Test]
        public void CreatePhoneNumberSetsAreaCodeToFirstThreeDigitsAfterCountryCode()
        {
            const string expectedAreaCode = "740";
            var countryCodes = new List<CountryCode>
                { CountryCode.UnitedStatesAndCanada, CountryCode.India, CountryCode.Nauru };
            PhoneNumber phoneNumber = _factory.CreatePhoneNumber(expectedAreaCode + "8675309", 0);
            foreach (var countryCode in countryCodes)
            {
                string areaCode = phoneNumber.AreaCode;
                Assert.AreEqual(expectedAreaCode, areaCode, "AreaCode {0} expected ({1} returned).", 
                    expectedAreaCode, areaCode);
                phoneNumber = _factory.CreatePhoneNumber((int)countryCode + expectedAreaCode + "8675309", 0);
            }
        }

        [Test]
        public void CreatePhoneNumberSetsPhoneNumberToNumbersAfterAreaCode()
        {
            const string expectedPhoneNumber = "8675309";

            PhoneNumber phoneNumber = _factory.CreatePhoneNumber("000" + expectedPhoneNumber, 0);

            Assert.AreEqual(expectedPhoneNumber, phoneNumber.Number);
        }
    }
}