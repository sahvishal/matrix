using System;
using System.Collections.Generic;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Users;

namespace Falcon.App.Core.Communication.Impl
{
    public class LostProspectFinder : ILostProspectFinder
    {
        private readonly IProspectCustomerRepository _prospectCustomerRepository;

        public LostProspectFinder(IProspectCustomerRepository prospectCustomerRepository)
        {
            _prospectCustomerRepository = prospectCustomerRepository;
        }

        public IEnumerable<ProspectCustomer> GetAbandonedProspectsAfter(DateTime lastChecked)
        {
            _prospectCustomerRepository.GetProspectCustomersAfter(lastChecked);
            throw new NotImplementedException();
        }
    }
}