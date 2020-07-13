using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class PayPeriodEditModel : ViewModelBase
    {
        public long PayPeriodId { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public int NumberOfWeek { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }

        public IEnumerable<PayPeriodCriteriaEditModel> Criteria { get; set; }

        public PayPeriodEditModel()
        {
            NumberOfWeek = 2;
        }
    }
}
