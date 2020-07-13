using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class PayPeriodBookedCustomerFactory : IPayPeriodBookedCustomerFactory
    {
        public PayPeriodBookedCustomerListModel Create(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel, IEnumerable<Customer> customers,
            IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests)
        {
            var model = new PayPeriodBookedCustomerListModel();
            var appointmentsBookedModels = new List<PayPeriodBookedCustomerViewModel>();

            eventCustomers.ToList().ForEach(ec =>
            {

                var appointment = ec.AppointmentId.HasValue ? appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value) : null;

                var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == ec.EventId);

                var order = orders.FirstOrDefault(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                var customer = customers.FirstOrDefault(c => c.CustomerId == ec.CustomerId);

                var productPurchased = string.Empty;

                if (order != null && order.OrderDetails != null && order.OrderDetails.Any())
                {
                    var packageOrderItem = order.OrderDetails.FirstOrDefault(od => od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted);
                    var testOrderItems = order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.IsCompleted);

                    if (packageOrderItem != null)
                    {
                        var eventPackage = eventPackages.FirstOrDefault(x => x.Id == packageOrderItem.OrderItem.ItemId);
                        if (eventPackage != null)
                        {
                            productPurchased = eventPackage.Package.Name;

                        }
                    }

                    if (!testOrderItems.IsNullOrEmpty())
                    {
                        var orderIds = testOrderItems.Select(x => x.OrderItem.ItemId);
                        var customerTests = eventTests.Where(x => orderIds.Contains(x.Id));

                        if (!customerTests.IsNullOrEmpty())
                        {
                            var testNames = customerTests.Select(x => x.Test.Name).ToArray();
                            productPurchased = string.IsNullOrEmpty(productPurchased) ? string.Join(" + ", testNames) : productPurchased + " + " + string.Join(" + ", testNames);
                        }
                    }
                }

                var apptModel = new PayPeriodBookedCustomerViewModel
                {
                    CustomerId = ec.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    EventId = ec.EventId.ToString(),
                    EventDate = eventModel.EventDate,
                    CustomerName = customer.NameAsString,
                    RegistrationDate = ec.DataRecorderMetaData.DateCreated,
                    AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointment.StartTime : null,
                    Package = productPurchased
                };

                appointmentsBookedModels.Add(apptModel);
            });

            model.Collection = appointmentsBookedModels;

            return model;
        }

        public ActualCustomerShowedListModel CreateActualCustomerShowed(IEnumerable<EventCustomer> eventCustomers, IEnumerable<Appointment> appointments, IEnumerable<Order> orders, EventVolumeListModel eventListModel,
            IEnumerable<Customer> customers, IEnumerable<EventPackage> eventPackages, IEnumerable<EventTest> eventTests, IEnumerable<PayPeriod> payPeriods, IEnumerable<PayPeriodCriteria> criterias,
            IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent)
        {
            var model = new ActualCustomerShowedListModel();
            var appointmentsBookedModels = new List<ActualCustomerShowedViewModel>();

            eventCustomers.ToList().ForEach(ec =>
            {

                var appointment = ec.AppointmentId.HasValue ? appointments.FirstOrDefault(a => a.Id == ec.AppointmentId.Value) : null;

                var eventModel = eventListModel.Collection.FirstOrDefault(e => e.EventCode == ec.EventId);

                var order = orders.FirstOrDefault(o => o.EventId == ec.EventId && o.CustomerId == ec.CustomerId);

                var customer = customers.FirstOrDefault(c => c.CustomerId == ec.CustomerId);

                var productPurchased = string.Empty;

                var payPeriod = payPeriods.FirstOrDefault(s => ec.DataRecorderMetaData.DateCreated >= s.StartDate && ec.DataRecorderMetaData.DateCreated < s.EndDate);
                decimal bonusfoEarnnedOnCustomer = 0;

                if (payPeriod != null)
                {
                    bonusfoEarnnedOnCustomer = GetBonusForCustomerBookedInPayRangbyAgent(payPeriodCustomerBookedByAgent, ec.DataRecorderMetaData.DateCreated, criterias);
                }

                if (order != null && order.OrderDetails != null && order.OrderDetails.Any())
                {
                    var packageOrderItem = order.OrderDetails.FirstOrDefault(od => od.DetailType == OrderItemType.EventPackageItem && od.IsCompleted);
                    var testOrderItems = order.OrderDetails.Where(od => od.DetailType == OrderItemType.EventTestItem && od.IsCompleted);

                    if (packageOrderItem != null)
                    {
                        var eventPackage = eventPackages.FirstOrDefault(x => x.Id == packageOrderItem.OrderItem.ItemId);
                        if (eventPackage != null)
                        {
                            productPurchased = eventPackage.Package.Name;
                        }
                    }

                    if (!testOrderItems.IsNullOrEmpty())
                    {
                        var orderIds = testOrderItems.Select(x => x.OrderItem.ItemId);
                        var customerTests = eventTests.Where(x => orderIds.Contains(x.Id));

                        if (!customerTests.IsNullOrEmpty())
                        {
                            var testNames = customerTests.Select(x => x.Test.Name).ToArray();
                            productPurchased = string.IsNullOrEmpty(productPurchased) ? string.Join(" + ", testNames) : productPurchased + " + " + string.Join(" + ", testNames);
                        }
                    }
                }

                var apptModel = new ActualCustomerShowedViewModel
                {
                    CustomerId = ec.CustomerId,
                    CustomerCode = customer.CustomerId.ToString(),
                    EventId = ec.EventId.ToString(),
                    EventDate = eventModel.EventDate,
                    CustomerName = customer.NameAsString,
                    RegistrationDate = ec.DataRecorderMetaData.DateCreated,
                    AppointmentTime = ec.AppointmentId.HasValue ? (DateTime?)appointment.StartTime : null,
                    Package = productPurchased,
                    BonusOnCustomer = bonusfoEarnnedOnCustomer
                };

                appointmentsBookedModels.Add(apptModel);
            });

            model.Collection = appointmentsBookedModels;

            return model;
        }

        private decimal GetTierToCalculateBonus(long bookedCustomer, IEnumerable<PayPeriodCriteria> criterias)
        {
            decimal bonus = 0;

            var criteria = criterias.FirstOrDefault(
                 x =>
                     (bookedCustomer <= x.MaxCustomer && x.TypeId == (long)PayPeriodCriteriaType.LessThanEqualTo) ||
                     (bookedCustomer >= x.MinCustomer && bookedCustomer <= x.MaxCustomer &&
                      x.TypeId == (long)PayPeriodCriteriaType.Between) || (bookedCustomer >= x.MinCustomer && x.TypeId == (long)PayPeriodCriteriaType.GreaterThanEqualTo));

            if (criteria != null)
                bonus = criteria.Ammount;

            return bonus;
        }

        private decimal GetBonusForCustomerBookedInPayRangbyAgent(IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent, DateTime dateCreated, IEnumerable<PayPeriodCriteria> criterias)
        {
            var payPeriod = payPeriodCustomerBookedByAgent.FirstOrDefault(x => dateCreated >= x.StartDate && x.EndDate >= dateCreated);
            if (payPeriod != null)
                return GetTierToCalculateBonus(payPeriod.TotalCustomerBookedByAgent, criterias.Where(x => x.PayPeriodId == payPeriod.PayPeriodId));

            return 0;
        }

    }


}