using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers.Orders
{
    [DefaultImplementation(Interface = typeof(IMapper<GiftCertificate, GiftCertificateEntity>))]
    public class GiftCertificateMapper : DomainEntityMapper<GiftCertificate, GiftCertificateEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public GiftCertificateMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        public GiftCertificateMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(GiftCertificateEntity entity, 
            GiftCertificate domainObjectToMapTo)
        {
            DataRecorderMetaData dataRecorderMetaData = entity.OrgazizationRoleUserCreatorId.HasValue
                                                            ? _dataRecorderMetaDataFactory.
                                                                  CreateDataRecorderMetaData(
                                                                      entity.OrgazizationRoleUserCreatorId.Value,
                                                                      entity.DateCreated)
                                                            : null;

            domainObjectToMapTo.Id = entity.GiftCertificateId;
            domainObjectToMapTo.Price = entity.Amount;
            domainObjectToMapTo.ClaimCode = entity.ClaimCode;
            domainObjectToMapTo.DataRecorderMetaData = dataRecorderMetaData;
            domainObjectToMapTo.ExpirationDate = entity.ExpirationDate;
            domainObjectToMapTo.FromName = entity.FromName;
            domainObjectToMapTo.GiftCertificateTypeId = entity.TypeId;
            domainObjectToMapTo.Message = entity.Message;
            domainObjectToMapTo.ToName = entity.ToName;
            domainObjectToMapTo.ApplicablePackageId = entity.ApplicablePackageId;
            domainObjectToMapTo.ToEmail = entity.ToEmail;
        }

        protected override void MapEntityFields(GiftCertificate domainObject, 
            GiftCertificateEntity entityToMapTo)
        {
        
            entityToMapTo.GiftCertificateId = domainObject.Id;
            entityToMapTo.Amount = domainObject.Price;
            entityToMapTo.ClaimCode = domainObject.ClaimCode;
            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData != null ? domainObject.DataRecorderMetaData.DateCreated : DateTime.Now;
            entityToMapTo.ExpirationDate = domainObject.ExpirationDate;
            entityToMapTo.FromName = domainObject.FromName;
            entityToMapTo.TypeId = domainObject.GiftCertificateTypeId;
            entityToMapTo.Message = domainObject.Message;
            entityToMapTo.ToEmail = domainObject.ToEmail;

            if (domainObject.DataRecorderMetaData != null && domainObject.DataRecorderMetaData.DataRecorderCreator != null)
            {
                entityToMapTo.OrgazizationRoleUserCreatorId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;
            }
            else
            {
                throw new ArgumentNullException("domainObject","DatarecoderMetadata cannot be null.");
            }
                

            entityToMapTo.ToName = domainObject.ToName;
            entityToMapTo.ApplicablePackageId = domainObject.ApplicablePackageId;
        }
    }
}