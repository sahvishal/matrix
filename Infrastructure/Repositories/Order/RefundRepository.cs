using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers.Orders;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Order
{
    [DefaultImplementation(Interface = typeof(IUniqueItemRepository<Refund>))]
    public class RefundRepository : UniqueItemRepository<Refund, RefundEntity>
    {
        public RefundRepository()
            : base(new RefundMapper())
        {}

        protected override EntityField2 EntityIdField
        {
            get { return RefundFields.RefundId; }
        }
    }
}