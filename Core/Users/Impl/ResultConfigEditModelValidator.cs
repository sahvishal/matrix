using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ResultConfigEditModel>))]
    public class ResultConfigEditModelValidator : AbstractValidator<ResultConfigEditModel>
    {
        public ResultConfigEditModelValidator()
        {
            RuleFor(x => x.ResultReadyMailTemplateId).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.SendResultReadyMail);

            RuleFor(x => x.SurveyMailTemplateId).NotEmpty().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.SendSurveyMail);

            RuleFor(x => x.CustomerResultTestDependency).NotNull().WithMessage("must have alteast one dependency").NotEmpty().WithMessage("must have alteast one dependency").Must((x, y) => y != null && y.Count() > 1)
                .WithMessage("must have alteast one dependency").When(x => x.IsCustomerResultsTestDependent);

            RuleFor(x => x.PcpResultTestDependency).NotNull().WithMessage("must have alteast one dependency").NotEmpty().WithMessage("must have alteast one dependency").Must((x, y) => y != null && y.Count() > 1)
                .WithMessage("must have alteast one dependency").When(x => x.GeneratePcpResult);

            RuleFor(x => x.PublicKeyFile).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required")
                .When(x => x.EnablePgpEncryption);

            RuleFor(x => x.HealthPlanResultTestDependency).NotNull().WithMessage("must have alteast one dependency").NotEmpty().WithMessage("must have alteast one dependency").Must((x, y) => y != null && y.Count() > 1)
                .WithMessage("must have alteast one dependency").When(x => x.GenerateHealthPlanReport);

            RuleFor(x => x.PennedBackText).NotNull().WithMessage("required").NotEmpty().WithMessage("required").When(x => x.MarkPennedBack);

            RuleFor(x => x.MemberLetter).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required")
                .When(x => x.IncludeMemberLetter && !x.IsMemberCoverLetterSelected);

            RuleFor(x => x.MemberCoverLetterTemplateId).NotNull().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.IncludeMemberLetter && x.IsMemberCoverLetterSelected);

            RuleFor(x => x.PcpLetterPdf).NotNull().WithMessage("Required").NotEmpty().WithMessage("Required").Must((x, y) => y != null && !string.IsNullOrEmpty(y.Caption)).WithMessage("Required")
                .When(x => x.GeneratePcpLetter && !x.IsPcpCoverLetterSelected);

            RuleFor(x => x.PcpCoverLetterTemplateId).NotNull().WithMessage("Required").GreaterThan(0).WithMessage("Required").When(x => x.GeneratePcpLetter && x.IsPcpCoverLetterSelected);

        }
    }
}