using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    [NoValidationRequired]
    public class HiptoAcesCrossWalkViewModelFilter
    {
        public string Tag { get; set; }
        public bool CustomerOnlyWithAcesId { get; set; }
        public bool OnlyEligibileCustomer { get; set; }
        public int? Year { get; set; }

    }
}
