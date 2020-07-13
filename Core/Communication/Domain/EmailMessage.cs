namespace Falcon.App.Core.Communication.Domain
{
    public class EmailMessage
    {
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromName { get; set; }
    }
}