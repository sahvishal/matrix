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
	/// <summary>Implements the static Relations variant for the entity: Account. </summary>
	public partial class AccountRelations
	{
		/// <summary>CTor</summary>
		public AccountRelations()
		{
		}

		/// <summary>Gets all relations of the AccountEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.AccountAdditionalFieldsEntityUsingAccountId);
			toReturn.Add(this.AccountCallCenterOrganizationEntityUsingAccountId);
			toReturn.Add(this.AccountCallQueueSettingEntityUsingAccountId);
			toReturn.Add(this.AccountCheckoutPhoneNumberEntityUsingAccountId);
			toReturn.Add(this.AccountCustomerResultTestDependencyEntityUsingAccountId);
			toReturn.Add(this.AccountEventZipSubstituteEntityUsingAccountId);
			toReturn.Add(this.AccountHealthPlanResultTestDependencyEntityUsingAccountId);
			toReturn.Add(this.AccountHraChatQuestionnaireEntityUsingAccountId);
			toReturn.Add(this.AccountNotReviewableTestEntityUsingAccountId);
			toReturn.Add(this.AccountPackageEntityUsingAccountId);
			toReturn.Add(this.AccountPcpResultTestDependencyEntityUsingAccountId);
			toReturn.Add(this.AccountTestEntityUsingAccountId);
			toReturn.Add(this.CallQueueCustomerEntityUsingHealthPlanId);
			toReturn.Add(this.CallQueueCustomTagEntityUsingHealthPlanId);
			toReturn.Add(this.CallRoundCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.CallsEntityUsingHealthPlanId);
			toReturn.Add(this.CampaignEntityUsingAccountId);
			toReturn.Add(this.CorporateTagEntityUsingCorporateId);
			toReturn.Add(this.CorporateUploadEntityUsingAccountId);
			toReturn.Add(this.CustomEventNotificationEntityUsingAccountId);
			toReturn.Add(this.EligibilityUploadEntityUsingAccountId);
			toReturn.Add(this.EventAccountEntityUsingAccountId);
			toReturn.Add(this.EventNoteEntityUsingHealthPlanId);
			toReturn.Add(this.FillEventCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId);
			toReturn.Add(this.HealthPlanRevenueEntityUsingAccountId);
			toReturn.Add(this.LanguageBarrierCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.MailRoundCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.NoShowCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.UncontactedCustomerCallQueueEntityUsingHealthPlanId);
			toReturn.Add(this.HealthPlanEventZipEntityUsingAccountId);
			toReturn.Add(this.OrganizationEntityUsingAccountId);
			toReturn.Add(this.CheckListTemplateEntityUsingCheckListTemplateId);
			toReturn.Add(this.CheckListTemplateEntityUsingExitInterviewTemplateId);
			toReturn.Add(this.EmailTemplateEntityUsingMemberCoverLetterTemplateId);
			toReturn.Add(this.EmailTemplateEntityUsingConfirmationSmsTemplateId);
			toReturn.Add(this.EmailTemplateEntityUsingPcpCoverLetterTemplateId);
			toReturn.Add(this.EmailTemplateEntityUsingReminderSmsTemplateId);
			toReturn.Add(this.FileEntityUsingMemberLetterFileId);
			toReturn.Add(this.FileEntityUsingCallCenterScriptFileId);
			toReturn.Add(this.FileEntityUsingConfirmationScriptFileId);
			toReturn.Add(this.FileEntityUsingInboundCallScriptFileId);
			toReturn.Add(this.FileEntityUsingFluffLetterFileId);
			toReturn.Add(this.FileEntityUsingPcpLetterPdfFileId);
			toReturn.Add(this.FileEntityUsingParticipantLetterId);
			toReturn.Add(this.FileEntityUsingCheckListFileId);
			toReturn.Add(this.FileEntityUsingSurveyPdfFileId);
			toReturn.Add(this.FluConsentTemplateEntityUsingFluConsentTemplateId);
			toReturn.Add(this.HafTemplateEntityUsingClinicalQuestionTemplateId);
			toReturn.Add(this.LookupEntityUsingResultFormatTypeId);
			toReturn.Add(this.ProspectsEntityUsingConvertedHostId);
			toReturn.Add(this.SurveyTemplateEntityUsingSurveyTemplateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountAdditionalFieldsEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountAdditionalFields.AccountId
		/// </summary>
		public virtual IEntityRelation AccountAdditionalFieldsEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountAdditionalFields" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountAdditionalFieldsFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountAdditionalFieldsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountCallCenterOrganizationEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountCallCenterOrganization.AccountId
		/// </summary>
		public virtual IEntityRelation AccountCallCenterOrganizationEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallCenterOrganization" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountCallCenterOrganizationFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallCenterOrganizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountCallQueueSettingEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountCallQueueSetting.AccountId
		/// </summary>
		public virtual IEntityRelation AccountCallQueueSettingEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCallQueueSetting" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountCallQueueSettingFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCallQueueSettingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountCheckoutPhoneNumberEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountCheckoutPhoneNumber.AccountId
		/// </summary>
		public virtual IEntityRelation AccountCheckoutPhoneNumberEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCheckoutPhoneNumber" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountCheckoutPhoneNumberFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCheckoutPhoneNumberEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountCustomerResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountCustomerResultTestDependency.AccountId
		/// </summary>
		public virtual IEntityRelation AccountCustomerResultTestDependencyEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountCustomerResultTestDependency" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountCustomerResultTestDependencyFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountCustomerResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountEventZipSubstituteEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountEventZipSubstitute.AccountId
		/// </summary>
		public virtual IEntityRelation AccountEventZipSubstituteEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountEventZipSubstitute" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountEventZipSubstituteFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEventZipSubstituteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountHealthPlanResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountHealthPlanResultTestDependency.AccountId
		/// </summary>
		public virtual IEntityRelation AccountHealthPlanResultTestDependencyEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHealthPlanResultTestDependency" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountHealthPlanResultTestDependencyFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHealthPlanResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountHraChatQuestionnaireEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountHraChatQuestionnaire.AccountId
		/// </summary>
		public virtual IEntityRelation AccountHraChatQuestionnaireEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountHraChatQuestionnaire" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountHraChatQuestionnaireFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountHraChatQuestionnaireEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountNotReviewableTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountNotReviewableTest.AccountId
		/// </summary>
		public virtual IEntityRelation AccountNotReviewableTestEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountNotReviewableTest" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountNotReviewableTestFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountNotReviewableTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountPackageEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountPackage.AccountId
		/// </summary>
		public virtual IEntityRelation AccountPackageEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountPackage" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountPackageFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountPackageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountPcpResultTestDependencyEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountPcpResultTestDependency.AccountId
		/// </summary>
		public virtual IEntityRelation AccountPcpResultTestDependencyEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountPcpResultTestDependency" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountPcpResultTestDependencyFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountPcpResultTestDependencyEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and AccountTestEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - AccountTest.AccountId
		/// </summary>
		public virtual IEntityRelation AccountTestEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "AccountTest" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, AccountTestFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountTestEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CallQueueCustomerEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CallQueueCustomer.HealthPlanId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomerEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomer" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallQueueCustomerFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CallQueueCustomTagEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CallQueueCustomTag.HealthPlanId
		/// </summary>
		public virtual IEntityRelation CallQueueCustomTagEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallQueueCustomTag" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallQueueCustomTagFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallQueueCustomTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CallRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CallRoundCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation CallRoundCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CallRoundCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallRoundCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CallsEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - Calls.HealthPlanId
		/// </summary>
		public virtual IEntityRelation CallsEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Calls" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CallsFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CallsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CampaignEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - Campaign.AccountId
		/// </summary>
		public virtual IEntityRelation CampaignEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Campaign" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CampaignFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CampaignEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CorporateTagEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CorporateTag.CorporateId
		/// </summary>
		public virtual IEntityRelation CorporateTagEntityUsingCorporateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateTag" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CorporateTagFields.CorporateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateTagEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CorporateUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CorporateUpload.AccountId
		/// </summary>
		public virtual IEntityRelation CorporateUploadEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CorporateUpload" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CorporateUploadFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CorporateUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CustomEventNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - CustomEventNotification.AccountId
		/// </summary>
		public virtual IEntityRelation CustomEventNotificationEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CustomEventNotification" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, CustomEventNotificationFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CustomEventNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EligibilityUploadEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - EligibilityUpload.AccountId
		/// </summary>
		public virtual IEntityRelation EligibilityUploadEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EligibilityUpload" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, EligibilityUploadFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EligibilityUploadEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EventAccountEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - EventAccount.AccountId
		/// </summary>
		public virtual IEntityRelation EventAccountEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventAccount" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, EventAccountFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventAccountEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EventNoteEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - EventNote.HealthPlanId
		/// </summary>
		public virtual IEntityRelation EventNoteEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "EventNote" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, EventNoteFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EventNoteEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FillEventCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - FillEventCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation FillEventCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FillEventCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, FillEventCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FillEventCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and HealthPlanCallQueueCriteriaEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - HealthPlanCallQueueCriteria.HealthPlanId
		/// </summary>
		public virtual IEntityRelation HealthPlanCallQueueCriteriaEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanCallQueueCriteria" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, HealthPlanCallQueueCriteriaFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanCallQueueCriteriaEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and HealthPlanRevenueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - HealthPlanRevenue.AccountId
		/// </summary>
		public virtual IEntityRelation HealthPlanRevenueEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HealthPlanRevenue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, HealthPlanRevenueFields.AccountId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanRevenueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and LanguageBarrierCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - LanguageBarrierCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation LanguageBarrierCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LanguageBarrierCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, LanguageBarrierCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LanguageBarrierCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and MailRoundCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - MailRoundCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation MailRoundCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MailRoundCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, MailRoundCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MailRoundCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and NoShowCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - NoShowCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation NoShowCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "NoShowCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, NoShowCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoShowCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and UncontactedCustomerCallQueueEntity over the 1:n relation they have, using the relation between the fields:
		/// Account.AccountId - UncontactedCustomerCallQueue.HealthPlanId
		/// </summary>
		public virtual IEntityRelation UncontactedCustomerCallQueueEntityUsingHealthPlanId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "UncontactedCustomerCallQueue" , true);
				relation.AddEntityFieldPair(AccountFields.AccountId, UncontactedCustomerCallQueueFields.HealthPlanId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("UncontactedCustomerCallQueueEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and HealthPlanEventZipEntity over the 1:1 relation they have, using the relation between the fields:
		/// Account.AccountId - HealthPlanEventZip.AccountId
		/// </summary>
		public virtual IEntityRelation HealthPlanEventZipEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "HealthPlanEventZip", true);

				relation.AddEntityFieldPair(AccountFields.AccountId, HealthPlanEventZipFields.AccountId);



				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HealthPlanEventZipEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and OrganizationEntity over the 1:1 relation they have, using the relation between the fields:
		/// Account.AccountId - Organization.OrganizationId
		/// </summary>
		public virtual IEntityRelation OrganizationEntityUsingAccountId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne, "Organization", false);



				relation.AddEntityFieldPair(OrganizationFields.OrganizationId, AccountFields.AccountId);

				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OrganizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CheckListTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.CheckListTemplateId - CheckListTemplate.Id
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingCheckListTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListTemplate_", false);
				relation.AddEntityFieldPair(CheckListTemplateFields.Id, AccountFields.CheckListTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and CheckListTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ExitInterviewTemplateId - CheckListTemplate.Id
		/// </summary>
		public virtual IEntityRelation CheckListTemplateEntityUsingExitInterviewTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CheckListTemplate", false);
				relation.AddEntityFieldPair(CheckListTemplateFields.Id, AccountFields.ExitInterviewTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CheckListTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EmailTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.MemberCoverLetterTemplateId - EmailTemplate.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingMemberCoverLetterTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EmailTemplate_", false);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.MemberCoverLetterTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EmailTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ConfirmationSmsTemplateId - EmailTemplate.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingConfirmationSmsTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EmailTemplate", false);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.ConfirmationSmsTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EmailTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.PcpCoverLetterTemplateId - EmailTemplate.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingPcpCoverLetterTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EmailTemplate__", false);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.PcpCoverLetterTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and EmailTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ReminderSmsTemplateId - EmailTemplate.EmailTemplateId
		/// </summary>
		public virtual IEntityRelation EmailTemplateEntityUsingReminderSmsTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "EmailTemplate___", false);
				relation.AddEntityFieldPair(EmailTemplateFields.EmailTemplateId, AccountFields.ReminderSmsTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("EmailTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.MemberLetterFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingMemberLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File________", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.MemberLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.CallCenterScriptFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingCallCenterScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_____", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.CallCenterScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ConfirmationScriptFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingConfirmationScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File______", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.ConfirmationScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.InboundCallScriptFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingInboundCallScriptFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_______", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.InboundCallScriptFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.FluffLetterFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingFluffLetterFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File____", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.FluffLetterFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.PcpLetterPdfFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingPcpLetterPdfFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File__", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.PcpLetterPdfFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ParticipantLetterId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingParticipantLetterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File_", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.ParticipantLetterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.CheckListFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingCheckListFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.CheckListFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FileEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.SurveyPdfFileId - File.FileId
		/// </summary>
		public virtual IEntityRelation FileEntityUsingSurveyPdfFileId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "File___", false);
				relation.AddEntityFieldPair(FileFields.FileId, AccountFields.SurveyPdfFileId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FileEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and FluConsentTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.FluConsentTemplateId - FluConsentTemplate.Id
		/// </summary>
		public virtual IEntityRelation FluConsentTemplateEntityUsingFluConsentTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FluConsentTemplate", false);
				relation.AddEntityFieldPair(FluConsentTemplateFields.Id, AccountFields.FluConsentTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FluConsentTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and HafTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ClinicalQuestionTemplateId - HafTemplate.HaftemplateId
		/// </summary>
		public virtual IEntityRelation HafTemplateEntityUsingClinicalQuestionTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HafTemplate", false);
				relation.AddEntityFieldPair(HafTemplateFields.HaftemplateId, AccountFields.ClinicalQuestionTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HafTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and LookupEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ResultFormatTypeId - Lookup.LookupId
		/// </summary>
		public virtual IEntityRelation LookupEntityUsingResultFormatTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Lookup", false);
				relation.AddEntityFieldPair(LookupFields.LookupId, AccountFields.ResultFormatTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LookupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and ProspectsEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.ConvertedHostId - Prospects.ProspectId
		/// </summary>
		public virtual IEntityRelation ProspectsEntityUsingConvertedHostId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Prospects", false);
				relation.AddEntityFieldPair(ProspectsFields.ProspectId, AccountFields.ConvertedHostId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ProspectsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between AccountEntity and SurveyTemplateEntity over the m:1 relation they have, using the relation between the fields:
		/// Account.SurveyTemplateId - SurveyTemplate.Id
		/// </summary>
		public virtual IEntityRelation SurveyTemplateEntityUsingSurveyTemplateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurveyTemplate", false);
				relation.AddEntityFieldPair(SurveyTemplateFields.Id, AccountFields.SurveyTemplateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurveyTemplateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("AccountEntity", true);
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
