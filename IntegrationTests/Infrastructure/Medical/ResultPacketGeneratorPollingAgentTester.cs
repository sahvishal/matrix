using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Medical;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class ResultPacketGeneratorPollingAgentTester
    {
        private IResultPacketGeneratorPollingAgent _resultPacketGeneratorPollingAgent;

        private IHafGenerationPollingAgent _hafGeneratorPollingAgent;
        private ICallUploadFileParserPollingAgent _callUploadFileParserPollingAgent;
        private IApplyRulesOnLockedCustomersPollingAgent _callUploadFileParserApplyRulePollingAgent;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
        }

        [Test]
        public void GeneratePdfs_Tester()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            _resultPacketGeneratorPollingAgent = IoC.Resolve<IResultPacketGeneratorPollingAgent>();
            _resultPacketGeneratorPollingAgent.PollForResultPacketGeneration();
        }

        [Test]
        public void PhysicianPartnerResultPdfDownloadPollingAgent_Tester()
        {

            var ppResultPdfDownloadPollingAgent = IoC.Resolve<IPhysicianPartnerResultPdfDownloadPollingAgent>();
            ppResultPdfDownloadPollingAgent.PollForPdfDownload();
        }

        [Test]
        public void GenerateHAF_Tester()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            _hafGeneratorPollingAgent = IoC.Resolve<IHafGenerationPollingAgent>();
            _hafGeneratorPollingAgent.PollforHealthAssessmentFormGeneration();
        }

        [Test]
        public void CallUpload_Tester()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            _callUploadFileParserPollingAgent = IoC.Resolve<ICallUploadFileParserPollingAgent>();
            _callUploadFileParserPollingAgent.PollForParsingCallUpload();
        }

        [Test]
        public void CallUploadApplyRule_Tester()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();

            _callUploadFileParserApplyRulePollingAgent = IoC.Resolve<IApplyRulesOnLockedCustomersPollingAgent>();
            _callUploadFileParserApplyRulePollingAgent.PollForApplyRule();
        }

    }
}
