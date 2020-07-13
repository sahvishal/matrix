using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Factories.Hosts;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Queryable = System.Linq.Queryable;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    public class HostPaymentRepository : PersistenceRepository, IHostPaymentRepository
    {
        private readonly IHostPaymentFactory _hostPaymentFactory;
        private readonly IAddressRepository _addressRepository;

        public HostPaymentRepository()
        {
            _hostPaymentFactory = new HostPaymentFactory();
            _addressRepository = new AddressRepository();
        }

        public HostPaymentRepository(IPersistenceLayer persistenceLayer, IHostPaymentFactory hostPaymentFactory, IAddressRepository addressRepository)
            : base(persistenceLayer)
        {
            _hostPaymentFactory = hostPaymentFactory;
            _addressRepository = addressRepository;
        }


        public HostPayment GetById(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostPayment = Queryable.FirstOrDefault<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                      prefetchPath.Prefetch(path => path.Address).Prefetch
                                                                                                                                          (path => path.HostPaymentTransaction)).Where(
                                                                                                                                              hp => hp.EventId == eventId && !hp.IsDeposit));
                if (hostPayment == null)
                {
                    throw new ObjectNotFoundInPersistenceException<HostPayment>(eventId);
                }

                var address = _addressRepository.GetAddress(hostPayment.MailingAddressId.Value); return _hostPaymentFactory.CreateHostPayment(hostPayment, address);
            }
        }

        public HostPayment GetHostPaymentById(long hostPaymentId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostPayment = Queryable.FirstOrDefault<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                                  prefetchPath.Prefetch(path => path.Address).Prefetch(path => path.HostPaymentTransaction)).Where(
                                                                                                                                                      hp => hp.HostPaymentId == hostPaymentId && !hp.IsDeposit));
                if (hostPayment == null)
                {
                    throw new ObjectNotFoundInPersistenceException<HostPayment>(hostPaymentId);
                }
                var address = _addressRepository.GetAddress(hostPayment.MailingAddressId.Value);

                return _hostPaymentFactory.CreateHostPayment(hostPayment, address);
            }
        }

        public List<HostPayment> GetByFilters(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate, HostPaymentStatus? hostPaymentStatus)
        {

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostPayments =
                    linqMetaData.HostPayment.Join(
                        linqMetaData.Events, @t => @t.EventId, e => e.EventId,
                        (@t, e) => new { HostPayment = @t, EventActive = e.IsActive }).Where(
                        @t => !@t.HostPayment.IsDeposit && @t.EventActive).Select(hp => hp.HostPayment).ToList();

                hostPayments = hostPayments.Where(hp =>
                                                  (hp.IsActive) &&
                                                  (!eventId.HasValue || hp.EventId == eventId) &&
                                                  (!dueStartDate.HasValue || dueStartDate <= hp.DueDate) &&
                                                  (!dueEndDate.HasValue || dueEndDate >= hp.DueDate) &&
                                                  (!hostPaymentStatus.HasValue ||
                                                   (long)hostPaymentStatus == hp.Status.Value))
                    .ToList();

                List<HostPaymentEntity> entities = hostPayments;
                hostPayments = Enumerable.ToList<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                                        prefetchPath.Prefetch(path => path.Address).Prefetch
                                                                                                                                                            (path => path.HostPaymentTransaction)).Where(
                                                                                                                                                                hp => entities.Select(h => h.HostPaymentId).Contains(hp.HostPaymentId)));

                var addresses = _addressRepository.GetAddresses(hostPayments.Select(hp => hp.MailingAddressId.Value).ToList());

                return
                    hostPayments.Select(
                        hp =>
                        _hostPaymentFactory.CreateHostPayment(hp,
                                                              addresses.SingleOrDefault(a => a.Id == hp.MailingAddressId)))
                        .ToList();
            }
        }

        public HostPayment Save(HostPayment hostPayment)
        {
            NullArgumentChecker.CheckIfNull(hostPayment, "hostPayment");

            var hostPaymentEntity = _hostPaymentFactory.CreateHostPaymentEntity(hostPayment);

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(hostPaymentEntity, true))
                {
                    throw new PersistenceFailureException();
                }
                var address = _addressRepository.GetAddress(hostPaymentEntity.MailingAddressId.Value);
                return _hostPaymentFactory.CreateHostPayment(hostPaymentEntity, address);
            }
        }

        public bool UpdateHostPaymentStatusAndNotes(long hostPaymentId, decimal amount, int hostPaymentStatus)
        {

            var hostPayment = new HostPaymentEntity(hostPaymentId) { Status = hostPaymentStatus };
            IRelationPredicateBucket relationPredicateBucket =
                new RelationPredicateBucket(HostPaymentFields.HostPaymentId == hostPaymentId);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostPayment, relationPredicateBucket) > 0;
            }
        }
    }
}
