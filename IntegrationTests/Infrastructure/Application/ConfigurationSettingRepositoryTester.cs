using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class ConfigurationSettingRepositoryTester
    {
        private readonly IConfigurationSettingRepository _configurationSettingRepository = new ConfigurationSettingRepository();

        [Test]
        public void GetConfigurationValueReturnsNovemberFirst2007WhenEpochDateConfigNameGiven()
        {
            var epochDateTime = new DateTime(2007, 11, 1);
            
            string configurationValue = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.EpochDate);

            Assert.AreEqual(epochDateTime, DateTime.Parse(configurationValue));
        }
    }
}