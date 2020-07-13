using System;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class SuspectConditionRepository : PersistenceRepository, ISuspectConditionRepository
    {
        private readonly ISettings _settings;

        public SuspectConditionRepository(ISettings settings)
        {
            _settings = settings;
        }

        public SuspectCondition SaveSuspectCondition(SuspectCondition domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<SuspectCondition, SuspectConditionEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException("Could not save Suspect Condition");

                return Mapper.Map<SuspectConditionEntity, SuspectCondition>(entity);
            }
        }

        public IEnumerable<SuspectCondition> GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.SuspectCondition
                              where h.CustomerId == customerId
                              select h).ToArray();

                return Mapper.Map<IEnumerable<SuspectConditionEntity>, IEnumerable<SuspectCondition>>(entity);
            }
        }

        //We were not having DateCreated for records , so we get it from ParseEnd time , as discussed
        public IEnumerable<SuspectCondition> GetSuspectConditionForSync(int recordsToSkip)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from h in linqMetaData.SuspectCondition
                              join suspectUpload in linqMetaData.SuspectConditionUpload
                              on h.SuspectConditionUploadId equals suspectUpload.Id
                              where h.IsSynced == false
                              && suspectUpload.ParseEndTime.HasValue && suspectUpload.ParseEndTime.Value.Date >= DateTime.Today.AddDays(-_settings.CustomerForSuspectSyncCutoffDays).Date
                              select h).Skip(recordsToSkip).Take(100).ToArray();

                return Mapper.Map<IEnumerable<SuspectConditionEntity>, IEnumerable<SuspectCondition>>(entity);
            }
        }

        public bool IsCustoemrExistForIcdCodeAndDate(IEnumerable<long> customerId, string icdCode, DateTime CaptureReferenceDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from h in linqMetaData.SuspectCondition
                        where customerId.Contains(h.CustomerId) && h.Icdcode == icdCode && h.CaptureReferenceDate == CaptureReferenceDate
                        select h.Id).Any();
            }
        }
    }
}
