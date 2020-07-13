using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCustomerSummaryModelFactory
    {
        EventCustomerSummaryModel Create(EventCustomer eventCustomer,Order order, EventBasicInfoViewModel eventInfo, Customer customer, DateTime? apptTime, IEnumerable<OrderedPair<long, string>> orderPackageNamePair,
                                            IEnumerable<OrderedPair<long, string>> orderTestNamePair, IEnumerable<OrderedPair<long, string>> orderitemProductPair, IEnumerable<ShippingDetail> shippingDetails, IEnumerable<SourceCode> sourceCodes, 
                                            IEnumerable<ChargeCard> cards);

        EventCustomerOrderSummaryModel Create(Event eventInfo, Host host, EventSchedulingSlot appointmentSlot, EventPackage eventPackage, IEnumerable<EventTest> eventTests, IEnumerable<Product> products,
            ShippingOption shippingOption, SourceCodeApplyEditModel sourceCodeApplyEditModel, Order order, long? shippingOptionId);
    }
}