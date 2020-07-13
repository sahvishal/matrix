using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Medical.Domain
{
    public class TestHcpcsCode : DomainObjectBase
    {
        public long TestId { get; set; }
        public long HcpcsCodeId { get; set; }
        public bool IsRetired { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
