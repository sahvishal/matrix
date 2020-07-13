using System.Collections.Generic;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    [DefaultImplementation]
    public class StaffEventScheduleUploadLogRepository : PersistenceRepository, IStaffEventScheduleUploadLogRepository
    {
        public void Save(IEnumerable<StaffEventScheduleUploadLog> collection)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = Mapper.Map<IEnumerable<StaffEventScheduleUploadLog>, IEnumerable<StaffEventScheduleUploadLogEntity>>(collection);
                var entitiesCollection = new EntityCollection<StaffEventScheduleUploadLogEntity>();
                entitiesCollection.AddRange(entities);
                if (adapter.SaveEntityCollection(entitiesCollection) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }
    }
}
