using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
    [TestFixture]
    public class EventStaffAssignmentRepositoryTester
    {
        private IEventStaffAssignmentRepository _eventStaffAssignmentRepository;
        private IRepository<EventStaffAssignment> _repository;

        public EventStaffAssignmentRepositoryTester()
        {
            DependencyRegistrar.RegisterDependencies();
            IoC.Resolve<IAutoMapperBootstrapper>().Bootstrap();

            _repository = IoC.Resolve<IRepository<EventStaffAssignment>>();
            _eventStaffAssignmentRepository = IoC.Resolve<IEventStaffAssignmentRepository>();

        }

        [Test]
        public void Save_InsertsCorrectlyWhenDataIsValid()
        {
            const long  VALID_TECHNICIAN_ORU_ID =26;
            var staffAssignment = new EventStaffAssignment
                                      {
                                          ScheduledStaffOrgRoleUserId = VALID_TECHNICIAN_ORU_ID,
                                          EventId = 1,
                                          PodId = 1,
                                          StaffEventRoleId = 1,
                                          Notes = "Larry is assigned",   
                                          DataRecorderMetaData = new DataRecorderMetaData(1,new DateTime(2011,1,21), null)
                                      };

            staffAssignment = _repository.Save(staffAssignment);

            Assert.Greater(staffAssignment.Id, 0); //created correctly
            Assert.AreEqual(VALID_TECHNICIAN_ORU_ID,staffAssignment.ScheduledStaffOrgRoleUserId);
            Assert.IsNull(staffAssignment.ActualStaffOrgRoleUserId);
        }

        [Test]
        public void GetForEvent_ReturnEmptyWhenNoAssignments()
        {
            const int validEventID = 1;
            var actual = _eventStaffAssignmentRepository.GetForEvent(validEventID);

            Assert.AreEqual(1,actual.Count());

        }

        [Test]
        public void DeleteFor_DeletesCorrectlyForValidEvent()
        {
            const int validEventId = 2;
                    var staffAssignment = new EventStaffAssignment
                    {
                        ScheduledStaffOrgRoleUserId = 26,
                        EventId = validEventId,
                        PodId = 1,
                        StaffEventRoleId = 1,
                        Notes = "Should Be DELETED - Integration TEST",
                        DataRecorderMetaData = new DataRecorderMetaData(1, new DateTime(2011, 1, 21), null)
                    };

             _repository.Save(staffAssignment);
             _eventStaffAssignmentRepository.DeleteFor(validEventId);

             var actual = _eventStaffAssignmentRepository.GetForEvent(validEventId);

            Assert.AreEqual(0, actual.Count()); 


        }
    }
}