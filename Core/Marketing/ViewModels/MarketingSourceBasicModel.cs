using System.Collections.Generic;

namespace Falcon.App.Core.Marketing.ViewModels
{
    public class MarketingSourceBasicModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Territories { get; set; } 
    }
}