using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class GuardianRepository : PersistenceRepository, IGuardianRepository
    {
        private readonly IMapper<GuardianDetails, GuardianDetailsEntity> _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IAddressService _addressService;
        private readonly IRelationshipRepository _relationshipRepository;

        public GuardianRepository(IMapper<GuardianDetails, GuardianDetailsEntity> mapper, IAddressRepository addressRepository, IAddressService addressService, IRelationshipRepository relationshipRepository)
        {
            _mapper = mapper;
            _addressRepository = addressRepository;
            _addressService = addressService;
            _relationshipRepository = relationshipRepository;
        }

        public GuardianDetails GetbyWithAddressId(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from gd in linqMetaData.GuardianDetails where gd.Id == id select gd).SingleOrDefault();

                if (entity == null) return null;

                var domainObject = _mapper.Map(entity);

                domainObject.Address = domainObject.Address != null
                                           ? _addressRepository.GetAddress(domainObject.Address.Id)
                                           : domainObject.Address;

                domainObject.Relationship = _relationshipRepository.GetById(entity.RelationshipId);

                return domainObject;
            }
        }

        public GuardianDetails GetbyWithoutAddressId(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from gd in linqMetaData.GuardianDetails where gd.Id == id select gd).SingleOrDefault();

                if (entity == null) return null;

                var domainObject = _mapper.Map(entity);

                domainObject.Relationship = _relationshipRepository.GetById(entity.RelationshipId);

                return domainObject;
            }
        }

        public IEnumerable<GuardianDetails> GetWithAddressByCustomerId(long customerId, bool isActive = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from gd in linqMetaData.GuardianDetails where gd.CustomerId == customerId && gd.IsActive == isActive select gd).ToArray();

                if (entities.IsNullOrEmpty()) return null;

                var guardianDetails = _mapper.MapMultiple(entities);

                var addressIds = guardianDetails.Where(pcp => pcp.Address != null).Select(pcp => pcp.Address.Id).ToList();
                var addresses = _addressRepository.GetAddresses(addressIds);

                var relationships = _relationshipRepository.GetByIds(entities.Select(x => x.RelationshipId));

                foreach (var guardian in guardianDetails)
                {
                    guardian.Address = guardian.Address != null
                                          ? addresses.Single(a => a.Id == guardian.Address.Id)
                                          : guardian.Address;

                    guardian.Relationship = relationships.First(r => r.Id == guardian.Relationship.Id);
                }

                return guardianDetails;
            }
        }

        public IEnumerable<GuardianDetails> GetWithoutAddressByCustomerId(long customerId, bool isActive = true)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from gd in linqMetaData.GuardianDetails where gd.CustomerId == customerId && gd.IsActive == isActive select gd).ToArray();

                if (entities.IsNullOrEmpty()) return null;

                var guardianDetails = _mapper.MapMultiple(entities);

                var relationships = _relationshipRepository.GetByIds(entities.Select(x => x.RelationshipId));

                foreach (var guardian in guardianDetails)
                {
                    guardian.Relationship = relationships.First(r => r.Id == guardian.Relationship.Id);
                }

                return guardianDetails;
            }
        }

        public GuardianDetails Save(GuardianDetails domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (domainObject.Address != null)
                {
                    domainObject.Address = _addressService.SaveAfterSanitizing(domainObject.Address, true);
                }

                var entity = _mapper.Map(domainObject);
                adapter.SaveEntity(entity, true);

                return GetbyWithAddressId(entity.Id);
            }
        }
    }
}
