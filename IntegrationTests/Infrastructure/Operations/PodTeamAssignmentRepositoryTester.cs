using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
     [TestFixture]
    public class PodTeamAssignmentRepositoryTester
    {
         private IUniqueItemRepository<PodStaff> _repository;
         private PodStaff _podDefaultTeam;

         [SetUp]
         public void Init()
         {
             IoC.Register<IUniqueItemRepository<PodStaff>, PodStaffAssignmentRepository>();
             IoC.Register<IMapper<PodStaff, PodDefaultTeamEntity>, PodTeamAssignmentMapper>();

             _repository = IoC.Resolve<IUniqueItemRepository<PodStaff>>();

             _podDefaultTeam = new PodStaff()
                                                 {
                                                     PodId = 1,
                                                     OrganizationRoleUserId = 1,
                                                     EventRoleId = 1,
                                                     DataRecorderMetaData =
                                                         new DataRecorderMetaData() {DateCreated = DateTime.Now}
                                                 };


         }

         [Test]
         public void SavePodDefaultTeamTester()
         {
             var podDefaultTeam = _repository.Save(_podDefaultTeam);

             Assert.IsNull(podDefaultTeam);
         }
    }
}