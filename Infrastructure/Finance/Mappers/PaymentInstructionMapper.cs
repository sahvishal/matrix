using System;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Core.Finance.Enum;

namespace Falcon.App.Infrastructure.Finance.Mappers
{
    public class PaymentInstructionMapper : DomainEntityMapper<PaymentInstructions, PaymentInstructionsEntity>
    {
        public PaymentInstructionMapper() { }

        protected override void MapDomainFields(PaymentInstructionsEntity entity, PaymentInstructions domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.PaymentInstructionId;
            domainObjectToMapTo.Interval = (PaymentFrequency)entity.PaymentFrequencyId;
            domainObjectToMapTo.AccountHolderName = entity.AccountHolderName;
            domainObjectToMapTo.AccountNumber = entity.AccountNumber;
            domainObjectToMapTo.BankName = entity.BankName;
            domainObjectToMapTo.Memo = entity.Memo;
            domainObjectToMapTo.PaymentMode = (VendorPaymentMode)entity.PaymentMode;
            domainObjectToMapTo.RoutingNumber = entity.RoutingNumber;
            domainObjectToMapTo.SpecialInsructions = entity.SpecialInstructions;

            if (!string.IsNullOrEmpty(entity.AccountType))
                domainObjectToMapTo.AccountType = (AccountType)Convert.ToInt32(entity.AccountType);
        }

        protected override void MapEntityFields(PaymentInstructions domainObject, PaymentInstructionsEntity entityToMapTo)
        {
            entityToMapTo.PaymentInstructionId = domainObject.Id;
            entityToMapTo.PaymentFrequencyId = (long)domainObject.Interval;
            entityToMapTo.AccountHolderName = domainObject.AccountHolderName;
            entityToMapTo.AccountNumber = domainObject.AccountNumber;
            entityToMapTo.BankName = domainObject.BankName;
            entityToMapTo.Memo = domainObject.Memo;
            entityToMapTo.PaymentMode = (int)domainObject.PaymentMode;
            entityToMapTo.RoutingNumber = domainObject.RoutingNumber;
            entityToMapTo.SpecialInstructions = domainObject.SpecialInsructions;
            entityToMapTo.AccountType = Convert.ToString((int)domainObject.AccountType); // Need to make it int type in DB
            
            if (entityToMapTo.PaymentInstructionId < 1)
                entityToMapTo.DateCreated = DateTime.Now;
            
                entityToMapTo.DateModified = DateTime.Now;
            

        }
    }
}
