///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:48
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
	/// Entity class which represents the entity 'HafTemplate'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HafTemplateEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEntity> _account;
		private EntityCollection<ClinicalTestQualificationCriteriaEntity> _clinicalTestQualificationCriteria;
		private EntityCollection<CustomerClinicalQuestionAnswerEntity> _customerClinicalQuestionAnswer;
		private EntityCollection<EventPackageDetailsEntity> _eventPackageDetails;
		private EntityCollection<EventsEntity> _events;
		private EntityCollection<EventTestEntity> _eventTest;
		private EntityCollection<HafTemplateQuestionEntity> _hafTemplateQuestion;
		private EntityCollection<HospitalPartnerEntity> _hospitalPartner;
		private EntityCollection<PackageEntity> _package;
		private EntityCollection<TestEntity> _test;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount;
		private EntityCollection<CommunicationModeEntity> _communicationModeCollectionViaEvents;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<CustomerHealthQuestionsEntity> _customerHealthQuestionsCollectionViaHafTemplateQuestion;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount___;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount__;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventTest;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventPackageDetails;
		private EntityCollection<EventsEntity> _eventsCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<EventTypeEntity> _eventTypeCollectionViaEvents;
		private EntityCollection<FileEntity> _fileCollectionViaPackage;
		private EntityCollection<FileEntity> _fileCollectionViaAccount;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents____;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents___;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents__;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest_;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest_;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest__;
		private EntityCollection<LookupEntity> _lookupCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventTest__;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventPackageDetails;
		private EntityCollection<LookupEntity> _lookupCollectionViaTest;
		private EntityCollection<LookupEntity> _lookupCollectionViaPackage;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaEvents;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents____;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents___;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaClinicalTestQualificationCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents_;
		private EntityCollection<PackageEntity> _packageCollectionViaEventPackageDetails;
		private EntityCollection<PodRoomEntity> _podRoomCollectionViaEventPackageDetails;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplateCollectionViaTest;
		private EntityCollection<PreQualificationTestTemplateEntity> _preQualificationTestTemplateCollectionViaEventTest;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaAccount;
		private EntityCollection<ScheduleMethodEntity> _scheduleMethodCollectionViaEvents;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount;
		private EntityCollection<TestEntity> _testCollectionViaEventTest;
		private EntityCollection<TestEntity> _testCollectionViaClinicalTestQualificationCriteria;
		private LookupEntity _lookup_;
		private LookupEntity _lookup;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name ClinicalTestQualificationCriteria</summary>
			public static readonly string ClinicalTestQualificationCriteria = "ClinicalTestQualificationCriteria";
			/// <summary>Member name CustomerClinicalQuestionAnswer</summary>
			public static readonly string CustomerClinicalQuestionAnswer = "CustomerClinicalQuestionAnswer";
			/// <summary>Member name EventPackageDetails</summary>
			public static readonly string EventPackageDetails = "EventPackageDetails";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name EventTest</summary>
			public static readonly string EventTest = "EventTest";
			/// <summary>Member name HafTemplateQuestion</summary>
			public static readonly string HafTemplateQuestion = "HafTemplateQuestion";
			/// <summary>Member name HospitalPartner</summary>
			public static readonly string HospitalPartner = "HospitalPartner";
			/// <summary>Member name Package</summary>
			public static readonly string Package = "Package";
			/// <summary>Member name Test</summary>
			public static readonly string Test = "Test";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_ = "CheckListTemplateCollectionViaAccount_";
			/// <summary>Member name CheckListTemplateCollectionViaAccount</summary>
			public static readonly string CheckListTemplateCollectionViaAccount = "CheckListTemplateCollectionViaAccount";
			/// <summary>Member name CommunicationModeCollectionViaEvents</summary>
			public static readonly string CommunicationModeCollectionViaEvents = "CommunicationModeCollectionViaEvents";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer = "CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name CustomerHealthQuestionsCollectionViaHafTemplateQuestion</summary>
			public static readonly string CustomerHealthQuestionsCollectionViaHafTemplateQuestion = "CustomerHealthQuestionsCollectionViaHafTemplateQuestion";
			/// <summary>Member name CustomerProfileCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string CustomerProfileCollectionViaCustomerClinicalQuestionAnswer = "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name EmailTemplateCollectionViaAccount___</summary>
			public static readonly string EmailTemplateCollectionViaAccount___ = "EmailTemplateCollectionViaAccount___";
			/// <summary>Member name EmailTemplateCollectionViaAccount_</summary>
			public static readonly string EmailTemplateCollectionViaAccount_ = "EmailTemplateCollectionViaAccount_";
			/// <summary>Member name EmailTemplateCollectionViaAccount</summary>
			public static readonly string EmailTemplateCollectionViaAccount = "EmailTemplateCollectionViaAccount";
			/// <summary>Member name EmailTemplateCollectionViaAccount__</summary>
			public static readonly string EmailTemplateCollectionViaAccount__ = "EmailTemplateCollectionViaAccount__";
			/// <summary>Member name EventsCollectionViaEventTest</summary>
			public static readonly string EventsCollectionViaEventTest = "EventsCollectionViaEventTest";
			/// <summary>Member name EventsCollectionViaEventPackageDetails</summary>
			public static readonly string EventsCollectionViaEventPackageDetails = "EventsCollectionViaEventPackageDetails";
			/// <summary>Member name EventsCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string EventsCollectionViaCustomerClinicalQuestionAnswer = "EventsCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name EventTypeCollectionViaEvents</summary>
			public static readonly string EventTypeCollectionViaEvents = "EventTypeCollectionViaEvents";
			/// <summary>Member name FileCollectionViaPackage</summary>
			public static readonly string FileCollectionViaPackage = "FileCollectionViaPackage";
			/// <summary>Member name FileCollectionViaAccount</summary>
			public static readonly string FileCollectionViaAccount = "FileCollectionViaAccount";
			/// <summary>Member name FileCollectionViaAccount____</summary>
			public static readonly string FileCollectionViaAccount____ = "FileCollectionViaAccount____";
			/// <summary>Member name FileCollectionViaAccount_____</summary>
			public static readonly string FileCollectionViaAccount_____ = "FileCollectionViaAccount_____";
			/// <summary>Member name FileCollectionViaAccount__</summary>
			public static readonly string FileCollectionViaAccount__ = "FileCollectionViaAccount__";
			/// <summary>Member name FileCollectionViaAccount___</summary>
			public static readonly string FileCollectionViaAccount___ = "FileCollectionViaAccount___";
			/// <summary>Member name FileCollectionViaAccount_</summary>
			public static readonly string FileCollectionViaAccount_ = "FileCollectionViaAccount_";
			/// <summary>Member name FileCollectionViaAccount______</summary>
			public static readonly string FileCollectionViaAccount______ = "FileCollectionViaAccount______";
			/// <summary>Member name FileCollectionViaAccount________</summary>
			public static readonly string FileCollectionViaAccount________ = "FileCollectionViaAccount________";
			/// <summary>Member name FileCollectionViaAccount_______</summary>
			public static readonly string FileCollectionViaAccount_______ = "FileCollectionViaAccount_______";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount = "FluConsentTemplateCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaEventTest</summary>
			public static readonly string LookupCollectionViaEventTest = "LookupCollectionViaEventTest";
			/// <summary>Member name LookupCollectionViaEvents</summary>
			public static readonly string LookupCollectionViaEvents = "LookupCollectionViaEvents";
			/// <summary>Member name LookupCollectionViaEvents____</summary>
			public static readonly string LookupCollectionViaEvents____ = "LookupCollectionViaEvents____";
			/// <summary>Member name LookupCollectionViaEvents___</summary>
			public static readonly string LookupCollectionViaEvents___ = "LookupCollectionViaEvents___";
			/// <summary>Member name LookupCollectionViaEvents__</summary>
			public static readonly string LookupCollectionViaEvents__ = "LookupCollectionViaEvents__";
			/// <summary>Member name LookupCollectionViaEvents_</summary>
			public static readonly string LookupCollectionViaEvents_ = "LookupCollectionViaEvents_";
			/// <summary>Member name LookupCollectionViaEventTest_</summary>
			public static readonly string LookupCollectionViaEventTest_ = "LookupCollectionViaEventTest_";
			/// <summary>Member name LookupCollectionViaTest_</summary>
			public static readonly string LookupCollectionViaTest_ = "LookupCollectionViaTest_";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria = "LookupCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name LookupCollectionViaAccount</summary>
			public static readonly string LookupCollectionViaAccount = "LookupCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaTest__</summary>
			public static readonly string LookupCollectionViaTest__ = "LookupCollectionViaTest__";
			/// <summary>Member name LookupCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string LookupCollectionViaClinicalTestQualificationCriteria_ = "LookupCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name LookupCollectionViaEventTest__</summary>
			public static readonly string LookupCollectionViaEventTest__ = "LookupCollectionViaEventTest__";
			/// <summary>Member name LookupCollectionViaEventPackageDetails</summary>
			public static readonly string LookupCollectionViaEventPackageDetails = "LookupCollectionViaEventPackageDetails";
			/// <summary>Member name LookupCollectionViaTest</summary>
			public static readonly string LookupCollectionViaTest = "LookupCollectionViaTest";
			/// <summary>Member name LookupCollectionViaPackage</summary>
			public static readonly string LookupCollectionViaPackage = "LookupCollectionViaPackage";
			/// <summary>Member name NotesDetailsCollectionViaEvents</summary>
			public static readonly string NotesDetailsCollectionViaEvents = "NotesDetailsCollectionViaEvents";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents____</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents____ = "OrganizationRoleUserCollectionViaEvents____";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents = "OrganizationRoleUserCollectionViaEvents";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents__ = "OrganizationRoleUserCollectionViaEvents__";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents___</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents___ = "OrganizationRoleUserCollectionViaEvents___";
			/// <summary>Member name OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria = "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents_ = "OrganizationRoleUserCollectionViaEvents_";
			/// <summary>Member name PackageCollectionViaEventPackageDetails</summary>
			public static readonly string PackageCollectionViaEventPackageDetails = "PackageCollectionViaEventPackageDetails";
			/// <summary>Member name PodRoomCollectionViaEventPackageDetails</summary>
			public static readonly string PodRoomCollectionViaEventPackageDetails = "PodRoomCollectionViaEventPackageDetails";
			/// <summary>Member name PreQualificationTestTemplateCollectionViaTest</summary>
			public static readonly string PreQualificationTestTemplateCollectionViaTest = "PreQualificationTestTemplateCollectionViaTest";
			/// <summary>Member name PreQualificationTestTemplateCollectionViaEventTest</summary>
			public static readonly string PreQualificationTestTemplateCollectionViaEventTest = "PreQualificationTestTemplateCollectionViaEventTest";
			/// <summary>Member name ProspectsCollectionViaAccount</summary>
			public static readonly string ProspectsCollectionViaAccount = "ProspectsCollectionViaAccount";
			/// <summary>Member name ScheduleMethodCollectionViaEvents</summary>
			public static readonly string ScheduleMethodCollectionViaEvents = "ScheduleMethodCollectionViaEvents";
			/// <summary>Member name SurveyTemplateCollectionViaAccount</summary>
			public static readonly string SurveyTemplateCollectionViaAccount = "SurveyTemplateCollectionViaAccount";
			/// <summary>Member name TestCollectionViaEventTest</summary>
			public static readonly string TestCollectionViaEventTest = "TestCollectionViaEventTest";
			/// <summary>Member name TestCollectionViaClinicalTestQualificationCriteria</summary>
			public static readonly string TestCollectionViaClinicalTestQualificationCriteria = "TestCollectionViaClinicalTestQualificationCriteria";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HafTemplateEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HafTemplateEntity():base("HafTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HafTemplateEntity(IEntityFields2 fields):base("HafTemplateEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HafTemplateEntity</param>
		public HafTemplateEntity(IValidator validator):base("HafTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="haftemplateId">PK value for HafTemplate which data should be fetched into this HafTemplate object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HafTemplateEntity(System.Int64 haftemplateId):base("HafTemplateEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.HaftemplateId = haftemplateId;
		}

		/// <summary> CTor</summary>
		/// <param name="haftemplateId">PK value for HafTemplate which data should be fetched into this HafTemplate object</param>
		/// <param name="validator">The custom validator object for this HafTemplateEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HafTemplateEntity(System.Int64 haftemplateId, IValidator validator):base("HafTemplateEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.HaftemplateId = haftemplateId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HafTemplateEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_account = (EntityCollection<AccountEntity>)info.GetValue("_account", typeof(EntityCollection<AccountEntity>));
				_clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>)info.GetValue("_clinicalTestQualificationCriteria", typeof(EntityCollection<ClinicalTestQualificationCriteriaEntity>));
				_customerClinicalQuestionAnswer = (EntityCollection<CustomerClinicalQuestionAnswerEntity>)info.GetValue("_customerClinicalQuestionAnswer", typeof(EntityCollection<CustomerClinicalQuestionAnswerEntity>));
				_eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>)info.GetValue("_eventPackageDetails", typeof(EntityCollection<EventPackageDetailsEntity>));
				_events = (EntityCollection<EventsEntity>)info.GetValue("_events", typeof(EntityCollection<EventsEntity>));
				_eventTest = (EntityCollection<EventTestEntity>)info.GetValue("_eventTest", typeof(EntityCollection<EventTestEntity>));
				_hafTemplateQuestion = (EntityCollection<HafTemplateQuestionEntity>)info.GetValue("_hafTemplateQuestion", typeof(EntityCollection<HafTemplateQuestionEntity>));
				_hospitalPartner = (EntityCollection<HospitalPartnerEntity>)info.GetValue("_hospitalPartner", typeof(EntityCollection<HospitalPartnerEntity>));
				_package = (EntityCollection<PackageEntity>)info.GetValue("_package", typeof(EntityCollection<PackageEntity>));
				_test = (EntityCollection<TestEntity>)info.GetValue("_test", typeof(EntityCollection<TestEntity>));
				_checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount", typeof(EntityCollection<CheckListTemplateEntity>));
				_communicationModeCollectionViaEvents = (EntityCollection<CommunicationModeEntity>)info.GetValue("_communicationModeCollectionViaEvents", typeof(EntityCollection<CommunicationModeEntity>));
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerHealthQuestionsCollectionViaHafTemplateQuestion = (EntityCollection<CustomerHealthQuestionsEntity>)info.GetValue("_customerHealthQuestionsCollectionViaHafTemplateQuestion", typeof(EntityCollection<CustomerHealthQuestionsEntity>));
				_customerProfileCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<CustomerProfileEntity>));
				_emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount___", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount__", typeof(EntityCollection<EmailTemplateEntity>));
				_eventsCollectionViaEventTest = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventTest", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventPackageDetails", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<EventsEntity>));
				_eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>)info.GetValue("_eventTypeCollectionViaEvents", typeof(EntityCollection<EventTypeEntity>));
				_fileCollectionViaPackage = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaPackage", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______", typeof(EntityCollection<FileEntity>));
				_fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount", typeof(EntityCollection<FluConsentTemplateEntity>));
				_lookupCollectionViaEventTest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTest_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccount = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTest__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventTest__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventPackageDetails", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaTest = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaTest", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaPackage = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaPackage", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaEvents = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaEvents", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents____", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents___", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_packageCollectionViaEventPackageDetails = (EntityCollection<PackageEntity>)info.GetValue("_packageCollectionViaEventPackageDetails", typeof(EntityCollection<PackageEntity>));
				_podRoomCollectionViaEventPackageDetails = (EntityCollection<PodRoomEntity>)info.GetValue("_podRoomCollectionViaEventPackageDetails", typeof(EntityCollection<PodRoomEntity>));
				_preQualificationTestTemplateCollectionViaTest = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplateCollectionViaTest", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_preQualificationTestTemplateCollectionViaEventTest = (EntityCollection<PreQualificationTestTemplateEntity>)info.GetValue("_preQualificationTestTemplateCollectionViaEventTest", typeof(EntityCollection<PreQualificationTestTemplateEntity>));
				_prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaAccount", typeof(EntityCollection<ProspectsEntity>));
				_scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>)info.GetValue("_scheduleMethodCollectionViaEvents", typeof(EntityCollection<ScheduleMethodEntity>));
				_surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount", typeof(EntityCollection<SurveyTemplateEntity>));
				_testCollectionViaEventTest = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaEventTest", typeof(EntityCollection<TestEntity>));
				_testCollectionViaClinicalTestQualificationCriteria = (EntityCollection<TestEntity>)info.GetValue("_testCollectionViaClinicalTestQualificationCriteria", typeof(EntityCollection<TestEntity>));
				_lookup_ = (LookupEntity)info.GetValue("_lookup_", typeof(LookupEntity));
				if(_lookup_!=null)
				{
					_lookup_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HafTemplateFieldIndex)fieldIndex)
			{
				case HafTemplateFieldIndex.Type:
					DesetupSyncLookup(true, false);
					break;
				case HafTemplateFieldIndex.CreatedBy:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case HafTemplateFieldIndex.ModifiedBy:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case HafTemplateFieldIndex.Category:
					DesetupSyncLookup_(true, false);
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
				case "Lookup_":
					this.Lookup_ = (LookupEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Account":
					this.Account.Add((AccountEntity)entity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)entity);
					break;
				case "CustomerClinicalQuestionAnswer":
					this.CustomerClinicalQuestionAnswer.Add((CustomerClinicalQuestionAnswerEntity)entity);
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)entity);
					break;
				case "Events":
					this.Events.Add((EventsEntity)entity);
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)entity);
					break;
				case "HafTemplateQuestion":
					this.HafTemplateQuestion.Add((HafTemplateQuestionEntity)entity);
					break;
				case "HospitalPartner":
					this.HospitalPartner.Add((HospitalPartnerEntity)entity);
					break;
				case "Package":
					this.Package.Add((PackageEntity)entity);
					break;
				case "Test":
					this.Test.Add((TestEntity)entity);
					break;
				case "CheckListTemplateCollectionViaAccount_":
					this.CheckListTemplateCollectionViaAccount_.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount_.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "CheckListTemplateCollectionViaAccount":
					this.CheckListTemplateCollectionViaAccount.IsReadOnly = false;
					this.CheckListTemplateCollectionViaAccount.Add((CheckListTemplateEntity)entity);
					this.CheckListTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "CommunicationModeCollectionViaEvents":
					this.CommunicationModeCollectionViaEvents.IsReadOnly = false;
					this.CommunicationModeCollectionViaEvents.Add((CommunicationModeEntity)entity);
					this.CommunicationModeCollectionViaEvents.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria":
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_":
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer":
					this.CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "CustomerHealthQuestionsCollectionViaHafTemplateQuestion":
					this.CustomerHealthQuestionsCollectionViaHafTemplateQuestion.IsReadOnly = false;
					this.CustomerHealthQuestionsCollectionViaHafTemplateQuestion.Add((CustomerHealthQuestionsEntity)entity);
					this.CustomerHealthQuestionsCollectionViaHafTemplateQuestion.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer":
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount___":
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount___.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_":
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount":
					this.EmailTemplateCollectionViaAccount.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount__":
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount__.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventTest":
					this.EventsCollectionViaEventTest.IsReadOnly = false;
					this.EventsCollectionViaEventTest.Add((EventsEntity)entity);
					this.EventsCollectionViaEventTest.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventPackageDetails":
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = false;
					this.EventsCollectionViaEventPackageDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "EventsCollectionViaCustomerClinicalQuestionAnswer":
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.Add((EventsEntity)entity);
					this.EventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "EventTypeCollectionViaEvents":
					this.EventTypeCollectionViaEvents.IsReadOnly = false;
					this.EventTypeCollectionViaEvents.Add((EventTypeEntity)entity);
					this.EventTypeCollectionViaEvents.IsReadOnly = true;
					break;
				case "FileCollectionViaPackage":
					this.FileCollectionViaPackage.IsReadOnly = false;
					this.FileCollectionViaPackage.Add((FileEntity)entity);
					this.FileCollectionViaPackage.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount":
					this.FileCollectionViaAccount.IsReadOnly = false;
					this.FileCollectionViaAccount.Add((FileEntity)entity);
					this.FileCollectionViaAccount.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____":
					this.FileCollectionViaAccount____.IsReadOnly = false;
					this.FileCollectionViaAccount____.Add((FileEntity)entity);
					this.FileCollectionViaAccount____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____":
					this.FileCollectionViaAccount_____.IsReadOnly = false;
					this.FileCollectionViaAccount_____.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__":
					this.FileCollectionViaAccount__.IsReadOnly = false;
					this.FileCollectionViaAccount__.Add((FileEntity)entity);
					this.FileCollectionViaAccount__.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___":
					this.FileCollectionViaAccount___.IsReadOnly = false;
					this.FileCollectionViaAccount___.Add((FileEntity)entity);
					this.FileCollectionViaAccount___.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_":
					this.FileCollectionViaAccount_.IsReadOnly = false;
					this.FileCollectionViaAccount_.Add((FileEntity)entity);
					this.FileCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______":
					this.FileCollectionViaAccount______.IsReadOnly = false;
					this.FileCollectionViaAccount______.Add((FileEntity)entity);
					this.FileCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________":
					this.FileCollectionViaAccount________.IsReadOnly = false;
					this.FileCollectionViaAccount________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______":
					this.FileCollectionViaAccount_______.IsReadOnly = false;
					this.FileCollectionViaAccount_______.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount":
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest":
					this.LookupCollectionViaEventTest.IsReadOnly = false;
					this.LookupCollectionViaEventTest.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents":
					this.LookupCollectionViaEvents.IsReadOnly = false;
					this.LookupCollectionViaEvents.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents____":
					this.LookupCollectionViaEvents____.IsReadOnly = false;
					this.LookupCollectionViaEvents____.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents____.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents___":
					this.LookupCollectionViaEvents___.IsReadOnly = false;
					this.LookupCollectionViaEvents___.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents___.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents__":
					this.LookupCollectionViaEvents__.IsReadOnly = false;
					this.LookupCollectionViaEvents__.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents__.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents_":
					this.LookupCollectionViaEvents_.IsReadOnly = false;
					this.LookupCollectionViaEvents_.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest_":
					this.LookupCollectionViaEventTest_.IsReadOnly = false;
					this.LookupCollectionViaEventTest_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest_.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest_":
					this.LookupCollectionViaTest_.IsReadOnly = false;
					this.LookupCollectionViaTest_.Add((LookupEntity)entity);
					this.LookupCollectionViaTest_.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount":
					this.LookupCollectionViaAccount.IsReadOnly = false;
					this.LookupCollectionViaAccount.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest__":
					this.LookupCollectionViaTest__.IsReadOnly = false;
					this.LookupCollectionViaTest__.Add((LookupEntity)entity);
					this.LookupCollectionViaTest__.IsReadOnly = true;
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.LookupCollectionViaClinicalTestQualificationCriteria_.Add((LookupEntity)entity);
					this.LookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventTest__":
					this.LookupCollectionViaEventTest__.IsReadOnly = false;
					this.LookupCollectionViaEventTest__.Add((LookupEntity)entity);
					this.LookupCollectionViaEventTest__.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventPackageDetails":
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = false;
					this.LookupCollectionViaEventPackageDetails.Add((LookupEntity)entity);
					this.LookupCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "LookupCollectionViaTest":
					this.LookupCollectionViaTest.IsReadOnly = false;
					this.LookupCollectionViaTest.Add((LookupEntity)entity);
					this.LookupCollectionViaTest.IsReadOnly = true;
					break;
				case "LookupCollectionViaPackage":
					this.LookupCollectionViaPackage.IsReadOnly = false;
					this.LookupCollectionViaPackage.Add((LookupEntity)entity);
					this.LookupCollectionViaPackage.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaEvents":
					this.NotesDetailsCollectionViaEvents.IsReadOnly = false;
					this.NotesDetailsCollectionViaEvents.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaEvents.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents____.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_":
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer":
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents___.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = true;
					break;
				case "PackageCollectionViaEventPackageDetails":
					this.PackageCollectionViaEventPackageDetails.IsReadOnly = false;
					this.PackageCollectionViaEventPackageDetails.Add((PackageEntity)entity);
					this.PackageCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "PodRoomCollectionViaEventPackageDetails":
					this.PodRoomCollectionViaEventPackageDetails.IsReadOnly = false;
					this.PodRoomCollectionViaEventPackageDetails.Add((PodRoomEntity)entity);
					this.PodRoomCollectionViaEventPackageDetails.IsReadOnly = true;
					break;
				case "PreQualificationTestTemplateCollectionViaTest":
					this.PreQualificationTestTemplateCollectionViaTest.IsReadOnly = false;
					this.PreQualificationTestTemplateCollectionViaTest.Add((PreQualificationTestTemplateEntity)entity);
					this.PreQualificationTestTemplateCollectionViaTest.IsReadOnly = true;
					break;
				case "PreQualificationTestTemplateCollectionViaEventTest":
					this.PreQualificationTestTemplateCollectionViaEventTest.IsReadOnly = false;
					this.PreQualificationTestTemplateCollectionViaEventTest.Add((PreQualificationTestTemplateEntity)entity);
					this.PreQualificationTestTemplateCollectionViaEventTest.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaAccount":
					this.ProspectsCollectionViaAccount.IsReadOnly = false;
					this.ProspectsCollectionViaAccount.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaAccount.IsReadOnly = true;
					break;
				case "ScheduleMethodCollectionViaEvents":
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = false;
					this.ScheduleMethodCollectionViaEvents.Add((ScheduleMethodEntity)entity);
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount":
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "TestCollectionViaEventTest":
					this.TestCollectionViaEventTest.IsReadOnly = false;
					this.TestCollectionViaEventTest.Add((TestEntity)entity);
					this.TestCollectionViaEventTest.IsReadOnly = true;
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria":
					this.TestCollectionViaClinicalTestQualificationCriteria.IsReadOnly = false;
					this.TestCollectionViaClinicalTestQualificationCriteria.Add((TestEntity)entity);
					this.TestCollectionViaClinicalTestQualificationCriteria.IsReadOnly = true;
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
			return HafTemplateEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Lookup_":
					toReturn.Add(HafTemplateEntity.Relations.LookupEntityUsingCategory);
					break;
				case "Lookup":
					toReturn.Add(HafTemplateEntity.Relations.LookupEntityUsingType);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy);
					break;
				case "Account":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId);
					break;
				case "ClinicalTestQualificationCriteria":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId);
					break;
				case "CustomerClinicalQuestionAnswer":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId);
					break;
				case "EventPackageDetails":
					toReturn.Add(HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId);
					break;
				case "Events":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId);
					break;
				case "EventTest":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId);
					break;
				case "HafTemplateQuestion":
					toReturn.Add(HafTemplateEntity.Relations.HafTemplateQuestionEntityUsingHaftemplateId);
					break;
				case "HospitalPartner":
					toReturn.Add(HafTemplateEntity.Relations.HospitalPartnerEntityUsingHafTemplateId);
					break;
				case "Package":
					toReturn.Add(HafTemplateEntity.Relations.PackageEntityUsingHafTemplateId);
					break;
				case "Test":
					toReturn.Add(HafTemplateEntity.Relations.TestEntityUsingHafTemplateId);
					break;
				case "CheckListTemplateCollectionViaAccount_":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CommunicationModeCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.CommunicationModeEntityUsingCommunicationModeId, "Events_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.CustomerHealthQuestionsEntityUsingMedicationQuestionId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.CustomerHealthQuestionsEntityUsingDisqualifierQuestionId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.CustomerHealthQuestionsEntityUsingClinicalHealthQuestionId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "CustomerHealthQuestionsCollectionViaHafTemplateQuestion":
					toReturn.Add(HafTemplateEntity.Relations.HafTemplateQuestionEntityUsingHaftemplateId, "HafTemplateEntity__", "HafTemplateQuestion_", JoinHint.None);
					toReturn.Add(HafTemplateQuestionEntity.Relations.CustomerHealthQuestionsEntityUsingQuestionId, "HafTemplateQuestion_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount___":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount__":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventTest":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.EventsEntityUsingEventId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventPackageDetails":
					toReturn.Add(HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId, "HafTemplateEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.EventsEntityUsingEventId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.EventsEntityUsingEventId, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "EventTypeCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.EventTypeEntityUsingEventTypeId, "Events_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaPackage":
					toReturn.Add(HafTemplateEntity.Relations.PackageEntityUsingHafTemplateId, "HafTemplateEntity__", "Package_", JoinHint.None);
					toReturn.Add(PackageEntity.Relations.FileEntityUsingForOrderDisplayFileId, "Package_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGender, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateKynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents____":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHealthAssesmentFormStatus, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents___":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateMyBioCheckAssessment, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents__":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHkynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents_":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingEventCancellationReasonId, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest_":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingGroupId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest_":
					toReturn.Add(HafTemplateEntity.Relations.TestEntityUsingHafTemplateId, "HafTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGroupId, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingAgeCondition, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest__":
					toReturn.Add(HafTemplateEntity.Relations.TestEntityUsingHafTemplateId, "HafTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingResultEntryTypeId, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.LookupEntityUsingGender, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventTest__":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.LookupEntityUsingResultEntryTypeId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventPackageDetails":
					toReturn.Add(HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId, "HafTemplateEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.LookupEntityUsingGender, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaTest":
					toReturn.Add(HafTemplateEntity.Relations.TestEntityUsingHafTemplateId, "HafTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.LookupEntityUsingGender, "Test_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaPackage":
					toReturn.Add(HafTemplateEntity.Relations.PackageEntityUsingHafTemplateId, "HafTemplateEntity__", "Package_", JoinHint.None);
					toReturn.Add(PackageEntity.Relations.LookupEntityUsingGender, "Package_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.NotesDetailsEntityUsingEmrNotesId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByAdmin, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer":
					toReturn.Add(HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "CustomerClinicalQuestionAnswer_", JoinHint.None);
					toReturn.Add(CustomerClinicalQuestionAnswerEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomerClinicalQuestionAnswer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingEventActivityOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingSignOffOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "PackageCollectionViaEventPackageDetails":
					toReturn.Add(HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId, "HafTemplateEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.PackageEntityUsingPackageId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "PodRoomCollectionViaEventPackageDetails":
					toReturn.Add(HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId, "HafTemplateEntity__", "EventPackageDetails_", JoinHint.None);
					toReturn.Add(EventPackageDetailsEntity.Relations.PodRoomEntityUsingPodRoomId, "EventPackageDetails_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationTestTemplateCollectionViaTest":
					toReturn.Add(HafTemplateEntity.Relations.TestEntityUsingHafTemplateId, "HafTemplateEntity__", "Test_", JoinHint.None);
					toReturn.Add(TestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, "Test_", string.Empty, JoinHint.None);
					break;
				case "PreQualificationTestTemplateCollectionViaEventTest":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.PreQualificationTestTemplateEntityUsingPreQualificationQuestionTemplateId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.ProspectsEntityUsingConvertedHostId, "Account_", string.Empty, JoinHint.None);
					break;
				case "ScheduleMethodCollectionViaEvents":
					toReturn.Add(HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId, "HafTemplateEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.ScheduleMethodEntityUsingScheduleMethodId, "Events_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount":
					toReturn.Add(HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId, "HafTemplateEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaEventTest":
					toReturn.Add(HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId, "HafTemplateEntity__", "EventTest_", JoinHint.None);
					toReturn.Add(EventTestEntity.Relations.TestEntityUsingTestId, "EventTest_", string.Empty, JoinHint.None);
					break;
				case "TestCollectionViaClinicalTestQualificationCriteria":
					toReturn.Add(HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId, "HafTemplateEntity__", "ClinicalTestQualificationCriteria_", JoinHint.None);
					toReturn.Add(ClinicalTestQualificationCriteriaEntity.Relations.TestEntityUsingTestId, "ClinicalTestQualificationCriteria_", string.Empty, JoinHint.None);
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
				case "Lookup_":
					SetupSyncLookup_(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)relatedEntity);
					break;
				case "ClinicalTestQualificationCriteria":
					this.ClinicalTestQualificationCriteria.Add((ClinicalTestQualificationCriteriaEntity)relatedEntity);
					break;
				case "CustomerClinicalQuestionAnswer":
					this.CustomerClinicalQuestionAnswer.Add((CustomerClinicalQuestionAnswerEntity)relatedEntity);
					break;
				case "EventPackageDetails":
					this.EventPackageDetails.Add((EventPackageDetailsEntity)relatedEntity);
					break;
				case "Events":
					this.Events.Add((EventsEntity)relatedEntity);
					break;
				case "EventTest":
					this.EventTest.Add((EventTestEntity)relatedEntity);
					break;
				case "HafTemplateQuestion":
					this.HafTemplateQuestion.Add((HafTemplateQuestionEntity)relatedEntity);
					break;
				case "HospitalPartner":
					this.HospitalPartner.Add((HospitalPartnerEntity)relatedEntity);
					break;
				case "Package":
					this.Package.Add((PackageEntity)relatedEntity);
					break;
				case "Test":
					this.Test.Add((TestEntity)relatedEntity);
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
				case "Lookup_":
					DesetupSyncLookup_(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Account":
					base.PerformRelatedEntityRemoval(this.Account, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ClinicalTestQualificationCriteria":
					base.PerformRelatedEntityRemoval(this.ClinicalTestQualificationCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerClinicalQuestionAnswer":
					base.PerformRelatedEntityRemoval(this.CustomerClinicalQuestionAnswer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventPackageDetails":
					base.PerformRelatedEntityRemoval(this.EventPackageDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Events":
					base.PerformRelatedEntityRemoval(this.Events, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventTest":
					base.PerformRelatedEntityRemoval(this.EventTest, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HafTemplateQuestion":
					base.PerformRelatedEntityRemoval(this.HafTemplateQuestion, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HospitalPartner":
					base.PerformRelatedEntityRemoval(this.HospitalPartner, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Package":
					base.PerformRelatedEntityRemoval(this.Package, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Test":
					base.PerformRelatedEntityRemoval(this.Test, relatedEntity, signalRelatedEntityManyToOne);
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

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_lookup_!=null)
			{
				toReturn.Add(_lookup_);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Account);
			toReturn.Add(this.ClinicalTestQualificationCriteria);
			toReturn.Add(this.CustomerClinicalQuestionAnswer);
			toReturn.Add(this.EventPackageDetails);
			toReturn.Add(this.Events);
			toReturn.Add(this.EventTest);
			toReturn.Add(this.HafTemplateQuestion);
			toReturn.Add(this.HospitalPartner);
			toReturn.Add(this.Package);
			toReturn.Add(this.Test);

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
				info.AddValue("_account", ((_account!=null) && (_account.Count>0) && !this.MarkedForDeletion)?_account:null);
				info.AddValue("_clinicalTestQualificationCriteria", ((_clinicalTestQualificationCriteria!=null) && (_clinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_clinicalTestQualificationCriteria:null);
				info.AddValue("_customerClinicalQuestionAnswer", ((_customerClinicalQuestionAnswer!=null) && (_customerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerClinicalQuestionAnswer:null);
				info.AddValue("_eventPackageDetails", ((_eventPackageDetails!=null) && (_eventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventPackageDetails:null);
				info.AddValue("_events", ((_events!=null) && (_events.Count>0) && !this.MarkedForDeletion)?_events:null);
				info.AddValue("_eventTest", ((_eventTest!=null) && (_eventTest.Count>0) && !this.MarkedForDeletion)?_eventTest:null);
				info.AddValue("_hafTemplateQuestion", ((_hafTemplateQuestion!=null) && (_hafTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_hafTemplateQuestion:null);
				info.AddValue("_hospitalPartner", ((_hospitalPartner!=null) && (_hospitalPartner.Count>0) && !this.MarkedForDeletion)?_hospitalPartner:null);
				info.AddValue("_package", ((_package!=null) && (_package.Count>0) && !this.MarkedForDeletion)?_package:null);
				info.AddValue("_test", ((_test!=null) && (_test.Count>0) && !this.MarkedForDeletion)?_test:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_", ((_checkListTemplateCollectionViaAccount_!=null) && (_checkListTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_:null);
				info.AddValue("_checkListTemplateCollectionViaAccount", ((_checkListTemplateCollectionViaAccount!=null) && (_checkListTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount:null);
				info.AddValue("_communicationModeCollectionViaEvents", ((_communicationModeCollectionViaEvents!=null) && (_communicationModeCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_communicationModeCollectionViaEvents:null);
				info.AddValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", ((_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria!=null) && (_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", ((_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_!=null) && (_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer", ((_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer!=null) && (_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_customerHealthQuestionsCollectionViaHafTemplateQuestion", ((_customerHealthQuestionsCollectionViaHafTemplateQuestion!=null) && (_customerHealthQuestionsCollectionViaHafTemplateQuestion.Count>0) && !this.MarkedForDeletion)?_customerHealthQuestionsCollectionViaHafTemplateQuestion:null);
				info.AddValue("_customerProfileCollectionViaCustomerClinicalQuestionAnswer", ((_customerProfileCollectionViaCustomerClinicalQuestionAnswer!=null) && (_customerProfileCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_emailTemplateCollectionViaAccount___", ((_emailTemplateCollectionViaAccount___!=null) && (_emailTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount___:null);
				info.AddValue("_emailTemplateCollectionViaAccount_", ((_emailTemplateCollectionViaAccount_!=null) && (_emailTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_:null);
				info.AddValue("_emailTemplateCollectionViaAccount", ((_emailTemplateCollectionViaAccount!=null) && (_emailTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount:null);
				info.AddValue("_emailTemplateCollectionViaAccount__", ((_emailTemplateCollectionViaAccount__!=null) && (_emailTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount__:null);
				info.AddValue("_eventsCollectionViaEventTest", ((_eventsCollectionViaEventTest!=null) && (_eventsCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventTest:null);
				info.AddValue("_eventsCollectionViaEventPackageDetails", ((_eventsCollectionViaEventPackageDetails!=null) && (_eventsCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventPackageDetails:null);
				info.AddValue("_eventsCollectionViaCustomerClinicalQuestionAnswer", ((_eventsCollectionViaCustomerClinicalQuestionAnswer!=null) && (_eventsCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_eventTypeCollectionViaEvents", ((_eventTypeCollectionViaEvents!=null) && (_eventTypeCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_eventTypeCollectionViaEvents:null);
				info.AddValue("_fileCollectionViaPackage", ((_fileCollectionViaPackage!=null) && (_fileCollectionViaPackage.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaPackage:null);
				info.AddValue("_fileCollectionViaAccount", ((_fileCollectionViaAccount!=null) && (_fileCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount:null);
				info.AddValue("_fileCollectionViaAccount____", ((_fileCollectionViaAccount____!=null) && (_fileCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____:null);
				info.AddValue("_fileCollectionViaAccount_____", ((_fileCollectionViaAccount_____!=null) && (_fileCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____:null);
				info.AddValue("_fileCollectionViaAccount__", ((_fileCollectionViaAccount__!=null) && (_fileCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__:null);
				info.AddValue("_fileCollectionViaAccount___", ((_fileCollectionViaAccount___!=null) && (_fileCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___:null);
				info.AddValue("_fileCollectionViaAccount_", ((_fileCollectionViaAccount_!=null) && (_fileCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_:null);
				info.AddValue("_fileCollectionViaAccount______", ((_fileCollectionViaAccount______!=null) && (_fileCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______:null);
				info.AddValue("_fileCollectionViaAccount________", ((_fileCollectionViaAccount________!=null) && (_fileCollectionViaAccount________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________:null);
				info.AddValue("_fileCollectionViaAccount_______", ((_fileCollectionViaAccount_______!=null) && (_fileCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount", ((_fluConsentTemplateCollectionViaAccount!=null) && (_fluConsentTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaEventTest", ((_lookupCollectionViaEventTest!=null) && (_lookupCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest:null);
				info.AddValue("_lookupCollectionViaEvents", ((_lookupCollectionViaEvents!=null) && (_lookupCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents:null);
				info.AddValue("_lookupCollectionViaEvents____", ((_lookupCollectionViaEvents____!=null) && (_lookupCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents____:null);
				info.AddValue("_lookupCollectionViaEvents___", ((_lookupCollectionViaEvents___!=null) && (_lookupCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents___:null);
				info.AddValue("_lookupCollectionViaEvents__", ((_lookupCollectionViaEvents__!=null) && (_lookupCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents__:null);
				info.AddValue("_lookupCollectionViaEvents_", ((_lookupCollectionViaEvents_!=null) && (_lookupCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents_:null);
				info.AddValue("_lookupCollectionViaEventTest_", ((_lookupCollectionViaEventTest_!=null) && (_lookupCollectionViaEventTest_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest_:null);
				info.AddValue("_lookupCollectionViaTest_", ((_lookupCollectionViaTest_!=null) && (_lookupCollectionViaTest_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest_:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria", ((_lookupCollectionViaClinicalTestQualificationCriteria!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_lookupCollectionViaAccount", ((_lookupCollectionViaAccount!=null) && (_lookupCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaTest__", ((_lookupCollectionViaTest__!=null) && (_lookupCollectionViaTest__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest__:null);
				info.AddValue("_lookupCollectionViaClinicalTestQualificationCriteria_", ((_lookupCollectionViaClinicalTestQualificationCriteria_!=null) && (_lookupCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_lookupCollectionViaEventTest__", ((_lookupCollectionViaEventTest__!=null) && (_lookupCollectionViaEventTest__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventTest__:null);
				info.AddValue("_lookupCollectionViaEventPackageDetails", ((_lookupCollectionViaEventPackageDetails!=null) && (_lookupCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventPackageDetails:null);
				info.AddValue("_lookupCollectionViaTest", ((_lookupCollectionViaTest!=null) && (_lookupCollectionViaTest.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaTest:null);
				info.AddValue("_lookupCollectionViaPackage", ((_lookupCollectionViaPackage!=null) && (_lookupCollectionViaPackage.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaPackage:null);
				info.AddValue("_notesDetailsCollectionViaEvents", ((_notesDetailsCollectionViaEvents!=null) && (_notesDetailsCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaEvents:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents____", ((_organizationRoleUserCollectionViaEvents____!=null) && (_organizationRoleUserCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents____:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", ((_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_!=null) && (_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents", ((_organizationRoleUserCollectionViaEvents!=null) && (_organizationRoleUserCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", ((_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer!=null) && (_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents__", ((_organizationRoleUserCollectionViaEvents__!=null) && (_organizationRoleUserCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents__:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents___", ((_organizationRoleUserCollectionViaEvents___!=null) && (_organizationRoleUserCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents___:null);
				info.AddValue("_organizationRoleUserCollectionViaClinicalTestQualificationCriteria", ((_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null) && (_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents_", ((_organizationRoleUserCollectionViaEvents_!=null) && (_organizationRoleUserCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents_:null);
				info.AddValue("_packageCollectionViaEventPackageDetails", ((_packageCollectionViaEventPackageDetails!=null) && (_packageCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_packageCollectionViaEventPackageDetails:null);
				info.AddValue("_podRoomCollectionViaEventPackageDetails", ((_podRoomCollectionViaEventPackageDetails!=null) && (_podRoomCollectionViaEventPackageDetails.Count>0) && !this.MarkedForDeletion)?_podRoomCollectionViaEventPackageDetails:null);
				info.AddValue("_preQualificationTestTemplateCollectionViaTest", ((_preQualificationTestTemplateCollectionViaTest!=null) && (_preQualificationTestTemplateCollectionViaTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplateCollectionViaTest:null);
				info.AddValue("_preQualificationTestTemplateCollectionViaEventTest", ((_preQualificationTestTemplateCollectionViaEventTest!=null) && (_preQualificationTestTemplateCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_preQualificationTestTemplateCollectionViaEventTest:null);
				info.AddValue("_prospectsCollectionViaAccount", ((_prospectsCollectionViaAccount!=null) && (_prospectsCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaAccount:null);
				info.AddValue("_scheduleMethodCollectionViaEvents", ((_scheduleMethodCollectionViaEvents!=null) && (_scheduleMethodCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_scheduleMethodCollectionViaEvents:null);
				info.AddValue("_surveyTemplateCollectionViaAccount", ((_surveyTemplateCollectionViaAccount!=null) && (_surveyTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount:null);
				info.AddValue("_testCollectionViaEventTest", ((_testCollectionViaEventTest!=null) && (_testCollectionViaEventTest.Count>0) && !this.MarkedForDeletion)?_testCollectionViaEventTest:null);
				info.AddValue("_testCollectionViaClinicalTestQualificationCriteria", ((_testCollectionViaClinicalTestQualificationCriteria!=null) && (_testCollectionViaClinicalTestQualificationCriteria.Count>0) && !this.MarkedForDeletion)?_testCollectionViaClinicalTestQualificationCriteria:null);
				info.AddValue("_lookup_", (!this.MarkedForDeletion?_lookup_:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HafTemplateFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HafTemplateFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HafTemplateRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.ClinicalQuestionTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ClinicalTestQualificationCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ClinicalTestQualificationCriteriaFields.TemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerClinicalQuestionAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerClinicalQuestionAnswerFields.ClinicalQuestionTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventPackageDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventPackageDetailsFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventTest' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventTestFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplateQuestion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateQuestionFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalPartner' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartner()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PackageFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TestFields.HafTemplateId, null, ComparisonOperator.Equal, this.HaftemplateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CommunicationMode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCommunicationModeCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CommunicationModeCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerHealthQuestions' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerHealthQuestionsCollectionViaHafTemplateQuestion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerHealthQuestionsCollectionViaHafTemplateQuestion"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTypeCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTypeCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventTest__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventTest__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaPackage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaPackage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Package' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPackageCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PackageCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodRoom' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodRoomCollectionViaEventPackageDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PodRoomCollectionViaEventPackageDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplateCollectionViaTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationTestTemplateCollectionViaTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PreQualificationTestTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPreQualificationTestTemplateCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PreQualificationTestTemplateCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleMethod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleMethodCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ScheduleMethodCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaEventTest()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaEventTest"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Test' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestCollectionViaClinicalTestQualificationCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestCollectionViaClinicalTestQualificationCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HafTemplateFields.HaftemplateId, null, ComparisonOperator.Equal, this.HaftemplateId, "HafTemplateEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Category));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.Type));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedBy));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedBy));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HafTemplateEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._account);
			collectionsQueue.Enqueue(this._clinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._customerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._eventPackageDetails);
			collectionsQueue.Enqueue(this._events);
			collectionsQueue.Enqueue(this._eventTest);
			collectionsQueue.Enqueue(this._hafTemplateQuestion);
			collectionsQueue.Enqueue(this._hospitalPartner);
			collectionsQueue.Enqueue(this._package);
			collectionsQueue.Enqueue(this._test);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._communicationModeCollectionViaEvents);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._customerHealthQuestionsCollectionViaHafTemplateQuestion);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventTest);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._eventsCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._eventTypeCollectionViaEvents);
			collectionsQueue.Enqueue(this._fileCollectionViaPackage);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents____);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents___);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents__);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest_);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest_);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest__);
			collectionsQueue.Enqueue(this._lookupCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventTest__);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._lookupCollectionViaTest);
			collectionsQueue.Enqueue(this._lookupCollectionViaPackage);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaEvents);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents____);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents___);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents_);
			collectionsQueue.Enqueue(this._packageCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._podRoomCollectionViaEventPackageDetails);
			collectionsQueue.Enqueue(this._preQualificationTestTemplateCollectionViaTest);
			collectionsQueue.Enqueue(this._preQualificationTestTemplateCollectionViaEventTest);
			collectionsQueue.Enqueue(this._prospectsCollectionViaAccount);
			collectionsQueue.Enqueue(this._scheduleMethodCollectionViaEvents);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._testCollectionViaEventTest);
			collectionsQueue.Enqueue(this._testCollectionViaClinicalTestQualificationCriteria);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._account = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._clinicalTestQualificationCriteria = (EntityCollection<ClinicalTestQualificationCriteriaEntity>) collectionsQueue.Dequeue();
			this._customerClinicalQuestionAnswer = (EntityCollection<CustomerClinicalQuestionAnswerEntity>) collectionsQueue.Dequeue();
			this._eventPackageDetails = (EntityCollection<EventPackageDetailsEntity>) collectionsQueue.Dequeue();
			this._events = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTest = (EntityCollection<EventTestEntity>) collectionsQueue.Dequeue();
			this._hafTemplateQuestion = (EntityCollection<HafTemplateQuestionEntity>) collectionsQueue.Dequeue();
			this._hospitalPartner = (EntityCollection<HospitalPartnerEntity>) collectionsQueue.Dequeue();
			this._package = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._test = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._communicationModeCollectionViaEvents = (EntityCollection<CommunicationModeEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerHealthQuestionsCollectionViaHafTemplateQuestion = (EntityCollection<CustomerHealthQuestionsEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventTest = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventPackageDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaPackage = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventTest__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventPackageDetails = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaTest = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaPackage = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaEvents = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._packageCollectionViaEventPackageDetails = (EntityCollection<PackageEntity>) collectionsQueue.Dequeue();
			this._podRoomCollectionViaEventPackageDetails = (EntityCollection<PodRoomEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplateCollectionViaTest = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._preQualificationTestTemplateCollectionViaEventTest = (EntityCollection<PreQualificationTestTemplateEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaAccount = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaEventTest = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
			this._testCollectionViaClinicalTestQualificationCriteria = (EntityCollection<TestEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._account != null)
			{
				return true;
			}
			if (this._clinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._customerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._eventPackageDetails != null)
			{
				return true;
			}
			if (this._events != null)
			{
				return true;
			}
			if (this._eventTest != null)
			{
				return true;
			}
			if (this._hafTemplateQuestion != null)
			{
				return true;
			}
			if (this._hospitalPartner != null)
			{
				return true;
			}
			if (this._package != null)
			{
				return true;
			}
			if (this._test != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._checkListTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._communicationModeCollectionViaEvents != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._customerHealthQuestionsCollectionViaHafTemplateQuestion != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._eventTypeCollectionViaEvents != null)
			{
				return true;
			}
			if (this._fileCollectionViaPackage != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventTest__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._lookupCollectionViaTest != null)
			{
				return true;
			}
			if (this._lookupCollectionViaPackage != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaEvents != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaClinicalTestQualificationCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._packageCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._podRoomCollectionViaEventPackageDetails != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplateCollectionViaTest != null)
			{
				return true;
			}
			if (this._preQualificationTestTemplateCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaAccount != null)
			{
				return true;
			}
			if (this._scheduleMethodCollectionViaEvents != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._testCollectionViaEventTest != null)
			{
				return true;
			}
			if (this._testCollectionViaClinicalTestQualificationCriteria != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CommunicationModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Account", _account);
			toReturn.Add("ClinicalTestQualificationCriteria", _clinicalTestQualificationCriteria);
			toReturn.Add("CustomerClinicalQuestionAnswer", _customerClinicalQuestionAnswer);
			toReturn.Add("EventPackageDetails", _eventPackageDetails);
			toReturn.Add("Events", _events);
			toReturn.Add("EventTest", _eventTest);
			toReturn.Add("HafTemplateQuestion", _hafTemplateQuestion);
			toReturn.Add("HospitalPartner", _hospitalPartner);
			toReturn.Add("Package", _package);
			toReturn.Add("Test", _test);
			toReturn.Add("CheckListTemplateCollectionViaAccount_", _checkListTemplateCollectionViaAccount_);
			toReturn.Add("CheckListTemplateCollectionViaAccount", _checkListTemplateCollectionViaAccount);
			toReturn.Add("CommunicationModeCollectionViaEvents", _communicationModeCollectionViaEvents);
			toReturn.Add("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer", _customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("CustomerHealthQuestionsCollectionViaHafTemplateQuestion", _customerHealthQuestionsCollectionViaHafTemplateQuestion);
			toReturn.Add("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer", _customerProfileCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("EmailTemplateCollectionViaAccount___", _emailTemplateCollectionViaAccount___);
			toReturn.Add("EmailTemplateCollectionViaAccount_", _emailTemplateCollectionViaAccount_);
			toReturn.Add("EmailTemplateCollectionViaAccount", _emailTemplateCollectionViaAccount);
			toReturn.Add("EmailTemplateCollectionViaAccount__", _emailTemplateCollectionViaAccount__);
			toReturn.Add("EventsCollectionViaEventTest", _eventsCollectionViaEventTest);
			toReturn.Add("EventsCollectionViaEventPackageDetails", _eventsCollectionViaEventPackageDetails);
			toReturn.Add("EventsCollectionViaCustomerClinicalQuestionAnswer", _eventsCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("EventTypeCollectionViaEvents", _eventTypeCollectionViaEvents);
			toReturn.Add("FileCollectionViaPackage", _fileCollectionViaPackage);
			toReturn.Add("FileCollectionViaAccount", _fileCollectionViaAccount);
			toReturn.Add("FileCollectionViaAccount____", _fileCollectionViaAccount____);
			toReturn.Add("FileCollectionViaAccount_____", _fileCollectionViaAccount_____);
			toReturn.Add("FileCollectionViaAccount__", _fileCollectionViaAccount__);
			toReturn.Add("FileCollectionViaAccount___", _fileCollectionViaAccount___);
			toReturn.Add("FileCollectionViaAccount_", _fileCollectionViaAccount_);
			toReturn.Add("FileCollectionViaAccount______", _fileCollectionViaAccount______);
			toReturn.Add("FileCollectionViaAccount________", _fileCollectionViaAccount________);
			toReturn.Add("FileCollectionViaAccount_______", _fileCollectionViaAccount_______);
			toReturn.Add("FluConsentTemplateCollectionViaAccount", _fluConsentTemplateCollectionViaAccount);
			toReturn.Add("LookupCollectionViaEventTest", _lookupCollectionViaEventTest);
			toReturn.Add("LookupCollectionViaEvents", _lookupCollectionViaEvents);
			toReturn.Add("LookupCollectionViaEvents____", _lookupCollectionViaEvents____);
			toReturn.Add("LookupCollectionViaEvents___", _lookupCollectionViaEvents___);
			toReturn.Add("LookupCollectionViaEvents__", _lookupCollectionViaEvents__);
			toReturn.Add("LookupCollectionViaEvents_", _lookupCollectionViaEvents_);
			toReturn.Add("LookupCollectionViaEventTest_", _lookupCollectionViaEventTest_);
			toReturn.Add("LookupCollectionViaTest_", _lookupCollectionViaTest_);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria", _lookupCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("LookupCollectionViaAccount", _lookupCollectionViaAccount);
			toReturn.Add("LookupCollectionViaTest__", _lookupCollectionViaTest__);
			toReturn.Add("LookupCollectionViaClinicalTestQualificationCriteria_", _lookupCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("LookupCollectionViaEventTest__", _lookupCollectionViaEventTest__);
			toReturn.Add("LookupCollectionViaEventPackageDetails", _lookupCollectionViaEventPackageDetails);
			toReturn.Add("LookupCollectionViaTest", _lookupCollectionViaTest);
			toReturn.Add("LookupCollectionViaPackage", _lookupCollectionViaPackage);
			toReturn.Add("NotesDetailsCollectionViaEvents", _notesDetailsCollectionViaEvents);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents____", _organizationRoleUserCollectionViaEvents____);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents", _organizationRoleUserCollectionViaEvents);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents__", _organizationRoleUserCollectionViaEvents__);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents___", _organizationRoleUserCollectionViaEvents___);
			toReturn.Add("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", _organizationRoleUserCollectionViaClinicalTestQualificationCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents_", _organizationRoleUserCollectionViaEvents_);
			toReturn.Add("PackageCollectionViaEventPackageDetails", _packageCollectionViaEventPackageDetails);
			toReturn.Add("PodRoomCollectionViaEventPackageDetails", _podRoomCollectionViaEventPackageDetails);
			toReturn.Add("PreQualificationTestTemplateCollectionViaTest", _preQualificationTestTemplateCollectionViaTest);
			toReturn.Add("PreQualificationTestTemplateCollectionViaEventTest", _preQualificationTestTemplateCollectionViaEventTest);
			toReturn.Add("ProspectsCollectionViaAccount", _prospectsCollectionViaAccount);
			toReturn.Add("ScheduleMethodCollectionViaEvents", _scheduleMethodCollectionViaEvents);
			toReturn.Add("SurveyTemplateCollectionViaAccount", _surveyTemplateCollectionViaAccount);
			toReturn.Add("TestCollectionViaEventTest", _testCollectionViaEventTest);
			toReturn.Add("TestCollectionViaClinicalTestQualificationCriteria", _testCollectionViaClinicalTestQualificationCriteria);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_clinicalTestQualificationCriteria!=null)
			{
				_clinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerClinicalQuestionAnswer!=null)
			{
				_customerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_eventPackageDetails!=null)
			{
				_eventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_eventTest!=null)
			{
				_eventTest.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateQuestion!=null)
			{
				_hafTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartner!=null)
			{
				_hospitalPartner.ActiveContext = base.ActiveContext;
			}
			if(_package!=null)
			{
				_package.ActiveContext = base.ActiveContext;
			}
			if(_test!=null)
			{
				_test.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_!=null)
			{
				_checkListTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount!=null)
			{
				_checkListTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_communicationModeCollectionViaEvents!=null)
			{
				_communicationModeCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_customerHealthQuestionsCollectionViaHafTemplateQuestion!=null)
			{
				_customerHealthQuestionsCollectionViaHafTemplateQuestion.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_customerProfileCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount___!=null)
			{
				_emailTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_!=null)
			{
				_emailTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount!=null)
			{
				_emailTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount__!=null)
			{
				_emailTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventTest!=null)
			{
				_eventsCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventPackageDetails!=null)
			{
				_eventsCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_eventsCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_eventTypeCollectionViaEvents!=null)
			{
				_eventTypeCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaPackage!=null)
			{
				_fileCollectionViaPackage.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount!=null)
			{
				_fileCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____!=null)
			{
				_fileCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____!=null)
			{
				_fileCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__!=null)
			{
				_fileCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___!=null)
			{
				_fileCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_!=null)
			{
				_fileCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______!=null)
			{
				_fileCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________!=null)
			{
				_fileCollectionViaAccount________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______!=null)
			{
				_fileCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount!=null)
			{
				_fluConsentTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest!=null)
			{
				_lookupCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents!=null)
			{
				_lookupCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents____!=null)
			{
				_lookupCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents___!=null)
			{
				_lookupCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents__!=null)
			{
				_lookupCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents_!=null)
			{
				_lookupCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest_!=null)
			{
				_lookupCollectionViaEventTest_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest_!=null)
			{
				_lookupCollectionViaTest_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount!=null)
			{
				_lookupCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest__!=null)
			{
				_lookupCollectionViaTest__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_lookupCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventTest__!=null)
			{
				_lookupCollectionViaEventTest__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventPackageDetails!=null)
			{
				_lookupCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaTest!=null)
			{
				_lookupCollectionViaTest.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaPackage!=null)
			{
				_lookupCollectionViaPackage.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaEvents!=null)
			{
				_notesDetailsCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents____!=null)
			{
				_organizationRoleUserCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_!=null)
			{
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents!=null)
			{
				_organizationRoleUserCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer!=null)
			{
				_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents__!=null)
			{
				_organizationRoleUserCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents___!=null)
			{
				_organizationRoleUserCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents_!=null)
			{
				_organizationRoleUserCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_packageCollectionViaEventPackageDetails!=null)
			{
				_packageCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_podRoomCollectionViaEventPackageDetails!=null)
			{
				_podRoomCollectionViaEventPackageDetails.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplateCollectionViaTest!=null)
			{
				_preQualificationTestTemplateCollectionViaTest.ActiveContext = base.ActiveContext;
			}
			if(_preQualificationTestTemplateCollectionViaEventTest!=null)
			{
				_preQualificationTestTemplateCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaAccount!=null)
			{
				_prospectsCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_scheduleMethodCollectionViaEvents!=null)
			{
				_scheduleMethodCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount!=null)
			{
				_surveyTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaEventTest!=null)
			{
				_testCollectionViaEventTest.ActiveContext = base.ActiveContext;
			}
			if(_testCollectionViaClinicalTestQualificationCriteria!=null)
			{
				_testCollectionViaClinicalTestQualificationCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookup_!=null)
			{
				_lookup_.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_account = null;
			_clinicalTestQualificationCriteria = null;
			_customerClinicalQuestionAnswer = null;
			_eventPackageDetails = null;
			_events = null;
			_eventTest = null;
			_hafTemplateQuestion = null;
			_hospitalPartner = null;
			_package = null;
			_test = null;
			_checkListTemplateCollectionViaAccount_ = null;
			_checkListTemplateCollectionViaAccount = null;
			_communicationModeCollectionViaEvents = null;
			_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = null;
			_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = null;
			_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer = null;
			_customerHealthQuestionsCollectionViaHafTemplateQuestion = null;
			_customerProfileCollectionViaCustomerClinicalQuestionAnswer = null;
			_emailTemplateCollectionViaAccount___ = null;
			_emailTemplateCollectionViaAccount_ = null;
			_emailTemplateCollectionViaAccount = null;
			_emailTemplateCollectionViaAccount__ = null;
			_eventsCollectionViaEventTest = null;
			_eventsCollectionViaEventPackageDetails = null;
			_eventsCollectionViaCustomerClinicalQuestionAnswer = null;
			_eventTypeCollectionViaEvents = null;
			_fileCollectionViaPackage = null;
			_fileCollectionViaAccount = null;
			_fileCollectionViaAccount____ = null;
			_fileCollectionViaAccount_____ = null;
			_fileCollectionViaAccount__ = null;
			_fileCollectionViaAccount___ = null;
			_fileCollectionViaAccount_ = null;
			_fileCollectionViaAccount______ = null;
			_fileCollectionViaAccount________ = null;
			_fileCollectionViaAccount_______ = null;
			_fluConsentTemplateCollectionViaAccount = null;
			_lookupCollectionViaEventTest = null;
			_lookupCollectionViaEvents = null;
			_lookupCollectionViaEvents____ = null;
			_lookupCollectionViaEvents___ = null;
			_lookupCollectionViaEvents__ = null;
			_lookupCollectionViaEvents_ = null;
			_lookupCollectionViaEventTest_ = null;
			_lookupCollectionViaTest_ = null;
			_lookupCollectionViaClinicalTestQualificationCriteria = null;
			_lookupCollectionViaAccount = null;
			_lookupCollectionViaTest__ = null;
			_lookupCollectionViaClinicalTestQualificationCriteria_ = null;
			_lookupCollectionViaEventTest__ = null;
			_lookupCollectionViaEventPackageDetails = null;
			_lookupCollectionViaTest = null;
			_lookupCollectionViaPackage = null;
			_notesDetailsCollectionViaEvents = null;
			_organizationRoleUserCollectionViaEvents____ = null;
			_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = null;
			_organizationRoleUserCollectionViaEvents = null;
			_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = null;
			_organizationRoleUserCollectionViaEvents__ = null;
			_organizationRoleUserCollectionViaEvents___ = null;
			_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = null;
			_organizationRoleUserCollectionViaEvents_ = null;
			_packageCollectionViaEventPackageDetails = null;
			_podRoomCollectionViaEventPackageDetails = null;
			_preQualificationTestTemplateCollectionViaTest = null;
			_preQualificationTestTemplateCollectionViaEventTest = null;
			_prospectsCollectionViaAccount = null;
			_scheduleMethodCollectionViaEvents = null;
			_surveyTemplateCollectionViaAccount = null;
			_testCollectionViaEventTest = null;
			_testCollectionViaClinicalTestQualificationCriteria = null;
			_lookup_ = null;
			_lookup = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;

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

			_fieldsCustomProperties.Add("HaftemplateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Type", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPublished", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PublicationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Category", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", HafTemplateEntity.Relations.LookupEntityUsingCategory, true, signalRelatedEntity, "HafTemplate_", resetFKFields, new int[] { (int)HafTemplateFieldIndex.Category } );		
			_lookup_ = null;
		}

		/// <summary> setups the sync logic for member _lookup_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLookup_(IEntity2 relatedEntity)
		{
			if(_lookup_!=relatedEntity)
			{
				DesetupSyncLookup_(true, true);
				_lookup_ = (LookupEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", HafTemplateEntity.Relations.LookupEntityUsingCategory, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLookup_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", HafTemplateEntity.Relations.LookupEntityUsingType, true, signalRelatedEntity, "HafTemplate", resetFKFields, new int[] { (int)HafTemplateFieldIndex.Type } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", HafTemplateEntity.Relations.LookupEntityUsingType, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, signalRelatedEntity, "HafTemplate_", resetFKFields, new int[] { (int)HafTemplateFieldIndex.ModifiedBy } );		
			_organizationRoleUser_ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser_(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser_!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser_(true, true);
				_organizationRoleUser_ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, signalRelatedEntity, "HafTemplate", resetFKFields, new int[] { (int)HafTemplateFieldIndex.CreatedBy } );		
			_organizationRoleUser = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser(true, true);
				_organizationRoleUser = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", HafTemplateEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUserPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HafTemplateEntity</param>
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
		public  static HafTemplateRelations Relations
		{
			get	{ return new HafTemplateRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ClinicalTestQualificationCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClinicalTestQualificationCriteria
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("ClinicalTestQualificationCriteria")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.ClinicalTestQualificationCriteriaEntity, 0, null, null, null, null, "ClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerClinicalQuestionAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerClinicalQuestionAnswer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerClinicalQuestionAnswer")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerClinicalQuestionAnswerEntity, 0, null, null, null, null, "CustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventPackageDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventPackageDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventPackageDetails")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventPackageDetailsEntity, 0, null, null, null, null, "EventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventTest' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventTest")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventTestEntity, 0, null, null, null, null, "EventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplateQuestion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateQuestion
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory))),
					(IEntityRelation)GetRelationsForField("HafTemplateQuestion")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.HafTemplateQuestionEntity, 0, null, null, null, null, "HafTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartner' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartner
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartner")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.HospitalPartnerEntity, 0, null, null, null, null, "HospitalPartner", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))),
					(IEntityRelation)GetRelationsForField("Package")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, null, null, "Package", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTest
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))),
					(IEntityRelation)GetRelationsForField("Test")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, null, null, "Test", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_"), null, "CheckListTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount"), null, "CheckListTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CommunicationMode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCommunicationModeCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<CommunicationModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CommunicationModeEntity, 0, null, null, GetRelationsForField("CommunicationModeCollectionViaEvents"), null, "CommunicationModeCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria"), null, "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_"), null, "CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer"), null, "CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerHealthQuestions' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerHealthQuestionsCollectionViaHafTemplateQuestion
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.HafTemplateQuestionEntityUsingHaftemplateId;
				intermediateRelation.SetAliases(string.Empty, "HafTemplateQuestion_");
				return new PrefetchPathElement2(new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerHealthQuestionsEntity, 0, null, null, GetRelationsForField("CustomerHealthQuestionsCollectionViaHafTemplateQuestion"), null, "CustomerHealthQuestionsCollectionViaHafTemplateQuestion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerClinicalQuestionAnswer"), null, "CustomerProfileCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount___"), null, "EmailTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_"), null, "EmailTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount"), null, "EmailTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount__"), null, "EmailTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventTest"), null, "EventsCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventPackageDetails"), null, "EventsCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCustomerClinicalQuestionAnswer"), null, "EventsCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTypeCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.EventTypeEntity, 0, null, null, GetRelationsForField("EventTypeCollectionViaEvents"), null, "EventTypeCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaPackage
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.PackageEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Package_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaPackage"), null, "FileCollectionViaPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount"), null, "FileCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____"), null, "FileCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____"), null, "FileCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__"), null, "FileCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___"), null, "FileCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_"), null, "FileCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______"), null, "FileCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________"), null, "FileCollectionViaAccount________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______"), null, "FileCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount"), null, "FluConsentTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest"), null, "LookupCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents"), null, "LookupCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents____"), null, "LookupCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents___"), null, "LookupCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents__"), null, "LookupCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents_"), null, "LookupCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest_"), null, "LookupCollectionViaEventTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.TestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest_"), null, "LookupCollectionViaTest_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria"), null, "LookupCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount"), null, "LookupCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.TestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest__"), null, "LookupCollectionViaTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaClinicalTestQualificationCriteria_"), null, "LookupCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventTest__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventTest__"), null, "LookupCollectionViaEventTest__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventPackageDetails"), null, "LookupCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.TestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaTest"), null, "LookupCollectionViaTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaPackage
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.PackageEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Package_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaPackage"), null, "LookupCollectionViaPackage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaEvents"), null, "NotesDetailsCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents____"), null, "OrganizationRoleUserCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_"), null, "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents"), null, "OrganizationRoleUserCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.CustomerClinicalQuestionAnswerEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "CustomerClinicalQuestionAnswer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer"), null, "OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents__"), null, "OrganizationRoleUserCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents___"), null, "OrganizationRoleUserCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria"), null, "OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents_"), null, "OrganizationRoleUserCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Package' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPackageCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.PackageEntity, 0, null, null, GetRelationsForField("PackageCollectionViaEventPackageDetails"), null, "PackageCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodRoom' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodRoomCollectionViaEventPackageDetails
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventPackageDetailsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventPackageDetails_");
				return new PrefetchPathElement2(new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.PodRoomEntity, 0, null, null, GetRelationsForField("PodRoomCollectionViaEventPackageDetails"), null, "PodRoomCollectionViaEventPackageDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplateCollectionViaTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.TestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Test_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, GetRelationsForField("PreQualificationTestTemplateCollectionViaTest"), null, "PreQualificationTestTemplateCollectionViaTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PreQualificationTestTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPreQualificationTestTemplateCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.PreQualificationTestTemplateEntity, 0, null, null, GetRelationsForField("PreQualificationTestTemplateCollectionViaEventTest"), null, "PreQualificationTestTemplateCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaAccount"), null, "ProspectsCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleMethod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleMethodCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventsEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.ScheduleMethodEntity, 0, null, null, GetRelationsForField("ScheduleMethodCollectionViaEvents"), null, "ScheduleMethodCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.AccountEntityUsingClinicalQuestionTemplateId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount"), null, "SurveyTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaEventTest
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.EventTestEntityUsingHafTemplateId;
				intermediateRelation.SetAliases(string.Empty, "EventTest_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaEventTest"), null, "TestCollectionViaEventTest", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Test' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = HafTemplateEntity.Relations.ClinicalTestQualificationCriteriaEntityUsingTemplateId;
				intermediateRelation.SetAliases(string.Empty, "ClinicalTestQualificationCriteria_");
				return new PrefetchPathElement2(new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.TestEntity, 0, null, null, GetRelationsForField("TestCollectionViaClinicalTestQualificationCriteria"), null, "TestCollectionViaClinicalTestQualificationCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookup_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))),
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.HafTemplateEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HafTemplateEntity.CustomProperties;}
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
			get { return HafTemplateEntity.FieldsCustomProperties;}
		}

		/// <summary> The HaftemplateId property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."HAFTemplateId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 HaftemplateId
		{
			get { return (System.Int64)GetValue((int)HafTemplateFieldIndex.HaftemplateId, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.HaftemplateId, value); }
		}

		/// <summary> The Name property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)HafTemplateFieldIndex.Name, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.Name, value); }
		}

		/// <summary> The Type property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."Type"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Type
		{
			get { return (Nullable<System.Int64>)GetValue((int)HafTemplateFieldIndex.Type, false); }
			set	{ SetValue((int)HafTemplateFieldIndex.Type, value); }
		}

		/// <summary> The IsDefault property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)HafTemplateFieldIndex.IsDefault, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.IsDefault, value); }
		}

		/// <summary> The IsPublished property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."IsPublished"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublished
		{
			get { return (System.Boolean)GetValue((int)HafTemplateFieldIndex.IsPublished, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.IsPublished, value); }
		}

		/// <summary> The CreatedBy property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedBy
		{
			get { return (System.Int64)GetValue((int)HafTemplateFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.CreatedBy, value); }
		}

		/// <summary> The DateCreated property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)HafTemplateFieldIndex.DateCreated, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.DateCreated, value); }
		}

		/// <summary> The ModifiedBy property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedBy
		{
			get { return (Nullable<System.Int64>)GetValue((int)HafTemplateFieldIndex.ModifiedBy, false); }
			set	{ SetValue((int)HafTemplateFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The DateModified property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HafTemplateFieldIndex.DateModified, false); }
			set	{ SetValue((int)HafTemplateFieldIndex.DateModified, value); }
		}

		/// <summary> The IsActive property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)HafTemplateFieldIndex.IsActive, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.IsActive, value); }
		}

		/// <summary> The PublicationDate property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."PublicationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> PublicationDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HafTemplateFieldIndex.PublicationDate, false); }
			set	{ SetValue((int)HafTemplateFieldIndex.PublicationDate, value); }
		}

		/// <summary> The Notes property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)HafTemplateFieldIndex.Notes, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.Notes, value); }
		}

		/// <summary> The Category property of the Entity HafTemplate<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHAFTemplate"."Category"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Category
		{
			get { return (System.Int64)GetValue((int)HafTemplateFieldIndex.Category, true); }
			set	{ SetValue((int)HafTemplateFieldIndex.Category, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> Account
		{
			get
			{
				if(_account==null)
				{
					_account = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_account.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _account;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClinicalTestQualificationCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClinicalTestQualificationCriteriaEntity))]
		public virtual EntityCollection<ClinicalTestQualificationCriteriaEntity> ClinicalTestQualificationCriteria
		{
			get
			{
				if(_clinicalTestQualificationCriteria==null)
				{
					_clinicalTestQualificationCriteria = new EntityCollection<ClinicalTestQualificationCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClinicalTestQualificationCriteriaEntityFactory)));
					_clinicalTestQualificationCriteria.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _clinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerClinicalQuestionAnswerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerClinicalQuestionAnswerEntity))]
		public virtual EntityCollection<CustomerClinicalQuestionAnswerEntity> CustomerClinicalQuestionAnswer
		{
			get
			{
				if(_customerClinicalQuestionAnswer==null)
				{
					_customerClinicalQuestionAnswer = new EntityCollection<CustomerClinicalQuestionAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerClinicalQuestionAnswerEntityFactory)));
					_customerClinicalQuestionAnswer.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _customerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventPackageDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventPackageDetailsEntity))]
		public virtual EntityCollection<EventPackageDetailsEntity> EventPackageDetails
		{
			get
			{
				if(_eventPackageDetails==null)
				{
					_eventPackageDetails = new EntityCollection<EventPackageDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventPackageDetailsEntityFactory)));
					_eventPackageDetails.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _eventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> Events
		{
			get
			{
				if(_events==null)
				{
					_events = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_events.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _events;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTestEntity))]
		public virtual EntityCollection<EventTestEntity> EventTest
		{
			get
			{
				if(_eventTest==null)
				{
					_eventTest = new EntityCollection<EventTestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTestEntityFactory)));
					_eventTest.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _eventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateQuestionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateQuestionEntity))]
		public virtual EntityCollection<HafTemplateQuestionEntity> HafTemplateQuestion
		{
			get
			{
				if(_hafTemplateQuestion==null)
				{
					_hafTemplateQuestion = new EntityCollection<HafTemplateQuestionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateQuestionEntityFactory)));
					_hafTemplateQuestion.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _hafTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalPartnerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalPartnerEntity))]
		public virtual EntityCollection<HospitalPartnerEntity> HospitalPartner
		{
			get
			{
				if(_hospitalPartner==null)
				{
					_hospitalPartner = new EntityCollection<HospitalPartnerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEntityFactory)));
					_hospitalPartner.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _hospitalPartner;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> Package
		{
			get
			{
				if(_package==null)
				{
					_package = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_package.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _package;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> Test
		{
			get
			{
				if(_test==null)
				{
					_test = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_test.SetContainingEntityInfo(this, "HafTemplate");
				}
				return _test;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount_
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount_==null)
				{
					_checkListTemplateCollectionViaAccount_ = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CheckListTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CheckListTemplateEntity))]
		public virtual EntityCollection<CheckListTemplateEntity> CheckListTemplateCollectionViaAccount
		{
			get
			{
				if(_checkListTemplateCollectionViaAccount==null)
				{
					_checkListTemplateCollectionViaAccount = new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory)));
					_checkListTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _checkListTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CommunicationModeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CommunicationModeEntity))]
		public virtual EntityCollection<CommunicationModeEntity> CommunicationModeCollectionViaEvents
		{
			get
			{
				if(_communicationModeCollectionViaEvents==null)
				{
					_communicationModeCollectionViaEvents = new EntityCollection<CommunicationModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory)));
					_communicationModeCollectionViaEvents.IsReadOnly=true;
				}
				return _communicationModeCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria==null)
				{
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerHealthQuestionsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerHealthQuestionsEntity))]
		public virtual EntityCollection<CustomerHealthQuestionsEntity> CustomerHealthQuestionsCollectionViaHafTemplateQuestion
		{
			get
			{
				if(_customerHealthQuestionsCollectionViaHafTemplateQuestion==null)
				{
					_customerHealthQuestionsCollectionViaHafTemplateQuestion = new EntityCollection<CustomerHealthQuestionsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerHealthQuestionsEntityFactory)));
					_customerHealthQuestionsCollectionViaHafTemplateQuestion.IsReadOnly=true;
				}
				return _customerHealthQuestionsCollectionViaHafTemplateQuestion;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_customerProfileCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_customerProfileCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount___
		{
			get
			{
				if(_emailTemplateCollectionViaAccount___==null)
				{
					_emailTemplateCollectionViaAccount___ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount___.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount_
		{
			get
			{
				if(_emailTemplateCollectionViaAccount_==null)
				{
					_emailTemplateCollectionViaAccount_ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount_.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount
		{
			get
			{
				if(_emailTemplateCollectionViaAccount==null)
				{
					_emailTemplateCollectionViaAccount = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EmailTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EmailTemplateEntity))]
		public virtual EntityCollection<EmailTemplateEntity> EmailTemplateCollectionViaAccount__
		{
			get
			{
				if(_emailTemplateCollectionViaAccount__==null)
				{
					_emailTemplateCollectionViaAccount__ = new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory)));
					_emailTemplateCollectionViaAccount__.IsReadOnly=true;
				}
				return _emailTemplateCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventTest
		{
			get
			{
				if(_eventsCollectionViaEventTest==null)
				{
					_eventsCollectionViaEventTest = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventTest.IsReadOnly=true;
				}
				return _eventsCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventPackageDetails
		{
			get
			{
				if(_eventsCollectionViaEventPackageDetails==null)
				{
					_eventsCollectionViaEventPackageDetails = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _eventsCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_eventsCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_eventsCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _eventsCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventTypeEntity))]
		public virtual EntityCollection<EventTypeEntity> EventTypeCollectionViaEvents
		{
			get
			{
				if(_eventTypeCollectionViaEvents==null)
				{
					_eventTypeCollectionViaEvents = new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory)));
					_eventTypeCollectionViaEvents.IsReadOnly=true;
				}
				return _eventTypeCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaPackage
		{
			get
			{
				if(_fileCollectionViaPackage==null)
				{
					_fileCollectionViaPackage = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaPackage.IsReadOnly=true;
				}
				return _fileCollectionViaPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount
		{
			get
			{
				if(_fileCollectionViaAccount==null)
				{
					_fileCollectionViaAccount = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount.IsReadOnly=true;
				}
				return _fileCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount____
		{
			get
			{
				if(_fileCollectionViaAccount____==null)
				{
					_fileCollectionViaAccount____ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount____.IsReadOnly=true;
				}
				return _fileCollectionViaAccount____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_____
		{
			get
			{
				if(_fileCollectionViaAccount_____==null)
				{
					_fileCollectionViaAccount_____ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_____.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount__
		{
			get
			{
				if(_fileCollectionViaAccount__==null)
				{
					_fileCollectionViaAccount__ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount__.IsReadOnly=true;
				}
				return _fileCollectionViaAccount__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount___
		{
			get
			{
				if(_fileCollectionViaAccount___==null)
				{
					_fileCollectionViaAccount___ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount___.IsReadOnly=true;
				}
				return _fileCollectionViaAccount___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_
		{
			get
			{
				if(_fileCollectionViaAccount_==null)
				{
					_fileCollectionViaAccount_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount______
		{
			get
			{
				if(_fileCollectionViaAccount______==null)
				{
					_fileCollectionViaAccount______ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount______.IsReadOnly=true;
				}
				return _fileCollectionViaAccount______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount________
		{
			get
			{
				if(_fileCollectionViaAccount________==null)
				{
					_fileCollectionViaAccount________ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount________.IsReadOnly=true;
				}
				return _fileCollectionViaAccount________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaAccount_______
		{
			get
			{
				if(_fileCollectionViaAccount_______==null)
				{
					_fileCollectionViaAccount_______ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaAccount_______.IsReadOnly=true;
				}
				return _fileCollectionViaAccount_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FluConsentTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FluConsentTemplateEntity))]
		public virtual EntityCollection<FluConsentTemplateEntity> FluConsentTemplateCollectionViaAccount
		{
			get
			{
				if(_fluConsentTemplateCollectionViaAccount==null)
				{
					_fluConsentTemplateCollectionViaAccount = new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory)));
					_fluConsentTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _fluConsentTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest
		{
			get
			{
				if(_lookupCollectionViaEventTest==null)
				{
					_lookupCollectionViaEventTest = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents
		{
			get
			{
				if(_lookupCollectionViaEvents==null)
				{
					_lookupCollectionViaEvents = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents____
		{
			get
			{
				if(_lookupCollectionViaEvents____==null)
				{
					_lookupCollectionViaEvents____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents____.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents___
		{
			get
			{
				if(_lookupCollectionViaEvents___==null)
				{
					_lookupCollectionViaEvents___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents___.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents__
		{
			get
			{
				if(_lookupCollectionViaEvents__==null)
				{
					_lookupCollectionViaEvents__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents__.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEvents_
		{
			get
			{
				if(_lookupCollectionViaEvents_==null)
				{
					_lookupCollectionViaEvents_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEvents_.IsReadOnly=true;
				}
				return _lookupCollectionViaEvents_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest_
		{
			get
			{
				if(_lookupCollectionViaEventTest_==null)
				{
					_lookupCollectionViaEventTest_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest_.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest_
		{
			get
			{
				if(_lookupCollectionViaTest_==null)
				{
					_lookupCollectionViaTest_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest_.IsReadOnly=true;
				}
				return _lookupCollectionViaTest_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaAccount
		{
			get
			{
				if(_lookupCollectionViaAccount==null)
				{
					_lookupCollectionViaAccount = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaAccount.IsReadOnly=true;
				}
				return _lookupCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest__
		{
			get
			{
				if(_lookupCollectionViaTest__==null)
				{
					_lookupCollectionViaTest__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest__.IsReadOnly=true;
				}
				return _lookupCollectionViaTest__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_lookupCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_lookupCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _lookupCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventTest__
		{
			get
			{
				if(_lookupCollectionViaEventTest__==null)
				{
					_lookupCollectionViaEventTest__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventTest__.IsReadOnly=true;
				}
				return _lookupCollectionViaEventTest__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventPackageDetails
		{
			get
			{
				if(_lookupCollectionViaEventPackageDetails==null)
				{
					_lookupCollectionViaEventPackageDetails = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _lookupCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaTest
		{
			get
			{
				if(_lookupCollectionViaTest==null)
				{
					_lookupCollectionViaTest = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaTest.IsReadOnly=true;
				}
				return _lookupCollectionViaTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaPackage
		{
			get
			{
				if(_lookupCollectionViaPackage==null)
				{
					_lookupCollectionViaPackage = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaPackage.IsReadOnly=true;
				}
				return _lookupCollectionViaPackage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaEvents
		{
			get
			{
				if(_notesDetailsCollectionViaEvents==null)
				{
					_notesDetailsCollectionViaEvents = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaEvents.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents____
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents____==null)
				{
					_organizationRoleUserCollectionViaEvents____ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents____.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_==null)
				{
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents==null)
				{
					_organizationRoleUserCollectionViaEvents = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerClinicalQuestionAnswer
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer==null)
				{
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerClinicalQuestionAnswer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria_
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents__
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents__==null)
				{
					_organizationRoleUserCollectionViaEvents__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents___
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents___==null)
				{
					_organizationRoleUserCollectionViaEvents___ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents___.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_organizationRoleUserCollectionViaClinicalTestQualificationCriteria==null)
				{
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEvents_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEvents_==null)
				{
					_organizationRoleUserCollectionViaEvents_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEvents_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEvents_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PackageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PackageEntity))]
		public virtual EntityCollection<PackageEntity> PackageCollectionViaEventPackageDetails
		{
			get
			{
				if(_packageCollectionViaEventPackageDetails==null)
				{
					_packageCollectionViaEventPackageDetails = new EntityCollection<PackageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PackageEntityFactory)));
					_packageCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _packageCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodRoomEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodRoomEntity))]
		public virtual EntityCollection<PodRoomEntity> PodRoomCollectionViaEventPackageDetails
		{
			get
			{
				if(_podRoomCollectionViaEventPackageDetails==null)
				{
					_podRoomCollectionViaEventPackageDetails = new EntityCollection<PodRoomEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodRoomEntityFactory)));
					_podRoomCollectionViaEventPackageDetails.IsReadOnly=true;
				}
				return _podRoomCollectionViaEventPackageDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplateCollectionViaTest
		{
			get
			{
				if(_preQualificationTestTemplateCollectionViaTest==null)
				{
					_preQualificationTestTemplateCollectionViaTest = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplateCollectionViaTest.IsReadOnly=true;
				}
				return _preQualificationTestTemplateCollectionViaTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PreQualificationTestTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PreQualificationTestTemplateEntity))]
		public virtual EntityCollection<PreQualificationTestTemplateEntity> PreQualificationTestTemplateCollectionViaEventTest
		{
			get
			{
				if(_preQualificationTestTemplateCollectionViaEventTest==null)
				{
					_preQualificationTestTemplateCollectionViaEventTest = new EntityCollection<PreQualificationTestTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PreQualificationTestTemplateEntityFactory)));
					_preQualificationTestTemplateCollectionViaEventTest.IsReadOnly=true;
				}
				return _preQualificationTestTemplateCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaAccount
		{
			get
			{
				if(_prospectsCollectionViaAccount==null)
				{
					_prospectsCollectionViaAccount = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaAccount.IsReadOnly=true;
				}
				return _prospectsCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleMethodEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleMethodEntity))]
		public virtual EntityCollection<ScheduleMethodEntity> ScheduleMethodCollectionViaEvents
		{
			get
			{
				if(_scheduleMethodCollectionViaEvents==null)
				{
					_scheduleMethodCollectionViaEvents = new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory)));
					_scheduleMethodCollectionViaEvents.IsReadOnly=true;
				}
				return _scheduleMethodCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurveyTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurveyTemplateEntity))]
		public virtual EntityCollection<SurveyTemplateEntity> SurveyTemplateCollectionViaAccount
		{
			get
			{
				if(_surveyTemplateCollectionViaAccount==null)
				{
					_surveyTemplateCollectionViaAccount = new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory)));
					_surveyTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _surveyTemplateCollectionViaAccount;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaEventTest
		{
			get
			{
				if(_testCollectionViaEventTest==null)
				{
					_testCollectionViaEventTest = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaEventTest.IsReadOnly=true;
				}
				return _testCollectionViaEventTest;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestEntity))]
		public virtual EntityCollection<TestEntity> TestCollectionViaClinicalTestQualificationCriteria
		{
			get
			{
				if(_testCollectionViaClinicalTestQualificationCriteria==null)
				{
					_testCollectionViaClinicalTestQualificationCriteria = new EntityCollection<TestEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestEntityFactory)));
					_testCollectionViaClinicalTestQualificationCriteria.IsReadOnly=true;
				}
				return _testCollectionViaClinicalTestQualificationCriteria;
			}
		}

		/// <summary> Gets / sets related entity of type 'LookupEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LookupEntity Lookup_
		{
			get
			{
				return _lookup_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLookup_(value);
				}
				else
				{
					if(value==null)
					{
						if(_lookup_ != null)
						{
							_lookup_.UnsetRelatedEntity(this, "HafTemplate_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HafTemplate_");
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
							_lookup.UnsetRelatedEntity(this, "HafTemplate");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HafTemplate");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser_
		{
			get
			{
				return _organizationRoleUser_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser_(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser_ != null)
						{
							_organizationRoleUser_.UnsetRelatedEntity(this, "HafTemplate_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HafTemplate_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser
		{
			get
			{
				return _organizationRoleUser;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser != null)
						{
							_organizationRoleUser.UnsetRelatedEntity(this, "HafTemplate");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HafTemplate");
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
			get { return (int)Falcon.Data.EntityType.HafTemplateEntity; }
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
