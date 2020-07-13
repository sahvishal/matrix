using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Communication.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Communication.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<EmailTemplateEditModel>))]
    public class EmailTemplateEditModelValidator : AbstractValidator<EmailTemplateEditModel>
    {
        public EmailTemplateEditModelValidator(IEmailTemplateService emailTemplateService)
        {
            RuleFor(x => x.Body).NotNull().WithMessage("required").NotEmpty().WithMessage("required");

            RuleFor(x => x.Body).Must((x, y) => emailTemplateService.IsEmailTemplateValid(x.Id, x.Body,x.NotificationTypeId)).WithMessage(
                    "Template didn't parse correctly. Invalid Macros.").When(x => !string.IsNullOrEmpty(x.Body));

            RuleFor(x => x.Subject).NotNull().WithMessage("required").NotEmpty().WithMessage("required");
        }
    }
}