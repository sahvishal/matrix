///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:52
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Falcon.Data;
using Falcon.Data.HelperClasses;
using Falcon.Data.FactoryClasses;
using Falcon.Data.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.Data.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'Account'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AccountEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountAdditionalFieldsEntity> _accountAdditionalFields;
		private EntityCollection<AccountCallCenterOrganizationEntity> _accountCallCenterOrganization;
		private EntityCollection<AccountCallQueueSettingEntity> _accountCallQueueSetting;
		private EntityCollection<AccountCheckoutPhoneNumberEntity> _accountCheckoutPhoneNumber;
		private EntityCollection<AccountCustomerResultTestDependencyEntity> _accountCustomerResultTestDependency;
		private EntityCollection<AccountEventZipSubstituteEntity> _accountEventZipSubstitute;
		private EntityCollection<AccountHealthPlanResultTestDependencyEntity> _accountHealthPlanResultTestDependency;
		private EntityCollection<AccountHraChatQuestionnaireEntity> _accountHraChatQuestionnaire;
		private EntityCollection<AccountNotReviewableTestEntity> _accountNotReviewableTest;
		private EntityCollection<AccountPackageEntity> _accountPackage;
		private EntityCollection<AccountPcpResultTestDependencyEntity> _accountPcpResultTestDependency;
		private EntityCollection<AccountTestEntity> _accountTest;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<CallQueueCustomTagEntity> _callQueueCustomTag;
		private EntityCollection<CallRoundCallQueueEntity> _callRoundCallQueue;
		private EntityCollection<CallsEntity> _calls;
		private EntityCollection<CampaignEntity> _campaign;
		private EntityCollection<CorporateTagEntity> _corporateTag;
		private EntityCollection<CorporateUploadEntity> _corporateUpload;
		private EntityCollection<CustomEventNotificationEntity> _customEventNotification;
		private EntityCollection<EligibilityUploadEntity> _eligibilityUpload;
		private EntityCollection<EventAccountEntity> _eventAccount;
		private EntityCollection<EventNoteEntity> _eventNote;
		private EntityCollection<FillEventCallQueueEntity> _fillEventCallQueue;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteria;
		private EntityCollection<HealthPlanRevenueEntity> _healthPlanRevenue;
		private EntityCollection<LanguageBarrierCallQueueEntity> _languageBarrierCallQueue;
		private EntityCollection<MailRoundCallQueueEntity> _mailRoundCallQueue;
		private EntityCollection<NoShowCallQueueEntity> _noShowCallQueue;
		private EntityCollection<UncontactedCustomerCallQueueEntity> _uncontactedCustomerCallQueue;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<AdditionalFieldsEntity> _additionalFieldsCollectionViaAccountAdditionalFields;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaAccountCallQueueSetting;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCalls;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCalls;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaNoShowCallQueue;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaFillEventCallQueue;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaUncontactedCustomerCallQueue;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaMailRoundCallQueue;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaLanguageBarrierCallQueue;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallRoundCallQueue;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomEventNotification;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<FileEntity> _fileCollectionViaEligibilityUpload;
		private EntityCollection<FileEntity> _fileCollectionViaEligibilityUpload_;
		private EntityCollection<FileEntity> _fileCollectionViaCorporateUpload_;
		private EntityCollection<FileEntity> _fileCollectionViaCorporateUpload;
		private EntityCollection<FileEntity> _fileCollectionViaCorporateUpload__;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LanguageEntity> _languageCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<LookupEntity> _lookupCollectionViaCampaign;
		private EntityCollection<LookupEntity> _lookupCollectionViaUncontactedCustomerCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls__;
		private EntityCollection<LookupEntity> _lookupCollectionViaLanguageBarrierCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaCampaign_;
		private EntityCollection<LookupEntity> _lookupCollectionViaHealthPlanRevenue;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomEventNotification;
		private EntityCollection<LookupEntity> _lookupCollectionViaFillEventCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaEligibilityUpload;
		private EntityCollection<LookupEntity> _lookupCollectionViaNoShowCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaCorporateUpload;
		private EntityCollection<LookupEntity> _lookupCollectionViaMailRoundCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccountCallQueueSetting;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccountHraChatQuestionnaire;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallRoundCallQueue;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaAccountCallCenterOrganization;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountHraChatQuestionnaire;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountHraChatQuestionnaire_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaFillEventCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventNote_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaNoShowCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountCallCenterOrganization_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaUncontactedCustomerCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountCallCenterOrganization;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanRevenue_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanRevenue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMailRoundCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaLanguageBarrierCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomTag;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCorporateTag_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCorporateUpload;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCorporateTag;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallRoundCallQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCalls;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaign_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaign;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventNote;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEligibilityUpload;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomEventNotification;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<PackageEntity> _packageCollectionViaAccountPackage;
		private EntityCollection<PodDetailsEntity> _podDetailsCollectionViaEventNote;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private EntityCollection<StateEntity> _stateCollectionViaAccountCheckoutPhoneNumber;
		private EntityCollection<TestEntity> _testCollectionViaAccountPcpResultTestDependency;
		private EntityCollection<TestEntity> _testCollectionViaAccountHealthPlanResultTestDependency;
		private EntityCollection<TestEntity> _testCollectionViaAccountCustomerResultTestDependency;
		private EntityCollection<TestEntity> _testCollectionViaAccountNotReviewableTest;
		private EntityCollection<TestEntity> _testCollectionViaAccountTest;
		private EntityCollection<ZipEntity> _zipCollectionViaAccountEventZipSubstitute;
		private CheckListTemplateEntity _checkListTemplate_;
		private CheckListTemplateEntity _checkListTemplate;
		private EmailTemplateEntity _emailTemplate_;
		private EmailTemplateEntity _emailTemplate;
		private EmailTemplateEntity _emailTemplate__;
		private EmailTemplateEntity _emailTemplate___;
		private FileEntity _file________;
		private FileEntity _file_____;
		private FileEntity _file______;
		private FileEntity _file_______;
		private FileEntity _file____;
		private FileEntity _file__;
		private FileEntity _file_;
		private FileEntity _file;
		private FileEntity _file___;
		private FluConsentTemplateEntity _fluConsentTemplate;
		private HafTemplateEntity _hafTemplate;
		private LookupEntity _lookup;
		private ProspectsEntity _prospects;
		private SurveyTemplateEntity _surveyTemplate;
		private HealthPlanEventZipEntity _healthPlanEventZip;
		private OrganizationEntity _organization;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name CheckListTemplate_</summary>
			public static readonly string CheckListTemplate_ = "CheckListTemplate_";
			/// <summary>Member name CheckListTemplate</summary>
			public static readonly string CheckListTemplate = "CheckListTemplate";
			/// <summary>Member name EmailTemplate_</summary>
			public static readonly string EmailTemplate_ = "EmailTemplate_";
			/// <summary>Member name EmailTemplate</summary>
			public static readonly string EmailTemplate = "EmailTemplate";
			/// <summary>Member name EmailTemplate__</summary>
			public static readonly string EmailTemplate__ = "EmailTemplate__";
			/// <summary>Member name EmailTemplate___</summary>
			public static readonly string EmailTemplate___ = "EmailTemplate___";
			/// <summary>Member name File________</summary>
			public static readonly string File________ = "File________";
			/// <summary>Member name File_____</summary>
			public static readonly string File_____ = "File_____";
			/// <summary>Member name File______</summary>
			public static readonly string File______ = "File______";
			/// <summary>Member name File_______</summary>
			public static readonly string File_______ = "File_______";
			/// <summary>Member name File____</summary>
			public static readonly string File____ = "File____";
			/// <summary>Member name File__</summary>
			public static readonly string File__ = "File__";
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name File___</summary>
			public static readonly string File___ = "File___";
			/// <summary>Member name FluConsentTemplate</summary>
			public static readonly string FluConsentTemplate = "FluConsentTemplate";
			/// <summary>Member name HafTemplate</summary>
			public static readonly string HafTemplate = "HafTemplate";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name SurveyTemplate</summary>
			public static readonly string SurveyTemplate = "SurveyTemplate";
			/// <summary>Member name AccountAdditionalFields</summary>
			public static readonly string AccountAdditionalFields = "AccountAdditionalFields";
			/// <summary>Member name AccountCallCenterOrganization</summary>
			public static readonly string AccountCallCenterOrganization = "AccountCallCenterOrganization";
			/// <summary>Member name AccountCallQueueSetting</summary>
			public static readonly string AccountCallQueueSetting = "AccountCallQueueSetting";
			/// <summary>Member name AccountCheckoutPhoneNumber</summary>
			public static readonly string AccountCheckoutPhoneNumber = "AccountCheckoutPhoneNumber";
			/// <summary>Member name AccountCustomerResultTestDependency</summary>
			public static readonly string AccountCustomerResultTestDependency = "AccountCustomerResultTestDependency";
			/// <summary>Member name AccountEventZipSubstitute</summary>
			public static readonly string AccountEventZipSubstitute = "AccountEventZipSubstitute";
			/// <summary>Member name AccountHealthPlanResultTestDependency</summary>
			public static readonly string AccountHealthPlanResultTestDependency = "AccountHealthPlanResultTestDependency";
			/// <summary>Member name AccountHraChatQuestionnaire</summary>
			public static readonly string AccountHraChatQuestionnaire = "AccountHraChatQuestionnaire";
			/// <summary>Member name AccountNotReviewableTest</summary>
			public static readonly string AccountNotReviewableTest = "AccountNotReviewableTest";
			/// <summary>Member name AccountPackage</summary>
			public static readonly string AccountPackage = "AccountPackage";
			/// <summary>Member name AccountPcpResultTestDependency</summary>
			public static readonly string AccountPcpResultTestDependency = "AccountPcpResultTestDependency";
			/// <summary>Member name AccountTest</summary>
			public static readonly string AccountTest = "AccountTest";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name CallQueueCustomTag</summary>
			public static readonly string CallQueueCustomTag = "CallQueueCustomTag";
			/// <summary>Member name CallRoundCallQueue</summary>
			public static readonly string CallRoundCallQueue = "CallRoundCallQueue";
			/// <summary>Member name Calls</summary>
			public static readonly string Calls = "Calls";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name CorporateTag</summary>
			public static readonly string CorporateTag = "CorporateTag";
			/// <summary>Member name CorporateUpload</summary>
			public static readonly string CorporateUpload = "CorporateUpload";
			/// <summary>Member name CustomEventNotification</summary>
			public static readonly string CustomEventNotification = "CustomEventNotification";
			/// <summary>Member name EligibilityUpload</summary>
			public static readonly string EligibilityUpload = "EligibilityUpload";
			/// <summary>Member name EventAccount</summary>
			public static readonly string EventAccount = "EventAccount";
			/// <summary>Member name EventNote</summary>
			public static readonly string EventNote = "EventNote";
			/// <summary>Member name FillEventCallQueue</summary>
			public static readonly string FillEventCallQueue = "FillEventCallQueue";
			/// <summary>Member name HealthPlanCallQueueCriteria</summary>
			public static readonly string HealthPlanCallQueueCriteria = "HealthPlanCallQueueCriteria";
			/// <summary>Member name HealthPlanRevenue</summary>
			public static readonly string HealthPlanRevenue = "HealthPlanRevenue";
			/// <summary>Member name LanguageBarrierCallQueue</summary>
			public static readonly string LanguageBarrierCallQueue = "LanguageBarrierCallQueue";
			/// <summary>Member name MailRoundCallQueue</summary>
			public static readonly string MailRoundCallQueue = "MailRoundCallQueue";
			/// <summary>Member name NoShowCallQueue</summary>
			public static readonly string NoShowCallQueue = "NoShowCallQueue";
			/// <summary>Member name UncontactedCustomerCallQueue</summary>
			public static readonly string UncontactedCustomerCallQueue = "UncontactedCustomerCallQueue";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name AdditionalFieldsCollectionViaAccountAdditionalFields</summary>
			public static readonly string AdditionalFieldsCollectionViaAccountAdditionalFields = "AdditionalFieldsCollectionViaAccountAdditionalFields";
			/// <summary>Member name CallQueueCollectionViaAccountCallQueueSetting</summary>
			public static readonly string CallQueueCollectionViaAccountCallQueueSetting = "CallQueueCollectionViaAccountCallQueueSetting";
			/// <summary>Member name CallQueueCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CallQueueCollectionViaHealthPlanCallQueueCriteria = "CallQueueCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CallQueueCollectionViaCalls</summary>
			public static readonly string CallQueueCollectionViaCalls = "CallQueueCollectionViaCalls";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CampaignCollectionViaHealthPlanCallQueueCriteria = "CampaignCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CampaignCollectionViaCalls</summary>
			public static readonly string CampaignCollectionViaCalls = "CampaignCollectionViaCalls";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaNoShowCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaNoShowCallQueue = "CustomerProfileCollectionViaNoShowCallQueue";
			/// <summary>Member name CustomerProfileCollectionViaFillEventCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaFillEventCallQueue = "CustomerProfileCollectionViaFillEventCallQueue";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaUncontactedCustomerCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaUncontactedCustomerCallQueue = "CustomerProfileCollectionViaUncontactedCustomerCallQueue";
			/// <summary>Member name CustomerProfileCollectionViaMailRoundCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaMailRoundCallQueue = "CustomerProfileCollectionViaMailRoundCallQueue";
			/// <summary>Member name CustomerProfileCollectionViaLanguageBarrierCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaLanguageBarrierCallQueue = "CustomerProfileCollectionViaLanguageBarrierCallQueue";
			/// <summary>Member name CustomerProfileCollectionViaCallRoundCallQueue</summary>
			public static readonly string CustomerProfileCollectionViaCallRoundCallQueue = "CustomerProfileCollectionViaCallRoundCallQueue";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaCustomEventNotification</summary>
			public static readonly string EventsCollectionViaCustomEventNotification = "EventsCollectionViaCustomEventNotification";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name FileCollectionViaEligibilityUpload</summary>
			public static readonly string FileCollectionViaEligibilityUpload = "FileCollectionViaEligibilityUpload";
			/// <summary>Member name FileCollectionViaEligibilityUpload_</summary>
			public static readonly string FileCollectionViaEligibilityUpload_ = "FileCollectionViaEligibilityUpload_";
			/// <summary>Member name FileCollectionViaCorporateUpload_</summary>
			public static readonly string FileCollectionViaCorporateUpload_ = "FileCollectionViaCorporateUpload_";
			/// <summary>Member name FileCollectionViaCorporateUpload</summary>
			public static readonly string FileCollectionViaCorporateUpload = "FileCollectionViaCorporateUpload";
			/// <summary>Member name FileCollectionViaCorporateUpload__</summary>
			public static readonly string FileCollectionViaCorporateUpload__ = "FileCollectionViaCorporateUpload__";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LanguageCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string LanguageCollectionViaHealthPlanCallQueueCriteria = "LanguageCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name LookupCollectionViaCampaign</summary>
			public static readonly string LookupCollectionViaCampaign = "LookupCollectionViaCampaign";
			/// <summary>Member name LookupCollectionViaUncontactedCustomerCallQueue</summary>
			public static readonly string LookupCollectionViaUncontactedCustomerCallQueue = "LookupCollectionViaUncontactedCustomerCallQueue";
			/// <summary>Member name LookupCollectionViaCalls__</summary>
			public static readonly string LookupCollectionViaCalls__ = "LookupCollectionViaCalls__";
			/// <summary>Member name LookupCollectionViaLanguageBarrierCallQueue</summary>
			public static readonly string LookupCollectionViaLanguageBarrierCallQueue = "LookupCollectionViaLanguageBarrierCallQueue";
			/// <summary>Member name LookupCollectionViaCampaign_</summary>
			public static readonly string LookupCollectionViaCampaign_ = "LookupCollectionViaCampaign_";
			/// <summary>Member name LookupCollectionViaHealthPlanRevenue</summary>
			public static readonly string LookupCollectionViaHealthPlanRevenue = "LookupCollectionViaHealthPlanRevenue";
			/// <summary>Member name LookupCollectionViaCustomEventNotification</summary>
			public static readonly string LookupCollectionViaCustomEventNotification = "LookupCollectionViaCustomEventNotification";
			/// <summary>Member name LookupCollectionViaFillEventCallQueue</summary>
			public static readonly string LookupCollectionViaFillEventCallQueue = "LookupCollectionViaFillEventCallQueue";
			/// <summary>Member name LookupCollectionViaEligibilityUpload</summary>
			public static readonly string LookupCollectionViaEligibilityUpload = "LookupCollectionViaEligibilityUpload";
			/// <summary>Member name LookupCollectionViaNoShowCallQueue</summary>
			public static readonly string LookupCollectionViaNoShowCallQueue = "LookupCollectionViaNoShowCallQueue";
			/// <summary>Member name LookupCollectionViaCorporateUpload</summary>
			public static readonly string LookupCollectionViaCorporateUpload = "LookupCollectionViaCorporateUpload";
			/// <summary>Member name LookupCollectionViaMailRoundCallQueue</summary>
			public static readonly string LookupCollectionViaMailRoundCallQueue = "LookupCollectionViaMailRoundCallQueue";
			/// <summary>Member name LookupCollectionViaAccountCallQueueSetting</summary>
			public static readonly string LookupCollectionViaAccountCallQueueSetting = "LookupCollectionViaAccountCallQueueSetting";
			/// <summary>Member name LookupCollectionViaAccountHraChatQuestionnaire</summary>
			public static readonly string LookupCollectionViaAccountHraChatQuestionnaire = "LookupCollectionViaAccountHraChatQuestionnaire";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCallRoundCallQueue</summary>
			public static readonly string LookupCollectionViaCallRoundCallQueue = "LookupCollectionViaCallRoundCallQueue";
			/// <summary>Member name LookupCollectionViaCalls_</summary>
			public static readonly string LookupCollectionViaCalls_ = "LookupCollectionViaCalls_";
			/// <summary>Member name LookupCollectionViaCalls</summary>
			public static readonly string LookupCollectionViaCalls = "LookupCollectionViaCalls";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationCollectionViaAccountCallCenterOrganization</summary>
			public static readonly string OrganizationCollectionViaAccountCallCenterOrganization = "OrganizationCollectionViaAccountCallCenterOrganization";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire = "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_ = "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_";
			/// <summary>Member name OrganizationRoleUserCollectionViaFillEventCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaFillEventCallQueue = "OrganizationRoleUserCollectionViaFillEventCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventNote_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventNote_ = "OrganizationRoleUserCollectionViaEventNote_";
			/// <summary>Member name OrganizationRoleUserCollectionViaNoShowCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaNoShowCallQueue = "OrganizationRoleUserCollectionViaNoShowCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountCallCenterOrganization_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountCallCenterOrganization_ = "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_";
			/// <summary>Member name OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue = "OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountCallCenterOrganization</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountCallCenterOrganization = "OrganizationRoleUserCollectionViaAccountCallCenterOrganization";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanRevenue_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanRevenue_ = "OrganizationRoleUserCollectionViaHealthPlanRevenue_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanRevenue</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanRevenue = "OrganizationRoleUserCollectionViaHealthPlanRevenue";
			/// <summary>Member name OrganizationRoleUserCollectionViaMailRoundCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaMailRoundCallQueue = "OrganizationRoleUserCollectionViaMailRoundCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaLanguageBarrierCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaLanguageBarrierCallQueue = "OrganizationRoleUserCollectionViaLanguageBarrierCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomTag</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomTag = "OrganizationRoleUserCollectionViaCallQueueCustomTag";
			/// <summary>Member name OrganizationRoleUserCollectionViaCorporateTag_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCorporateTag_ = "OrganizationRoleUserCollectionViaCorporateTag_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCorporateUpload</summary>
			public static readonly string OrganizationRoleUserCollectionViaCorporateUpload = "OrganizationRoleUserCollectionViaCorporateUpload";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCorporateTag</summary>
			public static readonly string OrganizationRoleUserCollectionViaCorporateTag = "OrganizationRoleUserCollectionViaCorporateTag";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallRoundCallQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallRoundCallQueue = "OrganizationRoleUserCollectionViaCallRoundCallQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaCalls</summary>
			public static readonly string OrganizationRoleUserCollectionViaCalls = "OrganizationRoleUserCollectionViaCalls";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaign_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaign_ = "OrganizationRoleUserCollectionViaCampaign_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaign</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaign = "OrganizationRoleUserCollectionViaCampaign";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventNote</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventNote = "OrganizationRoleUserCollectionViaEventNote";
			/// <summary>Member name OrganizationRoleUserCollectionViaEligibilityUpload</summary>
			public static readonly string OrganizationRoleUserCollectionViaEligibilityUpload = "OrganizationRoleUserCollectionViaEligibilityUpload";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomEventNotification</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomEventNotification = "OrganizationRoleUserCollectionViaCustomEventNotification";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name PackageCollectionViaAccountPackage</summary>
			public static readonly string PackageCollectionViaAccountPackage = "PackageCollectionViaAccountPackage";
			/// <summary>Member name PodDetailsCollectionViaEventNote</summary>
			public static readonly string PodDetailsCollectionViaEventNote = "PodDetailsCollectionViaEventNote";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";
			/// <summary>Member name StateCollectionViaAccountCheckoutPhoneNumber</summary>
			public static readonly string StateCollectionViaAccountCheckoutPhoneNumber = "StateCollectionViaAccountCheckoutPhoneNumber";
			/// <summary>Member name TestCollectionViaAccountPcpResultTestDependency</summary>
			public static readonly string TestCollectionViaAccountPcpResultTestDependency = "TestCollectionViaAccountPcpResultTestDependency";
			/// <summary>Member name TestCollectionViaAccountHealthPlanResultTestDependency</summary>
			public static readonly string TestCollectionViaAccountHealthPlanResultTestDependency = "TestCollectionViaAccountHealthPlanResultTestDependency";
			/// <summary>Member name TestCollectionViaAccountCustomerResultTestDependency</summary>
			public static readonly string TestCollectionViaAccountCustomerResultTestDependency = "TestCollectionViaAccountCustomerResultTestDependency";
			/// <summary>Member name TestCollectionViaAccountNotReviewableTest</summary>
			public static readonly string TestCollectionViaAccountNotReviewableTest = "TestCollectionViaAccountNotReviewableTest";
			/// <summary>Member name TestCollectionViaAccountTest</summary>
			public static readonly string TestCollectionViaAccountTest = "TestCollectionViaAccountTest";
			/// <summary>Member name ZipCollectionViaAccountEventZipSubstitute</summary>
			public static readonly string ZipCollectionViaAccountEventZipSubstitute = "ZipCollectionViaAccountEventZipSubstitute";
			/// <summary>Member name HealthPlanEventZip</summary>
			public static readonly string HealthPlanEventZip = "HealthPlanEventZip";
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AccountEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AccountEntity():base("AccountEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AccountEntity(IEntityFields2 fields):base("AccountEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AccountEntity</param>
		public AccountEntity(IValidator validator):base("AccountEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="accountId">PK value for Account which data should be fetched into this Account object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AccountEntity(System.Int64 accountId):base("AccountEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AccountId = accountId;
		}

		/// <summary> CTor</summary>
		/// <param name="accountId">PK value for Account which data should be fetched into this Account object</param>
		/// <param name="validator">The custom validator object for this AccountEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AccountEntity(System.Int64 accountId, IValidator validator):base("AccountEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AccountId = accountId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AccountEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountAdditionalFields = (EntityCollection<AccountAdditionalFieldsEntity>)info.GetValue("_accountAdditionalFields", typeof(EntityCollection<AccountAdditionalFieldsEntity>));
				_accountCallCenterOrganization = (EntityCollection<AccountCallCenterOrganizationEntity>)info.GetValue("_accountCallCenterOrganization", typeof(EntityCollection<AccountCallCenterOrganizationEntity>));
				_accountCallQueueSetting = (EntityCollection<AccountCallQueueSettingEntity>)info.GetValue("_accountCallQueueSetting", typeof(EntityCollection<AccountCallQueueSettingEntity>));
				_accountCheckoutPhoneNumber = (EntityCollection<AccountCheckoutPhoneNumberEntity>)info.GetValue("_accountCheckoutPhoneNumber", typeof(EntityCollection<AccountCheckoutPhoneNumberEntity>));
				_accountCustomerResultTestDependency = (EntityCollection<AccountCustomerResultTestDependencyEntity>)info.GetValue("_accountCustomerResultTestDependency", typeof(EntityCollection<AccountCustomerResultTestDependencyEntity>));
				_accountEventZipSubstitute = (EntityCollection<AccountEventZipSubstituteEntity>)info.GetValue("_accountEventZipSubstitute", typeof(EntityCollection<AccountEventZipSubstituteEntity>));
				_accountHealthPlanResultTestDependency = (EntityCollection<AccountHealthPlanResultTestDependencyEntity>)info.GetValue("_accountHealthPlanResultTestDependency", typeof(EntityCollection<AccountHealthPlanResultTestDependencyEntity>));
				_accountHraChatQuestionnaire = (EntityCollection<AccountHraChatQuestionnaireEntity>)info.GetValue("_accountHraChatQuestionnaire", typeof(EntityCollection<AccountHraChatQuestionnaireEntity>));
				_accountNotReviewableTest = (EntityCollection<AccountNotReviewableTestEntity>)info.GetValue("_accountNotReviewableTest", typeof(EntityCollection<AccountNotReviewableTestEntity>));
				_accountPackage = (EntityCollection<AccountPackageEntity>)info.GetValue("_accountPackage", typeof(EntityCollection<AccountPackageEntity>));
				_accountPcpResultTestDependency = (EntityCollection<AccountPcpResultTestDependencyEntity>)info.GetValue("_accountPcpResultTestDependency", typeof(EntityCollection<AccountPcpResultTestDependencyEntity>));
				_accountTest = (EntityCollection<AccountTestEntity>)info.GetValue("_accountTest", typeof(EntityCollection<AccountTestEntity>));
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callQueueCustomTag = (EntityCollection<CallQueueCustomTagEntity>)info.GetValue("_callQueueCustomTag", typeof(EntityCollection<CallQueueCustomTagEntity>));
				_callRoundCallQueue = (EntityCollection<CallRoundCallQueueEntity>)info.GetValue("_callRoundCallQueue", typeof(EntityCollection<CallRoundCallQueueEntity>));
				_calls = (EntityCollection<CallsEntity>)info.GetValue("_calls", typeof(EntityCollection<CallsEntity>));
				_campaign = (EntityCollection<CampaignEntity>)info.GetValue("_campaign", typeof(EntityCollection<CampaignEntity>));
				_corporateTag = (EntityCollection<CorporateTagEntity>)info.GetValue("_corporateTag", typeof(EntityCollection<CorporateTagEntity>));
				_corporateUpload = (EntityCollection<CorporateUploadEntity>)info.GetValue("_corporateUpload", typeof(EntityCollection<CorporateUploadEntity>));
				_customEventNotification = (EntityCollection<CustomEventNotificationEntity>)info.GetValue("_customEventNotification", typeof(EntityCollection<CustomEventNotificationEntity>));
				_eligibilityUpload = (EntityCollection<EligibilityUploadEntity>)info.GetValue("_eligibilityUpload", typeof(EntityCollection<EligibilityUploadEntity>));
				_eventAccount = (EntityCollection<EventAccountEntity>)info.GetValue("_eventAccount", typeof(EntityCollection<EventAccountEntity>));
				_eventNote = (EntityCollection<EventNoteEntity>)info.GetValue("_eventNote", typeof(EntityCollection<EventNoteEntity>));
				_fillEventCallQueue = (EntityCollection<FillEventCallQueueEntity>)info.GetValue("_fillEventCallQueue", typeof(EntityCollection<FillEventCallQueueEntity>));
				_healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteria", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_healthPlanRevenue = (EntityCollection<HealthPlanRevenueEntity>)info.GetValue("_healthPlanRevenue", typeof(EntityCollection<HealthPlanRevenueEntity>));
				_languageBarrierCallQueue = (EntityCollection<LanguageBarrierCallQueueEntity>)info.GetValue("_languageBarrierCallQueue", typeof(EntityCollection<LanguageBarrierCallQueueEntity>));
				_mailRoundCallQueue = (EntityCollection<MailRoundCallQueueEntity>)info.GetValue("_mailRoundCallQueue", typeof(EntityCollection<MailRoundCallQueueEntity>));
				_noShowCallQueue = (EntityCollection<NoShowCallQueueEntity>)info.GetValue("_noShowCallQueue", typeof(EntityCollection<NoShowCallQueueEntity>));
				_uncontactedCustomerCallQueue = (EntityCollection<UncontactedCustomerCallQueueEntity>)info.GetValue("_uncontactedCustomerCallQueue", typeof(EntityCollection<UncontactedCustomerCallQueueEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_additionalFieldsCollectionViaAccountAdditionalFields = (EntityCollection<AdditionalFieldsEntity>)info.GetValue("_additionalFieldsCollectionViaAccountAdditionalFields", typeof(EntityCollection<AdditionalFieldsEntity>));
				_callQueueCollectionViaAccountCallQueueSetting = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaAccountCallQueueSetting", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaCalls = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCalls", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaCalls = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCalls", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaNoShowCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaNoShowCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaFillEventCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaFillEventCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaUncontactedCustomerCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaUncontactedCustomerCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaMailRoundCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaMailRoundCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaLanguageBarrierCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaLanguageBarrierCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCallRoundCallQueue = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallRoundCallQueue", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCustomEventNotification = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomEventNotification", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaEligibilityUpload = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaEligibilityUpload", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaEligibilityUpload_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaEligibilityUpload_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaCorporateUpload_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaCorporateUpload_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaCorporateUpload = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaCorporateUpload", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaCorporateUpload__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaCorporateUpload__", typeof(EntityCollection<FileEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCampaign = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCampaign", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaUncontactedCustomerCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaUncontactedCustomerCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaLanguageBarrierCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaLanguageBarrierCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCampaign_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCampaign_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHealthPlanRevenue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHealthPlanRevenue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomEventNotification = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomEventNotification", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaFillEventCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaFillEventCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEligibilityUpload = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEligibilityUpload", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaNoShowCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaNoShowCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCorporateUpload = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCorporateUpload", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaMailRoundCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaMailRoundCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccountCallQueueSetting = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccountCallQueueSetting", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccountHraChatQuestionnaire = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccountHraChatQuestionnaire", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallRoundCallQueue = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallRoundCallQueue", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaAccountCallCenterOrganization", typeof(EntityCollection<OrganizationEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountHraChatQuestionnaire = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountHraChatQuestionnaire", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaFillEventCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaFillEventCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventNote_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventNote_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaNoShowCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaNoShowCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountCallCenterOrganization_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaUncontactedCustomerCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaUncontactedCustomerCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanRevenue_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanRevenue_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanRevenue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanRevenue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaMailRoundCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMailRoundCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaLanguageBarrierCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaLanguageBarrierCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomTag = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomTag", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCorporateTag_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCorporateTag_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCorporateUpload = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCorporateUpload", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCorporateTag = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCorporateTag", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallRoundCallQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallRoundCallQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCalls", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaign_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaign_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaign = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaign", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventNote = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventNote", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEligibilityUpload = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEligibilityUpload", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomEventNotification = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomEventNotification", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaAccountPackage = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaAccountPackage", typeof(EntityCollection<PackageEntity>));
				_podDetailsCollectionViaEventNote = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetailsCollectionViaEventNote", typeof(EntityCollection<PodDetailsEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_stateCollectionViaAccountCheckoutPhoneNumber = (EntityCollection<StateEntity>)info.GetValue("_stateCollectionViaAccountCheckoutPhoneNumber", typeof(EntityCollection<StateEntity>));
				_testCollectionViaAccountPcpResultTestDependency = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaAccountPcpResultTestDependency", typeof(EntityCollection<TestEntity>));
				_testCollectionViaAccountHealthPlanResultTestDependency = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaAccountHealthPlanResultTestDependency", typeof(EntityCollection<TestEntity>));
				_testCollectionViaAccountCustomerResultTestDependency = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaAccountCustomerResultTestDependency", typeof(EntityCollection<TestEntity>));
				_testCollectionViaAccountNotReviewableTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaAccountNotReviewableTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaAccountTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaAccountTest", typeof(EntityCollection<TestEntity>));
				_zipCollectionViaAccountEventZipSubstitute = (EntityCollection<ZipEntity>)info.GetValue("_zipCollectionViaAccountEventZipSubstitute", typeof(EntityCollection<ZipEntity>));
				_checkListTemplate_ = (CheckListTemplateEntity)info.GetValue("_checkListTemplate_", typeof(CheckListTemplateEntity));
				if(_checkListTemplate_!=null)
				{
					_checkListTemplate_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_checkListTemplate = (CheckListTemplateEntity)info.GetValue("_checkListTemplate", typeof(CheckListTemplateEntity));
				if(_checkListTemplate!=null)
				{
					_checkListTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_emailTemplate_ = (EmailTemplateEntity)info.GetValue("_emailTemplate_", typeof(EmailTemplateEntity));
				if(_emailTemplate_!=null)
				{
					_emailTemplate_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_emailTemplate = (EmailTemplateEntity)info.GetValue("_emailTemplate", typeof(EmailTemplateEntity));
				if(_emailTemplate!=null)
				{
					_emailTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_emailTemplate__ = (EmailTemplateEntity)info.GetValue("_emailTemplate__", typeof(EmailTemplateEntity));
				if(_emailTemplate__!=null)
				{
					_emailTemplate__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_emailTemplate___ = (EmailTemplateEntity)info.GetValue("_emailTemplate___", typeof(EmailTemplateEntity));
				if(_emailTemplate___!=null)
				{
					_emailTemplate___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file________ = (FileEntity)info.GetValue("_file________", typeof(FileEntity));
				if(_file________!=null)
				{
					_file________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file_____ = (FileEntity)info.GetValue("_file_____", typeof(FileEntity));
				if(_file_____!=null)
				{
					_file_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file______ = (FileEntity)info.GetValue("_file______", typeof(FileEntity));
				if(_file______!=null)
				{
					_file______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file_______ = (FileEntity)info.GetValue("_file_______", typeof(FileEntity));
				if(_file_______!=null)
				{
					_file_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file____ = (FileEntity)info.GetValue("_file____", typeof(FileEntity));
				if(_file____!=null)
				{
					_file____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file__ = (FileEntity)info.GetValue("_file__", typeof(FileEntity));
				if(_file__!=null)
				{
					_file__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file_ = (FileEntity)info.GetValue("_file_", typeof(FileEntity));
				if(_file_!=null)
				{
					_file_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file = (FileEntity)info.GetValue("_file", typeof(FileEntity));
				if(_file!=null)
				{
					_file.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_file___ = (FileEntity)info.GetValue("_file___", typeof(FileEntity));
				if(_file___!=null)
				{
					_file___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_fluConsentTemplate = (FluConsentTemplateEntity)info.GetValue("_fluConsentTemplate", typeof(FluConsentTemplateEntity));
				if(_fluConsentTemplate!=null)
				{
					_fluConsentTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hafTemplate = (HafTemplateEntity)info.GetValue("_hafTemplate", typeof(HafTemplateEntity));
				if(_hafTemplate!=null)
				{
					_hafTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospects = (ProspectsEntity)info.GetValue("_prospects", typeof(ProspectsEntity));
				if(_prospects!=null)
				{
					_prospects.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_surveyTemplate = (SurveyTemplateEntity)info.GetValue("_surveyTemplate", typeof(SurveyTemplateEntity));
				if(_surveyTemplate!=null)
				{
					_surveyTemplate.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_healthPlanEventZip = (HealthPlanEventZipEntity)info.GetValue("_healthPlanEventZip", typeof(HealthPlanEventZipEntity));
				if(_healthPlanEventZip!=null)
				{
					_healthPlanEventZip.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organization = (OrganizationEntity)info.GetValue("_organization", typeof(OrganizationEntity));
				if(_organization!=null)
				{
					_organization.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((AccountFieldIndex)fieldIndex)
			{
				case AccountFieldIndex.AccountId:
					DesetupSyncOrganization(true, false);
					break;
				case AccountFieldIndex.ConvertedHostId:
					DesetupSyncProspects(true, false);
					break;
				case AccountFieldIndex.FluffLetterFileId:
					DesetupSyncFile____(true, false);
					break;
				case AccountFieldIndex.ClinicalQuestionTemplateId:
					DesetupSyncHafTemplate(true, false);
					break;
				case AccountFieldIndex.SurveyPdfFileId:
					DesetupSyncFile___(true, false);
					break;
				case AccountFieldIndex.PcpLetterPdfFileId:
					DesetupSyncFile__(true, false);
					break;
				case AccountFieldIndex.ResultFormatTypeId:
					DesetupSyncLookup(true, false);
					break;
				case AccountFieldIndex.ParticipantLetterId:
					DesetupSyncFile_(true, false);
					break;
				case AccountFieldIndex.CheckListFileId:
					DesetupSyncFile(true, false);
					break;
				case AccountFieldIndex.ConfirmationSmsTemplateId:
					DesetupSyncEmailTemplate(true, false);
					break;
				case AccountFieldIndex.ReminderSmsTemplateId:
					DesetupSyncEmailTemplate___(true, false);
					break;
				case AccountFieldIndex.CheckListTemplateId:
					DesetupSyncCheckListTemplate_(true, false);
					break;
				case AccountFieldIndex.CallCenterScriptFileId:
					DesetupSyncFile_____(true, false);
					break;
				case AccountFieldIndex.ConfirmationScriptFileId:
					DesetupSyncFile______(true, false);
					break;
				case AccountFieldIndex.InboundCallScriptFileId:
					DesetupSyncFile_______(true, false);
					break;
				case AccountFieldIndex.MemberLetterFileId:
					DesetupSyncFile________(true, false);
					break;
				case AccountFieldIndex.PcpCoverLetterTemplateId:
					DesetupSyncEmailTemplate__(true, false);
					break;
				case AccountFieldIndex.MemberCoverLetterTemplateId:
					DesetupSyncEmailTemplate_(true, false);
					break;
				case AccountFieldIndex.FluConsentTemplateId:
					DesetupSyncFluConsentTemplate(true, false);
					break;
				case AccountFieldIndex.ExitInterviewTemplateId:
					DesetupSyncCheckListTemplate(true, false);
					break;
				case AccountFieldIndex.SurveyTemplateId:
					DesetupSyncSurveyTemplate(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
				
		/// <summary>Gets the inheritance info provider instance of the project this entity instance is located in. </summary>
		/// <returns>ready to use inheritance info provider instance.</returns>
		protected override IInheritanceInfoProvider GetInheritanceInfoProvider()
		{
			return InheritanceInfoProviderSingleton.GetInstance();
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "CheckListTemplate_":
					this.CheckListTemplate_ = (CheckListTemplateEntity)entity;
					break;
				case "CheckListTemplate":
					this.CheckListTemplate = (CheckListTemplateEntity)entity;
					break;
				case "EmailTemplate_":
					this.EmailTemplate_ = (EmailTemplateEntity)entity;
					break;
				case "EmailTemplate":
					this.EmailTemplate = (EmailTemplateEntity)entity;
					break;
				case "EmailTemplate__":
					this.EmailTemplate__ = (EmailTemplateEntity)entity;
					break;
				case "EmailTemplate___":
					this.EmailTemplate___ = (EmailTemplateEntity)entity;
					break;
				case "File________":
					this.File________ = (FileEntity)entity;
					break;
				case "File_____":
					this.File_____ = (FileEntity)entity;
					break;
				case "File______":
					this.File______ = (FileEntity)entity;
					break;
				case "File_______":
					this.File_______ = (FileEntity)entity;
					break;
				case "File____":
					this.File____ = (FileEntity)entity;
					break;
				case "File__":
					this.File__ = (FileEntity)entity;
					break;
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "File___":
					this.File___ = (FileEntity)entity;
					break;
				case "FluConsentTemplate":
					this.FluConsentTemplate = (FluConsentTemplateEntity)entity;
					break;
				case "HafTemplate":
					this.HafTemplate = (HafTemplateEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "Prospects":
					this.Prospects = (ProspectsEntity)entity;
					break;
				case "SurveyTemplate":
					this.SurveyTemplate = (SurveyTemplateEntity)entity;
					break;
				case "AccountAdditionalFields":
					this.AccountAdditionalFields.Add((AccountAdditionalFieldsEntity)entity);
					break;
				case "AccountCallCenterOrganization":
					this.AccountCallCenterOrganization.Add((AccountCallCenterOrganizationEntity)entity);
					break;
				case "AccountCallQueueSetting":
					this.AccountCallQueueSetting.Add((AccountCallQueueSettingEntity)entity);
					break;
				case "AccountCheckoutPhoneNumber":
					this.AccountCheckoutPhoneNumber.Add((AccountCheckoutPhoneNumberEntity)entity);
					break;
				case "AccountCustomerResultTestDependency":
					this.AccountCustomerResultTestDependency.Add((AccountCustomerResultTestDependencyEntity)entity);
					break;
				case "AccountEventZipSubstitute":
					this.AccountEventZipSubstitute.Add((AccountEventZipSubstituteEntity)entity);
					break;
				case "AccountHealthPlanResultTestDependency":
					this.AccountHealthPlanResultTestDependency.Add((AccountHealthPlanResultTestDependencyEntity)entity);
					break;
				case "AccountHraChatQuestionnaire":
					this.AccountHraChatQuestionnaire.Add((AccountHraChatQuestionnaireEntity)entity);
					break;
				case "AccountNotReviewableTest":
					this.AccountNotReviewableTest.Add((AccountNotReviewableTestEntity)entity);
					break;
				case "AccountPackage":
					this.AccountPackage.Add((AccountPackageEntity)entity);
					break;
				case "AccountPcpResultTestDependency":
					this.AccountPcpResultTestDependency.Add((AccountPcpResultTestDependencyEntity)entity);
					break;
				case "AccountTest":
					this.AccountTest.Add((AccountTestEntity)entity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "CallQueueCustomTag":
					this.CallQueueCustomTag.Add((CallQueueCustomTagEntity)entity);
					break;
				case "CallRoundCallQueue":
					this.CallRoundCallQueue.Add((CallRoundCallQueueEntity)entity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)entity);
					break;
				case "Campaign":
					this.Campaign.Add((CampaignEntity)entity);
					break;
				case "CorporateTag":
					this.CorporateTag.Add((CorporateTagEntity)entity);
					break;
				case "CorporateUpload":
					this.CorporateUpload.Add((CorporateUploadEntity)entity);
					break;
				case "CustomEventNotification":
					this.CustomEventNotification.Add((CustomEventNotificationEntity)entity);
					break;
				case "EligibilityUpload":
					this.EligibilityUpload.Add((EligibilityUploadEntity)entity);
					break;
				case "EventAccount":
					this.EventAccount.Add((EventAccountEntity)entity);
					break;
				case "EventNote":
					this.EventNote.Add((EventNoteEntity)entity);
					break;
				case "FillEventCallQueue":
					this.FillEventCallQueue.Add((FillEventCallQueueEntity)entity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)entity);
					break;
				case "HealthPlanRevenue":
					this.HealthPlanRevenue.Add((HealthPlanRevenueEntity)entity);
					break;
				case "LanguageBarrierCallQueue":
					this.LanguageBarrierCallQueue.Add((LanguageBarrierCallQueueEntity)entity);
					break;
				case "MailRoundCallQueue":
					this.MailRoundCallQueue.Add((MailRoundCallQueueEntity)entity);
					break;
				case "NoShowCallQueue":
					this.NoShowCallQueue.Add((NoShowCallQueueEntity)entity);
					break;
				case "UncontactedCustomerCallQueue":
					this.UncontactedCustomerCallQueue.Add((UncontactedCustomerCallQueueEntity)entity);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "AdditionalFieldsCollectionViaAccountAdditionalFields":
					this.AdditionalFieldsCollectionViaAccountAdditionalFields.IsReadOnly = false;
					this.AdditionalFieldsCollectionViaAccountAdditionalFields.Add((AdditionalFieldsEntity)entity);
					this.AdditionalFieldsCollectionViaAccountAdditionalFields.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaAccountCallQueueSetting":
					this.CallQueueCollectionViaAccountCallQueueSetting.IsReadOnly = false;
					this.CallQueueCollectionViaAccountCallQueueSetting.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaAccountCallQueueSetting.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteria":
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCalls":
					this.CallQueueCollectionViaCalls.IsReadOnly = false;
					this.CallQueueCollectionViaCalls.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCalls.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCollectionViaCallQueueCustomer.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.Add((CallQueueCriteriaEntity)entity);
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CampaignCollectionViaHealthPlanCallQueueCriteria":
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.Add((CampaignEntity)entity);
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCalls":
					this.CampaignCollectionViaCalls.IsReadOnly = false;
					this.CampaignCollectionViaCalls.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCalls.IsReadOnly = true;
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CampaignCollectionViaCallQueueCustomer.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaNoShowCallQueue":
					this.CustomerProfileCollectionViaNoShowCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaNoShowCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaNoShowCallQueue.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaFillEventCallQueue":
					this.CustomerProfileCollectionViaFillEventCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaFillEventCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaFillEventCallQueue.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaUncontactedCustomerCallQueue":
					this.CustomerProfileCollectionViaUncontactedCustomerCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaUncontactedCustomerCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaUncontactedCustomerCallQueue.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaMailRoundCallQueue":
					this.CustomerProfileCollectionViaMailRoundCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaMailRoundCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaMailRoundCallQueue.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaLanguageBarrierCallQueue":
					this.CustomerProfileCollectionViaLanguageBarrierCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaLanguageBarrierCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaLanguageBarrierCallQueue.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallRoundCallQueue":
					this.CustomerProfileCollectionViaCallRoundCallQueue.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallRoundCallQueue.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallRoundCallQueue.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventCustomersCollectionViaCallQueueCustomer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomEventNotification":
					this.EventsCollectionViaCustomEventNotification.IsReadOnly = false;
					this.EventsCollectionViaCustomEventNotification.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomEventNotification.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "FileCollectionViaEligibilityUpload":
					this.FileCollectionViaEligibilityUpload.IsReadOnly = false;
					this.FileCollectionViaEligibilityUpload.Add((FileEntity)entity);
					this.FileCollectionViaEligibilityUpload.IsReadOnly = true;
					break;
				case "FileCollectionViaEligibilityUpload_":
					this.FileCollectionViaEligibilityUpload_.IsReadOnly = false;
					this.FileCollectionViaEligibilityUpload_.Add((FileEntity)entity);
					this.FileCollectionViaEligibilityUpload_.IsReadOnly = true;
					break;
				case "FileCollectionViaCorporateUpload_":
					this.FileCollectionViaCorporateUpload_.IsReadOnly = false;
					this.FileCollectionViaCorporateUpload_.Add((FileEntity)entity);
					this.FileCollectionViaCorporateUpload_.IsReadOnly = true;
					break;
				case "FileCollectionViaCorporateUpload":
					this.FileCollectionViaCorporateUpload.IsReadOnly = false;
					this.FileCollectionViaCorporateUpload.Add((FileEntity)entity);
					this.FileCollectionViaCorporateUpload.IsReadOnly = true;
					break;
				case "FileCollectionViaCorporateUpload__":
					this.FileCollectionViaCorporateUpload__.IsReadOnly = false;
					this.FileCollectionViaCorporateUpload__.Add((FileEntity)entity);
					this.FileCollectionViaCorporateUpload__.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LanguageCollectionViaHealthPlanCallQueueCriteria":
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.Add((LanguageEntity)entity);
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "LookupCollectionViaCampaign":
					this.LookupCollectionViaCampaign.IsReadOnly = false;
					this.LookupCollectionViaCampaign.Add((LookupEntity)entity);
					this.LookupCollectionViaCampaign.IsReadOnly = true;
					break;
				case "LookupCollectionViaUncontactedCustomerCallQueue":
					this.LookupCollectionViaUncontactedCustomerCallQueue.IsReadOnly = false;
					this.LookupCollectionViaUncontactedCustomerCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaUncontactedCustomerCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls__":
					this.LookupCollectionViaCalls__.IsReadOnly = false;
					this.LookupCollectionViaCalls__.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls__.IsReadOnly = true;
					break;
				case "LookupCollectionViaLanguageBarrierCallQueue":
					this.LookupCollectionViaLanguageBarrierCallQueue.IsReadOnly = false;
					this.LookupCollectionViaLanguageBarrierCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaLanguageBarrierCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaCampaign_":
					this.LookupCollectionViaCampaign_.IsReadOnly = false;
					this.LookupCollectionViaCampaign_.Add((LookupEntity)entity);
					this.LookupCollectionViaCampaign_.IsReadOnly = true;
					break;
				case "LookupCollectionViaHealthPlanRevenue":
					this.LookupCollectionViaHealthPlanRevenue.IsReadOnly = false;
					this.LookupCollectionViaHealthPlanRevenue.Add((LookupEntity)entity);
					this.LookupCollectionViaHealthPlanRevenue.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomEventNotification":
					this.LookupCollectionViaCustomEventNotification.IsReadOnly = false;
					this.LookupCollectionViaCustomEventNotification.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomEventNotification.IsReadOnly = true;
					break;
				case "LookupCollectionViaFillEventCallQueue":
					this.LookupCollectionViaFillEventCallQueue.IsReadOnly = false;
					this.LookupCollectionViaFillEventCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaFillEventCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaEligibilityUpload":
					this.LookupCollectionViaEligibilityUpload.IsReadOnly = false;
					this.LookupCollectionViaEligibilityUpload.Add((LookupEntity)entity);
					this.LookupCollectionViaEligibilityUpload.IsReadOnly = true;
					break;
				case "LookupCollectionViaNoShowCallQueue":
					this.LookupCollectionViaNoShowCallQueue.IsReadOnly = false;
					this.LookupCollectionViaNoShowCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaNoShowCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaCorporateUpload":
					this.LookupCollectionViaCorporateUpload.IsReadOnly = false;
					this.LookupCollectionViaCorporateUpload.Add((LookupEntity)entity);
					this.LookupCollectionViaCorporateUpload.IsReadOnly = true;
					break;
				case "LookupCollectionViaMailRoundCallQueue":
					this.LookupCollectionViaMailRoundCallQueue.IsReadOnly = false;
					this.LookupCollectionViaMailRoundCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaMailRoundCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccountCallQueueSetting":
					this.LookupCollectionViaAccountCallQueueSetting.IsReadOnly = false;
					this.LookupCollectionViaAccountCallQueueSetting.Add((LookupEntity)entity);
					this.LookupCollectionViaAccountCallQueueSetting.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccountHraChatQuestionnaire":
					this.LookupCollectionViaAccountHraChatQuestionnaire.IsReadOnly = false;
					this.LookupCollectionViaAccountHraChatQuestionnaire.Add((LookupEntity)entity);
					this.LookupCollectionViaAccountHraChatQuestionnaire.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallRoundCallQueue":
					this.LookupCollectionViaCallRoundCallQueue.IsReadOnly = false;
					this.LookupCollectionViaCallRoundCallQueue.Add((LookupEntity)entity);
					this.LookupCollectionViaCallRoundCallQueue.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls_":
					this.LookupCollectionViaCalls_.IsReadOnly = false;
					this.LookupCollectionViaCalls_.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls":
					this.LookupCollectionViaCalls.IsReadOnly = false;
					this.LookupCollectionViaCalls.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationCollectionViaAccountCallCenterOrganization":
					this.OrganizationCollectionViaAccountCallCenterOrganization.IsReadOnly = false;
					this.OrganizationCollectionViaAccountCallCenterOrganization.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaAccountCallCenterOrganization.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire":
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_":
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaFillEventCallQueue":
					this.OrganizationRoleUserCollectionViaFillEventCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaFillEventCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaFillEventCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventNote_":
					this.OrganizationRoleUserCollectionViaEventNote_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventNote_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventNote_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaNoShowCallQueue":
					this.OrganizationRoleUserCollectionViaNoShowCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaNoShowCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaNoShowCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_":
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue":
					this.OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization":
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanRevenue_":
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanRevenue":
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanRevenue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaMailRoundCallQueue":
					this.OrganizationRoleUserCollectionViaMailRoundCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMailRoundCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMailRoundCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaLanguageBarrierCallQueue":
					this.OrganizationRoleUserCollectionViaLanguageBarrierCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaLanguageBarrierCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaLanguageBarrierCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomTag":
					this.OrganizationRoleUserCollectionViaCallQueueCustomTag.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomTag.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomTag.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCorporateTag_":
					this.OrganizationRoleUserCollectionViaCorporateTag_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCorporateTag_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCorporateTag_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCorporateUpload":
					this.OrganizationRoleUserCollectionViaCorporateUpload.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCorporateUpload.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCorporateUpload.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCorporateTag":
					this.OrganizationRoleUserCollectionViaCorporateTag.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCorporateTag.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCorporateTag.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallRoundCallQueue":
					this.OrganizationRoleUserCollectionViaCallRoundCallQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallRoundCallQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallRoundCallQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCalls.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaign_":
					this.OrganizationRoleUserCollectionViaCampaign_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaign_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaign_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaign":
					this.OrganizationRoleUserCollectionViaCampaign.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaign.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaign.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventNote":
					this.OrganizationRoleUserCollectionViaEventNote.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventNote.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventNote.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEligibilityUpload":
					this.OrganizationRoleUserCollectionViaEligibilityUpload.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEligibilityUpload.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEligibilityUpload.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomEventNotification":
					this.OrganizationRoleUserCollectionViaCustomEventNotification.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomEventNotification.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomEventNotification.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "PackageCollectionViaAccountPackage":
					this.PackageCollectionViaAccountPackage.IsReadOnly = false;
					this.PackageCollectionViaAccountPackage.Add((PackageEntity)entity);
					this.PackageCollectionViaAccountPackage.IsReadOnly = true;
					break;
				case "PodDetailsCollectionViaEventNote":
					this.PodDetailsCollectionViaEventNote.IsReadOnly = false;
					this.PodDetailsCollectionViaEventNote.Add((PodDetailsEntity)entity);
					this.PodDetailsCollectionViaEventNote.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "StateCollectionViaAccountCheckoutPhoneNumber":
					this.StateCollectionViaAccountCheckoutPhoneNumber.IsReadOnly = false;
					this.StateCollectionViaAccountCheckoutPhoneNumber.Add((StateEntity)entity);
					this.StateCollectionViaAccountCheckoutPhoneNumber.IsReadOnly = true;
					break;
				case "TestCollectionViaAccountPcpResultTestDependency":
					this.TestCollectionViaAccountPcpResultTestDependency.IsReadOnly = false;
					this.TestCollectionViaAccountPcpResultTestDependency.Add((TestEntity)entity);
					this.TestCollectionViaAccountPcpResultTestDependency.IsReadOnly = true;
					break;
				case "TestCollectionViaAccountHealthPlanResultTestDependency":
					this.TestCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly = false;
					this.TestCollectionViaAccountHealthPlanResultTestDependency.Add((TestEntity)entity);
					this.TestCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly = true;
					break;
				case "TestCollectionViaAccountCustomerResultTestDependency":
					this.TestCollectionViaAccountCustomerResultTestDependency.IsReadOnly = false;
					this.TestCollectionViaAccountCustomerResultTestDependency.Add((TestEntity)entity);
					this.TestCollectionViaAccountCustomerResultTestDependency.IsReadOnly = true;
					break;
				case "TestCollectionViaAccountNotReviewableTest":
					this.TestCollectionViaAccountNotReviewableTest.IsReadOnly = false;
					this.TestCollectionViaAccountNotReviewableTest.Add((TestEntity)entity);
					this.TestCollectionViaAccountNotReviewableTest.IsReadOnly = true;
					break;
				case "TestCollectionViaAccountTest":
					this.TestCollectionViaAccountTest.IsReadOnly = false;
					this.TestCollectionViaAccountTest.Add((TestEntity)entity);
					this.TestCollectionViaAccountTest.IsReadOnly = true;
					break;
				case "ZipCollectionViaAccountEventZipSubstitute":
					this.ZipCollectionViaAccountEventZipSubstitute.IsReadOnly = false;
					this.ZipCollectionViaAccountEventZipSubstitute.Add((ZipEntity)entity);
					this.ZipCollectionViaAccountEventZipSubstitute.IsReadOnly = true;
					break;
				case "HealthPlanEventZip":
					this.HealthPlanEventZip = (HealthPlanEventZipEntity)entity;
					break;
				case "Organization":
					this.Organization = (OrganizationEntity)entity;
					break;
				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return AccountEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "CheckListTemplate_":
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId);
					break;
				case "CheckListTemplate":
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId);
					break;
				case "EmailTemplate_":
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId);
					break;
				case "EmailTemplate":
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId);
					break;
				case "EmailTemplate__":
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId);
					break;
				case "EmailTemplate___":
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId);
					break;
				case "File________":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId);
					break;
				case "File_____":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId);
					break;
				case "File______":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId);
					break;
				case "File_______":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId);
					break;
				case "File____":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId);
					break;
				case "File__":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId);
					break;
				case "File_":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId);
					break;
				case "File":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId);
					break;
				case "File___":
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId);
					break;
				case "FluConsentTemplate":
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId);
					break;
				case "HafTemplate":
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId);
					break;
				case "Lookup":
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId);
					break;
				case "Prospects":
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId);
					break;
				case "SurveyTemplate":
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId);
					break;
				case "AccountAdditionalFields":
					toReturn.Add(AccountEntity.Relations.AccountAdditionalFieldsEntityUsingAccountId);
					break;
				case "AccountCallCenterOrganization":
					toReturn.Add(AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId);
					break;
				case "AccountCallQueueSetting":
					toReturn.Add(AccountEntity.Relations.AccountCallQueueSettingEntityUsingAccountId);
					break;
				case "AccountCheckoutPhoneNumber":
					toReturn.Add(AccountEntity.Relations.AccountCheckoutPhoneNumberEntityUsingAccountId);
					break;
				case "AccountCustomerResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountCustomerResultTestDependencyEntityUsingAccountId);
					break;
				case "AccountEventZipSubstitute":
					toReturn.Add(AccountEntity.Relations.AccountEventZipSubstituteEntityUsingAccountId);
					break;
				case "AccountHealthPlanResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingAccountId);
					break;
				case "AccountHraChatQuestionnaire":
					toReturn.Add(AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId);
					break;
				case "AccountNotReviewableTest":
					toReturn.Add(AccountEntity.Relations.AccountNotReviewableTestEntityUsingAccountId);
					break;
				case "AccountPackage":
					toReturn.Add(AccountEntity.Relations.AccountPackageEntityUsingAccountId);
					break;
				case "AccountPcpResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountPcpResultTestDependencyEntityUsingAccountId);
					break;
				case "AccountTest":
					toReturn.Add(AccountEntity.Relations.AccountTestEntityUsingAccountId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId);
					break;
				case "CallQueueCustomTag":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomTagEntityUsingHealthPlanId);
					break;
				case "CallRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId);
					break;
				case "Calls":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId);
					break;
				case "Campaign":
					toReturn.Add(AccountEntity.Relations.CampaignEntityUsingAccountId);
					break;
				case "CorporateTag":
					toReturn.Add(AccountEntity.Relations.CorporateTagEntityUsingCorporateId);
					break;
				case "CorporateUpload":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId);
					break;
				case "CustomEventNotification":
					toReturn.Add(AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId);
					break;
				case "EligibilityUpload":
					toReturn.Add(AccountEntity.Relations.EligibilityUploadEntityUsingAccountId);
					break;
				case "EventAccount":
					toReturn.Add(AccountEntity.Relations.EventAccountEntityUsingAccountId);
					break;
				case "EventNote":
					toReturn.Add(AccountEntity.Relations.EventNoteEntityUsingHealthPlanId);
					break;
				case "FillEventCallQueue":
					toReturn.Add(AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId);
					break;
				case "HealthPlanCallQueueCriteria":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId);
					break;
				case "HealthPlanRevenue":
					toReturn.Add(AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId);
					break;
				case "LanguageBarrierCallQueue":
					toReturn.Add(AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId);
					break;
				case "MailRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId);
					break;
				case "NoShowCallQueue":
					toReturn.Add(AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId);
					break;
				case "UncontactedCustomerCallQueue":
					toReturn.Add(AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "AdditionalFieldsCollectionViaAccountAdditionalFields":
					toReturn.Add(AccountEntity.Relations.AccountAdditionalFieldsEntityUsingAccountId, "AccountEntity__", "AccountAdditionalFields_", JoinHint.None);
					toReturn.Add(AccountAdditionalFieldsEntity.Relations.AdditionalFieldsEntityUsingAdditionalFieldId, "AccountAdditionalFields_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaAccountCallQueueSetting":
					toReturn.Add(AccountEntity.Relations.AccountCallQueueSettingEntityUsingAccountId, "AccountEntity__", "AccountCallQueueSetting_", JoinHint.None);
					toReturn.Add(AccountCallQueueSettingEntity.Relations.CallQueueEntityUsingCallQueueId, "AccountCallQueueSetting_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId, "AccountEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCalls":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.CallQueueEntityUsingCallQueueId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId, "AccountEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCalls":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.CampaignEntityUsingCampaignId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaNoShowCallQueue":
					toReturn.Add(AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId, "AccountEntity__", "NoShowCallQueue_", JoinHint.None);
					toReturn.Add(NoShowCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "NoShowCallQueue_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaFillEventCallQueue":
					toReturn.Add(AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId, "AccountEntity__", "FillEventCallQueue_", JoinHint.None);
					toReturn.Add(FillEventCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "FillEventCallQueue_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaUncontactedCustomerCallQueue":
					toReturn.Add(AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId, "AccountEntity__", "UncontactedCustomerCallQueue_", JoinHint.None);
					toReturn.Add(UncontactedCustomerCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "UncontactedCustomerCallQueue_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaMailRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "MailRoundCallQueue_", JoinHint.None);
					toReturn.Add(MailRoundCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "MailRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaLanguageBarrierCallQueue":
					toReturn.Add(AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId, "AccountEntity__", "LanguageBarrierCallQueue_", JoinHint.None);
					toReturn.Add(LanguageBarrierCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "LanguageBarrierCallQueue_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "CallRoundCallQueue_", JoinHint.None);
					toReturn.Add(CallRoundCallQueueEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomEventNotification":
					toReturn.Add(AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId, "AccountEntity__", "CustomEventNotification_", JoinHint.None);
					toReturn.Add(CustomEventNotificationEntity.Relations.EventsEntityUsingEventId, "CustomEventNotification_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaEligibilityUpload":
					toReturn.Add(AccountEntity.Relations.EligibilityUploadEntityUsingAccountId, "AccountEntity__", "EligibilityUpload_", JoinHint.None);
					toReturn.Add(EligibilityUploadEntity.Relations.FileEntityUsingFileId, "EligibilityUpload_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaEligibilityUpload_":
					toReturn.Add(AccountEntity.Relations.EligibilityUploadEntityUsingAccountId, "AccountEntity__", "EligibilityUpload_", JoinHint.None);
					toReturn.Add(EligibilityUploadEntity.Relations.FileEntityUsingLogFileId, "EligibilityUpload_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaCorporateUpload_":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId, "AccountEntity__", "CorporateUpload_", JoinHint.None);
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingFileId, "CorporateUpload_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaCorporateUpload":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId, "AccountEntity__", "CorporateUpload_", JoinHint.None);
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingAdjustOrderLogFileId, "CorporateUpload_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaCorporateUpload__":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId, "AccountEntity__", "CorporateUpload_", JoinHint.None);
					toReturn.Add(CorporateUploadEntity.Relations.FileEntityUsingLogFileId, "CorporateUpload_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId, "AccountEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCampaign":
					toReturn.Add(AccountEntity.Relations.CampaignEntityUsingAccountId, "AccountEntity__", "Campaign_", JoinHint.None);
					toReturn.Add(CampaignEntity.Relations.LookupEntityUsingModeId, "Campaign_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaUncontactedCustomerCallQueue":
					toReturn.Add(AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId, "AccountEntity__", "UncontactedCustomerCallQueue_", JoinHint.None);
					toReturn.Add(UncontactedCustomerCallQueueEntity.Relations.LookupEntityUsingStatus, "UncontactedCustomerCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls__":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingProductTypeId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaLanguageBarrierCallQueue":
					toReturn.Add(AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId, "AccountEntity__", "LanguageBarrierCallQueue_", JoinHint.None);
					toReturn.Add(LanguageBarrierCallQueueEntity.Relations.LookupEntityUsingStatus, "LanguageBarrierCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCampaign_":
					toReturn.Add(AccountEntity.Relations.CampaignEntityUsingAccountId, "AccountEntity__", "Campaign_", JoinHint.None);
					toReturn.Add(CampaignEntity.Relations.LookupEntityUsingTypeId, "Campaign_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHealthPlanRevenue":
					toReturn.Add(AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId, "AccountEntity__", "HealthPlanRevenue_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueEntity.Relations.LookupEntityUsingRevenueItemTypeId, "HealthPlanRevenue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomEventNotification":
					toReturn.Add(AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId, "AccountEntity__", "CustomEventNotification_", JoinHint.None);
					toReturn.Add(CustomEventNotificationEntity.Relations.LookupEntityUsingServiceStatus, "CustomEventNotification_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaFillEventCallQueue":
					toReturn.Add(AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId, "AccountEntity__", "FillEventCallQueue_", JoinHint.None);
					toReturn.Add(FillEventCallQueueEntity.Relations.LookupEntityUsingStatus, "FillEventCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEligibilityUpload":
					toReturn.Add(AccountEntity.Relations.EligibilityUploadEntityUsingAccountId, "AccountEntity__", "EligibilityUpload_", JoinHint.None);
					toReturn.Add(EligibilityUploadEntity.Relations.LookupEntityUsingStatusId, "EligibilityUpload_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaNoShowCallQueue":
					toReturn.Add(AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId, "AccountEntity__", "NoShowCallQueue_", JoinHint.None);
					toReturn.Add(NoShowCallQueueEntity.Relations.LookupEntityUsingStatus, "NoShowCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCorporateUpload":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId, "AccountEntity__", "CorporateUpload_", JoinHint.None);
					toReturn.Add(CorporateUploadEntity.Relations.LookupEntityUsingSourceId, "CorporateUpload_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaMailRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "MailRoundCallQueue_", JoinHint.None);
					toReturn.Add(MailRoundCallQueueEntity.Relations.LookupEntityUsingStatus, "MailRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccountCallQueueSetting":
					toReturn.Add(AccountEntity.Relations.AccountCallQueueSettingEntityUsingAccountId, "AccountEntity__", "AccountCallQueueSetting_", JoinHint.None);
					toReturn.Add(AccountCallQueueSettingEntity.Relations.LookupEntityUsingSuppressionTypeId, "AccountCallQueueSetting_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccountHraChatQuestionnaire":
					toReturn.Add(AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId, "AccountEntity__", "AccountHraChatQuestionnaire_", JoinHint.None);
					toReturn.Add(AccountHraChatQuestionnaireEntity.Relations.LookupEntityUsingQuestionnaireType, "AccountHraChatQuestionnaire_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "CallRoundCallQueue_", JoinHint.None);
					toReturn.Add(CallRoundCallQueueEntity.Relations.LookupEntityUsingStatus, "CallRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls_":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingDialerType, "Calls_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationCollectionViaAccountCallCenterOrganization":
					toReturn.Add(AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId, "AccountEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.OrganizationEntityUsingOrganizationId, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId, "AccountEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire":
					toReturn.Add(AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId, "AccountEntity__", "AccountHraChatQuestionnaire_", JoinHint.None);
					toReturn.Add(AccountHraChatQuestionnaireEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "AccountHraChatQuestionnaire_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_":
					toReturn.Add(AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId, "AccountEntity__", "AccountHraChatQuestionnaire_", JoinHint.None);
					toReturn.Add(AccountHraChatQuestionnaireEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "AccountHraChatQuestionnaire_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaFillEventCallQueue":
					toReturn.Add(AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId, "AccountEntity__", "FillEventCallQueue_", JoinHint.None);
					toReturn.Add(FillEventCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "FillEventCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId, "AccountEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventNote_":
					toReturn.Add(AccountEntity.Relations.EventNoteEntityUsingHealthPlanId, "AccountEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaNoShowCallQueue":
					toReturn.Add(AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId, "AccountEntity__", "NoShowCallQueue_", JoinHint.None);
					toReturn.Add(NoShowCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "NoShowCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_":
					toReturn.Add(AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId, "AccountEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue":
					toReturn.Add(AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId, "AccountEntity__", "UncontactedCustomerCallQueue_", JoinHint.None);
					toReturn.Add(UncontactedCustomerCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "UncontactedCustomerCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization":
					toReturn.Add(AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId, "AccountEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanRevenue_":
					toReturn.Add(AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId, "AccountEntity__", "HealthPlanRevenue_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "HealthPlanRevenue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanRevenue":
					toReturn.Add(AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId, "AccountEntity__", "HealthPlanRevenue_", JoinHint.None);
					toReturn.Add(HealthPlanRevenueEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "HealthPlanRevenue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaMailRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "MailRoundCallQueue_", JoinHint.None);
					toReturn.Add(MailRoundCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "MailRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaLanguageBarrierCallQueue":
					toReturn.Add(AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId, "AccountEntity__", "LanguageBarrierCallQueue_", JoinHint.None);
					toReturn.Add(LanguageBarrierCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "LanguageBarrierCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomTag":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomTagEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomTag_", JoinHint.None);
					toReturn.Add(CallQueueCustomTagEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CallQueueCustomTag_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCorporateTag_":
					toReturn.Add(AccountEntity.Relations.CorporateTagEntityUsingCorporateId, "AccountEntity__", "CorporateTag_", JoinHint.None);
					toReturn.Add(CorporateTagEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CorporateTag_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCorporateUpload":
					toReturn.Add(AccountEntity.Relations.CorporateUploadEntityUsingAccountId, "AccountEntity__", "CorporateUpload_", JoinHint.None);
					toReturn.Add(CorporateUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, "CorporateUpload_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCorporateTag":
					toReturn.Add(AccountEntity.Relations.CorporateTagEntityUsingCorporateId, "AccountEntity__", "CorporateTag_", JoinHint.None);
					toReturn.Add(CorporateTagEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CorporateTag_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallRoundCallQueue":
					toReturn.Add(AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId, "AccountEntity__", "CallRoundCallQueue_", JoinHint.None);
					toReturn.Add(CallRoundCallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CallRoundCallQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					toReturn.Add(AccountEntity.Relations.CallsEntityUsingHealthPlanId, "AccountEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaign_":
					toReturn.Add(AccountEntity.Relations.CampaignEntityUsingAccountId, "AccountEntity__", "Campaign_", JoinHint.None);
					toReturn.Add(CampaignEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, "Campaign_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaign":
					toReturn.Add(AccountEntity.Relations.CampaignEntityUsingAccountId, "AccountEntity__", "Campaign_", JoinHint.None);
					toReturn.Add(CampaignEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, "Campaign_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventNote":
					toReturn.Add(AccountEntity.Relations.EventNoteEntityUsingHealthPlanId, "AccountEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEligibilityUpload":
					toReturn.Add(AccountEntity.Relations.EligibilityUploadEntityUsingAccountId, "AccountEntity__", "EligibilityUpload_", JoinHint.None);
					toReturn.Add(EligibilityUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedBy, "EligibilityUpload_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomEventNotification":
					toReturn.Add(AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId, "AccountEntity__", "CustomEventNotification_", JoinHint.None);
					toReturn.Add(CustomEventNotificationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomEventNotification_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaAccountPackage":
					toReturn.Add(AccountEntity.Relations.AccountPackageEntityUsingAccountId, "AccountEntity__", "AccountPackage_", JoinHint.None);
					toReturn.Add(AccountPackageEntity.Relations.PackageEntityUsingPackageId, "AccountPackage_", string.Empty, JoinHint.None);
					break;
				case "PodDetailsCollectionViaEventNote":
					toReturn.Add(AccountEntity.Relations.EventNoteEntityUsingHealthPlanId, "AccountEntity__", "EventNote_", JoinHint.None);
					toReturn.Add(EventNoteEntity.Relations.PodDetailsEntityUsingPodId, "EventNote_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId, "AccountEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "StateCollectionViaAccountCheckoutPhoneNumber":
					toReturn.Add(AccountEntity.Relations.AccountCheckoutPhoneNumberEntityUsingAccountId, "AccountEntity__", "AccountCheckoutPhoneNumber_", JoinHint.None);
					toReturn.Add(AccountCheckoutPhoneNumberEntity.Relations.StateEntityUsingStateId, "AccountCheckoutPhoneNumber_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaAccountPcpResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountPcpResultTestDependencyEntityUsingAccountId, "AccountEntity__", "AccountPcpResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountPcpResultTestDependencyEntity.Relations.TestEntityUsingTestId, "AccountPcpResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaAccountHealthPlanResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingAccountId, "AccountEntity__", "AccountHealthPlanResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountHealthPlanResultTestDependencyEntity.Relations.TestEntityUsingTestId, "AccountHealthPlanResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaAccountCustomerResultTestDependency":
					toReturn.Add(AccountEntity.Relations.AccountCustomerResultTestDependencyEntityUsingAccountId, "AccountEntity__", "AccountCustomerResultTestDependency_", JoinHint.None);
					toReturn.Add(AccountCustomerResultTestDependencyEntity.Relations.TestEntityUsingTestId, "AccountCustomerResultTestDependency_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaAccountNotReviewableTest":
					toReturn.Add(AccountEntity.Relations.AccountNotReviewableTestEntityUsingAccountId, "AccountEntity__", "AccountNotReviewableTest_", JoinHint.None);
					toReturn.Add(AccountNotReviewableTestEntity.Relations.TestEntityUsingTestId, "AccountNotReviewableTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaAccountTest":
					toReturn.Add(AccountEntity.Relations.AccountTestEntityUsingAccountId, "AccountEntity__", "AccountTest_", JoinHint.None);
					toReturn.Add(AccountTestEntity.Relations.TestEntityUsingTestId, "AccountTest_", string.Empty, JoinHint.None);
					break;
				case "ZipCollectionViaAccountEventZipSubstitute":
					toReturn.Add(AccountEntity.Relations.AccountEventZipSubstituteEntityUsingAccountId, "AccountEntity__", "AccountEventZipSubstitute_", JoinHint.None);
					toReturn.Add(AccountEventZipSubstituteEntity.Relations.ZipEntityUsingZipId, "AccountEventZipSubstitute_", string.Empty, JoinHint.None);
					break;
				case "HealthPlanEventZip":
					toReturn.Add(AccountEntity.Relations.HealthPlanEventZipEntityUsingAccountId);
					break;
				case "Organization":
					toReturn.Add(AccountEntity.Relations.OrganizationEntityUsingAccountId);
					break;
				default:

					break;				
			}
			return toReturn;
		}
#if !CF
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));






















				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "CheckListTemplate_":
					SetupSyncCheckListTemplate_(relatedEntity);
					break;
				case "CheckListTemplate":
					SetupSyncCheckListTemplate(relatedEntity);
					break;
				case "EmailTemplate_":
					SetupSyncEmailTemplate_(relatedEntity);
					break;
				case "EmailTemplate":
					SetupSyncEmailTemplate(relatedEntity);
					break;
				case "EmailTemplate__":
					SetupSyncEmailTemplate__(relatedEntity);
					break;
				case "EmailTemplate___":
					SetupSyncEmailTemplate___(relatedEntity);
					break;
				case "File________":
					SetupSyncFile________(relatedEntity);
					break;
				case "File_____":
					SetupSyncFile_____(relatedEntity);
					break;
				case "File______":
					SetupSyncFile______(relatedEntity);
					break;
				case "File_______":
					SetupSyncFile_______(relatedEntity);
					break;
				case "File____":
					SetupSyncFile____(relatedEntity);
					break;
				case "File__":
					SetupSyncFile__(relatedEntity);
					break;
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "File___":
					SetupSyncFile___(relatedEntity);
					break;
				case "FluConsentTemplate":
					SetupSyncFluConsentTemplate(relatedEntity);
					break;
				case "HafTemplate":
					SetupSyncHafTemplate(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "Prospects":
					SetupSyncProspects(relatedEntity);
					break;
				case "SurveyTemplate":
					SetupSyncSurveyTemplate(relatedEntity);
					break;
				case "AccountAdditionalFields":
					this.AccountAdditionalFields.Add((AccountAdditionalFieldsEntity)relatedEntity);
					break;
				case "AccountCallCenterOrganization":
					this.AccountCallCenterOrganization.Add((AccountCallCenterOrganizationEntity)relatedEntity);
					break;
				case "AccountCallQueueSetting":
					this.AccountCallQueueSetting.Add((AccountCallQueueSettingEntity)relatedEntity);
					break;
				case "AccountCheckoutPhoneNumber":
					this.AccountCheckoutPhoneNumber.Add((AccountCheckoutPhoneNumberEntity)relatedEntity);
					break;
				case "AccountCustomerResultTestDependency":
					this.AccountCustomerResultTestDependency.Add((AccountCustomerResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountEventZipSubstitute":
					this.AccountEventZipSubstitute.Add((AccountEventZipSubstituteEntity)relatedEntity);
					break;
				case "AccountHealthPlanResultTestDependency":
					this.AccountHealthPlanResultTestDependency.Add((AccountHealthPlanResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountHraChatQuestionnaire":
					this.AccountHraChatQuestionnaire.Add((AccountHraChatQuestionnaireEntity)relatedEntity);
					break;
				case "AccountNotReviewableTest":
					this.AccountNotReviewableTest.Add((AccountNotReviewableTestEntity)relatedEntity);
					break;
				case "AccountPackage":
					this.AccountPackage.Add((AccountPackageEntity)relatedEntity);
					break;
				case "AccountPcpResultTestDependency":
					this.AccountPcpResultTestDependency.Add((AccountPcpResultTestDependencyEntity)relatedEntity);
					break;
				case "AccountTest":
					this.AccountTest.Add((AccountTestEntity)relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "CallQueueCustomTag":
					this.CallQueueCustomTag.Add((CallQueueCustomTagEntity)relatedEntity);
					break;
				case "CallRoundCallQueue":
					this.CallRoundCallQueue.Add((CallRoundCallQueueEntity)relatedEntity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)relatedEntity);
					break;
				case "Campaign":
					this.Campaign.Add((CampaignEntity)relatedEntity);
					break;
				case "CorporateTag":
					this.CorporateTag.Add((CorporateTagEntity)relatedEntity);
					break;
				case "CorporateUpload":
					this.CorporateUpload.Add((CorporateUploadEntity)relatedEntity);
					break;
				case "CustomEventNotification":
					this.CustomEventNotification.Add((CustomEventNotificationEntity)relatedEntity);
					break;
				case "EligibilityUpload":
					this.EligibilityUpload.Add((EligibilityUploadEntity)relatedEntity);
					break;
				case "EventAccount":
					this.EventAccount.Add((EventAccountEntity)relatedEntity);
					break;
				case "EventNote":
					this.EventNote.Add((EventNoteEntity)relatedEntity);
					break;
				case "FillEventCallQueue":
					this.FillEventCallQueue.Add((FillEventCallQueueEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)relatedEntity);
					break;
				case "HealthPlanRevenue":
					this.HealthPlanRevenue.Add((HealthPlanRevenueEntity)relatedEntity);
					break;
				case "LanguageBarrierCallQueue":
					this.LanguageBarrierCallQueue.Add((LanguageBarrierCallQueueEntity)relatedEntity);
					break;
				case "MailRoundCallQueue":
					this.MailRoundCallQueue.Add((MailRoundCallQueueEntity)relatedEntity);
					break;
				case "NoShowCallQueue":
					this.NoShowCallQueue.Add((NoShowCallQueueEntity)relatedEntity);
					break;
				case "UncontactedCustomerCallQueue":
					this.UncontactedCustomerCallQueue.Add((UncontactedCustomerCallQueueEntity)relatedEntity);
					break;
				case "HealthPlanEventZip":
					SetupSyncHealthPlanEventZip(relatedEntity);
					break;
				case "Organization":
					SetupSyncOrganization(relatedEntity);
					break;
				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "CheckListTemplate_":
					DesetupSyncCheckListTemplate_(false, true);
					break;
				case "CheckListTemplate":
					DesetupSyncCheckListTemplate(false, true);
					break;
				case "EmailTemplate_":
					DesetupSyncEmailTemplate_(false, true);
					break;
				case "EmailTemplate":
					DesetupSyncEmailTemplate(false, true);
					break;
				case "EmailTemplate__":
					DesetupSyncEmailTemplate__(false, true);
					break;
				case "EmailTemplate___":
					DesetupSyncEmailTemplate___(false, true);
					break;
				case "File________":
					DesetupSyncFile________(false, true);
					break;
				case "File_____":
					DesetupSyncFile_____(false, true);
					break;
				case "File______":
					DesetupSyncFile______(false, true);
					break;
				case "File_______":
					DesetupSyncFile_______(false, true);
					break;
				case "File____":
					DesetupSyncFile____(false, true);
					break;
				case "File__":
					DesetupSyncFile__(false, true);
					break;
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "File___":
					DesetupSyncFile___(false, true);
					break;
				case "FluConsentTemplate":
					DesetupSyncFluConsentTemplate(false, true);
					break;
				case "HafTemplate":
					DesetupSyncHafTemplate(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "Prospects":
					DesetupSyncProspects(false, true);
					break;
				case "SurveyTemplate":
					DesetupSyncSurveyTemplate(false, true);
					break;
				case "AccountAdditionalFields":
					base.PerformRelatedEntityRemoval(this.AccountAdditionalFields, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountCallCenterOrganization":
					base.PerformRelatedEntityRemoval(this.AccountCallCenterOrganization, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountCallQueueSetting":
					base.PerformRelatedEntityRemoval(this.AccountCallQueueSetting, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountCheckoutPhoneNumber":
					base.PerformRelatedEntityRemoval(this.AccountCheckoutPhoneNumber, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountCustomerResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountCustomerResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountEventZipSubstitute":
					base.PerformRelatedEntityRemoval(this.AccountEventZipSubstitute, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountHealthPlanResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountHealthPlanResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountHraChatQuestionnaire":
					base.PerformRelatedEntityRemoval(this.AccountHraChatQuestionnaire, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountNotReviewableTest":
					base.PerformRelatedEntityRemoval(this.AccountNotReviewableTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountPackage":
					base.PerformRelatedEntityRemoval(this.AccountPackage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountPcpResultTestDependency":
					base.PerformRelatedEntityRemoval(this.AccountPcpResultTestDependency, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountTest":
					base.PerformRelatedEntityRemoval(this.AccountTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCustomTag":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomTag, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallRoundCallQueue":
					base.PerformRelatedEntityRemoval(this.CallRoundCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Calls":
					base.PerformRelatedEntityRemoval(this.Calls, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Campaign":
					base.PerformRelatedEntityRemoval(this.Campaign, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CorporateTag":
					base.PerformRelatedEntityRemoval(this.CorporateTag, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CorporateUpload":
					base.PerformRelatedEntityRemoval(this.CorporateUpload, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomEventNotification":
					base.PerformRelatedEntityRemoval(this.CustomEventNotification, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EligibilityUpload":
					base.PerformRelatedEntityRemoval(this.EligibilityUpload, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAccount":
					base.PerformRelatedEntityRemoval(this.EventAccount, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventNote":
					base.PerformRelatedEntityRemoval(this.EventNote, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FillEventCallQueue":
					base.PerformRelatedEntityRemoval(this.FillEventCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteria":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanRevenue":
					base.PerformRelatedEntityRemoval(this.HealthPlanRevenue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "LanguageBarrierCallQueue":
					base.PerformRelatedEntityRemoval(this.LanguageBarrierCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MailRoundCallQueue":
					base.PerformRelatedEntityRemoval(this.MailRoundCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NoShowCallQueue":
					base.PerformRelatedEntityRemoval(this.NoShowCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UncontactedCustomerCallQueue":
					base.PerformRelatedEntityRemoval(this.UncontactedCustomerCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanEventZip":
					DesetupSyncHealthPlanEventZip(false, true);
					break;
				case "Organization":
					DesetupSyncOrganization(false, true);
					break;
				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_healthPlanEventZip!=null)
			{
				toReturn.Add(_healthPlanEventZip);
			}



			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_checkListTemplate_!=null)
			{
				toReturn.Add(_checkListTemplate_);
			}
			if(_checkListTemplate!=null)
			{
				toReturn.Add(_checkListTemplate);
			}
			if(_emailTemplate_!=null)
			{
				toReturn.Add(_emailTemplate_);
			}
			if(_emailTemplate!=null)
			{
				toReturn.Add(_emailTemplate);
			}
			if(_emailTemplate__!=null)
			{
				toReturn.Add(_emailTemplate__);
			}
			if(_emailTemplate___!=null)
			{
				toReturn.Add(_emailTemplate___);
			}
			if(_file________!=null)
			{
				toReturn.Add(_file________);
			}
			if(_file_____!=null)
			{
				toReturn.Add(_file_____);
			}
			if(_file______!=null)
			{
				toReturn.Add(_file______);
			}
			if(_file_______!=null)
			{
				toReturn.Add(_file_______);
			}
			if(_file____!=null)
			{
				toReturn.Add(_file____);
			}
			if(_file__!=null)
			{
				toReturn.Add(_file__);
			}
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_file___!=null)
			{
				toReturn.Add(_file___);
			}
			if(_fluConsentTemplate!=null)
			{
				toReturn.Add(_fluConsentTemplate);
			}
			if(_hafTemplate!=null)
			{
				toReturn.Add(_hafTemplate);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_prospects!=null)
			{
				toReturn.Add(_prospects);
			}
			if(_surveyTemplate!=null)
			{
				toReturn.Add(_surveyTemplate);
			}


			if(_organization!=null)
			{
				toReturn.Add(_organization);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountAdditionalFields);
			toReturn.Add(this.AccountCallCenterOrganization);
			toReturn.Add(this.AccountCallQueueSetting);
			toReturn.Add(this.AccountCheckoutPhoneNumber);
			toReturn.Add(this.AccountCustomerResultTestDependency);
			toReturn.Add(this.AccountEventZipSubstitute);
			toReturn.Add(this.AccountHealthPlanResultTestDependency);
			toReturn.Add(this.AccountHraChatQuestionnaire);
			toReturn.Add(this.AccountNotReviewableTest);
			toReturn.Add(this.AccountPackage);
			toReturn.Add(this.AccountPcpResultTestDependency);
			toReturn.Add(this.AccountTest);
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.CallQueueCustomTag);
			toReturn.Add(this.CallRoundCallQueue);
			toReturn.Add(this.Calls);
			toReturn.Add(this.Campaign);
			toReturn.Add(this.CorporateTag);
			toReturn.Add(this.CorporateUpload);
			toReturn.Add(this.CustomEventNotification);
			toReturn.Add(this.EligibilityUpload);
			toReturn.Add(this.EventAccount);
			toReturn.Add(this.EventNote);
			toReturn.Add(this.FillEventCallQueue);
			toReturn.Add(this.HealthPlanCallQueueCriteria);
			toReturn.Add(this.HealthPlanRevenue);
			toReturn.Add(this.LanguageBarrierCallQueue);
			toReturn.Add(this.MailRoundCallQueue);
			toReturn.Add(this.NoShowCallQueue);
			toReturn.Add(this.UncontactedCustomerCallQueue);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_accountAdditionalFields", ((_accountAdditionalFields!=null) && (_accountAdditionalFields.Count>0) && !this.MarkedForDeletion)?_accountAdditionalFields:null);
				info.AddValue("_accountCallCenterOrganization", ((_accountCallCenterOrganization!=null) && (_accountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_accountCallCenterOrganization:null);
				info.AddValue("_accountCallQueueSetting", ((_accountCallQueueSetting!=null) && (_accountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_accountCallQueueSetting:null);
				info.AddValue("_accountCheckoutPhoneNumber", ((_accountCheckoutPhoneNumber!=null) && (_accountCheckoutPhoneNumber.Count>0) && !this.MarkedForDeletion)?_accountCheckoutPhoneNumber:null);
				info.AddValue("_accountCustomerResultTestDependency", ((_accountCustomerResultTestDependency!=null) && (_accountCustomerResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountCustomerResultTestDependency:null);
				info.AddValue("_accountEventZipSubstitute", ((_accountEventZipSubstitute!=null) && (_accountEventZipSubstitute.Count>0) && !this.MarkedForDeletion)?_accountEventZipSubstitute:null);
				info.AddValue("_accountHealthPlanResultTestDependency", ((_accountHealthPlanResultTestDependency!=null) && (_accountHealthPlanResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountHealthPlanResultTestDependency:null);
				info.AddValue("_accountHraChatQuestionnaire", ((_accountHraChatQuestionnaire!=null) && (_accountHraChatQuestionnaire.Count>0) && !this.MarkedForDeletion)?_accountHraChatQuestionnaire:null);
				info.AddValue("_accountNotReviewableTest", ((_accountNotReviewableTest!=null) && (_accountNotReviewableTest.Count>0) && !this.MarkedForDeletion)?_accountNotReviewableTest:null);
				info.AddValue("_accountPackage", ((_accountPackage!=null) && (_accountPackage.Count>0) && !this.MarkedForDeletion)?_accountPackage:null);
				info.AddValue("_accountPcpResultTestDependency", ((_accountPcpResultTestDependency!=null) && (_accountPcpResultTestDependency.Count>0) && !this.MarkedForDeletion)?_accountPcpResultTestDependency:null);
				info.AddValue("_accountTest", ((_accountTest!=null) && (_accountTest.Count>0) && !this.MarkedForDeletion)?_accountTest:null);
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_callQueueCustomTag", ((_callQueueCustomTag!=null) && (_callQueueCustomTag.Count>0) && !this.MarkedForDeletion)?_callQueueCustomTag:null);
				info.AddValue("_callRoundCallQueue", ((_callRoundCallQueue!=null) && (_callRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_callRoundCallQueue:null);
				info.AddValue("_calls", ((_calls!=null) && (_calls.Count>0) && !this.MarkedForDeletion)?_calls:null);
				info.AddValue("_campaign", ((_campaign!=null) && (_campaign.Count>0) && !this.MarkedForDeletion)?_campaign:null);
				info.AddValue("_corporateTag", ((_corporateTag!=null) && (_corporateTag.Count>0) && !this.MarkedForDeletion)?_corporateTag:null);
				info.AddValue("_corporateUpload", ((_corporateUpload!=null) && (_corporateUpload.Count>0) && !this.MarkedForDeletion)?_corporateUpload:null);
				info.AddValue("_customEventNotification", ((_customEventNotification!=null) && (_customEventNotification.Count>0) && !this.MarkedForDeletion)?_customEventNotification:null);
				info.AddValue("_eligibilityUpload", ((_eligibilityUpload!=null) && (_eligibilityUpload.Count>0) && !this.MarkedForDeletion)?_eligibilityUpload:null);
				info.AddValue("_eventAccount", ((_eventAccount!=null) && (_eventAccount.Count>0) && !this.MarkedForDeletion)?_eventAccount:null);
				info.AddValue("_eventNote", ((_eventNote!=null) && (_eventNote.Count>0) && !this.MarkedForDeletion)?_eventNote:null);
				info.AddValue("_fillEventCallQueue", ((_fillEventCallQueue!=null) && (_fillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_fillEventCallQueue:null);
				info.AddValue("_healthPlanCallQueueCriteria", ((_healthPlanCallQueueCriteria!=null) && (_healthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteria:null);
				info.AddValue("_healthPlanRevenue", ((_healthPlanRevenue!=null) && (_healthPlanRevenue.Count>0) && !this.MarkedForDeletion)?_healthPlanRevenue:null);
				info.AddValue("_languageBarrierCallQueue", ((_languageBarrierCallQueue!=null) && (_languageBarrierCallQueue.Count>0) && !this.MarkedForDeletion)?_languageBarrierCallQueue:null);
				info.AddValue("_mailRoundCallQueue", ((_mailRoundCallQueue!=null) && (_mailRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_mailRoundCallQueue:null);
				info.AddValue("_noShowCallQueue", ((_noShowCallQueue!=null) && (_noShowCallQueue.Count>0) && !this.MarkedForDeletion)?_noShowCallQueue:null);
				info.AddValue("_uncontactedCustomerCallQueue", ((_uncontactedCustomerCallQueue!=null) && (_uncontactedCustomerCallQueue.Count>0) && !this.MarkedForDeletion)?_uncontactedCustomerCallQueue:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_additionalFieldsCollectionViaAccountAdditionalFields", ((_additionalFieldsCollectionViaAccountAdditionalFields!=null) && (_additionalFieldsCollectionViaAccountAdditionalFields.Count>0) && !this.MarkedForDeletion)?_additionalFieldsCollectionViaAccountAdditionalFields:null);
				info.AddValue("_callQueueCollectionViaAccountCallQueueSetting", ((_callQueueCollectionViaAccountCallQueueSetting!=null) && (_callQueueCollectionViaAccountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaAccountCallQueueSetting:null);
				info.AddValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", ((_callQueueCollectionViaHealthPlanCallQueueCriteria!=null) && (_callQueueCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_callQueueCollectionViaCalls", ((_callQueueCollectionViaCalls!=null) && (_callQueueCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCalls:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaHealthPlanCallQueueCriteria", ((_campaignCollectionViaHealthPlanCallQueueCriteria!=null) && (_campaignCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_campaignCollectionViaCalls", ((_campaignCollectionViaCalls!=null) && (_campaignCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCalls:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaNoShowCallQueue", ((_customerProfileCollectionViaNoShowCallQueue!=null) && (_customerProfileCollectionViaNoShowCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaNoShowCallQueue:null);
				info.AddValue("_customerProfileCollectionViaFillEventCallQueue", ((_customerProfileCollectionViaFillEventCallQueue!=null) && (_customerProfileCollectionViaFillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaFillEventCallQueue:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaUncontactedCustomerCallQueue", ((_customerProfileCollectionViaUncontactedCustomerCallQueue!=null) && (_customerProfileCollectionViaUncontactedCustomerCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaUncontactedCustomerCallQueue:null);
				info.AddValue("_customerProfileCollectionViaMailRoundCallQueue", ((_customerProfileCollectionViaMailRoundCallQueue!=null) && (_customerProfileCollectionViaMailRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaMailRoundCallQueue:null);
				info.AddValue("_customerProfileCollectionViaLanguageBarrierCallQueue", ((_customerProfileCollectionViaLanguageBarrierCallQueue!=null) && (_customerProfileCollectionViaLanguageBarrierCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaLanguageBarrierCallQueue:null);
				info.AddValue("_customerProfileCollectionViaCallRoundCallQueue", ((_customerProfileCollectionViaCallRoundCallQueue!=null) && (_customerProfileCollectionViaCallRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallRoundCallQueue:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaCustomEventNotification", ((_eventsCollectionViaCustomEventNotification!=null) && (_eventsCollectionViaCustomEventNotification.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomEventNotification:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_fileCollectionViaEligibilityUpload", ((_fileCollectionViaEligibilityUpload!=null) && (_fileCollectionViaEligibilityUpload.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaEligibilityUpload:null);
				info.AddValue("_fileCollectionViaEligibilityUpload_", ((_fileCollectionViaEligibilityUpload_!=null) && (_fileCollectionViaEligibilityUpload_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaEligibilityUpload_:null);
				info.AddValue("_fileCollectionViaCorporateUpload_", ((_fileCollectionViaCorporateUpload_!=null) && (_fileCollectionViaCorporateUpload_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaCorporateUpload_:null);
				info.AddValue("_fileCollectionViaCorporateUpload", ((_fileCollectionViaCorporateUpload!=null) && (_fileCollectionViaCorporateUpload.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaCorporateUpload:null);
				info.AddValue("_fileCollectionViaCorporateUpload__", ((_fileCollectionViaCorporateUpload__!=null) && (_fileCollectionViaCorporateUpload__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaCorporateUpload__:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_languageCollectionViaHealthPlanCallQueueCriteria", ((_languageCollectionViaHealthPlanCallQueueCriteria!=null) && (_languageCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_lookupCollectionViaCampaign", ((_lookupCollectionViaCampaign!=null) && (_lookupCollectionViaCampaign.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCampaign:null);
				info.AddValue("_lookupCollectionViaUncontactedCustomerCallQueue", ((_lookupCollectionViaUncontactedCustomerCallQueue!=null) && (_lookupCollectionViaUncontactedCustomerCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaUncontactedCustomerCallQueue:null);
				info.AddValue("_lookupCollectionViaCalls__", ((_lookupCollectionViaCalls__!=null) && (_lookupCollectionViaCalls__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls__:null);
				info.AddValue("_lookupCollectionViaLanguageBarrierCallQueue", ((_lookupCollectionViaLanguageBarrierCallQueue!=null) && (_lookupCollectionViaLanguageBarrierCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaLanguageBarrierCallQueue:null);
				info.AddValue("_lookupCollectionViaCampaign_", ((_lookupCollectionViaCampaign_!=null) && (_lookupCollectionViaCampaign_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCampaign_:null);
				info.AddValue("_lookupCollectionViaHealthPlanRevenue", ((_lookupCollectionViaHealthPlanRevenue!=null) && (_lookupCollectionViaHealthPlanRevenue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHealthPlanRevenue:null);
				info.AddValue("_lookupCollectionViaCustomEventNotification", ((_lookupCollectionViaCustomEventNotification!=null) && (_lookupCollectionViaCustomEventNotification.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomEventNotification:null);
				info.AddValue("_lookupCollectionViaFillEventCallQueue", ((_lookupCollectionViaFillEventCallQueue!=null) && (_lookupCollectionViaFillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaFillEventCallQueue:null);
				info.AddValue("_lookupCollectionViaEligibilityUpload", ((_lookupCollectionViaEligibilityUpload!=null) && (_lookupCollectionViaEligibilityUpload.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEligibilityUpload:null);
				info.AddValue("_lookupCollectionViaNoShowCallQueue", ((_lookupCollectionViaNoShowCallQueue!=null) && (_lookupCollectionViaNoShowCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaNoShowCallQueue:null);
				info.AddValue("_lookupCollectionViaCorporateUpload", ((_lookupCollectionViaCorporateUpload!=null) && (_lookupCollectionViaCorporateUpload.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCorporateUpload:null);
				info.AddValue("_lookupCollectionViaMailRoundCallQueue", ((_lookupCollectionViaMailRoundCallQueue!=null) && (_lookupCollectionViaMailRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaMailRoundCallQueue:null);
				info.AddValue("_lookupCollectionViaAccountCallQueueSetting", ((_lookupCollectionViaAccountCallQueueSetting!=null) && (_lookupCollectionViaAccountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccountCallQueueSetting:null);
				info.AddValue("_lookupCollectionViaAccountHraChatQuestionnaire", ((_lookupCollectionViaAccountHraChatQuestionnaire!=null) && (_lookupCollectionViaAccountHraChatQuestionnaire.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccountHraChatQuestionnaire:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCallRoundCallQueue", ((_lookupCollectionViaCallRoundCallQueue!=null) && (_lookupCollectionViaCallRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallRoundCallQueue:null);
				info.AddValue("_lookupCollectionViaCalls_", ((_lookupCollectionViaCalls_!=null) && (_lookupCollectionViaCalls_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls_:null);
				info.AddValue("_lookupCollectionViaCalls", ((_lookupCollectionViaCalls!=null) && (_lookupCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationCollectionViaAccountCallCenterOrganization", ((_organizationCollectionViaAccountCallCenterOrganization!=null) && (_organizationCollectionViaAccountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaAccountCallCenterOrganization:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountHraChatQuestionnaire", ((_organizationRoleUserCollectionViaAccountHraChatQuestionnaire!=null) && (_organizationRoleUserCollectionViaAccountHraChatQuestionnaire.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountHraChatQuestionnaire:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_", ((_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_!=null) && (_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_:null);
				info.AddValue("_organizationRoleUserCollectionViaFillEventCallQueue", ((_organizationRoleUserCollectionViaFillEventCallQueue!=null) && (_organizationRoleUserCollectionViaFillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaFillEventCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaEventNote_", ((_organizationRoleUserCollectionViaEventNote_!=null) && (_organizationRoleUserCollectionViaEventNote_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventNote_:null);
				info.AddValue("_organizationRoleUserCollectionViaNoShowCallQueue", ((_organizationRoleUserCollectionViaNoShowCallQueue!=null) && (_organizationRoleUserCollectionViaNoShowCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaNoShowCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization_", ((_organizationRoleUserCollectionViaAccountCallCenterOrganization_!=null) && (_organizationRoleUserCollectionViaAccountCallCenterOrganization_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountCallCenterOrganization_:null);
				info.AddValue("_organizationRoleUserCollectionViaUncontactedCustomerCallQueue", ((_organizationRoleUserCollectionViaUncontactedCustomerCallQueue!=null) && (_organizationRoleUserCollectionViaUncontactedCustomerCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaUncontactedCustomerCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization", ((_organizationRoleUserCollectionViaAccountCallCenterOrganization!=null) && (_organizationRoleUserCollectionViaAccountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountCallCenterOrganization:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanRevenue_", ((_organizationRoleUserCollectionViaHealthPlanRevenue_!=null) && (_organizationRoleUserCollectionViaHealthPlanRevenue_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanRevenue_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanRevenue", ((_organizationRoleUserCollectionViaHealthPlanRevenue!=null) && (_organizationRoleUserCollectionViaHealthPlanRevenue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanRevenue:null);
				info.AddValue("_organizationRoleUserCollectionViaMailRoundCallQueue", ((_organizationRoleUserCollectionViaMailRoundCallQueue!=null) && (_organizationRoleUserCollectionViaMailRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMailRoundCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaLanguageBarrierCallQueue", ((_organizationRoleUserCollectionViaLanguageBarrierCallQueue!=null) && (_organizationRoleUserCollectionViaLanguageBarrierCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaLanguageBarrierCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomTag", ((_organizationRoleUserCollectionViaCallQueueCustomTag!=null) && (_organizationRoleUserCollectionViaCallQueueCustomTag.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomTag:null);
				info.AddValue("_organizationRoleUserCollectionViaCorporateTag_", ((_organizationRoleUserCollectionViaCorporateTag_!=null) && (_organizationRoleUserCollectionViaCorporateTag_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCorporateTag_:null);
				info.AddValue("_organizationRoleUserCollectionViaCorporateUpload", ((_organizationRoleUserCollectionViaCorporateUpload!=null) && (_organizationRoleUserCollectionViaCorporateUpload.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCorporateUpload:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaCorporateTag", ((_organizationRoleUserCollectionViaCorporateTag!=null) && (_organizationRoleUserCollectionViaCorporateTag.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCorporateTag:null);
				info.AddValue("_organizationRoleUserCollectionViaCallRoundCallQueue", ((_organizationRoleUserCollectionViaCallRoundCallQueue!=null) && (_organizationRoleUserCollectionViaCallRoundCallQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallRoundCallQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaCalls", ((_organizationRoleUserCollectionViaCalls!=null) && (_organizationRoleUserCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCalls:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaign_", ((_organizationRoleUserCollectionViaCampaign_!=null) && (_organizationRoleUserCollectionViaCampaign_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaign_:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaign", ((_organizationRoleUserCollectionViaCampaign!=null) && (_organizationRoleUserCollectionViaCampaign.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaign:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaEventNote", ((_organizationRoleUserCollectionViaEventNote!=null) && (_organizationRoleUserCollectionViaEventNote.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventNote:null);
				info.AddValue("_organizationRoleUserCollectionViaEligibilityUpload", ((_organizationRoleUserCollectionViaEligibilityUpload!=null) && (_organizationRoleUserCollectionViaEligibilityUpload.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEligibilityUpload:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomEventNotification", ((_organizationRoleUserCollectionViaCustomEventNotification!=null) && (_organizationRoleUserCollectionViaCustomEventNotification.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomEventNotification:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_packageCollectionViaAccountPackage", ((_packageCollectionViaAccountPackage!=null) && (_packageCollectionViaAccountPackage.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaAccountPackage:null);
				info.AddValue("_podDetailsCollectionViaEventNote", ((_podDetailsCollectionViaEventNote!=null) && (_podDetailsCollectionViaEventNote.Count>0) && !this.MarkedForDeletion)?_podDetailsCollectionViaEventNote:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_stateCollectionViaAccountCheckoutPhoneNumber", ((_stateCollectionViaAccountCheckoutPhoneNumber!=null) && (_stateCollectionViaAccountCheckoutPhoneNumber.Count>0) && !this.MarkedForDeletion)?_stateCollectionViaAccountCheckoutPhoneNumber:null);
				info.AddValue("_testCollectionViaAccountPcpResultTestDependency", ((_testCollectionViaAccountPcpResultTestDependency!=null) && (_testCollectionViaAccountPcpResultTestDependency.Count>0) && !this.MarkedForDeletion)?_testCollectionViaAccountPcpResultTestDependency:null);
				info.AddValue("_testCollectionViaAccountHealthPlanResultTestDependency", ((_testCollectionViaAccountHealthPlanResultTestDependency!=null) && (_testCollectionViaAccountHealthPlanResultTestDependency.Count>0) && !this.MarkedForDeletion)?_testCollectionViaAccountHealthPlanResultTestDependency:null);
				info.AddValue("_testCollectionViaAccountCustomerResultTestDependency", ((_testCollectionViaAccountCustomerResultTestDependency!=null) && (_testCollectionViaAccountCustomerResultTestDependency.Count>0) && !this.MarkedForDeletion)?_testCollectionViaAccountCustomerResultTestDependency:null);
				info.AddValue("_testCollectionViaAccountNotReviewableTest", ((_testCollectionViaAccountNotReviewableTest!=null) && (_testCollectionViaAccountNotReviewableTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaAccountNotReviewableTest:null);
				info.AddValue("_testCollectionViaAccountTest", ((_testCollectionViaAccountTest!=null) && (_testCollectionViaAccountTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaAccountTest:null);
				info.AddValue("_zipCollectionViaAccountEventZipSubstitute", ((_zipCollectionViaAccountEventZipSubstitute!=null) && (_zipCollectionViaAccountEventZipSubstitute.Count>0) && !this.MarkedForDeletion)?_zipCollectionViaAccountEventZipSubstitute:null);
				info.AddValue("_checkListTemplate_", (!this.MarkedForDeletion?_checkListTemplate_:null));
				info.AddValue("_checkListTemplate", (!this.MarkedForDeletion?_checkListTemplate:null));
				info.AddValue("_emailTemplate_", (!this.MarkedForDeletion?_emailTemplate_:null));
				info.AddValue("_emailTemplate", (!this.MarkedForDeletion?_emailTemplate:null));
				info.AddValue("_emailTemplate__", (!this.MarkedForDeletion?_emailTemplate__:null));
				info.AddValue("_emailTemplate___", (!this.MarkedForDeletion?_emailTemplate___:null));
				info.AddValue("_file________", (!this.MarkedForDeletion?_file________:null));
				info.AddValue("_file_____", (!this.MarkedForDeletion?_file_____:null));
				info.AddValue("_file______", (!this.MarkedForDeletion?_file______:null));
				info.AddValue("_file_______", (!this.MarkedForDeletion?_file_______:null));
				info.AddValue("_file____", (!this.MarkedForDeletion?_file____:null));
				info.AddValue("_file__", (!this.MarkedForDeletion?_file__:null));
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_file___", (!this.MarkedForDeletion?_file___:null));
				info.AddValue("_fluConsentTemplate", (!this.MarkedForDeletion?_fluConsentTemplate:null));
				info.AddValue("_hafTemplate", (!this.MarkedForDeletion?_hafTemplate:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_prospects", (!this.MarkedForDeletion?_prospects:null));
				info.AddValue("_surveyTemplate", (!this.MarkedForDeletion?_surveyTemplate:null));
				info.AddValue("_healthPlanEventZip", (!this.MarkedForDeletion?_healthPlanEventZip:null));
				info.AddValue("_organization", (!this.MarkedForDeletion?_organization:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// CorpCode .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCCorpCode()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)AccountFieldIndex.CorpCode], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AccountFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AccountFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AccountRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountAdditionalFields' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountAdditionalFields()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountAdditionalFieldsFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCallCenterOrganization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCallCenterOrganizationFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCallQueueSetting' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCallQueueSettingFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCheckoutPhoneNumber' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCheckoutPhoneNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCheckoutPhoneNumberFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCustomerResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCustomerResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCustomerResultTestDependencyFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountEventZipSubstitute' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountEventZipSubstitute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountEventZipSubstituteFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountHealthPlanResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountHealthPlanResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountHealthPlanResultTestDependencyFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountHraChatQuestionnaire' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountHraChatQuestionnaire()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountHraChatQuestionnaireFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountNotReviewableTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountNotReviewableTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountNotReviewableTestFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountPackage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountPackageFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountPcpResultTestDependency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountPcpResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountPcpResultTestDependencyFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountTestFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomTag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomTag()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomTagFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallRoundCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallRoundCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CorporateTag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateTag()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateTagFields.CorporateId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CorporateUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCorporateUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CorporateUploadFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomEventNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomEventNotificationFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EligibilityUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEligibilityUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EligibilityUploadFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAccount' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventNote' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventNoteFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FillEventCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FillEventCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanRevenue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanRevenue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanRevenueFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LanguageBarrierCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageBarrierCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageBarrierCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MailRoundCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMailRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MailRoundCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NoShowCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoShowCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoShowCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UncontactedCustomerCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUncontactedCustomerCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UncontactedCustomerCallQueueFields.HealthPlanId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AdditionalFields' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAdditionalFieldsCollectionViaAccountAdditionalFields()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AdditionalFieldsCollectionViaAccountAdditionalFields"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaAccountCallQueueSetting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaNoShowCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaNoShowCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaFillEventCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaUncontactedCustomerCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaUncontactedCustomerCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaMailRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaMailRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaLanguageBarrierCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaLanguageBarrierCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomEventNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaEligibilityUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaEligibilityUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaEligibilityUpload_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaEligibilityUpload_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaCorporateUpload_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaCorporateUpload_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaCorporateUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaCorporateUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaCorporateUpload__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaCorporateUpload__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaUncontactedCustomerCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaUncontactedCustomerCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaLanguageBarrierCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaLanguageBarrierCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCampaign_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCampaign_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHealthPlanRevenue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHealthPlanRevenue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomEventNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaFillEventCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEligibilityUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEligibilityUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaNoShowCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaNoShowCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCorporateUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCorporateUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaMailRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaMailRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccountCallQueueSetting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccountHraChatQuestionnaire()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccountHraChatQuestionnaire"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaAccountCallCenterOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountHraChatQuestionnaire()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaFillEventCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventNote_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventNote_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaNoShowCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaNoShowCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountCallCenterOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaUncontactedCustomerCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountCallCenterOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanRevenue_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanRevenue_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanRevenue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanRevenue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMailRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMailRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaLanguageBarrierCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaLanguageBarrierCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomTag()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomTag"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCorporateTag_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCorporateTag_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCorporateUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCorporateUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCorporateTag()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCorporateTag"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallRoundCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallRoundCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaign_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaign_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaign"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventNote"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEligibilityUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEligibilityUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomEventNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomEventNotification"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaAccountPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaAccountPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetailsCollectionViaEventNote()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodDetailsCollectionViaEventNote"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'State' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoStateCollectionViaAccountCheckoutPhoneNumber()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("StateCollectionViaAccountCheckoutPhoneNumber"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaAccountPcpResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaAccountPcpResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaAccountHealthPlanResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaAccountHealthPlanResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaAccountCustomerResultTestDependency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaAccountCustomerResultTestDependency"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaAccountNotReviewableTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaAccountNotReviewableTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaAccountTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaAccountTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Zip' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZipCollectionViaAccountEventZipSubstitute()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ZipCollectionViaAccountEventZipSubstitute"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId, "AccountEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.CheckListTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CheckListTemplateFields.Id, null, ComparisonOperator.Equal, this.ExitInterviewTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplate_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.MemberCoverLetterTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.ConfirmationSmsTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplate__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.PcpCoverLetterTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplate___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EmailTemplateFields.EmailTemplateId, null, ComparisonOperator.Equal, this.ReminderSmsTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.MemberLetterFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.CallCenterScriptFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.ConfirmationScriptFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.InboundCallScriptFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.FluffLetterFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.PcpLetterPdfFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.ParticipantLetterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.CheckListFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.SurveyPdfFileId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FluConsentTemplateFields.Id, null, ComparisonOperator.Equal, this.FluConsentTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.ClinicalQuestionTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ResultFormatTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Prospects' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ConvertedHostId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SurveyTemplateFields.Id, null, ComparisonOperator.Equal, this.SurveyTemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HealthPlanEventZip' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanEventZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanEventZipFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Organization' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AccountEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountAdditionalFields);
			collectionsQueue.Enqueue(this._accountCallCenterOrganization);
			collectionsQueue.Enqueue(this._accountCallQueueSetting);
			collectionsQueue.Enqueue(this._accountCheckoutPhoneNumber);
			collectionsQueue.Enqueue(this._accountCustomerResultTestDependency);
			collectionsQueue.Enqueue(this._accountEventZipSubstitute);
			collectionsQueue.Enqueue(this._accountHealthPlanResultTestDependency);
			collectionsQueue.Enqueue(this._accountHraChatQuestionnaire);
			collectionsQueue.Enqueue(this._accountNotReviewableTest);
			collectionsQueue.Enqueue(this._accountPackage);
			collectionsQueue.Enqueue(this._accountPcpResultTestDependency);
			collectionsQueue.Enqueue(this._accountTest);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCustomTag);
			collectionsQueue.Enqueue(this._callRoundCallQueue);
			collectionsQueue.Enqueue(this._calls);
			collectionsQueue.Enqueue(this._campaign);
			collectionsQueue.Enqueue(this._corporateTag);
			collectionsQueue.Enqueue(this._corporateUpload);
			collectionsQueue.Enqueue(this._customEventNotification);
			collectionsQueue.Enqueue(this._eligibilityUpload);
			collectionsQueue.Enqueue(this._eventAccount);
			collectionsQueue.Enqueue(this._eventNote);
			collectionsQueue.Enqueue(this._fillEventCallQueue);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._healthPlanRevenue);
			collectionsQueue.Enqueue(this._languageBarrierCallQueue);
			collectionsQueue.Enqueue(this._mailRoundCallQueue);
			collectionsQueue.Enqueue(this._noShowCallQueue);
			collectionsQueue.Enqueue(this._uncontactedCustomerCallQueue);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._additionalFieldsCollectionViaAccountAdditionalFields);
			collectionsQueue.Enqueue(this._callQueueCollectionViaAccountCallQueueSetting);
			collectionsQueue.Enqueue(this._callQueueCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCalls);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._campaignCollectionViaCalls);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaNoShowCallQueue);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaFillEventCallQueue);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaUncontactedCustomerCallQueue);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaMailRoundCallQueue);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaLanguageBarrierCallQueue);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallRoundCallQueue);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomEventNotification);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._fileCollectionViaEligibilityUpload);
			collectionsQueue.Enqueue(this._fileCollectionViaEligibilityUpload_);
			collectionsQueue.Enqueue(this._fileCollectionViaCorporateUpload_);
			collectionsQueue.Enqueue(this._fileCollectionViaCorporateUpload);
			collectionsQueue.Enqueue(this._fileCollectionViaCorporateUpload__);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._languageCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._lookupCollectionViaCampaign);
			collectionsQueue.Enqueue(this._lookupCollectionViaUncontactedCustomerCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls__);
			collectionsQueue.Enqueue(this._lookupCollectionViaLanguageBarrierCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaCampaign_);
			collectionsQueue.Enqueue(this._lookupCollectionViaHealthPlanRevenue);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomEventNotification);
			collectionsQueue.Enqueue(this._lookupCollectionViaFillEventCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaEligibilityUpload);
			collectionsQueue.Enqueue(this._lookupCollectionViaNoShowCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaCorporateUpload);
			collectionsQueue.Enqueue(this._lookupCollectionViaMailRoundCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccountCallQueueSetting);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccountHraChatQuestionnaire);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallRoundCallQueue);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationCollectionViaAccountCallCenterOrganization);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaFillEventCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventNote_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaNoShowCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountCallCenterOrganization_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaUncontactedCustomerCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountCallCenterOrganization);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanRevenue_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanRevenue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMailRoundCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaLanguageBarrierCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomTag);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCorporateTag_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCorporateUpload);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCorporateTag);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallRoundCallQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCalls);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaign_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaign);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventNote);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEligibilityUpload);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomEventNotification);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._packageCollectionViaAccountPackage);
			collectionsQueue.Enqueue(this._podDetailsCollectionViaEventNote);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._stateCollectionViaAccountCheckoutPhoneNumber);
			collectionsQueue.Enqueue(this._testCollectionViaAccountPcpResultTestDependency);
			collectionsQueue.Enqueue(this._testCollectionViaAccountHealthPlanResultTestDependency);
			collectionsQueue.Enqueue(this._testCollectionViaAccountCustomerResultTestDependency);
			collectionsQueue.Enqueue(this._testCollectionViaAccountNotReviewableTest);
			collectionsQueue.Enqueue(this._testCollectionViaAccountTest);
			collectionsQueue.Enqueue(this._zipCollectionViaAccountEventZipSubstitute);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountAdditionalFields = (EntityCollection<AccountAdditionalFieldsEntity>) collectionsQueue.Dequeue();
			this._accountCallCenterOrganization = (EntityCollection<AccountCallCenterOrganizationEntity>) collectionsQueue.Dequeue();
			this._accountCallQueueSetting = (EntityCollection<AccountCallQueueSettingEntity>) collectionsQueue.Dequeue();
			this._accountCheckoutPhoneNumber = (EntityCollection<AccountCheckoutPhoneNumberEntity>) collectionsQueue.Dequeue();
			this._accountCustomerResultTestDependency = (EntityCollection<AccountCustomerResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountEventZipSubstitute = (EntityCollection<AccountEventZipSubstituteEntity>) collectionsQueue.Dequeue();
			this._accountHealthPlanResultTestDependency = (EntityCollection<AccountHealthPlanResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountHraChatQuestionnaire = (EntityCollection<AccountHraChatQuestionnaireEntity>) collectionsQueue.Dequeue();
			this._accountNotReviewableTest = (EntityCollection<AccountNotReviewableTestEntity>) collectionsQueue.Dequeue();
			this._accountPackage = (EntityCollection<AccountPackageEntity>) collectionsQueue.Dequeue();
			this._accountPcpResultTestDependency = (EntityCollection<AccountPcpResultTestDependencyEntity>) collectionsQueue.Dequeue();
			this._accountTest = (EntityCollection<AccountTestEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomTag = (EntityCollection<CallQueueCustomTagEntity>) collectionsQueue.Dequeue();
			this._callRoundCallQueue = (EntityCollection<CallRoundCallQueueEntity>) collectionsQueue.Dequeue();
			this._calls = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._campaign = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._corporateTag = (EntityCollection<CorporateTagEntity>) collectionsQueue.Dequeue();
			this._corporateUpload = (EntityCollection<CorporateUploadEntity>) collectionsQueue.Dequeue();
			this._customEventNotification = (EntityCollection<CustomEventNotificationEntity>) collectionsQueue.Dequeue();
			this._eligibilityUpload = (EntityCollection<EligibilityUploadEntity>) collectionsQueue.Dequeue();
			this._eventAccount = (EntityCollection<EventAccountEntity>) collectionsQueue.Dequeue();
			this._eventNote = (EntityCollection<EventNoteEntity>) collectionsQueue.Dequeue();
			this._fillEventCallQueue = (EntityCollection<FillEventCallQueueEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._healthPlanRevenue = (EntityCollection<HealthPlanRevenueEntity>) collectionsQueue.Dequeue();
			this._languageBarrierCallQueue = (EntityCollection<LanguageBarrierCallQueueEntity>) collectionsQueue.Dequeue();
			this._mailRoundCallQueue = (EntityCollection<MailRoundCallQueueEntity>) collectionsQueue.Dequeue();
			this._noShowCallQueue = (EntityCollection<NoShowCallQueueEntity>) collectionsQueue.Dequeue();
			this._uncontactedCustomerCallQueue = (EntityCollection<UncontactedCustomerCallQueueEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._additionalFieldsCollectionViaAccountAdditionalFields = (EntityCollection<AdditionalFieldsEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaAccountCallQueueSetting = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCalls = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCalls = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaNoShowCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaFillEventCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaUncontactedCustomerCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaMailRoundCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaLanguageBarrierCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallRoundCallQueue = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomEventNotification = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaEligibilityUpload = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaEligibilityUpload_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaCorporateUpload_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaCorporateUpload = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaCorporateUpload__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCampaign = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaUncontactedCustomerCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaLanguageBarrierCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCampaign_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHealthPlanRevenue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomEventNotification = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaFillEventCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEligibilityUpload = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaNoShowCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCorporateUpload = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaMailRoundCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccountCallQueueSetting = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccountHraChatQuestionnaire = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallRoundCallQueue = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaFillEventCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventNote_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaNoShowCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountCallCenterOrganization_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaUncontactedCustomerCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanRevenue_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanRevenue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMailRoundCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaLanguageBarrierCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomTag = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCorporateTag_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCorporateUpload = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCorporateTag = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallRoundCallQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaign_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaign = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventNote = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEligibilityUpload = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomEventNotification = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaAccountPackage = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._podDetailsCollectionViaEventNote = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._stateCollectionViaAccountCheckoutPhoneNumber = (EntityCollection<StateEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaAccountPcpResultTestDependency = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaAccountHealthPlanResultTestDependency = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaAccountCustomerResultTestDependency = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaAccountNotReviewableTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaAccountTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._zipCollectionViaAccountEventZipSubstitute = (EntityCollection<ZipEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountAdditionalFields != null)
			{
				return true;
			}
			if (this._accountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._accountCallQueueSetting != null)
			{
				return true;
			}
			if (this._accountCheckoutPhoneNumber != null)
			{
				return true;
			}
			if (this._accountCustomerResultTestDependency != null)
			{
				return true;
			}
			if (this._accountEventZipSubstitute != null)
			{
				return true;
			}
			if (this._accountHealthPlanResultTestDependency != null)
			{
				return true;
			}
			if (this._accountHraChatQuestionnaire != null)
			{
				return true;
			}
			if (this._accountNotReviewableTest != null)
			{
				return true;
			}
			if (this._accountPackage != null)
			{
				return true;
			}
			if (this._accountPcpResultTestDependency != null)
			{
				return true;
			}
			if (this._accountTest != null)
			{
				return true;
			}
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCustomTag != null)
			{
				return true;
			}
			if (this._callRoundCallQueue != null)
			{
				return true;
			}
			if (this._calls != null)
			{
				return true;
			}
			if (this._campaign != null)
			{
				return true;
			}
			if (this._corporateTag != null)
			{
				return true;
			}
			if (this._corporateUpload != null)
			{
				return true;
			}
			if (this._customEventNotification != null)
			{
				return true;
			}
			if (this._eligibilityUpload != null)
			{
				return true;
			}
			if (this._eventAccount != null)
			{
				return true;
			}
			if (this._eventNote != null)
			{
				return true;
			}
			if (this._fillEventCallQueue != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._healthPlanRevenue != null)
			{
				return true;
			}
			if (this._languageBarrierCallQueue != null)
			{
				return true;
			}
			if (this._mailRoundCallQueue != null)
			{
				return true;
			}
			if (this._noShowCallQueue != null)
			{
				return true;
			}
			if (this._uncontactedCustomerCallQueue != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._additionalFieldsCollectionViaAccountAdditionalFields != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaAccountCallQueueSetting != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCalls != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCriteriaCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._campaignCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCalls != null)
			{
				return true;
			}
			if (this._campaignCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaNoShowCallQueue != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaFillEventCallQueue != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaUncontactedCustomerCallQueue != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaMailRoundCallQueue != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaLanguageBarrierCallQueue != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallRoundCallQueue != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomEventNotification != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._fileCollectionViaEligibilityUpload != null)
			{
				return true;
			}
			if (this._fileCollectionViaEligibilityUpload_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaCorporateUpload_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaCorporateUpload != null)
			{
				return true;
			}
			if (this._fileCollectionViaCorporateUpload__ != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._languageCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCampaign != null)
			{
				return true;
			}
			if (this._lookupCollectionViaUncontactedCustomerCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaLanguageBarrierCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCampaign_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHealthPlanRevenue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomEventNotification != null)
			{
				return true;
			}
			if (this._lookupCollectionViaFillEventCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEligibilityUpload != null)
			{
				return true;
			}
			if (this._lookupCollectionViaNoShowCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCorporateUpload != null)
			{
				return true;
			}
			if (this._lookupCollectionViaMailRoundCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccountCallQueueSetting != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccountHraChatQuestionnaire != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallRoundCallQueue != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationCollectionViaAccountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountHraChatQuestionnaire_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaFillEventCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventNote_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaNoShowCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountCallCenterOrganization_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaUncontactedCustomerCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanRevenue_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanRevenue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMailRoundCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaLanguageBarrierCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomTag != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCorporateTag_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCorporateUpload != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCorporateTag != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallRoundCallQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCalls != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaign_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaign != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventNote != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEligibilityUpload != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomEventNotification != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._packageCollectionViaAccountPackage != null)
			{
				return true;
			}
			if (this._podDetailsCollectionViaEventNote != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._stateCollectionViaAccountCheckoutPhoneNumber != null)
			{
				return true;
			}
			if (this._testCollectionViaAccountPcpResultTestDependency != null)
			{
				return true;
			}
			if (this._testCollectionViaAccountHealthPlanResultTestDependency != null)
			{
				return true;
			}
			if (this._testCollectionViaAccountCustomerResultTestDependency != null)
			{
				return true;
			}
			if (this._testCollectionViaAccountNotReviewableTest != null)
			{
				return true;
			}
			if (this._testCollectionViaAccountTest != null)
			{
				return true;
			}
			if (this._zipCollectionViaAccountEventZipSubstitute != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountAdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountAdditionalFieldsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCallCenterOrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallCenterOrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCallQueueSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallQueueSettingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountHraChatQuestionnaireEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHraChatQuestionnaireEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomTagEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CorporateTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateTagEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EligibilityUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AdditionalFieldsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("CheckListTemplate_", _checkListTemplate_);
			toReturn.Add("CheckListTemplate", _checkListTemplate);
			toReturn.Add("EmailTemplate_", _emailTemplate_);
			toReturn.Add("EmailTemplate", _emailTemplate);
			toReturn.Add("EmailTemplate__", _emailTemplate__);
			toReturn.Add("EmailTemplate___", _emailTemplate___);
			toReturn.Add("File________", _file________);
			toReturn.Add("File_____", _file_____);
			toReturn.Add("File______", _file______);
			toReturn.Add("File_______", _file_______);
			toReturn.Add("File____", _file____);
			toReturn.Add("File__", _file__);
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("File___", _file___);
			toReturn.Add("FluConsentTemplate", _fluConsentTemplate);
			toReturn.Add("HafTemplate", _hafTemplate);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("Prospects", _prospects);
			toReturn.Add("SurveyTemplate", _surveyTemplate);
			toReturn.Add("AccountAdditionalFields", _accountAdditionalFields);
			toReturn.Add("AccountCallCenterOrganization", _accountCallCenterOrganization);
			toReturn.Add("AccountCallQueueSetting", _accountCallQueueSetting);
			toReturn.Add("AccountCheckoutPhoneNumber", _accountCheckoutPhoneNumber);
			toReturn.Add("AccountCustomerResultTestDependency", _accountCustomerResultTestDependency);
			toReturn.Add("AccountEventZipSubstitute", _accountEventZipSubstitute);
			toReturn.Add("AccountHealthPlanResultTestDependency", _accountHealthPlanResultTestDependency);
			toReturn.Add("AccountHraChatQuestionnaire", _accountHraChatQuestionnaire);
			toReturn.Add("AccountNotReviewableTest", _accountNotReviewableTest);
			toReturn.Add("AccountPackage", _accountPackage);
			toReturn.Add("AccountPcpResultTestDependency", _accountPcpResultTestDependency);
			toReturn.Add("AccountTest", _accountTest);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("CallQueueCustomTag", _callQueueCustomTag);
			toReturn.Add("CallRoundCallQueue", _callRoundCallQueue);
			toReturn.Add("Calls", _calls);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("CorporateTag", _corporateTag);
			toReturn.Add("CorporateUpload", _corporateUpload);
			toReturn.Add("CustomEventNotification", _customEventNotification);
			toReturn.Add("EligibilityUpload", _eligibilityUpload);
			toReturn.Add("EventAccount", _eventAccount);
			toReturn.Add("EventNote", _eventNote);
			toReturn.Add("FillEventCallQueue", _fillEventCallQueue);
			toReturn.Add("HealthPlanCallQueueCriteria", _healthPlanCallQueueCriteria);
			toReturn.Add("HealthPlanRevenue", _healthPlanRevenue);
			toReturn.Add("LanguageBarrierCallQueue", _languageBarrierCallQueue);
			toReturn.Add("MailRoundCallQueue", _mailRoundCallQueue);
			toReturn.Add("NoShowCallQueue", _noShowCallQueue);
			toReturn.Add("UncontactedCustomerCallQueue", _uncontactedCustomerCallQueue);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("AdditionalFieldsCollectionViaAccountAdditionalFields", _additionalFieldsCollectionViaAccountAdditionalFields);
			toReturn.Add("CallQueueCollectionViaAccountCallQueueSetting", _callQueueCollectionViaAccountCallQueueSetting);
			toReturn.Add("CallQueueCollectionViaHealthPlanCallQueueCriteria", _callQueueCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CallQueueCollectionViaCalls", _callQueueCollectionViaCalls);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaHealthPlanCallQueueCriteria", _campaignCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CampaignCollectionViaCalls", _campaignCollectionViaCalls);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaNoShowCallQueue", _customerProfileCollectionViaNoShowCallQueue);
			toReturn.Add("CustomerProfileCollectionViaFillEventCallQueue", _customerProfileCollectionViaFillEventCallQueue);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaUncontactedCustomerCallQueue", _customerProfileCollectionViaUncontactedCustomerCallQueue);
			toReturn.Add("CustomerProfileCollectionViaMailRoundCallQueue", _customerProfileCollectionViaMailRoundCallQueue);
			toReturn.Add("CustomerProfileCollectionViaLanguageBarrierCallQueue", _customerProfileCollectionViaLanguageBarrierCallQueue);
			toReturn.Add("CustomerProfileCollectionViaCallRoundCallQueue", _customerProfileCollectionViaCallRoundCallQueue);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaCustomEventNotification", _eventsCollectionViaCustomEventNotification);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("FileCollectionViaEligibilityUpload", _fileCollectionViaEligibilityUpload);
			toReturn.Add("FileCollectionViaEligibilityUpload_", _fileCollectionViaEligibilityUpload_);
			toReturn.Add("FileCollectionViaCorporateUpload_", _fileCollectionViaCorporateUpload_);
			toReturn.Add("FileCollectionViaCorporateUpload", _fileCollectionViaCorporateUpload);
			toReturn.Add("FileCollectionViaCorporateUpload__", _fileCollectionViaCorporateUpload__);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LanguageCollectionViaHealthPlanCallQueueCriteria", _languageCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("LookupCollectionViaCampaign", _lookupCollectionViaCampaign);
			toReturn.Add("LookupCollectionViaUncontactedCustomerCallQueue", _lookupCollectionViaUncontactedCustomerCallQueue);
			toReturn.Add("LookupCollectionViaCalls__", _lookupCollectionViaCalls__);
			toReturn.Add("LookupCollectionViaLanguageBarrierCallQueue", _lookupCollectionViaLanguageBarrierCallQueue);
			toReturn.Add("LookupCollectionViaCampaign_", _lookupCollectionViaCampaign_);
			toReturn.Add("LookupCollectionViaHealthPlanRevenue", _lookupCollectionViaHealthPlanRevenue);
			toReturn.Add("LookupCollectionViaCustomEventNotification", _lookupCollectionViaCustomEventNotification);
			toReturn.Add("LookupCollectionViaFillEventCallQueue", _lookupCollectionViaFillEventCallQueue);
			toReturn.Add("LookupCollectionViaEligibilityUpload", _lookupCollectionViaEligibilityUpload);
			toReturn.Add("LookupCollectionViaNoShowCallQueue", _lookupCollectionViaNoShowCallQueue);
			toReturn.Add("LookupCollectionViaCorporateUpload", _lookupCollectionViaCorporateUpload);
			toReturn.Add("LookupCollectionViaMailRoundCallQueue", _lookupCollectionViaMailRoundCallQueue);
			toReturn.Add("LookupCollectionViaAccountCallQueueSetting", _lookupCollectionViaAccountCallQueueSetting);
			toReturn.Add("LookupCollectionViaAccountHraChatQuestionnaire", _lookupCollectionViaAccountHraChatQuestionnaire);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCallRoundCallQueue", _lookupCollectionViaCallRoundCallQueue);
			toReturn.Add("LookupCollectionViaCalls_", _lookupCollectionViaCalls_);
			toReturn.Add("LookupCollectionViaCalls", _lookupCollectionViaCalls);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationCollectionViaAccountCallCenterOrganization", _organizationCollectionViaAccountCallCenterOrganization);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire", _organizationRoleUserCollectionViaAccountHraChatQuestionnaire);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_", _organizationRoleUserCollectionViaAccountHraChatQuestionnaire_);
			toReturn.Add("OrganizationRoleUserCollectionViaFillEventCallQueue", _organizationRoleUserCollectionViaFillEventCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaEventNote_", _organizationRoleUserCollectionViaEventNote_);
			toReturn.Add("OrganizationRoleUserCollectionViaNoShowCallQueue", _organizationRoleUserCollectionViaNoShowCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_", _organizationRoleUserCollectionViaAccountCallCenterOrganization_);
			toReturn.Add("OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue", _organizationRoleUserCollectionViaUncontactedCustomerCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountCallCenterOrganization", _organizationRoleUserCollectionViaAccountCallCenterOrganization);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanRevenue_", _organizationRoleUserCollectionViaHealthPlanRevenue_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanRevenue", _organizationRoleUserCollectionViaHealthPlanRevenue);
			toReturn.Add("OrganizationRoleUserCollectionViaMailRoundCallQueue", _organizationRoleUserCollectionViaMailRoundCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaLanguageBarrierCallQueue", _organizationRoleUserCollectionViaLanguageBarrierCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomTag", _organizationRoleUserCollectionViaCallQueueCustomTag);
			toReturn.Add("OrganizationRoleUserCollectionViaCorporateTag_", _organizationRoleUserCollectionViaCorporateTag_);
			toReturn.Add("OrganizationRoleUserCollectionViaCorporateUpload", _organizationRoleUserCollectionViaCorporateUpload);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaCorporateTag", _organizationRoleUserCollectionViaCorporateTag);
			toReturn.Add("OrganizationRoleUserCollectionViaCallRoundCallQueue", _organizationRoleUserCollectionViaCallRoundCallQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaCalls", _organizationRoleUserCollectionViaCalls);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaign_", _organizationRoleUserCollectionViaCampaign_);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaign", _organizationRoleUserCollectionViaCampaign);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaEventNote", _organizationRoleUserCollectionViaEventNote);
			toReturn.Add("OrganizationRoleUserCollectionViaEligibilityUpload", _organizationRoleUserCollectionViaEligibilityUpload);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomEventNotification", _organizationRoleUserCollectionViaCustomEventNotification);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("PackageCollectionViaAccountPackage", _packageCollectionViaAccountPackage);
			toReturn.Add("PodDetailsCollectionViaEventNote", _podDetailsCollectionViaEventNote);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);
			toReturn.Add("StateCollectionViaAccountCheckoutPhoneNumber", _stateCollectionViaAccountCheckoutPhoneNumber);
			toReturn.Add("TestCollectionViaAccountPcpResultTestDependency", _testCollectionViaAccountPcpResultTestDependency);
			toReturn.Add("TestCollectionViaAccountHealthPlanResultTestDependency", _testCollectionViaAccountHealthPlanResultTestDependency);
			toReturn.Add("TestCollectionViaAccountCustomerResultTestDependency", _testCollectionViaAccountCustomerResultTestDependency);
			toReturn.Add("TestCollectionViaAccountNotReviewableTest", _testCollectionViaAccountNotReviewableTest);
			toReturn.Add("TestCollectionViaAccountTest", _testCollectionViaAccountTest);
			toReturn.Add("ZipCollectionViaAccountEventZipSubstitute", _zipCollectionViaAccountEventZipSubstitute);
			toReturn.Add("HealthPlanEventZip", _healthPlanEventZip);
			toReturn.Add("Organization", _organization);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountAdditionalFields!=null)
			{
				_accountAdditionalFields.ActiveContext = base.ActiveContext;
			}
			if(_accountCallCenterOrganization!=null)
			{
				_accountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_accountCallQueueSetting!=null)
			{
				_accountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_accountCheckoutPhoneNumber!=null)
			{
				_accountCheckoutPhoneNumber.ActiveContext = base.ActiveContext;
			}
			if(_accountCustomerResultTestDependency!=null)
			{
				_accountCustomerResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountEventZipSubstitute!=null)
			{
				_accountEventZipSubstitute.ActiveContext = base.ActiveContext;
			}
			if(_accountHealthPlanResultTestDependency!=null)
			{
				_accountHealthPlanResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountHraChatQuestionnaire!=null)
			{
				_accountHraChatQuestionnaire.ActiveContext = base.ActiveContext;
			}
			if(_accountNotReviewableTest!=null)
			{
				_accountNotReviewableTest.ActiveContext = base.ActiveContext;
			}
			if(_accountPackage!=null)
			{
				_accountPackage.ActiveContext = base.ActiveContext;
			}
			if(_accountPcpResultTestDependency!=null)
			{
				_accountPcpResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_accountTest!=null)
			{
				_accountTest.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomTag!=null)
			{
				_callQueueCustomTag.ActiveContext = base.ActiveContext;
			}
			if(_callRoundCallQueue!=null)
			{
				_callRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_calls!=null)
			{
				_calls.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_corporateTag!=null)
			{
				_corporateTag.ActiveContext = base.ActiveContext;
			}
			if(_corporateUpload!=null)
			{
				_corporateUpload.ActiveContext = base.ActiveContext;
			}
			if(_customEventNotification!=null)
			{
				_customEventNotification.ActiveContext = base.ActiveContext;
			}
			if(_eligibilityUpload!=null)
			{
				_eligibilityUpload.ActiveContext = base.ActiveContext;
			}
			if(_eventAccount!=null)
			{
				_eventAccount.ActiveContext = base.ActiveContext;
			}
			if(_eventNote!=null)
			{
				_eventNote.ActiveContext = base.ActiveContext;
			}
			if(_fillEventCallQueue!=null)
			{
				_fillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteria!=null)
			{
				_healthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanRevenue!=null)
			{
				_healthPlanRevenue.ActiveContext = base.ActiveContext;
			}
			if(_languageBarrierCallQueue!=null)
			{
				_languageBarrierCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_mailRoundCallQueue!=null)
			{
				_mailRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_noShowCallQueue!=null)
			{
				_noShowCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_uncontactedCustomerCallQueue!=null)
			{
				_uncontactedCustomerCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_additionalFieldsCollectionViaAccountAdditionalFields!=null)
			{
				_additionalFieldsCollectionViaAccountAdditionalFields.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaAccountCallQueueSetting!=null)
			{
				_callQueueCollectionViaAccountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_callQueueCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCalls!=null)
			{
				_callQueueCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_campaignCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCalls!=null)
			{
				_campaignCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCallQueueCustomer!=null)
			{
				_campaignCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaNoShowCallQueue!=null)
			{
				_customerProfileCollectionViaNoShowCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaFillEventCallQueue!=null)
			{
				_customerProfileCollectionViaFillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaUncontactedCustomerCallQueue!=null)
			{
				_customerProfileCollectionViaUncontactedCustomerCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaMailRoundCallQueue!=null)
			{
				_customerProfileCollectionViaMailRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaLanguageBarrierCallQueue!=null)
			{
				_customerProfileCollectionViaLanguageBarrierCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallRoundCallQueue!=null)
			{
				_customerProfileCollectionViaCallRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomEventNotification!=null)
			{
				_eventsCollectionViaCustomEventNotification.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaEligibilityUpload!=null)
			{
				_fileCollectionViaEligibilityUpload.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaEligibilityUpload_!=null)
			{
				_fileCollectionViaEligibilityUpload_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaCorporateUpload_!=null)
			{
				_fileCollectionViaCorporateUpload_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaCorporateUpload!=null)
			{
				_fileCollectionViaCorporateUpload.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaCorporateUpload__!=null)
			{
				_fileCollectionViaCorporateUpload__.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_languageCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCampaign!=null)
			{
				_lookupCollectionViaCampaign.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaUncontactedCustomerCallQueue!=null)
			{
				_lookupCollectionViaUncontactedCustomerCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls__!=null)
			{
				_lookupCollectionViaCalls__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaLanguageBarrierCallQueue!=null)
			{
				_lookupCollectionViaLanguageBarrierCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCampaign_!=null)
			{
				_lookupCollectionViaCampaign_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHealthPlanRevenue!=null)
			{
				_lookupCollectionViaHealthPlanRevenue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomEventNotification!=null)
			{
				_lookupCollectionViaCustomEventNotification.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaFillEventCallQueue!=null)
			{
				_lookupCollectionViaFillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEligibilityUpload!=null)
			{
				_lookupCollectionViaEligibilityUpload.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaNoShowCallQueue!=null)
			{
				_lookupCollectionViaNoShowCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCorporateUpload!=null)
			{
				_lookupCollectionViaCorporateUpload.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaMailRoundCallQueue!=null)
			{
				_lookupCollectionViaMailRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccountCallQueueSetting!=null)
			{
				_lookupCollectionViaAccountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccountHraChatQuestionnaire!=null)
			{
				_lookupCollectionViaAccountHraChatQuestionnaire.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallRoundCallQueue!=null)
			{
				_lookupCollectionViaCallRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls_!=null)
			{
				_lookupCollectionViaCalls_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls!=null)
			{
				_lookupCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaAccountCallCenterOrganization!=null)
			{
				_organizationCollectionViaAccountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountHraChatQuestionnaire!=null)
			{
				_organizationRoleUserCollectionViaAccountHraChatQuestionnaire.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_!=null)
			{
				_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaFillEventCallQueue!=null)
			{
				_organizationRoleUserCollectionViaFillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventNote_!=null)
			{
				_organizationRoleUserCollectionViaEventNote_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaNoShowCallQueue!=null)
			{
				_organizationRoleUserCollectionViaNoShowCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountCallCenterOrganization_!=null)
			{
				_organizationRoleUserCollectionViaAccountCallCenterOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaUncontactedCustomerCallQueue!=null)
			{
				_organizationRoleUserCollectionViaUncontactedCustomerCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountCallCenterOrganization!=null)
			{
				_organizationRoleUserCollectionViaAccountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanRevenue_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanRevenue_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanRevenue!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanRevenue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMailRoundCallQueue!=null)
			{
				_organizationRoleUserCollectionViaMailRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaLanguageBarrierCallQueue!=null)
			{
				_organizationRoleUserCollectionViaLanguageBarrierCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomTag!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomTag.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCorporateTag_!=null)
			{
				_organizationRoleUserCollectionViaCorporateTag_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCorporateUpload!=null)
			{
				_organizationRoleUserCollectionViaCorporateUpload.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCorporateTag!=null)
			{
				_organizationRoleUserCollectionViaCorporateTag.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallRoundCallQueue!=null)
			{
				_organizationRoleUserCollectionViaCallRoundCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCalls!=null)
			{
				_organizationRoleUserCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaign_!=null)
			{
				_organizationRoleUserCollectionViaCampaign_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaign!=null)
			{
				_organizationRoleUserCollectionViaCampaign.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventNote!=null)
			{
				_organizationRoleUserCollectionViaEventNote.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEligibilityUpload!=null)
			{
				_organizationRoleUserCollectionViaEligibilityUpload.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomEventNotification!=null)
			{
				_organizationRoleUserCollectionViaCustomEventNotification.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaAccountPackage!=null)
			{
				_packageCollectionViaAccountPackage.ActiveContext = base.ActiveContext;
			}
			if(_podDetailsCollectionViaEventNote!=null)
			{
				_podDetailsCollectionViaEventNote.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_stateCollectionViaAccountCheckoutPhoneNumber!=null)
			{
				_stateCollectionViaAccountCheckoutPhoneNumber.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaAccountPcpResultTestDependency!=null)
			{
				_testCollectionViaAccountPcpResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaAccountHealthPlanResultTestDependency!=null)
			{
				_testCollectionViaAccountHealthPlanResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaAccountCustomerResultTestDependency!=null)
			{
				_testCollectionViaAccountCustomerResultTestDependency.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaAccountNotReviewableTest!=null)
			{
				_testCollectionViaAccountNotReviewableTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaAccountTest!=null)
			{
				_testCollectionViaAccountTest.ActiveContext = base.ActiveContext;
			}
			if(_zipCollectionViaAccountEventZipSubstitute!=null)
			{
				_zipCollectionViaAccountEventZipSubstitute.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplate_!=null)
			{
				_checkListTemplate_.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplate!=null)
			{
				_checkListTemplate.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplate_!=null)
			{
				_emailTemplate_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplate!=null)
			{
				_emailTemplate.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplate__!=null)
			{
				_emailTemplate__.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplate___!=null)
			{
				_emailTemplate___.ActiveContext = base.ActiveContext;
			}
			if(_file________!=null)
			{
				_file________.ActiveContext = base.ActiveContext;
			}
			if(_file_____!=null)
			{
				_file_____.ActiveContext = base.ActiveContext;
			}
			if(_file______!=null)
			{
				_file______.ActiveContext = base.ActiveContext;
			}
			if(_file_______!=null)
			{
				_file_______.ActiveContext = base.ActiveContext;
			}
			if(_file____!=null)
			{
				_file____.ActiveContext = base.ActiveContext;
			}
			if(_file__!=null)
			{
				_file__.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_file___!=null)
			{
				_file___.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplate!=null)
			{
				_fluConsentTemplate.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplate!=null)
			{
				_hafTemplate.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplate!=null)
			{
				_surveyTemplate.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanEventZip!=null)
			{
				_healthPlanEventZip.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountAdditionalFields = null;
			_accountCallCenterOrganization = null;
			_accountCallQueueSetting = null;
			_accountCheckoutPhoneNumber = null;
			_accountCustomerResultTestDependency = null;
			_accountEventZipSubstitute = null;
			_accountHealthPlanResultTestDependency = null;
			_accountHraChatQuestionnaire = null;
			_accountNotReviewableTest = null;
			_accountPackage = null;
			_accountPcpResultTestDependency = null;
			_accountTest = null;
			_callQueueCustomer = null;
			_callQueueCustomTag = null;
			_callRoundCallQueue = null;
			_calls = null;
			_campaign = null;
			_corporateTag = null;
			_corporateUpload = null;
			_customEventNotification = null;
			_eligibilityUpload = null;
			_eventAccount = null;
			_eventNote = null;
			_fillEventCallQueue = null;
			_healthPlanCallQueueCriteria = null;
			_healthPlanRevenue = null;
			_languageBarrierCallQueue = null;
			_mailRoundCallQueue = null;
			_noShowCallQueue = null;
			_uncontactedCustomerCallQueue = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_additionalFieldsCollectionViaAccountAdditionalFields = null;
			_callQueueCollectionViaAccountCallQueueSetting = null;
			_callQueueCollectionViaHealthPlanCallQueueCriteria = null;
			_callQueueCollectionViaCalls = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaHealthPlanCallQueueCriteria = null;
			_campaignCollectionViaCalls = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaNoShowCallQueue = null;
			_customerProfileCollectionViaFillEventCallQueue = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaUncontactedCustomerCallQueue = null;
			_customerProfileCollectionViaMailRoundCallQueue = null;
			_customerProfileCollectionViaLanguageBarrierCallQueue = null;
			_customerProfileCollectionViaCallRoundCallQueue = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaCustomEventNotification = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_fileCollectionViaEligibilityUpload = null;
			_fileCollectionViaEligibilityUpload_ = null;
			_fileCollectionViaCorporateUpload_ = null;
			_fileCollectionViaCorporateUpload = null;
			_fileCollectionViaCorporateUpload__ = null;
			_languageCollectionViaCallQueueCustomer = null;
			_languageCollectionViaHealthPlanCallQueueCriteria = null;
			_lookupCollectionViaCampaign = null;
			_lookupCollectionViaUncontactedCustomerCallQueue = null;
			_lookupCollectionViaCalls__ = null;
			_lookupCollectionViaLanguageBarrierCallQueue = null;
			_lookupCollectionViaCampaign_ = null;
			_lookupCollectionViaHealthPlanRevenue = null;
			_lookupCollectionViaCustomEventNotification = null;
			_lookupCollectionViaFillEventCallQueue = null;
			_lookupCollectionViaEligibilityUpload = null;
			_lookupCollectionViaNoShowCallQueue = null;
			_lookupCollectionViaCorporateUpload = null;
			_lookupCollectionViaMailRoundCallQueue = null;
			_lookupCollectionViaAccountCallQueueSetting = null;
			_lookupCollectionViaAccountHraChatQuestionnaire = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCallRoundCallQueue = null;
			_lookupCollectionViaCalls_ = null;
			_lookupCollectionViaCalls = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_organizationCollectionViaAccountCallCenterOrganization = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = null;
			_organizationRoleUserCollectionViaAccountHraChatQuestionnaire = null;
			_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_ = null;
			_organizationRoleUserCollectionViaFillEventCallQueue = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = null;
			_organizationRoleUserCollectionViaEventNote_ = null;
			_organizationRoleUserCollectionViaNoShowCallQueue = null;
			_organizationRoleUserCollectionViaAccountCallCenterOrganization_ = null;
			_organizationRoleUserCollectionViaUncontactedCustomerCallQueue = null;
			_organizationRoleUserCollectionViaAccountCallCenterOrganization = null;
			_organizationRoleUserCollectionViaHealthPlanRevenue_ = null;
			_organizationRoleUserCollectionViaHealthPlanRevenue = null;
			_organizationRoleUserCollectionViaMailRoundCallQueue = null;
			_organizationRoleUserCollectionViaLanguageBarrierCallQueue = null;
			_organizationRoleUserCollectionViaCallQueueCustomTag = null;
			_organizationRoleUserCollectionViaCorporateTag_ = null;
			_organizationRoleUserCollectionViaCorporateUpload = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaCorporateTag = null;
			_organizationRoleUserCollectionViaCallRoundCallQueue = null;
			_organizationRoleUserCollectionViaCalls = null;
			_organizationRoleUserCollectionViaCampaign_ = null;
			_organizationRoleUserCollectionViaCampaign = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaEventNote = null;
			_organizationRoleUserCollectionViaEligibilityUpload = null;
			_organizationRoleUserCollectionViaCustomEventNotification = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_packageCollectionViaAccountPackage = null;
			_podDetailsCollectionViaEventNote = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_stateCollectionViaAccountCheckoutPhoneNumber = null;
			_testCollectionViaAccountPcpResultTestDependency = null;
			_testCollectionViaAccountHealthPlanResultTestDependency = null;
			_testCollectionViaAccountCustomerResultTestDependency = null;
			_testCollectionViaAccountNotReviewableTest = null;
			_testCollectionViaAccountTest = null;
			_zipCollectionViaAccountEventZipSubstitute = null;
			_checkListTemplate_ = null;
			_checkListTemplate = null;
			_emailTemplate_ = null;
			_emailTemplate = null;
			_emailTemplate__ = null;
			_emailTemplate___ = null;
			_file________ = null;
			_file_____ = null;
			_file______ = null;
			_file_______ = null;
			_file____ = null;
			_file__ = null;
			_file_ = null;
			_file = null;
			_file___ = null;
			_fluConsentTemplate = null;
			_hafTemplate = null;
			_lookup = null;
			_prospects = null;
			_surveyTemplate = null;
			_healthPlanEventZip = null;
			_organization = null;
			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContractNotes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowSponsoredByUrl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Content", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConvertedHostId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CorpCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CorporateWhiteLabeling", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowCobranding", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FluffLetterFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureInsuranceId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InsuranceIdRequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendAppointmentMail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberIdLabel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowOnlineRegistration", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowPreQualifiedTestOnly", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowCustomerPortalLogin", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendResultReadyMail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowBasicBiometricPage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendSurveyMail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentConfirmationMailTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentReminderMailTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultReadyMailTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SurveyMailTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowVerifiedMembersOnly", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Zipcode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateOfBirth", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendResultReadyMailWithFax", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CapturePcpconsent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureAbnstatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowPrePayment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HicnumberRequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratePcpLetterWithDiagnosisCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateCustomerResult", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsCustomerResultsTestDependent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratePcpResult", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckoutPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RecommendPackage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AskPreQualificationQuestion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendWelcomeEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureHaf", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureHafonline", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableImageUpsell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowTechUpdateQualifiedTests", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachQualityAssuranceForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RemoveLongDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateBatchLabel", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachCongitiveClockForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachChronicEvaluationForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachParicipantConsentForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UpsellTest", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AskClinicalQuestions", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClinicalQuestionTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultSelectionBasePackage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SlotBooking", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddImagesForAbnormal", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BookPcpAppointment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NumberOfDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScreeningInfo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PatientWorkSheet", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UseHeaderImage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowHafFooter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CaptureSurvey", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SurveyPdfFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpLetterPdfFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachScannedDoc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ResultFormatTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachUnreadableTest", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachGiftCard", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GiftCardAmount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachEawvPreventionPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateEawvPreventionPlanReport", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateFluPneuConsentForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateBmiReport", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnablePgpEncryption", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PublicKeyFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LockEvent", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GenerateHealthPlanReport", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHealthPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachAttestationForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventLockDaysCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AttachOrderRequisitionForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParticipantLetterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FolderName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckListFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintCheckList", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendEventResultReadyNotification", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowBarrier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintPcpAppointmentForBulkHaf", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintPcpAppointmentForResult", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintAceForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintMipForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AllowRegistrationWithImproperTags", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintMicroalbuminForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintIfobtform", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EnableSms", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaximumSms", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmationSmsTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReminderSmsTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PrintLoincLabData", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CheckListTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsMaxAttemptPerHealthPlan", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MaxAttempt", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MarkPennedBack", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PennedBackText", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowCallCenterScript", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallCenterScriptFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventConfirmationBeforeDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmationBeforeAppointmentMinutes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ConfirmationScriptFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RestrictHealthPlanData", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendPatientDataToAces", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ClientId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendConsentData", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowGiftCertificateOnEod", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WarmTransfer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("InboundCallScriptFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesClientShortName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncludeMemberLetter", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberLetterFileId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PcpCoverLetterTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MemberCoverLetterTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesToHipIntake", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AcesToHipIntakeShortName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FluConsentTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ExitInterviewTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SurveyTemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShowChaperonForm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GeneratePcpLetter", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _checkListTemplate_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListTemplate_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListTemplate_, new PropertyChangedEventHandler( OnCheckListTemplate_PropertyChanged ), "CheckListTemplate_", AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, true, signalRelatedEntity, "Account_", resetFKFields, new int[] { (int)AccountFieldIndex.CheckListTemplateId } );		
			_checkListTemplate_ = null;
		}

		/// <summary> setups the sync logic for member _checkListTemplate_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListTemplate_(IEntity2 relatedEntity)
		{
			if(_checkListTemplate_!=relatedEntity)
			{
				DesetupSyncCheckListTemplate_(true, true);
				_checkListTemplate_ = (CheckListTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListTemplate_, new PropertyChangedEventHandler( OnCheckListTemplate_PropertyChanged ), "CheckListTemplate_", AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListTemplate_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _checkListTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCheckListTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _checkListTemplate, new PropertyChangedEventHandler( OnCheckListTemplatePropertyChanged ), "CheckListTemplate", AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.ExitInterviewTemplateId } );		
			_checkListTemplate = null;
		}

		/// <summary> setups the sync logic for member _checkListTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCheckListTemplate(IEntity2 relatedEntity)
		{
			if(_checkListTemplate!=relatedEntity)
			{
				DesetupSyncCheckListTemplate(true, true);
				_checkListTemplate = (CheckListTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _checkListTemplate, new PropertyChangedEventHandler( OnCheckListTemplatePropertyChanged ), "CheckListTemplate", AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCheckListTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _emailTemplate_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmailTemplate_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _emailTemplate_, new PropertyChangedEventHandler( OnEmailTemplate_PropertyChanged ), "EmailTemplate_", AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, true, signalRelatedEntity, "Account_", resetFKFields, new int[] { (int)AccountFieldIndex.MemberCoverLetterTemplateId } );		
			_emailTemplate_ = null;
		}

		/// <summary> setups the sync logic for member _emailTemplate_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmailTemplate_(IEntity2 relatedEntity)
		{
			if(_emailTemplate_!=relatedEntity)
			{
				DesetupSyncEmailTemplate_(true, true);
				_emailTemplate_ = (EmailTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _emailTemplate_, new PropertyChangedEventHandler( OnEmailTemplate_PropertyChanged ), "EmailTemplate_", AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmailTemplate_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _emailTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmailTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _emailTemplate, new PropertyChangedEventHandler( OnEmailTemplatePropertyChanged ), "EmailTemplate", AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.ConfirmationSmsTemplateId } );		
			_emailTemplate = null;
		}

		/// <summary> setups the sync logic for member _emailTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmailTemplate(IEntity2 relatedEntity)
		{
			if(_emailTemplate!=relatedEntity)
			{
				DesetupSyncEmailTemplate(true, true);
				_emailTemplate = (EmailTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _emailTemplate, new PropertyChangedEventHandler( OnEmailTemplatePropertyChanged ), "EmailTemplate", AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmailTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _emailTemplate__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmailTemplate__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _emailTemplate__, new PropertyChangedEventHandler( OnEmailTemplate__PropertyChanged ), "EmailTemplate__", AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, true, signalRelatedEntity, "Account__", resetFKFields, new int[] { (int)AccountFieldIndex.PcpCoverLetterTemplateId } );		
			_emailTemplate__ = null;
		}

		/// <summary> setups the sync logic for member _emailTemplate__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmailTemplate__(IEntity2 relatedEntity)
		{
			if(_emailTemplate__!=relatedEntity)
			{
				DesetupSyncEmailTemplate__(true, true);
				_emailTemplate__ = (EmailTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _emailTemplate__, new PropertyChangedEventHandler( OnEmailTemplate__PropertyChanged ), "EmailTemplate__", AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmailTemplate__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _emailTemplate___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEmailTemplate___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _emailTemplate___, new PropertyChangedEventHandler( OnEmailTemplate___PropertyChanged ), "EmailTemplate___", AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, true, signalRelatedEntity, "Account___", resetFKFields, new int[] { (int)AccountFieldIndex.ReminderSmsTemplateId } );		
			_emailTemplate___ = null;
		}

		/// <summary> setups the sync logic for member _emailTemplate___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEmailTemplate___(IEntity2 relatedEntity)
		{
			if(_emailTemplate___!=relatedEntity)
			{
				DesetupSyncEmailTemplate___(true, true);
				_emailTemplate___ = (EmailTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _emailTemplate___, new PropertyChangedEventHandler( OnEmailTemplate___PropertyChanged ), "EmailTemplate___", AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEmailTemplate___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file________, new PropertyChangedEventHandler( OnFile________PropertyChanged ), "File________", AccountEntity.Relations.FileEntityUsingMemberLetterFileId, true, signalRelatedEntity, "Account________", resetFKFields, new int[] { (int)AccountFieldIndex.MemberLetterFileId } );		
			_file________ = null;
		}

		/// <summary> setups the sync logic for member _file________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile________(IEntity2 relatedEntity)
		{
			if(_file________!=relatedEntity)
			{
				DesetupSyncFile________(true, true);
				_file________ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file________, new PropertyChangedEventHandler( OnFile________PropertyChanged ), "File________", AccountEntity.Relations.FileEntityUsingMemberLetterFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_____, new PropertyChangedEventHandler( OnFile_____PropertyChanged ), "File_____", AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, true, signalRelatedEntity, "Account_____", resetFKFields, new int[] { (int)AccountFieldIndex.CallCenterScriptFileId } );		
			_file_____ = null;
		}

		/// <summary> setups the sync logic for member _file_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_____(IEntity2 relatedEntity)
		{
			if(_file_____!=relatedEntity)
			{
				DesetupSyncFile_____(true, true);
				_file_____ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_____, new PropertyChangedEventHandler( OnFile_____PropertyChanged ), "File_____", AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file______, new PropertyChangedEventHandler( OnFile______PropertyChanged ), "File______", AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, true, signalRelatedEntity, "Account______", resetFKFields, new int[] { (int)AccountFieldIndex.ConfirmationScriptFileId } );		
			_file______ = null;
		}

		/// <summary> setups the sync logic for member _file______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile______(IEntity2 relatedEntity)
		{
			if(_file______!=relatedEntity)
			{
				DesetupSyncFile______(true, true);
				_file______ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file______, new PropertyChangedEventHandler( OnFile______PropertyChanged ), "File______", AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_______, new PropertyChangedEventHandler( OnFile_______PropertyChanged ), "File_______", AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, true, signalRelatedEntity, "Account_______", resetFKFields, new int[] { (int)AccountFieldIndex.InboundCallScriptFileId } );		
			_file_______ = null;
		}

		/// <summary> setups the sync logic for member _file_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_______(IEntity2 relatedEntity)
		{
			if(_file_______!=relatedEntity)
			{
				DesetupSyncFile_______(true, true);
				_file_______ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_______, new PropertyChangedEventHandler( OnFile_______PropertyChanged ), "File_______", AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file____, new PropertyChangedEventHandler( OnFile____PropertyChanged ), "File____", AccountEntity.Relations.FileEntityUsingFluffLetterFileId, true, signalRelatedEntity, "Account____", resetFKFields, new int[] { (int)AccountFieldIndex.FluffLetterFileId } );		
			_file____ = null;
		}

		/// <summary> setups the sync logic for member _file____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile____(IEntity2 relatedEntity)
		{
			if(_file____!=relatedEntity)
			{
				DesetupSyncFile____(true, true);
				_file____ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file____, new PropertyChangedEventHandler( OnFile____PropertyChanged ), "File____", AccountEntity.Relations.FileEntityUsingFluffLetterFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file__, new PropertyChangedEventHandler( OnFile__PropertyChanged ), "File__", AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, true, signalRelatedEntity, "Account__", resetFKFields, new int[] { (int)AccountFieldIndex.PcpLetterPdfFileId } );		
			_file__ = null;
		}

		/// <summary> setups the sync logic for member _file__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile__(IEntity2 relatedEntity)
		{
			if(_file__!=relatedEntity)
			{
				DesetupSyncFile__(true, true);
				_file__ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file__, new PropertyChangedEventHandler( OnFile__PropertyChanged ), "File__", AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", AccountEntity.Relations.FileEntityUsingParticipantLetterId, true, signalRelatedEntity, "Account_", resetFKFields, new int[] { (int)AccountFieldIndex.ParticipantLetterId } );		
			_file_ = null;
		}

		/// <summary> setups the sync logic for member _file_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile_(IEntity2 relatedEntity)
		{
			if(_file_!=relatedEntity)
			{
				DesetupSyncFile_(true, true);
				_file_ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", AccountEntity.Relations.FileEntityUsingParticipantLetterId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", AccountEntity.Relations.FileEntityUsingCheckListFileId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.CheckListFileId } );		
			_file = null;
		}

		/// <summary> setups the sync logic for member _file</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile(IEntity2 relatedEntity)
		{
			if(_file!=relatedEntity)
			{
				DesetupSyncFile(true, true);
				_file = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", AccountEntity.Relations.FileEntityUsingCheckListFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _file___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFile___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _file___, new PropertyChangedEventHandler( OnFile___PropertyChanged ), "File___", AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, true, signalRelatedEntity, "Account___", resetFKFields, new int[] { (int)AccountFieldIndex.SurveyPdfFileId } );		
			_file___ = null;
		}

		/// <summary> setups the sync logic for member _file___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFile___(IEntity2 relatedEntity)
		{
			if(_file___!=relatedEntity)
			{
				DesetupSyncFile___(true, true);
				_file___ = (FileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _file___, new PropertyChangedEventHandler( OnFile___PropertyChanged ), "File___", AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFile___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _fluConsentTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFluConsentTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _fluConsentTemplate, new PropertyChangedEventHandler( OnFluConsentTemplatePropertyChanged ), "FluConsentTemplate", AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.FluConsentTemplateId } );		
			_fluConsentTemplate = null;
		}

		/// <summary> setups the sync logic for member _fluConsentTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFluConsentTemplate(IEntity2 relatedEntity)
		{
			if(_fluConsentTemplate!=relatedEntity)
			{
				DesetupSyncFluConsentTemplate(true, true);
				_fluConsentTemplate = (FluConsentTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _fluConsentTemplate, new PropertyChangedEventHandler( OnFluConsentTemplatePropertyChanged ), "FluConsentTemplate", AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFluConsentTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hafTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHafTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.ClinicalQuestionTemplateId } );		
			_hafTemplate = null;
		}

		/// <summary> setups the sync logic for member _hafTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHafTemplate(IEntity2 relatedEntity)
		{
			if(_hafTemplate!=relatedEntity)
			{
				DesetupSyncHafTemplate(true, true);
				_hafTemplate = (HafTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hafTemplate, new PropertyChangedEventHandler( OnHafTemplatePropertyChanged ), "HafTemplate", AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHafTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.ResultFormatTypeId } );		
			_lookup = null;
		}

		/// <summary> setups the sync logic for member _lookup</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup(IEntity2 relatedEntity)
		{
			if(_lookup!=relatedEntity)
			{
				DesetupSyncLookup(true, true);
				_lookup = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookupPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _prospects</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspects(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.ConvertedHostId } );		
			_prospects = null;
		}

		/// <summary> setups the sync logic for member _prospects</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspects(IEntity2 relatedEntity)
		{
			if(_prospects!=relatedEntity)
			{
				DesetupSyncProspects(true, true);
				_prospects = (ProspectsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospects, new PropertyChangedEventHandler( OnProspectsPropertyChanged ), "Prospects", AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _surveyTemplate</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSurveyTemplate(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _surveyTemplate, new PropertyChangedEventHandler( OnSurveyTemplatePropertyChanged ), "SurveyTemplate", AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, true, signalRelatedEntity, "Account", resetFKFields, new int[] { (int)AccountFieldIndex.SurveyTemplateId } );		
			_surveyTemplate = null;
		}

		/// <summary> setups the sync logic for member _surveyTemplate</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSurveyTemplate(IEntity2 relatedEntity)
		{
			if(_surveyTemplate!=relatedEntity)
			{
				DesetupSyncSurveyTemplate(true, true);
				_surveyTemplate = (SurveyTemplateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _surveyTemplate, new PropertyChangedEventHandler( OnSurveyTemplatePropertyChanged ), "SurveyTemplate", AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSurveyTemplatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _healthPlanEventZip</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHealthPlanEventZip(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _healthPlanEventZip, new PropertyChangedEventHandler( OnHealthPlanEventZipPropertyChanged ), "HealthPlanEventZip", AccountEntity.Relations.HealthPlanEventZipEntityUsingAccountId, false, signalRelatedEntity, "Account", false, new int[] { (int)AccountFieldIndex.AccountId } );
			_healthPlanEventZip = null;
		}
		
		/// <summary> setups the sync logic for member _healthPlanEventZip</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHealthPlanEventZip(IEntity2 relatedEntity)
		{
			if(_healthPlanEventZip!=relatedEntity)
			{
				DesetupSyncHealthPlanEventZip(true, true);
				_healthPlanEventZip = (HealthPlanEventZipEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _healthPlanEventZip, new PropertyChangedEventHandler( OnHealthPlanEventZipPropertyChanged ), "HealthPlanEventZip", AccountEntity.Relations.HealthPlanEventZipEntityUsingAccountId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHealthPlanEventZipPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organization</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganization(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", AccountEntity.Relations.OrganizationEntityUsingAccountId, true, signalRelatedEntity, "Account", false, new int[] { (int)AccountFieldIndex.AccountId } );
			_organization = null;
		}
		
		/// <summary> setups the sync logic for member _organization</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganization(IEntity2 relatedEntity)
		{
			if(_organization!=relatedEntity)
			{
				DesetupSyncOrganization(true, true);
				_organization = (OrganizationEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organization, new PropertyChangedEventHandler( OnOrganizationPropertyChanged ), "Organization", AccountEntity.Relations.OrganizationEntityUsingAccountId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AccountEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static AccountRelations Relations
		{
			get	{ return new AccountRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountAdditionalFields' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountAdditionalFields
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountAdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountAdditionalFieldsEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountAdditionalFields")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountAdditionalFieldsEntity, 0, null, null, null, null, "AccountAdditionalFields", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCallCenterOrganization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCallCenterOrganization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCallCenterOrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallCenterOrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCallCenterOrganization")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountCallCenterOrganizationEntity, 0, null, null, null, null, "AccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCallQueueSetting' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCallQueueSetting
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCallQueueSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallQueueSettingEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCallQueueSetting")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountCallQueueSettingEntity, 0, null, null, null, null, "AccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCheckoutPhoneNumber' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCheckoutPhoneNumber
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCheckoutPhoneNumber")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountCheckoutPhoneNumberEntity, 0, null, null, null, null, "AccountCheckoutPhoneNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCustomerResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCustomerResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCustomerResultTestDependency")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountCustomerResultTestDependencyEntity, 0, null, null, null, null, "AccountCustomerResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountEventZipSubstitute' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountEventZipSubstitute
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountEventZipSubstitute")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountEventZipSubstituteEntity, 0, null, null, null, null, "AccountEventZipSubstitute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountHealthPlanResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountHealthPlanResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountHealthPlanResultTestDependency")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountHealthPlanResultTestDependencyEntity, 0, null, null, null, null, "AccountHealthPlanResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountHraChatQuestionnaire' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountHraChatQuestionnaire
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountHraChatQuestionnaireEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHraChatQuestionnaireEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountHraChatQuestionnaire")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountHraChatQuestionnaireEntity, 0, null, null, null, null, "AccountHraChatQuestionnaire", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountNotReviewableTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountNotReviewableTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountNotReviewableTest")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountNotReviewableTestEntity, 0, null, null, null, null, "AccountNotReviewableTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountPackage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountPackage")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountPackageEntity, 0, null, null, null, null, "AccountPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountPcpResultTestDependency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountPcpResultTestDependency
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountPcpResultTestDependency")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountPcpResultTestDependencyEntity, 0, null, null, null, null, "AccountPcpResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountTest")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AccountTestEntity, 0, null, null, null, null, "AccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomTag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomTag
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomTagEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomTag")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueCustomTagEntity, 0, null, null, null, null, "CallQueueCustomTag", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallRoundCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallRoundCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallRoundCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, 0, null, null, null, null, "CallRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCalls
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Calls")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, null, null, "Calls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateTag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateTag
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CorporateTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateTagEntityFactory))),
					(IEntityRelation)GetRelationsForField("CorporateTag")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CorporateTagEntity, 0, null, null, null, null, "CorporateTag", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CorporateUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCorporateUpload
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("CorporateUpload")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CorporateUploadEntity, 0, null, null, null, null, "CorporateUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomEventNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomEventNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomEventNotification")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomEventNotificationEntity, 0, null, null, null, null, "CustomEventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EligibilityUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEligibilityUpload
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EligibilityUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("EligibilityUpload")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EligibilityUploadEntity, 0, null, null, null, null, "EligibilityUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAccount' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAccount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAccount")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EventAccountEntity, 0, null, null, null, null, "EventAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventNote' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventNote
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventNote")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EventNoteEntity, 0, null, null, null, null, "EventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FillEventCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFillEventCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("FillEventCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FillEventCallQueueEntity, 0, null, null, null, null, "FillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteria
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteria")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanRevenue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanRevenue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanRevenue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.HealthPlanRevenueEntity, 0, null, null, null, null, "HealthPlanRevenue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LanguageBarrierCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageBarrierCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("LanguageBarrierCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LanguageBarrierCallQueueEntity, 0, null, null, null, null, "LanguageBarrierCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MailRoundCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMailRoundCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("MailRoundCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.MailRoundCallQueueEntity, 0, null, null, null, null, "MailRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NoShowCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoShowCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("NoShowCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.NoShowCallQueueEntity, 0, null, null, null, null, "NoShowCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UncontactedCustomerCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUncontactedCustomerCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("UncontactedCustomerCallQueue")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.UncontactedCustomerCallQueueEntity, 0, null, null, null, null, "UncontactedCustomerCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AdditionalFields' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAdditionalFieldsCollectionViaAccountAdditionalFields
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountAdditionalFieldsEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountAdditionalFields_");
				return new PrefetchPathElement2(new EntityCollection<AdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AdditionalFieldsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.AdditionalFieldsEntity, 0, null, null, GetRelationsForField("AdditionalFieldsCollectionViaAccountAdditionalFields"), null, "AdditionalFieldsCollectionViaAccountAdditionalFields", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaAccountCallQueueSetting
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCallQueueSettingEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallQueueSetting_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaAccountCallQueueSetting"), null, "CallQueueCollectionViaAccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaHealthPlanCallQueueCriteria"), null, "CallQueueCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCalls"), null, "CallQueueCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaHealthPlanCallQueueCriteria"), null, "CampaignCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCalls"), null, "CampaignCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaNoShowCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "NoShowCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaNoShowCallQueue"), null, "CustomerProfileCollectionViaNoShowCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaFillEventCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "FillEventCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaFillEventCallQueue"), null, "CustomerProfileCollectionViaFillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "UncontactedCustomerCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaUncontactedCustomerCallQueue"), null, "CustomerProfileCollectionViaUncontactedCustomerCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaMailRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "MailRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaMailRoundCallQueue"), null, "CustomerProfileCollectionViaMailRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "LanguageBarrierCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaLanguageBarrierCallQueue"), null, "CustomerProfileCollectionViaLanguageBarrierCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallRoundCallQueue"), null, "CustomerProfileCollectionViaCallRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomEventNotification
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CustomEventNotification_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomEventNotification"), null, "EventsCollectionViaCustomEventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaEligibilityUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EligibilityUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EligibilityUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaEligibilityUpload"), null, "FileCollectionViaEligibilityUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaEligibilityUpload_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EligibilityUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EligibilityUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaEligibilityUpload_"), null, "FileCollectionViaEligibilityUpload_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaCorporateUpload_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CorporateUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaCorporateUpload_"), null, "FileCollectionViaCorporateUpload_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaCorporateUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CorporateUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaCorporateUpload"), null, "FileCollectionViaCorporateUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaCorporateUpload__
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CorporateUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaCorporateUpload__"), null, "FileCollectionViaCorporateUpload__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaHealthPlanCallQueueCriteria"), null, "LanguageCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CampaignEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "Campaign_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCampaign"), null, "LookupCollectionViaCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "UncontactedCustomerCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaUncontactedCustomerCallQueue"), null, "LookupCollectionViaUncontactedCustomerCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls__
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls__"), null, "LookupCollectionViaCalls__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "LanguageBarrierCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaLanguageBarrierCallQueue"), null, "LookupCollectionViaLanguageBarrierCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCampaign_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CampaignEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "Campaign_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCampaign_"), null, "LookupCollectionViaCampaign_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHealthPlanRevenue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHealthPlanRevenue"), null, "LookupCollectionViaHealthPlanRevenue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomEventNotification
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CustomEventNotification_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomEventNotification"), null, "LookupCollectionViaCustomEventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaFillEventCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "FillEventCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaFillEventCallQueue"), null, "LookupCollectionViaFillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEligibilityUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EligibilityUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EligibilityUpload_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEligibilityUpload"), null, "LookupCollectionViaEligibilityUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaNoShowCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "NoShowCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaNoShowCallQueue"), null, "LookupCollectionViaNoShowCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCorporateUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CorporateUpload_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCorporateUpload"), null, "LookupCollectionViaCorporateUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaMailRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "MailRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaMailRoundCallQueue"), null, "LookupCollectionViaMailRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccountCallQueueSetting
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCallQueueSettingEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallQueueSetting_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccountCallQueueSetting"), null, "LookupCollectionViaAccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccountHraChatQuestionnaire
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountHraChatQuestionnaire_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccountHraChatQuestionnaire"), null, "LookupCollectionViaAccountHraChatQuestionnaire", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallRoundCallQueue"), null, "LookupCollectionViaCallRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls_"), null, "LookupCollectionViaCalls_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls"), null, "LookupCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaAccountCallCenterOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaAccountCallCenterOrganization"), null, "OrganizationCollectionViaAccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountHraChatQuestionnaire
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountHraChatQuestionnaire_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire"), null, "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountHraChatQuestionnaireEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountHraChatQuestionnaire_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_"), null, "OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaFillEventCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.FillEventCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "FillEventCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaFillEventCallQueue"), null, "OrganizationRoleUserCollectionViaFillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventNote_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EventNoteEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventNote_"), null, "OrganizationRoleUserCollectionViaEventNote_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaNoShowCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.NoShowCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "NoShowCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaNoShowCallQueue"), null, "OrganizationRoleUserCollectionViaNoShowCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountCallCenterOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_"), null, "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.UncontactedCustomerCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "UncontactedCustomerCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue"), null, "OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountCallCenterOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCallCenterOrganizationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountCallCenterOrganization"), null, "OrganizationRoleUserCollectionViaAccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanRevenue_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanRevenue_"), null, "OrganizationRoleUserCollectionViaHealthPlanRevenue_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanRevenue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.HealthPlanRevenueEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanRevenue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanRevenue"), null, "OrganizationRoleUserCollectionViaHealthPlanRevenue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMailRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.MailRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "MailRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMailRoundCallQueue"), null, "OrganizationRoleUserCollectionViaMailRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.LanguageBarrierCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "LanguageBarrierCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaLanguageBarrierCallQueue"), null, "OrganizationRoleUserCollectionViaLanguageBarrierCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomTag
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomTagEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomTag_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomTag"), null, "OrganizationRoleUserCollectionViaCallQueueCustomTag", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCorporateTag_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateTagEntityUsingCorporateId;
				intermediateRelation.SetAliases(string.Empty, "CorporateTag_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCorporateTag_"), null, "OrganizationRoleUserCollectionViaCorporateTag_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCorporateUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CorporateUpload_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCorporateUpload"), null, "OrganizationRoleUserCollectionViaCorporateUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCorporateTag
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CorporateTagEntityUsingCorporateId;
				intermediateRelation.SetAliases(string.Empty, "CorporateTag_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCorporateTag"), null, "OrganizationRoleUserCollectionViaCorporateTag", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallRoundCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallRoundCallQueueEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallRoundCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallRoundCallQueue"), null, "OrganizationRoleUserCollectionViaCallRoundCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallsEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCalls"), null, "OrganizationRoleUserCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaign_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CampaignEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "Campaign_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaign_"), null, "OrganizationRoleUserCollectionViaCampaign_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaign
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CampaignEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "Campaign_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaign"), null, "OrganizationRoleUserCollectionViaCampaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventNote
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EventNoteEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventNote"), null, "OrganizationRoleUserCollectionViaEventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEligibilityUpload
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EligibilityUploadEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EligibilityUpload_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEligibilityUpload"), null, "OrganizationRoleUserCollectionViaEligibilityUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomEventNotification
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CustomEventNotificationEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "CustomEventNotification_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomEventNotification"), null, "OrganizationRoleUserCollectionViaCustomEventNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaAccountPackage
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountPackageEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountPackage_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaAccountPackage"), null, "PackageCollectionViaAccountPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetailsCollectionViaEventNote
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.EventNoteEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "EventNote_");
				return new PrefetchPathElement2(new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, GetRelationsForField("PodDetailsCollectionViaEventNote"), null, "PodDetailsCollectionViaEventNote", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.CallQueueCustomerEntityUsingHealthPlanId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathStateCollectionViaAccountCheckoutPhoneNumber
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCheckoutPhoneNumberEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCheckoutPhoneNumber_");
				return new PrefetchPathElement2(new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, GetRelationsForField("StateCollectionViaAccountCheckoutPhoneNumber"), null, "StateCollectionViaAccountCheckoutPhoneNumber", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaAccountPcpResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountPcpResultTestDependencyEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountPcpResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaAccountPcpResultTestDependency"), null, "TestCollectionViaAccountPcpResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaAccountHealthPlanResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountHealthPlanResultTestDependencyEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountHealthPlanResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaAccountHealthPlanResultTestDependency"), null, "TestCollectionViaAccountHealthPlanResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaAccountCustomerResultTestDependency
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountCustomerResultTestDependencyEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountCustomerResultTestDependency_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaAccountCustomerResultTestDependency"), null, "TestCollectionViaAccountCustomerResultTestDependency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaAccountNotReviewableTest
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountNotReviewableTestEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountNotReviewableTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaAccountNotReviewableTest"), null, "TestCollectionViaAccountNotReviewableTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaAccountTest
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountTestEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaAccountTest"), null, "TestCollectionViaAccountTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Zip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZipCollectionViaAccountEventZipSubstitute
		{
			get
			{
				IEntityRelation intermediateRelation = AccountEntity.Relations.AccountEventZipSubstituteEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountEventZipSubstitute_");
				return new PrefetchPathElement2(new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.ZipEntity, 0, null, null, GetRelationsForField("ZipCollectionViaAccountEventZipSubstitute"), null, "ZipCollectionViaAccountEventZipSubstitute", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplate_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListTemplate_")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, null, null, "CheckListTemplate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("CheckListTemplate")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, null, null, "CheckListTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplate_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplate_")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, null, null, "EmailTemplate_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplate")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, null, null, "EmailTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplate__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplate__")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, null, null, "EmailTemplate__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplate___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("EmailTemplate___")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, null, null, "EmailTemplate___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File________")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_____")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File______")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_______")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File____")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File__")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFile___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))),
					(IEntityRelation)GetRelationsForField("File___")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("FluConsentTemplate")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, null, null, "FluConsentTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplate")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, null, null, "HafTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplate
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("SurveyTemplate")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, null, null, "SurveyTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanEventZip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanEventZip
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanEventZipEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanEventZip")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.HealthPlanEventZipEntity, 0, null, null, null, null, "HealthPlanEventZip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.AccountEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AccountEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return AccountEntity.FieldsCustomProperties;}
		}

		/// <summary> The AccountId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AccountID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, false</remarks>
		public virtual System.Int64 AccountId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.AccountId, true); }
			set	{ SetValue((int)AccountFieldIndex.AccountId, value); }
		}

		/// <summary> The ContractNotes property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ContractNotes"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ContractNotes
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.ContractNotes, true); }
			set	{ SetValue((int)AccountFieldIndex.ContractNotes, value); }
		}

		/// <summary> The ShowSponsoredByUrl property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowSponsoredByUrl"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowSponsoredByUrl
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowSponsoredByUrl, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowSponsoredByUrl, value); }
		}

		/// <summary> The Content property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."Content"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Content
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.Content, true); }
			set	{ SetValue((int)AccountFieldIndex.Content, value); }
		}

		/// <summary> The ConvertedHostId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ConvertedHostId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ConvertedHostId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.ConvertedHostId, false); }
			set	{ SetValue((int)AccountFieldIndex.ConvertedHostId, value); }
		}

		/// <summary> The CorpCode property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CorpCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CorpCode
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.CorpCode, true); }
			set	{ SetValue((int)AccountFieldIndex.CorpCode, value); }
		}

		/// <summary> The CorporateWhiteLabeling property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CorporateWhiteLabeling"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CorporateWhiteLabeling
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CorporateWhiteLabeling, true); }
			set	{ SetValue((int)AccountFieldIndex.CorporateWhiteLabeling, value); }
		}

		/// <summary> The AllowCobranding property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowCobranding"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowCobranding
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowCobranding, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowCobranding, value); }
		}

		/// <summary> The FluffLetterFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."FluffLetterFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FluffLetterFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.FluffLetterFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.FluffLetterFileId, value); }
		}

		/// <summary> The CaptureInsuranceId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CaptureInsuranceId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureInsuranceId
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CaptureInsuranceId, true); }
			set	{ SetValue((int)AccountFieldIndex.CaptureInsuranceId, value); }
		}

		/// <summary> The InsuranceIdRequired property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."InsuranceIdRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean InsuranceIdRequired
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.InsuranceIdRequired, true); }
			set	{ SetValue((int)AccountFieldIndex.InsuranceIdRequired, value); }
		}

		/// <summary> The SendAppointmentMail property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendAppointmentMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendAppointmentMail
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendAppointmentMail, true); }
			set	{ SetValue((int)AccountFieldIndex.SendAppointmentMail, value); }
		}

		/// <summary> The Tag property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."Tag"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Tag
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.Tag, true); }
			set	{ SetValue((int)AccountFieldIndex.Tag, value); }
		}

		/// <summary> The MemberIdLabel property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MemberIdLabel"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MemberIdLabel
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.MemberIdLabel, true); }
			set	{ SetValue((int)AccountFieldIndex.MemberIdLabel, value); }
		}

		/// <summary> The AllowOnlineRegistration property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowOnlineRegistration"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowOnlineRegistration
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowOnlineRegistration, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowOnlineRegistration, value); }
		}

		/// <summary> The AllowPreQualifiedTestOnly property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowPreQualifiedTestOnly"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowPreQualifiedTestOnly
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowPreQualifiedTestOnly, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowPreQualifiedTestOnly, value); }
		}

		/// <summary> The AllowCustomerPortalLogin property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowCustomerPortalLogin"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowCustomerPortalLogin
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowCustomerPortalLogin, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowCustomerPortalLogin, value); }
		}

		/// <summary> The SendResultReadyMail property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendResultReadyMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendResultReadyMail
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendResultReadyMail, true); }
			set	{ SetValue((int)AccountFieldIndex.SendResultReadyMail, value); }
		}

		/// <summary> The ShowBasicBiometricPage property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowBasicBiometricPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowBasicBiometricPage
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowBasicBiometricPage, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowBasicBiometricPage, value); }
		}

		/// <summary> The SendSurveyMail property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendSurveyMail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendSurveyMail
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendSurveyMail, true); }
			set	{ SetValue((int)AccountFieldIndex.SendSurveyMail, value); }
		}

		/// <summary> The AppointmentConfirmationMailTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AppointmentConfirmationMailTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AppointmentConfirmationMailTemplateId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.AppointmentConfirmationMailTemplateId, true); }
			set	{ SetValue((int)AccountFieldIndex.AppointmentConfirmationMailTemplateId, value); }
		}

		/// <summary> The AppointmentReminderMailTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AppointmentReminderMailTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AppointmentReminderMailTemplateId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.AppointmentReminderMailTemplateId, true); }
			set	{ SetValue((int)AccountFieldIndex.AppointmentReminderMailTemplateId, value); }
		}

		/// <summary> The ResultReadyMailTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ResultReadyMailTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ResultReadyMailTemplateId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.ResultReadyMailTemplateId, true); }
			set	{ SetValue((int)AccountFieldIndex.ResultReadyMailTemplateId, value); }
		}

		/// <summary> The SurveyMailTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SurveyMailTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SurveyMailTemplateId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.SurveyMailTemplateId, true); }
			set	{ SetValue((int)AccountFieldIndex.SurveyMailTemplateId, value); }
		}

		/// <summary> The AllowVerifiedMembersOnly property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowVerifiedMembersOnly"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowVerifiedMembersOnly
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowVerifiedMembersOnly, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowVerifiedMembersOnly, value); }
		}

		/// <summary> The FirstName property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean FirstName
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.FirstName, true); }
			set	{ SetValue((int)AccountFieldIndex.FirstName, value); }
		}

		/// <summary> The MemberId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MemberId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MemberId
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.MemberId, true); }
			set	{ SetValue((int)AccountFieldIndex.MemberId, value); }
		}

		/// <summary> The Zipcode property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."Zipcode"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Zipcode
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.Zipcode, true); }
			set	{ SetValue((int)AccountFieldIndex.Zipcode, value); }
		}

		/// <summary> The LastName property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean LastName
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.LastName, true); }
			set	{ SetValue((int)AccountFieldIndex.LastName, value); }
		}

		/// <summary> The DateOfBirth property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."DateOfBirth"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean DateOfBirth
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.DateOfBirth, true); }
			set	{ SetValue((int)AccountFieldIndex.DateOfBirth, value); }
		}

		/// <summary> The Email property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Email
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.Email, true); }
			set	{ SetValue((int)AccountFieldIndex.Email, value); }
		}

		/// <summary> The SendResultReadyMailWithFax property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendResultReadyMailWithFax"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendResultReadyMailWithFax
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendResultReadyMailWithFax, true); }
			set	{ SetValue((int)AccountFieldIndex.SendResultReadyMailWithFax, value); }
		}

		/// <summary> The CapturePcpconsent property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CapturePCPConsent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CapturePcpconsent
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CapturePcpconsent, true); }
			set	{ SetValue((int)AccountFieldIndex.CapturePcpconsent, value); }
		}

		/// <summary> The CaptureAbnstatus property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CaptureABNStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureAbnstatus
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CaptureAbnstatus, true); }
			set	{ SetValue((int)AccountFieldIndex.CaptureAbnstatus, value); }
		}

		/// <summary> The AllowPrePayment property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowPrePayment"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowPrePayment
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowPrePayment, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowPrePayment, value); }
		}

		/// <summary> The HicnumberRequired property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."HICNumberRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean HicnumberRequired
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.HicnumberRequired, true); }
			set	{ SetValue((int)AccountFieldIndex.HicnumberRequired, value); }
		}

		/// <summary> The GeneratePcpLetterWithDiagnosisCode property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GeneratePcpLetterWithDiagnosisCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GeneratePcpLetterWithDiagnosisCode
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GeneratePcpLetterWithDiagnosisCode, true); }
			set	{ SetValue((int)AccountFieldIndex.GeneratePcpLetterWithDiagnosisCode, value); }
		}

		/// <summary> The GenerateCustomerResult property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateCustomerResult"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateCustomerResult
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateCustomerResult, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateCustomerResult, value); }
		}

		/// <summary> The IsCustomerResultsTestDependent property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."IsCustomerResultsTestDependent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsCustomerResultsTestDependent
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.IsCustomerResultsTestDependent, true); }
			set	{ SetValue((int)AccountFieldIndex.IsCustomerResultsTestDependent, value); }
		}

		/// <summary> The GeneratePcpResult property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GeneratePcpResult"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GeneratePcpResult
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GeneratePcpResult, true); }
			set	{ SetValue((int)AccountFieldIndex.GeneratePcpResult, value); }
		}

		/// <summary> The CheckoutPhoneNumber property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CheckoutPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CheckoutPhoneNumber
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.CheckoutPhoneNumber, true); }
			set	{ SetValue((int)AccountFieldIndex.CheckoutPhoneNumber, value); }
		}

		/// <summary> The RecommendPackage property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."RecommendPackage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RecommendPackage
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.RecommendPackage, true); }
			set	{ SetValue((int)AccountFieldIndex.RecommendPackage, value); }
		}

		/// <summary> The AskPreQualificationQuestion property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AskPreQualificationQuestion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AskPreQualificationQuestion
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AskPreQualificationQuestion, true); }
			set	{ SetValue((int)AccountFieldIndex.AskPreQualificationQuestion, value); }
		}

		/// <summary> The SendWelcomeEmail property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendWelcomeEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendWelcomeEmail
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendWelcomeEmail, true); }
			set	{ SetValue((int)AccountFieldIndex.SendWelcomeEmail, value); }
		}

		/// <summary> The CaptureHaf property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CaptureHAF"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureHaf
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CaptureHaf, true); }
			set	{ SetValue((int)AccountFieldIndex.CaptureHaf, value); }
		}

		/// <summary> The CaptureHafonline property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CaptureHAFOnline"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureHafonline
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CaptureHafonline, true); }
			set	{ SetValue((int)AccountFieldIndex.CaptureHafonline, value); }
		}

		/// <summary> The EnableImageUpsell property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."EnableImageUpsell"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableImageUpsell
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.EnableImageUpsell, true); }
			set	{ SetValue((int)AccountFieldIndex.EnableImageUpsell, value); }
		}

		/// <summary> The AllowTechUpdateQualifiedTests property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowTechUpdateQualifiedTests"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowTechUpdateQualifiedTests
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowTechUpdateQualifiedTests, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowTechUpdateQualifiedTests, value); }
		}

		/// <summary> The AttachQualityAssuranceForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachQualityAssuranceForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachQualityAssuranceForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachQualityAssuranceForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachQualityAssuranceForm, value); }
		}

		/// <summary> The RemoveLongDescription property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."RemoveLongDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RemoveLongDescription
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.RemoveLongDescription, true); }
			set	{ SetValue((int)AccountFieldIndex.RemoveLongDescription, value); }
		}

		/// <summary> The GenerateBatchLabel property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateBatchLabel"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateBatchLabel
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateBatchLabel, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateBatchLabel, value); }
		}

		/// <summary> The AttachCongitiveClockForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachCongitiveClockForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachCongitiveClockForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachCongitiveClockForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachCongitiveClockForm, value); }
		}

		/// <summary> The AttachChronicEvaluationForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachChronicEvaluationForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachChronicEvaluationForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachChronicEvaluationForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachChronicEvaluationForm, value); }
		}

		/// <summary> The AttachParicipantConsentForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachParicipantConsentForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachParicipantConsentForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachParicipantConsentForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachParicipantConsentForm, value); }
		}

		/// <summary> The UpsellTest property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."UpsellTest"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UpsellTest
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.UpsellTest, true); }
			set	{ SetValue((int)AccountFieldIndex.UpsellTest, value); }
		}

		/// <summary> The AskClinicalQuestions property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AskClinicalQuestions"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AskClinicalQuestions
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AskClinicalQuestions, true); }
			set	{ SetValue((int)AccountFieldIndex.AskClinicalQuestions, value); }
		}

		/// <summary> The ClinicalQuestionTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ClinicalQuestionTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ClinicalQuestionTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.ClinicalQuestionTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.ClinicalQuestionTemplateId, value); }
		}

		/// <summary> The DefaultSelectionBasePackage property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."DefaultSelectionBasePackage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean DefaultSelectionBasePackage
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.DefaultSelectionBasePackage, true); }
			set	{ SetValue((int)AccountFieldIndex.DefaultSelectionBasePackage, value); }
		}

		/// <summary> The SlotBooking property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SlotBooking"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SlotBooking
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SlotBooking, true); }
			set	{ SetValue((int)AccountFieldIndex.SlotBooking, value); }
		}

		/// <summary> The AddImagesForAbnormal property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AddImagesForAbnormal"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AddImagesForAbnormal
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AddImagesForAbnormal, true); }
			set	{ SetValue((int)AccountFieldIndex.AddImagesForAbnormal, value); }
		}

		/// <summary> The BookPcpAppointment property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."BookPcpAppointment"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean BookPcpAppointment
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.BookPcpAppointment, true); }
			set	{ SetValue((int)AccountFieldIndex.BookPcpAppointment, value); }
		}

		/// <summary> The NumberOfDays property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."NumberOfDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NumberOfDays
		{
			get { return (System.Int32)GetValue((int)AccountFieldIndex.NumberOfDays, true); }
			set	{ SetValue((int)AccountFieldIndex.NumberOfDays, value); }
		}

		/// <summary> The ScreeningInfo property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ScreeningInfo"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ScreeningInfo
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ScreeningInfo, true); }
			set	{ SetValue((int)AccountFieldIndex.ScreeningInfo, value); }
		}

		/// <summary> The PatientWorkSheet property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PatientWorkSheet"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PatientWorkSheet
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PatientWorkSheet, true); }
			set	{ SetValue((int)AccountFieldIndex.PatientWorkSheet, value); }
		}

		/// <summary> The UseHeaderImage property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."UseHeaderImage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean UseHeaderImage
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.UseHeaderImage, true); }
			set	{ SetValue((int)AccountFieldIndex.UseHeaderImage, value); }
		}

		/// <summary> The ShowHafFooter property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowHafFooter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowHafFooter
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowHafFooter, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowHafFooter, value); }
		}

		/// <summary> The CaptureSurvey property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CaptureSurvey"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean CaptureSurvey
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.CaptureSurvey, true); }
			set	{ SetValue((int)AccountFieldIndex.CaptureSurvey, value); }
		}

		/// <summary> The SurveyPdfFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SurveyPdfFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SurveyPdfFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.SurveyPdfFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.SurveyPdfFileId, value); }
		}

		/// <summary> The PcpLetterPdfFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PcpLetterPdfFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PcpLetterPdfFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.PcpLetterPdfFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.PcpLetterPdfFileId, value); }
		}

		/// <summary> The AttachScannedDoc property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachScannedDoc"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachScannedDoc
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachScannedDoc, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachScannedDoc, value); }
		}

		/// <summary> The ResultFormatTypeId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ResultFormatTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ResultFormatTypeId
		{
			get { return (System.Int64)GetValue((int)AccountFieldIndex.ResultFormatTypeId, true); }
			set	{ SetValue((int)AccountFieldIndex.ResultFormatTypeId, value); }
		}

		/// <summary> The AttachUnreadableTest property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachUnreadableTest"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachUnreadableTest
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachUnreadableTest, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachUnreadableTest, value); }
		}

		/// <summary> The AttachGiftCard property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachGiftCard"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachGiftCard
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachGiftCard, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachGiftCard, value); }
		}

		/// <summary> The GiftCardAmount property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GiftCardAmount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 10, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> GiftCardAmount
		{
			get { return (Nullable<System.Decimal>)GetValue((int)AccountFieldIndex.GiftCardAmount, false); }
			set	{ SetValue((int)AccountFieldIndex.GiftCardAmount, value); }
		}

		/// <summary> The AttachEawvPreventionPlan property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachEawvPreventionPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachEawvPreventionPlan
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachEawvPreventionPlan, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachEawvPreventionPlan, value); }
		}

		/// <summary> The GenerateEawvPreventionPlanReport property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateEawvPreventionPlanReport"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateEawvPreventionPlanReport
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateEawvPreventionPlanReport, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateEawvPreventionPlanReport, value); }
		}

		/// <summary> The GenerateFluPneuConsentForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateFluPneuConsentForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateFluPneuConsentForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateFluPneuConsentForm, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateFluPneuConsentForm, value); }
		}

		/// <summary> The GenerateBmiReport property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateBmiReport"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateBmiReport
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateBmiReport, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateBmiReport, value); }
		}

		/// <summary> The EnablePgpEncryption property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."EnablePgpEncryption"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnablePgpEncryption
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.EnablePgpEncryption, true); }
			set	{ SetValue((int)AccountFieldIndex.EnablePgpEncryption, value); }
		}

		/// <summary> The PublicKeyFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PublicKeyFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> PublicKeyFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.PublicKeyFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.PublicKeyFileId, value); }
		}

		/// <summary> The LockEvent property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."LockEvent"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean LockEvent
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.LockEvent, true); }
			set	{ SetValue((int)AccountFieldIndex.LockEvent, value); }
		}

		/// <summary> The GenerateHealthPlanReport property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GenerateHealthPlanReport"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GenerateHealthPlanReport
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GenerateHealthPlanReport, true); }
			set	{ SetValue((int)AccountFieldIndex.GenerateHealthPlanReport, value); }
		}

		/// <summary> The IsHealthPlan property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."IsHealthPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsHealthPlan
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.IsHealthPlan, true); }
			set	{ SetValue((int)AccountFieldIndex.IsHealthPlan, value); }
		}

		/// <summary> The AttachAttestationForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachAttestationForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachAttestationForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachAttestationForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachAttestationForm, value); }
		}

		/// <summary> The EventLockDaysCount property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."EventLockDaysCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> EventLockDaysCount
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.EventLockDaysCount, false); }
			set	{ SetValue((int)AccountFieldIndex.EventLockDaysCount, value); }
		}

		/// <summary> The AttachOrderRequisitionForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AttachOrderRequisitionForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AttachOrderRequisitionForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AttachOrderRequisitionForm, true); }
			set	{ SetValue((int)AccountFieldIndex.AttachOrderRequisitionForm, value); }
		}

		/// <summary> The ParticipantLetterId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ParticipantLetterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParticipantLetterId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.ParticipantLetterId, false); }
			set	{ SetValue((int)AccountFieldIndex.ParticipantLetterId, value); }
		}

		/// <summary> The FolderName property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."FolderName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FolderName
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.FolderName, true); }
			set	{ SetValue((int)AccountFieldIndex.FolderName, value); }
		}

		/// <summary> The CheckListFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CheckListFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CheckListFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.CheckListFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.CheckListFileId, value); }
		}

		/// <summary> The PrintCheckList property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintCheckList"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintCheckList
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintCheckList, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintCheckList, value); }
		}

		/// <summary> The SendEventResultReadyNotification property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendEventResultReadyNotification"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendEventResultReadyNotification
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendEventResultReadyNotification, true); }
			set	{ SetValue((int)AccountFieldIndex.SendEventResultReadyNotification, value); }
		}

		/// <summary> The ShowBarrier property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowBarrier"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowBarrier
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowBarrier, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowBarrier, value); }
		}

		/// <summary> The PrintPcpAppointmentForBulkHaf property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintPcpAppointmentForBulkHaf"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintPcpAppointmentForBulkHaf
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintPcpAppointmentForBulkHaf, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintPcpAppointmentForBulkHaf, value); }
		}

		/// <summary> The PrintPcpAppointmentForResult property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintPcpAppointmentForResult"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintPcpAppointmentForResult
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintPcpAppointmentForResult, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintPcpAppointmentForResult, value); }
		}

		/// <summary> The PrintAceForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintAceForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintAceForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintAceForm, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintAceForm, value); }
		}

		/// <summary> The PrintMipForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintMipForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintMipForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintMipForm, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintMipForm, value); }
		}

		/// <summary> The AllowRegistrationWithImproperTags property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AllowRegistrationWithImproperTags"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AllowRegistrationWithImproperTags
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AllowRegistrationWithImproperTags, true); }
			set	{ SetValue((int)AccountFieldIndex.AllowRegistrationWithImproperTags, value); }
		}

		/// <summary> The PrintMicroalbuminForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintMicroalbuminForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintMicroalbuminForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintMicroalbuminForm, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintMicroalbuminForm, value); }
		}

		/// <summary> The PrintIfobtform property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintIFOBTForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintIfobtform
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintIfobtform, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintIfobtform, value); }
		}

		/// <summary> The EnableSms property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."EnableSms"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean EnableSms
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.EnableSms, true); }
			set	{ SetValue((int)AccountFieldIndex.EnableSms, value); }
		}

		/// <summary> The MaximumSms property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MaximumSms"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MaximumSms
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.MaximumSms, false); }
			set	{ SetValue((int)AccountFieldIndex.MaximumSms, value); }
		}

		/// <summary> The ConfirmationSmsTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ConfirmationSmsTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ConfirmationSmsTemplateId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.ConfirmationSmsTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.ConfirmationSmsTemplateId, value); }
		}

		/// <summary> The ReminderSmsTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ReminderSmsTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ReminderSmsTemplateId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.ReminderSmsTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.ReminderSmsTemplateId, value); }
		}

		/// <summary> The PrintLoincLabData property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PrintLoincLabData"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean PrintLoincLabData
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.PrintLoincLabData, true); }
			set	{ SetValue((int)AccountFieldIndex.PrintLoincLabData, value); }
		}

		/// <summary> The CheckListTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CheckListTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CheckListTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.CheckListTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.CheckListTemplateId, value); }
		}

		/// <summary> The IsMaxAttemptPerHealthPlan property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."IsMaxAttemptPerHealthPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsMaxAttemptPerHealthPlan
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.IsMaxAttemptPerHealthPlan, true); }
			set	{ SetValue((int)AccountFieldIndex.IsMaxAttemptPerHealthPlan, value); }
		}

		/// <summary> The MaxAttempt property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MaxAttempt"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MaxAttempt
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.MaxAttempt, false); }
			set	{ SetValue((int)AccountFieldIndex.MaxAttempt, value); }
		}

		/// <summary> The MarkPennedBack property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MarkPennedBack"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MarkPennedBack
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.MarkPennedBack, true); }
			set	{ SetValue((int)AccountFieldIndex.MarkPennedBack, value); }
		}

		/// <summary> The PennedBackText property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PennedBackText"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PennedBackText
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.PennedBackText, true); }
			set	{ SetValue((int)AccountFieldIndex.PennedBackText, value); }
		}

		/// <summary> The ShowCallCenterScript property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowCallCenterScript"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowCallCenterScript
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowCallCenterScript, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowCallCenterScript, value); }
		}

		/// <summary> The CallCenterScriptFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."CallCenterScriptFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallCenterScriptFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.CallCenterScriptFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.CallCenterScriptFileId, value); }
		}

		/// <summary> The EventConfirmationBeforeDays property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."EventConfirmationBeforeDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> EventConfirmationBeforeDays
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.EventConfirmationBeforeDays, false); }
			set	{ SetValue((int)AccountFieldIndex.EventConfirmationBeforeDays, value); }
		}

		/// <summary> The ConfirmationBeforeAppointmentMinutes property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ConfirmationBeforeAppointmentMinutes"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> ConfirmationBeforeAppointmentMinutes
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.ConfirmationBeforeAppointmentMinutes, false); }
			set	{ SetValue((int)AccountFieldIndex.ConfirmationBeforeAppointmentMinutes, value); }
		}

		/// <summary> The ConfirmationScriptFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ConfirmationScriptFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ConfirmationScriptFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.ConfirmationScriptFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.ConfirmationScriptFileId, value); }
		}

		/// <summary> The RestrictHealthPlanData property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."RestrictHealthPlanData"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean RestrictHealthPlanData
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.RestrictHealthPlanData, true); }
			set	{ SetValue((int)AccountFieldIndex.RestrictHealthPlanData, value); }
		}

		/// <summary> The SendPatientDataToAces property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendPatientDataToAces"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendPatientDataToAces
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendPatientDataToAces, true); }
			set	{ SetValue((int)AccountFieldIndex.SendPatientDataToAces, value); }
		}

		/// <summary> The ClientId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ClientId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ClientId
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.ClientId, true); }
			set	{ SetValue((int)AccountFieldIndex.ClientId, value); }
		}

		/// <summary> The SendConsentData property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SendConsentData"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean SendConsentData
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.SendConsentData, true); }
			set	{ SetValue((int)AccountFieldIndex.SendConsentData, value); }
		}

		/// <summary> The ShowGiftCertificateOnEod property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowGiftCertificateOnEod"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowGiftCertificateOnEod
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowGiftCertificateOnEod, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowGiftCertificateOnEod, value); }
		}

		/// <summary> The WarmTransfer property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."WarmTransfer"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean WarmTransfer
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.WarmTransfer, true); }
			set	{ SetValue((int)AccountFieldIndex.WarmTransfer, value); }
		}

		/// <summary> The InboundCallScriptFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."InboundCallScriptFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> InboundCallScriptFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.InboundCallScriptFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.InboundCallScriptFileId, value); }
		}

		/// <summary> The AcesClientShortName property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AcesClientShortName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesClientShortName
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.AcesClientShortName, true); }
			set	{ SetValue((int)AccountFieldIndex.AcesClientShortName, value); }
		}

		/// <summary> The IncludeMemberLetter property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."IncludeMemberLetter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IncludeMemberLetter
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.IncludeMemberLetter, true); }
			set	{ SetValue((int)AccountFieldIndex.IncludeMemberLetter, value); }
		}

		/// <summary> The MemberLetterFileId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MemberLetterFileId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MemberLetterFileId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.MemberLetterFileId, false); }
			set	{ SetValue((int)AccountFieldIndex.MemberLetterFileId, value); }
		}

		/// <summary> The PcpCoverLetterTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."PcpCoverLetterTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PcpCoverLetterTemplateId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.PcpCoverLetterTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.PcpCoverLetterTemplateId, value); }
		}

		/// <summary> The MemberCoverLetterTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."MemberCoverLetterTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> MemberCoverLetterTemplateId
		{
			get { return (Nullable<System.Int32>)GetValue((int)AccountFieldIndex.MemberCoverLetterTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.MemberCoverLetterTemplateId, value); }
		}

		/// <summary> The AcesToHipIntake property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AcesToHipIntake"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean AcesToHipIntake
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.AcesToHipIntake, true); }
			set	{ SetValue((int)AccountFieldIndex.AcesToHipIntake, value); }
		}

		/// <summary> The AcesToHipIntakeShortName property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."AcesToHipIntakeShortName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String AcesToHipIntakeShortName
		{
			get { return (System.String)GetValue((int)AccountFieldIndex.AcesToHipIntakeShortName, true); }
			set	{ SetValue((int)AccountFieldIndex.AcesToHipIntakeShortName, value); }
		}

		/// <summary> The FluConsentTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."FluConsentTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> FluConsentTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.FluConsentTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.FluConsentTemplateId, value); }
		}

		/// <summary> The ExitInterviewTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ExitInterviewTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ExitInterviewTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.ExitInterviewTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.ExitInterviewTemplateId, value); }
		}

		/// <summary> The SurveyTemplateId property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."SurveyTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SurveyTemplateId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AccountFieldIndex.SurveyTemplateId, false); }
			set	{ SetValue((int)AccountFieldIndex.SurveyTemplateId, value); }
		}

		/// <summary> The ShowChaperonForm property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."ShowChaperonForm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean ShowChaperonForm
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.ShowChaperonForm, true); }
			set	{ SetValue((int)AccountFieldIndex.ShowChaperonForm, value); }
		}

		/// <summary> The GeneratePcpLetter property of the Entity Account<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAccount"."GeneratePcpLetter"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GeneratePcpLetter
		{
			get { return (System.Boolean)GetValue((int)AccountFieldIndex.GeneratePcpLetter, true); }
			set	{ SetValue((int)AccountFieldIndex.GeneratePcpLetter, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountAdditionalFieldsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountAdditionalFieldsEntity))]
		public virtual EntityCollection<AccountAdditionalFieldsEntity> AccountAdditionalFields
		{
			get
			{
				if(_accountAdditionalFields==null)
				{
					_accountAdditionalFields = new EntityCollection<AccountAdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountAdditionalFieldsEntityFactory)));
					_accountAdditionalFields.SetContainingEntityInfo(this, "Account");
				}
				return _accountAdditionalFields;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCallCenterOrganizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCallCenterOrganizationEntity))]
		public virtual EntityCollection<AccountCallCenterOrganizationEntity> AccountCallCenterOrganization
		{
			get
			{
				if(_accountCallCenterOrganization==null)
				{
					_accountCallCenterOrganization = new EntityCollection<AccountCallCenterOrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallCenterOrganizationEntityFactory)));
					_accountCallCenterOrganization.SetContainingEntityInfo(this, "Account");
				}
				return _accountCallCenterOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCallQueueSettingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCallQueueSettingEntity))]
		public virtual EntityCollection<AccountCallQueueSettingEntity> AccountCallQueueSetting
		{
			get
			{
				if(_accountCallQueueSetting==null)
				{
					_accountCallQueueSetting = new EntityCollection<AccountCallQueueSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallQueueSettingEntityFactory)));
					_accountCallQueueSetting.SetContainingEntityInfo(this, "Account");
				}
				return _accountCallQueueSetting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCheckoutPhoneNumberEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCheckoutPhoneNumberEntity))]
		public virtual EntityCollection<AccountCheckoutPhoneNumberEntity> AccountCheckoutPhoneNumber
		{
			get
			{
				if(_accountCheckoutPhoneNumber==null)
				{
					_accountCheckoutPhoneNumber = new EntityCollection<AccountCheckoutPhoneNumberEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCheckoutPhoneNumberEntityFactory)));
					_accountCheckoutPhoneNumber.SetContainingEntityInfo(this, "Account");
				}
				return _accountCheckoutPhoneNumber;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountCustomerResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountCustomerResultTestDependencyEntity))]
		public virtual EntityCollection<AccountCustomerResultTestDependencyEntity> AccountCustomerResultTestDependency
		{
			get
			{
				if(_accountCustomerResultTestDependency==null)
				{
					_accountCustomerResultTestDependency = new EntityCollection<AccountCustomerResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCustomerResultTestDependencyEntityFactory)));
					_accountCustomerResultTestDependency.SetContainingEntityInfo(this, "Account");
				}
				return _accountCustomerResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEventZipSubstituteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEventZipSubstituteEntity))]
		public virtual EntityCollection<AccountEventZipSubstituteEntity> AccountEventZipSubstitute
		{
			get
			{
				if(_accountEventZipSubstitute==null)
				{
					_accountEventZipSubstitute = new EntityCollection<AccountEventZipSubstituteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEventZipSubstituteEntityFactory)));
					_accountEventZipSubstitute.SetContainingEntityInfo(this, "Account");
				}
				return _accountEventZipSubstitute;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountHealthPlanResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountHealthPlanResultTestDependencyEntity))]
		public virtual EntityCollection<AccountHealthPlanResultTestDependencyEntity> AccountHealthPlanResultTestDependency
		{
			get
			{
				if(_accountHealthPlanResultTestDependency==null)
				{
					_accountHealthPlanResultTestDependency = new EntityCollection<AccountHealthPlanResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHealthPlanResultTestDependencyEntityFactory)));
					_accountHealthPlanResultTestDependency.SetContainingEntityInfo(this, "Account");
				}
				return _accountHealthPlanResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountHraChatQuestionnaireEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountHraChatQuestionnaireEntity))]
		public virtual EntityCollection<AccountHraChatQuestionnaireEntity> AccountHraChatQuestionnaire
		{
			get
			{
				if(_accountHraChatQuestionnaire==null)
				{
					_accountHraChatQuestionnaire = new EntityCollection<AccountHraChatQuestionnaireEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountHraChatQuestionnaireEntityFactory)));
					_accountHraChatQuestionnaire.SetContainingEntityInfo(this, "Account");
				}
				return _accountHraChatQuestionnaire;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountNotReviewableTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountNotReviewableTestEntity))]
		public virtual EntityCollection<AccountNotReviewableTestEntity> AccountNotReviewableTest
		{
			get
			{
				if(_accountNotReviewableTest==null)
				{
					_accountNotReviewableTest = new EntityCollection<AccountNotReviewableTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountNotReviewableTestEntityFactory)));
					_accountNotReviewableTest.SetContainingEntityInfo(this, "Account");
				}
				return _accountNotReviewableTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountPackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountPackageEntity))]
		public virtual EntityCollection<AccountPackageEntity> AccountPackage
		{
			get
			{
				if(_accountPackage==null)
				{
					_accountPackage = new EntityCollection<AccountPackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPackageEntityFactory)));
					_accountPackage.SetContainingEntityInfo(this, "Account");
				}
				return _accountPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountPcpResultTestDependencyEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountPcpResultTestDependencyEntity))]
		public virtual EntityCollection<AccountPcpResultTestDependencyEntity> AccountPcpResultTestDependency
		{
			get
			{
				if(_accountPcpResultTestDependency==null)
				{
					_accountPcpResultTestDependency = new EntityCollection<AccountPcpResultTestDependencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountPcpResultTestDependencyEntityFactory)));
					_accountPcpResultTestDependency.SetContainingEntityInfo(this, "Account");
				}
				return _accountPcpResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountTestEntity))]
		public virtual EntityCollection<AccountTestEntity> AccountTest
		{
			get
			{
				if(_accountTest==null)
				{
					_accountTest = new EntityCollection<AccountTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestEntityFactory)));
					_accountTest.SetContainingEntityInfo(this, "Account");
				}
				return _accountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomer
		{
			get
			{
				if(_callQueueCustomer==null)
				{
					_callQueueCustomer = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomer.SetContainingEntityInfo(this, "Account");
				}
				return _callQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomTagEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomTagEntity))]
		public virtual EntityCollection<CallQueueCustomTagEntity> CallQueueCustomTag
		{
			get
			{
				if(_callQueueCustomTag==null)
				{
					_callQueueCustomTag = new EntityCollection<CallQueueCustomTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomTagEntityFactory)));
					_callQueueCustomTag.SetContainingEntityInfo(this, "Account");
				}
				return _callQueueCustomTag;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallRoundCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallRoundCallQueueEntity))]
		public virtual EntityCollection<CallRoundCallQueueEntity> CallRoundCallQueue
		{
			get
			{
				if(_callRoundCallQueue==null)
				{
					_callRoundCallQueue = new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory)));
					_callRoundCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _callRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> Calls
		{
			get
			{
				if(_calls==null)
				{
					_calls = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_calls.SetContainingEntityInfo(this, "Account");
				}
				return _calls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> Campaign
		{
			get
			{
				if(_campaign==null)
				{
					_campaign = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaign.SetContainingEntityInfo(this, "Account");
				}
				return _campaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CorporateTagEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CorporateTagEntity))]
		public virtual EntityCollection<CorporateTagEntity> CorporateTag
		{
			get
			{
				if(_corporateTag==null)
				{
					_corporateTag = new EntityCollection<CorporateTagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateTagEntityFactory)));
					_corporateTag.SetContainingEntityInfo(this, "Account");
				}
				return _corporateTag;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CorporateUploadEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CorporateUploadEntity))]
		public virtual EntityCollection<CorporateUploadEntity> CorporateUpload
		{
			get
			{
				if(_corporateUpload==null)
				{
					_corporateUpload = new EntityCollection<CorporateUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CorporateUploadEntityFactory)));
					_corporateUpload.SetContainingEntityInfo(this, "Account");
				}
				return _corporateUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomEventNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomEventNotificationEntity))]
		public virtual EntityCollection<CustomEventNotificationEntity> CustomEventNotification
		{
			get
			{
				if(_customEventNotification==null)
				{
					_customEventNotification = new EntityCollection<CustomEventNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomEventNotificationEntityFactory)));
					_customEventNotification.SetContainingEntityInfo(this, "Account");
				}
				return _customEventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EligibilityUploadEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EligibilityUploadEntity))]
		public virtual EntityCollection<EligibilityUploadEntity> EligibilityUpload
		{
			get
			{
				if(_eligibilityUpload==null)
				{
					_eligibilityUpload = new EntityCollection<EligibilityUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EligibilityUploadEntityFactory)));
					_eligibilityUpload.SetContainingEntityInfo(this, "Account");
				}
				return _eligibilityUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAccountEntity))]
		public virtual EntityCollection<EventAccountEntity> EventAccount
		{
			get
			{
				if(_eventAccount==null)
				{
					_eventAccount = new EntityCollection<EventAccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountEntityFactory)));
					_eventAccount.SetContainingEntityInfo(this, "Account");
				}
				return _eventAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventNoteEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventNoteEntity))]
		public virtual EntityCollection<EventNoteEntity> EventNote
		{
			get
			{
				if(_eventNote==null)
				{
					_eventNote = new EntityCollection<EventNoteEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventNoteEntityFactory)));
					_eventNote.SetContainingEntityInfo(this, "Account");
				}
				return _eventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FillEventCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FillEventCallQueueEntity))]
		public virtual EntityCollection<FillEventCallQueueEntity> FillEventCallQueue
		{
			get
			{
				if(_fillEventCallQueue==null)
				{
					_fillEventCallQueue = new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory)));
					_fillEventCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _fillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteria
		{
			get
			{
				if(_healthPlanCallQueueCriteria==null)
				{
					_healthPlanCallQueueCriteria = new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory)));
					_healthPlanCallQueueCriteria.SetContainingEntityInfo(this, "Account");
				}
				return _healthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanRevenueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanRevenueEntity))]
		public virtual EntityCollection<HealthPlanRevenueEntity> HealthPlanRevenue
		{
			get
			{
				if(_healthPlanRevenue==null)
				{
					_healthPlanRevenue = new EntityCollection<HealthPlanRevenueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanRevenueEntityFactory)));
					_healthPlanRevenue.SetContainingEntityInfo(this, "Account");
				}
				return _healthPlanRevenue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageBarrierCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageBarrierCallQueueEntity))]
		public virtual EntityCollection<LanguageBarrierCallQueueEntity> LanguageBarrierCallQueue
		{
			get
			{
				if(_languageBarrierCallQueue==null)
				{
					_languageBarrierCallQueue = new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory)));
					_languageBarrierCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _languageBarrierCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MailRoundCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MailRoundCallQueueEntity))]
		public virtual EntityCollection<MailRoundCallQueueEntity> MailRoundCallQueue
		{
			get
			{
				if(_mailRoundCallQueue==null)
				{
					_mailRoundCallQueue = new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory)));
					_mailRoundCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _mailRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoShowCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoShowCallQueueEntity))]
		public virtual EntityCollection<NoShowCallQueueEntity> NoShowCallQueue
		{
			get
			{
				if(_noShowCallQueue==null)
				{
					_noShowCallQueue = new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory)));
					_noShowCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _noShowCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UncontactedCustomerCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UncontactedCustomerCallQueueEntity))]
		public virtual EntityCollection<UncontactedCustomerCallQueueEntity> UncontactedCustomerCallQueue
		{
			get
			{
				if(_uncontactedCustomerCallQueue==null)
				{
					_uncontactedCustomerCallQueue = new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory)));
					_uncontactedCustomerCallQueue.SetContainingEntityInfo(this, "Account");
				}
				return _uncontactedCustomerCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActivityTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActivityTypeEntity))]
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				if(_activityTypeCollectionViaCallQueueCustomer==null)
				{
					_activityTypeCollectionViaCallQueueCustomer = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AdditionalFieldsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AdditionalFieldsEntity))]
		public virtual EntityCollection<AdditionalFieldsEntity> AdditionalFieldsCollectionViaAccountAdditionalFields
		{
			get
			{
				if(_additionalFieldsCollectionViaAccountAdditionalFields==null)
				{
					_additionalFieldsCollectionViaAccountAdditionalFields = new EntityCollection<AdditionalFieldsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AdditionalFieldsEntityFactory)));
					_additionalFieldsCollectionViaAccountAdditionalFields.IsReadOnly=true;
				}
				return _additionalFieldsCollectionViaAccountAdditionalFields;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaAccountCallQueueSetting
		{
			get
			{
				if(_callQueueCollectionViaAccountCallQueueSetting==null)
				{
					_callQueueCollectionViaAccountCallQueueSetting = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaAccountCallQueueSetting.IsReadOnly=true;
				}
				return _callQueueCollectionViaAccountCallQueueSetting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				if(_callQueueCollectionViaHealthPlanCallQueueCriteria==null)
				{
					_callQueueCollectionViaHealthPlanCallQueueCriteria = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaHealthPlanCallQueueCriteria.IsReadOnly=true;
				}
				return _callQueueCollectionViaHealthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaCalls
		{
			get
			{
				if(_callQueueCollectionViaCalls==null)
				{
					_callQueueCollectionViaCalls = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaCalls.IsReadOnly=true;
				}
				return _callQueueCollectionViaCalls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCollectionViaCallQueueCustomer==null)
				{
					_callQueueCollectionViaCallQueueCustomer = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCriteriaEntity))]
		public virtual EntityCollection<CallQueueCriteriaEntity> CallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				if(_callQueueCriteriaCollectionViaCallQueueCustomer==null)
				{
					_callQueueCriteriaCollectionViaCallQueueCustomer = new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory)));
					_callQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _callQueueCriteriaCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				if(_campaignCollectionViaHealthPlanCallQueueCriteria==null)
				{
					_campaignCollectionViaHealthPlanCallQueueCriteria = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaHealthPlanCallQueueCriteria.IsReadOnly=true;
				}
				return _campaignCollectionViaHealthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCalls
		{
			get
			{
				if(_campaignCollectionViaCalls==null)
				{
					_campaignCollectionViaCalls = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCalls.IsReadOnly=true;
				}
				return _campaignCollectionViaCalls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignEntity))]
		public virtual EntityCollection<CampaignEntity> CampaignCollectionViaCallQueueCustomer
		{
			get
			{
				if(_campaignCollectionViaCallQueueCustomer==null)
				{
					_campaignCollectionViaCallQueueCustomer = new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory)));
					_campaignCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _campaignCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaNoShowCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaNoShowCallQueue==null)
				{
					_customerProfileCollectionViaNoShowCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaNoShowCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaNoShowCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaFillEventCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaFillEventCallQueue==null)
				{
					_customerProfileCollectionViaFillEventCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaFillEventCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaFillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				if(_customerProfileCollectionViaCallQueueCustomer==null)
				{
					_customerProfileCollectionViaCallQueueCustomer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaUncontactedCustomerCallQueue==null)
				{
					_customerProfileCollectionViaUncontactedCustomerCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaUncontactedCustomerCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaUncontactedCustomerCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaMailRoundCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaMailRoundCallQueue==null)
				{
					_customerProfileCollectionViaMailRoundCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaMailRoundCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaMailRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaLanguageBarrierCallQueue==null)
				{
					_customerProfileCollectionViaLanguageBarrierCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaLanguageBarrierCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaLanguageBarrierCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCallRoundCallQueue
		{
			get
			{
				if(_customerProfileCollectionViaCallRoundCallQueue==null)
				{
					_customerProfileCollectionViaCallRoundCallQueue = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCallRoundCallQueue.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCallRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventCustomersCollectionViaCallQueueCustomer==null)
				{
					_eventCustomersCollectionViaCallQueueCustomer = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomersCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventCustomersCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomEventNotification
		{
			get
			{
				if(_eventsCollectionViaCustomEventNotification==null)
				{
					_eventsCollectionViaCustomEventNotification = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomEventNotification.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomEventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_eventsCollectionViaCallQueueCustomer==null)
				{
					_eventsCollectionViaCallQueueCustomer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _eventsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaEligibilityUpload
		{
			get
			{
				if(_fileCollectionViaEligibilityUpload==null)
				{
					_fileCollectionViaEligibilityUpload = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaEligibilityUpload.IsReadOnly=true;
				}
				return _fileCollectionViaEligibilityUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaEligibilityUpload_
		{
			get
			{
				if(_fileCollectionViaEligibilityUpload_==null)
				{
					_fileCollectionViaEligibilityUpload_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaEligibilityUpload_.IsReadOnly=true;
				}
				return _fileCollectionViaEligibilityUpload_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaCorporateUpload_
		{
			get
			{
				if(_fileCollectionViaCorporateUpload_==null)
				{
					_fileCollectionViaCorporateUpload_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaCorporateUpload_.IsReadOnly=true;
				}
				return _fileCollectionViaCorporateUpload_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaCorporateUpload
		{
			get
			{
				if(_fileCollectionViaCorporateUpload==null)
				{
					_fileCollectionViaCorporateUpload = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaCorporateUpload.IsReadOnly=true;
				}
				return _fileCollectionViaCorporateUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaCorporateUpload__
		{
			get
			{
				if(_fileCollectionViaCorporateUpload__==null)
				{
					_fileCollectionViaCorporateUpload__ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaCorporateUpload__.IsReadOnly=true;
				}
				return _fileCollectionViaCorporateUpload__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCallQueueCustomer
		{
			get
			{
				if(_languageCollectionViaCallQueueCustomer==null)
				{
					_languageCollectionViaCallQueueCustomer = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _languageCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageEntity))]
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				if(_languageCollectionViaHealthPlanCallQueueCriteria==null)
				{
					_languageCollectionViaHealthPlanCallQueueCriteria = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaHealthPlanCallQueueCriteria.IsReadOnly=true;
				}
				return _languageCollectionViaHealthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCampaign
		{
			get
			{
				if(_lookupCollectionViaCampaign==null)
				{
					_lookupCollectionViaCampaign = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCampaign.IsReadOnly=true;
				}
				return _lookupCollectionViaCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				if(_lookupCollectionViaUncontactedCustomerCallQueue==null)
				{
					_lookupCollectionViaUncontactedCustomerCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaUncontactedCustomerCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaUncontactedCustomerCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCalls__
		{
			get
			{
				if(_lookupCollectionViaCalls__==null)
				{
					_lookupCollectionViaCalls__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCalls__.IsReadOnly=true;
				}
				return _lookupCollectionViaCalls__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				if(_lookupCollectionViaLanguageBarrierCallQueue==null)
				{
					_lookupCollectionViaLanguageBarrierCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaLanguageBarrierCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaLanguageBarrierCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCampaign_
		{
			get
			{
				if(_lookupCollectionViaCampaign_==null)
				{
					_lookupCollectionViaCampaign_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCampaign_.IsReadOnly=true;
				}
				return _lookupCollectionViaCampaign_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHealthPlanRevenue
		{
			get
			{
				if(_lookupCollectionViaHealthPlanRevenue==null)
				{
					_lookupCollectionViaHealthPlanRevenue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHealthPlanRevenue.IsReadOnly=true;
				}
				return _lookupCollectionViaHealthPlanRevenue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomEventNotification
		{
			get
			{
				if(_lookupCollectionViaCustomEventNotification==null)
				{
					_lookupCollectionViaCustomEventNotification = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomEventNotification.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomEventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaFillEventCallQueue
		{
			get
			{
				if(_lookupCollectionViaFillEventCallQueue==null)
				{
					_lookupCollectionViaFillEventCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaFillEventCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaFillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEligibilityUpload
		{
			get
			{
				if(_lookupCollectionViaEligibilityUpload==null)
				{
					_lookupCollectionViaEligibilityUpload = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEligibilityUpload.IsReadOnly=true;
				}
				return _lookupCollectionViaEligibilityUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaNoShowCallQueue
		{
			get
			{
				if(_lookupCollectionViaNoShowCallQueue==null)
				{
					_lookupCollectionViaNoShowCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaNoShowCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaNoShowCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCorporateUpload
		{
			get
			{
				if(_lookupCollectionViaCorporateUpload==null)
				{
					_lookupCollectionViaCorporateUpload = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCorporateUpload.IsReadOnly=true;
				}
				return _lookupCollectionViaCorporateUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaMailRoundCallQueue
		{
			get
			{
				if(_lookupCollectionViaMailRoundCallQueue==null)
				{
					_lookupCollectionViaMailRoundCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaMailRoundCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaMailRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccountCallQueueSetting
		{
			get
			{
				if(_lookupCollectionViaAccountCallQueueSetting==null)
				{
					_lookupCollectionViaAccountCallQueueSetting = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccountCallQueueSetting.IsReadOnly=true;
				}
				return _lookupCollectionViaAccountCallQueueSetting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccountHraChatQuestionnaire
		{
			get
			{
				if(_lookupCollectionViaAccountHraChatQuestionnaire==null)
				{
					_lookupCollectionViaAccountHraChatQuestionnaire = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccountHraChatQuestionnaire.IsReadOnly=true;
				}
				return _lookupCollectionViaAccountHraChatQuestionnaire;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCallQueueCustomer
		{
			get
			{
				if(_lookupCollectionViaCallQueueCustomer==null)
				{
					_lookupCollectionViaCallQueueCustomer = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _lookupCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCallRoundCallQueue
		{
			get
			{
				if(_lookupCollectionViaCallRoundCallQueue==null)
				{
					_lookupCollectionViaCallRoundCallQueue = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCallRoundCallQueue.IsReadOnly=true;
				}
				return _lookupCollectionViaCallRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCalls_
		{
			get
			{
				if(_lookupCollectionViaCalls_==null)
				{
					_lookupCollectionViaCalls_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCalls_.IsReadOnly=true;
				}
				return _lookupCollectionViaCalls_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCalls
		{
			get
			{
				if(_lookupCollectionViaCalls==null)
				{
					_lookupCollectionViaCalls = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCalls.IsReadOnly=true;
				}
				return _lookupCollectionViaCalls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				if(_notesDetailsCollectionViaCallQueueCustomer==null)
				{
					_notesDetailsCollectionViaCallQueueCustomer = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaAccountCallCenterOrganization
		{
			get
			{
				if(_organizationCollectionViaAccountCallCenterOrganization==null)
				{
					_organizationCollectionViaAccountCallCenterOrganization = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaAccountCallCenterOrganization.IsReadOnly=true;
				}
				return _organizationCollectionViaAccountCallCenterOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountHraChatQuestionnaire==null)
				{
					_organizationRoleUserCollectionViaAccountHraChatQuestionnaire = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountHraChatQuestionnaire.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountHraChatQuestionnaire;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountHraChatQuestionnaire_
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_==null)
				{
					_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountHraChatQuestionnaire_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountHraChatQuestionnaire_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaFillEventCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaFillEventCallQueue==null)
				{
					_organizationRoleUserCollectionViaFillEventCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaFillEventCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaFillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventNote_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventNote_==null)
				{
					_organizationRoleUserCollectionViaEventNote_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventNote_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventNote_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaNoShowCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaNoShowCallQueue==null)
				{
					_organizationRoleUserCollectionViaNoShowCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaNoShowCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaNoShowCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountCallCenterOrganization_
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountCallCenterOrganization_==null)
				{
					_organizationRoleUserCollectionViaAccountCallCenterOrganization_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountCallCenterOrganization_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountCallCenterOrganization_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaUncontactedCustomerCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaUncontactedCustomerCallQueue==null)
				{
					_organizationRoleUserCollectionViaUncontactedCustomerCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaUncontactedCustomerCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaUncontactedCustomerCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountCallCenterOrganization
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountCallCenterOrganization==null)
				{
					_organizationRoleUserCollectionViaAccountCallCenterOrganization = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountCallCenterOrganization.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountCallCenterOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanRevenue_
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanRevenue_==null)
				{
					_organizationRoleUserCollectionViaHealthPlanRevenue_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanRevenue_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanRevenue_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanRevenue
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanRevenue==null)
				{
					_organizationRoleUserCollectionViaHealthPlanRevenue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanRevenue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanRevenue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMailRoundCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaMailRoundCallQueue==null)
				{
					_organizationRoleUserCollectionViaMailRoundCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMailRoundCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMailRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaLanguageBarrierCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaLanguageBarrierCallQueue==null)
				{
					_organizationRoleUserCollectionViaLanguageBarrierCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaLanguageBarrierCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaLanguageBarrierCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomTag
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomTag==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomTag = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomTag.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomTag;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCorporateTag_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCorporateTag_==null)
				{
					_organizationRoleUserCollectionViaCorporateTag_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCorporateTag_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCorporateTag_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCorporateUpload
		{
			get
			{
				if(_organizationRoleUserCollectionViaCorporateUpload==null)
				{
					_organizationRoleUserCollectionViaCorporateUpload = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCorporateUpload.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCorporateUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer__==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCorporateTag
		{
			get
			{
				if(_organizationRoleUserCollectionViaCorporateTag==null)
				{
					_organizationRoleUserCollectionViaCorporateTag = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCorporateTag.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCorporateTag;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallRoundCallQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallRoundCallQueue==null)
				{
					_organizationRoleUserCollectionViaCallRoundCallQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallRoundCallQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallRoundCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCalls
		{
			get
			{
				if(_organizationRoleUserCollectionViaCalls==null)
				{
					_organizationRoleUserCollectionViaCalls = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCalls.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCalls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaign_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaign_==null)
				{
					_organizationRoleUserCollectionViaCampaign_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaign_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaign_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaign
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaign==null)
				{
					_organizationRoleUserCollectionViaCampaign = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaign.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaign;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer_==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventNote
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventNote==null)
				{
					_organizationRoleUserCollectionViaEventNote = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventNote.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEligibilityUpload
		{
			get
			{
				if(_organizationRoleUserCollectionViaEligibilityUpload==null)
				{
					_organizationRoleUserCollectionViaEligibilityUpload = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEligibilityUpload.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEligibilityUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomEventNotification
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomEventNotification==null)
				{
					_organizationRoleUserCollectionViaCustomEventNotification = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomEventNotification.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomEventNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueCustomer==null)
				{
					_organizationRoleUserCollectionViaCallQueueCustomer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaAccountPackage
		{
			get
			{
				if(_packageCollectionViaAccountPackage==null)
				{
					_packageCollectionViaAccountPackage = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaAccountPackage.IsReadOnly=true;
				}
				return _packageCollectionViaAccountPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetailsCollectionViaEventNote
		{
			get
			{
				if(_podDetailsCollectionViaEventNote==null)
				{
					_podDetailsCollectionViaEventNote = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetailsCollectionViaEventNote.IsReadOnly=true;
				}
				return _podDetailsCollectionViaEventNote;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCustomerEntity))]
		public virtual EntityCollection<ProspectCustomerEntity> ProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				if(_prospectCustomerCollectionViaCallQueueCustomer==null)
				{
					_prospectCustomerCollectionViaCallQueueCustomer = new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory)));
					_prospectCustomerCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _prospectCustomerCollectionViaCallQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'StateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(StateEntity))]
		public virtual EntityCollection<StateEntity> StateCollectionViaAccountCheckoutPhoneNumber
		{
			get
			{
				if(_stateCollectionViaAccountCheckoutPhoneNumber==null)
				{
					_stateCollectionViaAccountCheckoutPhoneNumber = new EntityCollection<StateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory)));
					_stateCollectionViaAccountCheckoutPhoneNumber.IsReadOnly=true;
				}
				return _stateCollectionViaAccountCheckoutPhoneNumber;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaAccountPcpResultTestDependency
		{
			get
			{
				if(_testCollectionViaAccountPcpResultTestDependency==null)
				{
					_testCollectionViaAccountPcpResultTestDependency = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaAccountPcpResultTestDependency.IsReadOnly=true;
				}
				return _testCollectionViaAccountPcpResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaAccountHealthPlanResultTestDependency
		{
			get
			{
				if(_testCollectionViaAccountHealthPlanResultTestDependency==null)
				{
					_testCollectionViaAccountHealthPlanResultTestDependency = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaAccountHealthPlanResultTestDependency.IsReadOnly=true;
				}
				return _testCollectionViaAccountHealthPlanResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaAccountCustomerResultTestDependency
		{
			get
			{
				if(_testCollectionViaAccountCustomerResultTestDependency==null)
				{
					_testCollectionViaAccountCustomerResultTestDependency = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaAccountCustomerResultTestDependency.IsReadOnly=true;
				}
				return _testCollectionViaAccountCustomerResultTestDependency;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaAccountNotReviewableTest
		{
			get
			{
				if(_testCollectionViaAccountNotReviewableTest==null)
				{
					_testCollectionViaAccountNotReviewableTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaAccountNotReviewableTest.IsReadOnly=true;
				}
				return _testCollectionViaAccountNotReviewableTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaAccountTest
		{
			get
			{
				if(_testCollectionViaAccountTest==null)
				{
					_testCollectionViaAccountTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaAccountTest.IsReadOnly=true;
				}
				return _testCollectionViaAccountTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ZipEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ZipEntity))]
		public virtual EntityCollection<ZipEntity> ZipCollectionViaAccountEventZipSubstitute
		{
			get
			{
				if(_zipCollectionViaAccountEventZipSubstitute==null)
				{
					_zipCollectionViaAccountEventZipSubstitute = new EntityCollection<ZipEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory)));
					_zipCollectionViaAccountEventZipSubstitute.IsReadOnly=true;
				}
				return _zipCollectionViaAccountEventZipSubstitute;
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListTemplateEntity CheckListTemplate_
		{
			get
			{
				return _checkListTemplate_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListTemplate_(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListTemplate_ != null)
						{
							_checkListTemplate_.UnsetRelatedEntity(this, "Account_");
						}
					}
					else
					{
						if(_checkListTemplate_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CheckListTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CheckListTemplateEntity CheckListTemplate
		{
			get
			{
				return _checkListTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCheckListTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_checkListTemplate != null)
						{
							_checkListTemplate.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_checkListTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EmailTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EmailTemplateEntity EmailTemplate_
		{
			get
			{
				return _emailTemplate_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEmailTemplate_(value);
				}
				else
				{
					if(value==null)
					{
						if(_emailTemplate_ != null)
						{
							_emailTemplate_.UnsetRelatedEntity(this, "Account_");
						}
					}
					else
					{
						if(_emailTemplate_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EmailTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EmailTemplateEntity EmailTemplate
		{
			get
			{
				return _emailTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEmailTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_emailTemplate != null)
						{
							_emailTemplate.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_emailTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EmailTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EmailTemplateEntity EmailTemplate__
		{
			get
			{
				return _emailTemplate__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEmailTemplate__(value);
				}
				else
				{
					if(value==null)
					{
						if(_emailTemplate__ != null)
						{
							_emailTemplate__.UnsetRelatedEntity(this, "Account__");
						}
					}
					else
					{
						if(_emailTemplate__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EmailTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EmailTemplateEntity EmailTemplate___
		{
			get
			{
				return _emailTemplate___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEmailTemplate___(value);
				}
				else
				{
					if(value==null)
					{
						if(_emailTemplate___ != null)
						{
							_emailTemplate___.UnsetRelatedEntity(this, "Account___");
						}
					}
					else
					{
						if(_emailTemplate___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account___");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File________
		{
			get
			{
				return _file________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile________(value);
				}
				else
				{
					if(value==null)
					{
						if(_file________ != null)
						{
							_file________.UnsetRelatedEntity(this, "Account________");
						}
					}
					else
					{
						if(_file________!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account________");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_____
		{
			get
			{
				return _file_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_____ != null)
						{
							_file_____.UnsetRelatedEntity(this, "Account_____");
						}
					}
					else
					{
						if(_file_____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account_____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File______
		{
			get
			{
				return _file______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile______(value);
				}
				else
				{
					if(value==null)
					{
						if(_file______ != null)
						{
							_file______.UnsetRelatedEntity(this, "Account______");
						}
					}
					else
					{
						if(_file______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account______");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_______
		{
			get
			{
				return _file_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_______ != null)
						{
							_file_______.UnsetRelatedEntity(this, "Account_______");
						}
					}
					else
					{
						if(_file_______!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account_______");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File____
		{
			get
			{
				return _file____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile____(value);
				}
				else
				{
					if(value==null)
					{
						if(_file____ != null)
						{
							_file____.UnsetRelatedEntity(this, "Account____");
						}
					}
					else
					{
						if(_file____!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account____");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File__
		{
			get
			{
				return _file__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile__(value);
				}
				else
				{
					if(value==null)
					{
						if(_file__ != null)
						{
							_file__.UnsetRelatedEntity(this, "Account__");
						}
					}
					else
					{
						if(_file__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account__");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File_
		{
			get
			{
				return _file_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile_(value);
				}
				else
				{
					if(value==null)
					{
						if(_file_ != null)
						{
							_file_.UnsetRelatedEntity(this, "Account_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File
		{
			get
			{
				return _file;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile(value);
				}
				else
				{
					if(value==null)
					{
						if(_file != null)
						{
							_file.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FileEntity File___
		{
			get
			{
				return _file___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFile___(value);
				}
				else
				{
					if(value==null)
					{
						if(_file___ != null)
						{
							_file___.UnsetRelatedEntity(this, "Account___");
						}
					}
					else
					{
						if(_file___!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account___");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FluConsentTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FluConsentTemplateEntity FluConsentTemplate
		{
			get
			{
				return _fluConsentTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFluConsentTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_fluConsentTemplate != null)
						{
							_fluConsentTemplate.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_fluConsentTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HafTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HafTemplateEntity HafTemplate
		{
			get
			{
				return _hafTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHafTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_hafTemplate != null)
						{
							_hafTemplate.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_hafTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup
		{
			get
			{
				return _lookup;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup != null)
						{
							_lookup.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectsEntity Prospects
		{
			get
			{
				return _prospects;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspects(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospects != null)
						{
							_prospects.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_prospects!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SurveyTemplateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SurveyTemplateEntity SurveyTemplate
		{
			get
			{
				return _surveyTemplate;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSurveyTemplate(value);
				}
				else
				{
					if(value==null)
					{
						if(_surveyTemplate != null)
						{
							_surveyTemplate.UnsetRelatedEntity(this, "Account");
						}
					}
					else
					{
						if(_surveyTemplate!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Account");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HealthPlanEventZipEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HealthPlanEventZipEntity HealthPlanEventZip
		{
			get
			{
				return _healthPlanEventZip;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHealthPlanEventZip(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Account");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_healthPlanEventZip !=null);
						DesetupSyncHealthPlanEventZip(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("HealthPlanEventZip");
						}
					}
					else
					{
						if(_healthPlanEventZip!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Account");
							SetupSyncHealthPlanEventZip(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationEntity Organization
		{
			get
			{
				return _organization;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganization(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Account");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_organization !=null);
						DesetupSyncOrganization(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Organization");
						}
					}
					else
					{
						if(_organization!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Account");
							SetupSyncOrganization(relatedEntity);
						}
					}
				}
			}
		}
	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the Falcon.Data.EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Falcon.Data.EntityType.AccountEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
