using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class SalesRepresentativeFactory : ISalesRepresentativeFactory
    {
        public List<SalesRepresentative> CreateSalesRepresentatives(FranchiseeFranchiseeUserTypedView 
            franchiseeFranchiseeUserViewTypedView, List<User> users)
        {
            if (franchiseeFranchiseeUserViewTypedView == null)
            {
                throw new ArgumentNullException("franchiseeFranchiseeUserViewTypedView");
            }
            if (users == null)
            {
                throw new ArgumentNullException("users");
            }
            var salesRepresentatives = new List<SalesRepresentative>();
            foreach (FranchiseeFranchiseeUserRow franchiseeFranchiseeUserViewRow in franchiseeFranchiseeUserViewTypedView)
            {
                FranchiseeFranchiseeUserRow row = franchiseeFranchiseeUserViewRow;
                var user = users.Where(u => u.Id == row.UserId).SingleOrDefault();
                if (user != null)
                {
                    SalesRepresentative salesRepresentative;
                    try
                    {
                        salesRepresentative = CreateSalesRepresentative(franchiseeFranchiseeUserViewRow, user);
                    }
                    catch (InvalidOperationException)
                    {
                        throw new InvalidOperationException(string.Format(
                                                                "User for sales representative {0} not given.",
                                                                franchiseeFranchiseeUserViewRow.
                                                                    OrganizationRoleUserId));
                    }
                    salesRepresentatives.Add(salesRepresentative);
                }
            }
            return salesRepresentatives;
        }

        public SalesRepresentative CreateSalesRepresentative(FranchiseeFranchiseeUserRow franchiseeFranchiseeUserViewRow,
            User user)
        {
            if (franchiseeFranchiseeUserViewRow == null)
            {
                throw new ArgumentNullException("franchiseeFranchiseeUserViewRow");
            }
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            return new SalesRepresentative(user.Id)
            {
                SalesRepresentativeId = franchiseeFranchiseeUserViewRow.OrganizationRoleUserId,
                FranchiseeId = franchiseeFranchiseeUserViewRow.OrganizationId,
                Name = user.Name
            };
        }
    }
}