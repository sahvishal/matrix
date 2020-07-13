using System;
using System.Collections.Generic;
using System.Linq;
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
    // TODO: a lot of this code is redundantly similar to code in the CheckRepository, but is difficult to genericize properly...
    public class ECheckPaymentRepository : PaymentInstrumentRepository<ECheckPayment, EcheckPaymentEntity>, IECheckPaymentRepository
    {
        private readonly ICheckRepository _checkRepository;

        public ECheckPaymentRepository()
            : this(new CheckRepository(), new ECheckPaymentMapper())
        {}

        public ECheckPaymentRepository(ICheckRepository echeckRepository, 
            IMapper<ECheckPayment, EcheckPaymentEntity> mapper)
            : base(mapper)
        {
            _checkRepository = echeckRepository;
        }

        protected override EntityField2 EntityIdField
        {
            get { throw new NotImplementedException(); }
        }

        protected override IPredicate PaymentIdPredicate(long paymentId)
        {
            return EcheckPaymentFields.PaymentId == paymentId;
        }

        public override PaymentType PaymentType
        {
            get { return PaymentType.ElectronicCheck; }
        }

        protected override IEnumerable<ECheckPayment> PostFetchTransform(IEnumerable<ECheckPayment> domainObjects)
        {
            IEnumerable<long> echeckIds = domainObjects.Select(cp => cp.ECheckId);
            IEnumerable<Check> echecks = _checkRepository.GetByIds(echeckIds);

            domainObjects = AssignChecksToCheckPayments(domainObjects, echecks);

            return domainObjects;
        }

        public override PaymentInstrument SavePaymentInstrument(PaymentInstrument paymentInstrument)
        {
            var echeckPayment = (ECheckPayment)paymentInstrument;

            var check = _checkRepository.Save(echeckPayment.ECheck);
            echeckPayment.ECheckId = check.Id;

            echeckPayment = (ECheckPayment)base.SavePaymentInstrument(echeckPayment);
            MapCheckToCheckPayment(echeckPayment, check);

            return echeckPayment;
        }

        private IEnumerable<ECheckPayment> AssignChecksToCheckPayments(IEnumerable<ECheckPayment> domainObjects, IEnumerable<Check> checks)
        {
            var eCheckPayments = new List<ECheckPayment>();
            foreach (var checkPayment in domainObjects)
            {
                ECheckPayment payment = checkPayment;
                Check singleCheck = checks.Where(check => check.Id == payment.ECheckId).Single();
                MapCheckToCheckPayment(checkPayment, singleCheck);
                eCheckPayments.Add(checkPayment);
            }
            return eCheckPayments;
        }

        private void MapCheckToCheckPayment(ECheckPayment checkPayment, Check check)
        {
            checkPayment.ECheck = check;
            checkPayment.ECheckId = check.Id;
            checkPayment.Amount = check.Amount;
        }
    }
}