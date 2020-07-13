using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class OnlineEventListModel
    {
        public IEnumerable<OnlineEventViewModel> Events { get; set; }
        public OnlineRequestValidationModel RequestValidationModel { get; set; }
        public string CheckoutPhoneNumber { get; set; }
        public long TotalEvents { get; set; }
        [IgnoreAudit]
        public PagingModel PagingModel { get; set; }

    }
}
