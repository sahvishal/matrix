using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class BioCheckJsonViewModel
    {
        public string ProfileId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime? DoB { get; set; }
        public string Email { get; set; }
        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public string ResponseId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime CompletedAt { get; set; }
        public string reportSvg { get; set; }
        public string reportPdf { get; set; }
        public string UniqueId { get; set; }
        public string Exfld03 { get; set; }
        public BioCheckResponseModel[] Responses { get; set; }
    }
}
