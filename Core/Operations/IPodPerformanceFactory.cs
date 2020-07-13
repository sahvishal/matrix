using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;

namespace Falcon.App.Core.Operations
{
    public interface IPodPerformanceFactory
    {
        List<PodPerformanceViewData> CreatePodPerformance(List<OrderedPair<long, decimal>> listOfAverageRevenuePerCustomerAmount,
                List<OrderedPair<long, decimal>> listOfUpgradeAmount, List<OrderedPair<long, decimal>> listOfDowngradeAmount, List<OrderedPair<long, decimal>> listOfHIPAAPercentage);
    }
}
