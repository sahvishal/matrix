using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    [DefaultImplementation(Interface = typeof(IMapper<EventCustomer, VwEventCustomersAccountEntity>))]
    public class EventCustomerViewMapper : DomainEntityMapper<EventCustomer, VwEventCustomersAccountEntity>
    {
        protected override void MapDomainFields(VwEventCustomersAccountEntity entity, EventCustomer domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventCustomerId;
            domainObjectToMapTo.EventId = entity.EventId;
            domainObjectToMapTo.CustomerId = entity.CustomerId;
            domainObjectToMapTo.AppointmentId = entity.AppointmentId > 0 ? entity.AppointmentId : (long?)null;
            domainObjectToMapTo.AffiliateCampaignId = entity.AffiliateCampaignId > 0 ? entity.AffiliateCampaignId : (long?)null;
            domainObjectToMapTo.ClickId = entity.ClickId > 0 ? entity.ClickId : (long?)null;
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
                                                               DateCreated = entity.DateCreated
                                                           };
            domainObjectToMapTo.HospitalFacilityId = entity.HospitalFacilityId > 0 ? entity.HospitalFacilityId : (long?)null;
            /*domainObjectToMapTo.AbnStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.AbnStatus.ToString());
            domainObjectToMapTo.PcpConsentStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.PcpConsentStatus.ToString());*/
            domainObjectToMapTo.InsuranceReleaseStatus = (RegulatoryState)Enum.Parse(typeof(RegulatoryState), entity.InsuranceReleaseStatus.ToString());
            domainObjectToMapTo.CampaignId = entity.CampaignId > 0 ? entity.CampaignId : (long?)null;
            domainObjectToMapTo.LeftWithoutScreeningReasonId = entity.LeftWithoutScreeningReasonId > 0 ? entity.LeftWithoutScreeningReasonId : (long?)null;
            domainObjectToMapTo.AwvVisitId = entity.AwvVisitId > 0 ? entity.AwvVisitId : (long?)null;
            domainObjectToMapTo.EnableTexting = entity.EnableTexting;
            domainObjectToMapTo.IsGiftCertificateDelivered = entity.IsGiftCertificateDelivered;
            domainObjectToMapTo.GiftCode = entity.GiftCode;
            domainObjectToMapTo.PatientDetailId = entity.PatientDetailId > 0 ? entity.PatientDetailId : (long?)null;
            domainObjectToMapTo.IsAppointmentConfirmed = entity.IsAppointmentConfirmed;
            domainObjectToMapTo.ConfirmedBy = entity.ConfirmedBy;
            domainObjectToMapTo.PreferredContactType = entity.PreferredContactType;
        }

        protected override void MapEntityFields(EventCustomer domainObject, VwEventCustomersAccountEntity entityToMapTo)
        {
            entityToMapTo.EventCustomerId = domainObject.Id;
            entityToMapTo.EventId = domainObject.EventId;
            entityToMapTo.CustomerId = domainObject.CustomerId;
            entityToMapTo.AppointmentId = domainObject.AppointmentId.HasValue ? domainObject.AppointmentId.Value : 0;
            entityToMapTo.AffiliateCampaignId = domainObject.AffiliateCampaignId.HasValue ? domainObject.AffiliateCampaignId.Value : 0;
            entityToMapTo.ClickId = domainObject.ClickId.HasValue ? domainObject.ClickId.Value : 0;
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
            entityToMapTo.HospitalFacilityId = domainObject.HospitalFacilityId.HasValue ? domainObject.HospitalFacilityId.Value : 0;
            entityToMapTo.InsuranceReleaseStatus = (short)domainObject.InsuranceReleaseStatus;
            entityToMapTo.CampaignId = domainObject.CampaignId.HasValue ? domainObject.CampaignId.Value : 0;
            entityToMapTo.AwvVisitId = domainObject.AwvVisitId.HasValue ? domainObject.AwvVisitId.Value : 0;
            entityToMapTo.LeftWithoutScreeningReasonId = domainObject.LeftWithoutScreeningReasonId.HasValue ? domainObject.LeftWithoutScreeningReasonId.Value : 0;
            entityToMapTo.EnableTexting = domainObject.EnableTexting;
            entityToMapTo.IsGiftCertificateDelivered = domainObject.IsGiftCertificateDelivered ?? false;
            entityToMapTo.GiftCode = domainObject.GiftCode;
            entityToMapTo.PatientDetailId = domainObject.PatientDetailId.HasValue ? domainObject.PatientDetailId.Value : 0;
            //entityToMapTo.PcpAppointment = domainObject.PcpAppointment;
            entityToMapTo.IsAppointmentConfirmed = domainObject.IsAppointmentConfirmed;
            entityToMapTo.ConfirmedBy = domainObject.ConfirmedBy.HasValue ? domainObject.ConfirmedBy.Value : 0;
            entityToMapTo.PreferredContactType = domainObject.PreferredContactType.HasValue ? domainObject.PreferredContactType.Value : 0;
        }
    }
}
