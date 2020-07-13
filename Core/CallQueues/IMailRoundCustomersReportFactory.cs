using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;

namespace Falcon.App.Core.CallQueues
{
    public interface IMailRoundCustomersReportFactory
    {
        MailRoundCustomersListModel Create(IEnumerable<Customer> customers, IEnumerable<Core.CallCenter.Domain.Call> calls, IEnumerable<DirectMail> directMails, IEnumerable<CorporateCustomerCustomTag> customTags);
    }
}
