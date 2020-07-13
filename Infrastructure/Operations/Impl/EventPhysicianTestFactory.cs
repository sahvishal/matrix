using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Infrastructure.Operations.Impl
{
    [DefaultImplementation]
    public class EventPhysicianTestFactory : IEventPhysicianTestFactory
    {
        public EventPhysicianTest GetDomain(PhsicianEventTestViewModel model, long assignedByOrgRoleUserId, long eventId)
        {
            return new EventPhysicianTest
            {
                AssignedByOrgRoleUserId = assignedByOrgRoleUserId,
                ModifiedByOrgRoleUserId = assignedByOrgRoleUserId,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                IsActive = true,
                PhysicianId = model.PhysicianId,
                EventId = eventId,
                TestId = model.TestId
            };
        }
        public PhsicianEventTestViewModel GetModel(EventPhysicianTest domain)
        {
            return new PhsicianEventTestViewModel
            {
                PhysicianId = domain.PhysicianId,
                IsSelected = true,
                TestId = domain.TestId
            };
        }


        public IEnumerable<EventPhysicianTest> GetDomain(IEnumerable<PhsicianEventTestViewModel> list, long assignedByOrgRoleUserId, long eventId)
        {
            return list.Select(x => GetDomain(x, assignedByOrgRoleUserId, eventId));
        }
    }
}