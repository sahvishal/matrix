using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Finance
{
    public interface ICreditCardReconcileListModelFactory
    {
        CreditCardReconcileListModel Create(IEnumerable<ChargeCardPayment> chargeCardPayments, IEnumerable<ChargeCard> chargeCards, IEnumerable<OrderedPair<long, long>> orderPaymentIdOrderedPairs, IEnumerable<Order> orders,
                                            IEnumerable<OrderedPair<long, string>> customerNameIdPairs, IEnumerable<Event> events, IEnumerable<OrderedPair<long, string>> eventPods,IEnumerable<OrderedPair<long, string>> corporateAccountNameOrderedPairs);
    }
}