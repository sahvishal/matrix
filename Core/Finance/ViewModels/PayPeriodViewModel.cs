using System;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodViewModel : ViewModelBase
    {
        public long PayPerioidId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public long NumberOfWeek { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Createdby { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string Modifiedby { get; set; }
        public bool IsPublished { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<PayPeriodCriteriaViewModel> Criteria { get; set; }
    }
}
