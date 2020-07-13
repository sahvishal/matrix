using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Users.Factories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class HospitalFacilityRepository : PersistenceRepository, IHospitalFacilityRepository
    {
        private readonly IHospitalFacilityFactory _hospitalFacilityFactory;

        public HospitalFacilityRepository()
            : this(new SqlPersistenceLayer(), new HospitalFacilityFactory())
        { }

        public HospitalFacilityRepository(IPersistenceLayer persistenceLayer, IHospitalFacilityFactory hospitalFacilityFactory)
            : base(persistenceLayer)
        {
            _hospitalFacilityFactory = hospitalFacilityFactory;
        }

        public HospitalFacility GetHospitalFacility(long hospitalFacilityId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var hospitalFacilityEntity = new HospitalFacilityEntity(hospitalFacilityId);
                IPrefetchPath2 path = new PrefetchPath2(EntityType.HospitalFacilityEntity);
                path.Add(HospitalFacilityEntity.PrefetchPathOrganization);

                if (!myAdapter.FetchEntity(hospitalFacilityEntity, path))
                {
                    throw new ObjectNotFoundInPersistenceException<HospitalFacility>(hospitalFacilityId);
                }
                var hospitalFacility = _hospitalFacilityFactory.CreateHospitalFacility(hospitalFacilityEntity);
                hospitalFacility.HospitalPartnerId = GetHospitalPartnerId(hospitalFacilityId);
                return hospitalFacility;
            }
        }

        public HospitalFacility Save(HospitalFacility hospitalFacility)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var hospitalFacilityEntity = _hospitalFacilityFactory.CreateHospitalFacilityEntity(hospitalFacility);
                try
                {
                    var entity = new HospitalFacilityEntity(hospitalFacility.Id);
                    if (myAdapter.FetchEntity(entity))
                        hospitalFacilityEntity.IsNew = false;
                }
                catch (ObjectNotFoundInPersistenceException<HospitalFacility>)
                {
                    hospitalFacilityEntity.IsNew = true;
                }
                if (!myAdapter.SaveEntity(hospitalFacilityEntity, true))
                {
                    throw new PersistenceFailureException();
                }

                hospitalFacility.Id = hospitalFacilityEntity.HospitalFacilityId;

                SaveHospitalPartner(hospitalFacility.Id, hospitalFacility.HospitalPartnerId);
                return hospitalFacility;
            }
        }

        public List<HospitalFacility> GetByFilter(int pageNumber, int pageSize, HospitalFacilityListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null)
                {
                    totalRecords = linqMetaData.MedicalVendorProfile.Count();
                    return _hospitalFacilityFactory.CreateHospitalFacilities(linqMetaData.HospitalFacility.TakePage(pageNumber, pageSize));
                }

                var query = from hf in linqMetaData.HospitalFacility
                            join o in linqMetaData.Organization on hf.HospitalFacilityId equals o.OrganizationId
                            orderby o.Name
                            select new { hf, o };

                if (!string.IsNullOrEmpty(filter.Name))
                    query = query.Where(q => q.o.Name.Contains(filter.Name));

                if (filter.ParentHospitalPartnerId > 0)
                {
                    var hospitalFacilityIds = (from hphf in linqMetaData.HospitalPartnerHospitalFacility
                                               where hphf.HospitalPartnerId == filter.ParentHospitalPartnerId
                                               select hphf.HospitalFacilityId);
                    query = query.Where(q => hospitalFacilityIds.Contains(q.hf.HospitalFacilityId));
                }

                totalRecords = query.Count();
                return _hospitalFacilityFactory.CreateHospitalFacilities(query.OrderBy(q => q.o.Name).TakePage(pageNumber, pageSize).Select(q => q.hf).ToArray());
            }
        }

        public IEnumerable<HospitalFacility> GetByHospitalPartnerId(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hf in linqMetaData.HospitalFacility
                                join hphf in linqMetaData.HospitalPartnerHospitalFacility on hf.HospitalFacilityId equals hphf.HospitalFacilityId
                                where hphf.HospitalPartnerId == hospitalPartnerId
                                select hf).ToArray();

                return _hospitalFacilityFactory.CreateHospitalFacilities(entities);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAllForHospitalPartner(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var facilityIdsAttachedWithOther = (from hphf in linqMetaData.HospitalPartnerHospitalFacility
                                                    where hphf.HospitalPartnerId != hospitalPartnerId
                                                    select hphf.HospitalFacilityId);

                return (from hf in linqMetaData.HospitalFacility
                        join o in linqMetaData.Organization on hf.HospitalFacilityId equals o.OrganizationId
                        where !facilityIdsAttachedWithOther.Contains(hf.HospitalFacilityId)
                        select new OrderedPair<long, string>(hf.HospitalFacilityId, o.Name)).OrderBy(list => list.SecondValue).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetHospitalPartnerIdHositalFacilityIdPair(IEnumerable<long> hospitalFacilityIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from hphf in linqMetaData.HospitalPartnerHospitalFacility
                        where hospitalFacilityIds.Contains(hphf.HospitalFacilityId)
                        select new OrderedPair<long, long>(hphf.HospitalPartnerId, hphf.HospitalFacilityId)).ToArray();
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetByEventId(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from hf in linqMetaData.HospitalFacility
                        join ehf in linqMetaData.EventHospitalFacility on hf.HospitalFacilityId equals ehf.HospitalFacilityId
                        join o in linqMetaData.Organization on hf.HospitalFacilityId equals o.OrganizationId
                        where ehf.EventId == eventId
                        select new OrderedPair<long, string>(hf.HospitalFacilityId, o.Name)).OrderBy(list => list.SecondValue).ToArray();
            }
        }

        public long GetHospitalPartnerId(long hospitalFacilityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from hphf in linqMetaData.HospitalPartnerHospitalFacility
                        where hphf.HospitalFacilityId == hospitalFacilityId
                        select hphf.HospitalPartnerId).SingleOrDefault();
            }
        }

        public void SaveHospitalPartner(long hospitalFacilityId, long hospitalPartnerId)
        {
            DeleteHospitalPartner(hospitalFacilityId);
            if (hospitalPartnerId > 0)
            {
                using (var adapter = PersistenceLayer.GetDataAccessAdapter())
                {
                    var entity = new HospitalPartnerHospitalFacilityEntity(hospitalPartnerId, hospitalFacilityId);
                    if (!adapter.SaveEntity(entity, true))
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }

        public void DeleteHospitalPartner(long hospitalFacilityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var relationPredicateBucket = new RelationPredicateBucket(HospitalPartnerHospitalFacilityFields.HospitalFacilityId == hospitalFacilityId);

                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerHospitalFacilityEntity), relationPredicateBucket);
            }
        }

        public IEnumerable<long> GetEventIdsForHospitalFacility(long hospitalFacilityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehf in linqMetaData.EventHospitalFacility
                        join e in linqMetaData.Events on ehf.EventId equals e.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId
                              && e.EventStatus.HasValue
                              && e.EventStatus.Value == (int)EventStatus.Active
                        select e.EventId).ToList();
            }
        }

        public IEnumerable<HospitalFacility> GetByIds(IEnumerable<long> hospitalFacilityIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hf in linqMetaData.HospitalFacility
                                where hospitalFacilityIds.Contains(hf.HospitalFacilityId)
                                select hf).ToArray();

                return _hospitalFacilityFactory.CreateHospitalFacilities(entities);
            }
        }

        public IEnumerable<long> GetSelectedHospitalFacilityIdForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ehf in linqMetaData.EventHospitalFacility
                        //join ec in linqMetaData.EventCustomers on ehf.HospitalFacilityId equals ec.HospitalFacilityId
                        join ec in
                            (from ect in linqMetaData.EventCustomers where ect.EventId == eventId && ect.HospitalFacilityId.HasValue select new { ect.EventId, HospitalFacilityId = ect.HospitalFacilityId.Value })
                        on new { ehf.EventId, ehf.HospitalFacilityId } equals new { ec.EventId, ec.HospitalFacilityId }
                        where ehf.EventId == eventId && ec.EventId == eventId
                        select ec.HospitalFacilityId).Distinct().ToArray();
            }
        }
    }
}
