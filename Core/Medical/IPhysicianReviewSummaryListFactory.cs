using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianReviewSummaryListFactory
    {
        PhysicianReviewSummaryListModel Create(IEnumerable<long> physicianIds, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<OrderedPair<long, int>> physicianIdReviewCountPair,
                                               IEnumerable<OrderedPair<long, int>> physicianIdOverReadsCountPair, IEnumerable<OrderedPair<long, int>> physicianIdAvailableEvalutionCountPair, IEnumerable<OrderedPair<long, int>> physicianIdAvaliableOverReadCountPair,
                                               IEnumerable<OrderedPair<long, double>> physicianIdAverageReviewTimePair, IEnumerable<OrderedPair<long, int>> physicianIdReEvaluationCountPair, IEnumerable<OrderedPair<long, int>> physicianIdReOverReadsCountPair,
                                               IEnumerable<OrderedPair<long, int>> physicianIdPriorityEvalutionCountPair, IEnumerable<OrderedPair<long, int>> physicianIdPriorityOverReadCountPair);
    }
}
