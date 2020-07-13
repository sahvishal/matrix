using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.Data.EntityClasses;
using NUnit.Framework;

namespace Falcon.Web.IntegrationTests.Infrastructure.Operations
{
     [TestFixture]
    public class EventRoleRepositoryTester
    {
         private IUniqueItemRepository<StaffEventRole> _repository;
         private StaffEventRole _staffEventRole;

         [SetUp]
         public void Init()
         {
             IoC.Register<IUniqueItemRepository<StaffEventRole>, EventRoleRepository>();
             IoC.Register<IMapper<StaffEventRole, StaffEventRoleEntity>, EventRoleMapper>();

             _repository = IoC.Resolve<IUniqueItemRepository<StaffEventRole>>();

             _staffEventRole = new StaffEventRole()
                              {
                                  Name = "AAA Technician",
                                  Description = "AAA Technician which lwill perform on the Sone Machine",
                                  AllowedTestIds = new long[] {1, 10},
                                  DataRecorderMetaData = new DataRecorderMetaData() { DateCreated = DateTime.Now, DataRecorderCreator = new OrganizationRoleUser(){Id = 1}}
                              };


         }

         [Test]
         public void SavePodDefaultTeamTester()
         {
             var podDefaultTeam = _repository.Save(_staffEventRole);

             Assert.IsNotNull(podDefaultTeam);
         }
    }
}