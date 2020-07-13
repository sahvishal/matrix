using System;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Mappers
{
    public class PhysicianLicenseMapper:DomainEntityMapper<PhysicianLicense,PhysicianLicenseEntity>
    {
        protected override void MapDomainFields(PhysicianLicenseEntity entity, PhysicianLicense domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.LicenseId;
            domainObjectToMapTo.PhysicianId = entity.PhysicianId;
            domainObjectToMapTo.LicenseNumber = entity.LicenseNo;
            domainObjectToMapTo.Expirydate = entity.ExpiryDate;
            domainObjectToMapTo.StateId = entity.StateId;
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
        }

        protected override void MapEntityFields(PhysicianLicense domainObject, PhysicianLicenseEntity entityToMapTo)
        {
            entityToMapTo.LicenseId = domainObject.Id;
            entityToMapTo.PhysicianId = domainObject.PhysicianId;
            entityToMapTo.LicenseNo = domainObject.LicenseNumber;
            entityToMapTo.ExpiryDate = domainObject.Expirydate;
            entityToMapTo.StateId = domainObject.StateId;
            entityToMapTo.DateCreated = domainObject.Id > 0 ? domainObject.DateCreated : DateTime.Now;
            entityToMapTo.DateModified = DateTime.Now;
            entityToMapTo.IsActive = true;
            entityToMapTo.IsNew = !(domainObject.Id > 0);
        }
    }
}
