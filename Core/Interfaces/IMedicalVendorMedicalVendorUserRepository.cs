using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Interfaces
{
    public interface IMedicalVendorMedicalVendorUserRepository
    {
        List<MedicalVendorMedicalVendorUser> GetMedicalVendorMedicalVendorUsersForMedicalVendor(long medicalVendorId);
    }
}