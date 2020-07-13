using System;
using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Finance.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;

namespace Falcon.App.Infrastructure.Factories
{
    public class PaymentInstrumentFactory : IPaymentInstrumentFactory
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public PaymentInstrumentFactory()
            : this(new DataRecorderMetaDataFactory())
        {}

        public PaymentInstrumentFactory(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        public List<PaymentInstrument> CreatePaymentInstruments(EntityCollection<CheckEntity> checkEntities)
        {
            if (checkEntities == null)
            {
                throw new ArgumentNullException("checkEntities", "The given collection of check entities cannot be null.");
            }

            var paymentInstruments = new List<PaymentInstrument>();
            foreach (var checkEntity in checkEntities)
            {
                PaymentInstrument check = CreatePaymentInstrument(checkEntity);
                paymentInstruments.Add(check);
            }
            return paymentInstruments;
        }

        public PaymentInstrument CreatePaymentInstrument(CheckEntity checkEntity)
        {
            if (checkEntity == null)
            {
                throw new ArgumentNullException("checkEntity", "Given CheckEntity cannot be null.");
            }

            DataRecorderMetaData dataRecorderMetaData = _dataRecorderMetaDataFactory.
                CreateDataRecorderMetaData(checkEntity.DataRecoderCreatorId, checkEntity.DateCreated, 
                checkEntity.DataRecoderModifierId, checkEntity.DateModified);
            
            return new Check(checkEntity.CheckId)
            {
                DataRecorderMetaData = dataRecorderMetaData,
                AccountNumber = checkEntity.AccountNumber,
                Amount = checkEntity.Amount,
                BankName = checkEntity.BankName,
                CheckDate = checkEntity.CheckDate,
                CheckNumber = checkEntity.CheckNumber,
                PayableTo = checkEntity.PayableTo,
                RoutingNumber = checkEntity.RoutingNumber,
                Memo = checkEntity.Memo
            };
        }
    }
}