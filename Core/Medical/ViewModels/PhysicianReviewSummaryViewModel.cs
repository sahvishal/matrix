using System.ComponentModel;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PhysicianReviewSummaryViewModel : ViewModelBase
    {
        [DisplayName("Physician Name")]
        public string PhysicianName { get; set; }

        [DisplayName("Total Reviews")]
        public int TotalReviews { get; set; }

        [DisplayName("Evaluations Done (Review)")]
        public int Reviews { get; set; }

        [DisplayName("Re-Evaluations Done (Review)")]
        public int ReReviews { get; set; }

        [DisplayName("Total Overreads")]
        public int TotalOverReads { get; set; }

        [DisplayName("Evaluations Done (Overread)")]
        public int OverReads { get; set; }

        [DisplayName("Re-Evaluations Done (Overread)")]
        public int ReOverReads { get; set; }

        [DisplayName("Average Review/Overread Time")]
        public string AverageReviewTime { get; set; }

        [DisplayName("Estimated Earning")]
        [Hidden]
        public decimal EstimatedEarning { get; set; }

        [DisplayName("In Queue(Review)")]
        public int PrimaryEvaluationInQueue { get; set; }

        [DisplayName("In Queue(Overread)")]
        public int OverReadEvaluationInQueue { get; set; }

        [DisplayName("Priority In Queue(Review)")]
        public int PrimaryEvaluationPriorityInQueue { get; set; }

        [DisplayName("Priority In Queue(Overread)")]
        public int OverReadEvaluationPriorityInQueue { get; set; }

        [Hidden]
        public long PhysicianId { get; set; }
    }
}
