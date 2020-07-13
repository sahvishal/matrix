using System;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Operations.Domain
{
    public class ResultArchiveLog : DomainObjectBase
    {
        public long ResultArchiveId { get; set; }
        public TestType TestId { get; set; }
        public long CustomerId { get; set; }
        public string MedicalEquipmentTag { get; set; }

        public bool IsSuccessful { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}