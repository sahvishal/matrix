using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<TestEditModel>))]
    public class TestEditModelValidator : AbstractValidator<TestEditModel>
    {
        public TestEditModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("(required)");
            RuleFor(x => x.Price).NotNull().WithMessage("(required)");
            RuleFor(x => x.RefundPrice).NotNull().WithMessage("(required)");
            RuleFor(x => x.PackagePrice).NotNull().WithMessage("(required)");
            RuleFor(x => x.PackageRefundPrice).NotNull().WithMessage("(required)");
            RuleFor(x => x.WithPackagePrice).NotNull().WithMessage("(required)");
            RuleFor(x => x.AvailableToRoleIds).NotNull().WithMessage("Atleast one role needs to be selected.");
            RuleFor(x => x.BillingAccountId).NotNull().WithMessage("(required)").When(x => x.IsTestCoveredByInsurance);
            RuleFor(x => x.BillingAccountId).Must((x, billingAccountId) => x.BillingAccountId.HasValue && x.BillingAccountId.Value > 0).WithMessage("(required)").When(x => x.IsTestCoveredByInsurance);
            RuleFor(x => x.MediaUrl).Must((x, mediaUrl) => IsValidUri(mediaUrl)).WithMessage("(provide a valid url)").When(x => !string.IsNullOrEmpty(x.MediaUrl));
            RuleFor(x => x.ChatStartDate).NotNull().WithMessage("required").Must((x, chatStartDate) => chatStartDate.HasValue && chatStartDate >= DateTime.Today.AddDays(1)).WithMessage("Only future Date accepted.").When(x => x.IsRecordable && !x.NotValidateChatStartDate && x.ResultEntryTypeId == (long)ResultEntryType.Chat);
            //RuleFor(x => x.ScreeningTime).GreaterThan(0).WithMessage("greater than 0").LessThanOrEqualTo(30).WithMessage("max 30 minutes");
        }

        private bool IsValidUri(string url)
        {
            Uri uri;
            return Uri.TryCreate(url, UriKind.Absolute, out uri);
        }
    }
}
