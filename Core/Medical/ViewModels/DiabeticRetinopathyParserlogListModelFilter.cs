using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class DiabeticRetinopathyParserlogListModelFilter : ModelFilterBase
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}
