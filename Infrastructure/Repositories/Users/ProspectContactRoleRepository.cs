using System.Collections.Generic;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    [DefaultImplementation]
    public class ProspectContactRoleRepository : PersistenceRepository, IProspectContactRoleRepository
    {
        public List<OrderedPair<short,string>> GetAllProspectContactRole()
        { 
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var organizationRoleUserEntities = linqMetaData.ProspectContactRole;
                var listproscontrole = new List<OrderedPair<short, string>>();
                
                foreach (var drproscont in organizationRoleUserEntities)
                {
                    var objproscontrole = new OrderedPair<short, string>();
                    objproscontrole.FirstValue = (short)drproscont.ProspectContactRoleId;
                    objproscontrole.SecondValue = drproscont.ProspectContactRoleName;
                    listproscontrole.Add(objproscontrole);
                }
                return listproscontrole;

            }
        }
    }
}
