using System;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareRapsViewModel
    {
        public long Id { get; set; }
        public long RapsUploadId { get; set; }
        public string CmsHicn { get; set; }
        public DateTime? MemberDob { get; set; } 
        public string MemberId { get; set; }
        public int IcdVersion { get; set; }
        public DateTime? ServiceDate { get; set; }
        public string IcdCode { get; set; }

        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
    }
}
