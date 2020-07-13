using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Application.Repositories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class HospitalPartnerRepository : PersistenceRepository, IHospitalPartnerRepository
    {
        private readonly IMapper<HospitalPartner, HospitalPartnerEntity> _mapper;
        private readonly IPackageRepository _packageRepository;
        private readonly INotesRepository _notesRepository;
        private readonly IHospitalFacilityRepository _hospitalFacilityRepository;
        private readonly IShippingOptionRepository _shippingOptionRepository;

        public HospitalPartnerRepository()
            : this(new SqlPersistenceLayer(), new HospitalPartnerMapper(), new PackageRepository(), new NotesRepository(), new HospitalFacilityRepository(), new ShippingOptionRepository())
        { }

        public HospitalPartnerRepository(IPersistenceLayer persistenceLayer,
            IMapper<HospitalPartner, HospitalPartnerEntity> mapper, IPackageRepository packageRepository, INotesRepository notesRepository, IHospitalFacilityRepository hospitalFacilityRepository,
            IShippingOptionRepository shippingOptionRepository)
            : base(persistenceLayer)
        {
            _mapper = mapper;
            _packageRepository = packageRepository;
            _notesRepository = notesRepository;
            _hospitalFacilityRepository = hospitalFacilityRepository;
            _shippingOptionRepository = shippingOptionRepository;
        }

        public List<OrderedPair<long, string>> GetIdNamePairsforHospitalPartners()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hp in linqMetaData.HospitalPartner
                        join o in linqMetaData.Organization on hp.HospitalPartnerId equals o.OrganizationId
                        where o.IsActive
                        select new OrderedPair<long, string>(hp.HospitalPartnerId, o.Name)).OrderBy(hp => hp.SecondValue).ToList();
            }
        }

        public HospitalPartner GetHospitalPartnerforaVendor(long medicalVendorId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity =
                    linqMetaData.HospitalPartner.WithPath(
                        prefetchPath => prefetchPath.Prefetch(hp => hp.HospitalPartnerTerritory)).Where(
                            hp => hp.HospitalPartnerId == medicalVendorId).FirstOrDefault();
                if (entity == null) throw new ObjectNotFoundInPersistenceException<HospitalPartner>(medicalVendorId);

                var hospitaPartner = _mapper.Map(entity);
                var packages = _packageRepository.GetPackagesByHospitalPartner(medicalVendorId);
                if (packages != null && packages.Count() > 0)
                    hospitaPartner.PackageIds = packages.Select(p => p.Id).ToList();

                var hospitalFacilities = _hospitalFacilityRepository.GetByHospitalPartnerId(medicalVendorId);
                if (hospitalFacilities != null && hospitalFacilities.Any())
                    hospitaPartner.HospitalFacilityIds = hospitalFacilities.Select(hf => hf.Id).ToArray();

                var shippingOptions = _shippingOptionRepository.GetAllShippingOptionForHospitalPartner(medicalVendorId);
                if (shippingOptions != null && shippingOptions.Any())
                    hospitaPartner.ShippingOptionIds = shippingOptions.Select(so => so.Id).ToArray();

                return hospitaPartner;
            }
        }

        public void Delete(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                DeleteHospitalPartnerPackage(hospitalPartnerId);
                DeleteHospitalPartnerTerritory(hospitalPartnerId);
                DeleteHospitalPartnerHospitalFacility(hospitalPartnerId);

                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerFields.HospitalPartnerId == hospitalPartnerId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerEntity), relationPredicateBucket);
            }

        }

        public void DeleteHospitalPartnerPackage(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerPackageFields.HospitalpartnerId == hospitalPartnerId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerPackageEntity), relationPredicateBucket);
            }
        }

        public void DeleteHospitalPartnerTerritory(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerTerritoryFields.HospitalPartnerId == hospitalPartnerId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerTerritoryEntity), relationPredicateBucket);
            }
        }

        public long Save(HospitalPartner hospitalPartner)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = _mapper.Map(hospitalPartner);
                entity.IsNew = !adapter.FetchEntity(new HospitalPartnerEntity(hospitalPartner.Id));
                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }
                // DeleteHospitalPartnerPackage(hospitalPartner.Id);
                DeleteHospitalPartnerTerritory(hospitalPartner.Id);
                DeleteHospitalPartnerHospitalFacility(hospitalPartner.Id);
                DeleteHospitalPartnerShippingOption(hospitalPartner.Id);

                if (hospitalPartner.PackageIds != null && hospitalPartner.PackageIds.Any())
                    SaveHospitalPartnerPackage(hospitalPartner.Id, hospitalPartner.PackageIds);

                if (hospitalPartner.TerritoryIds != null && hospitalPartner.TerritoryIds.Any())
                    SaveHospitalPartnerTerritory(hospitalPartner.Id, hospitalPartner.TerritoryIds);

                if (hospitalPartner.HospitalFacilityIds != null && hospitalPartner.HospitalFacilityIds.Any())
                    SaveHospitalPartnerHospitalFacility(hospitalPartner.Id, hospitalPartner.HospitalFacilityIds);

                if (hospitalPartner.ShippingOptionIds != null && hospitalPartner.ShippingOptionIds.Any())
                    SaveHospitalPartnerShippingOption(hospitalPartner.Id, hospitalPartner.ShippingOptionIds);
            }
            return hospitalPartner.Id;
        }

        public void SaveHospitalPartnerPackage(long hospitalPartnerId, IEnumerable<long> packageIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HospitalPartnerPackageEntity>();
                foreach (var packageId in packageIds)
                {
                    entities.Add(new HospitalPartnerPackageEntity(hospitalPartnerId, packageId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public void SaveHospitalPartnerTerritory(long hospitalPartnerId, IEnumerable<long> territoryIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HospitalPartnerTerritoryEntity>();
                foreach (var territoryId in territoryIds)
                {
                    entities.Add(new HospitalPartnerTerritoryEntity(hospitalPartnerId, territoryId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public IEnumerable<long> GetEventIdsForHospitalPartner(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehp in linqMetaData.EventHospitalPartner
                        join e in linqMetaData.Events on ehp.EventId equals e.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                              && e.EventStatus.HasValue
                              && e.EventStatus.Value == (int)EventStatus.Active
                        select e.EventId).ToList();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventAndHospitalPartnerOrderedPair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from ehp in linqMetaData.EventHospitalPartner
                        where eventIds.Contains(ehp.EventId)
                        select new OrderedPair<long, long>(ehp.EventId, ehp.HospitalPartnerId)).ToArray();
            }
        }

        public long GetHospitalPartnerIdForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return
                    (from ehp in linqMetaData.EventHospitalPartner
                     where ehp.EventId == eventId
                     select ehp.HospitalPartnerId).SingleOrDefault();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetHospitalPartnerCustomerStatus()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lookupTypeId = (from l in linqMetaData.Lookup
                                    where l.LookupId == (long)HospitalPartnerCustomerStatus.NotCalled
                                    select l.LookupTypeId).SingleOrDefault();

                return (from l in linqMetaData.Lookup
                        where l.LookupTypeId == lookupTypeId && l.IsActive
                        orderby l.RelativeOrder
                        select new OrderedPair<long, string>(l.LookupId, l.DisplayName)).ToArray();
            }
        }

        public Notes SaveHospitalPartnerEventNotes(long eventId, Notes notes)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                notes = ((IRepository<Notes>)_notesRepository).Save(notes);

                if (notes.Id > 0)
                {
                    adapter.SaveEntity(new HospitalPartnerEventNotesEntity { NotesId = notes.Id, EventId = eventId });
                }

                return notes;
            }
        }

        public IEnumerable<Notes> GetHospitalPartnerEventNotes(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notesIds = (from hpen in linqMetaData.HospitalPartnerEventNotes
                                where hpen.EventId == eventId
                                select hpen.NotesId).ToArray();
                return _notesRepository.Get(notesIds);
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetEventIdNotesIdPair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hpen in linqMetaData.HospitalPartnerEventNotes
                        where eventIds.Contains(hpen.EventId)
                        select new OrderedPair<long, long>(hpen.EventId, hpen.NotesId)).ToArray();

            }
        }

        public IEnumerable<OrderedPair<long, string>> GetHospitalPartnerCustomerOutcome()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var lookupTypeIds = (from l in linqMetaData.LookupType
                                     where Enum.GetNames(typeof(HospitalPartnerCustomerOutcomeType)).Contains(l.Alias)
                                     select l.LookupTypeId).ToArray();

                return (from l in linqMetaData.Lookup
                        where lookupTypeIds.Contains(l.LookupTypeId) && l.IsActive
                        orderby l.RelativeOrder
                        select new OrderedPair<long, string>(l.LookupId, l.DisplayName)).ToArray();
            }
        }

        public IEnumerable<long> GetAttachedHospitalMaterialEventIdsForHospitalPartner(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehp in linqMetaData.EventHospitalPartner
                        join e in linqMetaData.Events on ehp.EventId equals e.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                              && e.EventStatus.HasValue
                              && e.EventStatus.Value == (int)EventStatus.Active
                              && ehp.AttachHospitalMaterial
                        select e.EventId).ToArray();
            }
        }

        public IEnumerable<EventHospitalPartner> GetEventHospitalPartnersByEventIds(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from ehp in linqMetaData.EventHospitalPartner
                                where eventIds.Contains(ehp.EventId)
                                select ehp).ToArray();

                return Mapper.Map<IEnumerable<EventHospitalPartnerEntity>, IEnumerable<EventHospitalPartner>>(entities);
            }
        }

        public List<OrderedPair<long, string>> GetIdNamePairsforParentHospitalPartners()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hp in linqMetaData.HospitalPartner
                        join o in linqMetaData.Organization on hp.HospitalPartnerId equals o.OrganizationId
                        join hphf in linqMetaData.HospitalPartnerHospitalFacility on hp.HospitalPartnerId equals hphf.HospitalPartnerId
                        where o.IsActive
                        select new OrderedPair<long, string>(hp.HospitalPartnerId, o.Name)).Distinct().OrderBy(hp => hp.SecondValue).ToList();
            }
        }

        public void DeleteHospitalPartnerHospitalFacility(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerHospitalFacilityFields.HospitalPartnerId == hospitalPartnerId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerHospitalFacilityEntity), relationPredicateBucket);
            }
        }

        public void SaveHospitalPartnerHospitalFacility(long hospitalPartnerId, IEnumerable<long> hospitalFacilityIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HospitalPartnerHospitalFacilityEntity>();
                foreach (var hospitalFacilityId in hospitalFacilityIds)
                {
                    entities.Add(new HospitalPartnerHospitalFacilityEntity(hospitalPartnerId, hospitalFacilityId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }

        public EventHospitalPartner GetEventHospitalPartnersByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = (from ehp in linqMetaData.EventHospitalPartner
                              where ehp.EventId == eventId
                              select ehp).SingleOrDefault();

                if (entity == null)
                    return null;

                return Mapper.Map<EventHospitalPartnerEntity, EventHospitalPartner>(entity);
            }
        }
        public IEnumerable<OrderedPair<long, string>> GetEventIdHospitalPartnerNamePair(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ea in linqMetaData.EventHospitalPartner
                        join o in linqMetaData.Organization on ea.HospitalPartnerId equals o.OrganizationId
                        where eventIds.Contains(ea.EventId)
                        select new OrderedPair<long, string>(ea.EventId, o.Name)
                       ).ToArray();
            }
        }

        private void DeleteHospitalPartnerShippingOption(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerShippingOptionFields.HospitalPartnerId == hospitalPartnerId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerShippingOptionEntity), relationPredicateBucket);
            }
        }

        private void SaveHospitalPartnerShippingOption(long hospitalPartnerId, IEnumerable<long> shippingOptionIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<HospitalPartnerShippingOptionEntity>();
                foreach (var shippingOptionId in shippingOptionIds)
                {
                    entities.Add(new HospitalPartnerShippingOptionEntity(hospitalPartnerId, shippingOptionId));
                }
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
            }
        }
    }
}