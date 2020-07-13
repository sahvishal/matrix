///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:39
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
	/// <summary>Implements the static Relations variant for the entity: Lookup. </summary>
	public partial class LookupRelations
	{
		/// <summary>CTor</summary>
		public LookupRelations()
		{
		}

		/// <summary>Gets all relations of the LookupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccessObjectScopeOptionEntityUsingScopeId);
			toReturn.Add(this.AccountEntityUsingResultFormatTypeId);
			toReturn.Add(this.AccountCallQueueSettingEntityUsingSuppressionTypeId);
			toReturn.Add(this.AccountHraChatQuestionnaireEntityUsingQuestionnaireType);
			toReturn.Add(this.CallCenterTeamEntityUsingTypeId);
			toReturn.Add(this.CallQueueCustomerEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.CallRoundCallQueueEntityUsingStatus);
			toReturn.Add(this.CallsEntityUsingProductTypeId);
			toReturn.Add(this.CallsEntityUsingNotInterestedReasonId);
			toReturn.Add(this.CallsEntityUsingDialerType);
			toReturn.Add(this.CallUploadEntityUsingStatusId);
			toReturn.Add(this.CampaignEntityUsingTypeId);
			toReturn.Add(this.CampaignEntityUsingModeId);
			toReturn.Add(this.CampaignActivityEntityUsingTypeId);
			toReturn.Add(this.ChaperoneQuestionEntityUsingTypeId);
			toReturn.Add(this.ChaperoneQuestionEntityUsingGender);
			toReturn.Add(this.ChaseOutboundEntityUsingConfidenceScoreId);
			toReturn.Add(this.CheckListAnswerEntityUsingType);
			toReturn.Add(this.CheckListGroupEntityUsingTypeId);
			toReturn.Add(this.CheckListQuestionEntityUsingTypeId);
			toReturn.Add(this.CheckListQuestionEntityUsingGender);
			toReturn.Add(this.CheckListTemplateEntityUsingType);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingGender);
			toReturn.Add(this.ClinicalTestQualificationCriteriaEntityUsingAgeCondition);
			toReturn.Add(this.CorporateUploadEntityUsingSourceId);
			toReturn.Add(this.CriticalQuestionEntityUsingControlType);
			toReturn.Add(this.CustomerActivityTypeUploadEntityUsingStatusId);
			toReturn.Add(this.CustomerEventTestStateEntityUsingTestSummary);
			toReturn.Add(this.CustomerHealthQuestionsEntityUsingControlType);
			toReturn.Add(this.CustomerOrderHistoryEntityUsingOrderItemStatusId);
			toReturn.Add(this.CustomerPhoneNumberUpdateUploadEntityUsingStatusId);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingSource);
			toReturn.Add(this.CustomerProfileEntityUsingPreferredContactType);
			toReturn.Add(this.CustomerProfileEntityUsingPhoneOfficeConsentId);
			toReturn.Add(this.CustomerProfileEntityUsingDoNotContactReasonId);
			toReturn.Add(this.CustomerProfileEntityUsingProductTypeId);
			toReturn.Add(this.CustomerProfileEntityUsingPhoneHomeConsentId);
			toReturn.Add(this.CustomerProfileEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.CustomerProfileEntityUsingDoNotContactTypeId);
			toReturn.Add(this.CustomerProfileEntityUsingPhoneCellConsentId);
			toReturn.Add(this.CustomerProfileEntityUsingMemberUploadSourceId);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingPreferredContactType);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingProductTypeId);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingMemberUploadSourceId);
			toReturn.Add(this.CustomerRegistrationNotesEntityUsingReasonId);
			toReturn.Add(this.CustomerUnsubscribedSmsNotificationEntityUsingStatusId);
			toReturn.Add(this.CustomEventNotificationEntityUsingServiceStatus);
			toReturn.Add(this.EligibilityUploadEntityUsingStatusId);
			toReturn.Add(this.EmailTemplateEntityUsingCoverLetterTypeLookupId);
			toReturn.Add(this.EmailTemplateEntityUsingTemplateType);
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingReasonId);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingReasonId);
			toReturn.Add(this.EventCustomerResultEntityUsingResultSummary);
			toReturn.Add(this.EventCustomerResultBloodLabParserEntityUsingBloodLabId);
			toReturn.Add(this.EventCustomersEntityUsingPreferredContactType);
			toReturn.Add(this.EventCustomersEntityUsingLeftWithoutScreeningReasonId);
			toReturn.Add(this.EventPackageDetailsEntityUsingGender);
			toReturn.Add(this.EventsEntityUsingGenerateHealthAssesmentFormStatus);
			toReturn.Add(this.EventsEntityUsingGenerateKynXml);
			toReturn.Add(this.EventsEntityUsingGenerateMyBioCheckAssessment);
			toReturn.Add(this.EventsEntityUsingGenerateHkynXml);
			toReturn.Add(this.EventsEntityUsingEventCancellationReasonId);
			toReturn.Add(this.EventSchedulingSlotEntityUsingStatus);
			toReturn.Add(this.EventTestEntityUsingResultEntryTypeId);
			toReturn.Add(this.EventTestEntityUsingGroupId);
			toReturn.Add(this.EventTestEntityUsingGender);
			toReturn.Add(this.ExitInterviewQuestionEntityUsingTypeId);
			toReturn.Add(this.ExitInterviewQuestionEntityUsingGender);
			toReturn.Add(this.ExportableReportsQueueEntityUsingStatusId);
			toReturn.Add(this.FileEntityUsingType);
			toReturn.Add(this.FillEventCallQueueEntityUsingStatus);
			toReturn.Add(this.FluConsentQuestionEntityUsingTypeId);
			toReturn.Add(this.FluConsentQuestionEntityUsingGender);
			toReturn.Add(this.FluConsentQuestionEntityUsingFluConsentQuestionType);
			toReturn.Add(this.HafTemplateEntityUsingCategory);
			toReturn.Add(this.HafTemplateEntityUsingType);
			toReturn.Add(this.HealthPlanRevenueEntityUsingRevenueItemTypeId);
			toReturn.Add(this.HostFacilityRankingEntityUsingRanking);
			toReturn.Add(this.HostFacilityRankingEntityUsingInternetAccess);
			toReturn.Add(this.HostImageEntityUsingHostImageType);
			toReturn.Add(this.HostPaymentEntityUsingStatus);
			toReturn.Add(this.HostPaymentEntityUsingDepositType);
			toReturn.Add(this.HostPaymentTransactionEntityUsingTransactionType);
			toReturn.Add(this.HostPaymentTransactionEntityUsingPaymentMethod);
			toReturn.Add(this.KynLabValuesEntityUsingFastingStatus);
			toReturn.Add(this.LanguageBarrierCallQueueEntityUsingStatus);
			toReturn.Add(this.LoginSettingsEntityUsingAuthenticationModeId);
			toReturn.Add(this.MailRoundCallQueueEntityUsingStatus);
			toReturn.Add(this.MarketingPrintOrderItemEntityUsingStatus);
			toReturn.Add(this.MedicareQuestionEntityUsingControlType);
			toReturn.Add(this.MedicationUploadEntityUsingStatusId);
			toReturn.Add(this.MergeCustomerUploadEntityUsingStatusId);
			toReturn.Add(this.MergeCustomerUploadLogEntityUsingStatusId);
			toReturn.Add(this.MolinaAttestationEntityUsingStatusId);
			toReturn.Add(this.NoShowCallQueueEntityUsingStatus);
			toReturn.Add(this.OrderDetailEntityUsingSourceId);
			toReturn.Add(this.OutboundUploadEntityUsingTypeId);
			toReturn.Add(this.OutboundUploadEntityUsingStatusId);
			toReturn.Add(this.PackageEntityUsingGender);
			toReturn.Add(this.PaymentInstructionsEntityUsingPaymentFrequencyId);
			toReturn.Add(this.PcpAppointmentEntityUsingPreferredContactMethod);
			toReturn.Add(this.PcpDispositionEntityUsingDispositionId);
			toReturn.Add(this.PreQualificationQuestionEntityUsingTypeId);
			toReturn.Add(this.PreQualificationResultEntityUsingHighCholestrol);
			toReturn.Add(this.PreQualificationResultEntityUsingHighBloodPressure);
			toReturn.Add(this.PreQualificationResultEntityUsingSmoker);
			toReturn.Add(this.PreQualificationResultEntityUsingOverWeight);
			toReturn.Add(this.PreQualificationResultEntityUsingHeartDisease);
			toReturn.Add(this.PreQualificationResultEntityUsingChestPain);
			toReturn.Add(this.PreQualificationResultEntityUsingAgeOverPreQualificationQuestion);
			toReturn.Add(this.PreQualificationResultEntityUsingDiagnosedHeartProblem);
			toReturn.Add(this.PreQualificationResultEntityUsingDiabetic);
			toReturn.Add(this.PrintOrderItemTrackingEntityUsingConfirmationMode);
			toReturn.Add(this.ProspectCustomerEntityUsingSource);
			toReturn.Add(this.RapsUploadEntityUsingStatusId);
			toReturn.Add(this.RefundRequestEntityUsingRequestStatus);
			toReturn.Add(this.RescheduleCancelDispositionEntityUsingLookupId);
			toReturn.Add(this.RoleAccessControlObjectEntityUsingScopeId);
			toReturn.Add(this.RoleAccessControlObjectEntityUsingPermissionTypeId);
			toReturn.Add(this.RoleScopeOptionEntityUsingScopeId);
			toReturn.Add(this.StaffEventScheduleUploadEntityUsingStatusId);
			toReturn.Add(this.StandardFindingEntityUsingPathwayRecommendation);
			toReturn.Add(this.StandardFindingEntityUsingResultInterpretation);
			toReturn.Add(this.SurveyQuestionEntityUsingTypeId);
			toReturn.Add(this.SurveyQuestionEntityUsingGender);
			toReturn.Add(this.SuspectConditionUploadEntityUsingStatusId);
			toReturn.Add(this.TagEntityUsingSource);
			toReturn.Add(this.TagEntityUsingCallStatus);
			toReturn.Add(this.TestEntityUsingResultEntryTypeId);
			toReturn.Add(this.TestEntityUsingGroupId);
			toReturn.Add(this.TestEntityUsingGender);
			toReturn.Add(this.TestPerformedExternallyEntityUsingResultEntryTypeId);
			toReturn.Add(this.TestUnableScreenReasonEntityUsingUnableScreenReasonId);
			toReturn.Add(this.UncontactedCustomerCallQueueEntityUsingStatus);
			toReturn.Add(this.WellMedAttestationEntityUsingStatusId);

			toReturn.Add(this.LookupTypeEntityUsingLookupTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and AccessObjectScopeOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - AccessObjectScopeOption.ScopeId
		/// </summary>
		public virtual IEntityRelation AccessObjectScopeOptionEntityUsingScopeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccessObjectScopeOption" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccessObjectScopeOptionFields.ScopeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccessObjectScopeOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and AccountEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Account.ResultFormatTypeId
		/// </summary>
		public virtual IEntityRelation AccountEntityUsingResultFormatTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Account" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccountFields.ResultFormatTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and AccountCallQueueSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - AccountCallQueueSetting.SuppressionTypeId
		/// </summary>
		public virtual IEntityRelation AccountCallQueueSettingEntityUsingSuppressionTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallQueueSetting" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccountCallQueueSettingFields.SuppressionTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallQueueSettingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and AccountHraChatQuestionnaireEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - AccountHraChatQuestionnaire.QuestionnaireType
		/// </summary>
		public virtual IEntityRelation AccountHraChatQuestionnaireEntityUsingQuestionnaireType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHraChatQuestionnaire" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccountHraChatQuestionnaireFields.QuestionnaireType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHraChatQuestionnaireEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallCenterTeamEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CallCenterTeam.TypeId
		/// </summary>
		public virtual IEntityRelation CallCenterTeamEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallCenterTeam" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallCenterTeamFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallCenterTeamEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CallQueueCustomer.DoNotContactUpdateSource
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallQueueCustomerFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CallRoundCallQueue.Status
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallRoundCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Calls.ProductTypeId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Calls.NotInterestedReasonId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingNotInterestedReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.NotInterestedReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Calls.DialerType
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingDialerType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallsFields.DialerType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CallUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CallUpload.StatusId
		/// </summary>
		public virtual IEntityRelation CallUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CallUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Campaign.TypeId
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Campaign_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Campaign.ModeId
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Campaign" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignFields.ModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CampaignActivityEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CampaignActivity.TypeId
		/// </summary>
		public virtual IEntityRelation CampaignActivityEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CampaignActivity" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CampaignActivityFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignActivityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ChaperoneQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ChaperoneQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation ChaperoneQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneQuestion_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ChaperoneQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ChaperoneQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ChaperoneQuestion.Gender
		/// </summary>
		public virtual IEntityRelation ChaperoneQuestionEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ChaperoneQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ChaseOutboundEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ChaseOutbound.ConfidenceScoreId
		/// </summary>
		public virtual IEntityRelation ChaseOutboundEntityUsingConfidenceScoreId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaseOutbound" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ChaseOutboundFields.ConfidenceScoreId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CheckListAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CheckListAnswer.Type
		/// </summary>
		public virtual IEntityRelation CheckListAnswerEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListAnswer" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListAnswerFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CheckListGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CheckListGroup.TypeId
		/// </summary>
		public virtual IEntityRelation CheckListGroupEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListGroup" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListGroupFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CheckListQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CheckListQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CheckListQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CheckListQuestion.Gender
		/// </summary>
		public virtual IEntityRelation CheckListQuestionEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListQuestion_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CheckListTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CheckListTemplate.Type
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListTemplate" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CheckListTemplateFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ClinicalTestQualificationCriteria.Gender
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ClinicalTestQualificationCriteriaFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ClinicalTestQualificationCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ClinicalTestQualificationCriteria.AgeCondition
		/// </summary>
		public virtual IEntityRelation ClinicalTestQualificationCriteriaEntityUsingAgeCondition
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClinicalTestQualificationCriteria" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ClinicalTestQualificationCriteriaFields.AgeCondition);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClinicalTestQualificationCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CorporateUpload.SourceId
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CorporateUploadFields.SourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CriticalQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CriticalQuestion.ControlType
		/// </summary>
		public virtual IEntityRelation CriticalQuestionEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CriticalQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CriticalQuestionFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CriticalQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerActivityTypeUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerActivityTypeUpload.StatusId
		/// </summary>
		public virtual IEntityRelation CustomerActivityTypeUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerActivityTypeUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerActivityTypeUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerActivityTypeUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerEventTestStateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerEventTestState.TestSummary
		/// </summary>
		public virtual IEntityRelation CustomerEventTestStateEntityUsingTestSummary
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestState" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerEventTestStateFields.TestSummary);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestStateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerHealthQuestionsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerHealthQuestions.ControlType
		/// </summary>
		public virtual IEntityRelation CustomerHealthQuestionsEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthQuestions" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerHealthQuestionsFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthQuestionsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerOrderHistory.OrderItemStatusId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingOrderItemStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerOrderHistoryFields.OrderItemStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerPhoneNumberUpdateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerPhoneNumberUpdateUpload.StatusId
		/// </summary>
		public virtual IEntityRelation CustomerPhoneNumberUpdateUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPhoneNumberUpdateUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerPhoneNumberUpdateUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPhoneNumberUpdateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerPrimaryCarePhysician.Source
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerPrimaryCarePhysicianFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.PreferredContactType
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile______" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.PhoneOfficeConsentId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingPhoneOfficeConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile_____" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneOfficeConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.DoNotContactReasonId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingDoNotContactReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile_______" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.ProductTypeId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile________" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.PhoneHomeConsentId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingPhoneHomeConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile____" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneHomeConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.DoNotContactUpdateSource
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.DoNotContactTypeId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingDoNotContactTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.PhoneCellConsentId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingPhoneCellConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile___" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneCellConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfile.MemberUploadSourceId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingMemberUploadSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfile__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.MemberUploadSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfileHistory.PreferredContactType
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory___" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfileHistory.ProductTypeId
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfileHistory.DoNotContactUpdateSource
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerProfileHistory.MemberUploadSourceId
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingMemberUploadSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileHistoryFields.MemberUploadSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerRegistrationNotesEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerRegistrationNotes.ReasonId
		/// </summary>
		public virtual IEntityRelation CustomerRegistrationNotesEntityUsingReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerRegistrationNotes" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerRegistrationNotesFields.ReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerRegistrationNotesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomerUnsubscribedSmsNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomerUnsubscribedSmsNotification.StatusId
		/// </summary>
		public virtual IEntityRelation CustomerUnsubscribedSmsNotificationEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerUnsubscribedSmsNotification" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerUnsubscribedSmsNotificationFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerUnsubscribedSmsNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and CustomEventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - CustomEventNotification.ServiceStatus
		/// </summary>
		public virtual IEntityRelation CustomEventNotificationEntityUsingServiceStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomEventNotification" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomEventNotificationFields.ServiceStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomEventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EligibilityUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EligibilityUpload.StatusId
		/// </summary>
		public virtual IEntityRelation EligibilityUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EligibilityUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EligibilityUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EmailTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EmailTemplate.CoverLetterTypeLookupId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingCoverLetterTypeLookupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmailTemplate_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EmailTemplateFields.CoverLetterTypeLookupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EmailTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EmailTemplate.TemplateType
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingTemplateType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EmailTemplate" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EmailTemplateFields.TemplateType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventAppointmentCancellationLog.ReasonId
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventAppointmentCancellationLogFields.ReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventAppointmentChangeLog.ReasonId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventAppointmentChangeLogFields.ReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventCustomerResult.ResultSummary
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingResultSummary
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomerResultFields.ResultSummary);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventCustomerResultBloodLabParserEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventCustomerResultBloodLabParser.BloodLabId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultBloodLabParserEntityUsingBloodLabId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResultBloodLabParser" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomerResultBloodLabParserFields.BloodLabId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultBloodLabParserEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventCustomers.PreferredContactType
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomersFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventCustomers.LeftWithoutScreeningReasonId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingLeftWithoutScreeningReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomersFields.LeftWithoutScreeningReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventPackageDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventPackageDetails.Gender
		/// </summary>
		public virtual IEntityRelation EventPackageDetailsEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPackageDetails" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventPackageDetailsFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPackageDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Events.GenerateHealthAssesmentFormStatus
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingGenerateHealthAssesmentFormStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events____" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateHealthAssesmentFormStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Events.GenerateKynXml
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingGenerateKynXml
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateKynXml);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Events.GenerateMyBioCheckAssessment
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingGenerateMyBioCheckAssessment
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events___" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateMyBioCheckAssessment);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Events.GenerateHkynXml
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingGenerateHkynXml
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.GenerateHkynXml);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Events.EventCancellationReasonId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventCancellationReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Events_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventsFields.EventCancellationReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventSchedulingSlotEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventSchedulingSlot.Status
		/// </summary>
		public virtual IEntityRelation EventSchedulingSlotEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventSchedulingSlot" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventSchedulingSlotFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventSchedulingSlotEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventTest.ResultEntryTypeId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingResultEntryTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.ResultEntryTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventTest.GroupId
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and EventTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - EventTest.Gender
		/// </summary>
		public virtual IEntityRelation EventTestEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventTest" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventTestFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ExitInterviewQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ExitInterviewQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation ExitInterviewQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewQuestion_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ExitInterviewQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ExitInterviewQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ExitInterviewQuestion.Gender
		/// </summary>
		public virtual IEntityRelation ExitInterviewQuestionEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ExitInterviewQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ExportableReportsQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ExportableReportsQueue.StatusId
		/// </summary>
		public virtual IEntityRelation ExportableReportsQueueEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExportableReportsQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ExportableReportsQueueFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExportableReportsQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and FileEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - File.Type
		/// </summary>
		public virtual IEntityRelation FileEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "File" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, FileFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and FillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - FillEventCallQueue.Status
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FillEventCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, FillEventCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and FluConsentQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - FluConsentQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentQuestion_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and FluConsentQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - FluConsentQuestion.Gender
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and FluConsentQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - FluConsentQuestion.FluConsentQuestionType
		/// </summary>
		public virtual IEntityRelation FluConsentQuestionEntityUsingFluConsentQuestionType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentQuestion__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, FluConsentQuestionFields.FluConsentQuestionType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HafTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HafTemplate.Category
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingCategory
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplate_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HafTemplateFields.Category);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HafTemplateEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HafTemplate.Type
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HafTemplate" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HafTemplateFields.Type);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HealthPlanRevenueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HealthPlanRevenue.RevenueItemTypeId
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueEntityUsingRevenueItemTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HealthPlanRevenueFields.RevenueItemTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostFacilityRankingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostFacilityRanking.Ranking
		/// </summary>
		public virtual IEntityRelation HostFacilityRankingEntityUsingRanking
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostFacilityRanking_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostFacilityRankingFields.Ranking);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostFacilityRankingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostFacilityRanking.InternetAccess
		/// </summary>
		public virtual IEntityRelation HostFacilityRankingEntityUsingInternetAccess
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostFacilityRanking" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostFacilityRankingFields.InternetAccess);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostFacilityRankingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostImageEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostImage.HostImageType
		/// </summary>
		public virtual IEntityRelation HostImageEntityUsingHostImageType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostImage" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostImageFields.HostImageType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostImageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostPayment.Status
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostPaymentEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostPayment.DepositType
		/// </summary>
		public virtual IEntityRelation HostPaymentEntityUsingDepositType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPayment__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentFields.DepositType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostPaymentTransactionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostPaymentTransaction.TransactionType
		/// </summary>
		public virtual IEntityRelation HostPaymentTransactionEntityUsingTransactionType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPaymentTransaction_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentTransactionFields.TransactionType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and HostPaymentTransactionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - HostPaymentTransaction.PaymentMethod
		/// </summary>
		public virtual IEntityRelation HostPaymentTransactionEntityUsingPaymentMethod
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HostPaymentTransaction" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, HostPaymentTransactionFields.PaymentMethod);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HostPaymentTransactionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and KynLabValuesEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - KynLabValues.FastingStatus
		/// </summary>
		public virtual IEntityRelation KynLabValuesEntityUsingFastingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "KynLabValues" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, KynLabValuesFields.FastingStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("KynLabValuesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and LanguageBarrierCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - LanguageBarrierCallQueue.Status
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, LanguageBarrierCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and LoginSettingsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - LoginSettings.AuthenticationModeId
		/// </summary>
		public virtual IEntityRelation LoginSettingsEntityUsingAuthenticationModeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LoginSettings" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, LoginSettingsFields.AuthenticationModeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LoginSettingsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MailRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MailRoundCallQueue.Status
		/// </summary>
		public virtual IEntityRelation MailRoundCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MailRoundCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MailRoundCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MailRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MarketingPrintOrderItemEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MarketingPrintOrderItem.Status
		/// </summary>
		public virtual IEntityRelation MarketingPrintOrderItemEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MarketingPrintOrderItem" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MarketingPrintOrderItemFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MarketingPrintOrderItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MedicareQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MedicareQuestion.ControlType
		/// </summary>
		public virtual IEntityRelation MedicareQuestionEntityUsingControlType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicareQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MedicareQuestionFields.ControlType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicareQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MedicationUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MedicationUpload.StatusId
		/// </summary>
		public virtual IEntityRelation MedicationUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MedicationUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MedicationUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MergeCustomerUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MergeCustomerUpload.StatusId
		/// </summary>
		public virtual IEntityRelation MergeCustomerUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MergeCustomerUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MergeCustomerUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MergeCustomerUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MergeCustomerUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MergeCustomerUploadLog.StatusId
		/// </summary>
		public virtual IEntityRelation MergeCustomerUploadLogEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MergeCustomerUploadLog" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MergeCustomerUploadLogFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MergeCustomerUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and MolinaAttestationEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - MolinaAttestation.StatusId
		/// </summary>
		public virtual IEntityRelation MolinaAttestationEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MolinaAttestation" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, MolinaAttestationFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MolinaAttestationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and NoShowCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - NoShowCallQueue.Status
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoShowCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, NoShowCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and OrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - OrderDetail.SourceId
		/// </summary>
		public virtual IEntityRelation OrderDetailEntityUsingSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OrderDetail" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, OrderDetailFields.SourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and OutboundUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - OutboundUpload.TypeId
		/// </summary>
		public virtual IEntityRelation OutboundUploadEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OutboundUpload_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, OutboundUploadFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OutboundUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and OutboundUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - OutboundUpload.StatusId
		/// </summary>
		public virtual IEntityRelation OutboundUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OutboundUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, OutboundUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OutboundUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Package.Gender
		/// </summary>
		public virtual IEntityRelation PackageEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Package" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PackageFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PaymentInstructionsEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PaymentInstructions.PaymentFrequencyId
		/// </summary>
		public virtual IEntityRelation PaymentInstructionsEntityUsingPaymentFrequencyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PaymentInstructions" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PaymentInstructionsFields.PaymentFrequencyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PaymentInstructionsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PcpAppointmentEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PcpAppointment.PreferredContactMethod
		/// </summary>
		public virtual IEntityRelation PcpAppointmentEntityUsingPreferredContactMethod
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpAppointment" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PcpAppointmentFields.PreferredContactMethod);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PcpDispositionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PcpDisposition.DispositionId
		/// </summary>
		public virtual IEntityRelation PcpDispositionEntityUsingDispositionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpDisposition" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PcpDispositionFields.DispositionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpDispositionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation PreQualificationQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.HighCholestrol
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingHighCholestrol
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult______" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HighCholestrol);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.HighBloodPressure
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingHighBloodPressure
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult_____" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HighBloodPressure);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.Smoker
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingSmoker
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult________" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.Smoker);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.OverWeight
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingOverWeight
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult_______" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.OverWeight);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.HeartDisease
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingHeartDisease
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult____" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.HeartDisease);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.ChestPain
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingChestPain
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.ChestPain);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.AgeOverPreQualificationQuestion
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingAgeOverPreQualificationQuestion
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.AgeOverPreQualificationQuestion);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.DiagnosedHeartProblem
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingDiagnosedHeartProblem
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult___" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.DiagnosedHeartProblem);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PreQualificationResult.Diabetic
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingDiabetic
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PreQualificationResultFields.Diabetic);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and PrintOrderItemTrackingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - PrintOrderItemTracking.ConfirmationMode
		/// </summary>
		public virtual IEntityRelation PrintOrderItemTrackingEntityUsingConfirmationMode
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PrintOrderItemTracking_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, PrintOrderItemTrackingFields.ConfirmationMode);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PrintOrderItemTrackingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and ProspectCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - ProspectCustomer.Source
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomer" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, ProspectCustomerFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RapsUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RapsUpload.StatusId
		/// </summary>
		public virtual IEntityRelation RapsUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RapsUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RapsUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RefundRequestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RefundRequest.RequestStatus
		/// </summary>
		public virtual IEntityRelation RefundRequestEntityUsingRequestStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RefundRequest" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RefundRequestFields.RequestStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RefundRequestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RescheduleCancelDispositionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RescheduleCancelDisposition.LookupId
		/// </summary>
		public virtual IEntityRelation RescheduleCancelDispositionEntityUsingLookupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RescheduleCancelDisposition" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RescheduleCancelDispositionFields.LookupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RescheduleCancelDispositionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RoleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RoleAccessControlObject.ScopeId
		/// </summary>
		public virtual IEntityRelation RoleAccessControlObjectEntityUsingScopeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAccessControlObject_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RoleAccessControlObjectFields.ScopeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RoleAccessControlObjectEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RoleAccessControlObject.PermissionTypeId
		/// </summary>
		public virtual IEntityRelation RoleAccessControlObjectEntityUsingPermissionTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleAccessControlObject" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RoleAccessControlObjectFields.PermissionTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleAccessControlObjectEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and RoleScopeOptionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - RoleScopeOption.ScopeId
		/// </summary>
		public virtual IEntityRelation RoleScopeOptionEntityUsingScopeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RoleScopeOption" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, RoleScopeOptionFields.ScopeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleScopeOptionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and StaffEventScheduleUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - StaffEventScheduleUpload.StatusId
		/// </summary>
		public virtual IEntityRelation StaffEventScheduleUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StaffEventScheduleUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, StaffEventScheduleUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StaffEventScheduleUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and StandardFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - StandardFinding.PathwayRecommendation
		/// </summary>
		public virtual IEntityRelation StandardFindingEntityUsingPathwayRecommendation
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StandardFinding_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, StandardFindingFields.PathwayRecommendation);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and StandardFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - StandardFinding.ResultInterpretation
		/// </summary>
		public virtual IEntityRelation StandardFindingEntityUsingResultInterpretation
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "StandardFinding" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, StandardFindingFields.ResultInterpretation);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("StandardFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and SurveyQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - SurveyQuestion.TypeId
		/// </summary>
		public virtual IEntityRelation SurveyQuestionEntityUsingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyQuestion_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, SurveyQuestionFields.TypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and SurveyQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - SurveyQuestion.Gender
		/// </summary>
		public virtual IEntityRelation SurveyQuestionEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyQuestion" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, SurveyQuestionFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and SuspectConditionUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - SuspectConditionUpload.StatusId
		/// </summary>
		public virtual IEntityRelation SuspectConditionUploadEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectConditionUpload" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, SuspectConditionUploadFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TagEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Tag.Source
		/// </summary>
		public virtual IEntityRelation TagEntityUsingSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Tag" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TagFields.Source);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TagEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Tag.CallStatus
		/// </summary>
		public virtual IEntityRelation TagEntityUsingCallStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Tag_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TagFields.CallStatus);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Test.ResultEntryTypeId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingResultEntryTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Test__" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.ResultEntryTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Test.GroupId
		/// </summary>
		public virtual IEntityRelation TestEntityUsingGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Test_" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.GroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TestEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - Test.Gender
		/// </summary>
		public virtual IEntityRelation TestEntityUsingGender
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Test" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestFields.Gender);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TestPerformedExternallyEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - TestPerformedExternally.ResultEntryTypeId
		/// </summary>
		public virtual IEntityRelation TestPerformedExternallyEntityUsingResultEntryTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestPerformedExternally" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestPerformedExternallyFields.ResultEntryTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestPerformedExternallyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and TestUnableScreenReasonEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - TestUnableScreenReason.UnableScreenReasonId
		/// </summary>
		public virtual IEntityRelation TestUnableScreenReasonEntityUsingUnableScreenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TestUnableScreenReason" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, TestUnableScreenReasonFields.UnableScreenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestUnableScreenReasonEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and UncontactedCustomerCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - UncontactedCustomerCallQueue.Status
		/// </summary>
		public virtual IEntityRelation UncontactedCustomerCallQueueEntityUsingStatus
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UncontactedCustomerCallQueue" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, UncontactedCustomerCallQueueFields.Status);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UncontactedCustomerCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LookupEntity and WellMedAttestationEntity over the 1:n relation they have, using the relation between the fields:
		/// Lookup.LookupId - WellMedAttestation.StatusId
		/// </summary>
		public virtual IEntityRelation WellMedAttestationEntityUsingStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "WellMedAttestation" , true);
				relation.AddEntityFieldPair(LookupFields.LookupId, WellMedAttestationFields.StatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("WellMedAttestationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LookupEntity and LookupTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// Lookup.LookupTypeId - LookupType.LookupTypeId
		/// </summary>
		public virtual IEntityRelation LookupTypeEntityUsingLookupTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "LookupType", false);
				relation.AddEntityFieldPair(LookupTypeFields.LookupTypeId, LookupFields.LookupTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", true);
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
