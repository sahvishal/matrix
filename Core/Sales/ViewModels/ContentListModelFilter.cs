using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class ContentListModelFilter
    {
        public string Title { get; set; }

        public bool Active { get; set; }

        public bool Inactive { get; set; }
    }
}