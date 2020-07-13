using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance
{
    public interface IPayPeriodCriteriaRepository
    {
        IEnumerable<PayPeriodCriteria> GetByPayPeriodId(long payperiodId);
        PayPeriodCriteria Save(PayPeriodCriteria domain);
        IEnumerable<PayPeriodCriteria> GetByPayPeriodId(long[] payPeriodIds);
        void Save(IEnumerable<PayPeriodCriteria> domains, long payPeriodId);
    }
}