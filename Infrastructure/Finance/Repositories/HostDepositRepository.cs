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
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Queryable = System.Linq.Queryable;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    public class HostDepositRepository : PersistenceRepository, IHostDeositRepository
    {
        private readonly IHostDepositFactory _hostDepositFactory;
        private readonly IAddressRepository _addressRepository;

        public HostDepositRepository()
        {
            _hostDepositFactory = new HostDepositFactory();
            _addressRepository = new AddressRepository();
        }

        public HostDepositRepository(IPersistenceLayer persistenceLayer, IHostDepositFactory hostDepositFactory, IAddressRepository addressRepository)
            : base(persistenceLayer)
        {
            _hostDepositFactory = hostDepositFactory;
            _addressRepository = addressRepository;
        }

        public HostDeposit GetById(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostPayment = Queryable.FirstOrDefault<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                     prefetchPath.Prefetch(path => path.Address).Prefetch(path => path.HostPaymentTransaction)).Where(
                                                                                                                                         hp => hp.EventId == eventId && hp.IsDeposit));


                if (hostPayment == null)
                {
                    throw new ObjectNotFoundInPersistenceException<HostPayment>(eventId);
                }
                var address = _addressRepository.GetAddress(hostPayment.MailingAddressId.Value);

                return _hostDepositFactory.CreateHostDeposit(hostPayment, address);
            }
        }
        
        public HostDeposit GetByHostDepositById(long hostDepositId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostPayment = Queryable.FirstOrDefault<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                                 prefetchPath.Prefetch(path => path.Address).Prefetch(path => path.HostPaymentTransaction)).Where(
                                                                                                                                                     hp => hp.HostPaymentId == hostDepositId && hp.IsDeposit));
                if (hostPayment == null)
                {
                    throw new ObjectNotFoundInPersistenceException<HostPayment>(hostDepositId);
                }
                var address = _addressRepository.GetAddress(hostPayment.MailingAddressId.Value);

                return _hostDepositFactory.CreateHostDeposit(hostPayment, address);
            }
        }
        public List<HostDeposit> GetByFilters(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate, HostPaymentStatus? hostPaymentStatus)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var hostDeposit =
                    linqMetaData.HostPayment.Join(
                        linqMetaData.Events, @t => @t.EventId, e => e.EventId,
                        (@t, e) => new { HostPayment = @t, EventActive = e.IsActive }).Where(
                        @t => @t.HostPayment.IsDeposit && @t.EventActive).Select(hp => hp.HostPayment).ToList();

                hostDeposit = hostDeposit.Where(hp =>
                                                  (hp.IsActive) &&
                                                  (!eventId.HasValue || hp.EventId == eventId) &&
                                                  (!dueStartDate.HasValue || dueStartDate <= hp.DueDate) &&
                                                  (!dueEndDate.HasValue || dueEndDate >= hp.DueDate) &&
                                                  (!hostPaymentStatus.HasValue ||
                                                   (long)hostPaymentStatus == hp.Status.Value))
                    .ToList();

                List<HostPaymentEntity> entities = hostDeposit;
                hostDeposit = Enumerable.ToList<HostPaymentEntity>(linqMetaData.HostPayment.WithPath(prefetchPath =>
                                                                                                                                                        prefetchPath.Prefetch(path => path.Address).Prefetch
                                                                                                                                                            (path => path.HostPaymentTransaction)).Where(
                                                                                                                                                                hp => entities.Select(h => h.HostPaymentId).Contains(hp.HostPaymentId)));

                var addresses = _addressRepository.GetAddresses(hostDeposit.Select(hp => hp.MailingAddressId.Value).ToList());

                return
                   hostDeposit.Select(
                       hp =>
                       _hostDepositFactory.CreateHostDeposit(hp,
                                                             addresses.SingleOrDefault(a => a.Id == hp.MailingAddressId)))
                       .ToList();
            }
        }

        public HostDeposit Save(HostDeposit hostDeposit)
        {
            NullArgumentChecker.CheckIfNull(hostDeposit, "hostDeposit");

            var hostPaymentEntity = _hostDepositFactory.CreateHostPayment(hostDeposit);

            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!myAdapter.SaveEntity(hostPaymentEntity, true))
                {
                    throw new PersistenceFailureException();
                }
                var address = _addressRepository.GetAddress(hostPaymentEntity.MailingAddressId.Value);
                return _hostDepositFactory.CreateHostDeposit(hostPaymentEntity, address);
            }
        }
    }
}
