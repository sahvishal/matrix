using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    public class EventStaffAssignmentServiceTester
    {
        private readonly IEventStaffAssignmentService _assignmentService;
        private readonly IEventService _eventService;
        private const int VALID_EVENT_ID = 1;
        

        public EventStaffAssignmentServiceTester()
        {
            DependencyRegistrar.RegisterDependencies();

            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();
            _assignmentService = IoC.Resolve<IEventStaffAssignmentService>();
            _eventService = IoC.Resolve<IEventService>();
        } 



        [Test]
        public void Get_ReturnsValidDataForDefaultEventStaffAssignment()
        {
            var actual = _eventService.GetEventStaff(new EventStaffAssignmentListModelFilter {Month = 5, Year = 2011});

            var ValidEventWithDefaultTeam = 2;
            var staffAssignments = actual.StaffEventAssignments.Where(x => x.Event.Id == ValidEventWithDefaultTeam).First().AssignedStaff;

            Assert.AreEqual(1, actual.StaffEventAssignments.Where(x => x.Event.Id == ValidEventWithDefaultTeam).Count());                        
            Assert.AreEqual(2, staffAssignments.Count());
            Assert.AreEqual(1, staffAssignments.Where(x => x.FullName == "Avi Dorian").Count());
            Assert.AreEqual(1, staffAssignments.Where(x => x.EventRole == "Welcome Technician").Count());
            Assert.AreEqual(1, staffAssignments.Where(x => x.FullName == "Larry King").Count());
        }


        [Test]
        public void Get_ReturnsValidDataForNonDefaultEventStaffAssignment()
        {
            var actual = _eventService.GetEventStaff(new EventStaffAssignmentListModelFilter { Month = 5, Year = 2011 });

            var staffAssignments = actual.StaffEventAssignments.Where(x => x.Event.Id == VALID_EVENT_ID).First().AssignedStaff;
            Assert.AreEqual(1, staffAssignments.Count());            
            Assert.AreEqual(1, staffAssignments.Where(x => x.FullName == "Larry King").Count());
        }

    }
}