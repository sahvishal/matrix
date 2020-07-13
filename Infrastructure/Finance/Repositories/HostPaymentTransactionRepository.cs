using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Infrastructure.Mappers.Hosts;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Finance.Repositories
{
    public class HostPaymentTransactionRepository : PersistenceRepository, IHostPaymentTransactionRepository
    {
        private readonly IMapper<HostPaymentTransaction, HostPaymentTransactionEntity> _mapper;

        public HostPaymentTransactionRepository()
            : this(new HostPaymentTransactionMapper())
        { }
        public HostPaymentTransactionRepository(IMapper<HostPaymentTransaction, HostPaymentTransactionEntity> mapper)
        {
            _mapper = mapper;
        }

        public List<HostPaymentTransaction> GetById(long hostPaymentId)
        {
            List<HostPaymentTransactionEntity> hostPaymentTransactionEntity;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                hostPaymentTransactionEntity = linqMetaData.HostPaymentTransaction.
                    Where(hostPaymentTransaction => hostPaymentTransaction.HostPaymentId == hostPaymentId).ToList();
            }
            return _mapper.MapMultiple(hostPaymentTransactionEntity).ToList();
        }
        public HostPaymentTransaction Save(HostPaymentTransaction hostPaymentTransaction)
        {
            var hostPaymentTransactionEntity = _mapper.Map(hostPaymentTransaction);

            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(hostPaymentTransactionEntity, false))
                {
                    throw new PersistenceFailureException();
                }
            }
            return hostPaymentTransaction;
        }

        public List<HostPaymentTransaction> GetHostpaymentTransactions(IEnumerable<long> hostPaymentIds)
        {
            List<HostPaymentTransactionEntity> hostPaymentTransactionEntity;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                hostPaymentTransactionEntity = linqMetaData.HostPaymentTransaction.
                    Where(hostPaymentTransaction => hostPaymentIds.Contains(hostPaymentTransaction.HostPaymentId)).
                    ToList();
            }
            return _mapper.MapMultiple(hostPaymentTransactionEntity).ToList();
        }

        public void DeleteByIdAndStatus(long hostPaymentId,HostPaymentStatus hostPaymentStatus)
        {
            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(HostPaymentTransactionFields.HostPaymentId == hostPaymentId);
            bucket.PredicateExpression.AddWithAnd(HostPaymentTransactionFields.TransactionType == hostPaymentStatus);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof (HostPaymentTransactionEntity), bucket);
            }
        }

        public HostPaymentTransaction GetByIdAndStatus(long hostPaymentId, long hostPaymentStatus)
        {
            HostPaymentTransactionEntity hostPaymentTransactionEntity = null;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                hostPaymentTransactionEntity =
                    linqMetaData.HostPaymentTransaction.Where(
                        hostPaymentTransaction =>
                        hostPaymentTransaction.HostPaymentId == hostPaymentId &&
                        hostPaymentTransaction.TransactionType == hostPaymentStatus
                        ).FirstOrDefault();

            }
            if (hostPaymentTransactionEntity!=null) return _mapper.Map(hostPaymentTransactionEntity);
            else return null;
        }
        public bool UpdateHostPaymentTransactionByIdAndStatus(HostPaymentTransaction hostPaymentTransaction)
        {

            var hostPaymentTransactionEntity = _mapper.Map(hostPaymentTransaction);
            IRelationPredicateBucket bucket =
                new RelationPredicateBucket(HostPaymentTransactionFields.HostPaymentId == hostPaymentTransaction.HostPaymentId);
            bucket.PredicateExpression.AddWithAnd(HostPaymentTransactionFields.TransactionType == hostPaymentTransaction.TransactionType);
            using (IDataAccessAdapter myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                return myAdapter.UpdateEntitiesDirectly(hostPaymentTransactionEntity, bucket) > 0;
            }
        }
    }
}
