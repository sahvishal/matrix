using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.OutboundReport.Domain
{
    public class LoincLabData : DomainObjectBase
    {
        public string MemberId { get; set; }
        public string Gmpi { get; set; }
        public string Loinc { get; set; }
        public string LoincDescription { get; set; }
        public string ResultValue { get; set; }
        public string ResultUnits { get; set; }
        public string RefRange { get; set; }
        public long UploadId { get; set; }
        public int Year { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateOfService { get; set; }

        public bool IsEmpty()
        {
            return (string.IsNullOrEmpty(MemberId) && string.IsNullOrEmpty(Gmpi)
                && string.IsNullOrEmpty(Loinc) && string.IsNullOrEmpty(LoincDescription)
                    && string.IsNullOrEmpty(ResultValue) && string.IsNullOrEmpty(ResultUnits)
                    && string.IsNullOrEmpty(RefRange));
        }
    }
}
