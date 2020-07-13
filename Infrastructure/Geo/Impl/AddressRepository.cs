using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Factories;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.Data.TypedViewClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class AddressRepository : PersistenceRepository, IAddressRepository
    {
        private readonly IAddressFactory _addressFactory;

        public AddressRepository()
            : this(new SqlPersistenceLayer(), new AddressFactory())
        { }

        public AddressRepository(IPersistenceLayer persistenceLayer, IAddressFactory addressFactory)
            : base(persistenceLayer)
        {
            _addressFactory = addressFactory;
        }

        public Address GetAddress(long addressId)
        {
            var addressViewTypedView = new AddressViewTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(AddressViewFields.AddressId == addressId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(addressViewTypedView, bucket, false);
            }
            if (addressViewTypedView.Rows.IsEmpty())
            {
                throw new ObjectNotFoundInPersistenceException<Address>(addressId);
            }
            return _addressFactory.CreateAddress(addressViewTypedView.Single());
        }


        public void UnDeleteAddress(long addressId)
        {
            var addressEntity = new AddressEntity(addressId);
            addressEntity.IsActive = true;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.FetchEntity(addressEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<Address>(addressId);
                }
            }
        }

        public bool ValidateAddress(Address addressToValidate)
        {
            if (string.IsNullOrEmpty(addressToValidate.StreetAddressLine1) &&
                (string.IsNullOrEmpty(addressToValidate.State) || addressToValidate.StateId == 0) &&
                (string.IsNullOrEmpty(addressToValidate.City) || addressToValidate.StateId == 0) &&
                (string.IsNullOrEmpty(addressToValidate.Country) || addressToValidate.CountryId == 0) &&
                addressToValidate.ZipCode == null)
            {
                throw new InvalidAddressException("Address", "Address is not valid");
            }

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var country = linqMetaData.Country.Where(s => s.Name == addressToValidate.Country || s.CountryId == addressToValidate.CountryId).FirstOrDefault();

                if (country == null)
                    throw new InvalidAddressException(addressToValidate.Country, "Country");

                var state = linqMetaData.State.Where(s => s.Name == addressToValidate.State || s.StateId == addressToValidate.StateId).FirstOrDefault();

                if (state == null)
                    throw new InvalidAddressException(addressToValidate.State, "State");

                var city =
                    linqMetaData.City.Where(c => c.StateId == state.StateId && c.Name == addressToValidate.City || c.CityId == addressToValidate.CityId).FirstOrDefault();

                if (city == null)
                    throw new InvalidAddressException(addressToValidate.City, "City");

                var zip = linqMetaData.Zip.Where(z => z.CityId == city.CityId && z.ZipCode == addressToValidate.ZipCode.Zip).FirstOrDefault();

                if (zip == null)
                    throw new InvalidAddressException(addressToValidate.ZipCode.Zip, "Zip for the City you entered");

                return true;
            }
        }

        public List<Address> GetAddresses(List<long> addressIds)
        {
            var addressViewTypedView = new AddressViewTypedView();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(AddressViewFields.AddressId == addressIds.ToArray());
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchTypedView(addressViewTypedView, bucket, false);
            }
            return _addressFactory.CreateAddresses(addressViewTypedView);

        }


        public Address Save(Address address)
        {
            return Save(address, true);
        }


        public Address SaveTemporary(Address address)
        {
            return Save(address, false);
        }


        private Address Save(Address address, bool isActive)
        {
            NullArgumentChecker.CheckIfNull(address, "address");

            ValidateAddress(address);

            var addressEntity = _addressFactory.CreateAddressEntity(address);
            addressEntity.IsActive = isActive;
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(addressEntity, true))
                {
                    throw new PersistenceFailureException();
                }
                address.Id = addressEntity.AddressId;
                return address;
            }
        }



        public bool UpdateAddressLatitudeAndLongitude(long addressId, string latitude, string longitude, long verificationOrganizationRoleUserId, bool useLatLogForMapping)
        {
            var hostAddress = new AddressEntity(addressId) { Latitude = latitude, Longitude = longitude, VerificationOrgRoleUserId = verificationOrganizationRoleUserId, UseLatLogForMapping = useLatLogForMapping };
            IRelationPredicateBucket relationPredicateBucket =
            new RelationPredicateBucket(AddressFields.AddressId == addressId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostAddress, relationPredicateBucket) > 0;
            }
        }
        public bool UpdateGoogleMapVerificatioStatus(long addressId, bool? isManuallyVerified, long verificationOrganizationRoleUserId)
        {
            var hostAddress = new AddressEntity(addressId) { IsManuallyVerified = isManuallyVerified, VerificationOrgRoleUserId = verificationOrganizationRoleUserId };
            IRelationPredicateBucket relationPredicateBucket =
            new RelationPredicateBucket(AddressFields.AddressId == addressId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostAddress, relationPredicateBucket) > 0;
            }
        }

        public bool UpdateNeedVerfication(long addressId, bool needVerfication)
        {
            var address = new AddressEntity(addressId) { NeedVerification = needVerfication };
            IRelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket(AddressFields.AddressId == addressId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(address, relationPredicateBucket) > 0;
            }
        }

        public bool UpdateNeedVerficationbyAddressIds(List<long> addressIds)
        {
            var address = new AddressEntity() { NeedVerification = true };
            IRelationPredicateBucket relationPredicateBucket = new RelationPredicateBucket(AddressFields.AddressId == addressIds);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(address, relationPredicateBucket) > 0;
            }
        }

    }
}