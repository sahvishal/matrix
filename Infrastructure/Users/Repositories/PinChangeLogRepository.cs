using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class PinChangeLogRepository : PersistenceRepository, IPinChangeLogRepository
    {
        public IEnumerable<PinChangelog> GetOldPinList(long technicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (technicianId > 0)
                {
                    var list = (from c in linqMetaData.PinChangelog
                                where c.TechnicianId == technicianId
                                select c).ToArray();
                    if (list.IsNullOrEmpty())
                        return null;

                    return Mapper.Map<IEnumerable<PinChangelogEntity>, IEnumerable<PinChangelog>>(list);
                }
                return null;
            }
        }

        public bool Save(PinChangelog pinChangelog)
        {
            var PinChangelogEntity = Mapper.Map<PinChangelog, PinChangelogEntity>(pinChangelog);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(PinChangelogEntity, false))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }

        public bool Delete(PinChangelog pinChangelog)
        {
            var PinChangelogEntity = Mapper.Map<PinChangelog, PinChangelogEntity>(pinChangelog);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.DeleteEntity(PinChangelogEntity))
                {
                    throw new PersistenceFailureException();
                }
                return true;
            }
        }
    }
}
