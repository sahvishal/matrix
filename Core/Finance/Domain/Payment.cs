using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Finance.Domain
{
    public class Payment : DomainObjectBase
    {
        public string Notes { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public Payment()
        {}

        public Payment(long paymentId)
            : base(paymentId)
        {}
    }
}