using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Marketing.Domain
{
    public class PackageTest : DomainObjectBase // Even though we are not going to utilize the Id, but IRepository needs domain object base
    {
        public long PackageId { get; set; }
        public long TestId { get; set; }
        public decimal Price { get; set; }
        public decimal RefundPrice { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}