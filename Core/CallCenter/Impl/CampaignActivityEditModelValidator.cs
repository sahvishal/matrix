using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallCenter.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallCenter.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<CampaignActivityEditModel>))]
    public class CampaignActivityEditModelValidator : AbstractValidator<CampaignActivityEditModel>
    {
        public CampaignActivityEditModelValidator()
        {
            RuleFor(x => x.ActivityDate).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
            RuleFor(x => x.ActivityType).GreaterThan(0).WithMessage("required");
            RuleFor(x => x.Assignments).NotNull().WithMessage("required").When(x => x.ActivityType == (long)CampaignActivityType.DirectMail);
            RuleFor(x => x.DirectMailType).GreaterThan(0).WithMessage("required").When(x => x.ActivityType == (long)CampaignActivityType.DirectMail);
            RuleFor(x => x.ActivityDate).GreaterThanOrEqualTo(x => x.CampaignStartDate).WithMessage("can not be less than campaign start date").When(x => x.CampaignStartDate.HasValue);
            RuleFor(x => x.ActivityDate).LessThanOrEqualTo(x => x.CampaignEndDate).WithMessage("can not be greater than campaign end date").When(x => x.CampaignEndDate.HasValue);
            RuleFor(x => x.ActivityDate).LessThanOrEqualTo(x => x.CampaignEndDate).WithMessage("can not be greater than campaign end date").When(x => x.CampaignEndDate.HasValue);
            RuleFor(x => x.ActivityDate).Must((x, activityDate) => activityDate.HasValue && activityDate >= DateTime.Today).WithMessage("must have future date.").When(x => x.ActivityDate.HasValue && x.ActivityEditMode);
        }
    }
}