using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Finance.Impl
{
    [NoValidationRequired]
    public class CorporateAccountInvoiceListModelFilter : ModelFilterBase
    {
        public DateTime? EventFrom { get; set; }

        public DateTime? EventTo { get; set; }

        public long AccountId { get; set; }

        public string CorpCode { get; set; }

        public long EventId { get; set; }
    }
}