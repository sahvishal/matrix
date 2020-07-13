using System;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Domain;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ChargeCard>))]
    public class ChargeCardValidator : AbstractValidator<ChargeCard>
    {
        public ChargeCardValidator()
        {
            RuleFor(x => x.NameOnCard).NotNull().WithMessage("Name on Card is required.").NotEmpty().WithMessage("Name on Card is required.").Must(ValidateNameOnCard).WithMessage("Name on Card should have both FirstName & LastName");
            RuleFor(x => (int)x.TypeId).GreaterThan(0).WithMessage("Card Type is required.");
            RuleFor(x => x.Number).NotNull().WithMessage("Card number is required.").NotEmpty().WithMessage("Card number is required.").Must(ValidateCardNumber).WithMessage("Card Number provided is not valid to its type.");
            RuleFor(x => x.ExpirationDate).NotNull().NotEmpty().WithMessage("Expiration Date is required.").GreaterThan(DateTime.Now.AddDays(-1 * DateTime.Now.Day)).WithMessage("Card Expiry Date should be greater than current date.");
            RuleFor(x => x.CVV).NotNull().WithMessage("CVV is required.").NotEmpty().WithMessage("CVV is required.");
        }

        public bool ValidateCardNumber(ChargeCard card, string number)
        {
            if ((int)card.TypeId < 1) return true;
            if (string.IsNullOrEmpty(card.Number)) return true;

            var regex = new Regex(card.TypeId.GetRegExpression());
            var matchResult = regex.Match(card.Number);
            return matchResult.Success;
        }

        public bool ValidateNameOnCard(ChargeCard card, string nameOnCard)
        {
            if (card.NameOnCard.IsNullOrEmpty())
                return true;
            if (card.NameOnCard.Split(new[] { ' ' }).Count() > 1)
                return true;
            return false;
        }
    }
}