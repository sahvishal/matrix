using System;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.Factories.Users
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;

        public CustomerFactory()
            : this(new UserFactory<Customer>(), new PhoneNumberFactory())
        { }

        public CustomerFactory(IUserFactory<Customer> userFactory, IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public Customer CreateCustomer(Customer customer, Address billingAddress, CustomerProfileEntity customersEntity)
        {
            NullArgumentChecker.CheckIfNull(customer, "customer");
            NullArgumentChecker.CheckIfNull(customersEntity, "customersEntity");

            customer.AddedByRoleId = customersEntity.AddedByRoleId;
            customer.CustomerId = customersEntity.CustomerId;
            customer.Gender = !string.IsNullOrEmpty(customersEntity.Gender) ? (Gender)Enum.Parse(typeof(Gender), customersEntity.Gender, true) : Gender.Unspecified;
            var height = !string.IsNullOrEmpty(customersEntity.Height) ? Convert.ToDouble(customersEntity.Height) : 0;
            if (height != 0)
            {
                var inches = height % 12;
                var feet = (height - inches) / 12;
                customer.Height = new Height(feet, inches);
            }
            customer.MarketingSource = customersEntity.TrackingMarketingId;
            customer.Race = !string.IsNullOrEmpty(customersEntity.Race)
                                ? (Race)Enum.Parse(typeof(Race), customersEntity.Race, true)
                                : Race.None;
            customer.Weight = new Weight(customersEntity.Weight ?? 0);
            customer.BillingAddress = billingAddress;
            customer.DateCreated = customersEntity.DateCreated;
            customer.DateModified = customersEntity.DateModified;

            customer.DisplayCode = customersEntity.DisplayId.HasValue
                                       ? customersEntity.DisplayId.Value.ToString()
                                       : string.Empty;
            customer.Employer = customersEntity.Employer;
            customer.EmergencyContactName = customersEntity.EmergencyContactName;
            customer.EmergencyContactRelationship = customersEntity.EmergencyContactRelationship;
            customer.EmergencyContactPhoneNumber = _phoneNumberFactory.CreatePhoneNumber(customersEntity.EmergencyContactPhoneNumber, PhoneNumberType.Office);

            customer.DoNotContactTypeId = customersEntity.DoNotContactTypeId;
            customer.DoNotContactReasonId = customersEntity.DoNotContactReasonId;
            customer.DoNotContactReasonNotesId = customersEntity.DoNotContactReasonNotesId;
            customer.RequestForNewsLetter = customersEntity.RequestNewsLetter;
            //customer.LastScreeningDate = customersEntity.UserDefined1;
            customer.EmployeeId = customersEntity.EmployeeId;
            customer.InsuranceId = customersEntity.InsuranceId;
            customer.PreferredLanguage = customersEntity.PreferredLanguage;
            customer.BestTimeToCall = customersEntity.BestTimeToCall;
            customer.Waist = customersEntity.Waist.HasValue && customersEntity.Waist.Value > 0 ? customersEntity.Waist.Value : (decimal?)null;
            customer.Tag = customersEntity.Tag ?? string.Empty;
            customer.Hicn = customersEntity.Hicn;
            customer.EnableTexting = customersEntity.EnableTexting;
            customer.MedicareAdvantageNumber = customersEntity.MedicareAdvantageNumber;
            customer.MedicareAdvantagePlanName = customersEntity.MedicareAdvantagePlanName;
            //customer.IsEligible = customersEntity.IsEligble;              //Column Moved from this table
            customer.LabId = customersEntity.LabId;
            customer.LanguageId = customersEntity.LanguageId;
            customer.Copay = customersEntity.Copay;
            customer.Lpi = customersEntity.Lpi;
            customer.Market = customersEntity.Market;
            customer.Mrn = customersEntity.Mrn;
            customer.GroupName = customersEntity.GroupName;
            customer.IsIncorrectPhoneNumber = customersEntity.IsIncorrectPhoneNumber;
            customer.IsLanguageBarrier = customersEntity.IsLanguageBarrier;
            customer.EnableVoiceMail = customersEntity.EnableVoiceMail;
            customer.AdditionalField1 = customersEntity.AdditionalField1;
            customer.AdditionalField2 = customersEntity.AdditionalField2;
            customer.AdditionalField3 = customersEntity.AdditionalField3;
            customer.AdditionalField4 = customersEntity.AdditionalField4;
            customer.ActivityId = customersEntity.ActivityId;

            customer.DoNotContactUpdateDate = customersEntity.DoNotContactUpdateDate;
            //customer.IsDuplicate = customersEntity.IsDuplicate;
            customer.DoNotContactUpdateSource = customersEntity.DoNotContactUpdateSource;

            customer.IsSubscribed = customersEntity.IsSubscribed;

            customer.LanguageBarrierMarkedDate = customersEntity.LanguageBarrierMarkedDate;
            customer.IncorrectPhoneNumberMarkedDate = customersEntity.IncorrectPhoneNumberMarkedDate;
            customer.PreferredContactType = customersEntity.PreferredContactType;
            customer.AcesId = customersEntity.AcesId;

            customer.Mbi = customersEntity.Mbi;

            customer.PhoneCellConsentId = customersEntity.PhoneCellConsentId;
            customer.PhoneHomeConsentId = customersEntity.PhoneHomeConsentId;
            customer.PhoneOfficeConsentId = customersEntity.PhoneOfficeConsentId;
            customer.PhoneHomeConsentUpdateDate = customersEntity.PhoneHomeConsentUpdateDate;
            customer.PhoneCellConsentUpdateDate = customersEntity.PhoneCellConsentUpdateDate;
            customer.PhoneOfficeConsentUpdateDate = customersEntity.PhoneOfficeConsentUpdateDate;
            customer.BillingMemberId = customersEntity.BillingMemberId;
            customer.BillingMemberPlan = customersEntity.BillingMemberPlan;
            customer.BillingMemberPlanYear = customersEntity.BillingMemberPlanYear;
            customer.EnableEmail = customersEntity.EnableEmail;
            customer.EnableEmailUpdateDate = customersEntity.EnableEmailUpdateDate;
            customer.MemberUploadSourceId = customersEntity.MemberUploadSourceId;
            customer.ActivityTypeIsManual = customersEntity.ActivityTypeIsManual;
            customer.ProductTypeId = customersEntity.ProductTypeId;
            customer.AcesClientId = customersEntity.AcesClientId;

            return customer;
        }

        public CustomerProfileEntity CreateCustomerEntity(Customer customer, long organizationRoleUserId)
        {
            NullArgumentChecker.CheckIfNull(customer, "customer");

            var entity = new CustomerProfileEntity(customer.CustomerId)
                       {
                           CustomerId = customer.CustomerId == 0 ? organizationRoleUserId : customer.CustomerId,
                           DateCreated = customer.DateCreated != DateTime.MinValue ? customer.DateCreated : DateTime.Now,
                           DateModified = DateTime.Now,
                           Gender = customer.Gender != Gender.Unspecified && ((long)customer.Gender > 0) ? customer.Gender.ToString() : null,
                           Height = customer.Height == null
                                        ? null
                                        : customer.Height.TotalInches.ToString(),
                           IsActive = true,

                           Race = (int)customer.Race > 0 ? customer.Race.ToString() : null,

                           Weight = customer.Weight == null
                                        ? null
                                        : (double?)customer.Weight.Pounds,
                           TrackingMarketingId = customer.MarketingSource,
                           AddedByRoleId = customer.AddedByRoleId,
                           BillingAddressId = customer.BillingAddress != null ? customer.BillingAddress.Id : customer.Address.Id,
                           Employer = customer.Employer,
                           EmergencyContactName = customer.EmergencyContactName,
                           EmergencyContactRelationship = customer.EmergencyContactRelationship,
                           EmergencyContactPhoneNumber = customer.EmergencyContactPhoneNumber != null ? customer.EmergencyContactPhoneNumber.AreaCode + customer.EmergencyContactPhoneNumber.Number : string.Empty,
                           DoNotContactTypeId = customer.DoNotContactTypeId,
                           DoNotContactReasonId = customer.DoNotContactReasonId,
                           DoNotContactReasonNotesId = customer.DoNotContactTypeId.HasValue ? customer.DoNotContactReasonNotesId : null,
                           RequestNewsLetter = customer.RequestForNewsLetter,
                           EmployeeId = customer.EmployeeId,
                           InsuranceId = customer.InsuranceId,
                           PreferredLanguage = customer.PreferredLanguage,
                           BestTimeToCall = customer.BestTimeToCall.HasValue && customer.BestTimeToCall.Value > 0 ? customer.BestTimeToCall.Value : (long?)null,
                           Waist = customer.Waist.HasValue && customer.Waist.Value > 0 ? customer.Waist.Value : (decimal?)null,
                           Tag = customer.Tag,
                           Hicn = customer.Hicn,
                           EnableTexting = customer.EnableTexting,
                           MedicareAdvantageNumber = customer.MedicareAdvantageNumber,
                           MedicareAdvantagePlanName = customer.MedicareAdvantagePlanName,
                           //IsEligble = customer.IsEligible,               //Column Moved from this table
                           LabId = customer.LabId,
                           LanguageId = customer.LanguageId,
                           IsNew = customer.CustomerId <= 0,
                           Copay = customer.Copay ?? "",
                           Lpi = customer.Lpi ?? "",
                           Market = customer.Market ?? "",
                           Mrn = customer.Mrn ?? "",
                           GroupName = customer.GroupName ?? "",
                           IsIncorrectPhoneNumber = customer.IsIncorrectPhoneNumber,
                           IsLanguageBarrier = customer.IsLanguageBarrier,
                           EnableVoiceMail = customer.EnableVoiceMail,
                           AdditionalField1 = customer.AdditionalField1,
                           AdditionalField2 = customer.AdditionalField2,
                           AdditionalField3 = customer.AdditionalField3,
                           AdditionalField4 = customer.AdditionalField4,
                           ActivityId = customer.ActivityId,
                           DoNotContactUpdateDate = customer.DoNotContactUpdateDate,
                           //IsDuplicate = customer.IsDuplicate
                           DoNotContactUpdateSource = customer.DoNotContactUpdateSource,
                           IsSubscribed = customer.IsSubscribed,
                           LanguageBarrierMarkedDate = customer.LanguageBarrierMarkedDate,
                           IncorrectPhoneNumberMarkedDate = customer.IncorrectPhoneNumberMarkedDate,
                           PreferredContactType = customer.PreferredContactType,
                           Mbi = customer.Mbi,
                           AcesId = customer.AcesId,
                           PhoneHomeConsentId = customer.PhoneHomeConsentId == 0 ? (long)PatientConsent.Unknown : customer.PhoneHomeConsentId,
                           PhoneCellConsentId = customer.PhoneCellConsentId == 0 ? (long)PatientConsent.Unknown : customer.PhoneCellConsentId,
                           PhoneOfficeConsentId = customer.PhoneOfficeConsentId == 0 ? (long)PatientConsent.Unknown : customer.PhoneOfficeConsentId,
                           PhoneHomeConsentUpdateDate = customer.PhoneHomeConsentUpdateDate,
                           PhoneCellConsentUpdateDate = customer.PhoneCellConsentUpdateDate,
                           PhoneOfficeConsentUpdateDate = customer.PhoneOfficeConsentUpdateDate,
                           BillingMemberId = customer.BillingMemberId,
                           BillingMemberPlan = customer.BillingMemberPlan,
                           BillingMemberPlanYear = customer.BillingMemberPlanYear,
                           EnableEmail = customer.EnableEmail,
                           EnableEmailUpdateDate = customer.EnableEmailUpdateDate,
                           MemberUploadSourceId = customer.MemberUploadSourceId,
                           ActivityTypeIsManual = customer.ActivityTypeIsManual,
                           ProductTypeId = customer.ProductTypeId,
                           AcesClientId = customer.AcesClientId,
                       };

            //if (!string.IsNullOrEmpty(customer.LastScreeningDate))
            //    entity.UserDefined1 = customer.LastScreeningDate;

            // entity.Fields["DoNotContactTypeId"].IsChanged = true;
            entity.Fields["DoNotContactReasonId"].IsChanged = true;
            entity.Fields["DoNotContactReasonNotesId"].IsChanged = true;

            entity.Fields["BestTimeToCall"].IsChanged = true;

            entity.Fields["Tag"].IsChanged = true;
            entity.Fields["Hicn"].IsChanged = true;
            entity.Fields["MedicareAdvantageNumber"].IsChanged = true;
            entity.Fields["MedicareAdvantagePlanName"].IsChanged = true;
            entity.Fields["Copay"].IsChanged = true;
            entity.Fields["Lpi"].IsChanged = true;

            entity.Fields["Market"].IsChanged = true;
            entity.Fields["Mrn"].IsChanged = true;
            entity.Fields["GroupName"].IsChanged = true;
            entity.Fields["AdditionalField1"].IsChanged = true;
            entity.Fields["AdditionalField2"].IsChanged = true;
            entity.Fields["AdditionalField3"].IsChanged = true;
            entity.Fields["AdditionalField4"].IsChanged = true;

            entity.Fields["ActivityId"].IsChanged = true;

            entity.Fields["DoNotContactUpdateDate"].IsChanged = true;
            entity.Fields["DoNotContactUpdateSource"].IsChanged = true;
            entity.Fields["LanguageBarrierMarkedDate"].IsChanged = true;
            entity.Fields["IncorrectPhoneNumberMarkedDate"].IsChanged = true;
            entity.Fields["PreferredContactType"].IsChanged = true;

            entity.Fields["IsSubscribed"].IsChanged = true;

            entity.Fields["Mbi"].IsChanged = true;
            entity.Fields["AcesId"].IsChanged = true;

            entity.Fields["PhoneHomeConsentId"].IsChanged = true;
            entity.Fields["PhoneCellConsentId"].IsChanged = true;
            entity.Fields["PhoneOfficeConsentId"].IsChanged = true;
            entity.Fields["PhoneHomeConsentUpdateDate"].IsChanged = true;
            entity.Fields["PhoneCellConsentUpdateDate"].IsChanged = true;
            entity.Fields["PhoneOfficeConsentUpdateDate"].IsChanged = true;
            entity.Fields["BillingMemberId"].IsChanged = true;
            entity.Fields["BillingMemberPlan"].IsChanged = true;
            entity.Fields["BillingMemberPlanYear"].IsChanged = true;
            entity.Fields["EnableEmailUpdateDate"].IsChanged = true;
            entity.Fields["MemberUploadSourceId"].IsChanged = true;
            entity.Fields["ProductTypeId"].IsChanged = true;
            entity.Fields["AcesClientId"].IsChanged = true;
            
            return entity;
        }

    }
}