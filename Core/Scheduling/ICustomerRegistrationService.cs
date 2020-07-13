using System.Collections.Generic;
using System.Text;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ICustomerRegistrationService
    {
        bool RegisterCustomer(MassRegistrationEditModel model, long eventId, EventType eventType);
        Order RegisterOnsiteCustomer(OnSiteRegistrationEditModel model);
        void SendAppointmentConfirmationMail(Customer customer, Event eventData, long createdByOrgRoleUserId, string source, CorporateAccount account);
        Customer RegisterCorporateCustomer(Customer customer, CorporateCustomerEditModel model, string tag, OrganizationRoleUser createdByOrgRoleUser,
            IEnumerable<Language> languages, IEnumerable<Lab> labs, StringBuilder sb, long activityTypeId, long? source, out bool isNewCustomer);
        void SendResetPasswordMail(long userId, string fullname, long createdByOrgRoleUserId, string source);
        string ValidateZipCodes(string zipCodes);
        void ExistingCustomerEventRegistrationTasks(long eventId, long customerId);
        List<Customer> GetCustomersByAcesId(string acesId);
    }
}
