using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Finance.Impl
{
    [DefaultImplementation]
    public class CallCenterBonusReportingFactory : ICallCenterBonusReportingFactory
    {


        public IEnumerable<CallCenterBonusViewModel> Create(IEnumerable<OrderedPair<long, string>> callCenterAgents, IEnumerable<OrderedPair<long, long>> callCounts,
            IEnumerable<OrderedPair<long, long>> appointmentBooked, IEnumerable<PayPeriodCriteria> criterias)
        {
            var list = new List<CallCenterBonusViewModel>();

            foreach (var agent in callCenterAgents)
            {
                var callCount = callCounts.IsNullOrEmpty() ? null : callCounts.FirstOrDefault(x => x.FirstValue == agent.FirstValue);

                var bookedCount = appointmentBooked.IsNullOrEmpty() ? null : appointmentBooked.FirstOrDefault(x => x.FirstValue == agent.FirstValue);
                var model = new CallCenterBonusViewModel
                {
                    AgentId = agent.FirstValue,
                    AgentName = agent.SecondValue,
                    TotalCalls = callCount != null ? callCount.SecondValue : 0,
                    BookedCustomers = bookedCount != null ? bookedCount.SecondValue : 0,
                };

               // model.ExpectedBonus = model.BookedCustomers > 0 ? CalculateBonus(model.BookedCustomers, criterias) : 0;

                list.Add(model);
            }

            return list;
        }

        public IEnumerable<AppointmentsShowedViewModel> Create(IEnumerable<OrderedPair<long, string>> callCenterAgents, IEnumerable<EventCustomer> eventCustomers, IEnumerable<PayPeriod> payPeriods
            , IEnumerable<PayPeriodCriteria> criterias, IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent)
        {
            var list = new List<AppointmentsShowedViewModel>();

            foreach (var agent in callCenterAgents)
            {
                var model = new AppointmentsShowedViewModel
                 {
                     AgentId = agent.FirstValue,
                     AgentName = agent.SecondValue,
                 };

                if (!eventCustomers.IsNullOrEmpty() && !payPeriods.IsNullOrEmpty())
                {
                    var customerBookedbyAgent = eventCustomers.Where(x => x.DataRecorderMetaData.DataRecorderCreator.Id == agent.FirstValue);

                    model.AppointmentsShowed = customerBookedbyAgent.Count();

                    model.ActualBonus = GetBonusForCustomerBookedInPayRangbyAgent(payPeriodCustomerBookedByAgent, customerBookedbyAgent, agent.FirstValue, criterias);
                }

                list.Add(model);
            }

            return list;
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

        private decimal GetBonusForCustomerBookedInPayRangbyAgent(IEnumerable<PayRangeCustomerBookedViewModel> payPeriodCustomerBookedByAgent, IEnumerable<EventCustomer> eventCustomers, long agentId, IEnumerable<PayPeriodCriteria> criterias)
        {
            decimal bonus = 0;

            foreach (var payRange in payPeriodCustomerBookedByAgent)
            {
                var customerBooked = eventCustomers.Count(x => x.DataRecorderMetaData.DateCreated >= payRange.StartDate && x.DataRecorderMetaData.DateCreated < payRange.EndDate);
                var customerBookedbyAgentInPayRange = payRange.CustomerBookedByAgents.IsNullOrEmpty() ? null : payRange.CustomerBookedByAgents.FirstOrDefault(a => a.FirstValue == agentId);

                long totalCustomerBookedbyAgentInPayRange = customerBookedbyAgentInPayRange == null ? 0 : customerBookedbyAgentInPayRange.SecondValue;

                var bonusTier = GetTierToCalculateBonus(totalCustomerBookedbyAgentInPayRange, criterias.Where(x => x.PayPeriodId == payRange.PayPeriodId));

                bonus += customerBooked * bonusTier;

            }

            return bonus;
        }


    }
}