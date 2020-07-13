using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Order;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class EventAppointmentAggregateRepository : PersistenceRepository, IEventAppointmentAggregateRepository
    {
        private readonly IMapper<Event, EventsEntity> _eventMapper;
        private readonly IEventPackageRepository _packageRepository;
        private readonly IEventTestRepository _testRepository;
        private readonly IMapper<Appointment, EventAppointmentEntity> _appointmentMapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public EventAppointmentAggregateRepository()
            : this(new SqlPersistenceLayer(), new EventMapper(), new EventPackageRepository(), 
            new AppointmentMapper(), new CustomerRepository(),new EventTestRepository(), new OrderRepository())
        { }

        public EventAppointmentAggregateRepository(IPersistenceLayer persistenceLayer, 
            IMapper<Event, EventsEntity> eventMapper, IEventPackageRepository packageRepository, 
            IMapper<Appointment, EventAppointmentEntity> appointmentMapper,
            ICustomerRepository customerRepository, IEventTestRepository testRepository, IOrderRepository orderRepository)
            : base(persistenceLayer)
        {
            _eventMapper = eventMapper;
            _testRepository = testRepository;
            _appointmentMapper = appointmentMapper;
            _packageRepository = packageRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        public IEnumerable<EventAppointmentAggregate> GetEventAppointmentAggregates(IEnumerable<long> appointmentsIds)
        {
            var appointmentAggregates = new List<EventAppointmentAggregate>();

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);

                var ecustomers =
                    linqMetaData.EventCustomers.WithPath(
                        path => path.Prefetch(ec => ec.Events).Prefetch(ec => ec.EventAppointment))
                        .Where(ec => ec.AppointmentId.HasValue && appointmentsIds.Contains(ec.AppointmentId.Value)).
                        ToArray();

                foreach (var record in ecustomers)
                {
                    var orderId = _orderRepository.GetOrderIdByEventIdCustomerId(record.EventId, record.CustomerId);
                    var package = _packageRepository.GetPackageForOrder(orderId);
                    var tests = _testRepository.GetTestsForOrder(orderId);

                    var packageAndTests = package != null ? package.Package.Name : string.Empty;
                    packageAndTests += tests.IsNullOrEmpty()
                                           ? string.Empty
                                           : !string.IsNullOrEmpty(packageAndTests)
                                                 ? ", " + string.Join(", ", tests.Select(t => t.Test.Name).ToArray())
                                                 : string.Join(", ", tests.Select(t => t.Test.Name).ToArray());


                    appointmentAggregates.Add(new EventAppointmentAggregate
                    {
                        Appointment =
                            _appointmentMapper.Map(record.EventAppointment),
                        AppointmentBookedFor =
                            _customerRepository.GetCustomer(record.CustomerId),
                        Event = _eventMapper.Map(record.Events),
                        PackageAndTests = packageAndTests
                    });
                }

                return appointmentAggregates;

                #region "Dead Code"


                //var eventCustomers =
                //    linqMetaData.EventCustomers.Where(
                //        ec => ec.AppointmentId.HasValue && appointmentsIds.Contains(ec.AppointmentId.Value)).ToArray();

                //// TODO: This query has to be fixed.
                //var eventCustomerPackageDetails =
                //    eventCustomers.Select(ec => new
                //                                    {
                //                                        EventCustomerAppointmentId = ec.AppointmentId,
                //                                        EventCustomerEventId = ec.EventId,
                //                                        EventCustomerCustomerId = ec.CustomerId,
                //                                    }).ToList();

                //var eventAppointmentPackageDetails =
                //    eventCustomerPackageDetails.Join(linqMetaData.Events, @t => @t.EventCustomerEventId, e => e.EventId,
                //                                     (@t, e) =>
                //                                     new
                //                                         {
                //                                             @t.EventCustomerAppointmentId,
                //                                             @t.EventCustomerCustomerId,
                //                                             e
                //                                         }).Join(linqMetaData.EventAppointment,
                //                                                 @t => @t.EventCustomerAppointmentId,
                //                                                 ea => ea.AppointmentId,
                //                                                 (@t, ea) =>
                //                                                 new
                //                                                     {
                //                                                         @t.EventCustomerAppointmentId,
                //                                                         @t.EventCustomerCustomerId,
                //                                                         @t.e,
                //                                                         ea
                //                                                     }).ToList();

                //var eventAppointmentPackageForCustomer =
                //    eventAppointmentPackageDetails.Join(linqMetaData.CustomerProfile, @t => @t.EventCustomerCustomerId,
                //                                        c => c.CustomerId, (@t, c) => new { @t, c }).Select(
                //        @t =>
                //        new
                //            {
                //                Appointments = @t.t.ea,
                //                Events = @t.t.e,
                //                Customers = @t.c,
                //                @t.t.EventCustomerAppointmentId
                //            }).ToList();

                //eventAppointmentPackageForCustomer =
                //    eventAppointmentPackageForCustomer.Where(
                //        @t => appointmentsIds.Contains(@t.Appointments.AppointmentId)).ToList();

                //foreach (var appointmentPackageForCustomer in eventAppointmentPackageForCustomer)
                //{
                //    var package = _packageRepository.GetPackageForOrder(appointmentPackageForCustomer.Events.EventId,
                //                                                        appointmentPackageForCustomer.Customers.
                //                                                            CustomerId);
                //    var tests = _testRepository.GetTestsForOrder(appointmentPackageForCustomer.Events.EventId,
                //                                                 appointmentPackageForCustomer.Customers.
                //                                                     CustomerId);
                //    var packageAndTests = package != null ? package.Name : string.Empty;

                //    packageAndTests += tests.IsNullOrEmpty()
                //                           ? string.Empty
                //                           : !string.IsNullOrEmpty(packageAndTests)
                //                                 ? ", " + string.Join(", ", tests.Select(t => t.Name).ToArray())
                //                                 : string.Join(", ", tests.Select(t => t.Name).ToArray());


                //    appointmentAggregates.Add(new EventAppointmentAggregate
                //                                  {
                //                                      Appointment =
                //                                          _appointmentMapper.Map(
                //                                          appointmentPackageForCustomer.Appointments),
                //                                      AppointmentBookedFor =
                //                                          _customerRepository.GetCustomer(
                //                                          appointmentPackageForCustomer.Customers.CustomerId),
                //                                      Event = _eventMapper.Map(appointmentPackageForCustomer.Events),
                //                                      PackageAndTests = packageAndTests
                //                                  });
                //}

                //return appointmentAggregates;
                #endregion
            }
        }
    }
}
