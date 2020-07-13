using System.Collections.Generic;

namespace Falcon.App.Core.Users
{
    public interface IProspectContactRoleRepository
    {
        List<OrderedPair<short,string>> GetAllProspectContactRole();
    }
}