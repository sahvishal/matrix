using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthAssessmentQuestionEditModel>))]
    public class HealthAssessmentQuestionEditModelValidator : AbstractValidator<HealthAssessmentQuestionEditModel>
    {

    }
}