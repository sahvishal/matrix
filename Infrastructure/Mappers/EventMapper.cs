using System;
using System.Linq;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;
using Falcon.App.Core.Extensions;

namespace Falcon.App.Infrastructure.Mappers
{
    public class EventMapper : DomainEntityMapper<Event, EventsEntity>
    {
        protected override void MapDomainFields(EventsEntity entity, Event domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.EventId;
            domainObjectToMapTo.AssignedtoOrgRoleUserId = entity.AssignedToOrgRoleUserId;
            domainObjectToMapTo.Name = entity.EventName;
            domainObjectToMapTo.EventDate = entity.EventDate;
            domainObjectToMapTo.EventStartTime = entity.EventStartTime;
            domainObjectToMapTo.EventEndTime = entity.EventEndTime;
            domainObjectToMapTo.TimeZone = entity.TimeZone;
            domainObjectToMapTo.RegistrationMode = (RegistrationMode)Enum.Parse(typeof(RegistrationMode), entity.EventTypeId.ToString());
            domainObjectToMapTo.Status = (EventStatus)Enum.Parse(typeof(EventStatus), entity.EventStatus.ToString());
            domainObjectToMapTo.EventNotes = entity.EventNotes;
            domainObjectToMapTo.InvitationCode = entity.InvitationCode;
            domainObjectToMapTo.IsSignOff = entity.IsSignoff;
            domainObjectToMapTo.SignOffDate = entity.SignoffDatetime;
            domainObjectToMapTo.SignOffOrgRoleUserId = entity.SignOffOrgRoleUserId;

            if (!entity.EventPod.IsNullOrEmpty())
                domainObjectToMapTo.PodIds = entity.EventPod.Where(ep => ep.IsActive).Select(ep => ep.PodId).ToArray();

            if (entity.EventAccount != null)
            {
                domainObjectToMapTo.EventType = EventType.Corporate;
                domainObjectToMapTo.AccountId = entity.EventAccount.AccountId;
            }
            else
            {
                domainObjectToMapTo.EventType = EventType.Retail;
            }

            if (!entity.HostEventDetails.IsNullOrEmpty())
            {
                domainObjectToMapTo.HostId = entity.HostEventDetails.Single(he => he.EventId == entity.EventId).HostId;
                domainObjectToMapTo.CallCenterNotes = entity.HostEventDetails.Single(he => he.EventId == entity.EventId).InstructionForCallCenter;
                domainObjectToMapTo.TechnicianNotes = entity.HostEventDetails.Single(he => he.EventId == entity.EventId).ConfirmedVisuallyComments;
            }

            domainObjectToMapTo.EnableAlaCarteOnline = entity.EnableAlaCarteOnline;
            domainObjectToMapTo.EnableAlaCarteCallCenter = entity.EnableAlaCarteCallCenter;
            domainObjectToMapTo.EnableAlaCarteTechnician = entity.EnableAlaCarteTechnician;
            domainObjectToMapTo.IsDynamicScheduling = entity.IsDynamicScheduling;
            domainObjectToMapTo.SlotInterval = entity.SlotInterval;
            domainObjectToMapTo.ServerRooms = entity.ServerRooms;
            domainObjectToMapTo.LunchStartTime = entity.LunchStartTime;
            domainObjectToMapTo.LunchDuration = entity.LunchDuration;
            domainObjectToMapTo.HealthAssessmentTemplateId = entity.HafTemplateId;
            domainObjectToMapTo.NotifyResultReady = entity.NotifyResultReady;
            domainObjectToMapTo.CaptureInsuranceId = entity.CaptureInsuranceId;
            domainObjectToMapTo.InsuranceIdRequired = entity.InsuranceIdRequired;
            domainObjectToMapTo.IsFemaleOnly = entity.IsFemaleOnly;

            domainObjectToMapTo.GenerateKynXml = entity.GenerateKynXml;
            domainObjectToMapTo.GenerateHKynXml = entity.GenerateHkynXml;
            domainObjectToMapTo.RecommendPackage = entity.RecommendPackage;
            domainObjectToMapTo.AskPreQualifierQuestion = entity.AskPreQualifierQuestion;
            domainObjectToMapTo.FixedGroupScreeningTime = entity.FixedGroupScreeningTime;
            domainObjectToMapTo.BloodPackageTracking = entity.BloodPackageTracking;
            domainObjectToMapTo.RecordsPackageTracking = entity.RecordsPackageTracking;
            domainObjectToMapTo.EventCancellationReasonId = entity.EventCancellationReasonId;

            domainObjectToMapTo.EnableForCallCenter = entity.EnableForCallCenter;
            domainObjectToMapTo.EnableForTechnician = entity.EnableForTechnician;

            domainObjectToMapTo.IsPackageTimeOnly = entity.IsPackageTimeOnly;
            domainObjectToMapTo.UpdatedByAdmin = entity.UpdatedByAdmin;
            domainObjectToMapTo.IsManual = entity.IsManual;

            domainObjectToMapTo.DataRecorderMetaData = new DataRecorderMetaData(entity.CreatedByOrgRoleUserId, entity.DateCreated, entity.DateModified);
            if (entity.UpdatedByOrganizationRoleUser.HasValue)
                domainObjectToMapTo.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(entity.UpdatedByOrganizationRoleUser.Value);

            domainObjectToMapTo.GenerateHealthAssesmentForm = entity.GenerateHealthAssesmentForm;
            domainObjectToMapTo.GenerateHealthAssesmentFormStatus = entity.GenerateHealthAssesmentFormStatus;
            domainObjectToMapTo.IsLocked = entity.IsLocked;
            domainObjectToMapTo.AllowNonMammoPatients = entity.AllowNonMammoPatients;
        }

        protected override void MapEntityFields(Event domainObject, EventsEntity entityToMapTo)
        {
            throw new NotImplementedException();
        }
    }
}
