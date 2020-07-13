using System.Text.RegularExpressions;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<Check>))]
    public class CheckValidator : AbstractValidator<Check>
    {
        public CheckValidator()
        {
            RuleFor(x => x.Amount).NotNull().NotEmpty().WithMessage("Specify the Amount.");
            RuleFor(x => x.CheckDate).NotNull().NotEmpty().WithMessage("Check Date is required.").When(x => x.IsElectronicCheck);
            RuleFor(x => x.BankName).NotNull().NotEmpty().WithMessage("Bank Name is required.").When(x => x.IsElectronicCheck);
            RuleFor(x => x.AccountNumber).NotNull().NotEmpty().WithMessage("Account Number is required.").When(x => x.IsElectronicCheck);
            RuleFor(x => x.AcountHolderName).NotNull().NotEmpty().WithMessage("Account Holder Name is required.").When(x => x.IsElectronicCheck);
            RuleFor(x => x.RoutingNumber).NotNull().NotEmpty().WithMessage("Routing Number is required.").When(x => x.IsElectronicCheck);
            RuleFor(x => x.PayableTo).NotNull().WithMessage("Payable To is required.").NotEmpty().WithMessage("Payable To is required.");
            RuleFor(x => x.CheckNumber).NotNull().WithMessage("Check Number is required.").NotEmpty().WithMessage("Check Number is required.");
            RuleFor(x => x.CheckNumber).Must(ValidateCheckNumber).When(x => !string.IsNullOrWhiteSpace(x.CheckNumber)).WithMessage("Check number can be Alphanumeric only.");
        }
        
        public bool ValidateCheckNumber(Check check, string number)
        {
            if (string.IsNullOrEmpty(check.CheckNumber)) return true;

            var regex = new Regex("^[a-zA-Z0-9]*$");
            var matchResult = regex.Match(check.CheckNumber);
            return matchResult.Success;
        }
    }
}