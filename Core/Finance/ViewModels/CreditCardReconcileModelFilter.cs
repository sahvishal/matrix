using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.ViewModels
{
    public class CreditCardReconcileModelFilter : ModelFilterBase
    {
        // For the card charge date range
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool IsRetailEvent { get; set; }
        public bool IsCorporateEvent { get; set; }
        public long AccountId { get; set; }
    }

    [DefaultImplementation(Interface = typeof(IValidator<CreditCardReconcileModelFilter>))]
    public class CreditCardReconcileModelFilterValidator: AbstractValidator<CreditCardReconcileModelFilter>
    {
        public CreditCardReconcileModelFilterValidator()
        {
            
        }
    }

}