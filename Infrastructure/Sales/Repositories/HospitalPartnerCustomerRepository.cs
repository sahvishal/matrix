using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Sales.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Sales.Repositories
{
    public class HospitalPartnerCustomerRepository : PersistenceRepository, IHospitalPartnerCustomerRepository
    {
        private readonly IMapper<HospitalPartnerCustomer, HospitalPartnerCustomerEntity> _mapper;
        public HospitalPartnerCustomerRepository()
            : this(new SqlPersistenceLayer(), new HospitalPartnerCustomerMapper())
        { }

        public HospitalPartnerCustomerRepository(IPersistenceLayer persistenceLayer, IMapper<HospitalPartnerCustomer, HospitalPartnerCustomerEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public HospitalPartnerCustomer Save(HospitalPartnerCustomer hospitalPartnerCustomer)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entityToSave = _mapper.Map(hospitalPartnerCustomer);

                if (!adapter.SaveEntity(entityToSave, true, false))
                {
                    throw new PersistenceFailureException();
                }

                return _mapper.Map(entityToSave);
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomers(IEnumerable<long> eventIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hpc in linqMetaData.HospitalPartnerCustomer
                                where eventIds.Contains(hpc.EventId)
                                select hpc);
                return _mapper.MapMultiple(entities).ToList();
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomers(long eventId, long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entitities = (from hpc in linqMetaData.HospitalPartnerCustomer
                                  where hpc.EventId == eventId && hpc.CustomerId == customerId
                                  orderby hpc.HospitalPartnerCustomerId
                                  select hpc).ToArray();
                return _mapper.MapMultiple(entitities);
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomersByHospitalPartnerId(long hospitalPartnerId, ResultInterpretation resultInterpretation,  int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hpc in linqMetaData.VwHospitalPartnerCustomers
                                join ehp in linqMetaData.EventHospitalPartner on hpc.EventId equals ehp.EventId
                                join ecr in linqMetaData.EventCustomerResult on new { hpc.EventId, hpc.CustomerId } equals new { ecr.EventId, ecr.CustomerId }
                                join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                where ehp.HospitalPartnerId == hospitalPartnerId
                                    && ecr.ResultSummary == (long)resultInterpretation
                                    && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1* validityPeriod))
                                select hpc).ToArray();
                return Mapper.Map<IEnumerable<VwHospitalPartnerCustomersEntity>, IEnumerable<HospitalPartnerCustomer>>(entities);
            }
        }

        public long GetMostRecentContactedEvent(long hospitalPartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hpc in linqMetaData.HospitalPartnerCustomer
                        join ehp in linqMetaData.EventHospitalPartner on hpc.EventId equals ehp.EventId
                        join e in linqMetaData.Events on ehp.EventId equals e.EventId
                        where ehp.HospitalPartnerId == hospitalPartnerId
                        orderby e.EventDate descending
                        select hpc.EventId).FirstOrDefault();
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalPartnerCustomersByHospitalPartnerIdForCritical(long hospitalPartnerId, ResultInterpretation resultInterpretation, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                var entities = (from hpc in linqMetaData.VwHospitalPartnerCustomers
                                join ehp in linqMetaData.EventHospitalPartner on hpc.EventId equals ehp.EventId
                                join ecr in linqMetaData.EventCustomerResult on new { hpc.EventId, hpc.CustomerId } equals new { ecr.EventId, ecr.CustomerId }
                                join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                where ehp.HospitalPartnerId == hospitalPartnerId
                                    && (ecr.ResultSummary == (long)resultInterpretation || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                    && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                                select hpc).ToArray();
                return Mapper.Map<IEnumerable<VwHospitalPartnerCustomersEntity>, IEnumerable<HospitalPartnerCustomer>>(entities);
            }
        }

        public long GetMostRecentContactedEventForHospitalFacility(long hospitalFacilityId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from hpc in linqMetaData.HospitalPartnerCustomer
                        join ec in linqMetaData.EventCustomers on new { hpc.EventId, hpc.CustomerId } equals new { ec.EventId, ec.CustomerId }
                        join ehf in linqMetaData.EventHospitalFacility on hpc.EventId equals ehf.EventId
                        join e in linqMetaData.Events on ehf.EventId equals e.EventId
                        where ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                        orderby e.EventDate descending
                        select hpc.EventId).FirstOrDefault();
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalFacilityCustomersByHospitalFacilityId(long hospitalFacilityId, ResultInterpretation resultInterpretation, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from hpc in linqMetaData.VwHospitalPartnerCustomers
                                join ehf in linqMetaData.EventHospitalFacility on hpc.EventId equals ehf.EventId
                                join ecr in linqMetaData.EventCustomerResult on new { hpc.EventId, hpc.CustomerId } equals new { ecr.EventId, ecr.CustomerId }
                                join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                where ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                                    && ecr.ResultSummary == (long)resultInterpretation
                                    && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                                select hpc).ToArray();
                return Mapper.Map<IEnumerable<VwHospitalPartnerCustomersEntity>, IEnumerable<HospitalPartnerCustomer>>(entities);
            }
        }

        public IEnumerable<HospitalPartnerCustomer> GetHospitalFacilityCustomersByHospitalFacilityIdForCritical(long hospitalFacilityId, ResultInterpretation resultInterpretation, int validityPeriod = 0)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var criticalEventCustomerResultIds = (from ecr in linqMetaData.EventCustomerResult
                                                      join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                                      join cect in linqMetaData.CustomerEventCriticalTestData on cest.CustomerEventScreeningTestId equals cect.CustomerEventScreeningTestId
                                                      where cect.CustomerEventScreeningTestId > 0
                                                            && (cect.IsActive.HasValue ? cect.IsActive.Value : true)
                                                            && (ecr.ResultState <= (int)TestResultStateNumber.PreAudit)
                                                      select ecr.EventCustomerResultId);

                var entities = (from hpc in linqMetaData.VwHospitalPartnerCustomers
                                join ehf in linqMetaData.EventHospitalFacility on hpc.EventId equals ehf.EventId
                                join ecr in linqMetaData.EventCustomerResult on new { hpc.EventId, hpc.CustomerId } equals new { ecr.EventId, ecr.CustomerId }
                                join ec in linqMetaData.EventCustomers on ecr.EventCustomerResultId equals ec.EventCustomerId
                                join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                where ehf.HospitalFacilityId == hospitalFacilityId && ec.HospitalFacilityId == hospitalFacilityId
                                    && (ecr.ResultSummary == (long)resultInterpretation || criticalEventCustomerResultIds.Contains(ecr.EventCustomerResultId))
                                    && (validityPeriod < 1 || e.EventDate >= DateTime.Now.Date.AddDays(-1 * validityPeriod))
                                select hpc).ToArray();
                return Mapper.Map<IEnumerable<VwHospitalPartnerCustomersEntity>, IEnumerable<HospitalPartnerCustomer>>(entities);
            }
        }
    }
}
