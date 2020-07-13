using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface ITempCartRepository: IRepository<TempCart>
    {
        TempCart Get(string guid, bool isCompleted = false);
        void DeleteByProspectCustomerId(long prospectCustomerId);
        void DeleteByProspectCustomerIds(IEnumerable<long> prospectCustomerIds);
    }
}