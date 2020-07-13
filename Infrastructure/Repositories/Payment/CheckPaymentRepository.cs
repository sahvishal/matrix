using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Infrastructure.Mappers.Payments;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories.Payment
{
    public class CheckPaymentRepository : PaymentInstrumentRepository<CheckPayment, CheckPaymentEntity>, ICheckPaymentRepository
    {
        private readonly ICheckRepository _checkRepository;

        public CheckPaymentRepository()
            : this(new CheckRepository(), new CheckPaymentMapper())
        {}

        public CheckPaymentRepository(ICheckRepository checkRepository, 
            IMapper<CheckPayment, CheckPaymentEntity> mapper)
            : base(mapper)
        {
            _checkRepository = checkRepository;
        }

        protected override EntityField2 EntityIdField
        {
            get { throw new NotImplementedException(); }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return CheckPaymentFields.PaymentId == paymentId;
        }

        public override PaymentType PaymentType
        {
            get { return PaymentType.Check; }
        }

        protected override IEnumerable<CheckPayment> PostFetchTransform(IEnumerable<CheckPayment> domainObjects)
        {
            IEnumerable<long> checkIds = domainObjects.Select(cp => cp.CheckId);
            IEnumerable<Check> checks = _checkRepository.GetByIds(checkIds);

            domainObjects = AssignChecksToCheckPayments(domainObjects, checks);

            return domainObjects;
        }

        public override PaymentInstrument SavePaymentInstrument(PaymentInstrument paymentInstrument)
        {
            var checkPayment = (CheckPayment) paymentInstrument;
            using (var transactionScope = new TransactionScope())
            {
                var check = _checkRepository.Save(checkPayment.Check);
                checkPayment.CheckId = check.Id;

                checkPayment = (CheckPayment) base.SavePaymentInstrument(paymentInstrument);
                MapCheckToCheckPayment(checkPayment, check);

                transactionScope.Complete();
            }
            return checkPayment;
        }

        private IEnumerable<CheckPayment> AssignChecksToCheckPayments(IEnumerable<CheckPayment> domainObjects, IEnumerable<Check> checks)
        {
            var checkPayments = new List<CheckPayment>();
            foreach (var checkPayment in domainObjects)
            {
                CheckPayment payment = checkPayment;
                Check singleCheck = checks.Where(check => check.Id == payment.CheckId).Single();
                MapCheckToCheckPayment(checkPayment, singleCheck);
                checkPayments.Add(checkPayment);
            }
            return checkPayments;
        }

        private void MapCheckToCheckPayment(CheckPayment checkPayment, Check check)
        {
            checkPayment.Check = check;
            checkPayment.CheckId = check.Id;
            checkPayment.Amount = check.Amount;
        }
    }
}