///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:38
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using Falcon.Data;
using Falcon.Data.FactoryClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: OrganizationRoleUser. </summary>
	public partial class OrganizationRoleUserRelations
	{
		/// <summary>CTor</summary>
		public OrganizationRoleUserRelations()
		{
		}

		/// <summary>Gets all relations of the OrganizationRoleUserEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountCallCenterOrganizationEntityUsingModifiedBy);
			toReturn.Add(this.AccountCallCenterOrganizationEntityUsingCreatedBy);
			toReturn.Add(this.AccountHraChatQuestionnaireEntityUsingModifiedBy);
			toReturn.Add(this.AccountHraChatQuestionnaireEntityUsingCreatedBy);
			toReturn.Add(this.AccountTestHcpcsCodeEntityUsingModifiedBy);
			toReturn.Add(this.AccountTestHcpcsCodeEntityUsingCreatedBy);
			toReturn.Add(this.ActivityTypeEntityUsingCreatedBy);
			toReturn.Add(this.AdditionalFieldsEntityUsingModifiedBy);
			toReturn.Add(this.AdditionalFieldsEntityUsingCreatedBy);
			toReturn.Add(this.AddressEntityUsingVerificationOrgRoleUserId);
			toReturn.Add(this.AdvocateManagerTeamEntityUsingSalesRepOrgRoleUserId);
			toReturn.Add(this.AdvocateManagerTeamEntityUsingManagerOrgRoleUserId);
			toReturn.Add(this.AfcampaignEntityUsingRoleId);
			toReturn.Add(this.AfcampaignEntityUsingShellId);
			toReturn.Add(this.AffiliateProfileEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ApplicationAuthenticationEntityUsingModifiedBy);
			toReturn.Add(this.ApplicationAuthenticationEntityUsingCreatedBy);
			toReturn.Add(this.BarrierEntityUsingModifiedBy);
			toReturn.Add(this.BarrierEntityUsingCreatedBy);
			toReturn.Add(this.CallCenterAgentTeamEntityUsingAgentId);
			toReturn.Add(this.CallCenterAgentTeamLogEntityUsingRemovedByOrgRoleUserId);
			toReturn.Add(this.CallCenterAgentTeamLogEntityUsingAssignedByOrgRoleUserId);
			toReturn.Add(this.CallCenterAgentTeamLogEntityUsingAgentId);
			toReturn.Add(this.CallCenterTeamEntityUsingModifiedBy);
			toReturn.Add(this.CallCenterTeamEntityUsingCreatedBy);
			toReturn.Add(this.CallQueueEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.CallQueueEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CallQueueAssignmentEntityUsingAssignedOrgRoleUserId);
			toReturn.Add(this.CallQueueCustomerEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.CallQueueCustomerEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CallQueueCustomerEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.CallQueueCustomerLockEntityUsingCreatedBy);
			toReturn.Add(this.CallQueueCustomTagEntityUsingCreatedBy);
			toReturn.Add(this.CallRoundCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.CallsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CallUploadEntityUsingUploadedBy);
			toReturn.Add(this.CampaignEntityUsingModifiedby);
			toReturn.Add(this.CampaignEntityUsingCreatedby);
			toReturn.Add(this.CampaignActivityEntityUsingModifiedby);
			toReturn.Add(this.CampaignActivityEntityUsingCreatedby);
			toReturn.Add(this.CampaignActivityAssignmentEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.CampaignAssignmentEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.CdcontentGeneratorTrackingEntityUsingDownloadedByOrgRoleUserId);
			toReturn.Add(this.ChaperoneAnswerEntityUsingModifiedBy);
			toReturn.Add(this.ChaperoneAnswerEntityUsingCreatedBy);
			toReturn.Add(this.ChaperoneSignatureEntityUsingCreatedBy);
			toReturn.Add(this.CheckEntityUsingDataRecoderModifierId);
			toReturn.Add(this.CheckEntityUsingDataRecoderCreatorId);
			toReturn.Add(this.CheckListAnswerEntityUsingModifiedBy);
			toReturn.Add(this.CheckListAnswerEntityUsingCreatedBy);
			toReturn.Add(this.CheckListTemplateEntityUsingModifiedBy);
			toReturn.Add(this.CheckListTemplateEntityUsingCreatedBy);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingModifiedBy);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingCreatedBy);
			toReturn.Add(this.ContactCallEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ContactCallEntityUsingCreatedByRoleId);
			toReturn.Add(this.ContactMeetingEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ContactMeetingEntityUsingCreatedByRoleId);
			toReturn.Add(this.ContentEntityUsingModifiedBy);
			toReturn.Add(this.ContentEntityUsingCreatedBy);
			toReturn.Add(this.CorporateTagEntityUsingModifiedBy);
			toReturn.Add(this.CorporateTagEntityUsingCreatedBy);
			toReturn.Add(this.CorporateUploadEntityUsingUploadedBy);
			toReturn.Add(this.CouponsEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.CouponsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CurrentMedicationEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerActivityTypeUploadEntityUsingUploadedBy);
			toReturn.Add(this.CustomerCallAttemptsEntityUsingUpdatedBy);
			toReturn.Add(this.CustomerCallQueueCallAttemptEntityUsingCreatedBy);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingModifiedBy);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingCreatedBy);
			toReturn.Add(this.CustomerEligibilityEntityUsingModifiedBy);
			toReturn.Add(this.CustomerEligibilityEntityUsingCreatedBy);
			toReturn.Add(this.CustomerEventCriticalTestDataEntityUsingValidatingTechnicianId);
			toReturn.Add(this.CustomerEventCriticalTestDataEntityUsingTechnicianId);
			toReturn.Add(this.CustomerEventPriorityInQueueDataEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventPriorityInQueueDataEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventReadingEntityUsingUpdatedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventTestPhysicianEvaluationEntityUsingUpdatedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventTestStateEntityUsingUpdatedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventTestStateEntityUsingEvaluatedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventTestStateEntityUsingConductedByOrgRoleUserId);
			toReturn.Add(this.CustomerEventUnableScreenReasonEntityUsingUpdatedByOrgRoleUserId);
			toReturn.Add(this.CustomerHealthInfoEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerHealthInfoArchiveEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerIcdCodeEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerLockForCallEntityUsingCreatedBy);
			toReturn.Add(this.CustomerMedicareQuestionAnswerEntityUsingCreateBy);
			toReturn.Add(this.CustomerPhoneNumberUpdateUploadEntityUsingUploadedByOrgRoleUserId);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingPcpAddressVerifiedBy);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingUpdatedByOrganizationRoleUserId);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingCreatedBy);
			toReturn.Add(this.CustomerRegistrationNotesEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerResultScreeningCommunicationEntityUsingPhysicianOrgRoleUserId);
			toReturn.Add(this.CustomerResultScreeningCommunicationEntityUsingFranchiseeAdminOrgRoleUserId);
			toReturn.Add(this.CustomerResultScreeningCommunicationEntityUsingCommunicationInitiatedByOrgRoleUserId);
			toReturn.Add(this.CustomerTagEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.CustomerTagEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.CustomerTargetedEntityUsingModifiedBy);
			toReturn.Add(this.CustomerTargetedEntityUsingCreatedBy);
			toReturn.Add(this.CustomerWarmTransferEntityUsingModifiedBy);
			toReturn.Add(this.CustomerWarmTransferEntityUsingCreatedBy);
			toReturn.Add(this.CustomEventNotificationEntityUsingCreatedBy);
			toReturn.Add(this.DirectMailEntityUsingMailedBy);
			toReturn.Add(this.DirectMailTypeEntityUsingModifiedBy);
			toReturn.Add(this.DirectMailTypeEntityUsingCreatedBy);
			toReturn.Add(this.DisqualifiedTestEntityUsingUpdatedBy);
			toReturn.Add(this.DisqualifiedTestEntityUsingCreatedBy);
			toReturn.Add(this.EligibilityEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EligibilityUploadEntityUsingUploadedBy);
			toReturn.Add(this.EmailTemplateEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.EventAccountTestHcpcsCodeEntityUsingModifiedBy);
			toReturn.Add(this.EventAccountTestHcpcsCodeEntityUsingCreatedBy);
			toReturn.Add(this.EventActivityTemplateEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.EventActivityTemplateCallEntityUsingResponsibleOrgRoleUserId);
			toReturn.Add(this.EventActivityTemplateEmailEntityUsingResponsibleOrgRoleUserId);
			toReturn.Add(this.EventActivityTemplateMeetingEntityUsingResponsibleOrgRoleUserId);
			toReturn.Add(this.EventActivityTemplateTaskEntityUsingResponsibleOrgRoleUserId);
			toReturn.Add(this.EventAppointmentEntityUsingScheduledByOrgRoleUserId);
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingCreatedBy);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EventCustomerBasicBioMetricEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EventCustomerGiftCardEntityUsingCreatedBy);
			toReturn.Add(this.EventCustomerPrimaryCarePhysicianEntityUsingPcpAddressVerifiedBy);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingUpdatedBy);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingCreatedBy);
			toReturn.Add(this.EventCustomerResultEntityUsingSignedOffBy);
			toReturn.Add(this.EventCustomerResultEntityUsingRegeneratedBy);
			toReturn.Add(this.EventCustomerResultEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.EventCustomerResultEntityUsingVerifiedBy);
			toReturn.Add(this.EventCustomerResultEntityUsingInvoiceDateUpdatedBy);
			toReturn.Add(this.EventCustomerResultEntityUsingChatPdfReviewedByOverreadPhysicianId);
			toReturn.Add(this.EventCustomerResultEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EventCustomerResultEntityUsingCodedBy);
			toReturn.Add(this.EventCustomerResultEntityUsingChatPdfReviewedByPhysicianId);
			toReturn.Add(this.EventCustomerResultBloodLabEntityUsingCreatedByOrgRoleUserid);
			toReturn.Add(this.EventCustomerResultHistoryEntityUsingInvoiceDateUpdatedBy);
			toReturn.Add(this.EventCustomerResultHistoryEntityUsingChatPdfReviewedByPhysicianId);
			toReturn.Add(this.EventCustomerResultHistoryEntityUsingChatPdfReviewedByOverreadPhysicianId);
			toReturn.Add(this.EventCustomerRetestEntityUsingCreatedBy);
			toReturn.Add(this.EventCustomersEntityUsingConfirmedBy);
			toReturn.Add(this.EventCustomersEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EventCustomerTestNotPerformedNotificationEntityUsingCreatedBy);
			toReturn.Add(this.EventNoteEntityUsingModifiedBy);
			toReturn.Add(this.EventNoteEntityUsingCreatedBy);
			toReturn.Add(this.EventPhysicianTestEntityUsingPhysicianId);
			toReturn.Add(this.EventPhysicianTestEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.EventPhysicianTestEntityUsingAssignedByOrgRoleUserId);
			toReturn.Add(this.EventsEntityUsingSignOffOrgRoleUserId);
			toReturn.Add(this.EventsEntityUsingUpdatedByAdmin);
			toReturn.Add(this.EventsEntityUsingEventActivityOrgRoleUserId);
			toReturn.Add(this.EventsEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.EventsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.EventStaffAssignmentEntityUsingScheduledByOrgRoleUserId);
			toReturn.Add(this.EventStaffAssignmentEntityUsingActualStaffOrgRoleUserId);
			toReturn.Add(this.EventStaffAssignmentEntityUsingScheduledStaffOrgRoleUserId);
			toReturn.Add(this.ExitInterviewAnswerEntityUsingModifiedBy);
			toReturn.Add(this.ExitInterviewAnswerEntityUsingCreatedBy);
			toReturn.Add(this.ExitInterviewSignatureEntityUsingCreatedBy);
			toReturn.Add(this.ExportableReportsQueueEntityUsingRequestedBy);
			toReturn.Add(this.FileEntityUsingCreatedBy);
			toReturn.Add(this.FillEventCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.FluConsentAnswerEntityUsingModifiedBy);
			toReturn.Add(this.FluConsentAnswerEntityUsingCreatedBy);
			toReturn.Add(this.FluConsentSignatureEntityUsingCreatedBy);
			toReturn.Add(this.FluConsentTemplateEntityUsingModifiedBy);
			toReturn.Add(this.FluConsentTemplateEntityUsingCreatedBy);
			toReturn.Add(this.GcNotGivenReasonEntityUsingModifiedBy);
			toReturn.Add(this.GcNotGivenReasonEntityUsingCreatedBy);
			toReturn.Add(this.GuardianDetailsEntityUsingModifiedBy);
			toReturn.Add(this.GuardianDetailsEntityUsingCreatedBy);
			toReturn.Add(this.HafTemplateEntityUsingModifiedBy);
			toReturn.Add(this.HafTemplateEntityUsingCreatedBy);
			toReturn.Add(this.HcpcsCodeEntityUsingModifiedBy);
			toReturn.Add(this.HcpcsCodeEntityUsingCreatedBy);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.HealthPlanCriteriaAssignmentEntityUsingModifiedBy);
			toReturn.Add(this.HealthPlanCriteriaAssignmentEntityUsingCreatedBy);
			toReturn.Add(this.HealthPlanCriteriaAssignmentEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.HealthPlanCriteriaAssignmentUploadEntityUsingUploadedByOrgRoleUserId);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignmentEntityUsingModifiedBy);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignmentEntityUsingCreatedBy);
			toReturn.Add(this.HealthPlanRevenueEntityUsingModifiedBy);
			toReturn.Add(this.HealthPlanRevenueEntityUsingCreatedBy);
			toReturn.Add(this.HospitalPartnerCustomerEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.HospitalPartnerCustomerEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.HospitalPartnerCustomerEntityUsingCareCoordinatorOrgRoleUserId);
			toReturn.Add(this.HostFacilityRankingEntityUsingRankedByOrganizationRoleUserId);
			toReturn.Add(this.HostPaymentEntityUsingCreatorOrganizationRoleUserId);
			toReturn.Add(this.HostPaymentTransactionEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.IcdCodesEntityUsingModifiedBy);
			toReturn.Add(this.IcdCodesEntityUsingCreatedBy);
			toReturn.Add(this.IncidentalFindingsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.KynLabValuesEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.KynLabValuesEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.LabEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.LanguageEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.LanguageBarrierCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.MailRoundCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.MarketingPrintOrderEntityUsingOrgRoleUserId);
			toReturn.Add(this.MedicationEntityUsingModifiedBy);
			toReturn.Add(this.MedicationEntityUsingCreatedBy);
			toReturn.Add(this.MedicationUploadEntityUsingUploadedBy);
			toReturn.Add(this.MergeCustomerUploadEntityUsingUploadedBy);
			toReturn.Add(this.NoShowCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.NotesDetailsEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.NotesDetailsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.NotificationEntityUsingRequestedByOrgRoleUserId);
			toReturn.Add(this.NotificationTypeEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.OrganizationRoleUserTerritoryEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.OrgRoleUserActivityEntityUsingOrgRoleUserId);
			toReturn.Add(this.ParticipationConsentSignatureEntityUsingCreatedBy);
			toReturn.Add(this.PasswordChangelogEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.PayPeriodEntityUsingModifiedBy);
			toReturn.Add(this.PayPeriodEntityUsingCreatedBy);
			toReturn.Add(this.PcpAppointmentEntityUsingModifiedBy);
			toReturn.Add(this.PcpAppointmentEntityUsingCreatedBy);
			toReturn.Add(this.PcpDispositionEntityUsingModifiedBy);
			toReturn.Add(this.PcpDispositionEntityUsingCreatedBy);
			toReturn.Add(this.PhysicianRecordRequestSignatureEntityUsingCreatedBy);
			toReturn.Add(this.PinChangelogEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.PodDefaultTeamEntityUsingOrgnizationRoleUserId);
			toReturn.Add(this.PreApprovedPackageEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.PreApprovedTestEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.PreAssessmentCallQueueCustomerLockEntityUsingCreatedBy);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCreatedBy);
			toReturn.Add(this.PreQualificationQuestionEntityUsingCreatedBy);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingUpdatedBy);
			toReturn.Add(this.PreQualificationTestTemplateEntityUsingCreatedBy);
			toReturn.Add(this.PrintOrderItemTrackingEntityUsingUpdatedByOrgRoleUserId);
			toReturn.Add(this.PrintOrderItemTrackingEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.PriorityInQueueEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.PriorityInQueueEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.ProspectCustomerEntityUsingContactedBy);
			toReturn.Add(this.ProspectsEntityUsingOrgRoleUserId);
			toReturn.Add(this.RapsUploadEntityUsingUploadedBy);
			toReturn.Add(this.ReferralEntityUsingReferedByOrgRoleUserId);
			toReturn.Add(this.RefundRequestEntityUsingProcessedByOrgRoleUserId);
			toReturn.Add(this.RefundRequestEntityUsingRequestedByOrgRoleUserId);
			toReturn.Add(this.RequiredTestEntityUsingCreatedBy);
			toReturn.Add(this.SalesRepPodAssigmentsEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.ScheduleTemplateEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.ScheduleTemplateEntityUsingModifiedBy);
			toReturn.Add(this.SeminarsEntityUsingOrgRoleUserId);
			toReturn.Add(this.ShippingDetailEntityUsingShippedByOrgRoleUserId);
			toReturn.Add(this.ShippingDetailEntityUsingModifiedBy);
			toReturn.Add(this.SourceCodeChangeLogEntityUsingShellid);
			toReturn.Add(this.StaffEventScheduleUploadEntityUsingUploadedByOrgRoleUserId);
			toReturn.Add(this.SurveyAnswerEntityUsingModifiedBy);
			toReturn.Add(this.SurveyAnswerEntityUsingCreatedBy);
			toReturn.Add(this.SurveyTemplateEntityUsingModifiedBy);
			toReturn.Add(this.SurveyTemplateEntityUsingCreatedBy);
			toReturn.Add(this.SuspectConditionUploadEntityUsingUploadedBy);
			toReturn.Add(this.SystemGeneratedCallQueueCriteriaEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.SystemGeneratedCallQueueCriteriaEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.SystemGeneratedCallQueueCriteriaEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.TaskDetailsEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.TaskDetailsEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.TaskDetailsEntityUsingAssignedToOrgRoleUserId);
			toReturn.Add(this.TerritoryEntityUsingCreatedBy);
			toReturn.Add(this.TestHcpcsCodeEntityUsingModifiedBy);
			toReturn.Add(this.TestHcpcsCodeEntityUsingCreatedBy);
			toReturn.Add(this.TestNotPerformedEntityUsingUpdatedBy);
			toReturn.Add(this.TestNotPerformedEntityUsingCreatedBy);
			toReturn.Add(this.TestNotPerformedReasonEntityUsingCreatedBy);
			toReturn.Add(this.TestPerformedExternallyEntityUsingModifiedBy);
			toReturn.Add(this.TestPerformedExternallyEntityUsingCreatedBy);
			toReturn.Add(this.UncontactedCustomerCallQueueEntityUsingModifiedBy);
			toReturn.Add(this.UploadZipInfoEntityUsingUploadedByOrgRoleUserId);
			toReturn.Add(this.UserEntityUsingModifiedByOrgRoleUserId);
			toReturn.Add(this.UserEntityUsingCreatedByOrgRoleUserId);
			toReturn.Add(this.AccountCoordinatorProfileEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.AffiliateProfileEntityUsingAffiliateId);
			toReturn.Add(this.CallCenterRepProfileEntityUsingCallCenterRepId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.PhysicianProfileEntityUsingPhysicianId);
			toReturn.Add(this.TechnicianProfileEntityUsingOrganizationRoleUserId);
			toReturn.Add(this.OrganizationEntityUsingOrganizationId);
			toReturn.Add(this.RoleEntityUsingRoleId);
			toReturn.Add(this.UserEntityUsingUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountCallCenterOrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountCallCenterOrganization.ModifiedBy
		/// </summary>
		public virtual IEntityRelation AccountCallCenterOrganizationEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallCenterOrganization_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountCallCenterOrganizationFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallCenterOrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountCallCenterOrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountCallCenterOrganization.CreatedBy
		/// </summary>
		public virtual IEntityRelation AccountCallCenterOrganizationEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallCenterOrganization" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountCallCenterOrganizationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallCenterOrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountHraChatQuestionnaireEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountHraChatQuestionnaire.ModifiedBy
		/// </summary>
		public virtual IEntityRelation AccountHraChatQuestionnaireEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHraChatQuestionnaire_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountHraChatQuestionnaireFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHraChatQuestionnaireEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountHraChatQuestionnaireEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountHraChatQuestionnaire.CreatedBy
		/// </summary>
		public virtual IEntityRelation AccountHraChatQuestionnaireEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHraChatQuestionnaire" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountHraChatQuestionnaireFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHraChatQuestionnaireEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountTestHcpcsCode.ModifiedBy
		/// </summary>
		public virtual IEntityRelation AccountTestHcpcsCodeEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTestHcpcsCode_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountTestHcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountTestHcpcsCode.CreatedBy
		/// </summary>
		public virtual IEntityRelation AccountTestHcpcsCodeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountTestHcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ActivityTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ActivityType.CreatedBy
		/// </summary>
		public virtual IEntityRelation ActivityTypeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ActivityType" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ActivityTypeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActivityTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AdditionalFieldsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AdditionalFields.ModifiedBy
		/// </summary>
		public virtual IEntityRelation AdditionalFieldsEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AdditionalFields_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdditionalFieldsFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AdditionalFieldsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AdditionalFields.CreatedBy
		/// </summary>
		public virtual IEntityRelation AdditionalFieldsEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AdditionalFields" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdditionalFieldsFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdditionalFieldsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AddressEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Address.VerificationOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingVerificationOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Address" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AddressFields.VerificationOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AdvocateManagerTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AdvocateManagerTeam.SalesRepOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation AdvocateManagerTeamEntityUsingSalesRepOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AdvocateManagerTeam_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdvocateManagerTeamFields.SalesRepOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdvocateManagerTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AdvocateManagerTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AdvocateManagerTeam.ManagerOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation AdvocateManagerTeamEntityUsingManagerOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AdvocateManagerTeam" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AdvocateManagerTeamFields.ManagerOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AdvocateManagerTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AfcampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Afcampaign.RoleId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcampaign_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AfcampaignFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AfcampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Afcampaign.ShellId
		/// </summary>
		public virtual IEntityRelation AfcampaignEntityUsingShellId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Afcampaign" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AfcampaignFields.ShellId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfcampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AffiliateProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AffiliateProfile.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AffiliateProfile" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AffiliateProfileFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ApplicationAuthenticationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ApplicationAuthentication.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ApplicationAuthenticationEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ApplicationAuthentication_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ApplicationAuthenticationFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ApplicationAuthenticationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ApplicationAuthenticationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ApplicationAuthentication.CreatedBy
		/// </summary>
		public virtual IEntityRelation ApplicationAuthenticationEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ApplicationAuthentication" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ApplicationAuthenticationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ApplicationAuthenticationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and BarrierEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Barrier.ModifiedBy
		/// </summary>
		public virtual IEntityRelation BarrierEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Barrier_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, BarrierFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BarrierEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and BarrierEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Barrier.CreatedBy
		/// </summary>
		public virtual IEntityRelation BarrierEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Barrier" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, BarrierFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BarrierEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterAgentTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterAgentTeam.AgentId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamEntityUsingAgentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeam" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterAgentTeamFields.AgentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterAgentTeamLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterAgentTeamLog.RemovedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamLogEntityUsingRemovedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeamLog__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterAgentTeamLogFields.RemovedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterAgentTeamLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterAgentTeamLog.AssignedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamLogEntityUsingAssignedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeamLog_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterAgentTeamLogFields.AssignedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterAgentTeamLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterAgentTeamLog.AgentId
		/// </summary>
		public virtual IEntityRelation CallCenterAgentTeamLogEntityUsingAgentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterAgentTeamLog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterAgentTeamLogFields.AgentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterAgentTeamLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterTeam.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CallCenterTeamEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterTeam_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterTeamFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterTeam.CreatedBy
		/// </summary>
		public virtual IEntityRelation CallCenterTeamEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterTeam" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterTeamFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueue.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueue_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueue.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueAssignment.AssignedOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueAssignmentEntityUsingAssignedOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueAssignmentFields.AssignedOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueCustomer.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueCustomer.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueCustomer.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueCustomerLockEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueCustomerLock.CreatedBy
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerLockEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomerLock" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomerLockFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerLockEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallQueueCustomTagEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallQueueCustomTag.CreatedBy
		/// </summary>
		public virtual IEntityRelation CallQueueCustomTagEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomTag" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallQueueCustomTagFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallRoundCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallRoundCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Calls.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation CallUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Campaign.Modifiedby
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingModifiedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Campaign_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignFields.Modifiedby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Campaign.Createdby
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCreatedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Campaign" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignFields.Createdby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CampaignActivity.Modifiedby
		/// </summary>
		public virtual IEntityRelation CampaignActivityEntityUsingModifiedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivity_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignActivityFields.Modifiedby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CampaignActivity.Createdby
		/// </summary>
		public virtual IEntityRelation CampaignActivityEntityUsingCreatedby
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivity" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignActivityFields.Createdby);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignActivityAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CampaignActivityAssignment.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CampaignActivityAssignmentEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivityAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignActivityAssignmentFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CampaignAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CampaignAssignment.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CampaignAssignmentEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CampaignAssignmentFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CdcontentGeneratorTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CdcontentGeneratorTracking.DownloadedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CdcontentGeneratorTrackingEntityUsingDownloadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CdcontentGeneratorTracking" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CdcontentGeneratorTrackingFields.DownloadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CdcontentGeneratorTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ChaperoneAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ChaperoneAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ChaperoneAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ChaperoneAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ChaperoneAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ChaperoneAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation ChaperoneAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ChaperoneAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ChaperoneSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ChaperoneSignature.CreatedBy
		/// </summary>
		public virtual IEntityRelation ChaperoneSignatureEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneSignature" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ChaperoneSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Check.DataRecoderModifierId
		/// </summary>
		public virtual IEntityRelation CheckEntityUsingDataRecoderModifierId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Check_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckFields.DataRecoderModifierId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Check.DataRecoderCreatorId
		/// </summary>
		public virtual IEntityRelation CheckEntityUsingDataRecoderCreatorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Check" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckFields.DataRecoderCreatorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckListAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CheckListAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CheckListAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckListAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckListAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CheckListAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation CheckListAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckListAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckListTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CheckListTemplate.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckListTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CheckListTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CheckListTemplate.CreatedBy
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CheckListTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ClinicalTestQualificationCriteria.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ClinicalTestQualificationCriteriaFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ClinicalTestQualificationCriteria.CreatedBy
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ClinicalTestQualificationCriteriaFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContactCallEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ContactCall.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ContactCallEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactCall_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactCallFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContactCallEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ContactCall.CreatedByRoleId
		/// </summary>
		public virtual IEntityRelation ContactCallEntityUsingCreatedByRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactCall" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactCallFields.CreatedByRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContactMeetingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ContactMeeting.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ContactMeetingEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactMeeting_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactMeetingFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactMeetingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContactMeetingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ContactMeeting.CreatedByRoleId
		/// </summary>
		public virtual IEntityRelation ContactMeetingEntityUsingCreatedByRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ContactMeeting" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContactMeetingFields.CreatedByRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContactMeetingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Content.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ContentEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Content_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContentFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ContentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Content.CreatedBy
		/// </summary>
		public virtual IEntityRelation ContentEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Content" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ContentFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ContentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CorporateTagEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CorporateTag.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CorporateTagEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateTag_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CorporateTagFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CorporateTagEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CorporateTag.CreatedBy
		/// </summary>
		public virtual IEntityRelation CorporateTagEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateTag" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CorporateTagFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CorporateUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CorporateUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Coupons.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Coupons_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CouponsFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CouponsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Coupons.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CouponsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Coupons" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CouponsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouponsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CurrentMedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CurrentMedication.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CurrentMedicationEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CurrentMedication" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CurrentMedicationFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CurrentMedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerActivityTypeUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerActivityTypeUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation CustomerActivityTypeUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerActivityTypeUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerActivityTypeUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerActivityTypeUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerCallAttemptsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerCallAttempts.UpdatedBy
		/// </summary>
		public virtual IEntityRelation CustomerCallAttemptsEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallAttempts" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerCallAttemptsFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallAttemptsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerCallQueueCallAttempt.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerCallQueueCallAttemptEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerCallQueueCallAttemptFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerClinicalQuestionAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerClinicalQuestionAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerClinicalQuestionAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerClinicalQuestionAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEligibility.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CustomerEligibilityEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEligibility_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEligibilityFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEligibility.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerEligibilityEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEligibility" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEligibilityFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventCriticalTestDataEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventCriticalTestData.ValidatingTechnicianId
		/// </summary>
		public virtual IEntityRelation CustomerEventCriticalTestDataEntityUsingValidatingTechnicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventCriticalTestData_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventCriticalTestDataFields.ValidatingTechnicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventCriticalTestDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventCriticalTestDataEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventCriticalTestData.TechnicianId
		/// </summary>
		public virtual IEntityRelation CustomerEventCriticalTestDataEntityUsingTechnicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventCriticalTestData" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventCriticalTestDataFields.TechnicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventCriticalTestDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventPriorityInQueueDataEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventPriorityInQueueData.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventPriorityInQueueDataEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventPriorityInQueueData_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventPriorityInQueueDataFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventPriorityInQueueDataEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventPriorityInQueueData.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventPriorityInQueueDataEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventPriorityInQueueData" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventPriorityInQueueDataFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventPriorityInQueueDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventReadingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventReading.UpdatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventReadingEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventReading" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventReadingFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventReadingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventTestPhysicianEvaluationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventTestPhysicianEvaluation.UpdatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestPhysicianEvaluationEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestPhysicianEvaluation" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventTestPhysicianEvaluationFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestPhysicianEvaluationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventTestStateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventTestState.UpdatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStateEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestState__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventTestStateFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventTestStateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventTestState.EvaluatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStateEntityUsingEvaluatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestState_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventTestStateFields.EvaluatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventTestStateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventTestState.ConductedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStateEntityUsingConductedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestState" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventTestStateFields.ConductedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerEventUnableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerEventUnableScreenReason.UpdatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerEventUnableScreenReasonEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventUnableScreenReason" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerEventUnableScreenReasonFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventUnableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerHealthInfoEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerHealthInfo.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfo" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerHealthInfoFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerHealthInfoArchiveEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerHealthInfoArchive.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoArchiveEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfoArchive" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerHealthInfoArchiveFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoArchiveEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerIcdCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerIcdCode.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerIcdCodeEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerIcdCode" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerIcdCodeFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerIcdCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerLockForCallEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerLockForCall.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerLockForCallEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerLockForCall" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerLockForCallFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerLockForCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerMedicareQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerMedicareQuestionAnswer.CreateBy
		/// </summary>
		public virtual IEntityRelation CustomerMedicareQuestionAnswerEntityUsingCreateBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerMedicareQuestionAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerMedicareQuestionAnswerFields.CreateBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerPhoneNumberUpdateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerPhoneNumberUpdateUpload.UploadedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerPhoneNumberUpdateUploadEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPhoneNumberUpdateUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPhoneNumberUpdateUploadFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPhoneNumberUpdateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerPrimaryCarePhysician.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerPrimaryCarePhysician.PcpAddressVerifiedBy
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingPcpAddressVerifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.PcpAddressVerifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerPrimaryCarePhysician.UpdatedByOrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingUpdatedByOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerPrimaryCarePhysicianFields.UpdatedByOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerProfileHistory.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerProfileHistoryFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerRegistrationNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerRegistrationNotes.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerRegistrationNotesEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerRegistrationNotes" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerRegistrationNotesFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerRegistrationNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerResultScreeningCommunicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerResultScreeningCommunication.PhysicianOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerResultScreeningCommunicationEntityUsingPhysicianOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerResultScreeningCommunication__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerResultScreeningCommunicationFields.PhysicianOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerResultScreeningCommunicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerResultScreeningCommunicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerResultScreeningCommunication.FranchiseeAdminOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerResultScreeningCommunicationEntityUsingFranchiseeAdminOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerResultScreeningCommunication_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerResultScreeningCommunicationFields.FranchiseeAdminOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerResultScreeningCommunicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerResultScreeningCommunicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerResultScreeningCommunication.CommunicationInitiatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerResultScreeningCommunicationEntityUsingCommunicationInitiatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerResultScreeningCommunication" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerResultScreeningCommunicationFields.CommunicationInitiatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerResultScreeningCommunicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerTagEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerTag.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerTagEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTag_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerTagFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerTagEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerTag.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation CustomerTagEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTag" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerTagFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerTargetedEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerTargeted.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CustomerTargetedEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTargeted_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerTargetedFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTargetedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerTargetedEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerTargeted.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerTargetedEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTargeted" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerTargetedFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTargetedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerWarmTransferEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerWarmTransfer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation CustomerWarmTransferEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerWarmTransfer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerWarmTransferFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerWarmTransferEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerWarmTransferEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerWarmTransfer.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomerWarmTransferEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerWarmTransfer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerWarmTransferFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerWarmTransferEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomEventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomEventNotification.CreatedBy
		/// </summary>
		public virtual IEntityRelation CustomEventNotificationEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomEventNotification" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomEventNotificationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomEventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and DirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - DirectMail.MailedBy
		/// </summary>
		public virtual IEntityRelation DirectMailEntityUsingMailedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMail" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DirectMailFields.MailedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and DirectMailTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - DirectMailType.ModifiedBy
		/// </summary>
		public virtual IEntityRelation DirectMailTypeEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMailType_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DirectMailTypeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and DirectMailTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - DirectMailType.CreatedBy
		/// </summary>
		public virtual IEntityRelation DirectMailTypeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMailType" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DirectMailTypeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - DisqualifiedTest.UpdatedBy
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DisqualifiedTestFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - DisqualifiedTest.CreatedBy
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, DisqualifiedTestFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Eligibility.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EligibilityEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Eligibility" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EligibilityFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EligibilityUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EligibilityUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation EligibilityUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EligibilityUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EligibilityUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EmailTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EmailTemplate.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmailTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EmailTemplateFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventAccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventAccountTestHcpcsCode.ModifiedBy
		/// </summary>
		public virtual IEntityRelation EventAccountTestHcpcsCodeEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccountTestHcpcsCode_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAccountTestHcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventAccountTestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventAccountTestHcpcsCode.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventAccountTestHcpcsCodeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccountTestHcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAccountTestHcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountTestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventActivityTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventActivityTemplate.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateFields.OrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventActivityTemplateCallEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventActivityTemplateCall.ResponsibleOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateCallEntityUsingResponsibleOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateCall" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateCallFields.ResponsibleOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventActivityTemplateEmailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventActivityTemplateEmail.ResponsibleOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateEmailEntityUsingResponsibleOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateEmail" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateEmailFields.ResponsibleOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateEmailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventActivityTemplateMeetingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventActivityTemplateMeeting.ResponsibleOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateMeetingEntityUsingResponsibleOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateMeeting" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateMeetingFields.ResponsibleOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateMeetingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventActivityTemplateTaskEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventActivityTemplateTask.ResponsibleOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventActivityTemplateTaskEntityUsingResponsibleOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventActivityTemplateTask" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventActivityTemplateTaskFields.ResponsibleOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventActivityTemplateTaskEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventAppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventAppointment.ScheduledByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventAppointmentEntityUsingScheduledByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAppointmentFields.ScheduledByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventAppointmentCancellationLog.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAppointmentCancellationLogFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventAppointmentChangeLog.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventAppointmentChangeLogFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerBasicBioMetricEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerBasicBioMetric.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventCustomerBasicBioMetricEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerBasicBioMetric" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerBasicBioMetricFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerBasicBioMetricEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerGiftCardEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerGiftCard.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerGiftCardEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerGiftCard" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerGiftCardFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerGiftCardEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerPrimaryCarePhysician.PcpAddressVerifiedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerPrimaryCarePhysicianEntityUsingPcpAddressVerifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerPrimaryCarePhysicianFields.PcpAddressVerifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerQuestionAnswer.UpdatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerQuestionAnswerFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerQuestionAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerQuestionAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.SignedOffBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingSignedOffBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult___" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.SignedOffBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.RegeneratedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingRegeneratedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.RegeneratedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.VerifiedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingVerifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult____" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.VerifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.InvoiceDateUpdatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingInvoiceDateUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult______" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.InvoiceDateUpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.ChatPdfReviewedByOverreadPhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingChatPdfReviewedByOverreadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult_______" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ChatPdfReviewedByOverreadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.CodedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingCodedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult_____" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.CodedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResult.ChatPdfReviewedByPhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingChatPdfReviewedByPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult________" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultFields.ChatPdfReviewedByPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultBloodLabEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResultBloodLab.CreatedByOrgRoleUserid
		/// </summary>
		public virtual IEntityRelation EventCustomerResultBloodLabEntityUsingCreatedByOrgRoleUserid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResultBloodLab" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultBloodLabFields.CreatedByOrgRoleUserid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResultHistory.InvoiceDateUpdatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerResultHistoryEntityUsingInvoiceDateUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResultHistory" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultHistoryFields.InvoiceDateUpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResultHistory.ChatPdfReviewedByPhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultHistoryEntityUsingChatPdfReviewedByPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResultHistory_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultHistoryFields.ChatPdfReviewedByPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerResultHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerResultHistory.ChatPdfReviewedByOverreadPhysicianId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultHistoryEntityUsingChatPdfReviewedByOverreadPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResultHistory__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerResultHistoryFields.ChatPdfReviewedByOverreadPhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerRetestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerRetest.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerRetestEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerRetest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerRetestFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerRetestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomers.ConfirmedBy
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingConfirmedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomersFields.ConfirmedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomers.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomersFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventCustomerTestNotPerformedNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventCustomerTestNotPerformedNotification.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventCustomerTestNotPerformedNotificationEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerTestNotPerformedNotification" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomerTestNotPerformedNotificationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventNote.ModifiedBy
		/// </summary>
		public virtual IEntityRelation EventNoteEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNote_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventNoteFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventNote.CreatedBy
		/// </summary>
		public virtual IEntityRelation EventNoteEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNote" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventNoteFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventPhysicianTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventPhysicianTest.PhysicianId
		/// </summary>
		public virtual IEntityRelation EventPhysicianTestEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPhysicianTest__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventPhysicianTestFields.PhysicianId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPhysicianTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventPhysicianTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventPhysicianTest.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventPhysicianTestEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPhysicianTest_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventPhysicianTestFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPhysicianTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventPhysicianTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventPhysicianTest.AssignedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventPhysicianTestEntityUsingAssignedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPhysicianTest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventPhysicianTestFields.AssignedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPhysicianTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Events.SignOffOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingSignOffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events___" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.SignOffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Events.UpdatedByAdmin
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingUpdatedByAdmin
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events____" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.UpdatedByAdmin);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Events.EventActivityOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventActivityOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.EventActivityOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Events.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Events.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventStaffAssignment.ScheduledByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingScheduledByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ScheduledByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventStaffAssignment.ActualStaffOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingActualStaffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ActualStaffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and EventStaffAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - EventStaffAssignment.ScheduledStaffOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation EventStaffAssignmentEntityUsingScheduledStaffOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventStaffAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventStaffAssignmentFields.ScheduledStaffOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventStaffAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ExitInterviewAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ExitInterviewAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ExitInterviewAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExitInterviewAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ExitInterviewAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ExitInterviewAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation ExitInterviewAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExitInterviewAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ExitInterviewSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ExitInterviewSignature.CreatedBy
		/// </summary>
		public virtual IEntityRelation ExitInterviewSignatureEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewSignature" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExitInterviewSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ExportableReportsQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ExportableReportsQueue.RequestedBy
		/// </summary>
		public virtual IEntityRelation ExportableReportsQueueEntityUsingRequestedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExportableReportsQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ExportableReportsQueueFields.RequestedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FileEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - File.CreatedBy
		/// </summary>
		public virtual IEntityRelation FileEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "File" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FileFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FillEventCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FillEventCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FillEventCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FluConsentAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FluConsentAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation FluConsentAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FluConsentAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FluConsentAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FluConsentAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation FluConsentAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FluConsentAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FluConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FluConsentSignature.CreatedBy
		/// </summary>
		public virtual IEntityRelation FluConsentSignatureEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentSignature" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FluConsentSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FluConsentTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FluConsentTemplate.ModifiedBy
		/// </summary>
		public virtual IEntityRelation FluConsentTemplateEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FluConsentTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and FluConsentTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - FluConsentTemplate.CreatedBy
		/// </summary>
		public virtual IEntityRelation FluConsentTemplateEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, FluConsentTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and GcNotGivenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - GcNotGivenReason.ModifiedBy
		/// </summary>
		public virtual IEntityRelation GcNotGivenReasonEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GcNotGivenReason_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, GcNotGivenReasonFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GcNotGivenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and GcNotGivenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - GcNotGivenReason.CreatedBy
		/// </summary>
		public virtual IEntityRelation GcNotGivenReasonEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GcNotGivenReason" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, GcNotGivenReasonFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GcNotGivenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and GuardianDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - GuardianDetails.ModifiedBy
		/// </summary>
		public virtual IEntityRelation GuardianDetailsEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GuardianDetails_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, GuardianDetailsFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GuardianDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and GuardianDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - GuardianDetails.CreatedBy
		/// </summary>
		public virtual IEntityRelation GuardianDetailsEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GuardianDetails" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, GuardianDetailsFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GuardianDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HafTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HafTemplate.ModifiedBy
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HafTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HafTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HafTemplate.CreatedBy
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HafTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HcpcsCode.ModifiedBy
		/// </summary>
		public virtual IEntityRelation HcpcsCodeEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HcpcsCode_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HcpcsCode.CreatedBy
		/// </summary>
		public virtual IEntityRelation HcpcsCodeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCallQueueCriteria.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCallQueueCriteriaFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCallQueueCriteria.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCallQueueCriteriaFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaAssignment.ModifiedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignment__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaAssignmentFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaAssignment.CreatedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignment_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaAssignmentFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaAssignment.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaAssignmentFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaAssignmentUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaAssignmentUpload.UploadedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaAssignmentUploadEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaAssignmentUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaAssignmentUploadFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaAssignmentUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaTeamAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaTeamAssignment.ModifiedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaTeamAssignmentEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaTeamAssignment_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaTeamAssignmentFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaTeamAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanCriteriaTeamAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanCriteriaTeamAssignment.CreatedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanCriteriaTeamAssignmentEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCriteriaTeamAssignment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanCriteriaTeamAssignmentFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCriteriaTeamAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanRevenueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanRevenue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenue_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanRevenueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HealthPlanRevenueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HealthPlanRevenue.CreatedBy
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HealthPlanRevenueFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HospitalPartnerCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HospitalPartnerCustomer.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerCustomerEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerCustomer__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HospitalPartnerCustomerFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HospitalPartnerCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HospitalPartnerCustomer.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerCustomerEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerCustomer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HospitalPartnerCustomerFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HospitalPartnerCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HospitalPartnerCustomer.CareCoordinatorOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerCustomerEntityUsingCareCoordinatorOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerCustomer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HospitalPartnerCustomerFields.CareCoordinatorOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HostFacilityRankingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HostFacilityRanking.RankedByOrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation HostFacilityRankingEntityUsingRankedByOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostFacilityRanking" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostFacilityRankingFields.RankedByOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HostPayment.CreatorOrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingCreatorOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostPaymentFields.CreatorOrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and HostPaymentTransactionEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - HostPaymentTransaction.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation HostPaymentTransactionEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPaymentTransaction" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, HostPaymentTransactionFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and IcdCodesEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - IcdCodes.ModifiedBy
		/// </summary>
		public virtual IEntityRelation IcdCodesEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IcdCodes_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, IcdCodesFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IcdCodesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and IcdCodesEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - IcdCodes.CreatedBy
		/// </summary>
		public virtual IEntityRelation IcdCodesEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IcdCodes" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, IcdCodesFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IcdCodesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and IncidentalFindingsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - IncidentalFindings.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation IncidentalFindingsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "IncidentalFindings" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, IncidentalFindingsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("IncidentalFindingsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and KynLabValuesEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - KynLabValues.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation KynLabValuesEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "KynLabValues_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, KynLabValuesFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and KynLabValuesEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - KynLabValues.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation KynLabValuesEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "KynLabValues" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, KynLabValuesFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and LabEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Lab.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation LabEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Lab" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, LabFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LabEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and LanguageEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Language.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation LanguageEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Language" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, LanguageFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and LanguageBarrierCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - LanguageBarrierCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, LanguageBarrierCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MailRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - MailRoundCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation MailRoundCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MailRoundCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MailRoundCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MailRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MarketingPrintOrderEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - MarketingPrintOrder.OrgRoleUserId
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrder" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MarketingPrintOrderFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Medication.ModifiedBy
		/// </summary>
		public virtual IEntityRelation MedicationEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Medication_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MedicationFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Medication.CreatedBy
		/// </summary>
		public virtual IEntityRelation MedicationEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Medication" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MedicationFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MedicationUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - MedicationUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation MedicationUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicationUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MedicationUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and MergeCustomerUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - MergeCustomerUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation MergeCustomerUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MergeCustomerUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, MergeCustomerUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MergeCustomerUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and NoShowCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - NoShowCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoShowCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NoShowCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and NotesDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - NotesDetails.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NotesDetails_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotesDetailsFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and NotesDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - NotesDetails.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NotesDetails" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotesDetailsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and NotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Notification.RequestedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation NotificationEntityUsingRequestedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Notification" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotificationFields.RequestedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and NotificationTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - NotificationType.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation NotificationTypeEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NotificationType" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, NotificationTypeFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotificationTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and OrganizationRoleUserTerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - OrganizationRoleUserTerritory.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserTerritoryEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrganizationRoleUserTerritory" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, OrganizationRoleUserTerritoryFields.OrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserTerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and OrgRoleUserActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - OrgRoleUserActivity.OrgRoleUserId
		/// </summary>
		public virtual IEntityRelation OrgRoleUserActivityEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrgRoleUserActivity" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, OrgRoleUserActivityFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrgRoleUserActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ParticipationConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ParticipationConsentSignature.CreatedBy
		/// </summary>
		public virtual IEntityRelation ParticipationConsentSignatureEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ParticipationConsentSignature" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ParticipationConsentSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ParticipationConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PasswordChangelogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PasswordChangelog.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PasswordChangelogEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PasswordChangelog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PasswordChangelogFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PasswordChangelogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PayPeriodEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PayPeriod.ModifiedBy
		/// </summary>
		public virtual IEntityRelation PayPeriodEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PayPeriod_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PayPeriodFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PayPeriodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PayPeriodEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PayPeriod.CreatedBy
		/// </summary>
		public virtual IEntityRelation PayPeriodEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PayPeriod" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PayPeriodFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PayPeriodEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PcpAppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PcpAppointment.ModifiedBy
		/// </summary>
		public virtual IEntityRelation PcpAppointmentEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpAppointment_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PcpAppointmentFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PcpAppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PcpAppointment.CreatedBy
		/// </summary>
		public virtual IEntityRelation PcpAppointmentEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpAppointment" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PcpAppointmentFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PcpDispositionEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PcpDisposition.ModifiedBy
		/// </summary>
		public virtual IEntityRelation PcpDispositionEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpDisposition_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PcpDispositionFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpDispositionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PcpDispositionEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PcpDisposition.CreatedBy
		/// </summary>
		public virtual IEntityRelation PcpDispositionEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpDisposition" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PcpDispositionFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpDispositionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PhysicianRecordRequestSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PhysicianRecordRequestSignature.CreatedBy
		/// </summary>
		public virtual IEntityRelation PhysicianRecordRequestSignatureEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianRecordRequestSignature" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PhysicianRecordRequestSignatureFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianRecordRequestSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PinChangelogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PinChangelog.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PinChangelogEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PinChangelog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PinChangelogFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PinChangelogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PodDefaultTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PodDefaultTeam.OrgnizationRoleUserId
		/// </summary>
		public virtual IEntityRelation PodDefaultTeamEntityUsingOrgnizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PodDefaultTeam" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PodDefaultTeamFields.OrgnizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PodDefaultTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreApprovedPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreApprovedPackage.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PreApprovedPackageEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreApprovedPackage" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreApprovedPackageFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreApprovedPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreApprovedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreApprovedTest.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PreApprovedTestEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreApprovedTest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreApprovedTestFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreApprovedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreAssessmentCallQueueCustomerLockEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreAssessmentCallQueueCustomerLock.CreatedBy
		/// </summary>
		public virtual IEntityRelation PreAssessmentCallQueueCustomerLockEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreAssessmentCallQueueCustomerLock" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreAssessmentCallQueueCustomerLockFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCallQueueCustomerLockEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreAssessmentCustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreAssessmentCustomerCallQueueCallAttempt.CreatedBy
		/// </summary>
		public virtual IEntityRelation PreAssessmentCustomerCallQueueCallAttemptEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreAssessmentCustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreAssessmentCustomerCallQueueCallAttemptFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreQualificationQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreQualificationQuestion.CreatedBy
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationQuestion" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationQuestionFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreQualificationTestTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreQualificationTestTemplate.UpdatedBy
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTestTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationTestTemplateFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PreQualificationTestTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PreQualificationTestTemplate.CreatedBy
		/// </summary>
		public virtual IEntityRelation PreQualificationTestTemplateEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationTestTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PreQualificationTestTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationTestTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PrintOrderItemTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PrintOrderItemTracking.UpdatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PrintOrderItemTrackingEntityUsingUpdatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PrintOrderItemTracking_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemTrackingFields.UpdatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PrintOrderItemTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PrintOrderItemTracking.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PrintOrderItemTrackingEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PrintOrderItemTracking" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PrintOrderItemTrackingFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PriorityInQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PriorityInQueue.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PriorityInQueueEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PriorityInQueue_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PriorityInQueueFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PriorityInQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PriorityInQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PriorityInQueue.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation PriorityInQueueEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PriorityInQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PriorityInQueueFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PriorityInQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ProspectCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ProspectCustomer.ContactedBy
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingContactedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ProspectCustomerFields.ContactedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ProspectsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Prospects.OrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Prospects" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ProspectsFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and RapsUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - RapsUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation RapsUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RapsUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RapsUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ReferralEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Referral.ReferedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ReferralEntityUsingReferedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Referral" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ReferralFields.ReferedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and RefundRequestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - RefundRequest.ProcessedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation RefundRequestEntityUsingProcessedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundRequest_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RefundRequestFields.ProcessedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and RefundRequestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - RefundRequest.RequestedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation RefundRequestEntityUsingRequestedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundRequest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RefundRequestFields.RequestedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and RequiredTestEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - RequiredTest.CreatedBy
		/// </summary>
		public virtual IEntityRelation RequiredTestEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RequiredTest" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, RequiredTestFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RequiredTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SalesRepPodAssigmentsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SalesRepPodAssigments.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation SalesRepPodAssigmentsEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SalesRepPodAssigments" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SalesRepPodAssigmentsFields.OrganizationRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SalesRepPodAssigmentsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ScheduleTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ScheduleTemplate.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ScheduleTemplateEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ScheduleTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ScheduleTemplateFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ScheduleTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ScheduleTemplate.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ScheduleTemplateEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ScheduleTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ScheduleTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScheduleTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SeminarsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Seminars.OrgRoleUserId
		/// </summary>
		public virtual IEntityRelation SeminarsEntityUsingOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Seminars" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SeminarsFields.OrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SeminarsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ShippingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ShippingDetail.ShippedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation ShippingDetailEntityUsingShippedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetail_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ShippingDetailFields.ShippedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and ShippingDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - ShippingDetail.ModifiedBy
		/// </summary>
		public virtual IEntityRelation ShippingDetailEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShippingDetail" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, ShippingDetailFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShippingDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SourceCodeChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SourceCodeChangeLog.Shellid
		/// </summary>
		public virtual IEntityRelation SourceCodeChangeLogEntityUsingShellid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SourceCodeChangeLog" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SourceCodeChangeLogFields.Shellid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SourceCodeChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and StaffEventScheduleUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - StaffEventScheduleUpload.UploadedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation StaffEventScheduleUploadEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventScheduleUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, StaffEventScheduleUploadFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SurveyAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SurveyAnswer.ModifiedBy
		/// </summary>
		public virtual IEntityRelation SurveyAnswerEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyAnswer_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyAnswerFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SurveyAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SurveyAnswer.CreatedBy
		/// </summary>
		public virtual IEntityRelation SurveyAnswerEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyAnswer" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyAnswerFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SurveyTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SurveyTemplate.ModifiedBy
		/// </summary>
		public virtual IEntityRelation SurveyTemplateEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyTemplate_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyTemplateFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SurveyTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SurveyTemplate.CreatedBy
		/// </summary>
		public virtual IEntityRelation SurveyTemplateEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyTemplate" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SurveyTemplateFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SuspectConditionUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SuspectConditionUpload.UploadedBy
		/// </summary>
		public virtual IEntityRelation SuspectConditionUploadEntityUsingUploadedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectConditionUpload" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SuspectConditionUploadFields.UploadedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SystemGeneratedCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SystemGeneratedCallQueueCriteria.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueCriteriaEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGenertedCallQueueCriteria__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SystemGeneratedCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SystemGeneratedCallQueueCriteria.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueCriteriaEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGenertedCallQueueCriteria_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and SystemGeneratedCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - SystemGeneratedCallQueueCriteria.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation SystemGeneratedCallQueueCriteriaEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SystemGenertedCallQueueCriteria" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, SystemGeneratedCallQueueCriteriaFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SystemGeneratedCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TaskDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TaskDetails.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation TaskDetailsEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TaskDetails__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TaskDetailsFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TaskDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TaskDetails.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation TaskDetailsEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TaskDetails_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TaskDetailsFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TaskDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TaskDetails.AssignedToOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation TaskDetailsEntityUsingAssignedToOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TaskDetails" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TaskDetailsFields.AssignedToOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TaskDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TerritoryEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - Territory.CreatedBy
		/// </summary>
		public virtual IEntityRelation TerritoryEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Territory" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TerritoryFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TerritoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestHcpcsCode.ModifiedBy
		/// </summary>
		public virtual IEntityRelation TestHcpcsCodeEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestHcpcsCode_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestHcpcsCodeFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestHcpcsCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestHcpcsCode.CreatedBy
		/// </summary>
		public virtual IEntityRelation TestHcpcsCodeEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestHcpcsCode" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestHcpcsCodeFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestHcpcsCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestNotPerformedEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestNotPerformed.UpdatedBy
		/// </summary>
		public virtual IEntityRelation TestNotPerformedEntityUsingUpdatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestNotPerformed_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestNotPerformedFields.UpdatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestNotPerformedEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestNotPerformed.CreatedBy
		/// </summary>
		public virtual IEntityRelation TestNotPerformedEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestNotPerformed" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestNotPerformedFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestNotPerformedReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestNotPerformedReason.CreatedBy
		/// </summary>
		public virtual IEntityRelation TestNotPerformedReasonEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestNotPerformedReason" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestNotPerformedReasonFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestNotPerformedReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestPerformedExternallyEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestPerformedExternally.ModifiedBy
		/// </summary>
		public virtual IEntityRelation TestPerformedExternallyEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestPerformedExternally_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestPerformedExternallyFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestPerformedExternallyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TestPerformedExternallyEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TestPerformedExternally.CreatedBy
		/// </summary>
		public virtual IEntityRelation TestPerformedExternallyEntityUsingCreatedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestPerformedExternally" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TestPerformedExternallyFields.CreatedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestPerformedExternallyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and UncontactedCustomerCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - UncontactedCustomerCallQueue.ModifiedBy
		/// </summary>
		public virtual IEntityRelation UncontactedCustomerCallQueueEntityUsingModifiedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UncontactedCustomerCallQueue" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UncontactedCustomerCallQueueFields.ModifiedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UncontactedCustomerCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and UploadZipInfoEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - UploadZipInfo.UploadedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation UploadZipInfoEntityUsingUploadedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UploadZipInfo" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UploadZipInfoFields.UploadedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UploadZipInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - User.ModifiedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingModifiedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "User__" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UserFields.ModifiedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and UserEntity over the 1:n relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - User.CreatedByOrgRoleUserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "User_" , true);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, UserFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AccountCoordinatorProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AccountCoordinatorProfile.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation AccountCoordinatorProfileEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "AccountCoordinatorProfile", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AccountCoordinatorProfileFields.OrganizationRoleUserId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCoordinatorProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and AffiliateProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - AffiliateProfile.AffiliateId
		/// </summary>
		public virtual IEntityRelation AffiliateProfileEntityUsingAffiliateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "AffiliateProfile_", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, AffiliateProfileFields.AffiliateId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AffiliateProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CallCenterRepProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CallCenterRepProfile.CallCenterRepId
		/// </summary>
		public virtual IEntityRelation CallCenterRepProfileEntityUsingCallCenterRepId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CallCenterRepProfile", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CallCenterRepProfileFields.CallCenterRepId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterRepProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and CustomerProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerProfile", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerProfileFields.CustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and PhysicianProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - PhysicianProfile.PhysicianId
		/// </summary>
		public virtual IEntityRelation PhysicianProfileEntityUsingPhysicianId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "PhysicianProfile", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, PhysicianProfileFields.PhysicianId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and TechnicianProfileEntity over the 1:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationRoleUserId - TechnicianProfile.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation TechnicianProfileEntityUsingOrganizationRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "TechnicianProfile", true);

				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, TechnicianProfileFields.OrganizationRoleUserId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TechnicianProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and OrganizationEntity over the m:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.OrganizationId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingOrganizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Organization", false);
				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, OrganizationRoleUserFields.OrganizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.RoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, OrganizationRoleUserFields.RoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between OrganizationRoleUserEntity and UserEntity over the m:1 relation they have, using the relation between the fields:
		/// OrganizationRoleUser.UserId - User.UserId
		/// </summary>
		public virtual IEntityRelation UserEntityUsingUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "User", false);
				relation.AddEntityFieldPair(UserFields.UserId, OrganizationRoleUserFields.UserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
