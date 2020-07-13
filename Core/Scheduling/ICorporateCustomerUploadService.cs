using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICorporateCustomerUploadService
    {
        string ValidateZipCodes(string zipCodes);
        void UpdateCustomerData(CorporateCustomerEditModel model, OrganizationRoleUser createdByOrgRoleUser, Customer customer, ILogger logger);
        void UpdateIcdCodesForFutureEvent(IEnumerable<EventCustomer> eventCustomers, IEnumerable<IcdCode> icdCodes);
        void UpdateCustomerPreApprovedForFutureEvents(IEnumerable<EventCustomer> eventCustomers, CorporateCustomerEditModel customerEditModel);
        void UpdateCustomerPreApprovedPackges(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId);
        void UpateCustomerPreApprovedTest(CorporateCustomerEditModel model, long createdByOrgRoleUserId, long customerId);
    }
}