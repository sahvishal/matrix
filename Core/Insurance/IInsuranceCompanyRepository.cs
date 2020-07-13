using System.Collections.Generic;
using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IInsuranceCompanyRepository
    {
        IEnumerable<InsuranceCompany> GetAll();
        InsuranceCompany GetById(long id);
        IEnumerable<InsuranceCompany> GetByIds(IEnumerable<long> ids);
    }
}
