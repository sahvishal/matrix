using System;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class ActivityLogEditModel
    {
        public long UserLogId { get; set; }
        public long AccessById { get; set; } 
        public long CustomerId { get; set; } 
        public string UrlAccessed { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestType { get; set; }
        public string Action { get; set; }
        public string ModelFullName { get; set; }
        public string ModelName { get; set; }
    }
}
