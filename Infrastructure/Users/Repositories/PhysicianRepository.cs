using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.ViewModels;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.Infrastructure.Scheduling.Repositories;
using Falcon.App.Infrastructure.Users.Factories;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.Data.Linq;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Application.Exceptions;
using System;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.Data.HelperClasses;
using Falcon.App.Core.Enum;
using System.Collections.Generic;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    public class PhysicianRepository : PersistenceRepository, IPhysicianRepository
    {
        private readonly IUserRepository<Physician> _userRepository;
        private readonly IPhysicianFactory _physicianFactory;
        private readonly IMapper<PhysicianLicense, PhysicianLicenseEntity> _licenseMapper;
        private readonly IUniqueItemRepository<EventCustomer> _eventCustomerRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;


        public PhysicianRepository(IUserRepository<Physician> repository, IPhysicianFactory factory, IMapper<PhysicianLicense, PhysicianLicenseEntity> licenseMapper,
            IUniqueItemRepository<EventCustomer> eventCustomerRepository, IUniqueItemRepository<File> fileRepository)
        {
            _userRepository = repository;
            _physicianFactory = factory;
            _licenseMapper = licenseMapper;
            _eventCustomerRepository = eventCustomerRepository;
            _fileRepository = fileRepository;
        }

        public PhysicianRepository()
            : this(new UserRepository<Physician>(), new PhysicianFactory(), new PhysicianLicenseMapper(), new EventCustomerRepository(), new FileRepository())
        {
        }

        public Physician GetPhysician(long physicianId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var physicianProfileEntity =
                    linqMetaData.PhysicianProfile.WithPath(
                        prefetchPath =>
                        prefetchPath.Prefetch(phy => phy.OrganizationRoleUser).Prefetch(phy => phy.PhysicianLicense).
                            Prefetch(phy => phy.PhysicianCustomerPayRate).Prefetch(phy => phy.PhysicianPermittedTest).
                            Prefetch(phy => phy.PhysicianPod)).
                        Where(phy => phy.PhysicianId == physicianId).FirstOrDefault();

                if (physicianProfileEntity == null)
                    throw new ObjectNotFoundInPersistenceException<Physician>(physicianId);

                Physician user = _userRepository.GetUser(physicianProfileEntity.OrganizationRoleUser.UserId);

                var physician = _physicianFactory.CreatePhysician(user, physicianProfileEntity);
                if (physician.SignatureFile != null && physician.SignatureFile.Id > 0)
                {
                    physician.SignatureFile = _fileRepository.GetById(physician.SignatureFile.Id);
                }

                return physician;
            }
        }

        public Physician GetResultEvaluatingPhysician(long customerId, long eventId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var eventCustomerResultId = linqMetaData.EventCustomerResult.Where(entity => entity.CustomerId == customerId && entity.EventId == eventId)
                                                                            .Select(entity => entity.EventCustomerResultId).FirstOrDefault();

                var id = linqMetaData.EventCustomerEvaluationLock.Where(entity => entity.EventCustomerId == eventCustomerResultId)
                                                            .Select(entity => entity.PhysicianId).FirstOrDefault();

                return GetPhysician(id);
            }
        }

        public bool CanSeeEarnings(long physicianId)
        {
            var physicianProfileEntity = new PhysicianProfileEntity(physicianId);
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.FetchEntity(physicianProfileEntity))
                {
                    throw new ObjectNotFoundInPersistenceException<Physician>(physicianId);
                }
            }
            return physicianProfileEntity.ShowEarningAmount;
        }

        public bool IsAuthorizationPending(long physicianId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var listState = (from license in linqMetaData.PhysicianLicense
                                 where license.PhysicianId == physicianId
                                 select license.StateId).ToList();

                var listEventCustomer = (from eventCustomer in linqMetaData.EventCustomers
                                         where eventCustomer.AppointmentId != null &&
                                         eventCustomer.NoShow == false && !linqMetaData.ScreeningAuthorization.Any(
                                             screeningAuthorization => screeningAuthorization.EventCustomerId == eventCustomer.EventCustomerId
                                         )
                                         select new { eventCustomer.EventId, eventCustomer.EventCustomerId }).ToList();


                var listEvent = (from eventEntity in linqMetaData.Events
                                 join hostEventDetails in linqMetaData.HostEventDetails on eventEntity.EventId equals hostEventDetails.EventId
                                 join prospect in linqMetaData.Prospects on hostEventDetails.HostId equals prospect.ProspectId
                                 join address in linqMetaData.Address on prospect.AddressId equals address.AddressId
                                 where (eventEntity.IsActive == true && eventEntity.EventDate >= DateTime.Now.Date &&
                                                         eventEntity.EventDate < (DateTime.Now.Date.AddDays(2))
                                                         )
                                 select new { eventEntity.EventId, address.StateId }).ToList();

                var eventsToAuthorize = listEvent.FindAll(events =>
                {
                    if (listEventCustomer.Find(eventCustomer => eventCustomer.EventId == events.EventId) != null)
                        return true;
                    return false;
                }).FindAll(events =>
                {
                    if (listState.Find(state => events.StateId == state) > 0) return true;
                    else return false;
                });

                if (eventsToAuthorize.Count() > 0) return true;
            }

            return false;
        }

        public long[] GetAllPhysicianIdsforaMedicalVendor(long medicalVendorId)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                return linqMetaData.OrganizationRoleUser.Where(oru => oru.OrganizationId == medicalVendorId && oru.RoleId == (long)Roles.MedicalVendorUser).
                    Select(oru => oru.OrganizationRoleUserId).ToArray();
            }
        }

        public decimal GetCurrentPayrate(long physicianId)
        {
            var physicianCustomerPayRateEntity = new PhysicianCustomerPayRateEntity();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                IPredicateExpression predicate = new PredicateExpression(PhysicianCustomerPayRateFields.PhysicianId == physicianId);

                if (!myAdapter.FetchEntityUsingUniqueConstraint(physicianCustomerPayRateEntity, predicate))
                {
                    throw new ObjectNotFoundInPersistenceException<Physician>(physicianId);
                }
            }
            return physicianCustomerPayRateEntity.StandardRate;
        }

        //TODO:NEEd a View Model  Concep to refactor this.
        public Physician SavePhysician(Physician physician)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var fileRepository = new FileRepository();
                if (physician.SignatureFile != null) physician.SignatureFile = fileRepository.Save(physician.SignatureFile);
                if (physician.ResumeFile != null) physician.ResumeFile = fileRepository.Save(physician.ResumeFile);

                var entity = _physicianFactory.CreatePhysicianEntity(physician);
                entity.IsNew = !adapter.FetchEntity(new PhysicianProfileEntity(physician.PhysicianId));

                if (!adapter.SaveEntity(entity)) throw new PersistenceFailureException();

                SavePermittedTests(physician.PhysicianId, physician.PermittedTests);
                SavePhysicianCustomerPayRate(physician.PhysicianId, physician.StandardRate, physician.OverReadRate);
                SavePhysicianLicenses(physician.PhysicianId, physician.AuthorizedStateLicenses);
                SavePhysicianPods(physician.PhysicianId, physician.AssignedPodIds);
                return physician;
            }
        }

        private void SavePermittedTests(long physicianId, IEnumerable<long> testsIds)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket =
                    new RelationPredicateBucket(PhysicianPermittedTestFields.OrganizationRoleUserId == physicianId);

                adapter.DeleteEntitiesDirectly("PhysicianPermittedTestEntity", bucket);

                var entities = new EntityCollection<PhysicianPermittedTestEntity>();
                foreach (var testId in testsIds)
                {
                    entities.Add(new PhysicianPermittedTestEntity(physicianId, testId));
                }

                if (adapter.SaveEntityCollection(entities) == 0)
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        private void SavePhysicianCustomerPayRate(long physicianId, decimal standardRate, decimal overReadRate)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket =
                       new RelationPredicateBucket(PhysicianCustomerPayRateFields.PhysicianId == physicianId);

                myAdapter.DeleteEntitiesDirectly("PhysicianCustomerPayRateEntity", bucket);

                var entity = new PhysicianCustomerPayRateEntity(physicianId) { StandardRate = standardRate, OverReadRate = overReadRate };
                if (!myAdapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }

        private void SavePhysicianLicenses(long physicianId, IEnumerable<PhysicianLicense> licenses)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entities = new EntityCollection<PhysicianLicenseEntity>();
                adapter.FetchEntityCollection(entities,
                                              new RelationPredicateBucket(
                                                  PhysicianLicenseFields.PhysicianId == physicianId));

                if (!entities.IsNullOrEmpty())
                {
                    if (licenses.IsNullOrEmpty())
                    {
                        if (adapter.DeleteEntityCollection(entities) == 0)
                            throw new PersistenceFailureException("Data for Physician Licenses could not be cleared.");
                        return;
                    }

                    var ids = licenses.Select(license => license.Id);
                    var entitiesToDelete = entities.Where(e => !ids.Contains(e.LicenseId));
                    var toDelete = new EntityCollection<PhysicianLicenseEntity>(entitiesToDelete.ToList());
                    if (!entitiesToDelete.IsNullOrEmpty())
                    {
                        adapter.DeleteEntityCollection(toDelete);
                    }
                }

                entities = new EntityCollection<PhysicianLicenseEntity>();
                var entitiesToSave = _licenseMapper.MapMultiple(licenses);

                entities.AddRange(entitiesToSave);
                if (adapter.SaveEntityCollection(entities) == 0) throw new PersistenceFailureException("Data for physician Licenses could not be saved.");
            }
        }

        private void SavePhysicianPods(long physicianId, IEnumerable<long> podIds)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var bucket =
                    new RelationPredicateBucket(PhysicianPodFields.PhysicianId == physicianId);

                adapter.DeleteEntitiesDirectly("PhysicianPodEntity", bucket);

                if (podIds != null && podIds.Count() > 0)
                {
                    var entities = new EntityCollection<PhysicianPodEntity>();
                    foreach (var id in podIds)
                    {
                        entities.Add(new PhysicianPodEntity(physicianId, id));
                    }

                    if (adapter.SaveEntityCollection(entities) == 0)
                    {
                        throw new PersistenceFailureException();
                    }
                }
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetPhysicianSpecilizationIdNamePairs()
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ps in linqMetaData.PhysicianSpecialization
                        where ps.IsActive
                        select new OrderedPair<long, string>(ps.PhysicianSpecializationId, ps.Name)).ToList();
            }
        }

        private IEnumerable<long> FilterPhysicianForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                IHostRepository hostRepository = new HostRepository();
                var eventHost = hostRepository.GetHostForEvent(eventId);

                var eventDate = (from e in linqMetaData.Events
                                 where e.EventId == eventId
                                 select e.EventDate).Single();

                var physicianIds = (from pf in linqMetaData.PhysicianProfile
                                    join pl in linqMetaData.PhysicianLicense on pf.PhysicianId equals pl.PhysicianId
                                    where pl.StateId == eventHost.Address.StateId && (pl.ExpiryDate > DateTime.Now.Date) && (pf.CutOffDate.HasValue ? eventDate >= pf.CutOffDate.Value : true)
                                    select pl.PhysicianId).ToList();

                var eventPodIds = from ep in linqMetaData.EventPod
                                  join p in linqMetaData.PodDetails on ep.PodId equals p.PodId
                                  where ep.EventId == eventId && ep.IsActive
                                  select p.PodId;

                var physicianIdsContainsEventPod = (from pp in linqMetaData.PhysicianPod
                                                    where eventPodIds.Contains(pp.PodId) && physicianIds.Contains(pp.PhysicianId)
                                                    select pp.PhysicianId).ToList();

                var physicianIdsWithPod = from pp in linqMetaData.PhysicianPod
                                          select pp.PhysicianId;

                var physicianIdsWithoutPod = physicianIds.Where(p => !physicianIdsWithPod.Contains(p)).Select(p => p);

                var filteredPhysicianIds = new List<long>();
                filteredPhysicianIds.AddRange(physicianIdsContainsEventPod);
                filteredPhysicianIds.AddRange(physicianIdsWithoutPod);
                return filteredPhysicianIds;

            }

        }

        public IEnumerable<OrderedPair<long, string>> GetAvailablePhysiciansIdNamePairForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var filteredIds = FilterPhysicianForEvent(eventId);

                var testIds = GetReviewableTestIdsForEvent(eventId);

                var physicianIds = filteredIds.Select(filteredId => (from pmt in linqMetaData.PhysicianPermittedTest
                                                                     where pmt.OrganizationRoleUserId == filteredId && testIds.Contains(pmt.TestId)
                                                                     select pmt.OrganizationRoleUserId).FirstOrDefault());

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        join pf in linqMetaData.PhysicianProfile on oru.OrganizationRoleUserId equals pf.PhysicianId
                        join ps in linqMetaData.PhysicianSpecialization on pf.SpecializationId equals ps.PhysicianSpecializationId
                        where physicianIds.Contains(oru.OrganizationRoleUserId) && oru.IsActive && u.IsActive
                        orderby u.FirstName, u.LastName
                        select
                            new OrderedPair<long, string>(oru.OrganizationRoleUserId,
                                                          u.FirstName + " " + u.LastName + " (" + ps.Name + ")")
                        ).ToList();

            }
        }

        private List<long> GetReviewableTestIdsForEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventTestIds = (from t in linqMetaData.Test
                                    join et in linqMetaData.EventTest on t.TestId equals et.TestId
                                    where et.EventId == eventId && t.IsTestReviewableByPhysician
                                    && (et.IsTestReviewableByPhysician == null || et.IsTestReviewableByPhysician.Value)
                                    select t.TestId).ToList();

                return eventTestIds;
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetAvailablePhysiciansIdNamePairForCustomer(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var physicianIds = GetPhysiciansIdsForEventCustomer(eventCustomerId);

                return (from u in linqMetaData.User
                        join oru in linqMetaData.OrganizationRoleUser on u.UserId equals oru.UserId
                        join pf in linqMetaData.PhysicianProfile on oru.OrganizationRoleUserId equals pf.PhysicianId
                        join ps in linqMetaData.PhysicianSpecialization on pf.SpecializationId equals ps.PhysicianSpecializationId
                        where (physicianIds.Contains(oru.OrganizationRoleUserId))
                        && oru.IsActive && u.IsActive
                        orderby u.FirstName, u.LastName
                        select
                            new OrderedPair<long, string>(oru.OrganizationRoleUserId,
                                                          u.FirstName + " " + u.LastName + " (" + ps.Name + ")")).ToList();
            }
        }

        private List<long> GetPhysiciansIdsForEventCustomer(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var eventCustomer = _eventCustomerRepository.GetById(eventCustomerId);
                var eventId = eventCustomer.EventId;

                var linqMetaData = new LinqMetaData(adapter);

                var filteredIds = FilterPhysicianForEvent(eventId);

                var testIds = GetReviewableTestIdsForEventCustomer(eventCustomerId);

                var physicianIds = filteredIds.Select(filteredId => (from pmt in linqMetaData.PhysicianPermittedTest
                                                                     where pmt.OrganizationRoleUserId == filteredId
                                                                           &&
                                                                           testIds.Contains(pmt.TestId)
                                                                     select pmt.OrganizationRoleUserId).FirstOrDefault()).ToList();
                return physicianIds;
            }
        }

        private List<long> GetReviewableTestIdsForEventCustomer(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var orderId = (from ec in linqMetaData.EventCustomers
                               join ecod in linqMetaData.EventCustomerOrderDetail on ec.EventCustomerId equals
                                   ecod.EventCustomerId
                               join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                               where ecod.IsActive && ec.EventCustomerId == eventCustomerId
                               select od.OrderId).FirstOrDefault();


                var packageTestIds = (from o in linqMetaData.Order
                                      join tod in linqMetaData.OrderDetail on o.OrderId equals tod.OrderId
                                      join epoi in linqMetaData.EventPackageOrderItem on tod.OrderItemId equals epoi.OrderItemId
                                      //join epd in linqMetaData.EventPackageDetails on epoi.EventPackageId equals epd.EventPackageId
                                      join ept in linqMetaData.EventPackageTest on epoi.EventPackageId equals ept.EventPackageId
                                      join et in linqMetaData.EventTest on ept.EventTestId equals et.EventTestId
                                      join test in linqMetaData.Test on et.TestId equals test.TestId
                                      where o.OrderId == orderId && (tod.Status == (short)OrderStatus.Open)
                                        && test.IsTestReviewableByPhysician
                                        && (et.IsTestReviewableByPhysician == null || et.IsTestReviewableByPhysician.Value)
                                      select test.TestId).ToList();

                var additionalTestIds = (from o in linqMetaData.Order
                                         join tod in linqMetaData.OrderDetail on o.OrderId equals tod.OrderId
                                         join etoi in linqMetaData.EventTestOrderItem on tod.OrderItemId equals
                                             etoi.OrderItemId
                                         join et in linqMetaData.EventTest on etoi.EventTestId equals
                                             et.EventTestId
                                         join test in linqMetaData.Test on et.TestId equals test.TestId
                                         where o.OrderId == orderId && (tod.Status == (short)OrderStatus.Open)
                                            && test.IsTestReviewableByPhysician
                                            && (et.IsTestReviewableByPhysician == null || et.IsTestReviewableByPhysician.Value)
                                         select test.TestId).ToList();

                packageTestIds.AddRange(additionalTestIds);

                return packageTestIds;
            }
        }

        //TODO: Refactor these two methods. Some repeated codes.
        public PhysicianEvaluationQueueSummary GetEventCustomerIdForPhysicianEvaluation(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var validEventCustomeridsforPhysician = GetValidEventCustomerResultIdsforPhysician(physicianId);

                var query = (from phr in linqMetaData.VwPhysicianQueueRecord
                             //where phr.PhysicianId == physicianId && phr.IsAtOverreadState == false
                             where phr.IsAtOverreadState == false
                                 && !(from ecel in linqMetaData.EventCustomerEvaluationLock select ecel.EventCustomerId).Contains(phr.EventCustomerResultId)
                             select phr);

                var maxPriorityValue = query.Max(q => q.InQueuePriority) + 1;

                query = from q in query
                        join a in linqMetaData.EventCustomers on q.EventCustomerResultId equals
                                 a.EventCustomerId
                        join ea in linqMetaData.EventAppointment on a.AppointmentId equals
                            ea.AppointmentId
                        join e in linqMetaData.Events on a.EventId equals e.EventId
                        orderby q.CriticalMarkedByTechnician descending, (q.InQueuePriority == 0 ? maxPriorityValue : q.InQueuePriority) ascending, q.SentBackatPrimaryEval descending,
                        q.CriticalChatTest descending, q.CriticalChatDate ascending, e.EventDate, e.EventId, ea.StartTime, q.UpdatedOn
                        select q;


                var resultsFromEventAssignment = query.ToArray();
                resultsFromEventAssignment = resultsFromEventAssignment.Where(ec => ec.PhysicianId == physicianId && validEventCustomeridsforPhysician.Contains(ec.EventCustomerResultId)).ToArray();

                var criticalPatientCount = resultsFromEventAssignment.Count(ea => ea.CriticalMarkedByTechnician);
                var priorityInQueueCount = resultsFromEventAssignment.Count(ea => ea.InQueuePriority > 0);

                return new PhysicianEvaluationQueueSummary
                           {
                               ItemsAvailable = resultsFromEventAssignment.Length,
                               ItemsDone = 0,
                               CriticalsInQueue = criticalPatientCount,
                               PriorityInQueueCount = priorityInQueueCount,
                               FirstItemInTheQueue = resultsFromEventAssignment.Select(phr => phr.EventCustomerResultId).FirstOrDefault()
                           };

            }
        }

        public PhysicianEvaluationQueueSummary GetEventCustomerIdForOverReadPhysicianEvaluation(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var validEventCustomeridsforPhysician = GetValidEventCustomerResultIdsforPhysician(physicianId, true);

                var query = (from phr in linqMetaData.VwPhysicianQueueRecord
                             //where phr.OverreadPhysicianId == physicianId && phr.IsAtOverreadState == true
                             where phr.IsAtOverreadState == true
                                 && !(from ecel in linqMetaData.EventCustomerEvaluationLock select ecel.EventCustomerId).Contains(phr.EventCustomerResultId)
                             select phr);

                var maxPriorityValue = query.Select(q => q.InQueuePriority).Max() + 1;

                query = from q in query
                        join a in linqMetaData.EventCustomers on q.EventCustomerResultId equals
                                 a.EventCustomerId
                        join ea in linqMetaData.EventAppointment on a.AppointmentId equals
                            ea.AppointmentId
                        join e in linqMetaData.Events on a.EventId equals e.EventId
                        orderby q.CriticalMarkedByTechnician descending, (q.InQueuePriority == 0 ? maxPriorityValue : q.InQueuePriority) ascending, q.SentBackatOverread descending, e.EventDate, e.EventId, ea.StartTime, q.UpdatedOn
                        select q;

                var resultsFromEventAssignment = query.ToArray();
                resultsFromEventAssignment = resultsFromEventAssignment.Where(ec => ec.OverreadPhysicianId == physicianId && validEventCustomeridsforPhysician.Contains(ec.EventCustomerResultId)).ToArray();

                var criticalPatientCount = resultsFromEventAssignment.Count(ea => ea.CriticalMarkedByTechnician);
                var priorityInQueueCount = resultsFromEventAssignment.Count(ea => ea.InQueuePriority > 0);

                return new PhysicianEvaluationQueueSummary
                {
                    ItemsAvailable = resultsFromEventAssignment.Length,
                    ItemsDone = 0,
                    CriticalsInQueue = criticalPatientCount,
                    PriorityInQueueCount = priorityInQueueCount,
                    FirstItemInTheQueue = resultsFromEventAssignment.Select(phr => phr.EventCustomerResultId).FirstOrDefault()
                };
            }
        }

        public long GetOverreadPhysician(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var customerAssignment = (from ce in linqMetaData.PhysicianCustomerAssignment
                                          where ce.EventCustomerId == eventCustomerId && ce.IsActive
                                          select ce).FirstOrDefault();

                if (customerAssignment == null)
                {
                    var eventAssignment = (from pe in linqMetaData.PhysicianEventAssignment
                                           join ec in linqMetaData.EventCustomers on pe.EventId equals ec.EventId
                                           where ec.EventCustomerId == eventCustomerId && pe.IsActive
                                           select pe).FirstOrDefault();

                    if (eventAssignment != null)
                        return eventAssignment.OverReadPhysicianId ?? 0;
                }
                else
                {
                    return customerAssignment.OverReadPhysicianId ?? 0;
                }

                return 0;
            }
        }

        private IEnumerable<long> GetValidEventCustomerResultIdsforPhysician(long physicianId, bool forOverread = false)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var physicianStates =
                    (from pl in linqMetaData.PhysicianLicense where pl.PhysicianId == physicianId && pl.IsActive && pl.ExpiryDate > DateTime.Now select pl.StateId).
                        ToArray();

                if (physicianStates.Count() < 1) return new List<long>();

                var physicianCutOffDate =
                    (from p in linqMetaData.PhysicianProfile where p.PhysicianId == physicianId select p.CutOffDate).
                        SingleOrDefault();

                var dateToCompareWith = physicianCutOffDate ?? DateTime.Now;

                return (from ecr in linqMetaData.VwPhysicianQueueRecord
                        join e in linqMetaData.Events on ecr.EventId equals e.EventId
                        join eh in linqMetaData.HostEventDetails on e.EventId equals eh.EventId
                        join p in linqMetaData.Prospects on eh.HostId equals p.ProspectId
                        join ad in linqMetaData.Address on p.AddressId equals ad.AddressId
                        where physicianStates.Contains(ad.StateId) && ecr.IsAtOverreadState == forOverread
                        && (physicianCutOffDate != null ? e.EventDate.Date >= dateToCompareWith.Date : true)
                        select ecr.EventCustomerResultId).ToArray();
            }
        }

        public IEnumerable<PhysicianQueueListItem> GetQueueforFilter(int pageNumber, int pageSize, PhysicianQueueListModelFilter filter, out int totalRecords)
        {
            totalRecords = 0;
            if (filter == null)
            {
                return null;
            }

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = from phr in linqMetaData.VwPhysicianQueueRecord
                            where (filter.PhysicianId > 0 ? (filter.PhysicianId == (filter.RecordsforPrimaryEval ? phr.PhysicianId : phr.OverreadPhysicianId)) : true)
                                    && phr.IsAtOverreadState != filter.RecordsforPrimaryEval && (filter.ShowOnlyCritical ? phr.CriticalMarkedByTechnician == true : true)
                            select phr;

                if (filter.EventId > 0)
                {
                    query = from phr in query where phr.EventId == filter.EventId select phr;
                }
                else
                {
                    var eventQuery = from e in linqMetaData.Events where (filter.IsPublicEvent ? e.EventTypeId == (long)RegistrationMode.Public : (filter.IsPrivateEvent ? e.EventTypeId == (long)RegistrationMode.Private : true)) select e;

                    if (filter.DateType == (int)PhysicianQueueDateTypeFilter.EventDate)
                    {
                        if (filter.FromDate.HasValue)
                            eventQuery = eventQuery.Where(q => q.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            eventQuery = eventQuery.Where(q => q.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }
                    else if (filter.DateType == (int)PhysicianQueueDateTypeFilter.PreAuditDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.UpdatedOn >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.UpdatedOn < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    if (filter.PodId > 0)
                    {
                        eventQuery = from e in eventQuery
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     where ep.IsActive && ep.PodId == filter.PodId
                                     select e;
                    }

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                        eventQuery = eventQuery.Where(q => !eventIds.Contains(q.EventId));
                    }
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                        eventQuery = eventQuery.Where(q => eventIds.Contains(q.EventId));
                    }

                    query =
                        query.Where(q => eventQuery.Where(e => e.IsActive).Select(e => e.EventId).Contains(q.EventId));

                }

                var maxPriorityValue = query.Select(q => q.InQueuePriority).Max() + 1;
                totalRecords = query.Count();
                var entities = (filter.RecordsforPrimaryEval ?
                                    (from q in query
                                     join ec in linqMetaData.EventCustomers on q.EventCustomerResultId equals ec.EventCustomerId
                                     join e in linqMetaData.Events on q.EventId equals e.EventId
                                     join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                     orderby (q.InQueuePriority == 0 ? maxPriorityValue : q.InQueuePriority), q.CriticalMarkedByTechnician descending, q.SentBackatPrimaryEval descending, e.EventDate, e.EventId, ea.StartTime, q.UpdatedOn
                                     select q)
                                    :
                                    (from q in query
                                     join ec in linqMetaData.EventCustomers on q.EventCustomerResultId equals ec.EventCustomerId
                                     join e in linqMetaData.Events on q.EventId equals e.EventId
                                     join ea in linqMetaData.EventAppointment on ec.AppointmentId equals ea.AppointmentId
                                     orderby (q.InQueuePriority == 0 ? maxPriorityValue : q.InQueuePriority), q.CriticalMarkedByTechnician descending, q.SentBackatOverread descending, e.EventDate, e.EventId, ea.StartTime, q.UpdatedOn
                                     select q)
                                ).TakePage(pageNumber, pageSize).ToArray();

                return entities.Select(m =>
                        new PhysicianQueueListItem
                            {
                                EventCustomerId = m.EventCustomerResultId,
                                LastUpdatedOn = m.UpdatedOn,
                                CriticalMarkedByTechnician = m.CriticalMarkedByTechnician,
                                ResultSummary = m.ResultSummary,
                                PhysicianId = filter.RecordsforPrimaryEval ? m.PhysicianId : m.OverreadPhysicianId,
                                SentBackbyOverread = m.SentBackatOverread,
                                SentBackbyPrimaryEval = m.SentBackatPrimaryEval,
                                InQueuePriority = m.InQueuePriority
                            });
            }
        }

        public bool IsValidPhysicianAssignmentForEvent(long physicianId, long? overReadPhysicianId, long eventId)
        {
            var testIds = GetReviewableTestIdsForEvent(eventId);

            var physicianTestIds = GetPermittedTestIdsForPhysician(physicianId).ToList();

            if (overReadPhysicianId.HasValue)
            {
                var overReadPhysicianTestIds = GetPermittedTestIdsForPhysician(overReadPhysicianId.Value).ToList();

                physicianTestIds.AddRange(overReadPhysicianTestIds);
            }

            return testIds.All(physicianTestIds.Contains);
        }

        public bool IsValidPhysicianAssignmentForEventCustomer(long physicianId, long? overReadPhysicianId, long eventCustomerId)
        {
            var testIds = GetReviewableTestIdsForEventCustomer(eventCustomerId);

            var physicianTestIds = GetPermittedTestIdsForPhysician(physicianId).ToList();

            if (overReadPhysicianId.HasValue)
            {
                var overReadPhysicianTestIds = GetPermittedTestIdsForPhysician(overReadPhysicianId.Value).ToList();

                physicianTestIds.AddRange(overReadPhysicianTestIds);
            }

            return testIds.All(physicianTestIds.Contains);
        }

        public IEnumerable<long> GetPermittedTestIdsForPhysician(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var testIds = (from pt in linqMetaData.PhysicianPermittedTest
                               where pt.OrganizationRoleUserId == physicianId
                               select pt.TestId).ToList();

                return testIds;
            }
        }

        public bool IsDefaultPhysicianAssignedForStates(IEnumerable<long> stateIds, long currentPhysicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var physicianIds = from p in linqMetaData.PhysicianProfile
                                   where p.IsDefaultPhysician && p.PhysicianId != currentPhysicianId
                                   select p.PhysicianId;
                if (physicianIds.Count() == 0)
                    return false;

                foreach (var physicianId in physicianIds)
                {
                    var licenseStateIds = (from pl in linqMetaData.PhysicianLicense
                                           where pl.PhysicianId == physicianId && pl.IsActive
                                           select pl.StateId).ToList();
                    if (stateIds.All(licenseStateIds.Contains))
                        return true;
                }
            }
            return false;
        }

        public long GetDefaultPhysicianforEvent(long eventId)
        {
            using (var adpater = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adpater);

                var eventState = (from eh in linqMetaData.HostEventDetails
                                  join p in linqMetaData.Prospects on eh.HostId equals p.ProspectId
                                  join ad in linqMetaData.Address on p.AddressId equals ad.AddressId
                                  where eh.EventId == eventId
                                  select ad.StateId).SingleOrDefault();


                var physicianWithEventState = (from p in linqMetaData.PhysicianProfile
                                               join pl in linqMetaData.PhysicianLicense on p.PhysicianId equals
                                                   pl.PhysicianId
                                               where p.IsDefaultPhysician && pl.StateId == eventState && pl.ExpiryDate > DateTime.Now
                                               select p.PhysicianId).FirstOrDefault();

                return physicianWithEventState;
            }
        }

        public int GetReviewsCountByPhysicianId(long physicianId, PhysicianReviewSummaryListModelFilter filter, bool isReEvelaued)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from q in
                                            (from pe in linqMetaData.PhysicianEvaluation
                                             where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator
                                             group pe by pe.EventCustomerId
                                                 into g
                                                 select new { EventCustomerId = g.Key, Count = g.Count() })
                                        where q.Count == 1
                                        select q.EventCustomerId);

                var reEvaluatedEventCustomerIds = (from q in
                                                       (from pe in linqMetaData.PhysicianEvaluation
                                                        where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator
                                                        group pe by pe.EventCustomerId
                                                            into g
                                                            select new { EventCustomerId = g.Key, Count = g.Count() })
                                                   where q.Count > 1
                                                   select q.EventCustomerId);
                if (filter == null)
                {
                    filter = new PhysicianReviewSummaryListModelFilter();
                }

                if (filter.IsBlank())
                {
                    return isReEvelaued ? reEvaluatedEventCustomerIds.Count() : eventCustomerIds.Count();
                    //return (from pe in linqMetaData.PhysicianEvaluation where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator select pe).Count();
                }

                if (filter.EventId > 0)
                {
                    return (from pe in linqMetaData.PhysicianEvaluation
                            join ecr in linqMetaData.EventCustomerResult on pe.EventCustomerId equals
                                ecr.EventCustomerResultId
                            where pe.PhysicianId == physicianId && ecr.EventId == filter.EventId
                                  && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator
                                  && isReEvelaued ? reEvaluatedEventCustomerIds.Contains(pe.EventCustomerId) : eventCustomerIds.Contains(pe.EventCustomerId)
                            select pe.EventCustomerId).Distinct().Count();
                }

                var query = (from pe in linqMetaData.PhysicianEvaluation
                             where pe.PhysicianId == physicianId
                                   && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator
                                   && isReEvelaued ? reEvaluatedEventCustomerIds.Contains(pe.EventCustomerId) : eventCustomerIds.Contains(pe.EventCustomerId)
                             select pe);

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    query = (from pe in query where (filter.FromDate != null ? pe.EvaluationStartTime >= fromDate : true) && (filter.ToDate != null ? pe.EvaluationStartTime < toDate : true) select pe);
                }

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate || filter.PodId > 0 || filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    var eventQuery = (from e in linqMetaData.Events where (filter.FromDate != null ? e.EventDate >= fromDate : true) && (filter.ToDate != null ? e.EventDate < toDate : true) select e);
                    if (filter.PodId > 0)
                    {
                        eventQuery = from e in eventQuery
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     where ep.IsActive && ep.PodId == filter.PodId
                                     select e;
                    }

                    if (filter.IsRetailEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         !(from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }

                    if (filter.IsCorporateEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         (from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }
                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Private);

                    query = from q in query
                            join ecr in linqMetaData.EventCustomerResult on q.EventCustomerId equals
                                ecr.EventCustomerResultId
                            join e in eventQuery on ecr.EventId equals e.EventId
                            select q;
                }

                return (from q in query select q.EventCustomerId).Distinct().Count();
            }
        }

        public int GetOverReadsCountByPhysicianId(long physicianId, PhysicianReviewSummaryListModelFilter filter, bool isReEvelaued)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventCustomerIds = (from q in
                                            (from pe in linqMetaData.PhysicianEvaluation
                                             where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator == false
                                             group pe by pe.EventCustomerId
                                                 into g
                                                 select new { EventCustomerId = g.Key, Count = g.Count() })
                                        where q.Count == 1
                                        select q.EventCustomerId);

                var reEvaluatedEventCustomerIds = (from q in
                                                       (from pe in linqMetaData.PhysicianEvaluation
                                                        where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator == false
                                                        group pe by pe.EventCustomerId
                                                            into g
                                                            select new { EventCustomerId = g.Key, Count = g.Count() })
                                                   where q.Count > 1
                                                   select q.EventCustomerId);

                if (filter == null)
                {
                    filter = new PhysicianReviewSummaryListModelFilter();
                }

                if (filter.IsBlank())
                {
                    return isReEvelaued ? reEvaluatedEventCustomerIds.Count() : eventCustomerIds.Count();
                    //return (from pe in linqMetaData.PhysicianEvaluation where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator == false select pe).Count();
                }

                if (filter.EventId > 0)
                {
                    return (from pe in linqMetaData.PhysicianEvaluation
                            join ecr in linqMetaData.EventCustomerResult on pe.EventCustomerId equals
                                ecr.EventCustomerResultId
                            where pe.PhysicianId == physicianId && ecr.EventId == filter.EventId
                                  && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator == false
                                  && isReEvelaued ? reEvaluatedEventCustomerIds.Contains(pe.EventCustomerId) : eventCustomerIds.Contains(pe.EventCustomerId)
                            select pe.EventCustomerId).Distinct().Count();
                }

                var query = (from pe in linqMetaData.PhysicianEvaluation
                             where pe.PhysicianId == physicianId
                                   && pe.EvaluationEndTime.HasValue && pe.IsPrimaryEvaluator == false
                                   && isReEvelaued ? reEvaluatedEventCustomerIds.Contains(pe.EventCustomerId) : eventCustomerIds.Contains(pe.EventCustomerId)
                             select pe);

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    query = (from pe in query where (filter.FromDate != null ? pe.EvaluationStartTime >= fromDate : true) && (filter.ToDate != null ? pe.EvaluationStartTime < toDate : true) select pe);
                }

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate || filter.PodId > 0 || filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    var eventQuery = (from e in linqMetaData.Events where (filter.FromDate != null ? e.EventDate >= fromDate : true) && (filter.ToDate != null ? e.EventDate < toDate : true) select e);
                    if (filter.PodId > 0)
                    {
                        eventQuery = from e in eventQuery
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     where ep.IsActive && ep.PodId == filter.PodId
                                     select e;
                    }

                    if (filter.IsRetailEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         !(from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }

                    if (filter.IsCorporateEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         (from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }

                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Private);

                    query = from q in query
                            join ecr in linqMetaData.EventCustomerResult on q.EventCustomerId equals
                                ecr.EventCustomerResultId
                            join e in eventQuery on ecr.EventId equals e.EventId
                            select q;
                }

                return (from q in query select q.EventCustomerId).Distinct().Count();
            }
        }

        public int GetAvailablePrimaryEvaluationCountByPhysicianId(long physicianId)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.VwPhysicianQueueRecord.Where(q => q.PhysicianId == physicianId && q.IsAtOverreadState == false).Count();
            }

        }

        public int GetAvailableOverReadEvaluationCountByPhysicianId(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.VwPhysicianQueueRecord.Where(q => q.OverreadPhysicianId == physicianId && q.IsAtOverreadState).Count();
            }

        }

        public int GetPriorityPrimaryEvaluationCountByPhysicianId(long physicianId)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.VwPhysicianQueueRecord.Count(q => q.PhysicianId == physicianId && q.IsAtOverreadState == false && q.InQueuePriority > 0);
            }

        }

        public int GetPriorityOverReadEvaluationCountByPhysicianId(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                return linqMetaData.VwPhysicianQueueRecord.Count(q => q.OverreadPhysicianId == physicianId && q.IsAtOverreadState && q.InQueuePriority > 0);
            }

        }

        public bool IsPhysicianAssignedForFutureEvent(long physicianId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var isPhysicianAssigned = (from pea in linqMetaData.PhysicianEventAssignment
                                           join e in linqMetaData.Events on pea.EventId equals e.EventId
                                           where (pea.PhysicianId == physicianId || pea.OverReadPhysicianId == physicianId) && pea.IsActive && e.EventDate > DateTime.Today.AddDays(-1)
                                           select pea.PhysicianId).Any();
                if (isPhysicianAssigned)
                    return true;

                isPhysicianAssigned = (from pca in linqMetaData.PhysicianCustomerAssignment
                                       join ecr in linqMetaData.EventCustomers on pca.EventCustomerId equals ecr.EventCustomerId
                                       join e in linqMetaData.Events on ecr.EventId equals e.EventId
                                       where (pca.PhysicianId == physicianId || pca.OverReadPhysicianId == physicianId) && pca.IsActive && e.EventDate > DateTime.Today.AddDays(-1)
                                       select pca.PhysicianId).Any();

                return isPhysicianAssigned;
            }
        }

        public IEnumerable<PhysicianEventQueueListItem> GetEventQueueforFilter(int pageNumber, int pageSize, PhysicianEventQueueListModelFilter filter, out int totalRecords)
        {
            totalRecords = 0;
            if (filter == null)
            {
                return null;
            }

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var query = from phr in linqMetaData.VwPhysicianQueueRecord
                            where (filter.PhysicianId > 0 ? (filter.PhysicianId == (filter.RecordsforPrimaryEval ? phr.PhysicianId : phr.OverreadPhysicianId)) : true)
                                    && phr.IsAtOverreadState != filter.RecordsforPrimaryEval && (filter.ShowOnlyCritical ? phr.CriticalMarkedByTechnician : true)
                            select phr;

                if (filter.EventId > 0)
                {
                    query = from phr in query where phr.EventId == filter.EventId select phr;
                }
                else
                {
                    var eventQuery = from e in linqMetaData.Events where (filter.IsPublicEvent ? e.EventTypeId == (long)RegistrationMode.Public : (filter.IsPrivateEvent ? e.EventTypeId == (long)RegistrationMode.Private : true)) select e;

                    if (filter.DateType == (int)PhysicianQueueDateTypeFilter.EventDate)
                    {
                        if (filter.FromDate.HasValue)
                            eventQuery = eventQuery.Where(q => q.EventDate >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            eventQuery = eventQuery.Where(q => q.EventDate < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }
                    else if (filter.DateType == (int)PhysicianQueueDateTypeFilter.PreAuditDate)
                    {
                        if (filter.FromDate.HasValue)
                            query = query.Where(q => q.UpdatedOn >= filter.FromDate.Value);

                        if (filter.ToDate.HasValue)
                            query = query.Where(q => q.UpdatedOn < filter.ToDate.Value.AddHours(23).AddMinutes(59));
                    }

                    if (filter.PodId > 0)
                    {
                        eventQuery = from e in eventQuery
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     where ep.IsActive && ep.PodId == filter.PodId
                                     select e;
                    }

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                        eventQuery = eventQuery.Where(q => !eventIds.Contains(q.EventId));
                    }
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                    {
                        var eventIds = (from ea in linqMetaData.EventAccount select ea.EventId);
                        eventQuery = eventQuery.Where(q => eventIds.Contains(q.EventId));
                    }

                    query =
                        query.Where(q => eventQuery.Where(e => e.IsActive).Select(e => e.EventId).Contains(q.EventId));

                }



                if (filter.RecordsforPrimaryEval)
                {
                    var eventQueueQuery = (from q in query
                                           join e in linqMetaData.Events on q.EventId equals e.EventId
                                           group q by new { q.EventId, q.PhysicianId, e.EventDate }
                                               into g
                                               select new { g.Key.EventId, g.Key.PhysicianId, g.Key.EventDate, CustomersCount = g.Count() }).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = eventQueueQuery.Count();
                    var entities = eventQueueQuery.TakePage(pageNumber, pageSize).ToArray();

                    return entities.Select(m => new PhysicianEventQueueListItem
                                                    {
                                                        EventId = m.EventId,
                                                        PhysicianId = m.PhysicianId,
                                                        CustomersInQueue = m.CustomersCount
                                                    }).ToArray();
                }
                else
                {
                    var eventQueueQuery = (from q in query
                                           join e in linqMetaData.Events on q.EventId equals e.EventId
                                           group q by new { q.EventId, q.OverreadPhysicianId, e.EventDate }
                                               into g
                                               select new { g.Key.EventId, g.Key.OverreadPhysicianId, g.Key.EventDate, CustomersCount = g.Count() }).OrderBy(e => e.EventDate).ThenBy(e => e.EventId);

                    totalRecords = eventQueueQuery.Count();
                    var entities = eventQueueQuery.TakePage(pageNumber, pageSize).ToArray();

                    return entities.Select(m => new PhysicianEventQueueListItem
                                                    {
                                                        EventId = m.EventId,
                                                        PhysicianId = m.OverreadPhysicianId,
                                                        CustomersInQueue = m.CustomersCount
                                                    }).ToArray();
                }

            }
        }

        public PhysicianTestReviewStats GetTestReviewedCountPairsByPhysicianId(long physicianId, PhysicianTestReviewListModelFilter filter)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var eventcustomerIds = (from pe in linqMetaData.PhysicianEvaluation
                                        where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue
                                        select pe.EventCustomerId);
                if (filter == null)
                {
                    filter = new PhysicianTestReviewListModelFilter();
                }

                if (filter.IsBlank())
                {
                    var testCountPairs = (from cest in linqMetaData.CustomerEventScreeningTests
                                          where eventcustomerIds.Contains(cest.EventCustomerResultId)
                                          group cest by cest.TestId
                                              into g
                                              select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
                    return new PhysicianTestReviewStats
                    {
                        PhysicianId = physicianId,
                        TestCountPairs = testCountPairs
                    };
                }

                if (filter.EventId > 0)
                {
                    var testCountPairs = (from ecr in linqMetaData.EventCustomerResult
                                          join cest in linqMetaData.CustomerEventScreeningTests on ecr.EventCustomerResultId equals cest.EventCustomerResultId
                                          where eventcustomerIds.Contains(cest.EventCustomerResultId)
                                          && ecr.EventId == filter.EventId
                                          group cest by cest.TestId
                                              into g
                                              select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
                    return new PhysicianTestReviewStats
                    {
                        PhysicianId = physicianId,
                        TestCountPairs = testCountPairs
                    };
                }

                var query = (from pe in linqMetaData.PhysicianEvaluation
                             where pe.PhysicianId == physicianId && pe.EvaluationEndTime.HasValue
                             select pe);

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EvaluationDate)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    query = (from pe in query where (filter.FromDate != null ? pe.EvaluationStartTime >= fromDate : true) && (filter.ToDate != null ? pe.EvaluationStartTime < toDate : true) select pe);
                }

                if (filter.DateType == (int)PhysicianReviewDateTypeFilter.EventDate || filter.PodId > 0 || filter.IsRetailEvent || filter.IsCorporateEvent || filter.IsPublicEvent || filter.IsPrivateEvent)
                {
                    var fromDate = filter.FromDate.HasValue ? filter.FromDate.Value : DateTime.Now;
                    var toDate = filter.ToDate.HasValue ? filter.ToDate.Value.AddHours(23).AddMinutes(59) : DateTime.Now;

                    var eventQuery = (from e in linqMetaData.Events where (filter.FromDate != null ? e.EventDate >= fromDate : true) && (filter.ToDate != null ? e.EventDate < toDate : true) select e);
                    if (filter.PodId > 0)
                    {
                        eventQuery = from e in eventQuery
                                     join ep in linqMetaData.EventPod on e.EventId equals ep.EventId
                                     where ep.IsActive && ep.PodId == filter.PodId
                                     select e;
                    }

                    if (filter.IsRetailEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         !(from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }

                    if (filter.IsCorporateEvent)
                    {
                        eventQuery = from e in eventQuery
                                     where
                                         (from ea in linqMetaData.EventAccount select ea.EventId).Contains(e.EventId)
                                     select e;
                    }
                    if (filter.IsPublicEvent && !filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Public);
                    else if (!filter.IsPublicEvent && filter.IsPrivateEvent)
                        eventQuery = eventQuery.Where(q => q.EventTypeId == (long)RegistrationMode.Private);

                    eventcustomerIds = (from q in query
                                        join ecr in linqMetaData.EventCustomerResult on q.EventCustomerId equals ecr.EventCustomerResultId
                                        join e in eventQuery on ecr.EventId equals e.EventId
                                        select q.EventCustomerId);

                    var testCountPairs = (from cest in linqMetaData.CustomerEventScreeningTests
                                          where eventcustomerIds.Contains(cest.EventCustomerResultId)
                                          group cest by cest.TestId
                                              into g
                                              select new OrderedPair<long, int>(g.Key, g.Count())).ToList();

                    return new PhysicianTestReviewStats
                    {
                        PhysicianId = physicianId,
                        TestCountPairs = testCountPairs
                    };
                }
                else
                {
                    eventcustomerIds = (from q in query select q.EventCustomerId);

                    var testCountPairs = (from cest in linqMetaData.CustomerEventScreeningTests
                                          where eventcustomerIds.Contains(cest.EventCustomerResultId)
                                          group cest by cest.TestId
                                              into g
                                              select new OrderedPair<long, int>(g.Key, g.Count())).ToList();
                    return new PhysicianTestReviewStats
                    {
                        PhysicianId = physicianId,
                        TestCountPairs = testCountPairs
                    };
                }
            }

        }

        public bool IsValidPhysicianAssignmentForRestrictedEvaluationOnEvent(long eventId, IEnumerable<PhsicianEventTestViewModel> selectedTests)
        {
            var physicianTestIds = selectedTests.Select(x => x.TestId).ToList();

            var testIds = GetReviewableTestIdsForEvent(eventId);

            return testIds.All(physicianTestIds.Contains);
        }
    }
}
