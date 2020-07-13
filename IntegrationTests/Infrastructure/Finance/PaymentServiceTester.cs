using Falcon.App.Core.Application;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Finance
{
    [TestFixture]
    [Ignore("The database needs to be in a steady state in order to run this test fixture.")]
    public class PaymentServiceTester
    {
        private const long VALID_EVENT_ID = 1724;

        private IEventMetricsService _eventMetricService;
        private IDailyPatientRecapReportPollingAgent _dailyPatientRecapReportPollingAgent;

        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _eventMetricService = IoC.Resolve<IEventMetricsService>();
            _dailyPatientRecapReportPollingAgent = IoC.Resolve<IDailyPatientRecapReportPollingAgent>();
        }

        [Test]
        public void GetEventRevenueStatisticsReturnValidDataWhenGivenValidId()
        {
            var viewData = _eventMetricService.GetEventMetricsViewData(VALID_EVENT_ID, 1);

            Assert.IsNotNull(viewData);
        }

        [Test]
        public void GetDailyPatientRecapReportReturnValidData()
        {

             _dailyPatientRecapReportPollingAgent.PollForDailyPatientRecapReport();

            Assert.Pass();
        }
    }
}