using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.DependencyResolution;
using NUnit.Framework;
using Falcon.App.Core.Scheduling;

namespace Falcon.Web.IntegrationTests.Infrastructure.Application
{
    [TestFixture]
    public class ExportableDataGeneratorTester
    {
        private IEventReportingService _eventReportingService;
        [SetUp]
        public void SetUp()
        {
            DependencyRegistrar.RegisterDependencies();            
        }

        [Test]
        public void GetDataTester()
        {
            _eventReportingService = IoC.Resolve<IEventReportingService>();
            var dataGenerator = new ExportableDataGenerator<DetailOpenOrdersModel,DetailOpenOrderModelFilter>(_eventReportingService.GetDetailOpenOrderModel);
            var records = dataGenerator.GetData(null);

            Assert.IsNotNull(records);
        }
    }
}