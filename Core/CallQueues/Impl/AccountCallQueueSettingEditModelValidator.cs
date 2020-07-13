using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallQueues.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<AccountCallQueueSettingEditModel>))]
    public class AccountCallQueueSettingEditModelValidator : AbstractValidator<AccountCallQueueSettingEditModel>
    {
        /*public AccountCallQueueSettingEditModelValidator()
        {
            RuleFor(x => x.AccountId).NotEqual(-1).WithMessage("required").NotNull().WithMessage("required");
            RuleFor(x => x.CallQueueId).NotEqual(-1).WithMessage("required").NotNull().WithMessage("required");
            RuleFor(x => x.SuppressionTypeId).NotEqual(-1).WithMessage("required").NotNull().WithMessage("required");
            RuleFor(x => x.NoOfDays).NotNull().WithMessage("required").NotEmpty().WithMessage("required").GreaterThan(0).WithMessage("should be greater than 0").LessThan(100).WithMessage("should be less than 100");
        }*/
    }
}
