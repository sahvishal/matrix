using System;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Mappers
{

    public class PhysicianLabTestMapper : DomainEntityMapper<PhysicianLabTest, PhysicianLabTestEntity>
    {
        protected override void MapDomainFields(PhysicianLabTestEntity entity, PhysicianLabTest domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.LabTestLicenseId;
            domainObjectToMapTo.PhysicianId = entity.PhysicianId;
            domainObjectToMapTo.StateId = entity.StateId;
            domainObjectToMapTo.IfobtLicenseNo = entity.IfobtLicenseNo;
            domainObjectToMapTo.MicroalbumineLicenseNo = entity.MicroalbumineLicenseNo;
            
            domainObjectToMapTo.DateCreated = entity.DateCreated;
            domainObjectToMapTo.DateModified = entity.DateModified;
            domainObjectToMapTo.IsActive = entity.IsActive;
            domainObjectToMapTo.IsDefault = entity.IsDefault;
        }

        protected override void MapEntityFields(PhysicianLabTest domainObject, PhysicianLabTestEntity entityToMapTo)
        {
            entityToMapTo.LabTestLicenseId = domainObject.Id;
            entityToMapTo.PhysicianId = domainObject.PhysicianId;
            entityToMapTo.StateId = domainObject.StateId;
            entityToMapTo.IfobtLicenseNo = domainObject.IfobtLicenseNo;
            entityToMapTo.MicroalbumineLicenseNo = domainObject.MicroalbumineLicenseNo;
            
            entityToMapTo.DateCreated = domainObject.Id > 0 ? domainObject.DateCreated : DateTime.Now;
            entityToMapTo.DateModified = DateTime.Now;
            entityToMapTo.IsActive = domainObject.IsActive;
            entityToMapTo.IsDefault = domainObject.IsDefault;

            entityToMapTo.IsNew = !(domainObject.Id > 0);
        }
    }
}