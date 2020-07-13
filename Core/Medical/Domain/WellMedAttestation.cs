using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class WellMedAttestation : DomainObjectBase
    {
        public long EventCustomerResultId { get; set; }
        public string DiagnosisCode { get; set; }
        public DateTime? ReferenceDate { get; set; }
        public long? StatusId { get; set; }
        public long? ProviderSignatureFileId { get; set; }
        public string FullPrintedName { get; set; }
        public DateTime? DiagnosisDate { get; set; }
    }
}
