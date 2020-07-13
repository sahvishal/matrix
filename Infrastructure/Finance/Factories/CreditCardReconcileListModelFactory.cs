using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation(Interface = typeof(ICreditCardReconcileListModelFactory))]
    public class CreditCardReconcileListModelFactory : ICreditCardReconcileListModelFactory
    {
        public CreditCardReconcileListModel Create(IEnumerable<ChargeCardPayment> chargeCardPayments, IEnumerable<ChargeCard> chargeCards, IEnumerable<OrderedPair<long, long>> orderPaymentIdOrderedPairs, IEnumerable<Order> orders,
             IEnumerable<OrderedPair<long, string>> customerNameIdPairs, IEnumerable<Event> events, IEnumerable<OrderedPair<long, string>> eventPods, IEnumerable<OrderedPair<long, string>> corporateAccountNameOrderedPairs)
        {
            var listModel = new CreditCardReconcileListModel();
            var array = new CreditCardReconcileModel[chargeCardPayments.Count()];
            var index = 0;
            foreach (var chargeCardPayment in chargeCardPayments)
            {
                var chargeCard = chargeCards.Where(c => c.Id == chargeCardPayment.ChargeCardId).SingleOrDefault();
                var orderId =
                    orderPaymentIdOrderedPairs.Where(p => p.SecondValue == chargeCardPayment.PaymentId).Select(p => p.FirstValue).SingleOrDefault();
                var order = orders.Where(o => o.Id == orderId).SingleOrDefault();
                if (order == null)
                    continue;
                var customerName = customerNameIdPairs.Where(p => p.FirstValue == order.CustomerId).FirstOrDefault();

                var eventPod = eventPods.Where(ep => ep.FirstValue == order.EventId).SingleOrDefault();
                string pods = eventPod != null ? eventPod.SecondValue : string.Empty;
                var theEvent = events != null && order.EventId.HasValue
                                   ? events.Where(e => e.Id == order.EventId).SingleOrDefault()
                                   : null;

                string prepaid = "No";
                decimal prePaidSum = 0;

                if (theEvent != null)
                {
                    prePaidSum = order.PaymentsApplied.Where(
                        pa => pa.DataRecorderMetaData.DateCreated < theEvent.EventDate).Sum(
                            p => p.Amount);
                    if (
                        order.PaymentsApplied.Where(pa => pa.DataRecorderMetaData.DateCreated < theEvent.EventDate).
                            Count() > 0 && prePaidSum < order.DiscountedTotal)
                        prepaid = "Partial Paid";
                    else if (order.DiscountedTotal == order.TotalAmountPaid &&
                             order.PaymentsApplied.Where(pa => pa.DataRecorderMetaData.DateCreated >= theEvent.EventDate)
                                 .Count() < 1)
                        prepaid = "Yes";
                    else if (chargeCardPayment.DataRecorderMetaData.DataRecorderCreator.Id == customerName.FirstValue)
                        prepaid = "Yes";
                }
                else
                {
                    prepaid = " -N/A-";
                    prePaidSum = order.PaymentsApplied.Sum(p => p.Amount);
                }

                var account = theEvent != null ? corporateAccountNameOrderedPairs.FirstOrDefault(x => x.FirstValue == theEvent.Id) : null;

                var model = new CreditCardReconcileModel
                                {
                                    EventId = theEvent != null ? theEvent.Id : 0,
                                    Amount = chargeCardPayment.Amount,
                                    CardType = chargeCard.TypeId.ToString(),
                                    CustomerName = customerName.SecondValue,
                                    DateApproved = chargeCardPayment.DataRecorderMetaData.DateCreated,
                                    Pod = pods,
                                    ReceiptNumber = ProcessorResponse.IsValidResponseString(chargeCardPayment.ProcessorResponse) ? new ProcessorResponse(chargeCardPayment.ProcessorResponse).TransactionCode : chargeCardPayment.ProcessorResponse,
                                    IsOnline = chargeCardPayment.DataRecorderMetaData.DataRecorderCreator.Id == customerName.FirstValue,
                                    Prepaid = prepaid,
                                    CorporatePartner = account == null ? "N/A" : account.SecondValue,
                                    EventType = theEvent != null ? ((theEvent.EventType == EventType.Retail) ? EventType.Retail.ToString() : EventType.Corporate.ToString()) : "N/A"
                                };

                array[index++] = model;
            }
            listModel.Collection = array;
            return listModel;
        }
    }
}