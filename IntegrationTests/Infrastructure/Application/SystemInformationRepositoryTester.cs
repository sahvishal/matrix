using System.Diagnostics;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class SystemInformationRepositoryTester
    {
        [Test]
        public void GetSystemVersionNumberReturnsDLLVersionOfCoreProject()
        {
            ISystemInformationFactory systemInformationFactory = new SystemInformationFactory();
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            string assemblyVersionNumber = Assembly.GetAssembly(typeof(Falcon.App.Core.Domain.DomainObjectBase)).GetName().Version.ToString();
            string expectedVersionNumber = systemInformationFactory.GetFormattedVersionString(assemblyVersionNumber);

            string actualVersionNumber = systemInformationRepository.GetSystemVersionNumber();

            Assert.IsNotNull(actualVersionNumber);
            Assert.AreEqual(expectedVersionNumber, actualVersionNumber);
            Debug.Print(actualVersionNumber);
        }
    }
}