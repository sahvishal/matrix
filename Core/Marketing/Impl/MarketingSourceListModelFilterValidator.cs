using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Marketing.ViewModels;
using FluentValidation;

namespace Falcon.App.Core.Marketing.Impl
{
    [DefaultImplementation(Interface = typeof(IValidator<MarketingSourceListModelFilter>))]
    public class MarketingSourceListModelFilterValidator: AbstractValidator<MarketingSourceListModelFilter>
    {
        public MarketingSourceListModelFilterValidator()
        {
            
        }
    }
}