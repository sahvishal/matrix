using System;
using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IPayPeriodRepository
    {
        PayPeriod GetById(long payperiodId);
        PayPeriod Save(PayPeriod domain);
        bool DeletePayPeriod(long payperiodId);
        IEnumerable<PayPeriod> GetByFilter(PayPeriodFilter filter, int pageNumber, int pageSize, out int totalRecords);

        IEnumerable<OrderedPair<long, string>> GetIdNamePairofUsersByRoleOrParentRole(CallCenterBonusFilter filter, int pageNumber, int pageSize, out int totalRecords);
        IEnumerable<OrderedPair<long, long>> GetTotalCallcount(CallCenterBonusFilter filter, IEnumerable<long> callCenterAgentids);
        IEnumerable<OrderedPair<long, long>> GetTotalBookedCustomerCount(DateTime fromDate, DateTime toDate, IEnumerable<long> callCenterAgentids);
        IEnumerable<OrderedPair<long, long>> GetCustomerAppeardOnEventCount(CallCenterBonusFilter filter, IEnumerable<long> callCenterAgentids);

        IEnumerable<PayPeriod> GetAllForDropdown();

        PayPeriod GetNextPublishedPayPeriod(DateTime effectiveDate, bool includeEffectiveDate = false);
        PayPeriod GetPreviousPublishedPayPeriod(DateTime effectiveDate, bool includeEffectiveDate = false);

        IEnumerable<PayPeriod> GetPayPeriods(DateTime fromDate, DateTime toDate);
        long GetPayPeriodBookingCountForAgent(DateTime fromDate, DateTime toDate, long callCenterAgentId);
    }
}
