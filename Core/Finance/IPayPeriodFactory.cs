using System.Collections.Generic;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.ViewModels;

namespace Falcon.App.Core.Finance
{
    public interface IPayPeriodFactory
    {
        PayPeriod CreateDomain(PayPeriod domain, PayPeriodEditModel model, long orgRoleId);
        PayPeriodEditModel CreateModel(PayPeriod domain);

        IEnumerable<PayPeriodCriteria> CreateCriteriaDomain(IEnumerable<PayPeriodCriteriaEditModel> criterias, long payPeriodId);
        PayPeriodCriteria CreateCriteriaDomain(PayPeriodCriteriaEditModel model, long payPeriodId);
        PayPeriodCriteriaEditModel CreateCriteriaModel(PayPeriodCriteria domain);

        IEnumerable<PayPeriodViewModel> CreateViewModel(IEnumerable<PayPeriod> payPeriod, IEnumerable<PayPeriodCriteria> payPeriodCriterias, IEnumerable<OrderedPair<long, string>> userOrderedPairs);

    }
}
