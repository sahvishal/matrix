using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface ISourceCodeOrderDetailRepository : IRepository<SourceCodeOrderDetail>
    {
        bool UpdateStatus(long sourceCodeId, long orderDetailId, bool status);
        bool UpdateAmount(long sourceCodeId, long orderDetailId, decimal amount, long organizationRoleUserCreatorId);
        IEnumerable<SourceCodeOrderDetail> GetForOrderDetailId(long orderDetailId);
        SourceCodeOrderDetail GetForSourceCodeIdAndOrderDetailId(long sourceCodeId, long orderDetailId);
        int GetSourceCodeUsageCount(long sourceCodeId);
        bool IsSourceCodeAppliedforGivenEventCustomer(long sourceCodeId, long eventId, long customerId);
        IEnumerable<SourceCodeOrderDetail> GetForOrder(long orderId);
    }
}