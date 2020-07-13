using System;

namespace Webhook.Models
{
    public class TwillioMessageResponse
    {
        public string AccountSid { get; set; }
        public string ApiVersion { get; set; }
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateSent { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Direction { get; set; }
        public string From { get; set; }
        public int NumImages { get; set; }
        public int NumSegments { get; set; }
        public decimal Price { get; set; }
        public string Sid { get; set; }
        public string Status { get; set; }
        public string To { get; set; }
    }


}