using Falcon.App.Core.Communication.Enum;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class EFaxResponse
    {
        public string TransmissionId { get; set; }
        public EFaxStatusCode StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public EFaxErrorLevel ErrorLevel { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class EFaxOutboundResponsStatus
    {
        public string Classification { get; set; }
        public string Message { get; set; }
        public string Outcome { get; set; }
    }
}