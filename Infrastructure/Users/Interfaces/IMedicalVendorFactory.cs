using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IMedicalVendorFactory
    {
        List<MedicalVendor> CreateMedicalVendors(IEnumerable<MedicalVendorProfileEntity> medicalVendorEntities);
        MedicalVendor CreateMedicalVendor(MedicalVendorProfileEntity medicalVendorEntity);
        MedicalVendorProfileEntity CreateMedicalVendorEntity(MedicalVendor vendor);
    }
}