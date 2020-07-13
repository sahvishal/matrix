using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface ISalesRepresentativeRepository
    {
        List<SalesRepresentative> GetSalesRepresentativesForFranchisee(long franchiseeId);
        List<SalesRepresentative> GetAllSalesRepresentatives();
    }
}