using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;

namespace Falcon.App.Core.Users
{
    public interface IOrganizationService
    {
        long Create(OrganizationEditModel model);
        long CreateFranchisee(FranchiseeEditModel model);
        OrganizationEditModel GetOrganizationCreateModel(long Id);
        FranchiseeEditModel GetFranchiseeCreateModel(long id);
        OrganizationListModel GetOrganizationListModel(OrganizationType type);
        OrganizationListModel GetOrganizationListModel(OrganizationType type, string searchText);
        MedicalVendorEditModel GetMedicalVendorCreateModel(long id);
        long CreateMedicalVendor(MedicalVendorEditModel model);

        CorporateAccountListModel GetCorporateAccountListModel(int pageNumber, int pageSize,
                                                               CorporateAccountListModelFilter filter,
                                                               out int totalRecords);

        MedicalVendorListModel GetMedicalVendorlistModel(int pageNumber, int pageSize,
                                                         MedicalVendorListModelFilter filter, out int totalRecords);

        HospitalPartnerDashboardViewModel GetHospitalPartnerDashboardModel(long hospitalPartnerId);
        CorporateAccountDashboardViewModel GetCorporateAccountDashboardModel(long accountId, int pageSize);
        long CreateHospitalFacility(HospitalFacilityEditModel model);
        HospitalFacilityEditModel GetHospitalFacilityCreateModel(long id);
        HospitalFacilityListModel GetHospitalFacilityListModel(int pageNumber, int pageSize, HospitalFacilityListModelFilter filter, out int totalRecords);
        HospitalPartnerDashboardViewModel GetHospitalFacilityDashboardModel(long hospitalFacilityId);
        void GetHospitalPartnerPackageInformation(long medicalVendorId, HospitalPartnerEditModel registrationModel);
        bool IsActiveOrganizationbyId(long organizationId);
    }
}
