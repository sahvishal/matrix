using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.Impl;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Mappers.Territories;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class TerritoryFactory : ITerritoryFactory
    {
        private readonly IMapper<AdvertiserTerritory, TerritoryEntity> _advertiserTerritoryMapper;
        private readonly IMapper<FranchiseeTerritory, TerritoryEntity> _franchiseeTerritoryMapper;
        private readonly IMapper<HospitalPartnerTerritory, TerritoryEntity> 
            _hospitalPartnerTerritoryMapper;
        private readonly IMapper<ReadingPhysicianTerritory, TerritoryEntity> 
            _readingPhysicianTerritoryMapper;
        private readonly IMapper<SalesRepTerritory, TerritoryEntity> _salesRepTerritoryMapper;
        private readonly ISalesRepTerritoryAssignmentFactory _salesRepTerritoryAssignmentFactory;
        private readonly IMapper<PodTerritory, TerritoryEntity> _podTerritoryMapper;

        public TerritoryFactory()
        {
            IMapper<ZipCode, ZipEntity> zipCodeMapper = new ZipCodeMapper();
            _advertiserTerritoryMapper = new AdvertiserTerritoryMapper(zipCodeMapper);
            _franchiseeTerritoryMapper = new FranchiseeTerritoryMapper(zipCodeMapper);
            _hospitalPartnerTerritoryMapper = new HospitalPartnerTerritoryMapper(zipCodeMapper);
            _readingPhysicianTerritoryMapper = new ReadingPhysicianTerritoryMapper(zipCodeMapper);
            _salesRepTerritoryMapper = new SalesRepTerritoryMapper(zipCodeMapper);
            _salesRepTerritoryAssignmentFactory = new SalesRepTerritoryAssignmentFactory();
            _podTerritoryMapper = new PodTerritoryMapper(zipCodeMapper);
        }

        public List<Territory> CreateTerritories(IEnumerable<TerritoryEntity> territoryEntities)
        {
            NullArgumentChecker.CheckIfNull(territoryEntities, "territoryEntities");
            return territoryEntities.Select(entity => CreateTerritory(entity)).ToList();
        }

        public Territory CreateTerritory(TerritoryEntity territoryEntity)
        {
            switch((TerritoryType)territoryEntity.Type)
            {
                case TerritoryType.Franchisee:
                    return _franchiseeTerritoryMapper.Map(territoryEntity);
                case TerritoryType.HospitalPartner:
                    return _hospitalPartnerTerritoryMapper.Map(territoryEntity);
                case TerritoryType.ReadingPhysician:
                    return _readingPhysicianTerritoryMapper.Map(territoryEntity);
                case TerritoryType.Advertiser:
                    return _advertiserTerritoryMapper.Map(territoryEntity);
                case TerritoryType.SalesRep:
                    return _salesRepTerritoryMapper.Map(territoryEntity);
                case TerritoryType.Pod:
                    return _podTerritoryMapper.Map(territoryEntity);
                default:
                    throw new NotSupportedException(string.Format
                        ("The persisted territory type {0} is currently unsupported.",
                        ((TerritoryType)territoryEntity.Type)));
            }
        }

        public TerritoryEntity CreateTerritoryEntity(Territory territory, DateTime dateCreated,
            DateTime dateModified)
        {
            NullArgumentChecker.CheckIfNull(territory, "territory");
            TerritoryEntity territoryEntity;
            switch (territory.TerritoryType)
            {
                case TerritoryType.Franchisee:
                    territoryEntity = _franchiseeTerritoryMapper.
                        Map((FranchiseeTerritory)territory);
                    break;
                case TerritoryType.HospitalPartner:
                    territoryEntity = _hospitalPartnerTerritoryMapper.
                        Map((HospitalPartnerTerritory)territory);
                    break;
                case TerritoryType.ReadingPhysician:
                    territoryEntity = _readingPhysicianTerritoryMapper.
                        Map((ReadingPhysicianTerritory)territory);
                    break;
                case TerritoryType.Advertiser:
                    territoryEntity = _advertiserTerritoryMapper.
                        Map((AdvertiserTerritory)territory);
                    break;
                case TerritoryType.SalesRep:
                    territoryEntity = _salesRepTerritoryMapper.Map((SalesRepTerritory)territory);
                    break;
                case TerritoryType.Pod:
                    territoryEntity = _podTerritoryMapper.Map((PodTerritory) territory);
                    break;
                default:
                    throw new NotSupportedException(string.Format
                        ("The given territory type {0} is currently unsupported.",
                        territory.TerritoryType));
            }
            territoryEntity.DateCreated = dateCreated;
            territoryEntity.DateModified = dateModified;
            territoryEntity.IsActive = true;
            return territoryEntity;
        }

        public SalesRepTerritory CreateSalesRepTerritory(TerritoryEntity territoryEntity,
            List<OrderedPair<OrganizationRoleUser, RegistrationMode>> owningUsersAndEventTypes,
            List<OrderedPair<long,long>> userSalesReps)
        {
            List<SalesRepTerritoryAssignment> salesRepTerritoryAssignments =             
                _salesRepTerritoryAssignmentFactory.CreateSalesRepTerritoryAssignments
                (owningUsersAndEventTypes, userSalesReps).ToList();
            SalesRepTerritory salesRepTerritory = _salesRepTerritoryMapper.Map(territoryEntity);
            salesRepTerritory.SalesRepTerritoryAssignments = salesRepTerritoryAssignments;
            return salesRepTerritory;
        }
    }
}