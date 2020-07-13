using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Finance.ViewModels;
using Falcon.App.Core.Impl;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.LinqSupportClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    [DefaultImplementation]
    public class ChargeCardPaymentRepository : PaymentInstrumentRepository<ChargeCardPayment, ChargeCardPaymentEntity>, IChargeCardPaymentRepository
    {
        public ChargeCardPaymentRepository()
            : this(new ChargeCardPaymentMapper(new DataRecorderMetaDataFactory()))
        { }

        public ChargeCardPaymentRepository(IMapper<ChargeCardPayment, ChargeCardPaymentEntity> mapper)
            : base(mapper)
        { }

        public ChargeCardPaymentRepository(IPersistenceLayer persistenceLayer,
            IMapper<ChargeCardPayment, ChargeCardPaymentEntity> mapper,
            RepositoryStrategySet<ChargeCardPayment> repositoryStrategySet)
            : base(persistenceLayer, mapper, repositoryStrategySet)
        { }

        protected override EntityField2 EntityIdField
        {
            get { return ChargeCardPaymentFields.ChargeCardPaymentId; }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return ChargeCardPaymentFields.PaymentId == paymentId;
        }

        public IEnumerable<ChargeCardPayment> Get(CreditCardReconcileModelFilter filter, int pageNumber, int pageSize, out int totalRecords)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                if (filter == null)
                {
                    var query = (from cp in linqMetaData.ChargeCardPayment
                                 join po in linqMetaData.PaymentOrder on cp.PaymentId equals po.PaymentId
                                 select cp);

                    totalRecords = query.Count();
                    var payments = query.OrderByDescending(cp => cp.DateCreated).TakePage(pageNumber, pageSize).ToArray();
                    return Mapper.MapMultiple(payments);
                }
                else
                {
                    var payments = (from cp in linqMetaData.ChargeCardPayment
                                    join po in linqMetaData.PaymentOrder on cp.PaymentId equals po.PaymentId
                                    select cp);

                    var query = (from ecs in linqMetaData.EventCustomers
                                 join ecod in linqMetaData.EventCustomerOrderDetail on ecs.EventCustomerId equals
                                     ecod.EventCustomerId
                                 join od in linqMetaData.OrderDetail on ecod.OrderDetailId equals od.OrderDetailId
                                 join po in linqMetaData.PaymentOrder on od.OrderId equals po.OrderId
                                 select new { po.PaymentId, ecs.EventId });


                    if (filter.FromDate.HasValue)
                        payments = payments.Where(cp => cp.DateCreated >= filter.FromDate.Value.Date);

                    if (filter.ToDate.HasValue)
                        payments = payments.Where(cp => cp.DateCreated < filter.ToDate.Value.Date.AddDays(1));

                    var eventAccounts = (from ea in linqMetaData.EventAccount select ea);

                    if (filter.AccountId > 0)
                    {
                        var eventIds = eventAccounts.Where(x => x.AccountId == filter.AccountId).Select(x => x.EventId);
                        query = query.Where(q => eventIds.Contains(q.EventId));
                    }

                    if (filter.IsRetailEvent && !filter.IsCorporateEvent)
                    {
                        var eventIds = eventAccounts.Select(x => x.EventId);
                        query = query.Where(q => !eventIds.Contains(q.EventId));
                    }
                    else if (!filter.IsRetailEvent && filter.IsCorporateEvent)
                    {
                        var eventIds = eventAccounts.Select(x => x.EventId);
                        query = query.Where(q => eventIds.Contains(q.EventId));
                    }


                    if (filter.IsRetailEvent != filter.IsCorporateEvent || filter.AccountId > 0)
                    {
                        var paymentIds = query.Select(x => x.PaymentId);
                        
                        payments = payments.Where(p => paymentIds.Contains(p.PaymentId));
                    }

                    totalRecords = payments.Count();
                    return Mapper.MapMultiple(payments.OrderByDescending(cp => cp.DateCreated).TakePage(pageNumber, pageSize).ToArray());
                }
            }
        }

        public override PaymentType PaymentType { get { return PaymentType.CreditCard; } }
    }
}