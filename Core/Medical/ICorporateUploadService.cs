using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System.Collections.Generic;
using System.Text;
namespace Falcon.App.Core.Medical
{
    public interface ICorporateUploadService
    {
        void CorporateUploadDataRow(CorporateCustomerEditModel customerEditModel, IEnumerable<Language> languages,
                IEnumerable<Lab> labs, List<string> customTags, CorporateUploadEditModel corporateModel,
                IEnumerable<AccountAdditionalFieldsEditModel> accountAdditionalFields, List<EventCusomerAdjustOrderViewModel> adjustOrderForCustomerEditModel,
                OrganizationRoleUser createdByOrgRoleUser, long organizationRoleUserId, List<long> customerList, long? source, StringBuilder sb, long corporateUploadId, out CustomerWithDuplicateAcesModel customerIdWithSameAcesId);

        MemberUploadDetailsListModel GetMemberUploadDetails(int pageNumber, int pageSize, MemberUploadDetailsListModelFilter filter, out int totalRecords);
        string DownlaodFilePath(string FileName);
    }
}
