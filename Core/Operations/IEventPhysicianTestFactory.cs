using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Operations.ViewModels;

namespace Falcon.App.Core.Operations
{
    public interface IEventPhysicianTestFactory
    {
        EventPhysicianTest GetDomain(PhsicianEventTestViewModel model, long assignedByOrgRoleUserId, long eventId);
        IEnumerable<EventPhysicianTest> GetDomain(IEnumerable<PhsicianEventTestViewModel> list, long assignedByOrgRoleUserId, long eventId);
        PhsicianEventTestViewModel GetModel(EventPhysicianTest domain);
    }
}