using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class EventTestOrderItemViewModel
    {
        public long TestId { get; set; }
        public long EventTestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string Alias { get; set; }
        public decimal WithPackageprice { get; set; }
        public bool NotAvailable { get; set; }
        public string NotAvailabilityMessage { get; set; }
        public int RelativeOrder { get; set; }
        public bool AddDefaultToOrder { get; set; }

        public string MediaUrl { get; set; }
        public IEnumerable<Test> Tests { get; set; }
    }
}