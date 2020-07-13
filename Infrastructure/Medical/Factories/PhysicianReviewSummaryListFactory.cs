using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PhysicianReviewSummaryListFactory : IPhysicianReviewSummaryListFactory
    {
        public PhysicianReviewSummaryListModel Create(IEnumerable<long> physicianIds, IEnumerable<OrderedPair<long, string>> physiciansIdNamePair, IEnumerable<OrderedPair<long, int>> physicianIdReviewCountPair,
            IEnumerable<OrderedPair<long, int>> physicianIdOverReadsCountPair, IEnumerable<OrderedPair<long, int>> physicianIdAvailableEvalutionCountPair, IEnumerable<OrderedPair<long, int>> physicianIdAvaliableOverReadCountPair,
            IEnumerable<OrderedPair<long, double>> physicianIdAverageReviewTimePair, IEnumerable<OrderedPair<long, int>> physicianIdReEvaluationCountPair, IEnumerable<OrderedPair<long, int>> physicianIdReOverReadsCountPair,
            IEnumerable<OrderedPair<long, int>> physicianIdPriorityEvalutionCountPair, IEnumerable<OrderedPair<long, int>> physicianIdPriorityOverReadCountPair)
        {
            var model = new PhysicianReviewSummaryListModel();

            var physicianReviews = new List<PhysicianReviewSummaryViewModel>();

            physicianIds.ToList().ForEach(pid =>
                                              {
                                                  var physicianName = physiciansIdNamePair.Where(p => p.FirstValue == pid).First().SecondValue;

                                                  var reviewCount = physicianIdReviewCountPair.Where(prc => prc.FirstValue == pid).First().SecondValue;

                                                  var reReviewCount = physicianIdReEvaluationCountPair.Where(prc => prc.FirstValue == pid).Select(prc=>prc.SecondValue).FirstOrDefault();

                                                  var overReadCount = physicianIdOverReadsCountPair.Where(poc => poc.FirstValue == pid).First().SecondValue;

                                                  var reOverReadCount = physicianIdReOverReadsCountPair.Where(prc => prc.FirstValue == pid).Select(prc => prc.SecondValue).FirstOrDefault();

                                                  var availableEvaluationCount = physicianIdAvailableEvalutionCountPair.Where(pae => pae.FirstValue == pid).First().SecondValue;

                                                  var availableOverReadCount = physicianIdAvaliableOverReadCountPair.Where(pao => pao.FirstValue == pid).First().SecondValue;

                                                  var priorityEvaluationCount = physicianIdPriorityEvalutionCountPair.First(pae => pae.FirstValue == pid).SecondValue;

                                                  var priorityOverReadCount = physicianIdPriorityOverReadCountPair.First(pao => pao.FirstValue == pid).SecondValue;

                                                  var averageReviewTimePair =
                                                      physicianIdAverageReviewTimePair.Where(
                                                          art => art.FirstValue == pid).FirstOrDefault();
                                                  var averageReviewTime = averageReviewTimePair != null
                                                                              ? TimeSpan.FromSeconds(
                                                                                  averageReviewTimePair.SecondValue)
                                                                              : TimeSpan.FromSeconds(0);
                                                  physicianReviews.Add(new PhysicianReviewSummaryViewModel
                                                                           {
                                                                               PhysicianId = pid,
                                                                               PhysicianName = physicianName,
                                                                               TotalReviews = reviewCount + reReviewCount,
                                                                               Reviews = reviewCount,
                                                                               ReReviews = reReviewCount,
                                                                               OverReads = overReadCount,
                                                                               ReOverReads = reOverReadCount,
                                                                               TotalOverReads = overReadCount + reOverReadCount,
                                                                               PrimaryEvaluationInQueue = availableEvaluationCount,
                                                                               OverReadEvaluationInQueue = availableOverReadCount,
                                                                               PrimaryEvaluationPriorityInQueue = priorityEvaluationCount,
                                                                               OverReadEvaluationPriorityInQueue = priorityOverReadCount,
                                                                               AverageReviewTime = string.Format("{0:D2}min {1:D2}sec", averageReviewTime.Minutes, averageReviewTime.Seconds)
                                                                           });
                                              });
            model.Collection = physicianReviews;

            return model;
        }
    }
}
