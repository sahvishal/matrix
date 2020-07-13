///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:42
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
	/// <summary>Implements the static Relations variant for the entity: CustomerProfile. </summary>
	public partial class CustomerProfileRelations
	{
		/// <summary>CTor</summary>
		public CustomerProfileRelations()
		{
		}

		/// <summary>Gets all relations of the CustomerProfileEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CallQueueCustomerEntityUsingCustomerId);
			toReturn.Add(this.CallRoundCallQueueEntityUsingCustomerId);
			toReturn.Add(this.ChaseOutboundEntityUsingCustomerId);
			toReturn.Add(this.ClickConversionEntityUsingCustomerId);
			toReturn.Add(this.CurrentMedicationEntityUsingCustomerId);
			toReturn.Add(this.CustomerAccountGlocomNumberEntityUsingCustomerId);
			toReturn.Add(this.CustomerBillingAccountEntityUsingCustomerId);
			toReturn.Add(this.CustomerCallQueueCallAttemptEntityUsingCustomerId);
			toReturn.Add(this.CustomerChaseCampaignEntityUsingCustomerId);
			toReturn.Add(this.CustomerChaseChannelEntityUsingCustomerId);
			toReturn.Add(this.CustomerChaseProductEntityUsingCustomerId);
			toReturn.Add(this.CustomerClinicalQuestionAnswerEntityUsingCustomerId);
			toReturn.Add(this.CustomerEligibilityEntityUsingCustomerId);
			toReturn.Add(this.CustomerEventTestFindingEntityUsingCustomerId);
			toReturn.Add(this.CustomerHealthInfoEntityUsingCustomerId);
			toReturn.Add(this.CustomerHealthInfoArchiveEntityUsingCustomerId);
			toReturn.Add(this.CustomerIcdCodeEntityUsingCustomerId);
			toReturn.Add(this.CustomerOrderHistoryEntityUsingCustomerId);
			toReturn.Add(this.CustomerPredictedZipEntityUsingCustomerId);
			toReturn.Add(this.CustomerPrimaryCarePhysicianEntityUsingCustomerId);
			toReturn.Add(this.CustomerProfileHistoryEntityUsingCustomerId);
			toReturn.Add(this.CustomerSurveyEntityUsingCustomerId);
			toReturn.Add(this.CustomerTagEntityUsingCustomerId);
			toReturn.Add(this.CustomerTargetedEntityUsingCustomerId);
			toReturn.Add(this.CustomerUnsubscribedSmsNotificationEntityUsingCustomerId);
			toReturn.Add(this.CustomerWarmTransferEntityUsingCustomerId);
			toReturn.Add(this.DependentDisqualifiedTestEntityUsingCustomerId);
			toReturn.Add(this.DirectMailEntityUsingCustomerId);
			toReturn.Add(this.DisqualifiedTestEntityUsingCustomerId);
			toReturn.Add(this.EventCustomerQuestionAnswerEntityUsingCustomerId);
			toReturn.Add(this.EventCustomerResultEntityUsingCustomerId);
			toReturn.Add(this.EventCustomersEntityUsingCustomerId);
			toReturn.Add(this.EventPaymentDetailsEntityUsingCustomerId);
			toReturn.Add(this.FillEventCallQueueEntityUsingCustomerId);
			toReturn.Add(this.GuardianDetailsEntityUsingCustomerId);
			toReturn.Add(this.HospitalPartnerCustomerEntityUsingCustomerId);
			toReturn.Add(this.LanguageBarrierCallQueueEntityUsingCustomerId);
			toReturn.Add(this.MailRoundCallQueueEntityUsingCustomerId);
			toReturn.Add(this.MedicationEntityUsingCustomerId);
			toReturn.Add(this.MemberUploadLogEntityUsingCustomerId);
			toReturn.Add(this.NoShowCallQueueEntityUsingCustomerId);
			toReturn.Add(this.PhysicianInvoiceItemEntityUsingCustomerId);
			toReturn.Add(this.PreAssessmentCustomerCallQueueCallAttemptEntityUsingCustomerId);
			toReturn.Add(this.PreQualificationResultEntityUsingCustomerId);
			toReturn.Add(this.ProspectCustomerEntityUsingCustomerId);
			toReturn.Add(this.RapsEntityUsingCustomerId);
			toReturn.Add(this.ReferralEntityUsingReferedCustomerId);
			toReturn.Add(this.RequiredTestEntityUsingCustomerId);
			toReturn.Add(this.ResultArchiveUploadLogEntityUsingCustomerId);
			toReturn.Add(this.SuspectConditionEntityUsingCustomerId);
			toReturn.Add(this.TempCartEntityUsingCustomerId);
			toReturn.Add(this.TestimonialEntityUsingCustomerId);
			toReturn.Add(this.UncontactedCustomerCallQueueEntityUsingCustomerId);
			toReturn.Add(this.CustomerCallAttemptsEntityUsingCustomerId);
			toReturn.Add(this.CustomerLockForCallEntityUsingCustomerId);
			toReturn.Add(this.CustomerResultPostedEntityUsingCustomerId);
			toReturn.Add(this.CustomerTraleEntityUsingCustomerId);
			toReturn.Add(this.OrganizationRoleUserEntityUsingCustomerId);
			toReturn.Add(this.ActivityTypeEntityUsingActivityId);
			toReturn.Add(this.AddressEntityUsingBillingAddressId);
			toReturn.Add(this.LabEntityUsingLabId);
			toReturn.Add(this.LanguageEntityUsingLanguageId);
			toReturn.Add(this.LookupEntityUsingPreferredContactType);
			toReturn.Add(this.LookupEntityUsingPhoneOfficeConsentId);
			toReturn.Add(this.LookupEntityUsingDoNotContactReasonId);
			toReturn.Add(this.LookupEntityUsingProductTypeId);
			toReturn.Add(this.LookupEntityUsingPhoneHomeConsentId);
			toReturn.Add(this.LookupEntityUsingDoNotContactUpdateSource);
			toReturn.Add(this.LookupEntityUsingDoNotContactTypeId);
			toReturn.Add(this.LookupEntityUsingPhoneCellConsentId);
			toReturn.Add(this.LookupEntityUsingMemberUploadSourceId);
			toReturn.Add(this.NotesDetailsEntityUsingDoNotContactReasonNotesId);
			toReturn.Add(this.RoleEntityUsingAddedByRoleId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CallQueueCustomer.CustomerId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CallQueueCustomerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CallRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CallRoundCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CallRoundCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ChaseOutboundEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - ChaseOutbound.CustomerId
		/// </summary>
		public virtual IEntityRelation ChaseOutboundEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ChaseOutbound" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ChaseOutboundFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ChaseOutboundEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ClickConversionEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - ClickConversion.CustomerId
		/// </summary>
		public virtual IEntityRelation ClickConversionEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ClickConversion" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ClickConversionFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClickConversionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CurrentMedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CurrentMedication.CustomerId
		/// </summary>
		public virtual IEntityRelation CurrentMedicationEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CurrentMedication" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CurrentMedicationFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CurrentMedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerAccountGlocomNumberEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerAccountGlocomNumber.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerAccountGlocomNumberEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerAccountGlocomNumber" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerAccountGlocomNumberFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerAccountGlocomNumberEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerBillingAccountEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerBillingAccount.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerBillingAccountEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerBillingAccount" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerBillingAccountFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerBillingAccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerCallQueueCallAttempt.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerCallQueueCallAttemptEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerCallQueueCallAttemptFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerChaseCampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerChaseCampaign.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerChaseCampaignEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseCampaign" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerChaseCampaignFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseCampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerChaseChannelEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerChaseChannel.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerChaseChannelEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseChannel" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerChaseChannelFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseChannelEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerChaseProductEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerChaseProduct.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerChaseProductEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerChaseProduct" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerChaseProductFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerChaseProductEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerClinicalQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerClinicalQuestionAnswer.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerClinicalQuestionAnswerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerClinicalQuestionAnswer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerClinicalQuestionAnswerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerClinicalQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerEligibilityEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerEligibility.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerEligibilityEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEligibility" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerEligibilityFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEligibilityEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerEventTestFindingEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerEventTestFinding.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerEventTestFindingEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerEventTestFinding" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerEventTestFindingFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerEventTestFindingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerHealthInfoEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerHealthInfo.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfo" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerHealthInfoFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerHealthInfoArchiveEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerHealthInfoArchive.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerHealthInfoArchiveEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerHealthInfoArchive" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerHealthInfoArchiveFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerHealthInfoArchiveEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerIcdCodeEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerIcdCode.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerIcdCodeEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerIcdCode" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerIcdCodeFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerIcdCodeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerOrderHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerOrderHistory.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerOrderHistoryEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerOrderHistory" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerOrderHistoryFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerOrderHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerPredictedZipEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerPredictedZip.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerPredictedZipEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPredictedZip" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerPredictedZipFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPredictedZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerPrimaryCarePhysicianEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerPrimaryCarePhysician.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerPrimaryCarePhysicianEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerPrimaryCarePhysician" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerPrimaryCarePhysicianFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerPrimaryCarePhysicianEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerProfileHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerProfileHistory.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerProfileHistoryEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerProfileHistory" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerProfileHistoryFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerSurveyEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerSurvey.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerSurveyEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerSurvey" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerSurveyFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerSurveyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerTagEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerTag.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerTagEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTag" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerTagFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerTargetedEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerTargeted.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerTargetedEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerTargeted" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerTargetedFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTargetedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerUnsubscribedSmsNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerUnsubscribedSmsNotification.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerUnsubscribedSmsNotificationEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerUnsubscribedSmsNotification" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerUnsubscribedSmsNotificationFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerUnsubscribedSmsNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerWarmTransferEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerWarmTransfer.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerWarmTransferEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomerWarmTransfer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerWarmTransferFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerWarmTransferEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and DependentDisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - DependentDisqualifiedTest.CustomerId
		/// </summary>
		public virtual IEntityRelation DependentDisqualifiedTestEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DependentDisqualifiedTest" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, DependentDisqualifiedTestFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DependentDisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and DirectMailEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - DirectMail.CustomerId
		/// </summary>
		public virtual IEntityRelation DirectMailEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DirectMail" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, DirectMailFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DirectMailEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and DisqualifiedTestEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - DisqualifiedTest.CustomerId
		/// </summary>
		public virtual IEntityRelation DisqualifiedTestEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DisqualifiedTest" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, DisqualifiedTestFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DisqualifiedTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and EventCustomerQuestionAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - EventCustomerQuestionAnswer.CustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerQuestionAnswerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerQuestionAnswer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventCustomerQuestionAnswerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerQuestionAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and EventCustomerResultEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - EventCustomerResult.CustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomerResultEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomerResult" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventCustomerResultFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomerResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and EventCustomersEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - EventCustomers.CustomerId
		/// </summary>
		public virtual IEntityRelation EventCustomersEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventCustomers" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventCustomersFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventCustomersEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and EventPaymentDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - EventPaymentDetails.CustomerId
		/// </summary>
		public virtual IEntityRelation EventPaymentDetailsEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventPaymentDetails" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, EventPaymentDetailsFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventPaymentDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and FillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - FillEventCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FillEventCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, FillEventCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and GuardianDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - GuardianDetails.CustomerId
		/// </summary>
		public virtual IEntityRelation GuardianDetailsEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GuardianDetails" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, GuardianDetailsFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GuardianDetailsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and HospitalPartnerCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - HospitalPartnerCustomer.CustomerId
		/// </summary>
		public virtual IEntityRelation HospitalPartnerCustomerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HospitalPartnerCustomer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, HospitalPartnerCustomerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HospitalPartnerCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LanguageBarrierCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - LanguageBarrierCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, LanguageBarrierCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and MailRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - MailRoundCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation MailRoundCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MailRoundCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, MailRoundCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MailRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and MedicationEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - Medication.CustomerId
		/// </summary>
		public virtual IEntityRelation MedicationEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Medication" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, MedicationFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MedicationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and MemberUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - MemberUploadLog.CustomerId
		/// </summary>
		public virtual IEntityRelation MemberUploadLogEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MemberUploadLog" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, MemberUploadLogFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MemberUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and NoShowCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - NoShowCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoShowCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, NoShowCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and PhysicianInvoiceItemEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - PhysicianInvoiceItem.CustomerId
		/// </summary>
		public virtual IEntityRelation PhysicianInvoiceItemEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PhysicianInvoiceItem" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PhysicianInvoiceItemFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PhysicianInvoiceItemEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and PreAssessmentCustomerCallQueueCallAttemptEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - PreAssessmentCustomerCallQueueCallAttempt.CustomerId
		/// </summary>
		public virtual IEntityRelation PreAssessmentCustomerCallQueueCallAttemptEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreAssessmentCustomerCallQueueCallAttempt" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PreAssessmentCustomerCallQueueCallAttemptFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreAssessmentCustomerCallQueueCallAttemptEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and PreQualificationResultEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - PreQualificationResult.CustomerId
		/// </summary>
		public virtual IEntityRelation PreQualificationResultEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "PreQualificationResult" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, PreQualificationResultFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("PreQualificationResultEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ProspectCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - ProspectCustomer.CustomerId
		/// </summary>
		public virtual IEntityRelation ProspectCustomerEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ProspectCustomer" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ProspectCustomerFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and RapsEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - Raps.CustomerId
		/// </summary>
		public virtual IEntityRelation RapsEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Raps" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, RapsFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RapsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ReferralEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - Referral.ReferedCustomerId
		/// </summary>
		public virtual IEntityRelation ReferralEntityUsingReferedCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Referral" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ReferralFields.ReferedCustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReferralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and RequiredTestEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - RequiredTest.CustomerId
		/// </summary>
		public virtual IEntityRelation RequiredTestEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RequiredTest" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, RequiredTestFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RequiredTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ResultArchiveUploadLogEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - ResultArchiveUploadLog.CustomerId
		/// </summary>
		public virtual IEntityRelation ResultArchiveUploadLogEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ResultArchiveUploadLog" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, ResultArchiveUploadLogFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ResultArchiveUploadLogEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and SuspectConditionEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - SuspectCondition.CustomerId
		/// </summary>
		public virtual IEntityRelation SuspectConditionEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SuspectCondition" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, SuspectConditionFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SuspectConditionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and TempCartEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - TempCart.CustomerId
		/// </summary>
		public virtual IEntityRelation TempCartEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TempCart" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, TempCartFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TempCartEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and TestimonialEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - Testimonial.CustomerId
		/// </summary>
		public virtual IEntityRelation TestimonialEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Testimonial" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, TestimonialFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TestimonialEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and UncontactedCustomerCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - UncontactedCustomerCallQueue.CustomerId
		/// </summary>
		public virtual IEntityRelation UncontactedCustomerCallQueueEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UncontactedCustomerCallQueue" , true);
				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, UncontactedCustomerCallQueueFields.CustomerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UncontactedCustomerCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerCallAttemptsEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerCallAttempts.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerCallAttemptsEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerCallAttempts", true);

				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerCallAttemptsFields.CustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerCallAttemptsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerLockForCallEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerLockForCall.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerLockForCallEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerLockForCall", true);

				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerLockForCallFields.CustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerLockForCallEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerResultPostedEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerResultPosted.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerResultPostedEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerResultPosted", true);

				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerResultPostedFields.CustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerResultPostedEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and CustomerTraleEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - CustomerTrale.CustomerId
		/// </summary>
		public virtual IEntityRelation CustomerTraleEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "CustomerTrale", true);

				relation.AddEntityFieldPair(CustomerProfileFields.CustomerId, CustomerTraleFields.CustomerId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerTraleEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and OrganizationRoleUserEntity over the 1:1 relation they have, using the relation between the fields:
		/// CustomerProfile.CustomerId - OrganizationRoleUser.OrganizationRoleUserId
		/// </summary>
		public virtual IEntityRelation OrganizationRoleUserEntityUsingCustomerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "OrganizationRoleUser", false);



				relation.AddEntityFieldPair(OrganizationRoleUserFields.OrganizationRoleUserId, CustomerProfileFields.CustomerId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationRoleUserEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and ActivityTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.ActivityId - ActivityType.Id
		/// </summary>
		public virtual IEntityRelation ActivityTypeEntityUsingActivityId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActivityType", false);
				relation.AddEntityFieldPair(ActivityTypeFields.Id, CustomerProfileFields.ActivityId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActivityTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and AddressEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.BillingAddressId - Address.AddressId
		/// </summary>
		public virtual IEntityRelation AddressEntityUsingBillingAddressId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Address", false);
				relation.AddEntityFieldPair(AddressFields.AddressId, CustomerProfileFields.BillingAddressId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AddressEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LabEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.LabId - Lab.Id
		/// </summary>
		public virtual IEntityRelation LabEntityUsingLabId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lab", false);
				relation.AddEntityFieldPair(LabFields.Id, CustomerProfileFields.LabId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LabEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LanguageEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.LanguageId - Language.Id
		/// </summary>
		public virtual IEntityRelation LanguageEntityUsingLanguageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Language", false);
				relation.AddEntityFieldPair(LanguageFields.Id, CustomerProfileFields.LanguageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.PreferredContactType - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPreferredContactType
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup______", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PreferredContactType);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.PhoneOfficeConsentId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPhoneOfficeConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_____", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneOfficeConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.DoNotContactReasonId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDoNotContactReasonId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_______", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactReasonId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.ProductTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingProductTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup________", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.ProductTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.PhoneHomeConsentId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPhoneHomeConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup____", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneHomeConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.DoNotContactUpdateSource - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDoNotContactUpdateSource
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup_", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactUpdateSource);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.DoNotContactTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingDoNotContactTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.DoNotContactTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.PhoneCellConsentId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingPhoneCellConsentId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup___", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.PhoneCellConsentId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.MemberUploadSourceId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingMemberUploadSourceId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup__", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, CustomerProfileFields.MemberUploadSourceId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and NotesDetailsEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.DoNotContactReasonNotesId - NotesDetails.NoteId
		/// </summary>
		public virtual IEntityRelation NotesDetailsEntityUsingDoNotContactReasonNotesId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "NotesDetails", false);
				relation.AddEntityFieldPair(NotesDetailsFields.NoteId, CustomerProfileFields.DoNotContactReasonNotesId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NotesDetailsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between CustomerProfileEntity and RoleEntity over the m:1 relation they have, using the relation between the fields:
		/// CustomerProfile.AddedByRoleId - Role.RoleId
		/// </summary>
		public virtual IEntityRelation RoleEntityUsingAddedByRoleId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Role", false);
				relation.AddEntityFieldPair(RoleFields.RoleId, CustomerProfileFields.AddedByRoleId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RoleEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomerProfileEntity", true);
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
