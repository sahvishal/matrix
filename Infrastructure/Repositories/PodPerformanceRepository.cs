using System;
using System.Linq;
using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Interfaces;
using HealthYes.Data.Linq;
using HealthYes.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class PodPerformanceRepository : PersistenceRepository, IPodPerformanceRepository
    {
        private readonly IPodPerformanceFactory _podPerformanceFactory;

        public PodPerformanceRepository()
        {
            _podPerformanceFactory = new PodPerformanceFactory();
        }

        public PodPerformanceRepository(IPersistenceLayer persistenceLayer, IPodPerformanceFactory podPerformanceFactory)
            : base(persistenceLayer)
        {
            _podPerformanceFactory = podPerformanceFactory;
        }

        public List<PodPerformanceViewData> GetPerformanceOfAllPods(DateTime startDate, DateTime endDate)
        {
            List<OrderedPair<long, decimal>> listOfAverageRevenuePerCustomerAmount;
            List<OrderedPair<long, decimal>> listOfUpgradeAmount;
            //List<OrderedPair<long, decimal>> listOfDowngradeAmount;
            //List<OrderedPair<long, decimal>> listOfHIPAAPercentage;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var eventCustomersJoinalbleQuery = linqMetaData.EventCustomers.
                    Where(eventCustomer => !eventCustomer.NoShow && eventCustomer.IsTestConducted && eventCustomer.AppointmentId.HasValue).ToList().
                    Join(linqMetaData.Events, eventCustomer => eventCustomer.EventId, eventData => eventData.EventId, (eventCustomer, eventData) => new { EventCustomerId = eventCustomer.EventCustomerId, EventId = eventData.EventId }).
                    Join(linqMetaData.EventPod, eventWithEventCustomer => eventWithEventCustomer.EventId, eventPod => eventPod.EventId, (eventWithEventCustomer, eventPod) => new { eventWithEventCustomer.EventCustomerId, eventWithEventCustomer.EventId, eventPod.PodId });

                var totalRevenues = linqMetaData.PaymentDetails.GroupBy(pd => pd.EventCustomerId).
                    Select(group => new { EventCustomerId = group.Key, TotalRevenue = GetPaymentNet(group) }).ToList();

                listOfAverageRevenuePerCustomerAmount = eventCustomersJoinalbleQuery.
                    Join(totalRevenues, evntCustomerPodData => evntCustomerPodData.EventCustomerId, paymentDetailData => paymentDetailData.EventCustomerId, (evntCustomerPodData, paymentDetailData) => new { PodId = evntCustomerPodData.PodId, TotalRevenue = paymentDetailData.TotalRevenue }).
                    Where(combinedData => combinedData.TotalRevenue > 0).
                    GroupBy(combinedData => combinedData.PodId).
                    Select(group => new OrderedPair<long, decimal>(group.Key, group.Average(data => data.TotalRevenue))).
                    ToList();

                var totalUpgradesAmount = linqMetaData.CustomerAccount.
                    Where(customerAccount => customerAccount.DrorCr == "0" && customerAccount.Description == "Change Package Adjustment").ToList().
                    Join(linqMetaData.PaymentDetails, customerAccount => customerAccount.PaymentDetailsId, paymentDetail => paymentDetail.PaymentId, (customerAccount, paymentDetail) => new { customerAccount.Amount, paymentDetail.EventCustomerId }).
                    GroupBy(combinedData => combinedData.EventCustomerId).
                    Select(group => new { EventCustomerId = group.Key, TotalUpgradesAmount = group.Sum(combinedData => combinedData.Amount) }).ToList();

                var listOfEventsForUpgrades = eventCustomersJoinalbleQuery.
                    Join(totalUpgradesAmount, evntCustomerPodData => evntCustomerPodData.EventCustomerId, paymentDetailData => paymentDetailData.EventCustomerId, (evntCustomerPodData, paymentDetailData) => new { PodId = evntCustomerPodData.PodId, TotalUpgrades = paymentDetailData.TotalUpgradesAmount, EventId = evntCustomerPodData.EventId });

                listOfUpgradeAmount = listOfEventsForUpgrades.GroupBy(combinedData => combinedData.PodId).
                  Select(group => new OrderedPair<long, decimal>(group.Key, (group.Sum(data => data.TotalUpgrades)) / (listOfEventsForUpgrades.Where(eventData => eventData.PodId == group.Key).GroupBy(eventData => eventData.EventId).Count()))).
                  ToList();
            }
            return new List<PodPerformanceViewData>();
            //return _podPerformanceFactory.CreatePodPerformance(listOfAverageRevenuePerCustomerAmount, listOfUpgradeAmount,
            //                            listOfDowngradeAmount, listOfHIPAAPercentage);
        }

        private decimal GetPaymentNet(IGrouping<long?, PaymentDetailsEntity> group)
        {
            var sum = default(decimal);
            group.ToList().ForEach(paymentDetail =>
            {
                sum +=
                    !paymentDetail.DrOrCr.Value ? paymentDetail.PaymentNet.Value : paymentDetail.PaymentNet.Value * (-1);
            });
            return sum;
        }

    }
}
