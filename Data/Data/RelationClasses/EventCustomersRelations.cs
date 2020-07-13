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
	/// <summary>Implements the static Relations variant for the entity: EventCustomers. </summary>
	public partial class EventCustomersRelations
	{
		/// <summary>CTor</summary>
		public EventCustomersRelations()
		{
		}

		/// <summary>Gets all relations of the EventCustomersEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingEventCustomerId);
			toReturn.Add(this.ChaperoneAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.ChaperoneSignatureEntityUsingEventCustomerId);
			toReturn.Add(this.CheckListAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.ClickConversionEntityUsingEventCustomerId);
			toReturn.Add(this.CustomerHealthInfoEntityUsingEventCustomerId);
			toReturn.Add(this.CustomerHealthInfoArchiveEntityUsingEventCustomerId);
			toReturn.Add(this.CustomerMedicareQuestionAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.CustomerOrderHistoryEntityUsingEventCustomerId);
			toReturn.Add(this.DependentDisqualifiedTestEntityUsingEventCustomerId);
			toReturn.Add(this.DisqualifiedTestEntityUsingEventCustomerId);
			toReturn.Add(this.EventAppointmentCancellationLogEntityUsingEventCustomerId);
			toReturn.Add(this.EventAppointmentChangeLogEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerCriticalQuestionEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerCurrentMedicationEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerCustomNotificationEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerDiagnosisEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerEligibilityEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerEncounterEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerGiftCardEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerIcdCodesEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerNotificationEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerOrderDetailEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerPreApprovedTestEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerRequiredTestEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerRetestEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId);
			toReturn.Add(this.ExitInterviewAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.ExitInterviewSignatureEntityUsingEventCustomerId);
			toReturn.Add(this.FluConsentAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.FluConsentSignatureEntityUsingEventCustomerId);
			toReturn.Add(this.ParticipationConsentSignatureEntityUsingEventCustomerId);
			toReturn.Add(this.PcpDispositionEntityUsingEventCustomerId);
			toReturn.Add(this.PhysicianCustomerAssignmentEntityUsingEventCustomerId);
			toReturn.Add(this.PhysicianEvaluationEntityUsingEventCustomerId);
			toReturn.Add(this.PhysicianRecordRequestSignatureEntityUsingEventCustomerId);
			toReturn.Add(this.SurveyAnswerEntityUsingEventCustomerId);
			toReturn.Add(this.CustomerSkipReviewEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerBarrierEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerBasicBioMetricEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerEvaluationLockEntityUsingEventCustomerId);
			toReturn.Add(this.EventCustomerResultEntityUsingEventCustomerResultId);
			toReturn.Add(this.PcpAppointmentEntityUsingEventCustomerId);
			toReturn.Add(this.ScreeningAuthorizationEntityUsingEventCustomerId);
			toReturn.Add(this.AfaffiliateCampaignEntityUsingAffiliateCampaignId);
			toReturn.Add(this.CampaignEntityUsingCampaignId);
			toReturn.Add(this.CustomerProfileEntityUsingCustomerId);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId);
			toReturn.Add(this.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId);
			toReturn.Add(this.EventAppointmentEntityUsingAppointmentId);
			toReturn.Add(this.EventsEntityUsingEventId);
			toReturn.Add(this.GcNotGivenReasonEntityUsingGcNotGivenReasonId);
			toReturn.Add(this.HospitalFacilityEntityUsingHospitalFacilityId);
			toReturn.Add(this.LookupEntityUsingPreferredContactType);
			toReturn.Add(this.LookupEntityUsingLeftWithoutScreeningReasonId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingConfirmedBy);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CallQueueCustomer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CallQueueCustomerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ChaperoneAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ChaperoneAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ChaperoneAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ChaperoneAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ChaperoneSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ChaperoneSignature.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ChaperoneSignatureEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaperoneSignature" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ChaperoneSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaperoneSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CheckListAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CheckListAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CheckListAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CheckListAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CheckListAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ClickConversionEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ClickConversion.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ClickConversionEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickConversion" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ClickConversionFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerHealthInfoEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CustomerHealthInfo.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfo" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerHealthInfoFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerHealthInfoArchiveEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CustomerHealthInfoArchive.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoArchiveEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfoArchive" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerHealthInfoArchiveFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoArchiveEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerMedicareQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CustomerMedicareQuestionAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerMedicareQuestionAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerMedicareQuestionAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerMedicareQuestionAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerMedicareQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CustomerOrderHistory.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerOrderHistoryFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and DependentDisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - DependentDisqualifiedTest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation DependentDisqualifiedTestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DependentDisqualifiedTest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, DependentDisqualifiedTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DependentDisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - DisqualifiedTest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, DisqualifiedTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventAppointmentCancellationLogEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventAppointmentCancellationLog.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventAppointmentCancellationLogEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentCancellationLog" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventAppointmentCancellationLogFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentCancellationLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventAppointmentChangeLogEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventAppointmentChangeLog.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventAppointmentChangeLogEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAppointmentChangeLog" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventAppointmentChangeLogFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentChangeLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerCriticalQuestionEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerCriticalQuestion.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerCriticalQuestionEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerCriticalQuestion" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerCriticalQuestionFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerCriticalQuestionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerCurrentMedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerCurrentMedication.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerCurrentMedicationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerCurrentMedication" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerCurrentMedicationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerCurrentMedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerCustomNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerCustomNotification.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerCustomNotificationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerCustomNotification" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerCustomNotificationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerCustomNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerDiagnosisEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerDiagnosis.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerDiagnosisEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerDiagnosis" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerDiagnosisFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerDiagnosisEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerEligibility.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerEligibilityEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEligibility" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerEligibilityFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerEncounterEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerEncounter.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerEncounterEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerEncounter" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerEncounterFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEncounterEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerGiftCardEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerGiftCard.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerGiftCardEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerGiftCard" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerGiftCardFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerGiftCardEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerIcdCodesEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerIcdCodes.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerIcdCodesEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerIcdCodes" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerIcdCodesFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerIcdCodesEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerNotification.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerNotificationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerNotification" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerNotificationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerOrderDetailEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerOrderDetail.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerOrderDetailEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerOrderDetail" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerOrderDetailFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerOrderDetailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerPreApprovedPackageTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerPreApprovedPackageTest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerPreApprovedPackageTestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPreApprovedPackageTest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerPreApprovedPackageTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPreApprovedPackageTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerPreApprovedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerPreApprovedTest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerPreApprovedTestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPreApprovedTest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerPreApprovedTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPreApprovedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerPrimaryCarePhysician.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerPrimaryCarePhysicianEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerPrimaryCarePhysicianFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerQuestionAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerQuestionAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerRequiredTestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerRequiredTest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerRequiredTestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerRequiredTest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerRequiredTestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerRequiredTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerRetestEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerRetest.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerRetestEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerRetest" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerRetestFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerRetestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerTestNotPerformedNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerTestNotPerformedNotification.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerTestNotPerformedNotificationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerTestNotPerformedNotification" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerTestNotPerformedNotificationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerTestNotPerformedNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ExitInterviewAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ExitInterviewAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ExitInterviewAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ExitInterviewAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ExitInterviewSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ExitInterviewSignature.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ExitInterviewSignatureEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ExitInterviewSignature" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ExitInterviewSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ExitInterviewSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and FluConsentAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - FluConsentAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation FluConsentAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, FluConsentAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and FluConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - FluConsentSignature.EventCustomerId
		/// </summary>
		public virtual IEntityRelation FluConsentSignatureEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FluConsentSignature" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, FluConsentSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ParticipationConsentSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ParticipationConsentSignature.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ParticipationConsentSignatureEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ParticipationConsentSignature" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ParticipationConsentSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ParticipationConsentSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and PcpDispositionEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - PcpDisposition.EventCustomerId
		/// </summary>
		public virtual IEntityRelation PcpDispositionEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PcpDisposition" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PcpDispositionFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpDispositionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and PhysicianCustomerAssignmentEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - PhysicianCustomerAssignment.EventCustomerId
		/// </summary>
		public virtual IEntityRelation PhysicianCustomerAssignmentEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianCustomerAssignment" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PhysicianCustomerAssignmentFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianCustomerAssignmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and PhysicianEvaluationEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - PhysicianEvaluation.EventCustomerId
		/// </summary>
		public virtual IEntityRelation PhysicianEvaluationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianEvaluation" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PhysicianEvaluationFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianEvaluationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and PhysicianRecordRequestSignatureEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - PhysicianRecordRequestSignature.EventCustomerId
		/// </summary>
		public virtual IEntityRelation PhysicianRecordRequestSignatureEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianRecordRequestSignature" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PhysicianRecordRequestSignatureFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianRecordRequestSignatureEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and SurveyAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - SurveyAnswer.EventCustomerId
		/// </summary>
		public virtual IEntityRelation SurveyAnswerEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurveyAnswer" , true);
				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, SurveyAnswerFields.EventCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerSkipReviewEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - CustomerSkipReview.EventCustomerId
		/// </summary>
		public virtual IEntityRelation CustomerSkipReviewEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerSkipReview", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, CustomerSkipReviewFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSkipReviewEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerBarrierEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerBarrier.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerBarrierEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerBarrier", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerBarrierFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerBarrierEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerBasicBioMetricEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerBasicBioMetric.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerBasicBioMetricEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerBasicBioMetric", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerBasicBioMetricFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerBasicBioMetricEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerEvaluationLockEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerEvaluationLock.EventCustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerEvaluationLockEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerEvaluationLock", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerEvaluationLockFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerEvaluationLockEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventCustomerResultEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - EventCustomerResult.EventCustomerResultId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingEventCustomerResultId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "EventCustomerResult", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, EventCustomerResultFields.EventCustomerResultId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and PcpAppointmentEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - PcpAppointment.EventCustomerId
		/// </summary>
		public virtual IEntityRelation PcpAppointmentEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "PcpAppointment_", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, PcpAppointmentFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PcpAppointmentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and ScreeningAuthorizationEntity over the 1:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventCustomerId - ScreeningAuthorization.EventCustomerId
		/// </summary>
		public virtual IEntityRelation ScreeningAuthorizationEntityUsingEventCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "ScreeningAuthorization", true);

				relation.AddEntityFieldPair(EventCustomersFields.EventCustomerId, ScreeningAuthorizationFields.EventCustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ScreeningAuthorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and AfaffiliateCampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.AffiliateCampaignId - AfaffiliateCampaign.AffiliateCampaignId
		/// </summary>
		public virtual IEntityRelation AfaffiliateCampaignEntityUsingAffiliateCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "AfaffiliateCampaign", false);
				relation.AddEntityFieldPair(AfaffiliateCampaignFields.AffiliateCampaignId, EventCustomersFields.AffiliateCampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AfaffiliateCampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CampaignEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.CampaignId - Campaign.Id
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingCampaignId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Campaign", false);
				relation.AddEntityFieldPair(CampaignFields.Id, EventCustomersFields.CampaignId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerProfileEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.CustomerId - CustomerProfile.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfile", false);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventCustomersFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerProfileHistoryEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.CustomerProfileHistoryId - CustomerProfileHistory.Id
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingCustomerProfileHistoryId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerProfileHistory", false);
				relation.AddEntityFieldPair(CustomerProfileHistoryFields.Id, EventCustomersFields.CustomerProfileHistoryId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and CustomerRegistrationNotesEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.LeftWithoutScreeningNotesId - CustomerRegistrationNotes.CustomerRegistrationNotesId
		/// </summary>
		public virtual IEntityRelation CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CustomerRegistrationNotes", false);
				relation.AddEntityFieldPair(CustomerRegistrationNotesFields.CustomerRegistrationNotesId, EventCustomersFields.LeftWithoutScreeningNotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerRegistrationNotesEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventAppointmentEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.AppointmentId - EventAppointment.AppointmentId
		/// </summary>
		public virtual IEntityRelation EventAppointmentEntityUsingAppointmentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EventAppointment", false);
				relation.AddEntityFieldPair(EventAppointmentFields.AppointmentId, EventCustomersFields.AppointmentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAppointmentEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and EventsEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.EventId - Events.EventId
		/// </summary>
		public virtual IEntityRelation EventsEntityUsingEventId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Events", false);
				relation.AddEntityFieldPair(EventsFields.EventId, EventCustomersFields.EventId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and GcNotGivenReasonEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.GcNotGivenReasonId - GcNotGivenReason.Id
		/// </summary>
		public virtual IEntityRelation GcNotGivenReasonEntityUsingGcNotGivenReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GcNotGivenReason", false);
				relation.AddEntityFieldPair(GcNotGivenReasonFields.Id, EventCustomersFields.GcNotGivenReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GcNotGivenReasonEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and HospitalFacilityEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.HospitalFacilityId - HospitalFacility.HospitalFacilityId
		/// </summary>
		public virtual IEntityRelation HospitalFacilityEntityUsingHospitalFacilityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HospitalFacility", false);
				relation.AddEntityFieldPair(HospitalFacilityFields.HospitalFacilityId, EventCustomersFields.HospitalFacilityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalFacilityEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.PreferredContactType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomersFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.LeftWithoutScreeningReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingLeftWithoutScreeningReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, EventCustomersFields.LeftWithoutScreeningReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.ConfirmedBy - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingConfirmedBy
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser_", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomersFields.ConfirmedBy);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between EventCustomersEntity and OrganizationRoleUserEntity over the m:1 relation they have, using the relation between the fields:
		/// EventCustomers.CreatedByOrgRoleUserId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OrganizationRoleUser", false);
				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, EventCustomersFields.CreatedByOrgRoleUserId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", true);
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
