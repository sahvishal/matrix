﻿using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ECheckPayment>))]
    public class ECheckPaymentValidator : AbstractValidator<ECheckPayment>
    {
        public ECheckPaymentValidator()
        {
            RuleFor(x => x.Amount).NotEqual(0).WithMessage("Charge/Refund Amount on a card can not be zero.");
        }
    }
}