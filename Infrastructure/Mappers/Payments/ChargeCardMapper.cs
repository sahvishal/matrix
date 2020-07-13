using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Payments
{
    [DefaultImplementation(Interface = typeof(IMapper<ChargeCard, ChargeCardEntity>))]
    public class ChargeCardMapper : DomainEntityMapper<ChargeCard, ChargeCardEntity>
    {
        private readonly IEncrypter _encrypter;
        private readonly IDataRecorderMetaDataFactory _metaDataFactory;
        
        // TODO: Replace with a better encryption method?
        public ChargeCardMapper()
            : this (new DataRecorderMetaDataFactory(), new EncryptionHelper())
        {}

        public ChargeCardMapper(IDataRecorderMetaDataFactory metaDataFactory, IEncrypter encrypter)
        {
            _metaDataFactory = metaDataFactory;
            _encrypter = encrypter;
        }

        protected override void MapDomainFields(ChargeCardEntity entity, ChargeCard domainObjectToMapTo)
        {
            // TODO: persist encrypted fields.
            DataRecorderMetaData metaData = _metaDataFactory.CreateDataRecorderMetaData(
                entity.OrganizationRoleUserCreatorId,
                entity.DateCreated);

            domainObjectToMapTo.Id = entity.ChargeCardId;
            domainObjectToMapTo.CVV = _encrypter.Decrypt(entity.Cvv);
            domainObjectToMapTo.CardIssuer = entity.CardIssuer;
            domainObjectToMapTo.ExpirationDate = entity.ExpirationDate;
            domainObjectToMapTo.IsDebit = entity.IsDebitCard;
            domainObjectToMapTo.NameOnCard = entity.NameOnCard;
            domainObjectToMapTo.Number = _encrypter.Decrypt(entity.Number);
            domainObjectToMapTo.TypeId = (ChargeCardType)entity.TypeId;
            domainObjectToMapTo.DataRecorderMetaData = metaData;
        }

        protected override void MapEntityFields(ChargeCard domainObject, ChargeCardEntity entityToMapTo)
        {
            entityToMapTo.ChargeCardId = domainObject.Id;
            entityToMapTo.Cvv = _encrypter.Encrypt(domainObject.CVV);
            entityToMapTo.CardIssuer = domainObject.CardIssuer;
            entityToMapTo.ExpirationDate = domainObject.ExpirationDate;
            entityToMapTo.IsDebitCard = domainObject.IsDebit;
            entityToMapTo.NameOnCard = domainObject.NameOnCard;
            entityToMapTo.Number = _encrypter.Encrypt(domainObject.Number);
            entityToMapTo.TypeId = (long) domainObject.TypeId;
            entityToMapTo.OrganizationRoleUserCreatorId = domainObject.DataRecorderMetaData.
                DataRecorderCreator.Id;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData.DateCreated;
            entityToMapTo.IsNew = domainObject.Id <= 0;
        }
    }
}