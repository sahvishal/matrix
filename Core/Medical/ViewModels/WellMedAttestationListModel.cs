using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class WellMedAttestationListModel : ViewModelBase
    {
        public IEnumerable<WellMedAttestationViewModel> Attestations { get; set; }
        public long EventCustomerResultId { get; set; }
        public string CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? CustomerDob { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public bool LayoutForPrint { get; set; }
    }
}
