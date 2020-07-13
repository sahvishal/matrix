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
	/// Entity class which represents the entity 'CallQueue'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallQueueEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountCallQueueSettingEntity> _accountCallQueueSetting;
		private EntityCollection<CallQueueAssignmentEntity> _callQueueAssignment;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteria;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<CallsEntity> _calls;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteria;
		private EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity> _healthPlanCallQueueCriteriaAssignment;
		private EntityCollection<SystemGeneratedCallQueueAssignmentEntity> _systemGeneratedCallQueueAssignment;
		private EntityCollection<SystemGeneratedCallQueueCriteriaEntity> _systemGenertedCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountCallQueueSetting;
		private EntityCollection<AccountEntity> _accountCollectionViaCalls;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment;
		private EntityCollection<CampaignEntity> _campaignCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCalls;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<CriteriaEntity> _criteriaCollectionViaCallQueueCriteria;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<LanguageEntity> _languageCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls__;
		private EntityCollection<LookupEntity> _lookupCollectionViaCalls_;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccountCallQueueSetting;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCalls;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private EntityCollection<SystemGeneratedCallQueueCriteriaEntity> _systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private ScriptsEntity _scripts;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Scripts</summary>
			public static readonly string Scripts = "Scripts";
			/// <summary>Member name AccountCallQueueSetting</summary>
			public static readonly string AccountCallQueueSetting = "AccountCallQueueSetting";
			/// <summary>Member name CallQueueAssignment</summary>
			public static readonly string CallQueueAssignment = "CallQueueAssignment";
			/// <summary>Member name CallQueueCriteria</summary>
			public static readonly string CallQueueCriteria = "CallQueueCriteria";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name Calls</summary>
			public static readonly string Calls = "Calls";
			/// <summary>Member name HealthPlanCallQueueCriteria</summary>
			public static readonly string HealthPlanCallQueueCriteria = "HealthPlanCallQueueCriteria";
			/// <summary>Member name HealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name SystemGeneratedCallQueueAssignment</summary>
			public static readonly string SystemGeneratedCallQueueAssignment = "SystemGeneratedCallQueueAssignment";
			/// <summary>Member name SystemGenertedCallQueueCriteria</summary>
			public static readonly string SystemGenertedCallQueueCriteria = "SystemGenertedCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string AccountCollectionViaHealthPlanCallQueueCriteria = "AccountCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name AccountCollectionViaAccountCallQueueSetting</summary>
			public static readonly string AccountCollectionViaAccountCallQueueSetting = "AccountCollectionViaAccountCallQueueSetting";
			/// <summary>Member name AccountCollectionViaCalls</summary>
			public static readonly string AccountCollectionViaCalls = "AccountCollectionViaCalls";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment";
			/// <summary>Member name CampaignCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CampaignCollectionViaHealthPlanCallQueueCriteria = "CampaignCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CampaignCollectionViaCalls</summary>
			public static readonly string CampaignCollectionViaCalls = "CampaignCollectionViaCalls";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name CriteriaCollectionViaCallQueueCriteria</summary>
			public static readonly string CriteriaCollectionViaCallQueueCriteria = "CriteriaCollectionViaCallQueueCriteria";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name LanguageCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string LanguageCollectionViaHealthPlanCallQueueCriteria = "LanguageCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCalls</summary>
			public static readonly string LookupCollectionViaCalls = "LookupCollectionViaCalls";
			/// <summary>Member name LookupCollectionViaCalls__</summary>
			public static readonly string LookupCollectionViaCalls__ = "LookupCollectionViaCalls__";
			/// <summary>Member name LookupCollectionViaCalls_</summary>
			public static readonly string LookupCollectionViaCalls_ = "LookupCollectionViaCalls_";
			/// <summary>Member name LookupCollectionViaAccountCallQueueSetting</summary>
			public static readonly string LookupCollectionViaAccountCallQueueSetting = "LookupCollectionViaAccountCallQueueSetting";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ = "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__</summary>
			public static readonly string OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ = "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueAssignment = "OrganizationRoleUserCollectionViaCallQueueAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria = "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCalls</summary>
			public static readonly string OrganizationRoleUserCollectionViaCalls = "OrganizationRoleUserCollectionViaCalls";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";
			/// <summary>Member name SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallQueueEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallQueueEntity():base("CallQueueEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallQueueEntity(IEntityFields2 fields):base("CallQueueEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallQueueEntity</param>
		public CallQueueEntity(IValidator validator):base("CallQueueEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="callQueueId">PK value for CallQueue which data should be fetched into this CallQueue object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueEntity(System.Int64 callQueueId):base("CallQueueEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CallQueueId = callQueueId;
		}

		/// <summary> CTor</summary>
		/// <param name="callQueueId">PK value for CallQueue which data should be fetched into this CallQueue object</param>
		/// <param name="validator">The custom validator object for this CallQueueEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueEntity(System.Int64 callQueueId, IValidator validator):base("CallQueueEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CallQueueId = callQueueId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallQueueEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountCallQueueSetting = (EntityCollection<AccountCallQueueSettingEntity>)info.GetValue("_accountCallQueueSetting", typeof(EntityCollection<AccountCallQueueSettingEntity>));
				_callQueueAssignment = (EntityCollection<CallQueueAssignmentEntity>)info.GetValue("_callQueueAssignment", typeof(EntityCollection<CallQueueAssignmentEntity>));
				_callQueueCriteria = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteria", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_calls = (EntityCollection<CallsEntity>)info.GetValue("_calls", typeof(EntityCollection<CallsEntity>));
				_healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteria", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>)info.GetValue("_healthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>));
				_systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>)info.GetValue("_systemGeneratedCallQueueAssignment", typeof(EntityCollection<SystemGeneratedCallQueueAssignmentEntity>));
				_systemGenertedCallQueueCriteria = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>)info.GetValue("_systemGenertedCallQueueCriteria", typeof(EntityCollection<SystemGeneratedCallQueueCriteriaEntity>));
				_accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaAccountCallQueueSetting = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountCallQueueSetting", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaCalls = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCalls", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<CallQueueCustomerEntity>));
				_campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaCalls = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCalls", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_criteriaCollectionViaCallQueueCriteria = (EntityCollection<CriteriaEntity>)info.GetValue("_criteriaCollectionViaCallQueueCriteria", typeof(EntityCollection<CriteriaEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<LanguageEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCalls = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCalls_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaAccountCallQueueSetting = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccountCallQueueSetting", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCalls", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>)info.GetValue("_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<SystemGeneratedCallQueueCriteriaEntity>));
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
				_scripts = (ScriptsEntity)info.GetValue("_scripts", typeof(ScriptsEntity));
				if(_scripts!=null)
				{
					_scripts.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CallQueueFieldIndex)fieldIndex)
			{
				case CallQueueFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CallQueueFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case CallQueueFieldIndex.ScriptId:
					DesetupSyncScripts(true, false);
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "Scripts":
					this.Scripts = (ScriptsEntity)entity;
					break;
				case "AccountCallQueueSetting":
					this.AccountCallQueueSetting.Add((AccountCallQueueSettingEntity)entity);
					break;
				case "CallQueueAssignment":
					this.CallQueueAssignment.Add((CallQueueAssignmentEntity)entity);
					break;
				case "CallQueueCriteria":
					this.CallQueueCriteria.Add((CallQueueCriteriaEntity)entity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)entity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)entity);
					break;
				case "SystemGenertedCallQueueCriteria":
					this.SystemGenertedCallQueueCriteria.Add((SystemGeneratedCallQueueCriteriaEntity)entity);
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
				case "AccountCollectionViaAccountCallQueueSetting":
					this.AccountCollectionViaAccountCallQueueSetting.IsReadOnly = false;
					this.AccountCollectionViaAccountCallQueueSetting.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountCallQueueSetting.IsReadOnly = true;
					break;
				case "AccountCollectionViaCalls":
					this.AccountCollectionViaCalls.IsReadOnly = false;
					this.AccountCollectionViaCalls.Add((AccountEntity)entity);
					this.AccountCollectionViaCalls.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.Add((CallQueueCriteriaEntity)entity);
					this.CallQueueCriteriaCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment":
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
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
				case "CriteriaCollectionViaCallQueueCriteria":
					this.CriteriaCollectionViaCallQueueCriteria.IsReadOnly = false;
					this.CriteriaCollectionViaCallQueueCriteria.Add((CriteriaEntity)entity);
					this.CriteriaCollectionViaCallQueueCriteria.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventCustomersCollectionViaCallQueueCustomer.Add((EventCustomersEntity)entity);
					this.EventCustomersCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventsCollectionViaCallQueueCustomer":
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.EventsCollectionViaCallQueueCustomer.Add((EventsEntity)entity);
					this.EventsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaEntity)entity);
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "LanguageCollectionViaHealthPlanCallQueueCriteria":
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.Add((LanguageEntity)entity);
					this.LanguageCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls":
					this.LookupCollectionViaCalls.IsReadOnly = false;
					this.LookupCollectionViaCalls.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls__":
					this.LookupCollectionViaCalls__.IsReadOnly = false;
					this.LookupCollectionViaCalls__.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls__.IsReadOnly = true;
					break;
				case "LookupCollectionViaCalls_":
					this.LookupCollectionViaCalls_.IsReadOnly = false;
					this.LookupCollectionViaCalls_.Add((LookupEntity)entity);
					this.LookupCollectionViaCalls_.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccountCallQueueSetting":
					this.LookupCollectionViaAccountCallQueueSetting.IsReadOnly = false;
					this.LookupCollectionViaAccountCallQueueSetting.Add((LookupEntity)entity);
					this.LookupCollectionViaAccountCallQueueSetting.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_":
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__":
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueAssignment":
					this.OrganizationRoleUserCollectionViaCallQueueAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria":
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCalls.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCalls.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueCriteriaEntity)entity);
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
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
			return CallQueueEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser_":
					toReturn.Add(CallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "Scripts":
					toReturn.Add(CallQueueEntity.Relations.ScriptsEntityUsingScriptId);
					break;
				case "AccountCallQueueSetting":
					toReturn.Add(CallQueueEntity.Relations.AccountCallQueueSettingEntityUsingCallQueueId);
					break;
				case "CallQueueAssignment":
					toReturn.Add(CallQueueEntity.Relations.CallQueueAssignmentEntityUsingCallQueueId);
					break;
				case "CallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCriteriaEntityUsingCallQueueId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId);
					break;
				case "Calls":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId);
					break;
				case "HealthPlanCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId);
					break;
				case "SystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId);
					break;
				case "SystemGenertedCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId);
					break;
				case "AccountCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaAccountCallQueueSetting":
					toReturn.Add(CallQueueEntity.Relations.AccountCallQueueSettingEntityUsingCallQueueId, "CallQueueEntity__", "AccountCallQueueSetting_", JoinHint.None);
					toReturn.Add(AccountCallQueueSettingEntity.Relations.AccountEntityUsingAccountId, "AccountCallQueueSetting_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaCalls":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.AccountEntityUsingHealthPlanId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId, "CallQueueEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCalls":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.CampaignEntityUsingCampaignId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CriteriaCollectionViaCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCriteria_", JoinHint.None);
					toReturn.Add(CallQueueCriteriaEntity.Relations.CriteriaEntityUsingCriteriaId, "CallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingNotInterestedReasonId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls__":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingProductTypeId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCalls_":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.LookupEntityUsingDialerType, "Calls_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccountCallQueueSetting":
					toReturn.Add(CallQueueEntity.Relations.AccountCallQueueSettingEntityUsingCallQueueId, "CallQueueEntity__", "AccountCallQueueSetting_", JoinHint.None);
					toReturn.Add(AccountCallQueueSettingEntity.Relations.LookupEntityUsingSuppressionTypeId, "AccountCallQueueSetting_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "SystemGeneratedCallQueueCriteria_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "SystemGeneratedCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "SystemGeneratedCallQueueCriteria_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "SystemGeneratedCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueAssignment":
					toReturn.Add(CallQueueEntity.Relations.CallQueueAssignmentEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueAssignment_", JoinHint.None);
					toReturn.Add(CallQueueAssignmentEntity.Relations.OrganizationRoleUserEntityUsingAssignedOrgRoleUserId, "CallQueueAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "SystemGeneratedCallQueueCriteria_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "SystemGeneratedCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					toReturn.Add(CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId, "CallQueueEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCalls":
					toReturn.Add(CallQueueEntity.Relations.CallsEntityUsingCallQueueId, "CallQueueEntity__", "Calls_", JoinHint.None);
					toReturn.Add(CallsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Calls_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId, "CallQueueEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId, "CallQueueEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "Scripts":
					SetupSyncScripts(relatedEntity);
					break;
				case "AccountCallQueueSetting":
					this.AccountCallQueueSetting.Add((AccountCallQueueSettingEntity)relatedEntity);
					break;
				case "CallQueueAssignment":
					this.CallQueueAssignment.Add((CallQueueAssignmentEntity)relatedEntity);
					break;
				case "CallQueueCriteria":
					this.CallQueueCriteria.Add((CallQueueCriteriaEntity)relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "Calls":
					this.Calls.Add((CallsEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)relatedEntity);
					break;
				case "SystemGenertedCallQueueCriteria":
					this.SystemGenertedCallQueueCriteria.Add((SystemGeneratedCallQueueCriteriaEntity)relatedEntity);
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
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "Scripts":
					DesetupSyncScripts(false, true);
					break;
				case "AccountCallQueueSetting":
					base.PerformRelatedEntityRemoval(this.AccountCallQueueSetting, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueAssignment":
					base.PerformRelatedEntityRemoval(this.CallQueueAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCriteria":
					base.PerformRelatedEntityRemoval(this.CallQueueCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Calls":
					base.PerformRelatedEntityRemoval(this.Calls, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteria":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteria, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemGeneratedCallQueueAssignment":
					base.PerformRelatedEntityRemoval(this.SystemGeneratedCallQueueAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemGenertedCallQueueCriteria":
					base.PerformRelatedEntityRemoval(this.SystemGenertedCallQueueCriteria, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_scripts!=null)
			{
				toReturn.Add(_scripts);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountCallQueueSetting);
			toReturn.Add(this.CallQueueAssignment);
			toReturn.Add(this.CallQueueCriteria);
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.Calls);
			toReturn.Add(this.HealthPlanCallQueueCriteria);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignment);
			toReturn.Add(this.SystemGeneratedCallQueueAssignment);
			toReturn.Add(this.SystemGenertedCallQueueCriteria);

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
				info.AddValue("_accountCallQueueSetting", ((_accountCallQueueSetting!=null) && (_accountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_accountCallQueueSetting:null);
				info.AddValue("_callQueueAssignment", ((_callQueueAssignment!=null) && (_callQueueAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueAssignment:null);
				info.AddValue("_callQueueCriteria", ((_callQueueCriteria!=null) && (_callQueueCriteria.Count>0) && !this.MarkedForDeletion)?_callQueueCriteria:null);
				info.AddValue("_callQueueCustomer", ((_callQueueCustomer!=null) && (_callQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCustomer:null);
				info.AddValue("_calls", ((_calls!=null) && (_calls.Count>0) && !this.MarkedForDeletion)?_calls:null);
				info.AddValue("_healthPlanCallQueueCriteria", ((_healthPlanCallQueueCriteria!=null) && (_healthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteria:null);
				info.AddValue("_healthPlanCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_systemGeneratedCallQueueAssignment", ((_systemGeneratedCallQueueAssignment!=null) && (_systemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_systemGeneratedCallQueueAssignment:null);
				info.AddValue("_systemGenertedCallQueueCriteria", ((_systemGenertedCallQueueCriteria!=null) && (_systemGenertedCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_systemGenertedCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaHealthPlanCallQueueCriteria", ((_accountCollectionViaHealthPlanCallQueueCriteria!=null) && (_accountCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_accountCollectionViaAccountCallQueueSetting", ((_accountCollectionViaAccountCallQueueSetting!=null) && (_accountCollectionViaAccountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountCallQueueSetting:null);
				info.AddValue("_accountCollectionViaCalls", ((_accountCollectionViaCalls!=null) && (_accountCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCalls:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", ((_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_campaignCollectionViaHealthPlanCallQueueCriteria", ((_campaignCollectionViaHealthPlanCallQueueCriteria!=null) && (_campaignCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_campaignCollectionViaCalls", ((_campaignCollectionViaCalls!=null) && (_campaignCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCalls:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_criteriaCollectionViaCallQueueCriteria", ((_criteriaCollectionViaCallQueueCriteria!=null) && (_criteriaCollectionViaCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_criteriaCollectionViaCallQueueCriteria:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_languageCollectionViaHealthPlanCallQueueCriteria", ((_languageCollectionViaHealthPlanCallQueueCriteria!=null) && (_languageCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCalls", ((_lookupCollectionViaCalls!=null) && (_lookupCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls:null);
				info.AddValue("_lookupCollectionViaCalls__", ((_lookupCollectionViaCalls__!=null) && (_lookupCollectionViaCalls__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls__:null);
				info.AddValue("_lookupCollectionViaCalls_", ((_lookupCollectionViaCalls_!=null) && (_lookupCollectionViaCalls_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCalls_:null);
				info.AddValue("_lookupCollectionViaAccountCallQueueSetting", ((_lookupCollectionViaAccountCallQueueSetting!=null) && (_lookupCollectionViaAccountCallQueueSetting.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccountCallQueueSetting:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_", ((_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_!=null) && (_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__", ((_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__!=null) && (_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueAssignment", ((_organizationRoleUserCollectionViaCallQueueAssignment!=null) && (_organizationRoleUserCollectionViaCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria", ((_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria!=null) && (_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaCalls", ((_organizationRoleUserCollectionViaCalls!=null) && (_organizationRoleUserCollectionViaCalls.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCalls:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", ((_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_scripts", (!this.MarkedForDeletion?_scripts:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CallQueueFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallQueueFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallQueueRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCallQueueSetting' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCallQueueSettingFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueAssignmentFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallsFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaAssignmentFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueAssignmentFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGenertedCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueCriteriaFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountCallQueueSetting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Criteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCriteriaCollectionViaCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CriteriaCollectionViaCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCalls_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCalls_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccountCallQueueSetting()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccountCallQueueSetting"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCalls()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCalls"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId, "CallQueueEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Scripts' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScripts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScriptsFields.ScriptId, null, ComparisonOperator.Equal, this.ScriptId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallQueueEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountCallQueueSetting);
			collectionsQueue.Enqueue(this._callQueueAssignment);
			collectionsQueue.Enqueue(this._callQueueCriteria);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._calls);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._systemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._systemGenertedCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountCallQueueSetting);
			collectionsQueue.Enqueue(this._accountCollectionViaCalls);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._campaignCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._campaignCollectionViaCalls);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._criteriaCollectionViaCallQueueCriteria);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._languageCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls__);
			collectionsQueue.Enqueue(this._lookupCollectionViaCalls_);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccountCallQueueSetting);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCalls);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountCallQueueSetting = (EntityCollection<AccountCallQueueSettingEntity>) collectionsQueue.Dequeue();
			this._callQueueAssignment = (EntityCollection<CallQueueAssignmentEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteria = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._calls = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>) collectionsQueue.Dequeue();
			this._systemGenertedCallQueueCriteria = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountCallQueueSetting = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCalls = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCalls = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._criteriaCollectionViaCallQueueCriteria = (EntityCollection<CriteriaEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCalls_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccountCallQueueSetting = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCalls = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountCallQueueSetting != null)
			{
				return true;
			}
			if (this._callQueueAssignment != null)
			{
				return true;
			}
			if (this._callQueueCriteria != null)
			{
				return true;
			}
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._calls != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._systemGeneratedCallQueueAssignment != null)
			{
				return true;
			}
			if (this._systemGenertedCallQueueCriteria != null)
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
			if (this._accountCollectionViaAccountCallQueueSetting != null)
			{
				return true;
			}
			if (this._accountCollectionViaCalls != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCriteriaCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment != null)
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
			if (this._criteriaCollectionViaCallQueueCriteria != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventCustomersCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._languageCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCalls_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccountCallQueueSetting != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCalls != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCallQueueSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallQueueSettingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Scripts", _scripts);
			toReturn.Add("AccountCallQueueSetting", _accountCallQueueSetting);
			toReturn.Add("CallQueueAssignment", _callQueueAssignment);
			toReturn.Add("CallQueueCriteria", _callQueueCriteria);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("Calls", _calls);
			toReturn.Add("HealthPlanCallQueueCriteria", _healthPlanCallQueueCriteria);
			toReturn.Add("HealthPlanCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaAssignment);
			toReturn.Add("SystemGeneratedCallQueueAssignment", _systemGeneratedCallQueueAssignment);
			toReturn.Add("SystemGenertedCallQueueCriteria", _systemGenertedCallQueueCriteria);
			toReturn.Add("AccountCollectionViaHealthPlanCallQueueCriteria", _accountCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("AccountCollectionViaAccountCallQueueSetting", _accountCollectionViaAccountCallQueueSetting);
			toReturn.Add("AccountCollectionViaCalls", _accountCollectionViaCalls);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", _callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment);
			toReturn.Add("CampaignCollectionViaHealthPlanCallQueueCriteria", _campaignCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CampaignCollectionViaCalls", _campaignCollectionViaCalls);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("CriteriaCollectionViaCallQueueCriteria", _criteriaCollectionViaCallQueueCriteria);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("LanguageCollectionViaHealthPlanCallQueueCriteria", _languageCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCalls", _lookupCollectionViaCalls);
			toReturn.Add("LookupCollectionViaCalls__", _lookupCollectionViaCalls__);
			toReturn.Add("LookupCollectionViaCalls_", _lookupCollectionViaCalls_);
			toReturn.Add("LookupCollectionViaAccountCallQueueSetting", _lookupCollectionViaAccountCallQueueSetting);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_", _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__", _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueAssignment", _organizationRoleUserCollectionViaCallQueueAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria", _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaCalls", _organizationRoleUserCollectionViaCalls);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);
			toReturn.Add("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", _systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountCallQueueSetting!=null)
			{
				_accountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_callQueueAssignment!=null)
			{
				_callQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteria!=null)
			{
				_callQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_calls!=null)
			{
				_calls.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteria!=null)
			{
				_healthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_systemGeneratedCallQueueAssignment!=null)
			{
				_systemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_systemGenertedCallQueueCriteria!=null)
			{
				_systemGenertedCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_accountCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountCallQueueSetting!=null)
			{
				_accountCollectionViaAccountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCalls!=null)
			{
				_accountCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
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
			if(_criteriaCollectionViaCallQueueCriteria!=null)
			{
				_criteriaCollectionViaCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_languageCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls!=null)
			{
				_lookupCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls__!=null)
			{
				_lookupCollectionViaCalls__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCalls_!=null)
			{
				_lookupCollectionViaCalls_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccountCallQueueSetting!=null)
			{
				_lookupCollectionViaAccountCallQueueSetting.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_!=null)
			{
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__!=null)
			{
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueAssignment!=null)
			{
				_organizationRoleUserCollectionViaCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria!=null)
			{
				_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCalls!=null)
			{
				_organizationRoleUserCollectionViaCalls.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_scripts!=null)
			{
				_scripts.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountCallQueueSetting = null;
			_callQueueAssignment = null;
			_callQueueCriteria = null;
			_callQueueCustomer = null;
			_calls = null;
			_healthPlanCallQueueCriteria = null;
			_healthPlanCallQueueCriteriaAssignment = null;
			_systemGeneratedCallQueueAssignment = null;
			_systemGenertedCallQueueCriteria = null;
			_accountCollectionViaHealthPlanCallQueueCriteria = null;
			_accountCollectionViaCallQueueCustomer = null;
			_accountCollectionViaAccountCallQueueSetting = null;
			_accountCollectionViaCalls = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = null;
			_campaignCollectionViaHealthPlanCallQueueCriteria = null;
			_campaignCollectionViaCalls = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_criteriaCollectionViaCallQueueCriteria = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_languageCollectionViaHealthPlanCallQueueCriteria = null;
			_languageCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCalls = null;
			_lookupCollectionViaCalls__ = null;
			_lookupCollectionViaCalls_ = null;
			_lookupCollectionViaAccountCallQueueSetting = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ = null;
			_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ = null;
			_organizationRoleUserCollectionViaCallQueueAssignment = null;
			_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = null;
			_organizationRoleUserCollectionViaCalls = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;
			_scripts = null;

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

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Attempts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsQueueGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QueueGenerationInterval", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastQueueGeneratedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ScriptId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManual", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Category", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHealthPlan", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "CallQueue_", resetFKFields, new int[] { (int)CallQueueFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "CallQueue", resetFKFields, new int[] { (int)CallQueueFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _scripts</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncScripts(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _scripts, new PropertyChangedEventHandler( OnScriptsPropertyChanged ), "Scripts", CallQueueEntity.Relations.ScriptsEntityUsingScriptId, true, signalRelatedEntity, "CallQueue", resetFKFields, new int[] { (int)CallQueueFieldIndex.ScriptId } );		
			_scripts = null;
		}

		/// <summary> setups the sync logic for member _scripts</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncScripts(IEntity2 relatedEntity)
		{
			if(_scripts!=relatedEntity)
			{
				DesetupSyncScripts(true, true);
				_scripts = (ScriptsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _scripts, new PropertyChangedEventHandler( OnScriptsPropertyChanged ), "Scripts", CallQueueEntity.Relations.ScriptsEntityUsingScriptId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnScriptsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CallQueueEntity</param>
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
		public  static CallQueueRelations Relations
		{
			get	{ return new CallQueueRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCallQueueSetting' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCallQueueSetting
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCallQueueSettingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallQueueSettingEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCallQueueSetting")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.AccountCallQueueSettingEntity, 0, null, null, null, null, "AccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueAssignment")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueAssignmentEntity, 0, null, null, null, null, "CallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteria
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCriteria")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, null, null, "CallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Calls")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, null, null, "Calls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteria")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGeneratedCallQueueAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("SystemGeneratedCallQueueAssignment")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, 0, null, null, null, null, "SystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGenertedCallQueueCriteria
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("SystemGenertedCallQueueCriteria")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, 0, null, null, null, null, "SystemGenertedCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaHealthPlanCallQueueCriteria"), null, "AccountCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountCallQueueSetting
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.AccountCallQueueSettingEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallQueueSetting_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountCallQueueSetting"), null, "AccountCollectionViaAccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCalls"), null, "AccountCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment"), null, "CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaHealthPlanCallQueueCriteria"), null, "CampaignCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCalls"), null, "CampaignCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Criteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCriteriaCollectionViaCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CriteriaEntity, 0, null, null, GetRelationsForField("CriteriaCollectionViaCallQueueCriteria"), null, "CriteriaCollectionViaCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaHealthPlanCallQueueCriteria"), null, "LanguageCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls"), null, "LookupCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls__
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls__"), null, "LookupCollectionViaCalls__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCalls_
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCalls_"), null, "LookupCollectionViaCalls_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccountCallQueueSetting
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.AccountCallQueueSettingEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallQueueSetting_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccountCallQueueSetting"), null, "LookupCollectionViaAccountCallQueueSetting", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_"), null, "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__"), null, "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueAssignmentEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueAssignment"), null, "OrganizationRoleUserCollectionViaCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria"), null, "OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCalls
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallsEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "Calls_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCalls"), null, "OrganizationRoleUserCollectionViaCalls", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.CallQueueCustomerEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment"), null, "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Scripts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScripts
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ScriptsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Scripts")[0], (int)Falcon.Data.EntityType.CallQueueEntity, (int)Falcon.Data.EntityType.ScriptsEntity, 0, null, null, null, null, "Scripts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallQueueEntity.CustomProperties;}
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
			get { return CallQueueEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallQueueId property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)CallQueueFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)CallQueueFieldIndex.CallQueueId, value); }
		}

		/// <summary> The Name property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CallQueueFieldIndex.Name, true); }
			set	{ SetValue((int)CallQueueFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)CallQueueFieldIndex.Description, true); }
			set	{ SetValue((int)CallQueueFieldIndex.Description, value); }
		}

		/// <summary> The Attempts property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."Attempts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Attempts
		{
			get { return (System.Int32)GetValue((int)CallQueueFieldIndex.Attempts, true); }
			set	{ SetValue((int)CallQueueFieldIndex.Attempts, value); }
		}

		/// <summary> The DateCreated property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CallQueueFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CallQueueFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueFieldIndex.DateModified, false); }
			set	{ SetValue((int)CallQueueFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)CallQueueFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)CallQueueFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)CallQueueFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The IsActive property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CallQueueFieldIndex.IsActive, true); }
			set	{ SetValue((int)CallQueueFieldIndex.IsActive, value); }
		}

		/// <summary> The IsQueueGenerated property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."IsQueueGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsQueueGenerated
		{
			get { return (System.Boolean)GetValue((int)CallQueueFieldIndex.IsQueueGenerated, true); }
			set	{ SetValue((int)CallQueueFieldIndex.IsQueueGenerated, value); }
		}

		/// <summary> The QueueGenerationInterval property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."QueueGenerationInterval"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> QueueGenerationInterval
		{
			get { return (Nullable<System.Int32>)GetValue((int)CallQueueFieldIndex.QueueGenerationInterval, false); }
			set	{ SetValue((int)CallQueueFieldIndex.QueueGenerationInterval, value); }
		}

		/// <summary> The LastQueueGeneratedDate property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."LastQueueGeneratedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastQueueGeneratedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueFieldIndex.LastQueueGeneratedDate, false); }
			set	{ SetValue((int)CallQueueFieldIndex.LastQueueGeneratedDate, value); }
		}

		/// <summary> The ScriptId property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."ScriptId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ScriptId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueFieldIndex.ScriptId, false); }
			set	{ SetValue((int)CallQueueFieldIndex.ScriptId, value); }
		}

		/// <summary> The IsManual property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."IsManual"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsManual
		{
			get { return (System.Boolean)GetValue((int)CallQueueFieldIndex.IsManual, true); }
			set	{ SetValue((int)CallQueueFieldIndex.IsManual, value); }
		}

		/// <summary> The Category property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."Category"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Category
		{
			get { return (System.String)GetValue((int)CallQueueFieldIndex.Category, true); }
			set	{ SetValue((int)CallQueueFieldIndex.Category, value); }
		}

		/// <summary> The IsHealthPlan property of the Entity CallQueue<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueue"."IsHealthPlan"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsHealthPlan
		{
			get { return (System.Boolean)GetValue((int)CallQueueFieldIndex.IsHealthPlan, true); }
			set	{ SetValue((int)CallQueueFieldIndex.IsHealthPlan, value); }
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
					_accountCallQueueSetting.SetContainingEntityInfo(this, "CallQueue");
				}
				return _accountCallQueueSetting;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueAssignmentEntity))]
		public virtual EntityCollection<CallQueueAssignmentEntity> CallQueueAssignment
		{
			get
			{
				if(_callQueueAssignment==null)
				{
					_callQueueAssignment = new EntityCollection<CallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueAssignmentEntityFactory)));
					_callQueueAssignment.SetContainingEntityInfo(this, "CallQueue");
				}
				return _callQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCriteriaEntity))]
		public virtual EntityCollection<CallQueueCriteriaEntity> CallQueueCriteria
		{
			get
			{
				if(_callQueueCriteria==null)
				{
					_callQueueCriteria = new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory)));
					_callQueueCriteria.SetContainingEntityInfo(this, "CallQueue");
				}
				return _callQueueCriteria;
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
					_callQueueCustomer.SetContainingEntityInfo(this, "CallQueue");
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
					_calls.SetContainingEntityInfo(this, "CallQueue");
				}
				return _calls;
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
					_healthPlanCallQueueCriteria.SetContainingEntityInfo(this, "CallQueue");
				}
				return _healthPlanCallQueueCriteria;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity> HealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				if(_healthPlanCallQueueCriteriaAssignment==null)
				{
					_healthPlanCallQueueCriteriaAssignment = new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaAssignmentEntityFactory)));
					_healthPlanCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "CallQueue");
				}
				return _healthPlanCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemGeneratedCallQueueAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SystemGeneratedCallQueueAssignmentEntity))]
		public virtual EntityCollection<SystemGeneratedCallQueueAssignmentEntity> SystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_systemGeneratedCallQueueAssignment==null)
				{
					_systemGeneratedCallQueueAssignment = new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory)));
					_systemGeneratedCallQueueAssignment.SetContainingEntityInfo(this, "CallQueue");
				}
				return _systemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemGeneratedCallQueueCriteriaEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SystemGeneratedCallQueueCriteriaEntity))]
		public virtual EntityCollection<SystemGeneratedCallQueueCriteriaEntity> SystemGenertedCallQueueCriteria
		{
			get
			{
				if(_systemGenertedCallQueueCriteria==null)
				{
					_systemGenertedCallQueueCriteria = new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory)));
					_systemGenertedCallQueueCriteria.SetContainingEntityInfo(this, "CallQueue");
				}
				return _systemGenertedCallQueueCriteria;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountCallQueueSetting
		{
			get
			{
				if(_accountCollectionViaAccountCallQueueSetting==null)
				{
					_accountCollectionViaAccountCallQueueSetting = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountCallQueueSetting.IsReadOnly=true;
				}
				return _accountCollectionViaAccountCallQueueSetting;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				if(_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment==null)
				{
					_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerEntity))]
		public virtual EntityCollection<CallQueueCustomerEntity> CallQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment==null)
				{
					_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment = new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory)));
					_callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly=true;
				}
				return _callQueueCustomerCollectionViaSystemGeneratedCallQueueAssignment;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CriteriaEntity))]
		public virtual EntityCollection<CriteriaEntity> CriteriaCollectionViaCallQueueCriteria
		{
			get
			{
				if(_criteriaCollectionViaCallQueueCriteria==null)
				{
					_criteriaCollectionViaCallQueueCriteria = new EntityCollection<CriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CriteriaEntityFactory)));
					_criteriaCollectionViaCallQueueCriteria.IsReadOnly=true;
				}
				return _criteriaCollectionViaCallQueueCriteria;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCallQueueCriteriaEntity))]
		public virtual EntityCollection<HealthPlanCallQueueCriteriaEntity> HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment==null)
				{
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory)));
					_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_
		{
			get
			{
				if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_==null)
				{
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__
		{
			get
			{
				if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__==null)
				{
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCallQueueAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaCallQueueAssignment==null)
				{
					_organizationRoleUserCollectionViaCallQueueAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCallQueueAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaSystemGenertedCallQueueCriteria
		{
			get
			{
				if(_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria==null)
				{
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaSystemGenertedCallQueueCriteria;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria__
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria__;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'SystemGeneratedCallQueueCriteriaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SystemGeneratedCallQueueCriteriaEntity))]
		public virtual EntityCollection<SystemGeneratedCallQueueCriteriaEntity> SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment==null)
				{
					_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory)));
					_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly=true;
				}
				return _systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CallQueue_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueue_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CallQueue");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueue");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ScriptsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ScriptsEntity Scripts
		{
			get
			{
				return _scripts;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncScripts(value);
				}
				else
				{
					if(value==null)
					{
						if(_scripts != null)
						{
							_scripts.UnsetRelatedEntity(this, "CallQueue");
						}
					}
					else
					{
						if(_scripts!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueue");
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
			get { return (int)Falcon.Data.EntityType.CallQueueEntity; }
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
