using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Hosts;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Repositories.Host
{
    public class HostFacilityRankingRepository : PersistenceRepository, IHostFacilityRankingRepository
    {
        DomainEntityMapper<HostFacilityViability, HostFacilityRankingEntity> _hostFacilityRankingMapper;
        
        public HostFacilityRankingRepository()
        {
            _hostFacilityRankingMapper = new HostFacilityRankingMapper();
        }

        public HostFacilityViability Save(HostFacilityViability domainObject)
        {
            var hostFacilityRankingEntity = _hostFacilityRankingMapper.Map(domainObject);

            SetIsCurrentForRoleFlagoffForRole(domainObject.CreatedBy.RoleId, domainObject.HostId);

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(hostFacilityRankingEntity, true))
                {
                    throw new PersistenceFailureException();
                }

                return _hostFacilityRankingMapper.Map(hostFacilityRankingEntity);
            }
        }

        private bool SetIsCurrentForRoleFlagoffForRole(long roleId, long hostId)
        {
            var hostFacilityRanking = new HostFacilityRankingEntity() { IsCurrentForRole = false };

            IRelationPredicateBucket relationPredicateBucket =
                new RelationPredicateBucket(HostFacilityRankingFields.HostId == hostId);

            relationPredicateBucket.PredicateExpression.AddWithAnd(HostFacilityRankingFields.RankedByRole == roleId);

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostFacilityRanking, relationPredicateBucket) > 0;
            }
        }

        public List<HostFacilityViability> GetHostFacilityRanking(long roleId, long hostId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var hostFacilityRankingList = linqMetaData.HostFacilityRanking.Where(facilityRanking => facilityRanking.IsCurrentForRole == true
                    && facilityRanking.RankedByRole == roleId
                    && facilityRanking.HostId == hostId).ToList();

                return _hostFacilityRankingMapper.MapMultiple(hostFacilityRankingList).ToList();
            }
        }

        public bool IsHostRatedByTechnician(long hostId, long eventId)
        {
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var selectedRecord = linqMetaData.HostEventDetails.Where(hostEventDetail => hostEventDetail.HostId == hostId
                    && hostEventDetail.EventId == eventId && hostEventDetail.IsHostRatedbyTechnician == true).FirstOrDefault();


                if (selectedRecord == null) return false;
                return true;
            }
        }

        public bool SetIsHostRatedFlagOn(long hostId, long eventId)
        {
            var hostEventDetail = new HostEventDetailsEntity() { IsHostRatedbyTechnician = true };

            IRelationPredicateBucket relationPredicateBucket =
                new RelationPredicateBucket(HostEventDetailsFields.HostId == hostId);

            relationPredicateBucket.PredicateExpression.AddWithAnd(HostEventDetailsFields.EventId == eventId);
                        
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostEventDetail, relationPredicateBucket) > 0;
            }
        }

    }
}
