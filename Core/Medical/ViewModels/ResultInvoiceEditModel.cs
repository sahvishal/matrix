using System;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class ResultInvoiceEditModel
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        
        public DateTime InvoiceDate { get; set; }

        public string CurrentResultState { get; set; }
        public string CurrentResultStateDescription { get; set; }
        public long CurrentRestultStateNumber { get; set; }
        public bool SyncedSuccess { get; set; }
    }
}