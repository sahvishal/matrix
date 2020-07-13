using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class PodTeamModelValidator : AbstractValidator<PodTeamEditModel>
    {
        public PodTeamModelValidator()
        {
            RuleFor(x => x.OrganizationRoleUserId).GreaterThan(0);
            RuleFor(x => x.EventRoleId).GreaterThan(0);      
        }
        
    }
}