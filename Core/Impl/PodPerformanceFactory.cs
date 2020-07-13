using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain.ViewData;
using Falcon.App.Core.Operations;

namespace Falcon.App.Core.Impl
{
    public class PodPerformanceFactory : IPodPerformanceFactory
    {

        public List<PodPerformanceViewData> CreatePodPerformance(List<OrderedPair<long, decimal>> listOfAverageRevenuePerCustomerAmount, List<OrderedPair<long, decimal>> listOfUpgradeAmount, List<OrderedPair<long, decimal>> listOfDowngradeAmount, List<OrderedPair<long, decimal>> listOfHIPAAPercentage)
        {
            throw new NotImplementedException();
        }

    }
}
