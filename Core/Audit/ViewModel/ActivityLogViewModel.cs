using System;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class ActivityLogViewModel
    {
        public string LogId { get; set; }
        public long AccessedById { get; set; }
        public Name AccessedBy { get; set; }
        public string UrlAccessed { get; set; }
        public string UrlAlias { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestType { get; set; }
        public string Action { get; set; }
        public string ClientIp { get; set; }
        public string ClientBrowser { get; set; }
        public long CustomerId { get; set; }
        public Name Customer { get; set; }
    }
}
