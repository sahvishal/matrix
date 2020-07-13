using System.Collections.Generic;
using Falcon.App.Core.Enum;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Interfaces
{
    public interface IEventCustomerFilterPredicateFactory
    {
        List<IPredicate> CreatePredicate(EventCustomerFilterMode eventCustomerFilterMode);
        IEnumerable<CustomerOrderBasicInfoRow> GetFilteredData(EventCustomerFilterMode eventCustomerFilterMode, CustomerOrderBasicInfoTypedView customerOrderBasicInfoTypedView);
    }
}