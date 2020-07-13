using System.Collections.Generic;

namespace Falcon.App.Core.Sales.ViewModels
{
    public class CorporateTagViewModel
    {
        public long AccountId { get; set; }
        public string Tag { get; set; }
        public IEnumerable<string> CustomTags { get; set; }
    }
}
