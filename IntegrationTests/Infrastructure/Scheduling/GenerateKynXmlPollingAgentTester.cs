using Falcon.App.Core.Scheduling;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class GenerateKynXmlPollingAgentTester
    {
        private IGenerateKynXmlPollingAgent _generateKynXmlPollingAgent;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
            _generateKynXmlPollingAgent = IoC.Resolve<IGenerateKynXmlPollingAgent>();
        }

        [Test]
        public void GenerateKynXmlPolling_Tester()
        {
            _generateKynXmlPollingAgent.Polling();
        }

    }
}
