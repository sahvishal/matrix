using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Finance.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<ProductstoOfferModel>))]
    public class ProductstoOfferModelValidator : AbstractValidator<ProductstoOfferModel>
    {
        public ProductstoOfferModelValidator()
        {
            
        }
    }
}