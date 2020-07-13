using Falcon.App.Core.Domain;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Operations.Mappers
{
    public class PhysicianCustomerAssignmentMapper:DomainEntityMapper<PhysicianCustomerAssignment,PhysicianCustomerAssignmentEntity>
    {
        protected override void MapDomainFields(PhysicianCustomerAssignmentEntity entity, PhysicianCustomerAssignment domainObjectToMapTo)
        {
            domainObjectToMapTo.EventCustomerId = entity.EventCustomerId;
            domainObjectToMapTo.PhysicianId = entity.PhysicianId;
            domainObjectToMapTo.OverReadPhysicianId = entity.OverReadPhysicianId;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData
                                                           {
                                                               DateCreated = entity.DateCreated,
                                                               DataRecorderCreator = new OrganizationRoleUser
                                                                                         {
                                                                                             Id =
                                                                                                 entity.
                                                                                                 AssignedByOrgRoleUserId
                                                                                         }
                                                           };
        }

        protected override void MapEntityFields(PhysicianCustomerAssignment domainObject, PhysicianCustomerAssignmentEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerId = domainObject.EventCustomerId;
            entityToMapTo.PhysicianId = domainObject.PhysicianId;
            entityToMapTo.OverReadPhysicianId = domainObject.OverReadPhysicianId > 0
                                                    ? domainObject.OverReadPhysicianId
                                                    : null;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.AssignedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.IsActive = true;

        }
    }
}
