using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface IChaseOutboundFactory
    {
        ChaseOutbound Create(ChaseOutboundViewModel model);

        Customer CreateCustomer(ChaseOutboundViewModel model, Customer customer, Language language, string tag);

        CorporateCustomerEditModel CreateCorporateCustomerEditModel(ChaseOutboundViewModel model);
    }
}
