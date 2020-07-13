using System;
using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Marketing.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Application.Attributes;
using Product = Falcon.App.Core.Finance.Domain.Product;

namespace Falcon.App.Infrastructure.Scheduling.Facotries
{
    [DefaultImplementation]
    public class EventCustomerSummaryModelFactory : IEventCustomerSummaryModelFactory
    {
        public EventCustomerSummaryModel Create(EventCustomer eventCustomer, Order order, EventBasicInfoViewModel eventInfo, Customer customer, DateTime? apptTime, IEnumerable<OrderedPair<long, string>> orderPackageNamePair,
            IEnumerable<OrderedPair<long, string>> orderTestNamePair, IEnumerable<OrderedPair<long, string>> orderitemProductPair, IEnumerable<ShippingDetail> shippingDetails, IEnumerable<SourceCode> sourceCodes, IEnumerable<ChargeCard> cards)
        {
            string package = "";
            if (orderPackageNamePair != null && orderPackageNamePair.Count() > 0) package = orderPackageNamePair.FirstOrDefault().SecondValue;
            if (orderTestNamePair != null && orderTestNamePair.Count() > 0)
            {
                var tests = string.Join(",", orderTestNamePair.Select(ot => ot.SecondValue));
                package = !string.IsNullOrEmpty(package) ? package + ", " + tests : tests;
            }

            var getCardDetailstoDisplay = new Func<long, string>(cardId =>
                                                                     {
                                                                         return cards.Where(c => c.Id == cardId).Select(
                                                                              c =>
                                                                              c.TypeId.ToString() + " " +
                                                                              c.Number.Substring(c.Number.Length - 4, 4)).FirstOrDefault();
                                                                     });

            var payments = order.PaymentsApplied != null
                               ? order.PaymentsApplied.Select(
                               pa => new OrderedPair<string, decimal>(pa.PaymentType == PaymentType.CreditCard ? getCardDetailstoDisplay(((ChargeCardPayment)pa).ChargeCardId) : pa.PaymentType.ToString(), pa.Amount))
                               : null;

            var sourceCodeOrderDetail =
                order.OrderDetails.Where(
                    od =>
                    od.SourceCodeOrderDetail != null &&
                    od.OrderItemStatus.OrderStatusState == OrderStatusState.FinalSuccess).Select(od => od.SourceCodeOrderDetail).FirstOrDefault();

            var sourceCode = sourceCodes != null && sourceCodes.Count() > 0
                                 ? sourceCodes.FirstOrDefault() : null;

            return new EventCustomerSummaryModel()
                       {
                           AdditionalProduct =
                               orderitemProductPair != null
                                   ? String.Join(", ", orderitemProductPair.Select(oip => oip.SecondValue))
                                   : "",
                           Address = eventInfo.HostAddress,
                           AmountDue = order.DiscountedTotal - order.TotalAmountPaid,
                           AmountPaid = order.TotalAmountPaid,
                           Cost = order.UndiscountedTotal,
                           AppointmentTime = apptTime,
                           CustomerId = eventCustomer.CustomerId,
                           CustomerName = customer.NameAsString,
                           HomePhoneNumber = customer.HomePhoneNumber != null ? customer.HomePhoneNumber.ToString() : "",
                           OfficePhoneNumber = customer.OfficePhoneNumber != null ? customer.OfficePhoneNumber.ToString() : "",
                           CellPhoneNumber = customer.MobilePhoneNumber != null ? customer.MobilePhoneNumber.ToString() : "",
                           Email = customer.Email != null ? customer.Email.ToString() : "",
                           EventCustomerId = eventCustomer.Id,
                           EventDate = eventInfo.EventDate,
                           EventId = eventCustomer.EventId,
                           Host = eventInfo.HostName,
                           OrderId = order.Id,
                           Package = package,
                           Payments = payments,
                           ShippingOptions =
                               shippingDetails != null
                                   ? shippingDetails.Select(
                                       sd => new OrderedPair<string, decimal>(sd.ShippingOption.Name, sd.ActualPrice))
                                   : null,
                           SourceCode = sourceCode != null ? sourceCode.CouponCode : "",
                           SourceCodeAmount = sourceCodeOrderDetail != null ? sourceCodeOrderDetail.Amount : 0,
                           EventStatus = eventInfo.Status
                       };
        }

        public EventCustomerOrderSummaryModel Create(Event eventInfo, Host host, EventSchedulingSlot appointmentSlot, EventPackage eventPackage, IEnumerable<EventTest> eventTests, IEnumerable<Product> products, ShippingOption shippingOption,
            SourceCodeApplyEditModel sourceCodeApplyEditModel, Order order, long? shippingOptionId)
        {
            var model = new EventCustomerOrderSummaryModel();

            if (eventInfo != null)
            {
                model.EventId = eventInfo.Id;
                model.EventType = eventInfo.EventType;
                model.EventDate = eventInfo.EventDate;
                model.Host = host.OrganizationName;
                model.Address = Mapper.Map<Address, AddressViewModel>(host.Address);
                model.CaptureInsuranceId = eventInfo.CaptureInsuranceId;
            }

            if (appointmentSlot != null)
                model.AppointmentTime = appointmentSlot.StartTime;

            decimal totalPrice = 0;

            if (eventPackage != null)
            {
                model.Package = new OrderedPair<string, decimal>(eventPackage.Package.Name, eventPackage.Price);
                model.PackageTest = eventPackage.Tests.Select(ept => ept.Test.Name).ToArray();
                totalPrice = eventPackage.Price;
            }

            if (eventTests != null)
            {
                model.AdditionalTests = eventTests.Select(et => new OrderedPair<string, decimal>(et.Test.Name, eventPackage != null ? et.WithPackagePrice : et.Price)).ToArray();

                var testPrice = eventTests.Select(et => eventPackage != null ? et.WithPackagePrice : et.Price).Sum();
                totalPrice += testPrice;
            }

            if (products != null)
            {
                model.Product = products.Select(p => new OrderedPair<string, decimal>(p.Name, p.Price)).ToArray();
                var productPrice = products.Select(p => p.Price).Sum();
                totalPrice += productPrice;
            }

            if (shippingOption != null)
            {
                model.ShippingOption = new OrderedPair<string, decimal>(shippingOption.Name, shippingOption.Price);
                totalPrice += shippingOption.Price;
            }

            model.TotalPrice = totalPrice;

            if (sourceCodeApplyEditModel != null)
            {
                model.DiscountAmount = sourceCodeApplyEditModel.DiscountApplied;
                model.SourceCode = sourceCodeApplyEditModel.SourceCode;
            }

            if (order != null)
            {
                var cancelledOrderDetail = order.OrderDetails.Where(od => od.DetailType == OrderItemType.CancellationFee).Select(od => od).LastOrDefault();
                if (cancelledOrderDetail != null)
                {
                    var paymentsApplied = order.PaymentsApplied.Where(pa => pa.DataRecorderMetaData.DateCreated > cancelledOrderDetail.DataRecorderMetaData.DateCreated.AddMinutes(5)).Select(pd => pd);
                    model.AmountPaid = paymentsApplied.Sum(pa => pa.Amount);
                }
                else
                {
                    model.AmountPaid = order.TotalAmountPaid;
                }
            }

            model.ShippingOptionId = shippingOptionId;
            return model;
        }
    }
}