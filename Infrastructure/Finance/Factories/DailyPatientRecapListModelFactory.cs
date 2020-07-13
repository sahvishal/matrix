using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Extension;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Infrastructure.Finance.Factories
{
    [DefaultImplementation]
    public class DailyPatientRecapListModelFactory : IDailyPatientRecapListModelFactory
    {
        public DailyPatientRecapListModel CreateListModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders, IEnumerable<ShippingDetail> shippingDetails, ShippingOption cdShippingOption,
            IEnumerable<OrderedPair<long, string>> hospitalPartners, IEnumerable<OrderedPair<long, string>> corporateAccounts, IEnumerable<Appointment> appointments, IEnumerable<Pod> pods, IEnumerable<EventPod> eventPods,
            IEnumerable<Event> events, IEnumerable<OrderedPair<long, long>> orderIdEventPackageTestIdPairs, IEnumerable<OrderedPair<long, long>> orderIdTestIdPairs, IEnumerable<OrderedPair<long, long>> testNotPerformedEventCustomerIdTestIdPairs,
            IEnumerable<OrderedPair<long, string>> tests, IEnumerable<OrderedPair<long, string>> orderIdPackageNamePairs)
        {
            var list = new List<DailyPatientRecapModel>();


            foreach (var theEventCustomer in eventCustomers)
            {
                var eventCustomer = theEventCustomer;

                var customer = customers.First(x => x.CustomerId == eventCustomer.CustomerId);
                var order = orders.FirstOrDefault(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                var eventData = events.First(e => e.Id == eventCustomer.EventId);

                var package = order == null ? null : orderIdPackageNamePairs.FirstOrDefault(p => p.FirstValue == order.Id);
                //var test = order == null ? null : tests.Where(p => p.FirstValue == order.Id).ToList();

                var productPurchased = string.Empty;

                //if (package != null && !test.IsNullOrEmpty())
                //    productPurchased = package.SecondValue + " + " + string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                //else if (!test.IsNullOrEmpty())
                //    productPurchased = string.Join(" + ", test.Select(t => t.SecondValue).ToArray());
                //else if (package != null)
                //    productPurchased = package.SecondValue;

                if (order != null)
                {
                    var eventCustomerTestIds = new List<long>();
                    if (orderIdEventPackageTestIdPairs != null)
                        eventCustomerTestIds.AddRange(orderIdEventPackageTestIdPairs.Where(op => op.FirstValue == order.Id).Select(op => op.SecondValue).ToArray());

                    if (orderIdTestIdPairs != null)
                        eventCustomerTestIds.AddRange(orderIdTestIdPairs.Where(op => op.FirstValue == order.Id).Select(op => op.SecondValue).ToArray());

                    if (testNotPerformedEventCustomerIdTestIdPairs != null)
                    {
                        var notPerformedTestIds = testNotPerformedEventCustomerIdTestIdPairs.Where(op => op.FirstValue == eventCustomer.Id).Select(op => op.SecondValue).ToArray();
                        if (notPerformedTestIds.Any())
                            eventCustomerTestIds.RemoveAll(notPerformedTestIds.Contains);
                    }

                    if (eventCustomerTestIds.Any())
                    {
                        var testPurchased = tests.Where(t => eventCustomerTestIds.Contains(t.FirstValue)).Select(t => t.SecondValue).ToArray();
                        productPurchased = string.Join(" + ", testPurchased);
                    }
                }

                var isShippingPurchased = false;
                var isCdPurchased = false;

                if (order != null)
                {
                    var shippingDetailIds = order.OrderDetails.SelectMany(od => od.ShippingDetailOrderDetails.Select(sdod => sdod.ShippingDetailId)).ToArray();
                    var cdShippingDetail = shippingDetails.FirstOrDefault(sd => shippingDetailIds.Contains(sd.Id) && sd.ShippingOption.Id == (cdShippingOption != null ? cdShippingOption.Id : 0));

                    var cdOrderDetail = order.OrderDetails.Where(od => od.IsCompleted && od.DetailType == OrderItemType.ProductItem).ToArray();
                    if (cdOrderDetail.Any())
                        isCdPurchased = true;
                    if (cdShippingDetail != null)
                        isShippingPurchased = true;
                }

                var hospitalPartner = hospitalPartners.FirstOrDefault(x => x.FirstValue == eventCustomer.EventId);
                var corporateAccount = corporateAccounts.FirstOrDefault(x => x.FirstValue == eventCustomer.EventId);

                var appointment = eventCustomer.AppointmentId.HasValue ? appointments.FirstOrDefault(x => x.Id == eventCustomer.AppointmentId.Value) : null;

                var podName = string.Empty;
                if (eventPods != null && eventPods.Any())
                {
                    var podIds = eventPods.Where(ep => ep.EventId == eventCustomer.EventId).Select(ep => ep.PodId).ToArray();
                    if (podIds.Any())
                    {
                        podName = string.Join(",", pods.Where(p => podIds.Contains(p.Id)).Select(p => p.Name).ToList());
                    }
                }

                var gender = string.Empty;
                if (customer.Gender == Gender.Female || customer.Gender == Gender.Male)
                {
                    gender = customer.Gender.ToString();
                }
                else
                {
                    gender = "N/A";
                }

                var item = new DailyPatientRecapModel
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    DateOfBirth = customer.DateOfBirth,
                    CustomerId = customer.CustomerId,
                    Phone = customer.HomePhoneNumber,
                    Email = customer.Email,
                    MemeberId = customer.InsuranceId,
                    EventId = eventCustomer.EventId,
                    EventDate = eventData.EventDate,
                    Package = package != null ? package.SecondValue : "N/A",
                    Tests = string.IsNullOrEmpty(productPurchased) ? "None" : productPurchased,
                    IsShippingPurchased = isShippingPurchased ? "Yes" : "No",
                    IsCdPurchased = isCdPurchased ? "Yes" : "No",
                    Discount = order.OrderDiscount,
                    AmountCollected = order.TotalAmountPaid,
                    TotalAmount = order.DiscountedTotal,
                    HospitalPartner = hospitalPartner == null ? "N/A" : hospitalPartner.SecondValue,
                    CorporatePartner = corporateAccount == null ? "N/A" : corporateAccount.SecondValue,
                    CheckedIn = appointment != null ? appointment.CheckInTime : null,
                    CheckedOut = appointment == null ? null : appointment.CheckOutTime,
                    Pod = podName,
                    Gender = gender,
                    IsGiftCertificateDeleievred = eventCustomer.IsGiftCertificateDelivered.HasValue ? (eventCustomer.IsGiftCertificateDelivered.Value ? "Yes" : "No") : "N/A",
                    GiftCode = !string.IsNullOrEmpty(eventCustomer.GiftCode) && eventCustomer.IsGiftCertificateDelivered.HasValue && eventCustomer.IsGiftCertificateDelivered.Value ? eventCustomer.GiftCode : "N/A",
                    GcNotGivenReason = eventCustomer.GcNotGivenReasonId.HasValue ? (string.IsNullOrEmpty(((GcNotGivenReason)eventCustomer.GcNotGivenReasonId.Value).GetDescription()) ? "N/A" : ((GcNotGivenReason)eventCustomer.GcNotGivenReasonId).GetDescription()) : "N/A"
                };

                list.Add(item);
            }

            return new DailyPatientRecapListModel { Collection = list };
        }

        public DailyPatientRecapCustomListModel CreateCustomListModel(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Customer> customers, IEnumerable<Order> orders,
            IEnumerable<OrderedPair<long, string>> corporateAccounts, IEnumerable<Pod> pods, IEnumerable<EventPod> eventPods, IEnumerable<Event> events,
            IEnumerable<OrderedPair<long, long>> orderIdEventPackageTestIdPairs, IEnumerable<OrderedPair<long, long>> orderIdTestIdPairs,
            IEnumerable<OrderedPair<long, long>> testNotPerformedEventCustomerIdTestIdPairs, IEnumerable<OrderedPair<long, string>> tests,
            IEnumerable<OrderedPair<long, string>> orderIdPackageNamePairs)
        {
            var list = new List<DailyPatientRecapCustomModel>();


            foreach (var eventCustomer in eventCustomers)
            {
                var customer = customers.First(x => x.CustomerId == eventCustomer.CustomerId);
                var order = orders.FirstOrDefault(o => o.EventId == eventCustomer.EventId && o.CustomerId == eventCustomer.CustomerId);
                var eventData = events.First(e => e.Id == eventCustomer.EventId);

                var package = order == null ? null : orderIdPackageNamePairs.FirstOrDefault(p => p.FirstValue == order.Id);


                var productPurchased = string.Empty;

                if (order != null)
                {
                    var eventCustomerTestIds = new List<long>();
                    if (orderIdEventPackageTestIdPairs != null)
                        eventCustomerTestIds.AddRange(orderIdEventPackageTestIdPairs.Where(op => op.FirstValue == order.Id).Select(op => op.SecondValue).ToArray());

                    if (orderIdTestIdPairs != null)
                        eventCustomerTestIds.AddRange(orderIdTestIdPairs.Where(op => op.FirstValue == order.Id).Select(op => op.SecondValue).ToArray());

                    if (testNotPerformedEventCustomerIdTestIdPairs != null)
                    {
                        var notPerformedTestIds = testNotPerformedEventCustomerIdTestIdPairs.Where(op => op.FirstValue == eventCustomer.Id).Select(op => op.SecondValue).ToArray();
                        if (notPerformedTestIds.Any())
                            eventCustomerTestIds.RemoveAll(notPerformedTestIds.Contains);
                    }

                    if (eventCustomerTestIds.Any())
                    {
                        var testPurchased = tests.Where(t => eventCustomerTestIds.Contains(t.FirstValue)).Select(t => t.SecondValue).ToArray();
                        productPurchased = string.Join(" + ", testPurchased);
                    }
                }

                var corporateAccount = corporateAccounts.FirstOrDefault(x => x.FirstValue == eventCustomer.EventId);

                var podName = string.Empty;
                if (eventPods != null && eventPods.Any())
                {
                    var podIds = eventPods.Where(ep => ep.EventId == eventCustomer.EventId).Select(ep => ep.PodId).ToArray();
                    if (podIds.Any())
                    {
                        podName = string.Join(",", pods.Where(p => podIds.Contains(p.Id)).Select(p => p.Name).ToList());
                    }
                }



                var item = new DailyPatientRecapCustomModel
                {
                    Name = customer.Name,
                    Address = customer.Address,
                    DateOfBirth = customer.DateOfBirth,
                    CustomerId = customer.CustomerId,
                    Phone = customer.HomePhoneNumber,
                    MemeberId = customer.InsuranceId,
                    EventId = eventCustomer.EventId,
                    EventDate = eventData.EventDate,
                    Package = package != null ? package.SecondValue : "N/A",
                    Tests = string.IsNullOrEmpty(productPurchased) ? "None" : productPurchased,
                    CorporatePartner = corporateAccount == null ? "N/A" : corporateAccount.SecondValue,
                    Pod = podName
                };

                list.Add(item);
            }

            return new DailyPatientRecapCustomListModel { Collection = list };
        }
    }
}
