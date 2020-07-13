using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class Raps : DomainObjectBase
    {
        public long RapsUploadId { get; set; }
        public string CmsHicn { get; set; }
        public DateTime? MemberDob { get; set; }
         
        public string MemberId { get; set; }
        public int? IcdVersion { get; set; }
        public DateTime? ServiceDate { get; set; }
        public string IcdCode { get; set; }

        public long CustomerId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public bool IsSynced { get; set; }
     }
}
