using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class EventCustomerConsentsListModel
    {
        public IEnumerable<EventCustomerConsents> CustomersConsent { get; set; }
    }
}