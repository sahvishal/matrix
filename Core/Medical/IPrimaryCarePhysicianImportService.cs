using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPrimaryCarePhysicianImportService
    {
        PhysicianMaster SavePhysicianMaster(PhysicianMaster physicianMaster, long stateId, long countryId);
        void UpdateCustomerPrimaryCarePhysician(PhysicianMaster physicianMaster, long stateId, long countryId);
        PhysicianMasterListModel SearchPcp(string firstName, string lastName, string zipcode, int pageNumber, int pageSize, out int totalRecords);
    }
}
