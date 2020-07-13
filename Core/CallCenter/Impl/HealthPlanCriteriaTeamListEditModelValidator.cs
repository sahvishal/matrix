using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallCenter.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.CallCenter.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<HealthPlanCriteriaTeamListEditModel>))]
    public class HealthPlanCriteriaTeamListEditModelValidator : AbstractValidator<HealthPlanCriteriaTeamListEditModel>
    {

    }
}