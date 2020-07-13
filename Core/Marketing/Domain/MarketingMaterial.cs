using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class MarketingMaterial
        : DomainObjectBase
    {
        public MarketingMaterial()
        { }
    
        public MarketingMaterial(long id)
            : base(id)
        { }
        
        public string   Title { get; set; }
        public string   Description { get; set; }
        public bool     IsEventSpecific { get; set; }
        public long     TypeId { get; set; }

        public bool?    IsInbound { get; set; }
        public bool?    IsDefault { get; set; }

        public string   LeadingInUrl { get; set; }
        public string   DisplayUrl   { get; set; }
        
        public string   ImagePath { get; set; }
        public string   ThumbnailImage { get; set; }

        public string   HTMLText { get; set; }

        public string   Text { get; set; }
        public string   HeadingText { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }

        public bool?    IsInternal { get; set; }
        public long?    EventId { get; set; }

        public long?    MarketingOfferId { get; set; }
    }
}