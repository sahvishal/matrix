using Falcon.App.Core.Application.Attributes;
using System;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class ViciDialerCallModel
    {
        public long CustomerId { get; set; }
        public string CallerId { get; set; }
        public string Disposition { get; set; }
        public DateTime CallStartDateTime { get; set; }
        public DateTime CallEndDateTime { get; set; }
        public long CallQueueId { get; set; }
        public string CallerPhoneNumber { get; set; }
    }
}
