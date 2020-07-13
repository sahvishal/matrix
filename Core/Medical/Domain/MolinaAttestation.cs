using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class MolinaAttestation : DomainObjectBase
    {
        public long EventCustomerResultId { get; set; }
        public string Icd9Code { get; set; }
        public string Icd9CodeDescription { get; set; }
        public string Icd10Code { get; set; }
        public string Icd10CodeDescription { get; set; }
        public string Condition { get; set; }
        public long? StatusId { get; set; }
        public string WhyNoDiagnosis { get; set; }
        public DateTime? DateResolved { get; set; }
    }
}
