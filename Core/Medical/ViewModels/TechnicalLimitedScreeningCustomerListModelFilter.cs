using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TechnicalLimitedScreeningCustomerListModelFilter : ModelFilterBase
    {
        public string CustomerName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int ResultState { get; set; }
        public long Test { get; set; }
        public string Pod { get; set; }
        public bool IsNewResultStateFlow { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<TechnicalLimitedScreeningCustomerListModelFilter>))]
    public class TechnicalLimitedScreeningCustomerListModelFilterValidator : AbstractValidator<TechnicalLimitedScreeningCustomerListModelFilter>
    {
        
    }

}