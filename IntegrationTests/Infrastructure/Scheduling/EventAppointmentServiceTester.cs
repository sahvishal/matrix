using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Scheduling
{
    [TestFixture]
    public class EventAppointmentServiceTester
    {
        private IEventAppointmentService _eventAppointmentService;
        private const int VALID_EVENT_ID = 1;
        private const int INVALID_EVENT_ID = 0;

        public EventAppointmentServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _eventAppointmentService = IoC.Resolve<IEventAppointmentService>();
        }

        [Test]
        public void GetEventAppointmentBasicInfoReturnsEventAppointmentData()
        {
            var eventAppointment = _eventAppointmentService.GetAppointmentSlotsByEventId(VALID_EVENT_ID);
            Assert.IsNotNull(eventAppointment);
            Assert.IsNotEmpty(eventAppointment.EventAppointmentViewModel.ToList());
        }

        [Test]
        public void GetEventAppointmentBasicInfoReturnsNoEventAppointmentData()
        {
            var eventAppointment = _eventAppointmentService.GetAppointmentSlotsByEventId(INVALID_EVENT_ID);
            Assert.IsEmpty(eventAppointment.EventAppointmentViewModel.ToList());
        }
    }
}
