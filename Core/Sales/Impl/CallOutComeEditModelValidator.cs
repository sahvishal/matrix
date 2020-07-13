using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Sales.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Sales.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CallOutComeEditModel>))]
    public class CallOutComeEditModelValidator : AbstractValidator<CallOutComeEditModel>
    {
        public CallOutComeEditModelValidator()
        {
            RuleFor(x => x.CallQueueCustomerId).NotNull().WithMessage("required");
            RuleFor(x => x.CallId).NotNull().WithMessage("required");
            RuleFor(x => x.CallBackDateTime).GreaterThan(DateTime.Today).When(m => m.CallBackDateTime.HasValue).WithMessage("date must be in future."); 
        }
    }
}
