using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Queryable = System.Linq.Queryable;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class TerritoryRepository : PersistenceRepository, ITerritoryRepository
    {
        private readonly ITerritoryFactory _territoryFactory;
        private readonly IHospitalPartnerRepository _hospitalPartnerRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        

        public TerritoryRepository()
            : this(new SqlPersistenceLayer(), new TerritoryFactory(),
            new OrganizationRoleUserRepository(), new HospitalPartnerRepository())
        { }

        public TerritoryRepository(IPersistenceLayer persistenceLayer,
            ITerritoryFactory territoryFactory,
            IOrganizationRoleUserRepository organizationRoleUserRepository,
            IHospitalPartnerRepository hospitalPartnerRepository)
            : base(persistenceLayer)
        {
            _territoryFactory = territoryFactory;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _hospitalPartnerRepository = hospitalPartnerRepository;
        }

        private IEnumerable<TerritoryEntity> FetchTerritoryEntities
            (Expression<Func<TerritoryEntity, bool>> filter)
        {
            IEnumerable<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = Enumerable.ToList<TerritoryEntity>(Queryable.Where(linqMetaData.Territory.
                                                                        WithPath(p => p.Prefetch(t => t.ZipCollectionViaTerritoryZip).
                                                                                          Prefetch(t => t.FranchiseeTerritory).
                                                                                          Prefetch(t => t.OrganizationRoleUserTerritory).
                                                                                          Prefetch(t => t.HospitalPartnerTerritory).
                                                                                          Prefetch(t => t.TerritoryPackage)), filter));
            }
            return territoryEntities;
        }

        private SalesRepTerritory GetSalesRepTerritory(TerritoryEntity territoryEntity)
        {
            IEnumerable<long> organizationRoleUserIds = territoryEntity.
                OrganizationRoleUserTerritory.Select(orut => orut.OrganizationRoleUserId);
            
            List<OrganizationRoleUser> organizationRoleUsers = _organizationRoleUserRepository.
                GetOrganizationRoleUsers(organizationRoleUserIds);
            
            List<OrderedPair<OrganizationRoleUser, RegistrationMode>> owningUsersAndEventTypes =
                organizationRoleUsers.Select(oru => new OrderedPair<OrganizationRoleUser, RegistrationMode>
                (oru, (RegistrationMode)(territoryEntity.OrganizationRoleUserTerritory.
                Single(orut => orut.OrganizationRoleUserId == oru.Id).EventTypeSetupPermission))).
                ToList();

            List<OrderedPair<long, long>> userSalesRepId =
                owningUsersAndEventTypes.Select(ouet => _organizationRoleUserRepository.
                    GetSalesRepUser(ouet.FirstValue)).ToList();

            return _territoryFactory.CreateSalesRepTerritory(territoryEntity,
                owningUsersAndEventTypes, userSalesRepId);
        }

        private void SaveTerritoryEntity(TerritoryEntity territoryEntity)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(territoryEntity))
                {
                    throw new PersistenceFailureException
                        ("The territory could not be saved to the database.");
                }
            }
        }

        private TerritoryEntity GetTerritoryEntity(Territory territoryToSave)
        {
            var territoryEntity = new TerritoryEntity(territoryToSave.Id);
            DateTime dateModified = DateTime.Now;
            DateTime dateCreated = dateModified;
            bool isNewTerritory = true;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (myAdapter.FetchEntity(territoryEntity))
                {
                    dateCreated = territoryEntity.DateCreated;
                    isNewTerritory = false;
                }
            }
            territoryEntity = _territoryFactory.
                CreateTerritoryEntity(territoryToSave, dateCreated, dateModified);
            territoryEntity.IsNew = isNewTerritory;
            return territoryEntity;
        }

        public Territory GetTerritory(long territoryId)
        {
            IEnumerable<TerritoryEntity> territoryEntities =
                FetchTerritoryEntities(t => t.TerritoryId == territoryId);
            TerritoryEntity territoryEntity;
            try
            {
                territoryEntity = territoryEntities.Single();
            }
            catch (InvalidOperationException)
            {
                if (territoryEntities.IsEmpty())
                {
                    throw new ObjectNotFoundInPersistenceException<Territory>(territoryId);
                }
                throw new DuplicateObjectException<Territory>();
            }
            return (TerritoryType)territoryEntity.Type == TerritoryType.SalesRep ?
                GetSalesRepTerritory(territoryEntity) :
                _territoryFactory.CreateTerritory(territoryEntity);
        }

        public List<Territory> GetTerritories(List<long> territoryIds)
        {
            IEnumerable<TerritoryEntity> territoryEntities =
                FetchTerritoryEntities(t => territoryIds.Contains(t.TerritoryId));

            var territories = new List<Territory>();
            foreach (var territoryEntity in territoryEntities)
            {
                territories.Add((TerritoryType)territoryEntity.Type == TerritoryType.SalesRep
                    ? GetSalesRepTerritory(territoryEntity)
                    : _territoryFactory.CreateTerritory(territoryEntity));
            }
            return territories;
        }

        public long SaveTerritory(Territory territoryToSave)
        {
            TerritoryEntity territoryEntity = GetTerritoryEntity(territoryToSave);
            SaveTerritoryEntity(territoryEntity);
            UpdateTerritoryOwnerMappings(territoryEntity.TerritoryId, territoryToSave);
            UpdateTerritoryZipMappings(territoryEntity.TerritoryId, territoryToSave.ZipCodes);
            return territoryEntity.TerritoryId;
        }

        public bool DeleteTerritory(long territoryId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var childTerritoryCount = GetChildTerritories(territoryId).Count;
                var franchiseeTerritoryCount =
                    linqMetaData.FranchiseeTerritory.
                    Where(territory => territory.TerritoryId == territoryId).Count();
                var hospitalPartnerTerritoryCount =
                    linqMetaData.HospitalPartnerTerritory.
                    Where(territory => territory.TerritoryId == territoryId).Count();
                var salesRepTerritoryCount =
                    linqMetaData.OrganizationRoleUserTerritory.
                    Where(territory => territory.TerritoryId == territoryId).Count();
                if (childTerritoryCount <= 0
                    && hospitalPartnerTerritoryCount <= 0
                    && franchiseeTerritoryCount <= 0
                    && salesRepTerritoryCount <= 0)
                {
                    return myAdapter.DeleteEntity(new TerritoryEntity(territoryId));
                }
                if (childTerritoryCount <= 0)
                {
                    throw new DeletionFailureException<Territory>
                        ("This territory has existing child territories.");
                }
                if (franchiseeTerritoryCount <= 0)
                {
                    throw new DeletionFailureException<Territory>
                        ("This territory is assigned to franchisee.");
                }
                if (hospitalPartnerTerritoryCount <= 0)
                {
                    throw new DeletionFailureException<Territory>
                        ("This territory is assigned to hospital partner.");
                }
                if (salesRepTerritoryCount <= 0)
                {
                    throw new DeletionFailureException<Territory>
                        ("This territory is assigned to sales rep.");
                }
            }
            return false;
        }

        public List<Territory> GetAllTerritories()
        {
            List<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = linqMetaData.Territory.ToList();
            }
            return _territoryFactory.CreateTerritories(territoryEntities);
        }

        public IEnumerable<OrderedPair<long, string>> GetAllTerritoriesIdNamePair(TerritoryType type)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.Territory.Where(t => t.Type == (byte)type).Select(t => new OrderedPair<long, string>(t.TerritoryId, t.Name)).ToArray();
            }
        }

        // Need to be refactored.
        public IEnumerable<OrderedPair<long, string>> GetMultiplePodTerritoriesIdNamePair(long[] id)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return (from t in linqMetaData.Territory
                        join pt in linqMetaData.PodTerritory on t.TerritoryId equals pt.TerritoryId
                        where id.Contains(pt.PodId)
                        select new OrderedPair<long, string>(pt.PodId, t.Name)).ToArray();
            }
        }

        public List<Territory> GetTerritoriesForPod(long podId)
        {
            List<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = linqMetaData.Territory.
                    Join(linqMetaData.PodTerritory,
                    t => t.TerritoryId, p => p.TerritoryId, (t, p) => new { t, p }).
                    Where(@t => @t.p.PodId == podId).Select(@t => @t.t).ToList();
            }
            return _territoryFactory.CreateTerritories(territoryEntities);
        }

        public List<Territory> GetTerritoriesForFranchisee(long franchiseeId)
        {
            List<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = linqMetaData.Territory.
                    Join(linqMetaData.FranchiseeTerritory,
                    t => t.TerritoryId, ft => ft.TerritoryId, (t, ft) => new { t, ft }).
                    Where(@t => @t.ft.OrganizationId == franchiseeId).Select(@t => @t.t).ToList();
            }
            return _territoryFactory.CreateTerritories(territoryEntities);
        }
        
        public List<Territory> GetTerritoriesForZipIds(long[] zipIds)
        {
            List<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = (from t in linqMetaData.Territory
                                     join tz in linqMetaData.TerritoryZip on t.TerritoryId equals tz.TerritoryId
                                     where zipIds.Contains(tz.ZipId)
                                     select t).ToList();
            }
            return _territoryFactory.CreateTerritories(territoryEntities);
        }

        public IEnumerable<Territory> GetTerritoriesFor(long zipId, TerritoryType territoryType)
        {
            List<TerritoryEntity> territoryEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                territoryEntities = (from t in linqMetaData.Territory
                                     join tz in linqMetaData.TerritoryZip on t.TerritoryId equals tz.TerritoryId
                                     where zipId == tz.ZipId && t.Type == (int)territoryType
                                     select t).ToList();
            }
            return _territoryFactory.CreateTerritories(territoryEntities);
        }
        
        public List<SalesRepTerritory> GetTerritoriesForSalesRep(long salesRepId)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.
                GetOrganizationRoleUser(salesRepId).Id;
            Expression<Func<TerritoryEntity, bool>> filter = te => te.OrganizationRoleUserTerritory.
                Select(orut => orut.OrganizationRoleUserId).Contains(organizationRoleUserId);

            IEnumerable<TerritoryEntity> territoryEntities = FetchTerritoryEntities(filter);
            return territoryEntities.Select(te => GetSalesRepTerritory(te)).ToList();
        }

        public List<Territory> GetChildTerritories(long parentTerritoryId)
        {
            IEnumerable<TerritoryEntity> territoryEntities =
                FetchTerritoryEntities(f => f.ParentTerritoryId == parentTerritoryId);
            return CreateTerritories(territoryEntities);
        }

        public List<Territory> GetAllParentTerritories()
        {
            IEnumerable<TerritoryEntity> territoryEntities =
                FetchTerritoryEntities(f => f.ParentTerritoryId == null);
            return CreateTerritories(territoryEntities);
        }

        public List<string> GetOwnerNamesForTerritory(Territory territory)
        {
            List<string> ownerNames;
            switch (territory.TerritoryType)
            {
                case TerritoryType.Franchisee:
                    using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
                    {
                        var linqMetaData = new LinqMetaData(myAdapter);
                        ownerNames = linqMetaData.Organization.
                            Join(linqMetaData.FranchiseeTerritory, f => f.OrganizationId,
                            ft => ft.OrganizationId, (f, ft) => new { f, ft }).
                            Where(@t => @t.ft.TerritoryId == territory.Id).Select(@t => @t.f.Name).
                            ToList();
                    }
                    break;

                case TerritoryType.HospitalPartner:
                    ownerNames = _hospitalPartnerRepository.GetIdNamePairsforHospitalPartners().
                        Where(hp => ((HospitalPartnerTerritory)territory).
                        HospitalPartnerOwnerIds.Contains(hp.FirstValue)).
                        Select(hp => hp.SecondValue).ToList();
                    break;

                case TerritoryType.SalesRep:
                    using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
                    {
                        var linqMetaData = new LinqMetaData(myAdapter);
                        ownerNames = linqMetaData.User.
                            Join(linqMetaData.OrganizationRoleUser, u => u.UserId,
                            oru => oru.UserId, (u, oru) => new { u, oru }).
                            Join(linqMetaData.OrganizationRoleUserTerritory,
                            @t => @t.oru.OrganizationRoleUserId,
                            orut => orut.OrganizationRoleUserId,
                            (@t, orut) => new { @t, orut }).
                            Where(@t2 => @t2.orut.TerritoryId == territory.Id).
                            Select(@t2 => new Name(@t2.@t.u.FirstName, @t2.@t.u.MiddleName,
                            @t2.@t.u.LastName).ToString()).ToList();
                    }
                    break;

                case TerritoryType.ReadingPhysician:
                    ownerNames = new List<string>();
                    // This type of territory does not yet have associated owners.
                    break;

                case TerritoryType.Advertiser:
                    ownerNames = new List<string>();
                    // This type of territory does not yet have associated owners.
                    break;
                case TerritoryType.Pod:
                    ownerNames = new List<string>();
                    // This type of territory does not yet have associated owners.
                    break;
                default:
                    throw new NotSupportedException
                        ("The given territory does not have associated owners or is not yet supported.");
            }
            return ownerNames;
        }

        public bool UnassignSalesRepOwnerFromTerritory(long salesRepId, long territoryId)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.
                GetOrganizationRoleUser(salesRepId).Id;
            var entityToDelete = new OrganizationRoleUserTerritoryEntity
                (territoryId, organizationRoleUserId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.DeleteEntity(entityToDelete);
            }
        }

        public bool AssignSalesRepOwnerToTerritory(long salesRepId, long territoryId,
            RegistrationMode eventTypeSetupPermission)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.
                GetOrganizationRoleUser(salesRepId).Id;
            var entityToInsert = new OrganizationRoleUserTerritoryEntity(territoryId,
                organizationRoleUserId) { EventTypeSetupPermission = (int)eventTypeSetupPermission };
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.SaveEntity(entityToInsert);
            }
        }

        public List<SalesRepTerritory> GetTerritoriesForSalesRepByZipCode(long salesRepId, string zipCode)
        {
            long organizationRoleUserId = _organizationRoleUserRepository.
                GetOrganizationRoleUser(salesRepId).Id;
            Expression<Func<TerritoryEntity, bool>> filter = te => te.OrganizationRoleUserTerritory.
                Select(orut => orut.OrganizationRoleUserId).Contains(organizationRoleUserId);
            try
            {
                List<TerritoryEntity> territoryEntityList =
                    FetchTerritoryEntities(filter).
                        Where(t => t.ZipCollectionViaTerritoryZip.
                        Select(zip => zip.ZipCode).Contains(zipCode)).ToList();
                //TODO: Look for a better option to filter inner collection.
                if (!territoryEntityList.IsEmpty())
                {
                    foreach (var territoryEntity in territoryEntityList)
                    {
                        var organizationRoleUserTerritoryEntity = territoryEntity.
                            OrganizationRoleUserTerritory.
                            SingleOrDefault(or => or.OrganizationRoleUserId == organizationRoleUserId);
                        territoryEntity.OrganizationRoleUserTerritory.Clear();
                        territoryEntity.OrganizationRoleUserTerritory.Add
                            (organizationRoleUserTerritoryEntity);

                    }

                    return territoryEntityList.Select(te => GetSalesRepTerritory(te)).ToList();
                }
                return null;
            }
            catch (Exception)
            {
                throw new DuplicateObjectException<SalesRepTerritory>();
            }

        }

        private List<Territory> CreateTerritories(IEnumerable<TerritoryEntity> territoryEntities)
        {
            var territories = new List<Territory>();
            foreach (var territoryEntity in territoryEntities)
            {
                if ((TerritoryType)territoryEntity.Type != TerritoryType.SalesRep)
                {
                    territories.Add(_territoryFactory.CreateTerritory(territoryEntity));
                }
                else
                {
                    territories.Add(GetSalesRepTerritory(territoryEntity));
                }
            }
            return territories;
        }

        private void UpdateTerritoryOwnerMappings(long territoryId, Territory territoryToSave)
        {
            // Presently, a created territory cannot change its owners.
            // Thus, there will never be any old owner mappings to delete.
            switch (territoryToSave.TerritoryType)
            {
                case TerritoryType.Franchisee:
                    UpdateFranchiseeTerritoryOwner(territoryId,
                    ((FranchiseeTerritory)territoryToSave).FranchiseeOwnerId);
                    break;
                case TerritoryType.HospitalPartner:
                    UpdateHospitalPartnerTerritoryOwners(territoryId,
                    ((HospitalPartnerTerritory)territoryToSave).HospitalPartnerOwnerIds);
                    break;
                case TerritoryType.SalesRep:
                    UpdateSalesRepTerritoryOwners(territoryId,
                    ((SalesRepTerritory)territoryToSave).SalesRepTerritoryAssignments);
                    break;
                case TerritoryType.ReadingPhysician:
                    // No owners associated to this type of territory yet.
                    break;
                case TerritoryType.Advertiser:
                    // No owners associated to this type of territory yet.
                    break;
                case TerritoryType.Pod:
                    // This type of territory does not yet have associated owners.
                    UpdateTerritorypackage(territoryId, ((PodTerritory) territoryToSave).PackageIds);
                    break;
                default:
                    throw new NotSupportedException(string.Format
                        ("The given TerritoryType {0} is not yet supported in persistence.",
                        territoryToSave.TerritoryType));
            }
        }

        //private void DeleteOldOwnerMappings(long territoryId)
        //{
        //    using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
        //    {
        //        IRelationPredicateBucket bucket = new RelationPredicateBucket(HospitalPartnerTerritoryFields.TerritoryId == territoryId);
        //        myAdapter.DeleteEntitiesDirectly(typeof(HospitalPartnerTerritoryEntity), bucket);
        //        bucket = new RelationPredicateBucket(FranchiseeTerritoryFields.TerritoryId == territoryId);
        //        myAdapter.DeleteEntitiesDirectly(typeof(FranchiseeTerritoryEntity), bucket);
        //        bucket = new RelationPredicateBucket(OrganizationRoleUserTerritoryFields.TerritoryId == territoryId);
        //        myAdapter.DeleteEntitiesDirectly(typeof(OrganizationRoleUserTerritoryEntity), bucket);
        //    }
        //}

        private void UpdateSalesRepTerritoryOwners(long territoryId,
            IEnumerable<SalesRepTerritoryAssignment> salesRepTerritoryAssignments)
        {
            IEntityCollection2 organizationRoleUserTerritoryEntities =
                new EntityCollection<OrganizationRoleUserTerritoryEntity>();
            foreach (var salesRepTerritoryAssignment in salesRepTerritoryAssignments)
            {
                // TODO: Ashutosh is looking into it
                //OrganizationRoleUser organizationRoleUser =  _organizationRoleUserRepository.
                //    GetOrganizationRoleUser(salesRepTerritoryAssignment.SalesRep.Id,
                //    (long)Roles.SalesRep, salesRepTerritoryAssignment.SalesRep.
                //    SalesRepresentativeId);

                OrganizationRoleUser organizationRoleUser = new OrganizationRoleUser();

                IEntity2 organizationRoleUserTerritoryEntity =
                    new OrganizationRoleUserTerritoryEntity(territoryId, organizationRoleUser.Id)
                    {
                        EventTypeSetupPermission = (int)salesRepTerritoryAssignment.
                          EventTypeSetupPermission
                    };
                organizationRoleUserTerritoryEntities.Add(organizationRoleUserTerritoryEntity);
            }
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.SaveEntityCollection(organizationRoleUserTerritoryEntities);
            }
        }

        private void UpdateHospitalPartnerTerritoryOwners(long territoryId,
            IEnumerable<long> hospitalPartnerOwnerIds)
        {
            IEntityCollection2 hospitalPartnerTerritoryEntities =
                new EntityCollection<HospitalPartnerTerritoryEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                foreach (var hospitalPartnerOwnerId in hospitalPartnerOwnerIds)
                {
                    IEntity2 hospitalPartnerTerritoryEntity =
                        new HospitalPartnerTerritoryEntity(hospitalPartnerOwnerId, territoryId);
                    if (!myAdapter.FetchEntity(hospitalPartnerTerritoryEntity))
                    {
                        hospitalPartnerTerritoryEntities.Add(hospitalPartnerTerritoryEntity);
                    }
                }
                if (hospitalPartnerTerritoryEntities.Count > 0)
                    myAdapter.SaveEntityCollection(hospitalPartnerTerritoryEntities);
            }
        }

        private void UpdateFranchiseeTerritoryOwner(long territoryId, long franchiseeOwnerId)
        {
            IEntity2 franchiseeTerritoryEntity = new FranchiseeTerritoryEntity(franchiseeOwnerId,
                territoryId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.FetchEntity(franchiseeTerritoryEntity))
                {
                    myAdapter.SaveEntity(franchiseeTerritoryEntity);
                }
            }
        }

        private void UpdateTerritoryZipMappings(long territoryId,
            IEnumerable<ZipCode> zipCodesToAdd)
        {
            var territoryZipMappings = new EntityCollection<TerritoryZipEntity>();
            foreach (var zipCode in zipCodesToAdd)
            {
                territoryZipMappings.Add(new TerritoryZipEntity(territoryId, zipCode.Id));
            }
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IRelationPredicateBucket bucket = new RelationPredicateBucket
                    (TerritoryZipFields.TerritoryId == territoryId);
                myAdapter.DeleteEntitiesDirectly(typeof(TerritoryZipEntity), bucket);
                myAdapter.SaveEntityCollection(territoryZipMappings);
            }
        }

        public bool IsZipCodePresentInTerritory(long organizationRoleUserId, string zipCode)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                
                if (!linqMetaData.Territory.Join(linqMetaData.OrganizationRoleUserTerritory, @t => @t.TerritoryId, o => o.TerritoryId,
                         (@t, o) => new { @t, o }).Where(@t => @t.t.IsActive && @t.o.OrganizationRoleUserId == organizationRoleUserId).Select(@a => @a.t.TerritoryId).Any())
                    return true;

                return linqMetaData.Territory.
                    Join(linqMetaData.TerritoryZip, t => t.TerritoryId, tz => tz.TerritoryId, (t, tz) => new {t, tz}).
                    Join(linqMetaData.Zip, @t => @t.tz.ZipId, z => z.ZipId, (@t, z) => new {@t, z}).
                    Join(linqMetaData.OrganizationRoleUserTerritory, @t => @t.t.t.TerritoryId, o => o.TerritoryId,
                         (@t, o) => new {@t, o}).
                    Where(@a => @a.t.t.t.IsActive && @a.t.z.IsActive &&
                                @a.o.OrganizationRoleUserId == organizationRoleUserId &&
                                @a.t.z.ZipCode == zipCode).
                    Select(@a => @a.t.t.t.TerritoryId).Any();
                
            }
        }

        private void UpdateTerritorypackage(long territoryId, IEnumerable<long> packageIds)
        {
            IEntityCollection2 territoryPackageEntities = new EntityCollection<TerritoryPackageEntity>();
            using(var adapter=PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(TerritoryPackageFields.TerritoryId == territoryId);
                bucket.PredicateExpression.AddWithAnd(TerritoryPackageFields.PackageId != packageIds.ToArray());

                adapter.FetchEntityCollection(territoryPackageEntities, bucket);
                if (territoryPackageEntities.Count > 0)
                {
                    adapter.DeleteEntityCollection(territoryPackageEntities);
                }

                territoryPackageEntities = new EntityCollection<TerritoryPackageEntity>();
                foreach (var packageId in packageIds)
                {
                    IEntity2 territoryPackageEntity = new TerritoryPackageEntity(territoryId, packageId);
                    if(!adapter.FetchEntity(territoryPackageEntity))
                    {
                        territoryPackageEntities.Add(territoryPackageEntity);
                    }
                }
                if (territoryPackageEntities.Count > 0)
                    adapter.SaveEntityCollection(territoryPackageEntities);
            }
        }
    }
}