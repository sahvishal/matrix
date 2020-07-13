using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.CallQueues.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.InboundReport.ViewModels;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.Infrastructure.Factories.Users;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using Falcon.App.Core.Extensions;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Sales.ViewModels;
using Falcon.Data;
using DateTime = System.DateTime;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Scheduling.Repositories;

namespace Falcon.App.Infrastructure.Repositories.Users
{
    public class CustomerRepository : PersistenceRepository, ICustomerRepository
    {
        private readonly IUserRepository<Customer> _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ICustomerFactory _customerFactory;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IZipCodeRepository _zipCodeRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IEventProductTypeRepository _eventProductTypeRepository;
        
        public CustomerRepository()
            : this(new UserRepository<Customer>(),
                   new AddressRepository(), new CustomerFactory(), new OrganizationRepository(), new ZipCodeRepository(), new OrganizationRoleUserRepository(), new EventProductTypeRepository())
        { }

        public CustomerRepository(IUserRepository<Customer> customerRepository, IAddressRepository addressRepository,
            ICustomerFactory customerFactory, IOrganizationRepository organizationRepository, IZipCodeRepository zipCodeRepository, IOrganizationRoleUserRepository organizationRoleUserRepository, IEventProductTypeRepository eventProductTypeRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _customerFactory = customerFactory;
            _organizationRepository = organizationRepository;
            _zipCodeRepository = zipCodeRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _eventProductTypeRepository = eventProductTypeRepository;
        }

        public Customer GetCustomer(long customerId)
        {
            CustomerProfileEntity customerEntity = null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                customerEntity = linqMetaData.CustomerProfile.WithPath(
                    prefetchPath => prefetchPath.Prefetch(cp => cp.OrganizationRoleUser)).Where(
                        cp => cp.CustomerId == customerId).SingleOrDefault();


                if (customerEntity == null)
                {
                    throw new ObjectNotFoundInPersistenceException<Customer>(customerId);
                }
            }
            Customer user = _customerRepository.GetUser(customerEntity.OrganizationRoleUser.UserId);
            var billingAddress =
                _addressRepository.GetAddress(customerEntity.BillingAddressId.HasValue
                                                  ? customerEntity.BillingAddressId.Value
                                                  : user.Address.Id);
            return _customerFactory.CreateCustomer(user, billingAddress, customerEntity);
        }

        public IEnumerable<long> GetCustomerIdForRaps(string cmsHicn, string firstName, string lastName, DateTime? dob)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEntity = (from cp in linqMetaData.CustomerProfile
                                      join
                                          oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                                      join
                                          u in linqMetaData.User
                                          on oru.UserId equals u.UserId
                                      where cp.Hicn == cmsHicn
                                         && u.FirstName == firstName && u.LastName == lastName && (u.Dob.HasValue && u.Dob == dob)
                                      select cp.CustomerId).ToList();
                return customerEntity;
            }
        }

        public Customer GetCustomerByOrganizationRoleUser(long organizationRoleUserId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userId =
                    linqMetaData.OrganizationRoleUser.Single(oru => oru.OrganizationRoleUserId == organizationRoleUserId)
                        .UserId;

                return GetCustomerByUserId(userId);
            }
        }

        public List<Customer> GetCustomers(long[] customerIds)
        {
            var customerEntityCollection = new EntityCollection<CustomerProfileEntity>();
            IRelationPredicateBucket bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerIds);
            IPrefetchPath2 path = new PrefetchPath2(EntityType.CustomerProfileEntity);
            path.Add(CustomerProfileEntity.PrefetchPathOrganizationRoleUser);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(customerEntityCollection, bucket, path);
            }

            List<Customer> users = _customerRepository.GetUsers(customerEntityCollection.Select(ce => ce.OrganizationRoleUser.UserId).ToList());
            var userDictionaryFactory = new DomainDictionaryFactory<Customer>();
            var userDictionary = userDictionaryFactory.GetDictionary(users);

            var billingAddresses =
                _addressRepository.GetAddresses((customerEntityCollection.Select(c => c.BillingAddressId.HasValue ? c.BillingAddressId.Value : users.Single(u => u.Id == c.OrganizationRoleUser.UserId).Address.Id).ToList()));

            return
                customerEntityCollection.Select(c => _customerFactory.CreateCustomer(userDictionary[c.OrganizationRoleUser.UserId], c.BillingAddressId.HasValue
                                                                                  ? billingAddresses.SingleOrDefault(a => a.Id == c.BillingAddressId.Value)
                                                                                  : billingAddresses.SingleOrDefault(a => a.Id == users.Single(u => u.Id == c.OrganizationRoleUser.UserId).Address.Id), c)).ToList();
        }


        public List<Customer> GetCustomersByOrganizationRoleUsers(List<long> organizationRoleUserIds)
        {
            var customers = new List<Customer>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var userIds =
                    linqMetaData.OrganizationRoleUser.Where(
                        oru => organizationRoleUserIds.Contains(oru.OrganizationRoleUserId)).Select(oru => oru.UserId);

                if (userIds.IsNullOrEmpty())
                {
                    throw new EmptyCollectionException();
                }

                foreach (var userId in userIds)
                {
                    customers.Add(GetCustomerByUserId(userId));
                }
            }
            return customers;
        }
        //TODO Check this
        public Customer GetCustomerByUserId(long userId)
        {
            Customer user = _customerRepository.GetUser(userId);
            var customerEntities = new EntityCollection<CustomerProfileEntity>();
            IRelationPredicateBucket relationPredicate = new RelationPredicateBucket();
            relationPredicate.Relations.Add(CustomerProfileEntity.Relations.OrganizationRoleUserEntityUsingCustomerId);
            relationPredicate.PredicateExpression.Add(OrganizationRoleUserFields.UserId == userId);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityCollection(customerEntities, relationPredicate);
                if (customerEntities.IsNullOrEmpty())
                {
                    throw new ObjectNotFoundInPersistenceException<Customer>(user.CustomerId);
                }
            }

            var customerEntity = customerEntities.SingleOrDefault();

            var billingAddress =
                _addressRepository.GetAddress(customerEntity.BillingAddressId.HasValue
                                                  ? customerEntity.BillingAddressId.Value
                                                  : user.Address.Id);
            return _customerFactory.CreateCustomer(user, billingAddress, customerEntity);
        }

        public Customer GetCustomerForShippingDetail(long shippingDetailId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                try
                {
                    // There can be multiple shipping details active for a order detail but they will always be mapped ro single order detail with in a order.
                    var orderDetailId = linqMetaData.ShippingDetailOrderDetail.First(
                        sdod => sdod.ShippingDetailId == shippingDetailId && sdod.IsActive).OrderDetailId;

                    var forOrganizationRoleUserId =
                        linqMetaData.OrderDetail.Single(od => od.OrderDetailId == orderDetailId).
                            ForOrganizationRoleUserId;

                    var userId =
                        linqMetaData.OrganizationRoleUser.Single(
                            oru => oru.OrganizationRoleUserId == forOrganizationRoleUserId).UserId;

                    return GetCustomerByUserId(userId);
                }
                catch (Exception)
                {
                    throw new ObjectNotFoundInPersistenceException<Customer>();
                }
            }
        }

        public bool UniqueEmail(long customerId, string emailAddress)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var emails = from organizationRoleUser in linqMetaData.OrganizationRoleUser
                             join user in linqMetaData.User on organizationRoleUser.UserId equals user.UserId
                             where organizationRoleUser.RoleId == (int)Roles.Customer && organizationRoleUser.OrganizationRoleUserId != customerId && user.Email1 == emailAddress && organizationRoleUser.IsActive
                             select user.Email1;
                if (emails.Count() > 0)
                {
                    if (!string.IsNullOrEmpty(emails.SingleOrDefault()))
                        return false;
                    return true;
                }
                return true;
            }
        }

        public bool SaveCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException("customer", "The given customer cannot be null.");
            }
            long organizationRoleUserId = 0;
            if (customer.CustomerId == 0)
            {
                var organization = _organizationRepository.GetOrganizationCollection(OrganizationType.Franchisor);
                if (organization != null && organization.Count() > 0)
                {
                    var franchisorOrganization = organization.SingleOrDefault();
                    IOrganizationRoleUserRepository organizationRoleUserRepository =
                        new OrganizationRoleUserRepository();
                    var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(customer.Id, Roles.Customer,
                                                                                             franchisorOrganization.Id);
                    organizationRoleUserId = orgRoleUser.Id;
                }
                else
                    throw new EmptyCollectionException();
            }
            CustomerProfileEntity customersEntity = _customerFactory.CreateCustomerEntity(customer, organizationRoleUserId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(customersEntity, true, false))
                {
                    throw new PersistenceFailureException();
                }
                customer.UserLogin.Id = customer.Id;
                customer.CustomerId = customersEntity.CustomerId;
                return true;
            }
        }

        public long GetCustomerEventCustomerUserId(long customerId)
        {
            var eventCustomerEntity = new EventCustomersEntity();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.FetchEntityUsingUniqueConstraint(eventCustomerEntity, new PredicateExpression(EventCustomersFields.CustomerId == customerId));
            }
            return eventCustomerEntity.EventCustomerId;
        }

        public bool UpdateMaketingSource(long customerId, string marketingSource)
        {
            var customersEntity = new CustomerProfileEntity(customerId) { TrackingMarketingId = marketingSource };
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);
                try
                {
                    return (myAdapter.UpdateEntitiesDirectly(customersEntity, bucket) > 0) ? true : false;
                }
                catch (Exception exception)
                {
                    throw new PersistenceFailureException(exception.Message);
                }
            }
        }

        public List<Customer> GetCustomerByFilters(string firstName, string lastName, long customerId, long stateId, string cityName, string zipCode, DateTime? registrationDate, string phoneNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var userAddressCollection = linqMetaData.OrganizationRoleUser.Where(oru => oru.RoleId == (long)Roles.Customer && (customerId > 0 ? oru.OrganizationRoleUserId == customerId : true)).Join(
                    linqMetaData.User.Where(u => (firstName.Trim().Length > 0
                                                      ? u.FirstName.StartsWith(firstName,
                                                                               StringComparison.
                                                                                   InvariantCultureIgnoreCase)
                                                      : true) &&
                                                 (lastName.Trim().Length > 0
                                                      ? (lastName.Length == 2
                                                             ? u.LastName.Equals(lastName,
                                                                                 StringComparison.
                                                                                     InvariantCultureIgnoreCase)
                                                             : u.LastName.StartsWith(lastName,
                                                                                     StringComparison.
                                                                                         InvariantCultureIgnoreCase))
                                                      : true) || (phoneNumber.Trim().Length > 0 ? (u.PhoneHome == phoneNumber) : false)), oru => oru.UserId, u => u.UserId,
                    (oru, u) => new { oru.OrganizationRoleUserId, u.UserId, u.HomeAddressId }).ToList();

                var addressIds = userAddressCollection.Select(u => u.HomeAddressId).ToList();


                var filteredIds = linqMetaData.Address.WithPath(
                    prefetchPath => prefetchPath.Prefetch(address => address.City).Prefetch(address => address.Zip)).
                    Where(
                        @t =>
                            addressIds.Contains(@t.AddressId) &&
                        (stateId == 0
                             ? true
                             : @t.StateId == stateId) &&
                        (cityName.Trim().Length > 0
                             ? @t.City.Name ==
                               cityName
                             : true) &&
                        (zipCode.Trim().Length > 0
                             ? @t.Zip.ZipCode == zipCode
                             : true)).Select(@t => @t.AddressId).ToList();

                var customerIds =
                    userAddressCollection.Where(u => filteredIds.Contains(u.HomeAddressId)).Select(
                        u => u.OrganizationRoleUserId).ToArray();

                customerIds = linqMetaData.CustomerProfile.Where(cp => (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value != (long)DoNotContactType.DoNotContact) && customerIds.Contains(cp.CustomerId)).Select(cp => cp.CustomerId).ToArray();

                //TODO : Check for registration date

                //      (registrationDate.HasValue
                //           ?
                //               @t.DateCreated.ToShortDateString() ==
                //               registrationDate.Value.
                //                   ToShortDateString()
                //           : true)).Select(
                //@t => @t.CustomerId).ToList();)

                return customerIds.Count() > 0 ? GetCustomers(customerIds) : new List<Customer>();
            }
        }

        public Customer GetCustomerByAppointmentId(long appointmentId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomer = linqMetaData.EventCustomers.SingleOrDefault(ec => ec.AppointmentId == appointmentId);

                if (eventCustomer != null)
                {
                    return GetCustomer(eventCustomer.CustomerId);
                }
                return null;
            }
        }

        public IEnumerable<Customer> GetCustomerForAnnualNotification(DateTime annualDate, int days)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fromDate = annualDate.Date.AddDays(days);
                var linqMetaData = new LinqMetaData(adapter);

                var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                    join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                    where e.EventDate > fromDate.Date
                                                          && ec.AppointmentId.HasValue
                                                          && !ec.NoShow
                                                    select ec.CustomerId).ToArray();

                var customerIds = (from e in linqMetaData.Events
                                   join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                   join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                   where e.EventDate == fromDate.Date
                                         && (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value != (long)DoNotContactType.DoNotContact)
                                         && !corporateEventIds.Contains(e.EventId)
                                         && ec.AppointmentId.HasValue
                                         && !ec.NoShow
                                   //&& !(cp.Tag.HasValue && cp.Tag.Value == (long)CustomerTag.PhysicianPartner)
                                   orderby ec.CustomerId
                                   select ec.CustomerId).Distinct().ToArray();

                customerIds = customerIds.Where(cid => !alreadyRegisteredCustomerIds.Contains(cid)).Select(cid => cid).ToArray();

                return customerIds.Count() > 0 ? customerIds.Select(GetCustomer).ToList() : null;
            }
        }

        public IEnumerable<long> GetCustomerBasedOnGeography(string zipCode, int radius, bool olderThanOneYear)
        {
            var zipcodeRepository = new ZipCodeRepository();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var zipInRange = zipcodeRepository.GetZipCodesInRadius(zipCode, radius);

                var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Id).ToList() : null;

                if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                {
                    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                    linqMetaData.CustomFunctionMappings.Add(mapping);
                    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                    linqMetaData.CustomFunctionMappings.Add(mapping);

                    string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";

                    var corporateEventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                    var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                        join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                        join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                                        where e.EventDate > DateTime.Now.Date.AddYears(-1)
                                                              && ec.AppointmentId.HasValue
                                                              && !ec.NoShow
                                                              && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.ZipId), zipIdstring) > 0
                                                        select ec.CustomerId).ToArray();

                    var customerIds = (from e in linqMetaData.Events
                                       join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                       join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                       where !corporateEventIds.Contains(e.EventId)
                                             && ec.AppointmentId.HasValue
                                             && !ec.NoShow
                                           //&& !(cp.Tag.HasValue && cp.Tag.Value == (long)CustomerTag.PhysicianPartner)
                                             && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.ZipId), zipIdstring) > 0
                                             && (olderThanOneYear ? e.EventDate <= DateTime.Now.Date.AddYears(-1) : true)
                                       orderby ec.CustomerId
                                       select ec.CustomerId).Distinct().ToArray();
                    if (olderThanOneYear)
                        customerIds = customerIds.Where(cid => !alreadyRegisteredCustomerIds.Contains(cid)).Select(cid => cid).ToArray();

                    return customerIds;
                }
                return null;
            }
        }

        private static int IndexOf(string searchText, string searchFrom)
        {
            return searchFrom.IndexOf(searchText);
        }

        public IEnumerable<Customer> GetCustomerForExport(int pageNumber, int pageSize, CustomerExportListModelFilter filter, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                // IEnumerable<long> customerIds;
                if (filter != null && (filter.FromDate.HasValue || filter.ToDate.HasValue || !string.IsNullOrEmpty(filter.FirstName) || !string.IsNullOrEmpty(filter.LastName) || !string.IsNullOrEmpty(filter.Tag)
                    || filter.CustomerId > 0 || filter.IsAttendedCustomers || filter.IsNotAttendedCustomers || filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent
                    || (filter.CustomTags != null && filter.CustomTags.Any()) || !string.IsNullOrWhiteSpace(filter.MemberId) || !filter.IncludeDoNotContact || !filter.DoNotContactOnly || filter.EligibleStatus != EligibleFilterStatus.All) || filter.AppointmentFrom.HasValue || filter.AppointmentTo.HasValue)
                {


                    var query = (from cp in linqMetaData.CustomerProfile where !cp.DoNotContactReasonId.HasValue select cp);
                   
                    if (filter.IncludeDoNotContact)
                    {
                        query = (from cp in linqMetaData.CustomerProfile select cp);
                    }

                    if (filter.DoNotContactOnly)
                    {
                        query = (from cp in linqMetaData.CustomerProfile where cp.DoNotContactReasonId.HasValue select cp);
                    }

                    if (filter.ProductTypeId > 0)
                    {
                        query = query.Where(x => x.ProductTypeId == filter.ProductTypeId);
                    }
                    
                    if (filter.EligibleStatus == EligibleFilterStatus.OnlyEligible)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                        query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                    }
                    else if (filter.EligibleStatus == EligibleFilterStatus.NotEligible)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value == false && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                        query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                    }
                    else if (filter.EligibleStatus == EligibleFilterStatus.NotMentioned)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible == null && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                        query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                    }

                    if (filter.CustomerId > 0)
                    {
                        query = query.Where(q => q.CustomerId == filter.CustomerId);
                    }
                    else if (!string.IsNullOrWhiteSpace(filter.MemberId))
                    {
                        query = query.Where(q => q.InsuranceId != null && q.InsuranceId.Trim() == filter.MemberId.Trim());
                    }
                    else
                    {
                        if (filter.OnlyRetailCustomers)
                        {
                            query = query.Where(q => q.Tag == null || q.Tag == "");
                        }
                        else
                        {
                            if (filter.HealthPlanId > 0)
                            {
                                var account = (from a in linqMetaData.Account where a.AccountId == filter.HealthPlanId select a).SingleOrDefault();
                                if (account != null && !string.IsNullOrEmpty(account.Tag))
                                {
                                    query = query.Where(q => q.Tag == account.Tag);
                                }
                            }

                            if (!string.IsNullOrEmpty(filter.Tag))
                            {
                                query = query.Where(q => q.Tag == filter.Tag);
                            }
                        }



                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.DateCreated >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.DateCreated < filter.ToDate.Value.AddDays(1));

                        if (!string.IsNullOrEmpty(filter.FirstName) || !string.IsNullOrEmpty(filter.LastName))
                        {
                            var firstName = !string.IsNullOrEmpty(filter.FirstName) ? filter.FirstName : "";
                            var lastName = !string.IsNullOrEmpty(filter.LastName) ? filter.LastName : "";
                            query = (from q in query
                                     join org in linqMetaData.OrganizationRoleUser on q.CustomerId equals org.OrganizationRoleUserId
                                     join u in linqMetaData.User on org.UserId equals u.UserId
                                     where (firstName.Trim().Length > 0 ? u.FirstName.StartsWith(firstName.Trim(), StringComparison.InvariantCultureIgnoreCase) : true)
                                     && (lastName.Trim().Length > 0 ? u.LastName.StartsWith(lastName.Trim(), StringComparison.InvariantCultureIgnoreCase) : true)
                                     select q);
                        }

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {
                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                        where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                        select ct.CustomerId);
                            query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                        }

                        if (filter.IsAttendedCustomers || filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent || filter.AppointmentFrom.HasValue || filter.AppointmentTo.HasValue || filter.IsHealthPlanEvent)
                        {
                            var eventQuery = (from ec in linqMetaData.EventCustomers
                                              join e in linqMetaData.Events on ec.EventId equals e.EventId
                                              select new { ec.EventCustomerId, ec.CustomerId, ec.EventId, ec.AppointmentId, e.EventTypeId, e.EventDate });

                            var queryForEcs = (from q in query
                                               join ec in eventQuery on q.CustomerId equals ec.CustomerId
                                                   into ecQuery
                                               from eq in ecQuery.DefaultIfEmpty()
                                               select new { q, eq.EventCustomerId, eq.EventId, eq.AppointmentId, eq.EventTypeId, eq.EventDate });

                            if (filter.IsAttendedCustomers && !filter.IsNotAttendedCustomers)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventCustomerId != null && q.AppointmentId != null);
                            }

                            if (filter.AppointmentFrom.HasValue)
                                queryForEcs = queryForEcs.Where(q => q.EventDate >= filter.AppointmentFrom.Value && q.AppointmentId.HasValue);
                            if (filter.AppointmentTo.HasValue)
                                queryForEcs = queryForEcs.Where(q => q.EventDate < filter.AppointmentTo.Value.AddHours(23).AddMinutes(59) && q.AppointmentId.HasValue);

                            if (filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent || filter.IsHealthPlanEvent)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventCustomerId != null && q.AppointmentId != null);
                            }

                            if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                            }
                            else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventTypeId == (long)RegistrationMode.Private);
                            }

                            if (filter.IsRetailEvent && !filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                            {
                                var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                                queryForEcs = (from q in queryForEcs
                                               where q.EventId != null && !eventIds.Contains(q.EventId)
                                               select q);
                            }
                            else if (!filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                            {
                                var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                                var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                                queryForEcs = (from q in queryForEcs where q.EventId != null && eventIds.Contains(q.EventId) select q);
                            }
                            else if (!filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                            {
                                var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                                var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                                queryForEcs = (from q in queryForEcs where q.EventId != null && eventIds.Contains(q.EventId) select q);
                            }
                            else if (!filter.IsRetailEvent && filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                            {
                                var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);

                                queryForEcs = (from q in queryForEcs where q.EventId != null && eventIds.Contains(q.EventId) select q);
                            }
                            else if (filter.IsRetailEvent && !filter.IsCorporateEvent && filter.IsHealthPlanEvent)
                            {
                                var notHealthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan == false select h.AccountId);

                                var eventIds = (from ea in linqMetaData.EventAccount where notHealthPlanIds.Contains(ea.AccountId) select ea.EventId);

                                queryForEcs = (from q in queryForEcs where q.EventId != null && !eventIds.Contains(q.EventId) select q);
                            }
                            else if (filter.IsRetailEvent && filter.IsCorporateEvent && !filter.IsHealthPlanEvent)
                            {
                                var healthPlanIds = (from h in linqMetaData.Account where h.IsHealthPlan select h.AccountId);

                                var eventIds = (from ea in linqMetaData.EventAccount where healthPlanIds.Contains(ea.AccountId) select ea.EventId);

                                queryForEcs = (from q in queryForEcs where q.EventId != null && !eventIds.Contains(q.EventId) select q);
                            }


                            query = (from qec in queryForEcs select qec.q);
                        }
                        else if (!filter.IsAttendedCustomers && filter.IsNotAttendedCustomers)
                        {
                            var attendedCustomerIds = (from ec in linqMetaData.EventCustomers
                                                       where ec.AppointmentId.HasValue
                                                       select ec.CustomerId);

                            query = (from q in query where !attendedCustomerIds.Contains(q.CustomerId) select q);
                        }
                    }

                    //var queryforCustomer = (from q in query orderby q.DateCreated, q.CustomerId select q.CustomerId).Distinct().Select(s => s);
                    var queryforCustomer = (from q in query select q.CustomerId).Distinct().Select(s => s);
                    totalRecords = queryforCustomer.Count();

                    var tempQuery = (from q in queryforCustomer
                                     join c in linqMetaData.CustomerProfile on q equals c.CustomerId
                                     orderby c.DateCreated, c.CustomerId
                                     select c);


                    if (totalRecords < 1)
                        return null;

                    var customerProfileEntities = tempQuery.TakePage(pageNumber, pageSize).ToArray();
                    return GetCustomersWithoutLogin(customerProfileEntities).OrderBy(c => c.DateCreated).ThenBy(c => c.CustomerId);
                }
                else
                {
                    var query = (from cp in linqMetaData.CustomerProfile
                                 where !cp.DoNotContactReasonId.HasValue
                                 orderby cp.DateCreated descending, cp.CustomerId
                                 select cp);

                    totalRecords = query.Count();

                    if (totalRecords < 1)
                        return null;

                    var customerProfileEntities = query.TakePage(pageNumber, pageSize).ToArray();

                    return GetCustomersWithoutLogin(customerProfileEntities).OrderBy(c => c.DateCreated).ThenBy(c => c.CustomerId);
                }
            }
        }

        public IEnumerable<long> GetPhysicianPartnerCustomerBasedOnGeography(string zipCode, int radius, long accountId)
        {
            var zipcodeRepository = new ZipCodeRepository();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var tag = (from a in linqMetaData.Account where a.AccountId == accountId select a.Tag).Single();

                var zipInRange = zipcodeRepository.GetZipCodesInRadius(zipCode, radius);

                var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Id).ToList() : null;

                if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                {
                    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                    linqMetaData.CustomFunctionMappings.Add(mapping);
                    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                    linqMetaData.CustomFunctionMappings.Add(mapping);

                    string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";

                    var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                        join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                        join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                                        where e.EventDate > DateTime.Now.Date.AddYears(-1)
                                                              && ec.AppointmentId.HasValue
                                                              && !ec.NoShow
                                                              && (cp.Tag == tag)
                                                              && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.ZipId), zipIdstring) > 0
                                                        select ec.CustomerId).ToArray();

                    var customerIds = (from cp in linqMetaData.CustomerProfile
                                       where (cp.Tag == tag)
                                             && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.ZipId), zipIdstring) > 0
                                       orderby cp.CustomerId
                                       select cp.CustomerId).Distinct().ToArray();

                    customerIds = customerIds.Where(cid => !alreadyRegisteredCustomerIds.Contains(cid)).Select(cid => cid).ToArray();

                    return customerIds;
                }
                return null;
            }
        }

        public bool IsCustomerTagInUse(string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.CustomerProfile.Any(x => x.Tag == tag);
            }
        }

        //private string SetFilterText(string newText)
        //{
        //    return filtertext + " : " + newText;
        //}

        public Customer GetCustomerForCorporate(string firstName, string middleName, string lastName, string email, string phoneHome, string phoneCell, DateTime? dob, string tag, StringBuilder filterLevelText)
        {
            filterLevelText = filterLevelText ?? new StringBuilder();
            filterLevelText.Append("Customer(s) with same");
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where cp.Tag == tag
                             && u.FirstName == firstName && u.LastName == lastName
                             select new { cp.CustomerId, u.FirstName, u.MiddleName, u.LastName, u.Email1, u.PhoneHome, u.PhoneOffice, u.PhoneCell, u.Dob });

                filterLevelText.Append(" First Name, Last Name");

                if (dob.HasValue)
                {
                    #region DOB
                    var customerQuery = (from q in query where q.Dob.HasValue && q.Dob.Value == dob.Value select q);

                    filterLevelText.Append(", Dob");

                    var totalRecords = customerQuery.Count();

                    if (totalRecords == 1)
                    {
                        var entity = customerQuery.First();

                        filterLevelText.Append(" already exist in the system. Single Customer Found: " + entity.CustomerId);

                        return GetCustomer(entity.CustomerId);
                    }
                    if (totalRecords > 1)
                    {
                        if (!string.IsNullOrEmpty(phoneHome) || !string.IsNullOrEmpty(phoneCell))
                        {
                            #region Phone
                            customerQuery = (from q in customerQuery
                                             where (
                                                     (phoneHome != null && phoneHome != "" && (q.PhoneHome == phoneHome || q.PhoneOffice == phoneHome || q.PhoneCell == phoneHome))
                                                     || (phoneCell != null && phoneCell != "" && (q.PhoneHome == phoneCell || q.PhoneOffice == phoneCell || q.PhoneCell == phoneCell))
                                                 )
                                             select q);

                            filterLevelText.Append(", Phone");

                            totalRecords = customerQuery.Count();

                            if (totalRecords == 1)
                            {
                                var entity = customerQuery.First();

                                filterLevelText.Append(" already exist in the system. Single Customer Found: " + entity.CustomerId);

                                return GetCustomer(entity.CustomerId);
                            }

                            if (totalRecords > 1)
                            {
                                if (!string.IsNullOrEmpty(email))
                                {
                                    #region Email
                                    customerQuery = (from q in customerQuery
                                                     where q.Email1 == email
                                                     select q);

                                    filterLevelText.Append(", Email");

                                    totalRecords = customerQuery.Count();

                                    if (totalRecords == 1)
                                    {
                                        var entity = customerQuery.First();

                                        filterLevelText.Append(" already exist in the system. Single Customer Found: " + entity.CustomerId);

                                        return GetCustomer(entity.CustomerId);
                                    }

                                    if (totalRecords > 1)
                                    {
                                        var customerIds = (customerQuery.Select(x => x.CustomerId)).ToArray();
                                        filterLevelText.Append(" already exist in the system. Multiple Customer Found: " + string.Join(",", customerIds));
                                        return null;
                                    }
                                    #endregion
                                }
                            }
                            if (totalRecords == 0)
                            {
                                //filterLevelText = new StringBuilder("");
                                filterLevelText.Clear();
                                return null;
                            }
                            #endregion
                        }

                        if (totalRecords > 1)
                        {
                            var customerIds = (customerQuery.Select(x => x.CustomerId)).ToArray();
                            filterLevelText.Append(" already exist in the system. Multiple Customer Found: " + string.Join(",", customerIds));
                            return null;
                        }
                    }

                    if (totalRecords == 0)
                    {
                        //filterLevelText = new StringBuilder("");
                        filterLevelText.Clear();
                        return null;
                    }
                    #endregion
                }

                //filterLevelText = new StringBuilder("");
                filterLevelText.Clear();
                return null;
            }

        }

        public bool IsCustomerVerified(AccountVerificationEditModel model)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where cp.Tag == model.Tag
                             select
                                 new
                                 {
                                     cp.CustomerId,
                                     u.FirstName,
                                     u.MiddleName,
                                     u.LastName,
                                     u.Email1,
                                     u.PhoneHome,
                                     u.Dob,
                                     cp.InsuranceId,
                                     u.Address.Zip.ZipCode
                                 });

                if (model.FirstNameVerification)
                    query = from q in query where q.FirstName == model.FirstName select q;


                if (model.LastNameVerification)
                    query = from q in query where q.LastName == model.LastName select q;


                if (model.DateOfBirthVerification)
                    query = from q in query where q.Dob.HasValue && q.Dob == model.DateOfBirth select q;


                if (model.CustomerEmailVerification)
                    query = from q in query where q.Email1 == model.CustomerEmail select q;


                if (model.MemberIdVerification)
                    query = from q in query where q.InsuranceId == model.MemberId select q;


                if (model.ZipCodeVerification)
                    query = from q in query where q.ZipCode == model.ZipCode select q;

                var isVerified = query.Count() == 1;

                if (isVerified)
                {
                    var customer = query.Single();
                    model.CustomerId = customer.CustomerId;
                }
                return isVerified;
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomerForFillEventCallQueue(List<OrderedPair<long, string>> eventIdZips, List<OrderedPair<string, string>> zipZipStringPairList)
        {
            var fromDate = DateTime.Now.Date.AddYears(-1);
            var completeCustomerList = new List<OrderedPair<long, long>>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                    join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                    join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                                    where e.EventDate > fromDate.Date
                                                          && ec.AppointmentId.HasValue
                                                          && !ec.NoShow
                                                    select ec.CustomerId).ToArray();

                var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                linqMetaData.CustomFunctionMappings.Add(mapping);
                mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                linqMetaData.CustomFunctionMappings.Add(mapping);

                foreach (var item in eventIdZips)
                {
                    var zipCodestring = zipZipStringPairList.Where(x => x.FirstValue == item.SecondValue).Select(x => x.SecondValue).FirstOrDefault() ?? item.SecondValue;

                    var customerIds = (from cp in linqMetaData.CustomerProfile
                                       where (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail) && cp.IsIncorrectPhoneNumber == false
                                       && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.Zip.ZipCode), zipCodestring) > 0
                                       select cp.CustomerId).Distinct().ToArray();

                    customerIds = customerIds.Where(cid => !alreadyRegisteredCustomerIds.Contains(cid)).Select(cid => cid).ToArray();

                    var eventId = item.FirstValue;
                    if (customerIds.Any())
                    {
                        customerIds = customerIds.Take(100).ToArray();
                        customerIds.ForEach(x => completeCustomerList.Add(new OrderedPair<long, long>(eventId, x)));
                    }

                }
            }
            return completeCustomerList.Distinct();
        }

        public bool UpdateDoNotCallStatus(long customerId, bool isRevertDoNotCall)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerProfileEntity(customerId)
                {
                    DoNotContactTypeId = isRevertDoNotCall ? (long?)null : (long)DoNotContactType.DoNotCall,
                    DoNotContactReasonId = isRevertDoNotCall ? (long?)null : (long)DoNotContactReason.CustomerRequest,
                    DoNotContactUpdateDate = isRevertDoNotCall ? (DateTime?)null : DateTime.Now
                };

                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0;
            }
        }

        public IEnumerable<long> GetCustomersByHealthPlanForCallRound(string healthPlanTag, int pastAppointmentDays, int roundOfCallCompleted, int lastCallDaysBefore)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerWithCallDetails = CallCenterCallRepository.CustomerHaveMoreRoundOfCallsInDays(linqMetaData, lastCallDaysBefore, roundOfCallCompleted);

                if (roundOfCallCompleted == 0)
                {
                    var customerIds = (from cp in linqMetaData.VwGetCustomersToGenerateCallQueue
                                       where !customerWithCallDetails.Contains(cp.CustomerId)
                                               && cp.Tag == healthPlanTag && cp.IsLanguageBarrier == false
                                       select cp.CustomerId).Distinct().ToArray();

                    return customerIds;
                }
                else
                {
                    var customerIds = (from cp in linqMetaData.VwGetCustomersToGenerateCallQueue
                                       where
                                               customerWithCallDetails.Contains(cp.CustomerId)
                                               && cp.Tag == healthPlanTag && cp.IsLanguageBarrier == false

                                       select cp.CustomerId).Distinct().ToArray();

                    return customerIds;
                }

            }
        }

        public IEnumerable<long> GetCustomersMarkedNoShowForHealthPlanCallQueue(string healthPlanTag, DateTime startDate, DateTime endDate)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var customerWithFutureAppointment = (from ec in linqMetaData.EventCustomers
                                                     join e in linqMetaData.Events on ec.EventId equals e.EventId
                                                     where ec.AppointmentId.HasValue && e.EventDate >= DateTime.Now.Date && !ec.NoShow
                                                     select ec.CustomerId);

                var customerInRefusedList = GetRefusedCustomer(linqMetaData);

                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);

                var customerIds = (from cp in linqMetaData.CustomerProfile
                                   join ec in linqMetaData.EventCustomers on cp.CustomerId equals ec.CustomerId
                                   join e in linqMetaData.Events on ec.EventId equals e.EventId
                                   where cp.Tag == healthPlanTag && (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail) && cp.IsIncorrectPhoneNumber == false && cp.IsLanguageBarrier == false
                                        && eligibleCustomerIds.Contains(cp.CustomerId)
                                        && ec.NoShow && e.EventDate >= startDate && e.EventDate <= endDate
                                        && !customerInRefusedList.Contains(cp.CustomerId) && !customerWithFutureAppointment.Contains(cp.CustomerId)
                                        && (cp.ActivityId != null && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall))
                                   select cp.CustomerId).Distinct().ToArray();

                return customerIds;
            }
        }

        public IEnumerable<OrderedPair<long, long>> GetCustomerForHealthPlanFillEventCallQueue(List<EventZipMammoModel> eventZipMammoListModel, string corporateTag, int radius, ILogger logger)
        {
            logger.Info("Executing CustomerRepository.GetCustomerForHealthPlanFillEventCallQueue");

            var completeCustomerList = new List<OrderedPair<long, long>>();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                foreach (var item in eventZipMammoListModel)
                {
                    logger.Info(string.Format("EventId: {0}, ZipId: {1}, Is Non Mammo: {2}", item.EventId, item.ZipId, item.IsNonMammoEvent));

                    var zipIds = (from zrd in linqMetaData.ZipRadiusDistance
                                  where zrd.SourceZipId == item.ZipId && zrd.Radius <= radius
                                  select zrd.DestinationZipId);

                    var productList = _eventProductTypeRepository.GetProductTypeByEventId(item.EventId);

                   // var customerIdwithProduct = linqMetaData.CustomerProfile.Where(x => productList.Contains(x.ProductTypeId.Value)).Select(x => x.CustomerId).ToArray();

                    var customerIds = (from cp in linqMetaData.VwGetCustomersToGenerateFillEventCallQueue
                                      // join cup in linqMetaData.CustomerProfile on cp.CustomerId equals cup.CustomerId
                                       where cp.Tag == corporateTag && (cp.IsLanguageBarrier == false || (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate < startOfYear))
                                      && zipIds.Contains(cp.ZipId) && (cp.IsMammoPatient || cp.IsMammoPatient == !item.IsNonMammoEvent)
                                      && productList.Contains(cp.ProductTypeId)
                                       select cp.CustomerId).Distinct().ToArray();

                    logger.Info("Customer Count: " + customerIds.Count());

                    var eventId = item.EventId;

                    if (customerIds.Any())
                    {
                        customerIds.ForEach(x => completeCustomerList.Add(new OrderedPair<long, long>(eventId, x)));
                    }
                }
            }

            logger.Info("Execution completed CustomerRepository.GetCustomerForHealthPlanFillEventCallQueue");
            return completeCustomerList.Distinct();
        }

        public IEnumerable<long> GetCustomersZipCodeRadiusCallQueue(string healthPlanTag, string zipCode, int radius, int pastAppointmentDays)
        {
            var zipcodeRepository = new ZipCodeRepository();
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var zipInRange = zipcodeRepository.GetZipCodesInRadius(zipCode, radius);

                var zipCodesInRange = zipInRange != null ? zipInRange.Select(zcir => zcir.Id).ToList() : null;

                if (!(zipCodesInRange == null || zipCodesInRange.IsEmpty()))
                {
                    var mapping = new FunctionMapping(this.GetType(), "IndexOf", 2, " charindex({0}, {1})");
                    if (linqMetaData.CustomFunctionMappings == null) linqMetaData.CustomFunctionMappings = new FunctionMappingStore();
                    linqMetaData.CustomFunctionMappings.Add(mapping);
                    mapping = new FunctionMapping(typeof(Convert), "ToString", 1, "',' + Convert(varchar, {0}) + ','");
                    linqMetaData.CustomFunctionMappings.Add(mapping);

                    string zipIdstring = "," + string.Join(",", zipCodesInRange) + ",";

                    var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                        join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                        join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                                        where e.EventDate > DateTime.Now.Date.AddDays(-pastAppointmentDays)
                                                              && ec.AppointmentId.HasValue && (cp.Tag == healthPlanTag)
                                                        select ec.CustomerId);

                    var refusedCustomers = GetRefusedCustomer(linqMetaData);
                    var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);

                    var customerIds = (from cp in linqMetaData.CustomerProfile
                                       where (cp.Tag == healthPlanTag)
                                            && eligibleCustomerIds.Contains(cp.CustomerId) && (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail) && cp.IsIncorrectPhoneNumber == false
                                            && cp.IsLanguageBarrier == false
                                            && IndexOf(Convert.ToString(cp.OrganizationRoleUser.User.Address.ZipId), zipIdstring) > 0
                                            && !alreadyRegisteredCustomerIds.Contains(cp.CustomerId) && !refusedCustomers.Contains(cp.CustomerId)
                                            && (cp.ActivityId != null && (cp.ActivityId == (long)UploadActivityType.OnlyCall || cp.ActivityId == (long)UploadActivityType.BothMailAndCall))
                                       orderby cp.CustomerId
                                       select cp.CustomerId).Distinct().ToArray();

                    return customerIds;
                }
                return null;
            }
        }

        private IQueryable<long> GetRefusedCustomer(LinqMetaData linqMetaData)
        {
            var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
            var doNotContact = ProspectCustomerTag.DoNotCall.ToString();
            var deceased = ProspectCustomerTag.Deceased.ToString();
            var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
            var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
            var customerContactedThisYear = new DateTime(DateTime.Today.Year, 1, 1);
            var query = (from pc in linqMetaData.ProspectCustomer
                         where pc.CustomerId != null &&
                              ((pc.Tag == deceased) || ((pc.TagUpdateDate.HasValue && pc.TagUpdateDate.Value >= customerContactedThisYear) && (pc.Tag == homeVisitRequested || pc.Tag == doNotContact || pc.Tag == mobilityIssue || pc.Tag == inLongTermCareNursingHome)))
                         select pc.CustomerId.Value);

            return query;
        }

        public IEnumerable<Customer> GetHealthPlanIncorrectPhoneCustomerExport(HealthPlanCustomerIncorrectPhoneExportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             where cp.Tag == filter.CorporateTag
                              && cp.IsIncorrectPhoneNumber && cp.IncorrectPhoneNumberMarkedDate >= filter.StartDate
                             select cp);

                if (filter.EndDate.HasValue)
                {
                    var endDate = filter.EndDate.Value.AddDays(1);
                    query = (from q in query where q.IncorrectPhoneNumberMarkedDate < endDate select q);
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                    if (filter.ExcludeCustomerWithCustomTag)
                    {
                        query = (from q in query where !customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                    else
                    {
                        query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                }

                var customerIdQuery = query.OrderBy(x => x.CustomerId).Select(q => q.CustomerId).Distinct();

                totalRecords = customerIdQuery.Count();

                if (totalRecords < 1)
                    return null;

                var customerIds = customerIdQuery.TakePage(pageNumber, pageSize).ToArray();

                return GetCustomers(customerIds);
            }
        }

        public IEnumerable<Customer> HealthPlanHomeVisitRequestedCustomerExport(HealthPlanCustomerExportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             join c in linqMetaData.Calls on cp.CustomerId equals c.CalledCustomerId
                             where cp.Tag == filter.CorporateTag && c.Status == (long)filter.CallStatus
                             && (c.OutBound.HasValue && c.OutBound.Value) && c.Disposition == filter.Tag.ToString()
                             && c.DateCreated >= filter.StartDate
                             select cp);

                if (filter.EndDate.HasValue)
                {
                    var endDate = filter.EndDate.Value.AddDays(1);
                    query = (from q in query where q.DateCreated < endDate select q);
                }

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);

                    if (filter.ExcludeCustomerWithCustomTag)
                    {
                        query = (from q in query where !customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                    else
                    {
                        query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                    }
                }

                var customerIdQuery = query.OrderBy(x => x.CustomerId).Select(q => q.CustomerId).Distinct();

                totalRecords = customerIdQuery.Count();

                if (totalRecords < 1)
                    return null;

                var customerIds = customerIdQuery.TakePage(pageNumber, pageSize).ToArray();

                return GetCustomers(customerIds);
            }
        }

        public IEnumerable<long> GetHealthPlanUncontactedCustomers(string healthPlanTag, int neverBeenCalledInDays, int noPastAppointmentInDays)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var alreadyCalledCustomes = AlreadyCalledCustomes(neverBeenCalledInDays, linqMetaData);

                var customerIds = (from cp in linqMetaData.VwGetCustomersToGenerateCallQueue
                                   where cp.Tag == healthPlanTag
                                        && !alreadyCalledCustomes.Contains(cp.CustomerId)
                                        && cp.IsLanguageBarrier == false
                                   orderby cp.CustomerId
                                   select cp.CustomerId).Distinct().ToArray();

                return customerIds;
            }
        }

        private IQueryable<long> AlreadyCalledCustomes(int neverBeenCalledInDays, LinqMetaData linqMetaData)
        {
            var alreadyCalledCustomes = (from c in linqMetaData.VwGetCallsForCallQueue
                                         where c.CalledCustomerId > 0 &&
                                             (c.DateCreated > DateTime.Now.Date.AddDays(-neverBeenCalledInDays) && c.Status != (long)CallStatus.CallSkipped)
                                         select c.CalledCustomerId);

            return alreadyCalledCustomes;
        }

        private IQueryable<long> AlreadyRegisteredCustomerIds(string healthPlanTag, int noPastAppointmentInDays, LinqMetaData linqMetaData)
        {
            var alreadyRegisteredCustomerIds = (from e in linqMetaData.Events
                                                join ec in linqMetaData.EventCustomers on e.EventId equals ec.EventId
                                                join cp in linqMetaData.CustomerProfile on ec.CustomerId equals cp.CustomerId
                                                where e.EventDate > DateTime.Now.Date.AddDays(-noPastAppointmentInDays)
                                                      && ec.AppointmentId.HasValue
                                                      && (cp.Tag == healthPlanTag)
                                                select ec.CustomerId);
            return alreadyRegisteredCustomerIds;
        }

        public IEnumerable<Customer> GetUncontactedCustomers(UncontactedCustomersReportModelFilter filter, int pageNumber, int pageSize, int neverBeenCalledInDays, int noPastAppointmentInDays, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null || filter.HelathPlanId == null)
                {
                    totalRecords = 0;
                    return null;
                }

                string healthPlanTag = (from ct in linqMetaData.Account where ct.AccountId == filter.HelathPlanId.Value select ct.Tag).First();

                var alreadyRegisteredCustomerIds = AlreadyRegisteredCustomerIds(healthPlanTag, noPastAppointmentInDays, linqMetaData);

                var alreadyCalledCustomes = AlreadyCalledCustomes(neverBeenCalledInDays, linqMetaData);

                var refusedCustomers = GetRefusedCustomer(linqMetaData);

                var query = (from cp in linqMetaData.CustomerProfile
                             where
                                  cp.DoNotContactReasonNotesId == null && (cp.DoNotContactTypeId == null || cp.DoNotContactTypeId.Value == (long)DoNotContactType.DoNotMail) && cp.IsIncorrectPhoneNumber == false && cp.IsLanguageBarrier == false
                                  && !alreadyRegisteredCustomerIds.Contains(cp.CustomerId)
                                  && !alreadyCalledCustomes.Contains(cp.CustomerId)
                                  && !refusedCustomers.Contains(cp.CustomerId)
                                  && cp.Tag == healthPlanTag
                             select cp);

                if (filter.CustomTags != null && filter.CustomTags.Any())
                {

                    var customTags = string.Join(",", filter.CustomTags);
                    customTags = "," + customTags + ",";

                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where ct.IsActive && customTags.IndexOf("," + ct.Tag + ",") >= 0
                                                select ct.CustomerId);

                    query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                }

                if (filter.EligibleStatus == EligibleFilterStatus.OnlyEligible)
                {
                    var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                    query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                }
                else if (filter.EligibleStatus == EligibleFilterStatus.NotEligible)
                {
                    var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value == false && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                    query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                }
                else if (filter.EligibleStatus == EligibleFilterStatus.NotMentioned)
                {
                    var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible == null && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                    query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                }

                totalRecords = query.Count();

                if (totalRecords < 1)
                    return null;


                var customers = query.OrderByDescending(c => c.DateCreated).TakePage(pageNumber, pageSize).ToList();

                var customersId = (from c in customers select c.CustomerId);

                return GetCustomers(customersId.ToArray()).OrderByDescending(x => x.DateCreated);
            }
        }

        public bool UpdateIsIncorrectPhoneNumber(long customerId, bool isIncorrectPhoneNumber)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerProfileEntity(customerId)
                {
                    IsIncorrectPhoneNumber = isIncorrectPhoneNumber
                };
                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0;
            }
        }

        public IEnumerable<long> GetCustomersByHealthPlanForMailRound(string healthPlanTag, string customTags, long campaignId, long criteriaId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var directMailDates = (from hpcdm in linqMetaData.HealthPlanCriteriaDirectMail
                                       join ca in linqMetaData.CampaignActivity on hpcdm.CampaignActivityId equals ca.Id
                                       where hpcdm.CriteriaId == criteriaId
                                       select ca.ActivityDate);

                var mailedCustomers = (from dm in linqMetaData.VwGetDirectMailForCallQueue
                                       where directMailDates.Contains(dm.MailDate) && dm.MailDate < DateTime.Today.Date.AddDays(1)
                                           && dm.CampaignId > 0 && dm.CampaignId == campaignId
                                       select dm.CustomerId);

                customTags = "," + customTags + ",";
                var customTagCustomerIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.IndexOf("," + ct.Tag + ",") >= 0 select ct.CustomerId);

                var customerIds = (from cp in linqMetaData.VwGetCustomerForMailRoundInsertion
                                   where cp.Tag == healthPlanTag && mailedCustomers.Contains(cp.CustomerId) && customTagCustomerIds.Contains(cp.CustomerId)
                                   select cp.CustomerId).Distinct().ToArray();

                return customerIds;

            }
        }

        public bool UpdateIsLanguageBarrier(long customerId, bool isLanguageBarrier)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerProfileEntity(customerId)
                {
                    IsLanguageBarrier = isLanguageBarrier
                };

                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);

                return adapter.UpdateEntitiesDirectly(entity, bucket) > 0;
            }
        }

        public IEnumerable<long> GetHealthPlanLanguageBarrierCustomers(string healthPlanTag, int noPastAppointmentInDays)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var startOfYear = new DateTime(DateTime.Today.Year, 1, 1);

                var customerIds = (from cp in linqMetaData.VwGetCustomersToGenerateCallQueue
                                   where (cp.Tag == healthPlanTag) && (cp.IsLanguageBarrier && cp.LanguageBarrierMarkedDate >= startOfYear)
                                   orderby cp.CustomerId
                                   select cp.CustomerId).Distinct().ToArray();

                return customerIds;
            }
        }

        public IEnumerable<Customer> GetMemberForReport(int pageNumber, int pageSize, MemberStatusListModelFilter filter,
            out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                IEnumerable<long> customerIds;
                if (filter != null && (!string.IsNullOrEmpty(filter.FirstName) || !string.IsNullOrEmpty(filter.LastName) || !string.IsNullOrEmpty(filter.Tag)
                     || filter.CustomerId > 0 || filter.IsAttendedCustomers || filter.IsNotAttendedCustomers || filter.IsPublicEvent || filter.IsPrivateEvent
                     || (filter.CustomTags != null && filter.CustomTags.Any()) || !string.IsNullOrWhiteSpace(filter.MemberId) || !filter.IncludeDoNotContact ||
                     !filter.DoNotContactOnly || filter.EligibleStatus != EligibleFilterStatus.All || filter.TargetMemberStatus != TargetMemberFilterStatus.All))
                {
                    var query = (from cp in linqMetaData.CustomerProfile
                                 where !cp.DoNotContactReasonId.HasValue && cp.Tag != null && cp.Tag != ""
                                 select cp);
                   
                    if (filter.IncludeDoNotContact)
                    {
                        query = (from cp in linqMetaData.CustomerProfile select cp);
                    }

                    if (filter.DoNotContactOnly)
                    {
                        query = (from cp in linqMetaData.CustomerProfile where cp.DoNotContactReasonId.HasValue select cp);
                    }

                    if (filter.ProductTypeId > 0)
                    {
                        query = query.Where(q => q.ProductTypeId == filter.ProductTypeId);

                    }

                    if (filter.EligibleStatus == EligibleFilterStatus.OnlyEligible)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value && ce.ForYear == filter.FromDate.Year select ce.CustomerId;

                        //Consider Eligibility From History only set for Wellmed Account
                        if (!string.IsNullOrWhiteSpace(filter.Tag) && filter.ConsiderEligibiltyFromHistory)
                        {
                            var customerIdEligibilityFromHistory = (from cph in linqMetaData.CustomerProfileHistory
                                                                    where cph.Tag == filter.Tag && cph.IsEligble != null && cph.IsEligble.Value && cph.EligibilityForYear == filter.Year
                                                                    select cph.CustomerId).Distinct();
                            query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) || customerIdEligibilityFromHistory.Contains(cp.CustomerId) select cp);
                        }
                        else
                        {
                            query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                        }
                    }
                    else if (filter.EligibleStatus == EligibleFilterStatus.NotEligible)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value == false && ce.ForYear == filter.FromDate.Year select ce.CustomerId;
                        query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                    }
                    else if (filter.EligibleStatus == EligibleFilterStatus.NotMentioned)
                    {
                        var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible == null && ce.ForYear == filter.FromDate.Year select ce.CustomerId;
                        query = (from cp in query where customerIdFromEligibility.Contains(cp.CustomerId) select cp);
                    }

                    if (filter.TargetMemberStatus == TargetMemberFilterStatus.Targeted)
                    {
                        var customerIdsFromTargeted = from ce in linqMetaData.CustomerTargeted where ce.IsTargated.HasValue && ce.IsTargated.Value == true && ce.ForYear == filter.FromDate.Year select ce.CustomerId;
                        query = (from cp in query where customerIdsFromTargeted.Contains(cp.CustomerId) select cp);
                    }
                    else if (filter.TargetMemberStatus == TargetMemberFilterStatus.NonTargeted)
                    {
                        var customerIdsFromTargeted = from ce in linqMetaData.CustomerTargeted where ce.IsTargated.HasValue && ce.IsTargated.Value == false && ce.ForYear == filter.FromDate.Year select ce.CustomerId;
                        query = (from cp in query where customerIdsFromTargeted.Contains(cp.CustomerId) select cp);
                    }
                    else if (filter.TargetMemberStatus == TargetMemberFilterStatus.NotMentioned)
                    {
                        var customerIdsFromTargeted = from ce in linqMetaData.CustomerTargeted where !ce.IsTargated.HasValue && ce.ForYear == filter.FromDate.Year select ce.CustomerId;
                        query = (from cp in query where customerIdsFromTargeted.Contains(cp.CustomerId) select cp);
                    }



                    if (filter.CustomerId > 0)
                    {
                        query = query.Where(q => q.CustomerId == filter.CustomerId);
                    }
                    else if (!string.IsNullOrWhiteSpace(filter.MemberId))
                    {
                        query = query.Where(q => q.InsuranceId != null && q.InsuranceId.Trim() == filter.MemberId.Trim());
                    }
                    else
                    {
                        if (filter.HealthPlanId > 0)
                        {
                            var account = (from a in linqMetaData.Account where a.AccountId == filter.HealthPlanId select a).SingleOrDefault();
                            if (account != null && !string.IsNullOrEmpty(account.Tag))
                            {
                                query = query.Where(q => q.Tag == account.Tag);
                            }
                        }

                        if (!string.IsNullOrEmpty(filter.Tag))
                        {
                            query = query.Where(q => q.Tag == filter.Tag);
                        }

                        if (!string.IsNullOrEmpty(filter.FirstName) || !string.IsNullOrEmpty(filter.LastName))
                        {
                            var firstName = !string.IsNullOrEmpty(filter.FirstName) ? filter.FirstName : "";
                            var lastName = !string.IsNullOrEmpty(filter.LastName) ? filter.LastName : "";
                            query = (from q in query
                                     join org in linqMetaData.OrganizationRoleUser on q.CustomerId equals
                                         org.OrganizationRoleUserId
                                     join u in linqMetaData.User on org.UserId equals u.UserId
                                     where
                                         (firstName.Trim().Length > 0
                                             ? u.FirstName.StartsWith(firstName.Trim(),
                                                 StringComparison.InvariantCultureIgnoreCase)
                                             : true)
                                         &&
                                         (lastName.Trim().Length > 0
                                             ? u.LastName.StartsWith(lastName.Trim(),
                                                 StringComparison.InvariantCultureIgnoreCase)
                                             : true)
                                     select q);
                        }

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {
                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                        where ct.IsActive && filter.CustomTags.Contains(ct.Tag)
                                                        select ct.CustomerId);
                            query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                        }


                        if (filter.IsAttendedCustomers || filter.IsPublicEvent || filter.IsPrivateEvent)
                        {

                            var eventQuery = (from ec in linqMetaData.EventCustomers
                                              join e in linqMetaData.Events on ec.EventId equals e.EventId
                                              select
                                                  new { ec.EventCustomerId, ec.CustomerId, ec.EventId, ec.AppointmentId, e.EventTypeId });

                            var queryForEcs = (from q in query
                                               join ec in eventQuery on q.CustomerId equals ec.CustomerId
                                                   into ecQuery
                                               from e in ecQuery.DefaultIfEmpty()
                                               select new { q, e.EventCustomerId, e.EventId, e.AppointmentId, e.EventTypeId });

                            if (filter.IsAttendedCustomers && !filter.IsNotAttendedCustomers)
                            {
                                queryForEcs =
                                    queryForEcs.Where(q => q.EventCustomerId != null && q.AppointmentId != null);
                            }

                            if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                            }
                            else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                            {
                                queryForEcs = queryForEcs.Where(q => q.EventTypeId == (long)RegistrationMode.Private);
                            }

                            query = (from qec in queryForEcs select qec.q);
                        }
                        else if (!filter.IsAttendedCustomers && filter.IsNotAttendedCustomers)
                        {
                            var attendedCustomerIds = (from ec in linqMetaData.EventCustomers
                                                       where ec.AppointmentId.HasValue
                                                       select ec.CustomerId);

                            query = (from q in query where !attendedCustomerIds.Contains(q.CustomerId) select q);
                        }

                    }

                    //var queryforCustomer = (from q in query orderby q.DateCreated, q.CustomerId select q.CustomerId).Distinct().Select(s => s);

                    var queryforCustomer = (from q in query select q.CustomerId).Distinct().Select(s => s);
                    var tempQuery = (from q in queryforCustomer
                                     join c in linqMetaData.CustomerProfile on q equals c.CustomerId
                                     orderby c.DateCreated, c.CustomerId
                                     select c.CustomerId);

                    totalRecords = queryforCustomer.Count();

                    if (totalRecords < 1)
                        return null;

                    customerIds = tempQuery.TakePage(pageNumber, pageSize).ToArray();
                    return GetCustomers(customerIds.ToArray()).OrderBy(c => c.DateCreated).ThenBy(c => c.CustomerId);
                }
                else
                {
                    var query = (from cp in linqMetaData.CustomerProfile
                                 where !cp.DoNotContactReasonId.HasValue && cp.Tag != null && cp.Tag != ""
                                 orderby cp.DateCreated descending, cp.CustomerId
                                 select cp.CustomerId);

                    totalRecords = query.Count();

                    if (totalRecords < 1)
                        return null;

                    customerIds = query.TakePage(pageNumber, pageSize).ToArray();

                    return
                        GetCustomers(customerIds.ToArray())
                            .OrderByDescending(c => c.DateCreated)
                            .ThenBy(c => c.CustomerId);
                }
            }
        }

        public CorporateAccountMemberStatusViewModel GetMemberStatusForAccountCoordinatorDashboard(long accountId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (accountId > 0)
                {
                    var query = (from ea in linqMetaData.EventAccount
                                 where ea.AccountId == accountId
                                 select ea.Events.EventId);

                    var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility
                                               where !ce.IsEligible.HasValue || ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year
                                               select ce.CustomerId);

                    var eligibleCustomers = (from cp in linqMetaData.CustomerProfile
                                             join ec in linqMetaData.EventCustomers on cp.CustomerId equals ec.CustomerId
                                             where eligibleCustomerIds.Contains(cp.CustomerId)/*!cp.IsEligble.HasValue || cp.IsEligble.Value*/
                                             && query.Contains(ec.EventId)
                                             select cp);

                    var membersTested = (from ec in linqMetaData.EventCustomers
                                         join ecr in linqMetaData.EventCustomerResult on ec.CustomerId equals ecr.CustomerId
                                         where !ec.NoShow && ec.LeftWithoutScreeningReasonId == null && ec.AppointmentId != null
                                         && query.Contains(ec.EventId)
                                         select ec);

                    var membersScheduled = (from ec in linqMetaData.EventCustomers
                                            join ecr in linqMetaData.EventCustomerResult on ec.CustomerId equals ecr.CustomerId
                                            where query.Contains(ec.EventId) && ec.AppointmentId != null
                                            select ec);

                    var membersCancelled = (from ec in linqMetaData.EventCustomers
                                            join ecr in linqMetaData.EventCustomerResult on ec.CustomerId equals ecr.CustomerId
                                            where ec.AppointmentId == null
                                            && query.Contains(ec.EventId)
                                            select ec);

                    var membersNoShowed = (from ec in linqMetaData.EventCustomers
                                           join ecr in linqMetaData.EventCustomerResult on ec.CustomerId equals ecr.CustomerId
                                           where ec.AppointmentId != null && ec.NoShow && query.Contains(ec.EventId)
                                           select ec);

                    return new CorporateAccountMemberStatusViewModel
                    {
                        EligibleCustomersCount = eligibleCustomers.Count(),
                        MembersTestedCount = membersTested.Count(),
                        MembersScheduledCount = membersScheduled.Count(),
                        MembersCancelledCount = membersCancelled.Count(),
                        MembersNoShowedCount = membersNoShowed.Count()
                    };
                }

                return new CorporateAccountMemberStatusViewModel();
            }
        }

        public IEnumerable<long> GetCustomerIdByInsuranceId(string insuranceId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEntity = linqMetaData.CustomerProfile.WithPath(
                    prefetchPath => prefetchPath.Prefetch(cp => cp.OrganizationRoleUser)).Where(
                        cp => cp.InsuranceId == insuranceId).ToList();

                return customerEntity.Any() ? customerEntity.Select(x => x.CustomerId) : null;
            }
        }

        public Customer GetCustomerForOutboundImport(string firstName, string middleName, string lastName, string email, string phoneNumber, DateTime? dob, string memberId, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where cp.Tag == tag
                             select new { cp.CustomerId, u.FirstName, u.MiddleName, u.LastName, u.Email1, u.PhoneHome, cp.InsuranceId, u.Dob });

                if (!string.IsNullOrEmpty(memberId) && dob.HasValue)
                {
                    query = (from q in query
                             where q.InsuranceId == memberId && q.Dob == dob
                             select q);
                }
                else
                {
                    var name = firstName + (middleName.Length > 0 ? " " + middleName + " " : " ") + lastName;

                    query = from q in query
                            where (q.FirstName + (q.MiddleName.Length > 0 ? " " + q.MiddleName + " " : " ") + q.LastName).Contains(name)
                            select q;
                    if (!string.IsNullOrEmpty(email))
                    {
                        query = from q in query where q.Email1 == email select q;
                    }
                    else if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        query = from q in query where q.PhoneHome == phoneNumber select q;
                    }
                    else if (!string.IsNullOrEmpty(memberId))
                    {
                        query = from q in query where q.InsuranceId == memberId select q;
                    }
                }

                var entity = (from q in query select q).FirstOrDefault();

                if (entity == null)
                    return null;
                return GetCustomer(entity.CustomerId);
            }
        }

        public IEnumerable<long> GetCustomerForMedicareSync(DateTime fromDate, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);
                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);
                var query = (from cp in linqMetaData.CustomerProfile
                             join ec in linqMetaData.EventCustomers
                             on cp.CustomerId equals ec.CustomerId
                             join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             where ec.AppointmentId.HasValue && cp.Tag == tag && eligibleCustomerIds.Contains(cp.CustomerId) && (cp.DateCreated >= fromDate || cp.DateModified >= fromDate)
                             select cp.CustomerId).Distinct().ToArray();
                return query;
            }
        }

        public IEnumerable<long> GetCustomerForMedicareSyncWithoutVisit(DateTime fromDate, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);
                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);
                var query = (from cp in linqMetaData.CustomerProfile
                             join ec in linqMetaData.EventCustomers
                             on cp.CustomerId equals ec.CustomerId
                             join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             where !ec.AwvVisitId.HasValue && ec.AppointmentId.HasValue && cp.Tag == tag && eligibleCustomerIds.Contains(cp.CustomerId)
                             && (cp.DateCreated >= fromDate || cp.DateModified >= fromDate)
                             select cp.CustomerId).Distinct().ToArray();
                return query;
            }
        }

        private IEnumerable<string> GetRefusalTag()
        {
            var homeVisitRequested = ProspectCustomerTag.HomeVisitRequested.ToString();
            var doNotContact = ProspectCustomerTag.DoNotCall.ToString();
            var deceased = ProspectCustomerTag.Deceased.ToString();
            var mobilityIssue = ProspectCustomerTag.MobilityIssue.ToString();
            var inLongTermCareNursingHome = ProspectCustomerTag.InLongTermCareNursingHome.ToString();
            var mobilityIssue_LeftMessageWithOther = ProspectCustomerTag.MobilityIssues_LeftMessageWithOther.ToString();
            var noLongeronInsuracnePlan = ProspectCustomerTag.NoLongeronInsurancePlan.ToString();
            var debilitatingDisease = ProspectCustomerTag.DebilitatingDisease.ToString();

            string[] refusalTag = { homeVisitRequested, doNotContact, deceased, mobilityIssue, inLongTermCareNursingHome, mobilityIssue_LeftMessageWithOther, noLongeronInsuracnePlan, debilitatingDisease };
            //return query;
            return refusalTag;
        }

        public IEnumerable<Customer> GetCallQueueExcludedCustomers(CallQueueExcludedCustomerReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var firstDayOfYear = new DateTime(DateTime.Today.Year, 1, 1);
                var maxAttempt = 0;
                var isHealthPlanLevelAttempt = false;
                var account = (from a in linqMetaData.Account where a.AccountId == filter.HealthPlanId select a).First();
                var critera = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria where hpcqc.HealthPlanId == filter.HealthPlanId select hpcqc).First();

                if (filter.CampaignId > 0)
                {
                    if (account.IsMaxAttemptPerHealthPlan)
                    {
                        isHealthPlanLevelAttempt = true;
                        maxAttempt = account.MaxAttempt.Value;
                    }


                    critera = (from hpcqc in linqMetaData.HealthPlanCallQueueCriteria where hpcqc.CampaignId == filter.CampaignId select hpcqc).First();

                    var callQueueSetting = (from acqs in linqMetaData.AccountCallQueueSetting
                                            where acqs.AccountId == filter.HealthPlanId && acqs.CallQueueId == critera.CallQueueId
                                            select acqs);

                    var othersDays = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.Others)).NoOfDays;
                    var leftVoiceMail = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.LeftVoiceMail)).NoOfDays;
                    var refuseCustomer = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.RefuseCustomer)).NoOfDays;

                    var refusalTags = GetRefusalTag();
                    var eventZip = (from aez in linqMetaData.AccountEventZip where aez.AccountId == filter.HealthPlanId select aez.ZipId);
                    var substituteEventZip = (from aezs in linqMetaData.AccountEventZipSubstitute where aezs.AccountId == filter.HealthPlanId select aezs.ZipId);

                    if (!isHealthPlanLevelAttempt)
                        maxAttempt = (callQueueSetting.First(x => x.SuppressionTypeId == (int)CallQueueSuppressionType.MaxAttempts)).NoOfDays;

                    var othersFilterDate = DateTime.Today.AddDays(-(othersDays - 1));
                    var leftVoiceMailDate = DateTime.Today.AddDays(-(leftVoiceMail - 1));
                    var refusalDate = DateTime.Today.AddDays(-(refuseCustomer - 1));

                    var notInterested = ProspectCustomerTag.NotInterested.ToString();
                    var recentlySawDoc = ProspectCustomerTag.RecentlySawDoc.ToString();
                    var transportationIssue = ProspectCustomerTag.TransportationIssue.ToString();
                    var declinedMammoNotinterestedInMammogram = ProspectCustomerTag.DeclinedMammoNotinterestedInMammogram.ToString();

                    var regectedCustomerQuery = ((from cqc in linqMetaData.VwCallQueueCustomerCriteraAssignmentForStats
                                                  where cqc.HealthPlanId == filter.HealthPlanId
                                                        && cqc.CampaignId == filter.CampaignId &&
                                                        ((isHealthPlanLevelAttempt ? cqc.CallCount >= maxAttempt : cqc.Attempts >= maxAttempt)
                                                         ||
                                                         (cqc.IsEligble == false)
                                                         || (cqc.TargetedYear != DateTime.Today.Year || cqc.IsTargeted == false)
                                                         || (cqc.IsIncorrectPhoneNumber && cqc.IncorrectPhoneNumberMarkedDate >= firstDayOfYear)
                                                         || (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                                                      //(
                                                      // (
                                                      //     (cqc.DoNotContactUpdateDate > firstDayOfYear && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall))
                                                      //     ||
                                                      //     (cqc.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail)
                                                      //  )
                                                      // )
                                                         || (
                                                             (cqc.ActivityId == (long)UploadActivityType.MailOnly)
                                                             )
                                                         || (
                                                             ((cqc.PhoneCell == "") && (cqc.PhoneHome == "") && (cqc.PhoneOffice == ""))
                                                             )
                                                         || (
                                                             (cqc.AppointmentDate >= firstDayOfYear)
                                                             )
                                                         || (
                                                                cqc.Disposition == ProspectCustomerTag.Deceased.ToString() || (cqc.ContactedDate >= firstDayOfYear && refusalTags.Contains(cqc.Disposition))
                                                             )
                                                         || (cqc.Disposition == ProspectCustomerTag.CallBackLater.ToString() && cqc.CallBackRequestedDate > DateTime.Now)
                                                         || (!(eventZip.Contains(cqc.ZipId) || substituteEventZip.Contains(cqc.ZipId)))
                                                         || (cqc.IsLanguageBarrier && cqc.LanguageBarrierMarkedDate >= firstDayOfYear)
                                                         || (cqc.AppointmentCancellationDate >= othersFilterDate
                                                                || (cqc.NoShowDate >= othersFilterDate || cqc.AppointmentDate > new DateTime(1900, 1, 1))
                                                                || (cqc.ContactedDate >= leftVoiceMailDate && cqc.CallStatus == (long)CallStatus.VoiceMessage)
                                                                || (
                                                                    cqc.ContactedDate >= refusalDate &&
                                                                        (cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.VoiceMessage)
                                                                        && (
                                                                                cqc.Disposition == notInterested || cqc.Disposition == recentlySawDoc || cqc.Disposition == transportationIssue || cqc.Disposition == declinedMammoNotinterestedInMammogram
                                                                            )
                                                                    )
                                                                || (cqc.ContactedDate >= othersFilterDate && cqc.CallStatus != (long)CallStatus.CallSkipped && cqc.CallStatus != (long)CallStatus.Initiated && (cqc.Disposition != ProspectCustomerTag.CallBackLater.ToString() && cqc.Disposition != (ProspectCustomerTag.LanguageBarrier.ToString())))
                                                                || (cqc.ContactedDate >= DateTime.Today && (cqc.CallStatus == (long)CallStatus.CallSkipped || cqc.CallStatus == (long)CallStatus.Initiated))
                                                            )
                                                    )

                                                  select cqc));

                    var customerQuery = (from cp in linqMetaData.CustomerProfile select cp);

                    if (filter.CustomerId.HasValue && filter.CustomerId.Value > 0)
                    {
                        regectedCustomerQuery = (from q in regectedCustomerQuery where q.CustomerId == filter.CustomerId select q);
                    }
                    else if (!string.IsNullOrEmpty(filter.MemberId))
                    {
                        customerQuery = (from q in customerQuery where q.InsuranceId == filter.MemberId select q);
                    }
                    else
                    {

                        if (filter.BookedAppointment)
                        {
                            regectedCustomerQuery = (from q in regectedCustomerQuery where (q.AppointmentDate >= firstDayOfYear) select q);
                        }

                        if (!string.IsNullOrEmpty(filter.ZipCode))
                        {
                            regectedCustomerQuery = (from q in regectedCustomerQuery where (q.ZipCode == filter.ZipCode) select q);
                        }

                        if (filter.IsEligible)
                        {
                            var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ce.IsEligible != null && ce.IsEligible.Value == false && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                            regectedCustomerQuery = (from q in regectedCustomerQuery where customerIdFromEligibility.Contains(q.CustomerId) select q);
                        }

                        if (filter.InCorrectPhoneNumber)
                        {
                            regectedCustomerQuery = (from q in regectedCustomerQuery
                                                     where (q.IsIncorrectPhoneNumber == filter.InCorrectPhoneNumber && q.IncorrectPhoneNumberMarkedDate > firstDayOfYear)
                                                     select q);
                        }

                        if (filter.DoNotContact)
                        {
                            //regectedCustomerQuery = (regectedCustomerQuery.Where(cqc => (
                            //    (
                            //        cqc.DoNotContactUpdateDate > firstDayOfYear && (cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall)
                            //    )
                            //    || (cqc.DoNotContactUpdateSource == (long)DoNotContactSource.Manual && cqc.DoNotContactTypeId != (long)DoNotContactType.DoNotMail)
                            //    )));

                            regectedCustomerQuery = regectedCustomerQuery.Where(cqc => cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotContact || cqc.DoNotContactTypeId == (long)DoNotContactType.DoNotCall);
                        }

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {

                            var customTags = string.Join(",", filter.CustomTags);
                            customTags = "," + customTags + ",";

                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag where ct.IsActive && customTags.IndexOf("," + ct.Tag + ",") >= 0 select ct.CustomerId);

                            regectedCustomerQuery = (from q in regectedCustomerQuery where customTagCustomerIds.Contains(q.CustomerId) select q);
                        }

                        if (filter.DirectMailDate.HasValue)
                        {
                            var mailedCustomerIds = (from dm in linqMetaData.VwGetDirectMailForCallQueue
                                                     where
                                                         dm.CampaignId == filter.CampaignId && dm.MailDate >= filter.DirectMailDate.Value &&
                                                         dm.MailDate < filter.DirectMailDate.Value.AddDays(1)
                                                     select dm.CustomerId);

                            regectedCustomerQuery = (from q in regectedCustomerQuery where mailedCustomerIds.Contains(q.CustomerId) select q);
                        }
                    }

                    var rejectedCustomerIds = (from rcq in regectedCustomerQuery select rcq.CustomerId);

                    customerQuery =
                        customerQuery.Where(r => rejectedCustomerIds.Contains(r.CustomerId)).OrderBy(x => x.CustomerId);

                    totalRecords = customerQuery.Count();

                    var customers = customerQuery.TakePage(pageNumber, pageSize).ToList();

                    var customerIds = (from c in customers select c.CustomerId).ToArray();

                    if (customerIds.Any())
                        return GetCustomers(customerIds.ToArray());
                    return null;
                }
                else
                {
                    var eventCustomers = (from ec in linqMetaData.EventCustomers
                                          join e in linqMetaData.Events on ec.EventId equals e.EventId
                                          where ec.AppointmentId != null && e.EventDate >= firstDayOfYear && !ec.NoShow
                                          select ec.CustomerId);

                    var query = (from cp in linqMetaData.VwGetCallQueueExcludedCustomers
                                 select cp);

                    if (filter.CustomerId.HasValue && filter.CustomerId.Value > 0)
                    {
                        query = (from q in query where q.CustomerId == filter.CustomerId select q);
                    }
                    else if (!string.IsNullOrEmpty(filter.MemberId))
                    {
                        query = (from q in query where q.InsuranceId == filter.MemberId select q);
                    }
                    else
                    {
                        if (filter.BookedAppointment)
                        {
                            query = (from cp in linqMetaData.VwGetCallQueueExcludedCustomers
                                     where (eventCustomers.Contains(cp.CustomerId))
                                     select cp);

                        }

                        if (filter.HealthPlanId > 0)
                        {
                            query = (from q in query where (q.Tag == account.Tag) select q);
                        }
                        else
                        {
                            query = (from q in query where (q.Tag != null && q.Tag != string.Empty) select q);
                        }

                        if (!string.IsNullOrEmpty(filter.ZipCode))
                        {
                            query = (from q in query
                                     where (q.ZipCode == filter.ZipCode)
                                     select q);
                        }

                        if (filter.IsEligible)
                        {
                            var customerIdFromEligibility = from ce in linqMetaData.CustomerEligibility where ((ce.IsEligible != null && ce.IsEligible.Value == false) || (ce.IsEligible == null)) && ce.ForYear == DateTime.Today.Year select ce.CustomerId;
                            query = (from q in query where customerIdFromEligibility.Contains(q.CustomerId) select q);
                        }

                        if (filter.InCorrectPhoneNumber)
                        {
                            query = (from q in query where q.IsIncorrectPhoneNumber == filter.InCorrectPhoneNumber select q);
                        }

                        if (filter.DoNotContact)
                        {
                            query = (from q in query
                                     where q.DoNotContactTypeId != null && q.DoNotContactTypeId != (long)DoNotContactType.DoNotMail
                                     select q);
                        }

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {

                            var customTags = string.Join(",", filter.CustomTags);
                            customTags = "," + customTags + ",";

                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                        where ct.IsActive && customTags.IndexOf("," + ct.Tag + ",") >= 0
                                                        select ct.CustomerId);

                            query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                        }

                    }

                    query = query.OrderBy(x => x.CustomerId);

                    totalRecords = query.Count();

                    var customers = query.TakePage(pageNumber, pageSize).ToList();

                    var customerIds = (from c in customers select c.CustomerId).ToArray();

                    if (customerIds.Any())
                        return GetCustomers(customerIds.ToArray());
                    return null;
                }
            }
        }

        public IEnumerable<MedicareEventEditModel> GetEventDetailForMedicareSync(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);
                var query = (from evt in linqMetaData.Events
                             join ec in linqMetaData.EventCustomers
                             on evt.EventId equals ec.EventId
                             join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             where ec.AppointmentId.HasValue && ec.CustomerId == customerId
                             select new MedicareEventEditModel { EventCustomerId = ec.EventCustomerId, EventId = ec.EventId, VisitDate = evt.EventDate }).ToArray();
                return query;
            }
        }

        public IEnumerable<MedicareResultEditModel> GetRecentResultUpdatedForMedicareSync(DateTime fromDate, string tag)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);
                var eligibleCustomerIds = (from ce in linqMetaData.CustomerEligibility where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year select ce.CustomerId);
                var query = (from cp in linqMetaData.CustomerProfile
                             join ec in linqMetaData.EventCustomers
                             on cp.CustomerId equals ec.CustomerId
                             //join ea in linqMetaData.EventAccount on ec.EventId equals ea.EventId
                             join ecr in linqMetaData.EventCustomerResult on new { cp.CustomerId, ec.EventId } equals new { ecr.CustomerId, ecr.EventId }
                             where ec.AppointmentId.HasValue && cp.Tag == tag && eligibleCustomerIds.Contains(cp.CustomerId) && (ecr.DateCreated >= fromDate || ecr.DateModified >= fromDate)
                             select new MedicareResultEditModel { EventCustomerId = ec.EventCustomerId, CustomerId = ecr.CustomerId, EventId = ecr.EventId, ResultState = ecr.ResultState }).Distinct().ToArray();


                return query;
            }
        }

        public IEnumerable<long> GetEventWithTest(long[] events, string tag, long testId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                // has tag , Is Eligible
                // has appointment , on a corporate Account

                var linqMetaData = new LinqMetaData(adapter);
                var query = (from ea in linqMetaData.EventAccount
                             join accountEntity in linqMetaData.Account on ea.AccountId equals accountEntity.AccountId
                             join eventTestEntity in linqMetaData.EventTest on ea.EventId equals eventTestEntity.EventId
                             where accountEntity.Tag == tag && eventTestEntity.TestId == testId && events.Contains(ea.EventId)
                             select ea.EventId).Distinct().ToArray();

                return query;
            }
        }

        public IEnumerable<long> GetCustomersByCustomTag(ResponseVendorReportFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var account = (from a in linqMetaData.Account where a.AccountId == filter.AccountId select a).SingleOrDefault();

                var query = (from cp in linqMetaData.CustomerProfile
                             where (account == null || cp.Tag == account.Tag)
                             select cp);

                if (!filter.CustomTags.IsNullOrEmpty())
                {
                    var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                where filter.CustomTags.Contains(ct.Tag)
                                                select ct.CustomerId);
                    query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                }

                totalRecords = query.Count();

                var result = query.OrderBy(x => x.CustomerId).TakePage(pageNumber, pageSize).Select(x => x.CustomerId).ToArray();

                return result;
            }
        }

        public IEnumerable<Customer> GetCustomerWithNoEventsInArea(CustomerWithNoEventsInAreaReportModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter.AccountId > 0 || (filter.CustomerId.HasValue && filter.CustomerId > 0) || !string.IsNullOrEmpty(filter.MemberId))
                {
                    var query = (from cp in linqMetaData.VwGetCustomersForNotInCallQueue select cp);

                    if (filter.CustomerId.HasValue && filter.CustomerId.Value > 0)
                    {
                        query = (from cp in linqMetaData.VwGetCustomersForNotInCallQueue
                                 where cp.CustomerId == filter.CustomerId
                                 select cp);

                    }
                    else if (!string.IsNullOrEmpty(filter.MemberId))
                    {
                        query = (from cp in linqMetaData.VwGetCustomersForNotInCallQueue
                                 where cp.InsuranceId == filter.MemberId
                                 select cp);
                    }
                    else
                    {
                        query = (from cp in linqMetaData.VwGetCustomersForNotInCallQueue
                                 where cp.AccountId == filter.AccountId
                                 select cp);

                        if (filter.CustomTags != null && filter.CustomTags.Any())
                        {

                            var customTags = string.Join(",", filter.CustomTags);
                            customTags = "," + customTags + ",";

                            var customTagCustomerIds = (from ct in linqMetaData.CustomerTag
                                                        where ct.IsActive && customTags.IndexOf("," + ct.Tag + ",") >= 0
                                                        select ct.CustomerId);

                            query = (from q in query where customTagCustomerIds.Contains(q.CustomerId) select q);
                        }

                        if (!string.IsNullOrEmpty(filter.ZipCode))
                        {
                            query = (from q in query
                                     where (q.ZipCode == filter.ZipCode)
                                     select q);
                        }
                    }

                    query = query.OrderBy(x => x.CustomerId);

                    totalRecords = query.Count();

                    var customers = query.TakePage(pageNumber, pageSize).ToList();

                    var customerIds = (from c in customers select c.CustomerId).ToArray();

                    if (customerIds.Any())
                        return GetCustomers(customerIds.ToArray());
                }

                totalRecords = 0;
                return null;
            }
        }

        public IEnumerable<ConfirmationQueueCustomerModel> GetHealthPlanConfirmationQueueCustomers(CorporateAccount account)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var toDate = account.EventConfirmationBeforeDays.HasValue ? DateTime.Today.AddDays(account.EventConfirmationBeforeDays.Value) : DateTime.Today;

                var eventCustomers = (from cp in linqMetaData.VwGetCustomersToGenerateConfirmationCallQueue
                                      where cp.Tag == account.Tag
                                      //&& cp.EventDate <= toDate
                                      orderby cp.CustomerId
                                      select new ConfirmationQueueCustomerModel
                                      {
                                          CustomerId = cp.CustomerId,
                                          EventId = cp.EventId,
                                          EventDate = cp.EventDate,
                                          Tag = cp.Tag,
                                          EventCustomerId = cp.EventCustomerId,
                                          AppointmentTime = cp.AppointmentTime,
                                          TimeZone = cp.TimeZone,
                                          StateId = cp.StateId,
                                          StateCode = cp.StateCode
                                      }).ToArray();

                return eventCustomers;
            }
        }

        public Customer GetCustomerForPhoneNumberUpdate(string firstName, string lastName, DateTime dob, string memberId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var name = firstName + lastName;
                var query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where (u.FirstName + u.LastName).Contains(name)
                             && cp.InsuranceId == memberId && u.Dob == dob
                             select cp).SingleOrDefault();

                if (query == null)
                    return null;
                return GetCustomer(query.CustomerId);
            }
        }

        public IEnumerable<Customer> GetCustomersByPhoneNumber(string phoneNumber, PhoneNumberType phoneNumberType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where u.PhoneCell == phoneNumber
                             select cp.CustomerId).ToArray();

                if (phoneNumberType == PhoneNumberType.Office)
                {
                    query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where u.PhoneOffice == phoneNumber
                             select cp.CustomerId).ToArray();
                }

                if (phoneNumberType == PhoneNumberType.Home)
                {
                    query = (from cp in linqMetaData.CustomerProfile
                             join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                             join u in linqMetaData.User on oru.UserId equals u.UserId
                             where u.PhoneHome == phoneNumber
                             select cp.CustomerId).ToArray();
                }

                if (query.IsNullOrEmpty()) return null;

                return GetCustomers(query);
            }
        }

        public Customer GetRestrictedCustomer(long customerId, long organizationId)
        {
            CustomerProfileEntity customerEntity = null;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var accountIds = (from ao in linqMetaData.AccountCallCenterOrganization
                                  where ao.IsDeleted == false && ao.OrganizationId == organizationId
                                  select ao.AccountId);

                var tags = (from a in linqMetaData.Account where a.RestrictHealthPlanData == false || accountIds.Contains(a.AccountId) select a.Tag);

                customerEntity = (from cp in linqMetaData.CustomerProfile
                                  where cp.CustomerId == customerId
                                        &&
                                        (cp.Tag == null || cp.Tag == "" || tags.Contains(cp.Tag))
                                  select cp).WithPath(prefetchPath => prefetchPath.Prefetch(cp => cp.OrganizationRoleUser)).SingleOrDefault();


                if (customerEntity == null)
                {
                    throw new ObjectNotFoundInPersistenceException<Customer>(customerId);
                }
            }
            Customer user = _customerRepository.GetUser(customerEntity.OrganizationRoleUser.UserId);
            var billingAddress =
                _addressRepository.GetAddress(customerEntity.BillingAddressId.HasValue
                                                  ? customerEntity.BillingAddressId.Value
                                                  : user.Address.Id);
            return _customerFactory.CreateCustomer(user, billingAddress, customerEntity);
        }

        public IEnumerable<EligibilityUploadCustomerDataViewModel> GetCustomerDataForEligibilityUpload(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var data = from cp in linqMetaData.CustomerProfile
                           where customerIds.Contains(cp.CustomerId)
                           select new EligibilityUploadCustomerDataViewModel { CustomerId = cp.CustomerId, Tag = cp.Tag };
                return data.ToArray();
            }
        }

        public IEnumerable<long> GetCustomerIdByHicn(string hicn)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerEntity = linqMetaData.CustomerProfile.WithPath(
                    prefetchPath => prefetchPath.Prefetch(cp => cp.OrganizationRoleUser)).Where(
                        cp => cp.Hicn.ToUpper() == hicn.ToUpper()).ToList();

                return customerEntity.Any() ? customerEntity.Select(x => x.CustomerId) : null;
            }
        }

        public IEnumerable<OrderedPair<long, DateTime?>> GetCustomerIdDobPair(IEnumerable<long> customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var data = (from cp in linqMetaData.CustomerProfile
                            join oru in linqMetaData.OrganizationRoleUser on cp.CustomerId equals oru.OrganizationRoleUserId
                            join u in linqMetaData.User on oru.UserId equals u.UserId
                            where customerIds.Contains(oru.OrganizationRoleUserId)
                            select new OrderedPair<long, DateTime?> { FirstValue = cp.CustomerId, SecondValue = u.Dob });
                return data.ToList();
            }
        }

        public void UpdateBillingAddress(long customerId, long addressId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerProfileEntity { BillingAddressId = addressId };

                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);

                if (adapter.UpdateEntitiesDirectly(entity, bucket) <= 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        public IEnumerable<Customer> GetForPcpTrackingReport(int pageNumber, int pageSize, PcpTrackingReportFilter filter,
            out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from pcp in linqMetaData.CustomerPrimaryCarePhysician
                             where pcp.Source == (long)CustomerPcpUpdateSource.CorporateUpload
                             select pcp);

                if (filter.PatientId.HasValue && filter.PatientId.Value > 0)
                {
                    query = query.Where(q => q.CustomerId == filter.PatientId.Value);
                }
                else
                {
                    if (filter.HealthPlanId > 0)
                    {
                        var account = (from a in linqMetaData.Account where a.AccountId == filter.HealthPlanId select a).Single();
                        var customerIds = (from cp in linqMetaData.CustomerProfile where cp.Tag == account.Tag select cp.CustomerId);
                        query = query.Where(q => customerIds.Contains(q.CustomerId));
                    }
                    if (!string.IsNullOrEmpty(filter.PatientName))
                    {
                        var customerIds = (from oru in linqMetaData.OrganizationRoleUser
                                           join u in linqMetaData.User on oru.UserId equals u.UserId
                                           where (u.FirstName + (u.MiddleName.Trim().Length > 0 ? (" " + u.MiddleName + " ") : " ") + u.LastName).ToLower().Contains(filter.PatientName.ToLower())
                                           select oru.OrganizationRoleUserId);

                        query = query.Where(q => customerIds.Contains(q.CustomerId));
                    }
                }

                var customerIdsQuery = query.OrderByDescending(x => x.CustomerId).Select(x => x.CustomerId).Distinct();

                totalRecords = customerIdsQuery.Count();

                var pagedCustomerIds = customerIdsQuery.TakePage(pageNumber, pageSize).ToArray();

                if (!pagedCustomerIds.Any())
                    return null;

                var pagedCustomers = GetCustomers(pagedCustomerIds);
                return pagedCustomerIds.Select(x => pagedCustomers.Single(pc => pc.CustomerId == x));
            }
        }

        public IEnumerable<Customer> GetCustomerForUniversalMemberReport(UniversalMemberListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!(string.IsNullOrEmpty(filter.Tag)))
                {
                    var eligibleCustomers = (from ce in linqMetaData.CustomerEligibility
                                             where ce.IsEligible.HasValue && ce.IsEligible.Value && ce.ForYear == DateTime.Today.Year
                                             select ce.CustomerId);

                    var query = (from cp in linqMetaData.CustomerProfile
                                 where cp.Tag == filter.Tag && eligibleCustomers.Contains(cp.CustomerId)
                                 select cp);

                    totalRecords = query.Count();

                    query = query.OrderByDescending(x => x.DateModified).ThenByDescending(x => x.DateCreated);

                    var customers = query.TakePage(pageNumber, pageSize).ToArray();

                    if (customers.Any())
                        return GetCustomersWithoutLogin(customers);
                }

                totalRecords = 0;
                return null;
            }
        }

        private IEnumerable<Customer> GetCustomersWithoutLogin(IEnumerable<CustomerProfileEntity> customerProfileEntities)
        {

            var customerIds = customerProfileEntities.Select(x => x.CustomerId).ToArray();
            var billingAddressIds = customerProfileEntities.Where(x => x.BillingAddressId.HasValue).Select(x => x.BillingAddressId.Value).ToList();

            var organizationRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(customerIds);
            List<Customer> users = _customerRepository.GetOnlyUserAndAddressInfo(organizationRoleUsers.Select(x => x.UserId));

            var billingAddresses = _addressRepository.GetAddresses(billingAddressIds);

            var list = new List<Customer>();

            foreach (var customerProfileEntity in customerProfileEntities)
            {
                var organizationRoleUser = organizationRoleUsers.First(x => x.Id == customerProfileEntity.CustomerId);
                var customer = users.First(x => x.Id == organizationRoleUser.UserId);
                Address billingAddress = null;
                if (customerProfileEntity.BillingAddressId.HasValue)
                    billingAddress = billingAddresses.First(x => x.Id == customerProfileEntity.BillingAddressId.Value);
                list.Add(_customerFactory.CreateCustomer(customer, billingAddress, customerProfileEntity));
            }

            return list;
        }

        private IEnumerable<Customer> GetCustomersWithoutLoginAndAddressDetails(IEnumerable<CustomerProfileEntity> customerProfileEntities)
        {
            var customerIds = customerProfileEntities.Select(x => x.CustomerId).ToArray();

            var organizationRoleUsers = _organizationRoleUserRepository.GetOrganizationRoleUsers(customerIds);
            List<Customer> users = _customerRepository.GetUserWithoutAddressInfo(organizationRoleUsers.Select(x => x.UserId));
            var list = new List<Customer>();

            foreach (var customerProfileEntity in customerProfileEntities)
            {
                var organizationRoleUser = organizationRoleUsers.First(x => x.Id == customerProfileEntity.CustomerId);
                var customer = users.First(x => x.Id == organizationRoleUser.UserId);
                Address billingAddress = null;
                list.Add(_customerFactory.CreateCustomer(customer, billingAddress, customerProfileEntity));
            }

            return list;
        }

        public IEnumerable<long> CheckCustomerExists(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cp in linqMetaData.CustomerProfile
                        where customerIds.Contains(cp.CustomerId)
                        select cp.CustomerId).ToArray();
            }
        }

        public bool UpdateAcesId(long customerId, string acesId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = new CustomerProfileEntity(customerId)
                {
                    AcesId = acesId
                };
                var bucket = new RelationPredicateBucket(CustomerProfileFields.CustomerId == customerId);
                try { return adapter.UpdateEntitiesDirectly(entity, bucket) > 0; }
                catch (Exception ex) { throw new PersistenceFailureException(ex.Message); }
            }
        }

        public IEnumerable<long> CheckCustomerAlreadyHaveAcesId(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cp in linqMetaData.CustomerProfile
                        where customerIds.Contains(cp.CustomerId)
                        && cp.AcesId != null && cp.AcesId.Length > 0
                        select cp.CustomerId).ToArray();
            }
        }

        public IEnumerable<string> CheckAcesIdAlreadyAssignedToCustomer(string[] acesIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return (from cp in linqMetaData.CustomerProfile
                        where cp.AcesId != null && cp.AcesId.Length > 0
                        && acesIds.Contains(cp.AcesId.ToLower())
                        select cp.AcesId.ToLower()).ToArray();
            }
        }

        public IEnumerable<Customer> GetCustomerConsentDataReport(CustomerConsentDataListModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!(string.IsNullOrEmpty(filter.Tag)))
                {
                    var query = (from cp in linqMetaData.CustomerProfile where cp.Tag == filter.Tag && cp.AcesId != null && cp.AcesId.Length > 0 select cp);

                    if (filter.FromDate.HasValue)
                    {
                        query = (from cp in query
                                 where (cp.PhoneCellConsentUpdateDate.HasValue && cp.PhoneCellConsentUpdateDate >= filter.FromDate)
                                 || (cp.PhoneHomeConsentUpdateDate.HasValue && cp.PhoneHomeConsentUpdateDate >= filter.FromDate)
                                 || (cp.PhoneOfficeConsentUpdateDate.HasValue && cp.PhoneOfficeConsentUpdateDate >= filter.FromDate)
                                 select cp);
                    }
                    query = query.OrderByDescending(x => x.DateModified).ThenByDescending(x => x.DateCreated);

                    totalRecords = query.Count();

                    var customers = query.TakePage(pageNumber, pageSize).ToArray();

                    if (customers.Any())
                        return GetCustomersWithoutLogin(customers);
                }

                totalRecords = 0;
                return null;
            }
        }

        public IEnumerable<Customer> GetCustomerForSuspectConditionUpload(string gmpi, string memberId, string memberName, DateTime dob)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                memberName = memberName.Replace(" ", "");

                var linqMetaData = new LinqMetaData(adapter);

                if (!string.IsNullOrEmpty(gmpi))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 join a in linqMetaData.Account on c.Tag equals a.Tag
                                 join aaf in linqMetaData.AccountAdditionalFields on a.AccountId equals aaf.AccountId
                                 join oru in linqMetaData.OrganizationRoleUser on c.CustomerId equals oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where (u.LastName + "," + u.FirstName + "" + u.MiddleName).Trim().ToLower().Contains(memberName)
                                 && u.Dob == dob && (memberId == "" || c.InsuranceId == memberId)
                                 && aaf.DisplayName.ToLower() == "gmpi" && c.AdditionalField3 == gmpi
                                 select c).ToArray();
                    if (query.Count() == 0)
                        return null;
                    return GetCustomersWithoutLogin(query);
                }
                else if (!string.IsNullOrEmpty(memberId))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 join oru in linqMetaData.OrganizationRoleUser on c.CustomerId equals oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where (u.LastName + "," + u.FirstName + "" + u.MiddleName).Trim().ToLower().Contains(memberName)
                                 && c.InsuranceId == memberId && u.Dob == dob
                                 select c).ToArray();
                    if (query.Count() == 0)
                        return null;
                    return GetCustomersWithoutLogin(query);
                }
                else return null;
            }
        }

        public IEnumerable<Customer> GetCustomerForMedicationParsing(string hicn, string memberId, DateTime dob)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!string.IsNullOrEmpty(hicn))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 where c.Hicn == hicn
                                 select c);
                    var customerCount = query.Count();
                    if (customerCount == 0 && !string.IsNullOrEmpty(memberId))
                    {
                        query = (from c in linqMetaData.CustomerProfile
                                 where c.InsuranceId == memberId
                                 select c);

                        if (query.Count() > 1)
                        {
                            query = (from q in linqMetaData.CustomerProfile
                                     join oru in linqMetaData.OrganizationRoleUser on q.CustomerId equals
                                         oru.OrganizationRoleUserId
                                     join u in linqMetaData.User on oru.UserId equals u.UserId
                                     where q.InsuranceId == memberId && (u.Dob != null && u.Dob.Value == dob.Date)
                                     select q);
                        }
                    }
                    else if (customerCount > 1)
                    {
                        query = (from q in linqMetaData.CustomerProfile
                                 join oru in linqMetaData.OrganizationRoleUser on q.CustomerId equals
                                         oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where q.Hicn == hicn && (u.Dob != null && u.Dob.Value == dob.Date)
                                 select q);
                    }
                    var customers = query.ToArray();
                    return customers.Any() ? GetCustomersWithoutLoginAndAddressDetails(customers) : null;
                }

                if (!string.IsNullOrEmpty(memberId))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 where c.InsuranceId == memberId
                                 select c);

                    if (query.Count() > 1)
                    {
                        query = (from q in linqMetaData.CustomerProfile
                                 join oru in linqMetaData.OrganizationRoleUser on q.CustomerId equals
                                     oru.OrganizationRoleUserId
                                 join u in linqMetaData.User on oru.UserId equals u.UserId
                                 where q.InsuranceId == memberId && (u.Dob != null && u.Dob.Value == dob.Date)
                                 select q);
                    }
                    var customers = query.ToArray();
                    return customers.Any() ? GetCustomersWithoutLoginAndAddressDetails(customers) : null;
                }

                return null;
            }
        }

        public IEnumerable<Customer> GetCustomersWoithoutLoginAndAddressDetails(long[] customerIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from c in linqMetaData.CustomerProfile
                             where customerIds.Contains(c.CustomerId)
                             select c);

                var customers = query.ToArray();
                return customers.Any() ? GetCustomersWithoutLoginAndAddressDetails(customers) : null;
            }
        }

        public List<Customer> GetCustomersByAcesId(string acesId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!string.IsNullOrWhiteSpace(acesId))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 where c.AcesId == acesId
                                 select c);

                    var customers = query.ToArray();
                    return customers.Any() ? GetCustomers(customers.Select(x => x.CustomerId).ToArray()).ToList() : null;
                }

                return null;
            }
        }

        public List<Customer> GetCustomersByMemberId(string memberId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (!string.IsNullOrWhiteSpace(memberId))
                {
                    var query = (from c in linqMetaData.CustomerProfile
                                 where c.InsuranceId == memberId
                                 select c);

                    var customers = query.ToArray();
                    return customers.Any() ? GetCustomersWithoutLoginAndAddressDetails(customers).ToList() : null;
                }

                return null;
            }
        }

        public IEnumerable<Customer> GetCustomerForHiptoAcesCrossWalk(HiptoAcesCrossWalkViewModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = (from c in linqMetaData.CustomerProfile select c);

                if (string.IsNullOrWhiteSpace(filter.Tag) || filter.CustomerOnlyWithAcesId == false)
                {
                    if (!string.IsNullOrWhiteSpace(filter.Tag))
                    {
                        query = from q in query where q.Tag == filter.Tag select q;
                    }

                    if (filter.CustomerOnlyWithAcesId)
                        query = from q in query where q.AcesId != null && q.AcesId != "" select q;

                    if (filter.OnlyEligibileCustomer && filter.Year.HasValue)
                    {
                        var eligibleCustomer = (from ec in linqMetaData.CustomerEligibility
                                                where ec.ForYear == filter.Year.Value && ec.IsEligible == filter.OnlyEligibileCustomer
                                                select ec.CustomerId);

                        query = (from q in query
                                 where eligibleCustomer.Contains(q.CustomerId)
                                 select q);
                    }

                }
                else
                {
                    //var eligibleCustomer = (from ec in linqMetaData.CustomerEligibility
                    //                        where ec.ForYear == filter.Year.Value && ec.IsEligible == filter.OnlyEligibileCustomer
                    //                        select ec.CustomerId);

                    query = (from c in linqMetaData.CustomerProfile
                             where c.Tag == filter.Tag && c.AcesId != null && c.AcesId != ""
                             //&& eligibleCustomer.Contains(c.CustomerId)
                             select c);
                }

                totalRecords = query.Count();

                if (totalRecords < 1)
                    return null;

                var customerProfileEntities = query.TakePage(pageNumber, pageSize).ToArray();

                return customerProfileEntities.Any() ? GetCustomersWithoutLogin(customerProfileEntities) : null;
            }
        }

        public IEnumerable<Customer> GetPatientList(PatientSearchFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                if (filter == null || ((filter.CustomerId == null || filter.CustomerId <= 0) && string.IsNullOrWhiteSpace(filter.FirstName) && string.IsNullOrWhiteSpace(filter.LastName) && string.IsNullOrWhiteSpace(filter.MemberId)))
                {
                    return null;
                }

                var query = (from cp in linqMetaData.CustomerProfile
                             select cp);

                if (filter.CustomerId.HasValue && filter.CustomerId > 0)
                {
                    query = (from cp in linqMetaData.CustomerProfile
                             where cp.CustomerId == filter.CustomerId
                             select cp);
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(filter.FirstName) || !string.IsNullOrWhiteSpace(filter.LastName))
                    {
                        var firstName = !string.IsNullOrEmpty(filter.FirstName) ? filter.FirstName : "";
                        var lastName = !string.IsNullOrEmpty(filter.LastName) ? filter.LastName : "";

                        query = (from q in linqMetaData.CustomerProfile
                                 join org in linqMetaData.OrganizationRoleUser on q.CustomerId equals org.OrganizationRoleUserId
                                 join u in linqMetaData.User on org.UserId equals u.UserId
                                 where (firstName.Trim().Length > 0 ? u.FirstName.Contains(firstName.Trim()) : true)
                                 && (lastName.Trim().Length > 0 ? u.LastName.Contains(lastName.Trim()) : true)
                                 select q);
                    }

                    if (!string.IsNullOrWhiteSpace(filter.MemberId))
                    {
                        query = (from q in query
                                 where q.InsuranceId == filter.MemberId
                                 select q);
                    }
                }

                var entities = query.ToArray();

                return entities.Any() ? GetCustomersWithoutLogin(entities) : null;
            }
        }

        public IEnumerable<long> GetCustomerForTermByAbsence(int pageNumber, int pageSize, MemberTermByAbsenceFilter filter,
    out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eligibileCustomers = (from ce in linqMetaData.CustomerEligibility
                                          where ce.ForYear == DateTime.Today.Year && ce.IsEligible == true
                                          select ce.CustomerId);

                var query = (from mul in linqMetaData.MemberUploadLog
                             where mul.CorporateUploadId == filter.CorporateUploadId
                             select mul.CustomerId);

                var queryForAbsence = (from c in linqMetaData.CustomerProfile
                                       where c.Tag == filter.Tag && !query.Contains(c.CustomerId)
                                       && eligibileCustomers.Contains(c.CustomerId)
                                       select c.CustomerId).OrderBy(c => c);

                totalRecords = queryForAbsence.Count();

                if (totalRecords < 1)
                    return null;

                var customerIds = queryForAbsence.TakePage(pageNumber, pageSize).ToArray();

                return customerIds;
            }
        }


    }
}