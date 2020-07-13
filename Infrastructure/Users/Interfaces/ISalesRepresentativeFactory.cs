using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface ISalesRepresentativeFactory
    {
        List<SalesRepresentative> CreateSalesRepresentatives(FranchiseeFranchiseeUserTypedView 
            franchiseeFranchiseeUserViewTypedView, List<User> users);
        SalesRepresentative CreateSalesRepresentative(FranchiseeFranchiseeUserRow franchiseeFranchiseeUserViewRow, User user);
    }
}