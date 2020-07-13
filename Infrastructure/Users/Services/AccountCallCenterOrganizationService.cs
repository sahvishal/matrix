using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.ViewModels;
using System;

namespace Falcon.App.Infrastructure.Users.Services
{
    [DefaultImplementation]
    public class AccountCallCenterOrganizationService : IAccountCallCenterOrganizationService
    {
        private readonly IAccountCallCenterOrganizationRepository _accountCallCenterOrganizationRepository;
        private readonly IAccountCallCenterOrganizationFactory _accountCallCenterOrganizationFactory;
        private readonly IOrganizationRepository _organizationRepository;

        public AccountCallCenterOrganizationService(IAccountCallCenterOrganizationRepository accountCallCenterOrganizationRepository, IAccountCallCenterOrganizationFactory accountCallCenterOrganizationFactory,
            IOrganizationRepository organizationRepository)
        {
            _accountCallCenterOrganizationRepository = accountCallCenterOrganizationRepository;
            _accountCallCenterOrganizationFactory = accountCallCenterOrganizationFactory;
            _organizationRepository = organizationRepository;
        }

        public void Save(IEnumerable<AccountCallCenterOrganizationEditModel> accountCallCenterOrganizations, long accountId, long orgRoleUserId, bool restrictHealthPlanData)
        {
            if (!restrictHealthPlanData)
            {
                _accountCallCenterOrganizationRepository.MarkAsDeletedByAccountId(accountId, orgRoleUserId);
            }
            else
            {
                var existingAccountCallCenterOrganizations = _accountCallCenterOrganizationRepository.GetByAccountId(accountId);

                if (existingAccountCallCenterOrganizations.IsNullOrEmpty())
                {
                    var domain = _accountCallCenterOrganizationFactory.CreateDomain(accountCallCenterOrganizations, accountId, orgRoleUserId);
                    _accountCallCenterOrganizationRepository.Save(domain);
                }
                else
                {
                    var existingOrganizationIDs = existingAccountCallCenterOrganizations.Select(x => new { x.OrganizationId });
                    var newOrganizationIDs = accountCallCenterOrganizations.Select(x => new { x.OrganizationId });

                    var deleteOrganizations = existingOrganizationIDs.Except(newOrganizationIDs);
                    var addOrganizations = newOrganizationIDs.Except(existingOrganizationIDs);

                    if (!deleteOrganizations.IsNullOrEmpty())
                    {
                        var accountOrganizationsIds = existingAccountCallCenterOrganizations.Where(x => deleteOrganizations.Contains(new { x.OrganizationId })).Select(x => x.Id);
                        _accountCallCenterOrganizationRepository.MarkAsDeletedByIds(accountOrganizationsIds, orgRoleUserId);
                    }

                    if (!addOrganizations.IsNullOrEmpty())
                    {
                        var newAccountOrganizationsToAdd = accountCallCenterOrganizations.Where(x => addOrganizations.Contains(new { x.OrganizationId }));

                        var domain = _accountCallCenterOrganizationFactory.CreateDomain(newAccountOrganizationsToAdd, accountId, orgRoleUserId);
                        _accountCallCenterOrganizationRepository.Save(domain);
                    }
                }
            }
        }

        public IEnumerable<AccountCallCenterOrganizationEditModel> GetEditModel(IEnumerable<AccountCallCenterOrganization> accountCallCenterOrganization)
        {
            var organizationIds = accountCallCenterOrganization.Select(x => x.OrganizationId).Distinct().ToArray();
            var organizations = _organizationRepository.GetOrganizations(organizationIds);

            return _accountCallCenterOrganizationFactory.CreateEditModel(accountCallCenterOrganization, organizations);
        }
    }
}
