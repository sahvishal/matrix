using System;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class PotentialPcpChangeReportModelFilter : ModelFilterBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long AccountId { get; set; }
        public long StateId { get; set; }
    }
}
