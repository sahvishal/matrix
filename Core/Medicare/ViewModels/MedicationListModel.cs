using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicationListModel
    {
        public IEnumerable<MedicationEditModel> Medications { get; set; }
        public IEnumerable<Lookup> Frequency { get; set; }
        public IEnumerable<Unit> Unit { get; set; }
        public long CustomerId { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
