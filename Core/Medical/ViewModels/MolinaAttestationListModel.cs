using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class MolinaAttestationListModel
    {
        public long EventCustomerResultId { get; set; }
        public List<MolinaAttestationViewModel> Attestations { get; set; }
        public string CustomerName { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? CustomerDob { get; set; }
        public long EventId { get; set; }
        public long CustomerId { get; set; }

        public bool ModelForPrint { get; set; }
    }
}
