using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Users.Enum;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class ProspectCustomerMapper : DomainEntityMapper<ProspectCustomer, ProspectCustomerEntity>
    {
        private readonly IEmailFactory _emailFactory;
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public ProspectCustomerMapper()
            : this(new EmailFactory(), new PhoneNumberFactory())
        { }

        public ProspectCustomerMapper(IEmailFactory emailFactory, IPhoneNumberFactory phoneNumberFactory)
        {
            _emailFactory = emailFactory;
            _phoneNumberFactory = phoneNumberFactory;
        }

        protected override void MapDomainFields(ProspectCustomerEntity entity, ProspectCustomer domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.ProspectCustomerId;
            domainObjectToMapTo.Address = new Address
                                              {
                                                  City = entity.City,
                                                  State = entity.State,
                                                  StreetAddressLine1 = entity.Address1,
                                                  StreetAddressLine2 = entity.Address2,
                                                  ZipCode = new ZipCode {Zip = entity.ZipCode}
                                              };
            domainObjectToMapTo.BirthDate = entity.Dob;
            domainObjectToMapTo.Email = _emailFactory.CreateEmail(entity.Email);
            domainObjectToMapTo.FirstName = entity.FirstName;
            domainObjectToMapTo.LastName = entity.LastName;
            domainObjectToMapTo.MarketingSource = entity.MarketingSource;
            domainObjectToMapTo.PhoneNumber = _phoneNumberFactory.CreatePhoneNumber(entity.IncomingPhoneLine,
                                                                                         PhoneNumberType.Unknown);
            domainObjectToMapTo.CallBackPhoneNumber = _phoneNumberFactory.CreatePhoneNumber(entity.CallbackNo,
                                                                                            PhoneNumberType.Unknown);
            domainObjectToMapTo.SourceCodeId = entity.SourceCodeId;
            domainObjectToMapTo.Gender = !string.IsNullOrEmpty(entity.Gender)
                                             ? (Gender)Enum.Parse(typeof(Gender), entity.Gender, true)
                                             : Gender.Unspecified;
            domainObjectToMapTo.Source = (ProspectCustomerSource)entity.Source;
            domainObjectToMapTo.Tag = !string.IsNullOrEmpty(entity.Tag)
                                          ? (ProspectCustomerTag)
                                            Enum.Parse(typeof (ProspectCustomerTag), entity.Tag, true)
                                          : ProspectCustomerTag.Unspecified;

            domainObjectToMapTo.IsConverted = entity.IsConverted;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.ConvertedOnDate = entity.DateConverted;
            domainObjectToMapTo.CreatedOn = entity.DateCreated;
            domainObjectToMapTo.IsContacted = entity.IsContacted;
            domainObjectToMapTo.ContactedDate = entity.ContactedDate;
            domainObjectToMapTo.ContactedBy = entity.ContactedBy;
            domainObjectToMapTo.Status = entity.Status;
            domainObjectToMapTo.CallBackRequestedOn = entity.CallBackRequestedOn;
            domainObjectToMapTo.CallBackRequestedDate = entity.CallBackRequestedDate;
            domainObjectToMapTo.CallBackRequestedDate = entity.CallBackRequestedDate;
            domainObjectToMapTo.IsQueuedForCallBack = entity.IsQueuedForCallBack;
            domainObjectToMapTo.TagUpdateDate = entity.TagUpdateDate;

        }

        protected override void MapEntityFields(ProspectCustomer domainObject, ProspectCustomerEntity entityToMapTo)
        {
            entityToMapTo.ProspectCustomerId = domainObject.Id;
            if (domainObject.Address != null)
            {
                entityToMapTo.City = domainObject.Address.City;
                entityToMapTo.State = domainObject.Address.State;
                entityToMapTo.Address1 = domainObject.Address.StreetAddressLine1;
                entityToMapTo.Address2 = domainObject.Address.StreetAddressLine2;
                entityToMapTo.ZipCode = domainObject.Address.ZipCode.Zip;
            }

            entityToMapTo.Dob = domainObject.BirthDate;
            entityToMapTo.Fields["Dob"].IsChanged = true;
            entityToMapTo.Email = domainObject.Email != null ? domainObject.Email.ToString() : string.Empty;
            entityToMapTo.FirstName = domainObject.FirstName;
            entityToMapTo.LastName = domainObject.LastName;
            entityToMapTo.MarketingSource = domainObject.MarketingSource;
            if (domainObject.CallBackPhoneNumber != null)
            {
                entityToMapTo.CallbackNo = domainObject.CallBackPhoneNumber.AreaCode +
                                           domainObject.CallBackPhoneNumber.Number;
            }

            entityToMapTo.IncomingPhoneLine = domainObject.PhoneNumber != null
                                                  ? domainObject.PhoneNumber.AreaCode + domainObject.PhoneNumber.Number
                                                  : string.Empty;
            entityToMapTo.SourceCodeId = domainObject.SourceCodeId;
            entityToMapTo.Gender = domainObject.Gender != Gender.Unspecified && ((long)domainObject.Gender > 0) ? domainObject.Gender.ToString() : null;
            entityToMapTo.Tag = domainObject.Tag.ToString();
            entityToMapTo.Source = (long) domainObject.Source;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.Fields["CustomerId"].IsChanged = true;
            entityToMapTo.IsConverted = domainObject.IsConverted;

            entityToMapTo.DateConverted = domainObject.ConvertedOnDate;
            entityToMapTo.Fields["DateConverted"].IsChanged = true;

            entityToMapTo.IsContacted = domainObject.IsContacted;
            entityToMapTo.ContactedDate = domainObject.ContactedDate;
            entityToMapTo.ContactedBy = domainObject.ContactedBy;
            entityToMapTo.Status = domainObject.Status;

            entityToMapTo.CallBackRequestedOn = domainObject.CallBackRequestedOn;
            entityToMapTo.CallBackRequestedDate = domainObject.CallBackRequestedDate;
            entityToMapTo.IsQueuedForCallBack = domainObject.IsQueuedForCallBack;
            entityToMapTo.TagUpdateDate = domainObject.TagUpdateDate;

            entityToMapTo.Fields["TagUpdateDate"].IsChanged = true;

            if (domainObject.Id < 1)
                entityToMapTo.DateCreated = DateTime.Now;
            else
                entityToMapTo.DateCreated = domainObject.CreatedOn;
        }
    }
}
