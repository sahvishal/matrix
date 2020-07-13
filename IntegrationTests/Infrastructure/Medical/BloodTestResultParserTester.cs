using Falcon.App.Core.Medical;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class BloodTestResultParserTester
    {
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
        }

        [Test]
        public void Parse_Tester()
        {
            var bloodTestResultParserPollingAgent = IoC.Resolve<IBloodTestResultParserPollingAgent>();
            bloodTestResultParserPollingAgent.Parse();
        }

    }
}
