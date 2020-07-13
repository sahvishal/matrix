using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventServiceTester
    {
        private IEventService _eventService;
        private const int VALID_EVENT_ID = 1;
        private const int VALID_HOST_ID = 1;

        private const int Page_Number = 1;
        private const int Page_Size = 20;

        public EventServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _eventService = IoC.Resolve<IEventService>();
        }


        [Test]
        public void GetEventBasicInfo_ReturnsDefaultListWhenFilterIsNull()
        {
            int totalRecords = 0;
            var modelList = _eventService.GetEventBasicInfo(null, Page_Number, Page_Size, out totalRecords);

            Assert.IsNotNull(modelList);
            Assert.IsNotNull(modelList.Events);
            Assert.IsNotEmpty(modelList.Events.ToArray());
        }
        
        [Test]
        public void GetEventBasicInfo_FiltersCorrectlyForAllConditionsProvided()
        {
            int totalRecords = 0;
            var filter = new EventBasicInfoViewModelFilter() { Pod = "VB023", DateFrom = new DateTime(2007, 5, 15), DateTo = new DateTime(2007, 12, 15), Name="Walgreen", City = "Fort", State = "Florida", ZipCode = "33308", Radius = 25 };
            var modelList = _eventService.GetEventBasicInfo(filter, Page_Number, Page_Size, out totalRecords);

            Assert.IsNotNull(modelList);
            Assert.IsNotNull(modelList.Events);
            Assert.IsNotEmpty(modelList.Events.ToArray());
        }

        [Test]
        public void GetEventBasicInfo_FiltersCorrectlyForSepcificEventsBasedOnPodName()
        {
            int totalRecords = 0;
            var filter = new EventBasicInfoViewModelFilter() { Pod = "VB023" };
            var modelList = _eventService.GetEventBasicInfo(filter, Page_Number, Page_Size, out totalRecords);

            Assert.IsNotNull(modelList);
            Assert.IsNotNull(modelList.Events);
            Assert.IsNotEmpty(modelList.Events.ToArray());
        }


        [Test]
        public void GetUpcomingEventBasicModelwithnameFiltertester()
        {
            int totalRecords = 0;
            var filter = new EventBasicInfoViewModelFilter() { Name = "Albert" };
            var modelList = _eventService.GetEventBasicInfo(filter, Page_Number, Page_Size, out totalRecords);

            Assert.IsNotNull(modelList);
            Assert.IsNotNull(modelList.Events);
            Assert.IsNotEmpty(modelList.Events.ToArray());
        }

    }
}