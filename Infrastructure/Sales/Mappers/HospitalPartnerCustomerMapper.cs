using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Sales.Mappers
{
    public class HospitalPartnerCustomerMapper : DomainEntityMapper<HospitalPartnerCustomer,HospitalPartnerCustomerEntity>
    {
        protected override void MapDomainFields(HospitalPartnerCustomerEntity entity, HospitalPartnerCustomer domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.HospitalPartnerCustomerId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.Status = entity.Status;
            domainObjectToMapTo.Outcome = entity.Outcome;
            domainObjectToMapTo.CareCoordinatorOrgRoleUserId = entity.CareCoordinatorOrgRoleUserId;
            domainObjectToMapTo.Notes = entity.Notes;
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData()
                                                           {
                                                               DataRecorderCreator =
                                                                   new OrganizationRoleUser
                                                                       {Id = entity.CreatedByOrgRoleUserId},
                                                               DataRecorderModifier =
                                                                   new OrganizationRoleUser
                                                                       {Id = entity.ModifiedByOrgRoleUserId},
                                                               DateCreated = entity.DateCreated,
                                                               DateModified = entity.DateModified
                                                           };
        }

        protected override void MapEntityFields(HospitalPartnerCustomer domainObject, HospitalPartnerCustomerEntity entityToMapTo)
        {
            entityToMapTo.HospitalPartnerCustomerId = domainObject.Id;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.Status = domainObject.Status;
            entityToMapTo.Outcome = domainObject.Outcome;
            entityToMapTo.CareCoordinatorOrgRoleUserId = domainObject.CareCoordinatorOrgRoleUserId;
            entityToMapTo.Notes = domainObject.Notes;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.ModifiedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderModifier.Id;
            entityToMapTo.DateModified = domainObject.DataRecorderMetaData.DateModified.HasValue
                                             ? domainObject.DataRecorderMetaData.DateModified.Value
                                             : DateTime.Now;
            entityToMapTo.IsNew = domainObject.Id <= 0;

        }
    }
}
