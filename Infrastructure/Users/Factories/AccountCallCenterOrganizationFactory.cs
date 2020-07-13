using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using System;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class AccountCallCenterOrganizationFactory : IAccountCallCenterOrganizationFactory
    {
        public IEnumerable<AccountCallCenterOrganizationEditModel> CreateEditModel(IEnumerable<AccountCallCenterOrganization> accountCallCenterOrganizations, IEnumerable<Organization> organizations)
        {
            if (accountCallCenterOrganizations.IsNullOrEmpty()) return null;

            var list = accountCallCenterOrganizations.Select((aco, index) => new AccountCallCenterOrganizationEditModel
            {
                OrganizationId = aco.OrganizationId,
                OrganizationName = organizations.First(x => x.Id == aco.OrganizationId).Name,
                Id = index++
            }).OrderBy(x => x.OrganizationName).ToList();

            return list;
        }

        public IEnumerable<AccountCallCenterOrganization> CreateDomain(IEnumerable<AccountCallCenterOrganizationEditModel> modelList, long accountId, long orgRoleUserId)
        {
            if (modelList.IsNullOrEmpty()) return null;
            var todayDate = DateTime.Now;

            var list = modelList.Select(model => new AccountCallCenterOrganization
            {
                AccountId = accountId,
                OrganizationId = model.OrganizationId,
                DataRecorderMetaData = new Core.Domain.DataRecorderMetaData(orgRoleUserId, todayDate, null)
            }).ToList();

            return list;
        }
    }
}
