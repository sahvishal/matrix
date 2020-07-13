using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.ValueTypes;
using FluentValidation;

namespace Falcon.App.Core.Scheduling.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EnableTextingEditModel>))]
    public class EnableTextingEditModelValidator : AbstractValidator<EnableTextingEditModel>
    {
        public EnableTextingEditModelValidator()
        {
            //RuleFor(x => x.PhoneCell).Must((x, y) => x.PhoneCell != null && PhoneNumber.ToNumber(x.PhoneCell.ToString()).Length != 10).WithMessage("Phone number is not valid").When(x => x.EnableTexting);

            RuleFor(x => x.PhoneCell).SetValidator(new PhoneNumberRequiredValidator()).When(x => x.EnableTexting);
        }
    }
}
