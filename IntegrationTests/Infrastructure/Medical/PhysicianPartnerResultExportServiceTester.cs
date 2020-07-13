using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Application.Impl;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Medical
{
    [TestFixture]
    public class PhysicianPartnerResultExportServiceTester
    {
        IPhysicianPartnerResultPdfDownloadPollingAgent _ppResultPdfDownloadPollingAgent;
        private IPhysicianPartnerAppointmentBookExportPollingAgent _physicianPartnerAppointmentBookExportPollingAgent;
        private IPhysicianPartnerResultExportPollingAgent _physicianPartnerResultExportPollingAgent;
        private IArchiveResultDataPollingAgent _archiveResultDataPollingAgent;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            var autoMapperBootstrapper = new AutoMapperBootstrapper();
            autoMapperBootstrapper.Bootstrap();
        }

        [Test]
        public void PhysicianPartnerResultPdfDownloadPollingAgent_Tester()
        {
            _ppResultPdfDownloadPollingAgent = IoC.Resolve<IPhysicianPartnerResultPdfDownloadPollingAgent>();
            _ppResultPdfDownloadPollingAgent.PollForPdfDownload();
        }

        [Test]
        public void PhysicianPartnerAppointmentBookExportPollingAgent_Tester()
        {
            _physicianPartnerAppointmentBookExportPollingAgent = IoC.Resolve<IPhysicianPartnerAppointmentBookExportPollingAgent>();
            _physicianPartnerAppointmentBookExportPollingAgent.PollForAppointmentBookExport();
        }

        [Test]
        public void PhysicianPartnerResultExportPollingAgent_Tester()
        {
            _physicianPartnerResultExportPollingAgent = IoC.Resolve<IPhysicianPartnerResultExportPollingAgent>();
            _physicianPartnerResultExportPollingAgent.PollForResultExport();
        }

        [Test]
        public void ArchiveResultDataPollingAgent_Tester()
        {
            _archiveResultDataPollingAgent = IoC.Resolve<IArchiveResultDataPollingAgent>();
            _archiveResultDataPollingAgent.PollToArchiveResultData();
        }
    }
}