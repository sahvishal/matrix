using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Marketing.Domain
{
    public class LoggedClick
        : DomainObjectBase
    {
        public long CampaignId { get; set; }
        public long MarketingMaterialId { get; set; }
        public DateTime Timestamp { get; set; }
        
        public string IpAddress { get; set; }
        public string PriorReferrer { get; set; }
        public string Referrer { get; set; }
        public string BrowserClient { get; set; }

        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }

        public string Cookie { get; set; }

        public SearchInfo[] SearchInfos { get; set; }

        public LoggedClick()
        {
            Timestamp = DateTime.Now;
        }

        public LoggedClick(long id)
            : base(id)
        {
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return "Click";
        }
    }
}