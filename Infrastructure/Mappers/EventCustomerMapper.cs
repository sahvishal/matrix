using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<EventCustomer, EventCustomersEntity>))]
    public class EventCustomerMapper : DomainEntityMapper<EventCustomer, EventCustomersEntity>
    {
        private readonly IDataRecorderMetaDataFactory _dataRecorderMetaDataFactory;

        public EventCustomerMapper()
            : this(new DataRecorderMetaDataFactory())
        { }

        public EventCustomerMapper(IDataRecorderMetaDataFactory dataRecorderMetaDataFactory)
        {
            _dataRecorderMetaDataFactory = dataRecorderMetaDataFactory;
        }

        protected override void MapDomainFields(EventCustomersEntity entity, EventCustomer domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventCustomerId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.AppointmentId = entity.AppointmentId;
            domainObjectToMapTo.AffiliateCampaignId = entity.AffiliateCampaignId;
            domainObjectToMapTo.ClickId = entity.ClickId;
            domainObjectToMapTo.OnlinePayment = entity.IsPaymentOnline;
            domainObjectToMapTo.TestConducted = entity.IsTestConducted;
            domainObjectToMapTo.NoShow = entity.NoShow;
            domainObjectToMapTo.MarketingSource = entity.MarketingSource;
            domainObjectToMapTo.HIPAAStatus =
                (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.Hipaastatus.ToString());
            domainObjectToMapTo.PartnerRelease = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.PartnerRelease.ToString());
            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData
                                                           {
                                                               DataRecorderCreator =
                                                                   new OrganizationRoleUser(entity.CreatedByOrgRoleUserId),
                                                               DateCreated = entity.DateCreated.Value
                                                           };
            domainObjectToMapTo.HospitalFacilityId = entity.HospitalFacilityId;
            domainObjectToMapTo.AbnStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.AbnStatus.ToString());
            domainObjectToMapTo.PcpConsentStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.PcpConsentStatus.ToString());
            domainObjectToMapTo.InsuranceReleaseStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.InsuranceReleaseStatus.ToString());
            domainObjectToMapTo.CampaignId = entity.CampaignId;
            domainObjectToMapTo.LeftWithoutScreeningReasonId = entity.LeftWithoutScreeningReasonId;
            domainObjectToMapTo.LeftWithoutScreeningNotesId = entity.LeftWithoutScreeningReasonId.HasValue ? entity.LeftWithoutScreeningNotesId : null;
            domainObjectToMapTo.AwvVisitId = entity.AwvVisitId;
            domainObjectToMapTo.EnableTexting = entity.EnableTexting;
            domainObjectToMapTo.IsGiftCertificateDelivered = entity.IsGiftCertificateDelivered;
            domainObjectToMapTo.GiftCode = entity.GiftCode;
            domainObjectToMapTo.PatientDetailId = entity.PatientDetailId;
            domainObjectToMapTo.CustomerProfileHistoryId = entity.CustomerProfileHistoryId;
            domainObjectToMapTo.IsAppointmentConfirmed = entity.IsAppointmentConfirmed;
            domainObjectToMapTo.ConfirmedBy = entity.ConfirmedBy;
            domainObjectToMapTo.IsForRetest = entity.IsForRetest;
            domainObjectToMapTo.PreferredContactType = entity.PreferredContactType;
            domainObjectToMapTo.GcNotGivenReasonId = entity.GcNotGivenReasonId;
            domainObjectToMapTo.NoShowDate = entity.NoShowDate;
            domainObjectToMapTo.SingleTestOverride = entity.SingleTestOverride;
            domainObjectToMapTo.IsParticipationConsentSigned = entity.IsParticipationConsentSigned;
            domainObjectToMapTo.IsPhysicianRecordRequestSigned = entity.IsPhysicianRecordRequestSigned;
            domainObjectToMapTo.IsFluVaccineConsentSigned = entity.IsFluVaccineConsentSigned;
        }

        protected override void MapEntityFields(EventCustomer domainObject, EventCustomersEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerId = domainObject.Id;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.AppointmentId = domainObject.AppointmentId;
            entityToMapTo.AffiliateCampaignId = domainObject.AffiliateCampaignId;
            entityToMapTo.ClickId = domainObject.ClickId;
            entityToMapTo.IsPaymentOnline = domainObject.OnlinePayment;
            entityToMapTo.IsTestConducted = domainObject.TestConducted;
            entityToMapTo.NoShow = domainObject.NoShow;
            entityToMapTo.MarketingSource = domainObject.MarketingSource;
            entityToMapTo.Hipaastatus = (short)domainObject.HIPAAStatus;
            entityToMapTo.PartnerRelease = (short)domainObject.PartnerRelease;
            entityToMapTo.CreatedByOrgRoleUserId = domainObject.DataRecorderMetaData.DataRecorderCreator.Id;

            entityToMapTo.DateCreated = domainObject.DataRecorderMetaData != null
                                            ? domainObject.DataRecorderMetaData.DateCreated
                                            : default(DateTime);
            entityToMapTo.HospitalFacilityId = domainObject.HospitalFacilityId;
            entityToMapTo.AbnStatus = (short)domainObject.AbnStatus;
            entityToMapTo.PcpConsentStatus = (short)domainObject.PcpConsentStatus;
            entityToMapTo.InsuranceReleaseStatus = (short)domainObject.InsuranceReleaseStatus;
            entityToMapTo.CampaignId = domainObject.CampaignId;
            entityToMapTo.AwvVisitId = domainObject.AwvVisitId;
            entityToMapTo.Fields["AwvVisitId"].IsChanged = true;
            entityToMapTo.LeftWithoutScreeningReasonId = domainObject.LeftWithoutScreeningReasonId;
            entityToMapTo.Fields["LeftWithoutScreeningReasonId"].IsChanged = true;

            entityToMapTo.LeftWithoutScreeningNotesId = domainObject.LeftWithoutScreeningReasonId.HasValue ? domainObject.LeftWithoutScreeningNotesId : null;
            entityToMapTo.Fields["LeftWithoutScreeningNotesId"].IsChanged = true;

            entityToMapTo.EnableTexting = domainObject.EnableTexting;
            entityToMapTo.IsGiftCertificateDelivered = domainObject.IsGiftCertificateDelivered;
            entityToMapTo.GiftCode = domainObject.GiftCode;
            entityToMapTo.PatientDetailId = domainObject.PatientDetailId;
            entityToMapTo.CustomerProfileHistoryId = domainObject.CustomerProfileHistoryId;
            entityToMapTo.IsAppointmentConfirmed = domainObject.IsAppointmentConfirmed;
            entityToMapTo.ConfirmedBy = domainObject.ConfirmedBy;
            entityToMapTo.Fields["ConfirmedBy"].IsChanged = true;
            entityToMapTo.IsForRetest = domainObject.IsForRetest;
            entityToMapTo.PreferredContactType = domainObject.PreferredContactType;
            entityToMapTo.GcNotGivenReasonId = domainObject.GcNotGivenReasonId;
            entityToMapTo.NoShowDate = domainObject.NoShow ? domainObject.NoShowDate : null;
            entityToMapTo.Fields["NoShowDate"].IsChanged = true;
            entityToMapTo.SingleTestOverride = domainObject.SingleTestOverride;
            entityToMapTo.IsParticipationConsentSigned = domainObject.IsParticipationConsentSigned;
            entityToMapTo.IsPhysicianRecordRequestSigned = domainObject.IsPhysicianRecordRequestSigned;
            entityToMapTo.IsFluVaccineConsentSigned = domainObject.IsFluVaccineConsentSigned;
        }
    }
}
