using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IInsuranceServiceTypeRepository
    {
        IEnumerable<InsuranceServiceType> GetAll();
        InsuranceServiceType GetById(long id);
        IEnumerable<InsuranceServiceType> GetByIds(IEnumerable<long> ids);
    }
}
