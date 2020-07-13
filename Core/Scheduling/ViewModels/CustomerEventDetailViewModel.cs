using System.Collections.Generic;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class CustomerEventDetailViewModel
    {
        public IEnumerable<ShortEventInfoViewModel> Events { get; set; }

        public IEnumerable<ShortPatientInfoViewModel> Customers { get; set; }
    }
}
