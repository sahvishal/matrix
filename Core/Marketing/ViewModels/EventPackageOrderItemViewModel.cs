using System.Collections.Generic;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class EventPackageOrderItemViewModel
    {
        public long PackageId { get; set; }
        public long EventPackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DescriptiononUpsellSection { get; set; }
        public decimal Price { get; set; }
        public MediaLocation ImageUrlForOnlineDisplay { get; set; }
        public IEnumerable<EventTestOrderItemViewModel> Tests { get; set; }
        public string PackageInfoUrl { get; set; }
        public bool NotAvailable { get; set; }
        public string NotAvailabilityMessage { get; set; }
        public bool IsRecommended { get; set; }
        public bool IsLowestPrice { get; set; }
        public bool IsHighestPrice { get; set; }
        public int DisplaySequence { get; set; }
        public bool MostPopular { get; set; }
        public bool BestValue { get; set; }
    }
}