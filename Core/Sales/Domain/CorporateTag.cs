using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Sales.Domain
{
    public class CorporateTag : DomainObjectBase
    {
        public long CorporateId { get; set; }
        public string Tag { get; set; }
        public DateTime DateCreated { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsDisabled { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CorporateTag()
        {}

        public CorporateTag(long corporateTagId)
            : base(corporateTagId)
        {}
    }
}
