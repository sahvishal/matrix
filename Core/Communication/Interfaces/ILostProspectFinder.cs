using System;
using System.Collections.Generic;
using Falcon.App.Core.Marketing.Domain;

namespace Falcon.App.Core.Communication.Interfaces
{
    public interface ILostProspectFinder
    {
        IEnumerable<ProspectCustomer> GetAbandonedProspectsAfter(DateTime lastChecked);
    }
}