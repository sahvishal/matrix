using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IMemberUploadParseDetailFactory
    {
        MemberUploadParseDetail GetDomain(CorporateCustomerEditModel viewModel, long corporateUploadId);
        CorporateCustomerEditModel GetCorporateCustomerModel(MemberUploadParseDetail domain, long? memberUplaodsourceId);
        IEnumerable<CorporateCustomerEditModel> GetCorporateCustomerListModel(IEnumerable<MemberUploadParseDetail> domainList, long? memberUplaodsourceId);
        List<MemberUploadbyAcesFailedCustomerModel> GetMemberUploadbyAcesFailedCustomerListModel(IEnumerable<MemberUploadParseDetail> domainList, long? memberUplaodsourceId);
    }
}
