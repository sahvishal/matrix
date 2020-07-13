using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.ValueTypes;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class HospitalPartnerMapper : DomainEntityMapper<HospitalPartner, HospitalPartnerEntity>
    {
        private readonly IPhoneNumberFactory _phoneNumberFactory;
        public HospitalPartnerMapper(IPhoneNumberFactory phoneNumberFactory)
        {
            _phoneNumberFactory = phoneNumberFactory;
        }

        public HospitalPartnerMapper()
        {
            _phoneNumberFactory = new PhoneNumberFactory();
        }
        protected override void MapDomainFields(HospitalPartnerEntity entity,
            HospitalPartner domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.HospitalPartnerId;
            domainObjectToMapTo.AssociatedPhoneNumber = _phoneNumberFactory.CreatePhoneNumber(entity.AssociatedPhoneNumber, PhoneNumberType.Unknown);
            domainObjectToMapTo.IsGlobal = entity.IsGlobal;
            domainObjectToMapTo.MailTransitDays = entity.MailTransitDays;
            domainObjectToMapTo.AdvocateId = entity.AdvocateId;
            domainObjectToMapTo.TerritoryIds = !entity.HospitalPartnerTerritory.IsNullOrEmpty()
                                                  ? entity.HospitalPartnerTerritory.Select(hpt => hpt.TerritoryId)
                                                  : null;
            domainObjectToMapTo.NormalResultValidityPeriod = entity.NormalResultValidityPeriod;
            domainObjectToMapTo.AbnormalResultValidityPeriod = entity.AbnormalResultValidityPeriod;
            domainObjectToMapTo.CriticalResultValidityPeriod = entity.CriticalResultValidityPeriod;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.CannedMessage = entity.CannedMessage;
            domainObjectToMapTo.CaptureSsn = entity.CaptureSsn;
            domainObjectToMapTo.RecommendPackage = entity.RecommendPackage;
            domainObjectToMapTo.AskPreQualificationQuestion = entity.AskPreQualificationQuestion;
            domainObjectToMapTo.AttachDoctorLetter = entity.AttachDoctorLetter;
            domainObjectToMapTo.RestrictEvaluation = entity.RestrictEvaluation;
            domainObjectToMapTo.ShowOnlineShipping = entity.ShowOnlineShipping;

        }

        protected override void MapEntityFields(HospitalPartner domainObject,
            HospitalPartnerEntity entityToMapTo)
        {
            entityToMapTo.HospitalPartnerId = domainObject.Id;
            entityToMapTo.AssociatedPhoneNumber = domainObject.AssociatedPhoneNumber != null
                                                      ? PhoneNumber.ToNumber(
                                                          domainObject.AssociatedPhoneNumber.ToString())
                                                      : string.Empty;
            entityToMapTo.IsGlobal = domainObject.IsGlobal;
            entityToMapTo.AdvocateId = domainObject.AdvocateId;
            entityToMapTo.MailTransitDays = domainObject.MailTransitDays;
            entityToMapTo.NormalResultValidityPeriod = domainObject.NormalResultValidityPeriod;
            entityToMapTo.AbnormalResultValidityPeriod = domainObject.AbnormalResultValidityPeriod;
            entityToMapTo.CriticalResultValidityPeriod = domainObject.CriticalResultValidityPeriod;
            entityToMapTo.HafTemplateId = domainObject.HealthAssessmentTemplateId.HasValue && domainObject.HealthAssessmentTemplateId.Value > 0
                                              ? domainObject.HealthAssessmentTemplateId
                                              : null;
            entityToMapTo.CannedMessage = domainObject.CannedMessage;
            entityToMapTo.CaptureSsn = domainObject.CaptureSsn;
            entityToMapTo.RecommendPackage = domainObject.RecommendPackage;
            
            entityToMapTo.Fields["HafTemplateId"].IsChanged = true;
            entityToMapTo.AskPreQualificationQuestion = domainObject.AskPreQualificationQuestion;
            entityToMapTo.AttachDoctorLetter = domainObject.AttachDoctorLetter;
            entityToMapTo.RestrictEvaluation = domainObject.RestrictEvaluation;
            entityToMapTo.ShowOnlineShipping = domainObject.ShowOnlineShipping;

        }
    }
}