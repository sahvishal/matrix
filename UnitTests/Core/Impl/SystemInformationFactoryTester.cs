using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using NUnit.Framework;

namespace HealthYes.Web.UnitTests.Core.Impl
{
    [TestFixture]
    public class SystemInformationFactoryTester
    {
        private readonly ISystemInformationFactory _systemInformationFactory = new SystemInformationFactory();

        [Test]
        public void GetFormattedVersionStringSeparatesRevisionNumberFromRestOfString()
        {
            const string versionNumber = "1.2.3";
            const int buildNumber = 4;
            string rawVersionString = versionNumber + "." + buildNumber;
            string expectedVersionNumber = string.Format("Version {0} [Build: {1}]", versionNumber, buildNumber);

            string actualVersionNumber = _systemInformationFactory.GetFormattedVersionString(rawVersionString);

            Assert.AreEqual(expectedVersionNumber, actualVersionNumber);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFormattedVersionStringThrowsExceptionWhenGivenStringIsNotFormattedCorrectly()
        {
            const string incorrectlyFormattedString = "abc";

            _systemInformationFactory.GetFormattedVersionString(incorrectlyFormattedString);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFormattedVersionStringThrowsExceptionWhenGivenNullString()
        {
            _systemInformationFactory.GetFormattedVersionString(null);
        }
    }
}