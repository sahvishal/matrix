using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Insurance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class InsurancePaymentListModelFactory : IInsurancePaymentListModelFactory
    {
        public InsurancePaymentListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Event> events, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<OrderedPair<long, string>> packages,
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<InsuranceDetailViewModel> insuranceDetailViewModels)
        {
            var model = new InsurancePaymentListModel();
            var insurancePaymentModels = new List<InsurancePaymentViewModel>();

            eventCustomers.ToList().ForEach(ec =>
            {
                var eventModel = events.First(e => e.Id == ec.EventId);

                var order = orders.First(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                var customer = customers.First(c => c.CustomerId == ec.CustomerId);

                var package = packages.FirstOrDefault(p => p.FirstValue == order.Id);

                var test = tests.Where(p => p.FirstValue == order.Id).ToList();

                var orderPurchased = string.Empty;

                if (package != null && !test.IsNullOrEmpty())
                    orderPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (!test.IsNullOrEmpty())
                    orderPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                else if (package != null)
                    orderPurchased = package.SecondValue;

                var insuranceAmount = 0m;
                var insurancePaidAmount = 0m;

                var paymentInstruments = new List<OrderedPair<string, decimal>>();

                if (order.PaymentsApplied != null && order.PaymentsApplied.Any())
                {
                    foreach (var paymentInstrument in order.PaymentsApplied)
                    {
                        if (paymentInstrument is InsurancePayment)
                        {
                            var insurancePayment = paymentInstrument as InsurancePayment;
                            insuranceAmount += insurancePayment.AmountToBePaid;
                            insurancePaidAmount += insurancePayment.Amount;
                        }
                    }

                    var creditCardPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.CreditCard).Select(pa => pa).ToArray();
                    if (creditCardPayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(creditCardPayments.First().PaymentType.Name, creditCardPayments.Sum(cc => cc.Amount)));

                    var eCheckPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.ElectronicCheck).Select(pa => pa).ToArray();
                    if (eCheckPayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(eCheckPayments.First().PaymentType.Name, eCheckPayments.Sum(cc => cc.Amount)));

                    var checkPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Check).Select(pa => pa).ToArray();
                    if (checkPayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(checkPayments.First().PaymentType.Name, checkPayments.Sum(cc => cc.Amount)));

                    var cashPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Cash).Select(pa => pa).ToArray();
                    if (cashPayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(cashPayments.First().PaymentType.Name, cashPayments.Sum(cc => cc.Amount)));

                    var gcPayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.GiftCertificate).Select(pa => pa).ToArray();
                    if (gcPayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(gcPayments.First().PaymentType.Name, gcPayments.Sum(cc => cc.Amount)));

                    var insurancePayments = order.PaymentsApplied.Where(pa => pa.PaymentType == PaymentType.Insurance).Select(pa => pa).ToArray();
                    if (insurancePayments.Any())
                        paymentInstruments.Add(new OrderedPair<string, decimal>(insurancePayments.First().PaymentType.Name, insurancePayments.Sum(cc => cc.Amount)));

                }

                var insurancePaymentModel = new InsurancePaymentViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.NameAsString,
                    EventId = eventModel.Id,
                    EventDate = eventModel.EventDate,
                    EventName = eventModel.Name,
                    CustomerOrder = orderPurchased,
                    Status = insurancePaidAmount >= insuranceAmount ? InsurancePaymentStatus.Settled.GetDescription() : InsurancePaymentStatus.NotSettled.GetDescription(),
                    PaymentInstruments = paymentInstruments,
                    InsuranceDetail = insuranceDetailViewModels.First(idvm => idvm.EventCustomerId == ec.Id),
                    DiscountedTotal = order.DiscountedTotal,
                    OrderId = order.Id
                };
                insurancePaymentModels.Add(insurancePaymentModel);
            });

            model.Collection = insurancePaymentModels;
            return model;
        }
    }
}
