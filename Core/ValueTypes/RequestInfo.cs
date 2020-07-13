namespace Falcon.App.Core.ValueTypes
{
    public class RequestInfo
    {
        public string ServerPath { get; set; }
        public string ServerImagePath { get; set; }
        public string AuthKey   { get; set; }
        public string IpAddress { get; set; }
        public string Referrer  { get; set; }
        public string L2Referrer { get; set; }
        public bool IsHyLinkPresent { get; set; }
        public int ResolutionWidth { get; set; }
        public int ResolutionHeight { get; set; }
        public string BrowserClient { get; set; }
    }
}