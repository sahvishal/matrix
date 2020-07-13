using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IMassRegistrationEditModelFactory
    {
        Customer CreateCustomer(MassRegistrationEditModel model, OrganizationRoleUser createdByOrgRoleUser);
        Customer CreateCustomer(OnSiteRegistrationEditModel model, OrganizationRoleUser createdByOrgRoleUser);
        Customer CreateCustomer(CorporateCustomerEditModel model, string tag, OrganizationRoleUser createdByOrgRoleUser, Customer customer, Language language, Lab lab, long activityTypeId, long? source);
        Address CreateAddress(CorporateCustomerEditModel model, string addresstoCreate);
    }
}
