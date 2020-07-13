using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IMedicalVendorRepository
    {
        MedicalVendor GetMedicalVendor(long medicalVendorId);
        List<MedicalVendor> GetMedicalVendors();
        MedicalVendor Save(MedicalVendor medicalVendor);
        List<OrderedPair<long, string>> GetAllContracts();

        List<MedicalVendor> GetByFilter(int pageNumber, int pageSize, MedicalVendorListModelFilter filter,
                                        out int totalRecords);
    }
}