///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:49
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
	/// Entity class which represents the entity 'Campaign'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CampaignEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<CallsEntity> _calls;
		private EntityCollection<CampaignActivityEntity> _campaignActivity;
		private EntityCollection<CampaignAssignmentEntity> _campaignAssignment;
		private EntityCollection<DirectMailEntity> _directMail;
		private EntityCollection<EventCustomersEntity> _eventCustomers;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaCalls;
		private EntityCollection<AccountEntity> _accountCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<AfaffiliateCampaignEntity> _afaffiliateCampaignCollectionViaEventCustomers;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCalls;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CallUploadEntity> _callUploadCollectionViaDirectMail;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaDirectMail;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaEventCustomers;
		private EntityCollection<CustomerProfileHistoryEntity> _customerProfileHistoryCollectionViaEventCustomers;
		private EntityCollection<CustomerRegistrationNotesEntity> _customerRegistrationNotesCollectionViaEventCustomers;
		private EntityCollection<DirectMailTypeEntity> _directMailTypeCollectionViaCampaignActivity;
		private EntityCollection<DirectMailTypeEntity> _directMailTypeCollectionViaDirectMail;
		private EntityCollection<EventAppointmentEntity> _eventAppointmentCollectionViaEventCustomers;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventCustomers;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<GcNotGivenReasonEntity> _gcNotGivenReasonCollectionViaEventCustomers;
		private EntityCollection<HospitalFacilityEntity> _hospitalFacilityCollectionViaEventCustomers;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LanguageEntity> _languageCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls__;
		private EntityCollection<LookupEntity> _lookupCollectionViaEventCustomers_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCampaignActivity;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignActivity;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventCustomers_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaDirectMail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCalls;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCampaignActivity_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private AccountEntity _account;
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
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name Lookup_</summary>
			public static readonly string Lookup_ = "Lookup_";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name Calls</summary>
			public static readonly string Calls = "Calls";
			/// <summary>Member name CampaignActivity</summary>
			public static readonly string CampaignActivity = "CampaignActivity";
			/// <summary>Member name CampaignAssignment</summary>
			public static readonly string CampaignAssignment = "CampaignAssignment";
			/// <summary>Member name DirectMail</summary>
			public static readonly string DirectMail = "DirectMail";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name HealthPlanCallQueueCriteria</summary>
			public static readonly string HealthPlanCallQueueCriteria = "HealthPlanCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaCalls</summary>
			public static readonly string AccountCollectionViaCalls = "AccountCollectionViaCalls";
			/// <summary>Member name AccountCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string AccountCollectionViaHealthPlanCallQueueCriteria = "AccountCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name AfaffiliateCampaignCollectionViaEventCustomers</summary>
			public static readonly string AfaffiliateCampaignCollectionViaEventCustomers = "AfaffiliateCampaignCollectionViaEventCustomers";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CallQueueCollectionViaHealthPlanCallQueueCriteria = "CallQueueCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CallQueueCollectionViaCalls</summary>
			public static readonly string CallQueueCollectionViaCalls = "CallQueueCollectionViaCalls";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CallUploadCollectionViaDirectMail</summary>
			public static readonly string CallUploadCollectionViaDirectMail = "CallUploadCollectionViaDirectMail";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name CustomerProfileCollectionViaDirectMail</summary>
			public static readonly string CustomerProfileCollectionViaDirectMail = "CustomerProfileCollectionViaDirectMail";
			/// <summary>Member name CustomerProfileCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileCollectionViaEventCustomers = "CustomerProfileCollectionViaEventCustomers";
			/// <summary>Member name CustomerProfileHistoryCollectionViaEventCustomers</summary>
			public static readonly string CustomerProfileHistoryCollectionViaEventCustomers = "CustomerProfileHistoryCollectionViaEventCustomers";
			/// <summary>Member name CustomerRegistrationNotesCollectionViaEventCustomers</summary>
			public static readonly string CustomerRegistrationNotesCollectionViaEventCustomers = "CustomerRegistrationNotesCollectionViaEventCustomers";
			/// <summary>Member name DirectMailTypeCollectionViaCampaignActivity</summary>
			public static readonly string DirectMailTypeCollectionViaCampaignActivity = "DirectMailTypeCollectionViaCampaignActivity";
			/// <summary>Member name DirectMailTypeCollectionViaDirectMail</summary>
			public static readonly string DirectMailTypeCollectionViaDirectMail = "DirectMailTypeCollectionViaDirectMail";
			/// <summary>Member name EventAppointmentCollectionViaEventCustomers</summary>
			public static readonly string EventAppointmentCollectionViaEventCustomers = "EventAppointmentCollectionViaEventCustomers";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaEventCustomers</summary>
			public static readonly string EventsCollectionViaEventCustomers = "EventsCollectionViaEventCustomers";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name GcNotGivenReasonCollectionViaEventCustomers</summary>
			public static readonly string GcNotGivenReasonCollectionViaEventCustomers = "GcNotGivenReasonCollectionViaEventCustomers";
			/// <summary>Member name HospitalFacilityCollectionViaEventCustomers</summary>
			public static readonly string HospitalFacilityCollectionViaEventCustomers = "HospitalFacilityCollectionViaEventCustomers";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LanguageCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string LanguageCollectionViaHealthPlanCallQueueCriteria = "LanguageCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name LookupCollectionViaEventCustomers</summary>
			public static readonly string LookupCollectionViaEventCustomers = "LookupCollectionViaEventCustomers";
			/// <summary>Member name LookupCollectionViaCalls__</summary>
			public static readonly string LookupCollectionViaCalls__ = "LookupCollectionViaCalls__";
			/// <summary>Member name LookupCollectionViaEventCustomers_</summary>
			public static readonly string LookupCollectionViaEventCustomers_ = "LookupCollectionViaEventCustomers_";
			/// <summary>Member name LookupCollectionViaCalls_</summary>
			public static readonly string LookupCollectionViaCalls_ = "LookupCollectionViaCalls_";
			/// <summary>Member name LookupCollectionViaCalls</summary>
			public static readonly string LookupCollectionViaCalls = "LookupCollectionViaCalls";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCampaignActivity</summary>
			public static readonly string LookupCollectionViaCampaignActivity = "LookupCollectionViaCampaignActivity";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignActivity</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignActivity = "OrganizationRoleUserCollectionViaCampaignActivity";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers = "OrganizationRoleUserCollectionViaEventCustomers";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventCustomers_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventCustomers_ = "OrganizationRoleUserCollectionViaEventCustomers_";
			/// <summary>Member name OrganizationRoleUserCollectionViaDirectMail</summary>
			public static readonly string OrganizationRoleUserCollectionViaDirectMail = "OrganizationRoleUserCollectionViaDirectMail";
			/// <summary>Member name OrganizationRoleUserCollectionViaCalls</summary>
			public static readonly string OrganizationRoleUserCollectionViaCalls = "OrganizationRoleUserCollectionViaCalls";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignAssignment = "OrganizationRoleUserCollectionViaCampaignAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaCampaignActivity_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCampaignActivity_ = "OrganizationRoleUserCollectionViaCampaignActivity_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CampaignEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CampaignEntity():base("CampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CampaignEntity(IEntityFields2 fields):base("CampaignEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CampaignEntity</param>
		public CampaignEntity(IValidator validator):base("CampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Campaign which data should be fetched into this Campaign object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignEntity(System.Int64 id):base("CampaignEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Campaign which data should be fetched into this Campaign object</param>
		/// <param name="validator">The custom validator object for this CampaignEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CampaignEntity(System.Int64 id, IValidator validator):base("CampaignEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CampaignEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_calls = (EntityCollection<CallsEntity>)info.GetValue("_calls", typeof(EntityCollection<CallsEntity>));
				_campaignActivity = (EntityCollection<CampaignActivityEntity>)info.GetValue("_campaignActivity", typeof(EntityCollection<CampaignActivityEntity>));
				_campaignAssignment = (EntityCollection<CampaignAssignmentEntity>)info.GetValue("_campaignAssignment", typeof(EntityCollection<CampaignAssignmentEntity>));
				_directMail = (EntityCollection<DirectMailEntity>)info.GetValue("_directMail", typeof(EntityCollection<DirectMailEntity>));
				_eventCustomers = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomers", typeof(EntityCollection<EventCustomersEntity>));
				_healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteria", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_accountCollectionViaCalls = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCalls", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>)info.GetValue("_afaffiliateCampaignCollectionViaEventCustomers", typeof(EntityCollection<AfaffiliateCampaignEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaCalls = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCalls", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_callUploadCollectionViaDirectMail = (EntityCollection<CallUploadEntity>)info.GetValue("_callUploadCollectionViaDirectMail", typeof(EntityCollection<CallUploadEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaDirectMail", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>)info.GetValue("_customerProfileHistoryCollectionViaEventCustomers", typeof(EntityCollection<CustomerProfileHistoryEntity>));
				_customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>)info.GetValue("_customerRegistrationNotesCollectionViaEventCustomers", typeof(EntityCollection<CustomerRegistrationNotesEntity>));
				_directMailTypeCollectionViaCampaignActivity = (EntityCollection<DirectMailTypeEntity>)info.GetValue("_directMailTypeCollectionViaCampaignActivity", typeof(EntityCollection<DirectMailTypeEntity>));
				_directMailTypeCollectionViaDirectMail = (EntityCollection<DirectMailTypeEntity>)info.GetValue("_directMailTypeCollectionViaDirectMail", typeof(EntityCollection<DirectMailTypeEntity>));
				_eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>)info.GetValue("_eventAppointmentCollectionViaEventCustomers", typeof(EntityCollection<EventAppointmentEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventCustomers", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>)info.GetValue("_gcNotGivenReasonCollectionViaEventCustomers", typeof(EntityCollection<GcNotGivenReasonEntity>));
				_hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>)info.GetValue("_hospitalFacilityCollectionViaEventCustomers", typeof(EntityCollection<HospitalFacilityEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEventCustomers_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCampaignActivity = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCampaignActivity", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaCampaignActivity = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignActivity", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventCustomers_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaDirectMail", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCalls", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaignAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCampaignActivity_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCampaignActivity_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
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
			switch((CampaignFieldIndex)fieldIndex)
			{
				case CampaignFieldIndex.TypeId:
					DesetupSyncLookup_(true, false);
					break;
				case CampaignFieldIndex.ModeId:
					DesetupSyncLookup(true, false);
					break;
				case CampaignFieldIndex.AccountId:
					DesetupSyncAccount(true, false);
					break;
				case CampaignFieldIndex.Createdby:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CampaignFieldIndex.Modifiedby:
					DesetupSyncOrganizationRoleUser_(true, false);
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
				case "Account":
					this.Account = (AccountEntity)entity;
					break;
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
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)entity);
					break;
				case "CampaignActivity":
					this.CampaignActivity.Add((CampaignActivityEntity)entity);
					break;
				case "CampaignAssignment":
					this.CampaignAssignment.Add((CampaignAssignmentEntity)entity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)entity);
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)entity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)entity);
					break;
				case "AccountCollectionViaCalls":
					this.AccountCollectionViaCalls.IsReadOnly = false;
					this.AccountCollectionViaCalls.Add((AccountEntity)entity);
					this.AccountCollectionViaCalls.IsReadOnly = true;
					break;
				case "AccountCollectionViaHealthPlanCallQueueCriteria":
					this.AccountCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.AccountCollectionViaHealthPlanCallQueueCriteria.Add((AccountEntity)entity);
					this.AccountCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "AccountCollectionViaCallQueueCustomer":
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.AccountCollectionViaCallQueueCustomer.Add((AccountEntity)entity);
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					this.AfaffiliateCampaignCollectionViaEventCustomers.IsReadOnly = false;
					this.AfaffiliateCampaignCollectionViaEventCustomers.Add((AfaffiliateCampaignEntity)entity);
					this.AfaffiliateCampaignCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCollectionViaCallQueueCustomer.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaCallQueueCustomer.IsReadOnly = true;
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
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.Add((CallQueueCriteriaEntity)entity);
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallUploadCollectionViaDirectMail":
					this.CallUploadCollectionViaDirectMail.IsReadOnly = false;
					this.CallUploadCollectionViaDirectMail.Add((CallUploadEntity)entity);
					this.CallUploadCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaDirectMail":
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = false;
					this.CustomerProfileCollectionViaDirectMail.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					this.CustomerProfileCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerProfileCollectionViaEventCustomers.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CustomerProfileHistoryCollectionViaEventCustomers":
					this.CustomerProfileHistoryCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerProfileHistoryCollectionViaEventCustomers.Add((CustomerProfileHistoryEntity)entity);
					this.CustomerProfileHistoryCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = false;
					this.CustomerRegistrationNotesCollectionViaEventCustomers.Add((CustomerRegistrationNotesEntity)entity);
					this.CustomerRegistrationNotesCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "DirectMailTypeCollectionViaCampaignActivity":
					this.DirectMailTypeCollectionViaCampaignActivity.IsReadOnly = false;
					this.DirectMailTypeCollectionViaCampaignActivity.Add((DirectMailTypeEntity)entity);
					this.DirectMailTypeCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "DirectMailTypeCollectionViaDirectMail":
					this.DirectMailTypeCollectionViaDirectMail.IsReadOnly = false;
					this.DirectMailTypeCollectionViaDirectMail.Add((DirectMailTypeEntity)entity);
					this.DirectMailTypeCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "EventAppointmentCollectionViaEventCustomers":
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = false;
					this.EventAppointmentCollectionViaEventCustomers.Add((EventAppointmentEntity)entity);
					this.EventAppointmentCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventCustomersCollectionViaCallQueueCustomer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventCustomers":
					this.EventsCollectionViaEventCustomers.IsReadOnly = false;
					this.EventsCollectionViaEventCustomers.Add((EventsEntity)entity);
					this.EventsCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					this.GcNotGivenReasonCollectionViaEventCustomers.IsReadOnly = false;
					this.GcNotGivenReasonCollectionViaEventCustomers.Add((GcNotGivenReasonEntity)entity);
					this.GcNotGivenReasonCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					this.HospitalFacilityCollectionViaEventCustomers.IsReadOnly = false;
					this.HospitalFacilityCollectionViaEventCustomers.Add((HospitalFacilityEntity)entity);
					this.HospitalFacilityCollectionViaEventCustomers.IsReadOnly = true;
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
				case "LookupCollectionViaEventCustomers":
					this.LookupCollectionViaEventCustomers.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls__":
					this.LookupCollectionViaCalls__.IsReadOnly = false;
					this.LookupCollectionViaCalls__.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls__.IsReadOnly = true;
					break;
				case "LookupCollectionViaEventCustomers_":
					this.LookupCollectionViaEventCustomers_.IsReadOnly = false;
					this.LookupCollectionViaEventCustomers_.Add((LookupEntity)entity);
					this.LookupCollectionViaEventCustomers_.IsReadOnly = true;
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
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCampaignActivity":
					this.LookupCollectionViaCampaignActivity.IsReadOnly = false;
					this.LookupCollectionViaCampaignActivity.Add((LookupEntity)entity);
					this.LookupCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity":
					this.OrganizationRoleUserCollectionViaCampaignActivity.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignActivity.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignActivity.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventCustomers_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventCustomers_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaDirectMail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaDirectMail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCalls.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignAssignment":
					this.OrganizationRoleUserCollectionViaCampaignAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity_":
					this.OrganizationRoleUserCollectionViaCampaignActivity_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCampaignActivity_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCampaignActivity_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
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
			return CampaignEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Account":
					toReturn.Add(CampaignEntity.Relations.AccountEntityUsingAccountId);
					break;
				case "Lookup_":
					toReturn.Add(CampaignEntity.Relations.LookupEntityUsingTypeId);
					break;
				case "Lookup":
					toReturn.Add(CampaignEntity.Relations.LookupEntityUsingModeId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CampaignEntity.Relations.OrganizationRoleUserEntityUsingModifiedby);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CampaignEntity.Relations.OrganizationRoleUserEntityUsingCreatedby);
					break;
				case "CallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId);
					break;
				case "Calls":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId);
					break;
				case "CampaignActivity":
					toReturn.Add(CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId);
					break;
				case "CampaignAssignment":
					toReturn.Add(CampaignEntity.Relations.CampaignAssignmentEntityUsingCampaignId);
					break;
				case "DirectMail":
					toReturn.Add(CampaignEntity.Relations.DirectMailEntityUsingCampaignId);
					break;
				case "EventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId);
					break;
				case "HealthPlanCallQueueCriteria":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId);
					break;
				case "AccountCollectionViaCalls":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.AccountEntityUsingHealthPlanId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId, "CampaignEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "AfaffiliateCampaignCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.AfaffiliateCampaignEntityUsingAffiliateCampaignId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId, "CampaignEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCalls":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.CallQueueEntityUsingCallQueueId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallUploadCollectionViaDirectMail":
					toReturn.Add(CampaignEntity.Relations.DirectMailEntityUsingCampaignId, "CampaignEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CallUploadEntityUsingCallUploadId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaDirectMail":
					toReturn.Add(CampaignEntity.Relations.DirectMailEntityUsingCampaignId, "CampaignEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.CustomerProfileEntityUsingCustomerId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileEntityUsingCustomerId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileHistoryCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerProfileHistoryEntityUsingCustomerProfileHistoryId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "CustomerRegistrationNotesCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.CustomerRegistrationNotesEntityUsingLeftWithoutScreeningNotesId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "DirectMailTypeCollectionViaCampaignActivity":
					toReturn.Add(CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId, "CampaignEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "DirectMailTypeCollectionViaDirectMail":
					toReturn.Add(CampaignEntity.Relations.DirectMailEntityUsingCampaignId, "CampaignEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.DirectMailTypeEntityUsingDirectMailTypeId, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "EventAppointmentCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventAppointmentEntityUsingAppointmentId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.EventsEntityUsingEventId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "GcNotGivenReasonCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.GcNotGivenReasonEntityUsingGcNotGivenReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "HospitalFacilityCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId, "CampaignEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingLeftWithoutScreeningReasonId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls__":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingProductTypeId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEventCustomers_":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.LookupEntityUsingPreferredContactType, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls_":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingDialerType, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCampaignActivity":
					toReturn.Add(CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId, "CampaignEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.LookupEntityUsingTypeId, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity":
					toReturn.Add(CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId, "CampaignEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId, "CampaignEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId, "CampaignEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventCustomers_":
					toReturn.Add(CampaignEntity.Relations.EventCustomersEntityUsingCampaignId, "CampaignEntity__", "EventCustomers_", JoinHint.None);
					toReturn.Add(EventCustomersEntity.Relations.OrganizationRoleUserEntityUsingConfirmedBy, "EventCustomers_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaDirectMail":
					toReturn.Add(CampaignEntity.Relations.DirectMailEntityUsingCampaignId, "CampaignEntity__", "DirectMail_", JoinHint.None);
					toReturn.Add(DirectMailEntity.Relations.OrganizationRoleUserEntityUsingMailedBy, "DirectMail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					toReturn.Add(CampaignEntity.Relations.CallsEntityUsingCampaignId, "CampaignEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignAssignment":
					toReturn.Add(CampaignEntity.Relations.CampaignAssignmentEntityUsingCampaignId, "CampaignEntity__", "CampaignAssignment_", JoinHint.None);
					toReturn.Add(CampaignAssignmentEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CampaignAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCampaignActivity_":
					toReturn.Add(CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId, "CampaignEntity__", "CampaignActivity_", JoinHint.None);
					toReturn.Add(CampaignActivityEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, "CampaignActivity_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId, "CampaignEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
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
				case "Account":
					SetupSyncAccount(relatedEntity);
					break;
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
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)relatedEntity);
					break;
				case "CampaignActivity":
					this.CampaignActivity.Add((CampaignActivityEntity)relatedEntity);
					break;
				case "CampaignAssignment":
					this.CampaignAssignment.Add((CampaignAssignmentEntity)relatedEntity);
					break;
				case "DirectMail":
					this.DirectMail.Add((DirectMailEntity)relatedEntity);
					break;
				case "EventCustomers":
					this.EventCustomers.Add((EventCustomersEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)relatedEntity);
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
				case "Account":
					DesetupSyncAccount(false, true);
					break;
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
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Calls":
					base.PerformRelatedEntityRemoval(this.Calls, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CampaignActivity":
					base.PerformRelatedEntityRemoval(this.CampaignActivity, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CampaignAssignment":
					base.PerformRelatedEntityRemoval(this.CampaignAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "DirectMail":
					base.PerformRelatedEntityRemoval(this.DirectMail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventCustomers":
					base.PerformRelatedEntityRemoval(this.EventCustomers, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteria":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteria, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_account!=null)
			{
				toReturn.Add(_account);
			}
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
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.Calls);
			toReturn.Add(this.CampaignActivity);
			toReturn.Add(this.CampaignAssignment);
			toReturn.Add(this.DirectMail);
			toReturn.Add(this.EventCustomers);
			toReturn.Add(this.HealthPlanCallQueueCriteria);

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
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_calls", ((_calls!=null) && (_calls.Count>0) && !this.MarkedForDeletion)?_calls:null);
				info.AddValue("_campaignActivity", ((_campaignActivity!=null) && (_campaignActivity.Count>0) && !this.MarkedForDeletion)?_campaignActivity:null);
				info.AddValue("_campaignAssignment", ((_campaignAssignment!=null) && (_campaignAssignment.Count>0) && !this.MarkedForDeletion)?_campaignAssignment:null);
				info.AddValue("_directMail", ((_directMail!=null) && (_directMail.Count>0) && !this.MarkedForDeletion)?_directMail:null);
				info.AddValue("_eventCustomers", ((_eventCustomers!=null) && (_eventCustomers.Count>0) && !this.MarkedForDeletion)?_eventCustomers:null);
				info.AddValue("_healthPlanCallQueueCriteria", ((_healthPlanCallQueueCriteria!=null) && (_healthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaCalls", ((_accountCollectionViaCalls!=null) && (_accountCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCalls:null);
				info.AddValue("_accountCollectionViaHealthPlanCallQueueCriteria", ((_accountCollectionViaHealthPlanCallQueueCriteria!=null) && (_accountCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_afaffiliateCampaignCollectionViaEventCustomers", ((_afaffiliateCampaignCollectionViaEventCustomers!=null) && (_afaffiliateCampaignCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_afaffiliateCampaignCollectionViaEventCustomers:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", ((_callQueueCollectionViaHealthPlanCallQueueCriteria!=null) && (_callQueueCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_callQueueCollectionViaCalls", ((_callQueueCollectionViaCalls!=null) && (_callQueueCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCalls:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_callUploadCollectionViaDirectMail", ((_callUploadCollectionViaDirectMail!=null) && (_callUploadCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_callUploadCollectionViaDirectMail:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_customerProfileCollectionViaDirectMail", ((_customerProfileCollectionViaDirectMail!=null) && (_customerProfileCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaDirectMail:null);
				info.AddValue("_customerProfileCollectionViaEventCustomers", ((_customerProfileCollectionViaEventCustomers!=null) && (_customerProfileCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaEventCustomers:null);
				info.AddValue("_customerProfileHistoryCollectionViaEventCustomers", ((_customerProfileHistoryCollectionViaEventCustomers!=null) && (_customerProfileHistoryCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerProfileHistoryCollectionViaEventCustomers:null);
				info.AddValue("_customerRegistrationNotesCollectionViaEventCustomers", ((_customerRegistrationNotesCollectionViaEventCustomers!=null) && (_customerRegistrationNotesCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_customerRegistrationNotesCollectionViaEventCustomers:null);
				info.AddValue("_directMailTypeCollectionViaCampaignActivity", ((_directMailTypeCollectionViaCampaignActivity!=null) && (_directMailTypeCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_directMailTypeCollectionViaCampaignActivity:null);
				info.AddValue("_directMailTypeCollectionViaDirectMail", ((_directMailTypeCollectionViaDirectMail!=null) && (_directMailTypeCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_directMailTypeCollectionViaDirectMail:null);
				info.AddValue("_eventAppointmentCollectionViaEventCustomers", ((_eventAppointmentCollectionViaEventCustomers!=null) && (_eventAppointmentCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventAppointmentCollectionViaEventCustomers:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaEventCustomers", ((_eventsCollectionViaEventCustomers!=null) && (_eventsCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventCustomers:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_gcNotGivenReasonCollectionViaEventCustomers", ((_gcNotGivenReasonCollectionViaEventCustomers!=null) && (_gcNotGivenReasonCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_gcNotGivenReasonCollectionViaEventCustomers:null);
				info.AddValue("_hospitalFacilityCollectionViaEventCustomers", ((_hospitalFacilityCollectionViaEventCustomers!=null) && (_hospitalFacilityCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_hospitalFacilityCollectionViaEventCustomers:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_languageCollectionViaHealthPlanCallQueueCriteria", ((_languageCollectionViaHealthPlanCallQueueCriteria!=null) && (_languageCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_lookupCollectionViaEventCustomers", ((_lookupCollectionViaEventCustomers!=null) && (_lookupCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers:null);
				info.AddValue("_lookupCollectionViaCalls__", ((_lookupCollectionViaCalls__!=null) && (_lookupCollectionViaCalls__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls__:null);
				info.AddValue("_lookupCollectionViaEventCustomers_", ((_lookupCollectionViaEventCustomers_!=null) && (_lookupCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEventCustomers_:null);
				info.AddValue("_lookupCollectionViaCalls_", ((_lookupCollectionViaCalls_!=null) && (_lookupCollectionViaCalls_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls_:null);
				info.AddValue("_lookupCollectionViaCalls", ((_lookupCollectionViaCalls!=null) && (_lookupCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCampaignActivity", ((_lookupCollectionViaCampaignActivity!=null) && (_lookupCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCampaignActivity:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignActivity", ((_organizationRoleUserCollectionViaCampaignActivity!=null) && (_organizationRoleUserCollectionViaCampaignActivity.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignActivity:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers", ((_organizationRoleUserCollectionViaEventCustomers!=null) && (_organizationRoleUserCollectionViaEventCustomers.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaEventCustomers_", ((_organizationRoleUserCollectionViaEventCustomers_!=null) && (_organizationRoleUserCollectionViaEventCustomers_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventCustomers_:null);
				info.AddValue("_organizationRoleUserCollectionViaDirectMail", ((_organizationRoleUserCollectionViaDirectMail!=null) && (_organizationRoleUserCollectionViaDirectMail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaDirectMail:null);
				info.AddValue("_organizationRoleUserCollectionViaCalls", ((_organizationRoleUserCollectionViaCalls!=null) && (_organizationRoleUserCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCalls:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignAssignment", ((_organizationRoleUserCollectionViaCampaignAssignment!=null) && (_organizationRoleUserCollectionViaCampaignAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaCampaignActivity_", ((_organizationRoleUserCollectionViaCampaignActivity_!=null) && (_organizationRoleUserCollectionViaCampaignActivity_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCampaignActivity_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
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
		public bool TestOriginalFieldValueForNull(CampaignFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CampaignFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CampaignRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignActivityFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignAssignmentFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DirectMailFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.CampaignId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfaffiliateCampaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfaffiliateCampaignCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AfaffiliateCampaignCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallUploadCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallUploadCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfileHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileHistoryCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileHistoryCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerRegistrationNotes' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerRegistrationNotesCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerRegistrationNotesCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMailType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMailTypeCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("DirectMailTypeCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DirectMailType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDirectMailTypeCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("DirectMailTypeCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAppointment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAppointmentCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventAppointmentCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GcNotGivenReason' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGcNotGivenReasonCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("GcNotGivenReasonCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacilityCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HospitalFacilityCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignActivity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignActivity"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventCustomers_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventCustomers_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCampaignActivity_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCampaignActivity_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.Id, "CampaignEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.AccountId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.TypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.ModeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.Modifiedby));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.Createdby));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CampaignEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._calls);
			collectionsQueue.Enqueue(this._campaignActivity);
			collectionsQueue.Enqueue(this._campaignAssignment);
			collectionsQueue.Enqueue(this._directMail);
			collectionsQueue.Enqueue(this._eventCustomers);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaCalls);
			collectionsQueue.Enqueue(this._accountCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._afaffiliateCampaignCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCalls);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callUploadCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerProfileHistoryCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._customerRegistrationNotesCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._directMailTypeCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._directMailTypeCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._eventAppointmentCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._gcNotGivenReasonCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._hospitalFacilityCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._languageCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls__);
			collectionsQueue.Enqueue(this._lookupCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignActivity);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventCustomers_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaDirectMail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCalls);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCampaignActivity_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._calls = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._campaignActivity = (EntityCollection<CampaignActivityEntity>) collectionsQueue.Dequeue();
			this._campaignAssignment = (EntityCollection<CampaignAssignmentEntity>) collectionsQueue.Dequeue();
			this._directMail = (EntityCollection<DirectMailEntity>) collectionsQueue.Dequeue();
			this._eventCustomers = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCalls = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._afaffiliateCampaignCollectionViaEventCustomers = (EntityCollection<AfaffiliateCampaignEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCalls = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._callUploadCollectionViaDirectMail = (EntityCollection<CallUploadEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaDirectMail = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaEventCustomers = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileHistoryCollectionViaEventCustomers = (EntityCollection<CustomerProfileHistoryEntity>) collectionsQueue.Dequeue();
			this._customerRegistrationNotesCollectionViaEventCustomers = (EntityCollection<CustomerRegistrationNotesEntity>) collectionsQueue.Dequeue();
			this._directMailTypeCollectionViaCampaignActivity = (EntityCollection<DirectMailTypeEntity>) collectionsQueue.Dequeue();
			this._directMailTypeCollectionViaDirectMail = (EntityCollection<DirectMailTypeEntity>) collectionsQueue.Dequeue();
			this._eventAppointmentCollectionViaEventCustomers = (EntityCollection<EventAppointmentEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventCustomers = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._gcNotGivenReasonCollectionViaEventCustomers = (EntityCollection<GcNotGivenReasonEntity>) collectionsQueue.Dequeue();
			this._hospitalFacilityCollectionViaEventCustomers = (EntityCollection<HospitalFacilityEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEventCustomers_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCampaignActivity = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignActivity = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventCustomers_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaDirectMail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCampaignActivity_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._calls != null)
			{
				return true;
			}
			if (this._campaignActivity != null)
			{
				return true;
			}
			if (this._campaignAssignment != null)
			{
				return true;
			}
			if (this._directMail != null)
			{
				return true;
			}
			if (this._eventCustomers != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._accountCollectionViaCalls != null)
			{
				return true;
			}
			if (this._accountCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._accountCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._afaffiliateCampaignCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaCallQueueCustomer != null)
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
			if (this._callQueueCriteriaCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callUploadCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._customerProfileHistoryCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._customerRegistrationNotesCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._directMailTypeCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._directMailTypeCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._eventAppointmentCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._gcNotGivenReasonCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._hospitalFacilityCollectionViaEventCustomers != null)
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
			if (this._lookupCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEventCustomers_ != null)
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
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignActivity != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventCustomers_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaDirectMail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCalls != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCampaignActivity_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Account", _account);
			toReturn.Add("Lookup_", _lookup_);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("Calls", _calls);
			toReturn.Add("CampaignActivity", _campaignActivity);
			toReturn.Add("CampaignAssignment", _campaignAssignment);
			toReturn.Add("DirectMail", _directMail);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("HealthPlanCallQueueCriteria", _healthPlanCallQueueCriteria);
			toReturn.Add("AccountCollectionViaCalls", _accountCollectionViaCalls);
			toReturn.Add("AccountCollectionViaHealthPlanCallQueueCriteria", _accountCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("AfaffiliateCampaignCollectionViaEventCustomers", _afaffiliateCampaignCollectionViaEventCustomers);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCollectionViaHealthPlanCallQueueCriteria", _callQueueCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CallQueueCollectionViaCalls", _callQueueCollectionViaCalls);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CallUploadCollectionViaDirectMail", _callUploadCollectionViaDirectMail);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("CustomerProfileCollectionViaDirectMail", _customerProfileCollectionViaDirectMail);
			toReturn.Add("CustomerProfileCollectionViaEventCustomers", _customerProfileCollectionViaEventCustomers);
			toReturn.Add("CustomerProfileHistoryCollectionViaEventCustomers", _customerProfileHistoryCollectionViaEventCustomers);
			toReturn.Add("CustomerRegistrationNotesCollectionViaEventCustomers", _customerRegistrationNotesCollectionViaEventCustomers);
			toReturn.Add("DirectMailTypeCollectionViaCampaignActivity", _directMailTypeCollectionViaCampaignActivity);
			toReturn.Add("DirectMailTypeCollectionViaDirectMail", _directMailTypeCollectionViaDirectMail);
			toReturn.Add("EventAppointmentCollectionViaEventCustomers", _eventAppointmentCollectionViaEventCustomers);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaEventCustomers", _eventsCollectionViaEventCustomers);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("GcNotGivenReasonCollectionViaEventCustomers", _gcNotGivenReasonCollectionViaEventCustomers);
			toReturn.Add("HospitalFacilityCollectionViaEventCustomers", _hospitalFacilityCollectionViaEventCustomers);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LanguageCollectionViaHealthPlanCallQueueCriteria", _languageCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("LookupCollectionViaEventCustomers", _lookupCollectionViaEventCustomers);
			toReturn.Add("LookupCollectionViaCalls__", _lookupCollectionViaCalls__);
			toReturn.Add("LookupCollectionViaEventCustomers_", _lookupCollectionViaEventCustomers_);
			toReturn.Add("LookupCollectionViaCalls_", _lookupCollectionViaCalls_);
			toReturn.Add("LookupCollectionViaCalls", _lookupCollectionViaCalls);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCampaignActivity", _lookupCollectionViaCampaignActivity);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignActivity", _organizationRoleUserCollectionViaCampaignActivity);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers", _organizationRoleUserCollectionViaEventCustomers);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaEventCustomers_", _organizationRoleUserCollectionViaEventCustomers_);
			toReturn.Add("OrganizationRoleUserCollectionViaDirectMail", _organizationRoleUserCollectionViaDirectMail);
			toReturn.Add("OrganizationRoleUserCollectionViaCalls", _organizationRoleUserCollectionViaCalls);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignAssignment", _organizationRoleUserCollectionViaCampaignAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaCampaignActivity_", _organizationRoleUserCollectionViaCampaignActivity_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_calls!=null)
			{
				_calls.ActiveContext = base.ActiveContext;
			}
			if(_campaignActivity!=null)
			{
				_campaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_campaignAssignment!=null)
			{
				_campaignAssignment.ActiveContext = base.ActiveContext;
			}
			if(_directMail!=null)
			{
				_directMail.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteria!=null)
			{
				_healthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCalls!=null)
			{
				_accountCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_accountCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_afaffiliateCampaignCollectionViaEventCustomers!=null)
			{
				_afaffiliateCampaignCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_callQueueCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCalls!=null)
			{
				_callQueueCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callUploadCollectionViaDirectMail!=null)
			{
				_callUploadCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaDirectMail!=null)
			{
				_customerProfileCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaEventCustomers!=null)
			{
				_customerProfileCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileHistoryCollectionViaEventCustomers!=null)
			{
				_customerProfileHistoryCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_customerRegistrationNotesCollectionViaEventCustomers!=null)
			{
				_customerRegistrationNotesCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_directMailTypeCollectionViaCampaignActivity!=null)
			{
				_directMailTypeCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_directMailTypeCollectionViaDirectMail!=null)
			{
				_directMailTypeCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_eventAppointmentCollectionViaEventCustomers!=null)
			{
				_eventAppointmentCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventCustomers!=null)
			{
				_eventsCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_gcNotGivenReasonCollectionViaEventCustomers!=null)
			{
				_gcNotGivenReasonCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_hospitalFacilityCollectionViaEventCustomers!=null)
			{
				_hospitalFacilityCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_languageCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers!=null)
			{
				_lookupCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls__!=null)
			{
				_lookupCollectionViaCalls__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEventCustomers_!=null)
			{
				_lookupCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls_!=null)
			{
				_lookupCollectionViaCalls_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls!=null)
			{
				_lookupCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCampaignActivity!=null)
			{
				_lookupCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignActivity!=null)
			{
				_organizationRoleUserCollectionViaCampaignActivity.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventCustomers_!=null)
			{
				_organizationRoleUserCollectionViaEventCustomers_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaDirectMail!=null)
			{
				_organizationRoleUserCollectionViaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCalls!=null)
			{
				_organizationRoleUserCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignAssignment!=null)
			{
				_organizationRoleUserCollectionViaCampaignAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCampaignActivity_!=null)
			{
				_organizationRoleUserCollectionViaCampaignActivity_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
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

			_callQueueCustomer = null;
			_calls = null;
			_campaignActivity = null;
			_campaignAssignment = null;
			_directMail = null;
			_eventCustomers = null;
			_healthPlanCallQueueCriteria = null;
			_accountCollectionViaCalls = null;
			_accountCollectionViaHealthPlanCallQueueCriteria = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_afaffiliateCampaignCollectionViaEventCustomers = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCollectionViaHealthPlanCallQueueCriteria = null;
			_callQueueCollectionViaCalls = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_callUploadCollectionViaDirectMail = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_customerProfileCollectionViaDirectMail = null;
			_customerProfileCollectionViaEventCustomers = null;
			_customerProfileHistoryCollectionViaEventCustomers = null;
			_customerRegistrationNotesCollectionViaEventCustomers = null;
			_directMailTypeCollectionViaCampaignActivity = null;
			_directMailTypeCollectionViaDirectMail = null;
			_eventAppointmentCollectionViaEventCustomers = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaEventCustomers = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_gcNotGivenReasonCollectionViaEventCustomers = null;
			_hospitalFacilityCollectionViaEventCustomers = null;
			_languageCollectionViaCallQueueCustomer = null;
			_languageCollectionViaHealthPlanCallQueueCriteria = null;
			_lookupCollectionViaEventCustomers = null;
			_lookupCollectionViaCalls__ = null;
			_lookupCollectionViaEventCustomers_ = null;
			_lookupCollectionViaCalls_ = null;
			_lookupCollectionViaCalls = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCampaignActivity = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCampaignActivity = null;
			_organizationRoleUserCollectionViaEventCustomers = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = null;
			_organizationRoleUserCollectionViaEventCustomers_ = null;
			_organizationRoleUserCollectionViaDirectMail = null;
			_organizationRoleUserCollectionViaCalls = null;
			_organizationRoleUserCollectionViaCampaignAssignment = null;
			_organizationRoleUserCollectionViaCampaignActivity_ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_account = null;
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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AccountId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomTags", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPublished", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Createdby", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Modifiedby", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CampaignEntity.Relations.AccountEntityUsingAccountId, true, signalRelatedEntity, "Campaign", resetFKFields, new int[] { (int)CampaignFieldIndex.AccountId } );		
			_account = null;
		}

		/// <summary> setups the sync logic for member _account</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAccount(IEntity2 relatedEntity)
		{
			if(_account!=relatedEntity)
			{
				DesetupSyncAccount(true, true);
				_account = (AccountEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CampaignEntity.Relations.AccountEntityUsingAccountId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAccountPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _lookup_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLookup_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CampaignEntity.Relations.LookupEntityUsingTypeId, true, signalRelatedEntity, "Campaign_", resetFKFields, new int[] { (int)CampaignFieldIndex.TypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup_, new PropertyChangedEventHandler( OnLookup_PropertyChanged ), "Lookup_", CampaignEntity.Relations.LookupEntityUsingTypeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CampaignEntity.Relations.LookupEntityUsingModeId, true, signalRelatedEntity, "Campaign", resetFKFields, new int[] { (int)CampaignFieldIndex.ModeId } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CampaignEntity.Relations.LookupEntityUsingModeId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CampaignEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, true, signalRelatedEntity, "Campaign_", resetFKFields, new int[] { (int)CampaignFieldIndex.Modifiedby } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CampaignEntity.Relations.OrganizationRoleUserEntityUsingModifiedby, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CampaignEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, true, signalRelatedEntity, "Campaign", resetFKFields, new int[] { (int)CampaignFieldIndex.Createdby } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CampaignEntity.Relations.OrganizationRoleUserEntityUsingCreatedby, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this CampaignEntity</param>
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
		public  static CampaignRelations Relations
		{
			get	{ return new CampaignRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Calls")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, null, null, "Calls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignActivity
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignActivity")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CampaignActivityEntity, 0, null, null, null, null, "CampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CampaignAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CampaignAssignment")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CampaignAssignmentEntity, 0, null, null, null, null, "CampaignAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory))),
					(IEntityRelation)GetRelationsForField("DirectMail")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.DirectMailEntity, 0, null, null, null, null, "DirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteria")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCalls"), null, "AccountCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaHealthPlanCallQueueCriteria"), null, "AccountCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfaffiliateCampaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.AfaffiliateCampaignEntity, 0, null, null, GetRelationsForField("AfaffiliateCampaignCollectionViaEventCustomers"), null, "AfaffiliateCampaignCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaHealthPlanCallQueueCriteria"), null, "CallQueueCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCalls"), null, "CallQueueCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallUploadCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.DirectMailEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CallUploadEntity, 0, null, null, GetRelationsForField("CallUploadCollectionViaDirectMail"), null, "CallUploadCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.DirectMailEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaDirectMail"), null, "CustomerProfileCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaEventCustomers"), null, "CustomerProfileCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfileHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileHistoryCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CustomerProfileHistoryEntity, 0, null, null, GetRelationsForField("CustomerProfileHistoryCollectionViaEventCustomers"), null, "CustomerProfileHistoryCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerRegistrationNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerRegistrationNotesCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.CustomerRegistrationNotesEntity, 0, null, null, GetRelationsForField("CustomerRegistrationNotesCollectionViaEventCustomers"), null, "CustomerRegistrationNotesCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMailType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMailTypeCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.DirectMailTypeEntity, 0, null, null, GetRelationsForField("DirectMailTypeCollectionViaCampaignActivity"), null, "DirectMailTypeCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DirectMailType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDirectMailTypeCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.DirectMailEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.DirectMailTypeEntity, 0, null, null, GetRelationsForField("DirectMailTypeCollectionViaDirectMail"), null, "DirectMailTypeCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAppointment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAppointmentCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.EventAppointmentEntity, 0, null, null, GetRelationsForField("EventAppointmentCollectionViaEventCustomers"), null, "EventAppointmentCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventCustomers"), null, "EventsCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GcNotGivenReason' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.GcNotGivenReasonEntity, 0, null, null, GetRelationsForField("GcNotGivenReasonCollectionViaEventCustomers"), null, "GcNotGivenReasonCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, GetRelationsForField("HospitalFacilityCollectionViaEventCustomers"), null, "HospitalFacilityCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaHealthPlanCallQueueCriteria"), null, "LanguageCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers"), null, "LookupCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls__
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls__"), null, "LookupCollectionViaCalls__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEventCustomers_"), null, "LookupCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls_"), null, "LookupCollectionViaCalls_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls"), null, "LookupCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCampaignActivity"), null, "LookupCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignActivity
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignActivity"), null, "OrganizationRoleUserCollectionViaCampaignActivity", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers"), null, "OrganizationRoleUserCollectionViaEventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.EventCustomersEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "EventCustomers_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventCustomers_"), null, "OrganizationRoleUserCollectionViaEventCustomers_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.DirectMailEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "DirectMail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaDirectMail"), null, "OrganizationRoleUserCollectionViaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallsEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCalls"), null, "OrganizationRoleUserCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CampaignAssignmentEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignAssignment"), null, "OrganizationRoleUserCollectionViaCampaignAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCampaignActivity_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CampaignActivityEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CampaignActivity_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCampaignActivity_"), null, "OrganizationRoleUserCollectionViaCampaignActivity_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CampaignEntity.Relations.CallQueueCustomerEntityUsingCampaignId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccount
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))),
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup_")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CampaignEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CampaignEntity.CustomProperties;}
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
			get { return CampaignEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.Id, true); }
			set	{ SetValue((int)CampaignFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CampaignFieldIndex.Name, true); }
			set	{ SetValue((int)CampaignFieldIndex.Name, value); }
		}

		/// <summary> The CampaignCode property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."CampaignCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CampaignCode
		{
			get { return (System.String)GetValue((int)CampaignFieldIndex.CampaignCode, true); }
			set	{ SetValue((int)CampaignFieldIndex.CampaignCode, value); }
		}

		/// <summary> The StartDate property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."StartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime StartDate
		{
			get { return (System.DateTime)GetValue((int)CampaignFieldIndex.StartDate, true); }
			set	{ SetValue((int)CampaignFieldIndex.StartDate, value); }
		}

		/// <summary> The EndDate property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."EndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime EndDate
		{
			get { return (System.DateTime)GetValue((int)CampaignFieldIndex.EndDate, true); }
			set	{ SetValue((int)CampaignFieldIndex.EndDate, value); }
		}

		/// <summary> The TypeId property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."TypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TypeId
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.TypeId, true); }
			set	{ SetValue((int)CampaignFieldIndex.TypeId, value); }
		}

		/// <summary> The ModeId property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."ModeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ModeId
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.ModeId, true); }
			set	{ SetValue((int)CampaignFieldIndex.ModeId, value); }
		}

		/// <summary> The AccountId property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."AccountId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 AccountId
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.AccountId, true); }
			set	{ SetValue((int)CampaignFieldIndex.AccountId, value); }
		}

		/// <summary> The CustomTags property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."CustomTags"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CustomTags
		{
			get { return (System.String)GetValue((int)CampaignFieldIndex.CustomTags, true); }
			set	{ SetValue((int)CampaignFieldIndex.CustomTags, value); }
		}

		/// <summary> The Description property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 4000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CampaignFieldIndex.Description, true); }
			set	{ SetValue((int)CampaignFieldIndex.Description, value); }
		}

		/// <summary> The IsPublished property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."IsPublished"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPublished
		{
			get { return (System.Boolean)GetValue((int)CampaignFieldIndex.IsPublished, true); }
			set	{ SetValue((int)CampaignFieldIndex.IsPublished, value); }
		}

		/// <summary> The CreatedOn property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."CreatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CreatedOn
		{
			get { return (System.DateTime)GetValue((int)CampaignFieldIndex.CreatedOn, true); }
			set	{ SetValue((int)CampaignFieldIndex.CreatedOn, value); }
		}

		/// <summary> The Createdby property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."Createdby"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Createdby
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.Createdby, true); }
			set	{ SetValue((int)CampaignFieldIndex.Createdby, value); }
		}

		/// <summary> The ModifiedOn property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."ModifiedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime ModifiedOn
		{
			get { return (System.DateTime)GetValue((int)CampaignFieldIndex.ModifiedOn, true); }
			set	{ SetValue((int)CampaignFieldIndex.ModifiedOn, value); }
		}

		/// <summary> The Modifiedby property of the Entity Campaign<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCampaign"."Modifiedby"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Modifiedby
		{
			get { return (System.Int64)GetValue((int)CampaignFieldIndex.Modifiedby, true); }
			set	{ SetValue((int)CampaignFieldIndex.Modifiedby, value); }
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
					_callQueueCustomer.SetContainingEntityInfo(this, "Campaign");
				}
				return _callQueueCustomer;
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
					_calls.SetContainingEntityInfo(this, "Campaign");
				}
				return _calls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignActivityEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignActivityEntity))]
		public virtual EntityCollection<CampaignActivityEntity> CampaignActivity
		{
			get
			{
				if(_campaignActivity==null)
				{
					_campaignActivity = new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory)));
					_campaignActivity.SetContainingEntityInfo(this, "Campaign");
				}
				return _campaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignAssignmentEntity))]
		public virtual EntityCollection<CampaignAssignmentEntity> CampaignAssignment
		{
			get
			{
				if(_campaignAssignment==null)
				{
					_campaignAssignment = new EntityCollection<CampaignAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignAssignmentEntityFactory)));
					_campaignAssignment.SetContainingEntityInfo(this, "Campaign");
				}
				return _campaignAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailEntity))]
		public virtual EntityCollection<DirectMailEntity> DirectMail
		{
			get
			{
				if(_directMail==null)
				{
					_directMail = new EntityCollection<DirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailEntityFactory)));
					_directMail.SetContainingEntityInfo(this, "Campaign");
				}
				return _directMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomersEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomersEntity))]
		public virtual EntityCollection<EventCustomersEntity> EventCustomers
		{
			get
			{
				if(_eventCustomers==null)
				{
					_eventCustomers = new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory)));
					_eventCustomers.SetContainingEntityInfo(this, "Campaign");
				}
				return _eventCustomers;
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
					_healthPlanCallQueueCriteria.SetContainingEntityInfo(this, "Campaign");
				}
				return _healthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaCalls
		{
			get
			{
				if(_accountCollectionViaCalls==null)
				{
					_accountCollectionViaCalls = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaCalls.IsReadOnly=true;
				}
				return _accountCollectionViaCalls;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				if(_accountCollectionViaHealthPlanCallQueueCriteria==null)
				{
					_accountCollectionViaHealthPlanCallQueueCriteria = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaHealthPlanCallQueueCriteria.IsReadOnly=true;
				}
				return _accountCollectionViaHealthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaCallQueueCustomer
		{
			get
			{
				if(_accountCollectionViaCallQueueCustomer==null)
				{
					_accountCollectionViaCallQueueCustomer = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaCallQueueCustomer.IsReadOnly=true;
				}
				return _accountCollectionViaCallQueueCustomer;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'AfaffiliateCampaignEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfaffiliateCampaignEntity))]
		public virtual EntityCollection<AfaffiliateCampaignEntity> AfaffiliateCampaignCollectionViaEventCustomers
		{
			get
			{
				if(_afaffiliateCampaignCollectionViaEventCustomers==null)
				{
					_afaffiliateCampaignCollectionViaEventCustomers = new EntityCollection<AfaffiliateCampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfaffiliateCampaignEntityFactory)));
					_afaffiliateCampaignCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _afaffiliateCampaignCollectionViaEventCustomers;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CallUploadEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallUploadEntity))]
		public virtual EntityCollection<CallUploadEntity> CallUploadCollectionViaDirectMail
		{
			get
			{
				if(_callUploadCollectionViaDirectMail==null)
				{
					_callUploadCollectionViaDirectMail = new EntityCollection<CallUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallUploadEntityFactory)));
					_callUploadCollectionViaDirectMail.IsReadOnly=true;
				}
				return _callUploadCollectionViaDirectMail;
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
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaDirectMail
		{
			get
			{
				if(_customerProfileCollectionViaDirectMail==null)
				{
					_customerProfileCollectionViaDirectMail = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaDirectMail.IsReadOnly=true;
				}
				return _customerProfileCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaEventCustomers
		{
			get
			{
				if(_customerProfileCollectionViaEventCustomers==null)
				{
					_customerProfileCollectionViaEventCustomers = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerProfileCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileHistoryEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileHistoryEntity))]
		public virtual EntityCollection<CustomerProfileHistoryEntity> CustomerProfileHistoryCollectionViaEventCustomers
		{
			get
			{
				if(_customerProfileHistoryCollectionViaEventCustomers==null)
				{
					_customerProfileHistoryCollectionViaEventCustomers = new EntityCollection<CustomerProfileHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileHistoryEntityFactory)));
					_customerProfileHistoryCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerProfileHistoryCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerRegistrationNotesEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerRegistrationNotesEntity))]
		public virtual EntityCollection<CustomerRegistrationNotesEntity> CustomerRegistrationNotesCollectionViaEventCustomers
		{
			get
			{
				if(_customerRegistrationNotesCollectionViaEventCustomers==null)
				{
					_customerRegistrationNotesCollectionViaEventCustomers = new EntityCollection<CustomerRegistrationNotesEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerRegistrationNotesEntityFactory)));
					_customerRegistrationNotesCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _customerRegistrationNotesCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailTypeEntity))]
		public virtual EntityCollection<DirectMailTypeEntity> DirectMailTypeCollectionViaCampaignActivity
		{
			get
			{
				if(_directMailTypeCollectionViaCampaignActivity==null)
				{
					_directMailTypeCollectionViaCampaignActivity = new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory)));
					_directMailTypeCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _directMailTypeCollectionViaCampaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DirectMailTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DirectMailTypeEntity))]
		public virtual EntityCollection<DirectMailTypeEntity> DirectMailTypeCollectionViaDirectMail
		{
			get
			{
				if(_directMailTypeCollectionViaDirectMail==null)
				{
					_directMailTypeCollectionViaDirectMail = new EntityCollection<DirectMailTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DirectMailTypeEntityFactory)));
					_directMailTypeCollectionViaDirectMail.IsReadOnly=true;
				}
				return _directMailTypeCollectionViaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAppointmentEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAppointmentEntity))]
		public virtual EntityCollection<EventAppointmentEntity> EventAppointmentCollectionViaEventCustomers
		{
			get
			{
				if(_eventAppointmentCollectionViaEventCustomers==null)
				{
					_eventAppointmentCollectionViaEventCustomers = new EntityCollection<EventAppointmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAppointmentEntityFactory)));
					_eventAppointmentCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _eventAppointmentCollectionViaEventCustomers;
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
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventCustomers
		{
			get
			{
				if(_eventsCollectionViaEventCustomers==null)
				{
					_eventsCollectionViaEventCustomers = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _eventsCollectionViaEventCustomers;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'GcNotGivenReasonEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GcNotGivenReasonEntity))]
		public virtual EntityCollection<GcNotGivenReasonEntity> GcNotGivenReasonCollectionViaEventCustomers
		{
			get
			{
				if(_gcNotGivenReasonCollectionViaEventCustomers==null)
				{
					_gcNotGivenReasonCollectionViaEventCustomers = new EntityCollection<GcNotGivenReasonEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GcNotGivenReasonEntityFactory)));
					_gcNotGivenReasonCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _gcNotGivenReasonCollectionViaEventCustomers;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HospitalFacilityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HospitalFacilityEntity))]
		public virtual EntityCollection<HospitalFacilityEntity> HospitalFacilityCollectionViaEventCustomers
		{
			get
			{
				if(_hospitalFacilityCollectionViaEventCustomers==null)
				{
					_hospitalFacilityCollectionViaEventCustomers = new EntityCollection<HospitalFacilityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory)));
					_hospitalFacilityCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _hospitalFacilityCollectionViaEventCustomers;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventCustomers
		{
			get
			{
				if(_lookupCollectionViaEventCustomers==null)
				{
					_lookupCollectionViaEventCustomers = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _lookupCollectionViaEventCustomers;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaEventCustomers_
		{
			get
			{
				if(_lookupCollectionViaEventCustomers_==null)
				{
					_lookupCollectionViaEventCustomers_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaEventCustomers_.IsReadOnly=true;
				}
				return _lookupCollectionViaEventCustomers_;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCampaignActivity
		{
			get
			{
				if(_lookupCollectionViaCampaignActivity==null)
				{
					_lookupCollectionViaCampaignActivity = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _lookupCollectionViaCampaignActivity;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignActivity
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignActivity==null)
				{
					_organizationRoleUserCollectionViaCampaignActivity = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignActivity.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignActivity;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomers
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomers==null)
				{
					_organizationRoleUserCollectionViaEventCustomers = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomers.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomers;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventCustomers_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventCustomers_==null)
				{
					_organizationRoleUserCollectionViaEventCustomers_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventCustomers_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventCustomers_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaDirectMail
		{
			get
			{
				if(_organizationRoleUserCollectionViaDirectMail==null)
				{
					_organizationRoleUserCollectionViaDirectMail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaDirectMail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaDirectMail;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignAssignment==null)
				{
					_organizationRoleUserCollectionViaCampaignAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCampaignActivity_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCampaignActivity_==null)
				{
					_organizationRoleUserCollectionViaCampaignActivity_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCampaignActivity_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCampaignActivity_;
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

		/// <summary> Gets / sets related entity of type 'AccountEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AccountEntity Account
		{
			get
			{
				return _account;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAccount(value);
				}
				else
				{
					if(value==null)
					{
						if(_account != null)
						{
							_account.UnsetRelatedEntity(this, "Campaign");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Campaign");
						}
					}
				}
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
							_lookup_.UnsetRelatedEntity(this, "Campaign_");
						}
					}
					else
					{
						if(_lookup_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Campaign_");
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
							_lookup.UnsetRelatedEntity(this, "Campaign");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Campaign");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "Campaign_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Campaign_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Campaign");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Campaign");
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
			get { return (int)Falcon.Data.EntityType.CampaignEntity; }
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
