using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Operations.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Operations.Repositories
{
    public class CdContentGeneratorTrackingRepository : PersistenceRepository, ICdContentGeneratorTrackingRepository
    {
        private readonly IMapper<CdContentGeneratorTracking, CdcontentGeneratorTrackingEntity> _mapper;

        public CdContentGeneratorTrackingRepository()
            : this(new SqlPersistenceLayer(), new CdContentGeneratorTrackingMapper())
        {}

        public CdContentGeneratorTrackingRepository(IPersistenceLayer persistenceLayer, IMapper<CdContentGeneratorTracking, CdcontentGeneratorTrackingEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public CdContentGeneratorTracking Save(CdContentGeneratorTracking cdContentGeneratorTracking)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityToSave = _mapper.Map(cdContentGeneratorTracking);

                if (!adapter.SaveEntity(entityToSave, true, false))
                {
                    throw new PersistenceFailureException();
                }

                return _mapper.Map(entityToSave);
            }
        }

        public bool IsCdContentGenerated(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cct in linqMetaData.CdcontentGeneratorTracking
                        join ec in linqMetaData.EventCustomers on cct.EventCustomerResultId equals ec.EventCustomerId
                        where ec.EventId == eventId && ec.CustomerId == customerId
                              && cct.IsContentGenerated
                        select cct.CdcontentGeneratorTrackingId).Any();
                
            }
            
        }

        public bool IsCdContentGenerated(IList<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerResultIds = (from cct in linqMetaData.CdcontentGeneratorTracking
                                              where eventCustomerIds.Contains(cct.EventCustomerResultId) && cct.IsContentGenerated
                                              select cct.EventCustomerResultId).ToList();
                
                return eventCustomerIds.All(eventCustomerResultIds.Contains);
            }
        }

        public IEnumerable<CdContentGeneratorTracking> GetCdContentGeneratedforEventCustomerIds(IEnumerable<long> eventCustomerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var cdContentTrackingList = (from cct in linqMetaData.CdcontentGeneratorTracking
                                             where eventCustomerIds.Contains(cct.EventCustomerResultId)
                                             select cct).ToArray();

                return _mapper.MapMultiple(cdContentTrackingList);
            }
        }

        public CdContentGeneratorTracking Get(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cct in linqMetaData.CdcontentGeneratorTracking
                                             where cct.CdcontentGeneratorTrackingId == id
                                             select cct).SingleOrDefault();
                if (entity == null)
                    return null;
                return _mapper.Map(entity);
            }
        }

        public IEnumerable<long> GetCdContentGeneratedEventIds(IEnumerable<long> eventIds)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var queryNotGenEventIds = (from ccg in linqMetaData.CdcontentGeneratorTracking
                             join ecr in linqMetaData.EventCustomerResult on ccg.EventCustomerResultId equals
                                 ecr.EventCustomerResultId
                             where eventIds.Contains(ecr.EventId) && ccg.IsContentGenerated == false
                             select ecr.EventId).Distinct().ToArray();

                eventIds = eventIds.Where(e => !queryNotGenEventIds.Contains(e)).ToArray();

                if (eventIds.Count() < 1) return eventIds;

                return (from ccg in linqMetaData.CdcontentGeneratorTracking
                        join ecr in linqMetaData.EventCustomerResult on ccg.EventCustomerResultId equals
                            ecr.EventCustomerResultId
                        where eventIds.Contains(ecr.EventId) && ccg.IsContentGenerated
                        select ecr.EventId).Distinct().ToArray();
            }
        }

        public bool UpdateCdContentDownloadedinfo(long eventId, long downloadedByOrgRoleUserId)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from ccg in linqMetaData.CdcontentGeneratorTracking
                                        join ecr in linqMetaData.EventCustomerResult on ccg.EventCustomerResultId equals
                                            ecr.EventCustomerResultId
                                        where ecr.EventId == eventId
                                        select ecr.EventCustomerResultId).ToArray();
                var entity = new CdcontentGeneratorTrackingEntity()
                                 {
                                     IsContentDownloaded = true,
                                     DownloadedByOrgRoleUserId = downloadedByOrgRoleUserId,
                                     DownloadedDate = DateTime.Now
                                 };
                var bucket = new RelationPredicateBucket(CdcontentGeneratorTrackingFields.EventCustomerResultId == eventCustomerIds);
                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0 ? true : false;
            }
        }

        public IEnumerable<CdContentGeneratorTracking> GetCdContentGeneratedforCleanUp(DateTime dateTo)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var cdContentTrackingList = (from cct in linqMetaData.CdcontentGeneratorTracking
                                             where cct.ContentGeneratedDate != null && cct.ContentGeneratedDate >= dateTo.Date.AddDays(-2) && cct.ContentGeneratedDate < dateTo.Date && cct.IsContentGenerated
                                             select cct).ToArray();

                return _mapper.MapMultiple(cdContentTrackingList);
            }
        }

        public void Delete(long cdContentGenratedTrackingId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("CdcontentGeneratorTrackingEntity", new RelationPredicateBucket(CdcontentGeneratorTrackingFields.CdcontentGeneratorTrackingId == cdContentGenratedTrackingId));
            }    
        }

        public CdContentGeneratorTracking GetByEventIdAndCustomerId(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cct in linqMetaData.CdcontentGeneratorTracking
                              join ecr in linqMetaData.EventCustomerResult on cct.EventCustomerResultId equals ecr.EventCustomerResultId
                              where ecr.EventId==eventId && ecr.CustomerId==customerId
                              select cct).SingleOrDefault();
                if (entity == null)
                    return null;
                return _mapper.Map(entity);
            }
        }
        
    }
}
