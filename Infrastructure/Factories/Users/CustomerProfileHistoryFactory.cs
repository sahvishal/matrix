using System;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Factories.Users
{
    [DefaultImplementation]
    public class CustomerProfileHistoryFactory : ICustomerProfileHistoryFactory
    {
        private readonly IAddressRepository _addressRepository;

        public CustomerProfileHistoryFactory()
            : this(new AddressRepository())
        {

        }
        public CustomerProfileHistoryFactory(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public CustomerProfileHistoryEntity CustomerProfileHistoryEntity(CustomerProfileEntity customerProfileEntity, UserEntity userEntity, long createdBy, CustomerEligibility customerEligibility, CustomerWarmTransferEntity customerWarmTransfer, CustomerTargetedEntity customerTargeted)
        {
            var billingAddress = customerProfileEntity.BillingAddressId.HasValue ? _addressRepository.GetAddress(customerProfileEntity.BillingAddressId.Value) : null;
            var homeAddress = _addressRepository.GetAddress(userEntity.HomeAddressId);

            var entity = new CustomerProfileHistoryEntity
            {
                IsNew = true,

                CustomerId = customerProfileEntity.CustomerId,
                FirstName = userEntity.FirstName,
                MiddleName = userEntity.MiddleName,
                LastName = userEntity.LastName,
                HomeAddress1 = homeAddress.StreetAddressLine1,
                HomeAddress2 = homeAddress.StreetAddressLine2,
                HomeCity = homeAddress.City,
                HomeState = homeAddress.State,
                HomeZipCode = homeAddress.ZipCode.Zip,
                HomeCountry = homeAddress.Country,
                PhoneOffice = userEntity.PhoneOffice,
                PhoneCell = userEntity.PhoneCell,
                PhoneHome = userEntity.PhoneHome,
                Email1 = userEntity.Email1,
                Email2 = userEntity.Email2,
                Picture = userEntity.Picture,
                Dob = userEntity.Dob,
                DefaultRoleId = userEntity.Role.RoleId,
                PhoneOfficeExtension = userEntity.PhoneOfficeExtension,
                Ssn = userEntity.Ssn,
                DisplayId = customerProfileEntity.DisplayId,
                BillingAddress1 = billingAddress != null ? billingAddress.StreetAddressLine1 : string.Empty,
                BillingAddress2 = billingAddress != null ? billingAddress.StreetAddressLine2 : string.Empty,
                BillingCity = billingAddress != null ? billingAddress.City : string.Empty,
                BillingState = billingAddress != null ? billingAddress.State : string.Empty,
                BillingZipCode = billingAddress != null ? billingAddress.ZipCode.Zip : string.Empty,
                BillingCountry = billingAddress != null ? billingAddress.Country : string.Empty,
                Waist = customerProfileEntity.Waist,
                Height = customerProfileEntity.Height,
                Weight = customerProfileEntity.Weight,
                Gender = customerProfileEntity.Gender,
                Race = customerProfileEntity.Race,
                TrackingMarketingId = customerProfileEntity.TrackingMarketingId,
                AddedByRoleId = customerProfileEntity.AddedByRoleId,
                Employer = customerProfileEntity.Employer,
                EmergencyContactName = customerProfileEntity.EmergencyContactName,
                EmergencyContactRelationship = customerProfileEntity.EmergencyContactRelationship,
                EmergencyContactPhoneNumber = customerProfileEntity.EmergencyContactPhoneNumber,
                DoNotContactReasonId = customerProfileEntity.DoNotContactReasonId,
                DoNotContactReasonNotesId = customerProfileEntity.DoNotContactReasonNotesId,
                RequestNewsLetter = customerProfileEntity.RequestNewsLetter,
                EmployeeId = customerProfileEntity.EmployeeId,
                InsuranceId = customerProfileEntity.InsuranceId,
                PreferredLanguage = customerProfileEntity.PreferredLanguage,
                BestTimeToCall = customerProfileEntity.BestTimeToCall,
                Hicn = customerProfileEntity.Hicn,
                EnableTexting = customerProfileEntity.EnableTexting,
                MedicareAdvantageNumber = customerProfileEntity.MedicareAdvantageNumber,
                Tag = customerProfileEntity.Tag,
                MedicareAdvantagePlanName = customerProfileEntity.MedicareAdvantagePlanName,
                LanguageId = customerProfileEntity.LanguageId,
                LabId = customerProfileEntity.LabId,
                Copay = customerProfileEntity.Copay,
                Lpi = customerProfileEntity.Lpi,
                Market = customerProfileEntity.Market,
                Mrn = customerProfileEntity.Mrn,
                GroupName = customerProfileEntity.GroupName,
                IsIncorrectPhoneNumber = customerProfileEntity.IsIncorrectPhoneNumber,
                IsLanguageBarrier = customerProfileEntity.IsLanguageBarrier,
                DoNotContactTypeId = customerProfileEntity.DoNotContactTypeId,
                EnableVoiceMail = customerProfileEntity.EnableVoiceMail,
                AdditionalField1 = customerProfileEntity.AdditionalField1,
                AdditionalField2 = customerProfileEntity.AdditionalField2,
                AdditionalField3 = customerProfileEntity.AdditionalField3,
                AdditionalField4 = customerProfileEntity.AdditionalField4,
                ActivityId = customerProfileEntity.ActivityId,
                DoNotContactUpdateDate = customerProfileEntity.DoNotContactUpdateDate,
                DateCreated = DateTime.Now,
                CreatedBy = createdBy,
                DoNotContactUpdateSource = customerProfileEntity.DoNotContactUpdateSource,
                LanguageBarrierMarkedDate = customerProfileEntity.LanguageBarrierMarkedDate,
                IncorrectPhoneNumberMarkedDate = customerProfileEntity.IncorrectPhoneNumberMarkedDate,
                IsSubscribed = customerProfileEntity.IsSubscribed,
                PreferredContactType = customerProfileEntity.PreferredContactType,
                Mbi = customerProfileEntity.Mbi,
                PhoneHomeConsentId = customerProfileEntity.PhoneHomeConsentId,
                PhoneCellConsentId = customerProfileEntity.PhoneCellConsentId,
                PhoneOfficeConsentId = customerProfileEntity.PhoneOfficeConsentId,
                PhoneHomeConsentUpdateDate = customerProfileEntity.PhoneHomeConsentUpdateDate,
                PhoneCellConsentUpdateDate = customerProfileEntity.PhoneCellConsentUpdateDate,
                PhoneOfficeConsentUpdateDate = customerProfileEntity.PhoneOfficeConsentUpdateDate,
                AcesId = customerProfileEntity.AcesId,
                BillingMemberId = customerProfileEntity.BillingMemberId,
                BillingMemberPlan = customerProfileEntity.BillingMemberPlan,
                BillingMemberPlanYear = customerProfileEntity.BillingMemberPlanYear,
                EnableEmail = customerProfileEntity.EnableEmail,
                EnableEmailUpdateDate = customerProfileEntity.EnableEmailUpdateDate,
                MemberUploadSourceId = customerProfileEntity.MemberUploadSourceId,
                ProductTypeId = customerProfileEntity.ProductTypeId,
                AcesClientId = customerProfileEntity.AcesClientId,
            };

            if (customerEligibility != null)
            {
                entity.IsEligble = customerEligibility.IsEligible;
                entity.EligibilityForYear = customerEligibility.ForYear;
            }

            if (customerWarmTransfer != null)
            {
                entity.IsWarmTransfer = customerWarmTransfer.IsWarmTransfer;
                entity.WarmTransferYear = customerWarmTransfer.WarmTransferYear;
            }

            if (customerTargeted != null)
            {
                entity.TargetedYear = customerTargeted.ForYear;
                entity.IsTargeted = customerTargeted.IsTargated;
            }
            return entity;
        }
    }
}