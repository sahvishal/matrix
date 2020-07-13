using Falcon.App.Core.Operations.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Operations.Impl
{
    public class PodStaffModelValidator : AbstractValidator<PodStaffEditModel>
    {
        public PodStaffModelValidator()
        {
            RuleFor(x => x.OrganizationRoleUserId).GreaterThan(0);
            RuleFor(x => x.EventRoleId).GreaterThan(0);      
        }
        
    }
}