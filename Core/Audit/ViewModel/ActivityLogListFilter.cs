using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Audit.ViewModel
{
    [NoValidationRequired]
    public class ActivityLogListFilter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Enum.Type AccessType { get; set; }
        public long AccessedBy { get; set; }
        public string AccessedByName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
    }
}
