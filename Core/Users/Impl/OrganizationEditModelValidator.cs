using Falcon.App.Core.Users.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Users.Impl
{
    public class OrganizationEditModelValidator : AbstractValidator<OrganizationEditModel>
    {
        //TODO put more rules
        
        public OrganizationEditModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("(required)");
            RuleFor(x => x.Name).NotEmpty().WithMessage("(required)");
            RuleFor(x => x.Name).Length(3, 50).WithMessage("(2-50 chars)");

            RuleFor(org => org.Email).EmailAddress().When(org => !string.IsNullOrWhiteSpace(org.Email));
            RuleFor(org => org.BusinessAddress).Must(add => !add.IsEmpty()).WithMessage("required");


            RuleFor(org => org.Description).NotNull().NotEmpty().WithMessage("(required)").Length(2, 2000).WithMessage("(2-2000 chars)");

            //RuleFor(org => org.BusinessAddress1).SetValidator(new AddressEditModelValidator());
            //RuleFor(org => org.BillingAddress1).SetValidator(new AddressEditModelValidator()).When(
            //    org => org.BillingAddress1.IsEmpty());
        }


    }
}