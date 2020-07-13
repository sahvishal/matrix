using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class PrimaryCarePhysicianRepository : PersistenceRepository, IPrimaryCarePhysicianRepository
    {
        private readonly IMapper<PrimaryCarePhysician, CustomerPrimaryCarePhysicianEntity> _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressService _addressService;

        public PrimaryCarePhysicianRepository(IMapper<PrimaryCarePhysician, CustomerPrimaryCarePhysicianEntity> mapper, IAddressRepository addressRepository, IAddressService addressService)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressService = addressService;
        }

        public PrimaryCarePhysician Get(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.CustomerPrimaryCarePhysician.Where(x => x.IsActive).SingleOrDefault(prp => prp.CustomerId == customerId);

                if (entity == null) return null;
                var domainObject = _mapper.Map(entity);
                domainObject.Address = domainObject.Address != null
                                           ? _addressRepository.GetAddress(domainObject.Address.Id)
                                           : domainObject.Address;

                domainObject.MailingAddress = domainObject.MailingAddress != null
                                           ? _addressRepository.GetAddress(domainObject.MailingAddress.Id)
                                           : domainObject.MailingAddress;

                return domainObject;
            }
        }

        public PrimaryCarePhysician Save(PrimaryCarePhysician domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (domainObject.Id <= 0)
                    DecativatePhysician(domainObject.CustomerId, domainObject.DataRecorderMetaData.DataRecorderCreator.Id);

                var isSkipAddressCheck = domainObject.Source.HasValue && domainObject.Source.Value == (long)CustomerPcpUpdateSource.CorporateUpload ? true : false;

                if (domainObject.Address != null)
                {
                    domainObject.Address = _addressService.SaveAfterSanitizing(domainObject.Address, true);
                }

                if (domainObject.MailingAddress != null)
                {
                    domainObject.MailingAddress = _addressService.SaveAfterSanitizing(domainObject.MailingAddress, true);
                }
                var entity = _mapper.Map(domainObject);

                if (domainObject.Address != null && domainObject.MailingAddress == null)
                {
                    entity.MailingAddressId = domainObject.Address.Id;
                }

                if (domainObject.Address == null && domainObject.MailingAddress != null)
                {
                    entity.Pcpaddress = domainObject.MailingAddress.Id;
                }

                adapter.SaveEntity(entity, true);
                return Get(domainObject.CustomerId);
            }
        }

        public void Delete(PrimaryCarePhysician domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("CustomerPrimaryCarePhysicianEntity", new RelationPredicateBucket(CustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId == domainObject.Id));
            }
        }

        public void Delete(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("CustomerPrimaryCarePhysicianEntity", new RelationPredicateBucket(CustomerPrimaryCarePhysicianFields.CustomerId == customerId));
            }
        }

        public void DecativatePhysician(long customerId, long updatedBy)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var pcp = Get(customerId);

                if (pcp != null)
                {
                    var entity = new CustomerPrimaryCarePhysicianEntity { IsActive = false, DateModified = DateTime.Now };
                    var bucket = new RelationPredicateBucket(CustomerPrimaryCarePhysicianFields.PrimaryCarePhysicianId == pcp.Id);
                    bucket.PredicateExpression.AddWithAnd(CustomerPrimaryCarePhysicianFields.IsActive == true);

                    if (adapter.UpdateEntitiesDirectly(entity, bucket) == 0)
                    {
                        throw new PersistenceFailureException();
                    }
                }

            }
        }

        public void Delete(IEnumerable<PrimaryCarePhysician> domainObjects)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PrimaryCarePhysician> GetByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities =
                    linqMetaData.CustomerPrimaryCarePhysician.Where(pcp => customerIds.Contains(pcp.CustomerId) && pcp.IsActive).ToArray();

                var primaryCarephysicians = _mapper.MapMultiple(entities);

                var addressIds = primaryCarephysicians.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);
                foreach (var primaryCarephysician in primaryCarephysicians)
                {
                    primaryCarephysician.Address = primaryCarephysician.Address != null
                                                       ? addresses.Where(a => a.Id == primaryCarephysician.Address.Id).
                                                             Select(a => a).Single()
                                                       : primaryCarephysician.Address;
                }

                return primaryCarephysicians;
            }
        }

        public IEnumerable<PrimaryCarePhysician> GetByPhysicianMasterId(long physicianMasterId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = (from pcp in linqMetaData.CustomerPrimaryCarePhysician
                                where pcp.PhysicianMasterId.HasValue && pcp.PhysicianMasterId == physicianMasterId && pcp.IsActive
                                select pcp).ToArray();

                if (!entities.Any())
                    return null;

                var primaryCarephysicians = _mapper.MapMultiple(entities);

                var addressIds = primaryCarephysicians.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);
                foreach (var primaryCarephysician in primaryCarephysicians)
                {
                    primaryCarephysician.Address = primaryCarephysician.Address != null
                                                       ? addresses.Where(a => a.Id == primaryCarephysician.Address.Id).Select(a => a).Single()
                                                       : primaryCarephysician.Address;
                }

                return primaryCarephysicians;
            }
        }

        public IEnumerable<PrimaryCarePhysician> GetForPcpChangeReport(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cpcp in linqMetaData.CustomerPrimaryCarePhysician
                                where customerIds.Contains(cpcp.CustomerId)
                                select cpcp).ToArray();

                var primaryCarephysicians = _mapper.MapMultiple(entities);

                var addressIds = primaryCarephysicians.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);
                foreach (var primaryCarephysician in primaryCarephysicians)
                {
                    primaryCarephysician.Address = primaryCarephysician.Address != null
                                                       ? addresses.Where(a => a.Id == primaryCarephysician.Address.Id).
                                                             Select(a => a).Single()
                                                       : primaryCarephysician.Address;
                }

                return primaryCarephysicians;
            }
        }

        public IEnumerable<PrimaryCarePhysician> GetAllByCustomerIds(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.CustomerPrimaryCarePhysician.Where(pcp => customerIds.Contains(pcp.CustomerId)).ToArray();

                var primaryCarephysicians = _mapper.MapMultiple(entities);

                var addressIds = primaryCarephysicians.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);
                foreach (var primaryCarephysician in primaryCarephysicians)
                {
                    primaryCarephysician.Address = primaryCarephysician.Address != null
                                                       ? addresses.Where(a => a.Id == primaryCarephysician.Address.Id).
                                                             Select(a => a).Single()
                                                       : primaryCarephysician.Address;
                }

                return primaryCarephysicians;
            }
        }

        public IEnumerable<PrimaryCarePhysician> GetCustomerPcpWithoutAddress(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from cpcp in linqMetaData.CustomerPrimaryCarePhysician
                                where customerIds.Contains(cpcp.CustomerId)
                                select cpcp).ToArray();

                var primaryCarephysicians = _mapper.MapMultiple(entities);

                return primaryCarephysicians;
            }
        }

        public IEnumerable<PrimaryCarePhysician> GetPrimaryCarePhysicians(UniversalProviderListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eligibleCustomers = (from ce in linqMetaData.CustomerEligibility
                                         where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year
                                         select ce.CustomerId);

                var customerIds = (from cp in linqMetaData.CustomerProfile
                                   where cp.Tag == filter.Tag && eligibleCustomers.Contains(cp.CustomerId)
                                   select cp.CustomerId);

                var query = (from cpcp in linqMetaData.CustomerPrimaryCarePhysician
                             where cpcp.IsActive == true && customerIds.Contains(cpcp.CustomerId)
                             select cpcp);

                totalRecords = (from cpcp in query select cpcp.CustomerId).Count();

                var entities = query.OrderBy(x => x.PrimaryCarePhysicianId).TakePage(pageNumber, pageSize).ToArray();


                var primaryCarephysicians = _mapper.MapMultiple(entities);

                var addressIds = primaryCarephysicians.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);

                foreach (var primaryCarephysician in primaryCarephysicians)
                {
                    primaryCarephysician.Address = primaryCarephysician.Address != null
                                                       ? addresses.Where(a => a.Id == primaryCarephysician.Address.Id).
                                                             Select(a => a).Single()
                                                       : primaryCarephysician.Address;
                }

                return primaryCarephysicians;
            }
        }
    }
}