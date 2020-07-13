///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:45
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
	/// Entity class which represents the entity 'NotesDetails'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NotesDetailsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfile;
		private EntityCollection<EventsEntity> _events;
		private EntityCollection<PriorityInQueueEntity> _priorityInQueue;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCustomerProfile;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerProfile;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<CommunicationModeEntity> _communicationModeCollectionViaEvents;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<EventCustomerResultEntity> _eventCustomerResultCollectionViaPriorityInQueue;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<EventTypeEntity> _eventTypeCollectionViaEvents;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaEvents;
		private EntityCollection<LabEntity> _labCollectionViaCustomerProfile;
		private EntityCollection<LanguageEntity> _languageCollectionViaCallQueueCustomer;
		private EntityCollection<LanguageEntity> _languageCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile________;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents___;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents____;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents_;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents;
		private EntityCollection<LookupEntity> _lookupCollectionViaEvents__;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile___;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents____;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPriorityInQueue_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaPriorityInQueue;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents___;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEvents__;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private EntityCollection<RoleEntity> _roleCollectionViaCustomerProfile;
		private EntityCollection<ScheduleMethodEntity> _scheduleMethodCollectionViaEvents;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private CriticalCustomerCommunicationRecordEntity _criticalCustomerCommunicationRecord;
		private HospitalPartnerEventNotesEntity _hospitalPartnerEventNotes;
		
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
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name PriorityInQueue</summary>
			public static readonly string PriorityInQueue = "PriorityInQueue";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCustomerProfile</summary>
			public static readonly string ActivityTypeCollectionViaCustomerProfile = "ActivityTypeCollectionViaCustomerProfile";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name AddressCollectionViaCustomerProfile</summary>
			public static readonly string AddressCollectionViaCustomerProfile = "AddressCollectionViaCustomerProfile";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name CommunicationModeCollectionViaEvents</summary>
			public static readonly string CommunicationModeCollectionViaEvents = "CommunicationModeCollectionViaEvents";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name EventCustomerResultCollectionViaPriorityInQueue</summary>
			public static readonly string EventCustomerResultCollectionViaPriorityInQueue = "EventCustomerResultCollectionViaPriorityInQueue";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name EventTypeCollectionViaEvents</summary>
			public static readonly string EventTypeCollectionViaEvents = "EventTypeCollectionViaEvents";
			/// <summary>Member name HafTemplateCollectionViaEvents</summary>
			public static readonly string HafTemplateCollectionViaEvents = "HafTemplateCollectionViaEvents";
			/// <summary>Member name LabCollectionViaCustomerProfile</summary>
			public static readonly string LabCollectionViaCustomerProfile = "LabCollectionViaCustomerProfile";
			/// <summary>Member name LanguageCollectionViaCallQueueCustomer</summary>
			public static readonly string LanguageCollectionViaCallQueueCustomer = "LanguageCollectionViaCallQueueCustomer";
			/// <summary>Member name LanguageCollectionViaCustomerProfile</summary>
			public static readonly string LanguageCollectionViaCustomerProfile = "LanguageCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile____</summary>
			public static readonly string LookupCollectionViaCustomerProfile____ = "LookupCollectionViaCustomerProfile____";
			/// <summary>Member name LookupCollectionViaCustomerProfile________</summary>
			public static readonly string LookupCollectionViaCustomerProfile________ = "LookupCollectionViaCustomerProfile________";
			/// <summary>Member name LookupCollectionViaEvents___</summary>
			public static readonly string LookupCollectionViaEvents___ = "LookupCollectionViaEvents___";
			/// <summary>Member name LookupCollectionViaEvents____</summary>
			public static readonly string LookupCollectionViaEvents____ = "LookupCollectionViaEvents____";
			/// <summary>Member name LookupCollectionViaEvents_</summary>
			public static readonly string LookupCollectionViaEvents_ = "LookupCollectionViaEvents_";
			/// <summary>Member name LookupCollectionViaEvents</summary>
			public static readonly string LookupCollectionViaEvents = "LookupCollectionViaEvents";
			/// <summary>Member name LookupCollectionViaEvents__</summary>
			public static readonly string LookupCollectionViaEvents__ = "LookupCollectionViaEvents__";
			/// <summary>Member name LookupCollectionViaCustomerProfile______</summary>
			public static readonly string LookupCollectionViaCustomerProfile______ = "LookupCollectionViaCustomerProfile______";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCustomerProfile_</summary>
			public static readonly string LookupCollectionViaCustomerProfile_ = "LookupCollectionViaCustomerProfile_";
			/// <summary>Member name LookupCollectionViaCustomerProfile_______</summary>
			public static readonly string LookupCollectionViaCustomerProfile_______ = "LookupCollectionViaCustomerProfile_______";
			/// <summary>Member name LookupCollectionViaCustomerProfile</summary>
			public static readonly string LookupCollectionViaCustomerProfile = "LookupCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile_____</summary>
			public static readonly string LookupCollectionViaCustomerProfile_____ = "LookupCollectionViaCustomerProfile_____";
			/// <summary>Member name LookupCollectionViaCustomerProfile___</summary>
			public static readonly string LookupCollectionViaCustomerProfile___ = "LookupCollectionViaCustomerProfile___";
			/// <summary>Member name LookupCollectionViaCustomerProfile__</summary>
			public static readonly string LookupCollectionViaCustomerProfile__ = "LookupCollectionViaCustomerProfile__";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents____</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents____ = "OrganizationRoleUserCollectionViaEvents____";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaPriorityInQueue_</summary>
			public static readonly string OrganizationRoleUserCollectionViaPriorityInQueue_ = "OrganizationRoleUserCollectionViaPriorityInQueue_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaPriorityInQueue</summary>
			public static readonly string OrganizationRoleUserCollectionViaPriorityInQueue = "OrganizationRoleUserCollectionViaPriorityInQueue";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents___</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents___ = "OrganizationRoleUserCollectionViaEvents___";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents = "OrganizationRoleUserCollectionViaEvents";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents_ = "OrganizationRoleUserCollectionViaEvents_";
			/// <summary>Member name OrganizationRoleUserCollectionViaEvents__</summary>
			public static readonly string OrganizationRoleUserCollectionViaEvents__ = "OrganizationRoleUserCollectionViaEvents__";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";
			/// <summary>Member name RoleCollectionViaCustomerProfile</summary>
			public static readonly string RoleCollectionViaCustomerProfile = "RoleCollectionViaCustomerProfile";
			/// <summary>Member name ScheduleMethodCollectionViaEvents</summary>
			public static readonly string ScheduleMethodCollectionViaEvents = "ScheduleMethodCollectionViaEvents";
			/// <summary>Member name CriticalCustomerCommunicationRecord</summary>
			public static readonly string CriticalCustomerCommunicationRecord = "CriticalCustomerCommunicationRecord";
			/// <summary>Member name HospitalPartnerEventNotes</summary>
			public static readonly string HospitalPartnerEventNotes = "HospitalPartnerEventNotes";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NotesDetailsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NotesDetailsEntity():base("NotesDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NotesDetailsEntity(IEntityFields2 fields):base("NotesDetailsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NotesDetailsEntity</param>
		public NotesDetailsEntity(IValidator validator):base("NotesDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="noteId">PK value for NotesDetails which data should be fetched into this NotesDetails object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotesDetailsEntity(System.Int64 noteId):base("NotesDetailsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NoteId = noteId;
		}

		/// <summary> CTor</summary>
		/// <param name="noteId">PK value for NotesDetails which data should be fetched into this NotesDetails object</param>
		/// <param name="validator">The custom validator object for this NotesDetailsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NotesDetailsEntity(System.Int64 noteId, IValidator validator):base("NotesDetailsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NoteId = noteId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NotesDetailsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_customerProfile = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfile", typeof(EntityCollection<CustomerProfileEntity>));
				_events = (EntityCollection<EventsEntity>)info.GetValue("_events", typeof(EntityCollection<EventsEntity>));
				_priorityInQueue = (EntityCollection<PriorityInQueueEntity>)info.GetValue("_priorityInQueue", typeof(EntityCollection<PriorityInQueueEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCustomerProfile", typeof(EntityCollection<ActivityTypeEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerProfile", typeof(EntityCollection<AddressEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_communicationModeCollectionViaEvents = (EntityCollection<CommunicationModeEntity>)info.GetValue("_communicationModeCollectionViaEvents", typeof(EntityCollection<CommunicationModeEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomerResultCollectionViaPriorityInQueue = (EntityCollection<EventCustomerResultEntity>)info.GetValue("_eventCustomerResultCollectionViaPriorityInQueue", typeof(EntityCollection<EventCustomerResultEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>)info.GetValue("_eventTypeCollectionViaEvents", typeof(EntityCollection<EventTypeEntity>));
				_hafTemplateCollectionViaEvents = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaEvents", typeof(EntityCollection<HafTemplateEntity>));
				_labCollectionViaCustomerProfile = (EntityCollection<LabEntity>)info.GetValue("_labCollectionViaCustomerProfile", typeof(EntityCollection<LabEntity>));
				_languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCallQueueCustomer", typeof(EntityCollection<LanguageEntity>));
				_languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCustomerProfile", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaEvents__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile__", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents____", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPriorityInQueue_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPriorityInQueue_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaPriorityInQueue = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaPriorityInQueue", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents___", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEvents__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaCustomerProfile", typeof(EntityCollection<RoleEntity>));
				_scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>)info.GetValue("_scheduleMethodCollectionViaEvents", typeof(EntityCollection<ScheduleMethodEntity>));
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
				_criticalCustomerCommunicationRecord = (CriticalCustomerCommunicationRecordEntity)info.GetValue("_criticalCustomerCommunicationRecord", typeof(CriticalCustomerCommunicationRecordEntity));
				if(_criticalCustomerCommunicationRecord!=null)
				{
					_criticalCustomerCommunicationRecord.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hospitalPartnerEventNotes = (HospitalPartnerEventNotesEntity)info.GetValue("_hospitalPartnerEventNotes", typeof(HospitalPartnerEventNotesEntity));
				if(_hospitalPartnerEventNotes!=null)
				{
					_hospitalPartnerEventNotes.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((NotesDetailsFieldIndex)fieldIndex)
			{
				case NotesDetailsFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case NotesDetailsFieldIndex.ModifiedByOrgRoleUserId:
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
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)entity);
					break;
				case "Events":
					this.Events.Add((EventsEntity)entity);
					break;
				case "PriorityInQueue":
					this.PriorityInQueue.Add((PriorityInQueueEntity)entity);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.AccountCollectionViaCallQueueCustomer.Add((AccountEntity)entity);
					this.AccountCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = false;
					this.ActivityTypeCollectionViaCustomerProfile.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ActivityTypeCollectionViaCallQueueCustomer.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "AddressCollectionViaCustomerProfile":
					this.AddressCollectionViaCustomerProfile.IsReadOnly = false;
					this.AddressCollectionViaCustomerProfile.Add((AddressEntity)entity);
					this.AddressCollectionViaCustomerProfile.IsReadOnly = true;
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
				case "CampaignCollectionViaCallQueueCustomer":
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CampaignCollectionViaCallQueueCustomer.Add((CampaignEntity)entity);
					this.CampaignCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "CommunicationModeCollectionViaEvents":
					this.CommunicationModeCollectionViaEvents.IsReadOnly = false;
					this.CommunicationModeCollectionViaEvents.Add((CommunicationModeEntity)entity);
					this.CommunicationModeCollectionViaEvents.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.CustomerProfileCollectionViaCallQueueCustomer.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "EventCustomerResultCollectionViaPriorityInQueue":
					this.EventCustomerResultCollectionViaPriorityInQueue.IsReadOnly = false;
					this.EventCustomerResultCollectionViaPriorityInQueue.Add((EventCustomerResultEntity)entity);
					this.EventCustomerResultCollectionViaPriorityInQueue.IsReadOnly = true;
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
				case "EventTypeCollectionViaEvents":
					this.EventTypeCollectionViaEvents.IsReadOnly = false;
					this.EventTypeCollectionViaEvents.Add((EventTypeEntity)entity);
					this.EventTypeCollectionViaEvents.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaEvents":
					this.HafTemplateCollectionViaEvents.IsReadOnly = false;
					this.HafTemplateCollectionViaEvents.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaEvents.IsReadOnly = true;
					break;
				case "LabCollectionViaCustomerProfile":
					this.LabCollectionViaCustomerProfile.IsReadOnly = false;
					this.LabCollectionViaCustomerProfile.Add((LabEntity)entity);
					this.LabCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LanguageCollectionViaCallQueueCustomer.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCustomerProfile":
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = false;
					this.LanguageCollectionViaCustomerProfile.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile____":
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile________":
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile________.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents___":
					this.LookupCollectionViaEvents___.IsReadOnly = false;
					this.LookupCollectionViaEvents___.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents___.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents____":
					this.LookupCollectionViaEvents____.IsReadOnly = false;
					this.LookupCollectionViaEvents____.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents____.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents_":
					this.LookupCollectionViaEvents_.IsReadOnly = false;
					this.LookupCollectionViaEvents_.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents_.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents":
					this.LookupCollectionViaEvents.IsReadOnly = false;
					this.LookupCollectionViaEvents.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents.IsReadOnly = true;
					break;
				case "LookupCollectionViaEvents__":
					this.LookupCollectionViaEvents__.IsReadOnly = false;
					this.LookupCollectionViaEvents__.Add((LookupEntity)entity);
					this.LookupCollectionViaEvents__.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile______":
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = true;
					break;
				case "LookupCollectionViaCallQueueCustomer":
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.LookupCollectionViaCallQueueCustomer.Add((LookupEntity)entity);
					this.LookupCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_":
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_______":
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile":
					this.LookupCollectionViaCustomerProfile.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_____":
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile___":
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile___.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile__":
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile__.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents____.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents____.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue_":
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue":
					this.OrganizationRoleUserCollectionViaPriorityInQueue.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaPriorityInQueue.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaPriorityInQueue.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents___.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents___.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEvents__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEvents__.IsReadOnly = true;
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.ProspectCustomerCollectionViaCallQueueCustomer.Add((ProspectCustomerEntity)entity);
					this.ProspectCustomerCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "RoleCollectionViaCustomerProfile":
					this.RoleCollectionViaCustomerProfile.IsReadOnly = false;
					this.RoleCollectionViaCustomerProfile.Add((RoleEntity)entity);
					this.RoleCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "ScheduleMethodCollectionViaEvents":
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = false;
					this.ScheduleMethodCollectionViaEvents.Add((ScheduleMethodEntity)entity);
					this.ScheduleMethodCollectionViaEvents.IsReadOnly = true;
					break;
				case "CriticalCustomerCommunicationRecord":
					this.CriticalCustomerCommunicationRecord = (CriticalCustomerCommunicationRecordEntity)entity;
					break;
				case "HospitalPartnerEventNotes":
					this.HospitalPartnerEventNotes = (HospitalPartnerEventNotesEntity)entity;
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
			return NotesDetailsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId);
					break;
				case "CustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId);
					break;
				case "Events":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId);
					break;
				case "PriorityInQueue":
					toReturn.Add(NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.ActivityTypeEntityUsingActivityId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.AddressEntityUsingBillingAddressId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CommunicationModeCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.CommunicationModeEntityUsingCommunicationModeId, "Events_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomerResultCollectionViaPriorityInQueue":
					toReturn.Add(NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId, "NotesDetailsEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.EventCustomerResultEntityUsingEventCustomerResultId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventTypeCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.EventTypeEntityUsingEventTypeId, "Events_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.HafTemplateEntityUsingHafTemplateId, "Events_", string.Empty, JoinHint.None);
					break;
				case "LabCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LabEntityUsingLabId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LanguageEntityUsingLanguageId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile____":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneHomeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile________":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingProductTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents___":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateMyBioCheckAssessment, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents____":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHealthAssesmentFormStatus, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents_":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingEventCancellationReasonId, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateKynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaEvents__":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.LookupEntityUsingGenerateHkynXml, "Events_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile______":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPreferredContactType, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_______":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactReasonId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_____":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneOfficeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile___":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneCellConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile__":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingMemberUploadSourceId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents____":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByAdmin, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue_":
					toReturn.Add(NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId, "NotesDetailsEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaPriorityInQueue":
					toReturn.Add(NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId, "NotesDetailsEntity__", "PriorityInQueue_", JoinHint.None);
					toReturn.Add(PriorityInQueueEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "PriorityInQueue_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents___":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingSignOffOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents_":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEvents__":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.OrganizationRoleUserEntityUsingEventActivityOrgRoleUserId, "Events_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId, "NotesDetailsEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaCustomerProfile":
					toReturn.Add(NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId, "NotesDetailsEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.RoleEntityUsingAddedByRoleId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "ScheduleMethodCollectionViaEvents":
					toReturn.Add(NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId, "NotesDetailsEntity__", "Events_", JoinHint.None);
					toReturn.Add(EventsEntity.Relations.ScheduleMethodEntityUsingScheduleMethodId, "Events_", string.Empty, JoinHint.None);
					break;
				case "CriticalCustomerCommunicationRecord":
					toReturn.Add(NotesDetailsEntity.Relations.CriticalCustomerCommunicationRecordEntityUsingNoteId);
					break;
				case "HospitalPartnerEventNotes":
					toReturn.Add(NotesDetailsEntity.Relations.HospitalPartnerEventNotesEntityUsingNotesId);
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
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)relatedEntity);
					break;
				case "Events":
					this.Events.Add((EventsEntity)relatedEntity);
					break;
				case "PriorityInQueue":
					this.PriorityInQueue.Add((PriorityInQueueEntity)relatedEntity);
					break;
				case "CriticalCustomerCommunicationRecord":
					SetupSyncCriticalCustomerCommunicationRecord(relatedEntity);
					break;
				case "HospitalPartnerEventNotes":
					SetupSyncHospitalPartnerEventNotes(relatedEntity);
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
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerProfile":
					base.PerformRelatedEntityRemoval(this.CustomerProfile, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Events":
					base.PerformRelatedEntityRemoval(this.Events, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PriorityInQueue":
					base.PerformRelatedEntityRemoval(this.PriorityInQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CriticalCustomerCommunicationRecord":
					DesetupSyncCriticalCustomerCommunicationRecord(false, true);
					break;
				case "HospitalPartnerEventNotes":
					DesetupSyncHospitalPartnerEventNotes(false, true);
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
			if(_criticalCustomerCommunicationRecord!=null)
			{
				toReturn.Add(_criticalCustomerCommunicationRecord);
			}

			if(_hospitalPartnerEventNotes!=null)
			{
				toReturn.Add(_hospitalPartnerEventNotes);
			}

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




			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallQueueCustomer);
			toReturn.Add(this.CustomerProfile);
			toReturn.Add(this.Events);
			toReturn.Add(this.PriorityInQueue);

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
				info.AddValue("_customerProfile", ((_customerProfile!=null) && (_customerProfile.Count>0) && !this.MarkedForDeletion)?_customerProfile:null);
				info.AddValue("_events", ((_events!=null) && (_events.Count>0) && !this.MarkedForDeletion)?_events:null);
				info.AddValue("_priorityInQueue", ((_priorityInQueue!=null) && (_priorityInQueue.Count>0) && !this.MarkedForDeletion)?_priorityInQueue:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCustomerProfile", ((_activityTypeCollectionViaCustomerProfile!=null) && (_activityTypeCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCustomerProfile:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_addressCollectionViaCustomerProfile", ((_addressCollectionViaCustomerProfile!=null) && (_addressCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerProfile:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_communicationModeCollectionViaEvents", ((_communicationModeCollectionViaEvents!=null) && (_communicationModeCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_communicationModeCollectionViaEvents:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventCustomerResultCollectionViaPriorityInQueue", ((_eventCustomerResultCollectionViaPriorityInQueue!=null) && (_eventCustomerResultCollectionViaPriorityInQueue.Count>0) && !this.MarkedForDeletion)?_eventCustomerResultCollectionViaPriorityInQueue:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventTypeCollectionViaEvents", ((_eventTypeCollectionViaEvents!=null) && (_eventTypeCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_eventTypeCollectionViaEvents:null);
				info.AddValue("_hafTemplateCollectionViaEvents", ((_hafTemplateCollectionViaEvents!=null) && (_hafTemplateCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaEvents:null);
				info.AddValue("_labCollectionViaCustomerProfile", ((_labCollectionViaCustomerProfile!=null) && (_labCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_labCollectionViaCustomerProfile:null);
				info.AddValue("_languageCollectionViaCallQueueCustomer", ((_languageCollectionViaCallQueueCustomer!=null) && (_languageCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCallQueueCustomer:null);
				info.AddValue("_languageCollectionViaCustomerProfile", ((_languageCollectionViaCustomerProfile!=null) && (_languageCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile____", ((_lookupCollectionViaCustomerProfile____!=null) && (_lookupCollectionViaCustomerProfile____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile________", ((_lookupCollectionViaCustomerProfile________!=null) && (_lookupCollectionViaCustomerProfile________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile________:null);
				info.AddValue("_lookupCollectionViaEvents___", ((_lookupCollectionViaEvents___!=null) && (_lookupCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents___:null);
				info.AddValue("_lookupCollectionViaEvents____", ((_lookupCollectionViaEvents____!=null) && (_lookupCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents____:null);
				info.AddValue("_lookupCollectionViaEvents_", ((_lookupCollectionViaEvents_!=null) && (_lookupCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents_:null);
				info.AddValue("_lookupCollectionViaEvents", ((_lookupCollectionViaEvents!=null) && (_lookupCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents:null);
				info.AddValue("_lookupCollectionViaEvents__", ((_lookupCollectionViaEvents__!=null) && (_lookupCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaEvents__:null);
				info.AddValue("_lookupCollectionViaCustomerProfile______", ((_lookupCollectionViaCustomerProfile______!=null) && (_lookupCollectionViaCustomerProfile______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile______:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_", ((_lookupCollectionViaCustomerProfile_!=null) && (_lookupCollectionViaCustomerProfile_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_______", ((_lookupCollectionViaCustomerProfile_______!=null) && (_lookupCollectionViaCustomerProfile_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile", ((_lookupCollectionViaCustomerProfile!=null) && (_lookupCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_____", ((_lookupCollectionViaCustomerProfile_____!=null) && (_lookupCollectionViaCustomerProfile_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile___", ((_lookupCollectionViaCustomerProfile___!=null) && (_lookupCollectionViaCustomerProfile___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile___:null);
				info.AddValue("_lookupCollectionViaCustomerProfile__", ((_lookupCollectionViaCustomerProfile__!=null) && (_lookupCollectionViaCustomerProfile__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile__:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents____", ((_organizationRoleUserCollectionViaEvents____!=null) && (_organizationRoleUserCollectionViaEvents____.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents____:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaPriorityInQueue_", ((_organizationRoleUserCollectionViaPriorityInQueue_!=null) && (_organizationRoleUserCollectionViaPriorityInQueue_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPriorityInQueue_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaPriorityInQueue", ((_organizationRoleUserCollectionViaPriorityInQueue!=null) && (_organizationRoleUserCollectionViaPriorityInQueue.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaPriorityInQueue:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents___", ((_organizationRoleUserCollectionViaEvents___!=null) && (_organizationRoleUserCollectionViaEvents___.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents___:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents", ((_organizationRoleUserCollectionViaEvents!=null) && (_organizationRoleUserCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents_", ((_organizationRoleUserCollectionViaEvents_!=null) && (_organizationRoleUserCollectionViaEvents_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents_:null);
				info.AddValue("_organizationRoleUserCollectionViaEvents__", ((_organizationRoleUserCollectionViaEvents__!=null) && (_organizationRoleUserCollectionViaEvents__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEvents__:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_roleCollectionViaCustomerProfile", ((_roleCollectionViaCustomerProfile!=null) && (_roleCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaCustomerProfile:null);
				info.AddValue("_scheduleMethodCollectionViaEvents", ((_scheduleMethodCollectionViaEvents!=null) && (_scheduleMethodCollectionViaEvents.Count>0) && !this.MarkedForDeletion)?_scheduleMethodCollectionViaEvents:null);
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_criticalCustomerCommunicationRecord", (!this.MarkedForDeletion?_criticalCustomerCommunicationRecord:null));
				info.AddValue("_hospitalPartnerEventNotes", (!this.MarkedForDeletion?_hospitalPartnerEventNotes:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NotesDetailsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NotesDetailsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NotesDetailsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.NotesId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.DoNotContactReasonNotesId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EmrNotesId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PriorityInQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PriorityInQueueFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CommunicationMode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCommunicationModeCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CommunicationModeCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomerResult' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomerResultCollectionViaPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomerResultCollectionViaPriorityInQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventTypeCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventTypeCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lab' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLabCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LabCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPriorityInQueue_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPriorityInQueue_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaPriorityInQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaPriorityInQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEvents__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEvents__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleMethod' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleMethodCollectionViaEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ScheduleMethodCollectionViaEvents"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NoteId, "NotesDetailsEntity__"));
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
		/// the related entity of type 'CriticalCustomerCommunicationRecord' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCriticalCustomerCommunicationRecord()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CriticalCustomerCommunicationRecordFields.NoteId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HospitalPartnerEventNotes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalPartnerEventNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalPartnerEventNotesFields.NotesId, null, ComparisonOperator.Equal, this.NoteId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.NotesDetailsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfile);
			collectionsQueue.Enqueue(this._events);
			collectionsQueue.Enqueue(this._priorityInQueue);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._communicationModeCollectionViaEvents);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventCustomerResultCollectionViaPriorityInQueue);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventTypeCollectionViaEvents);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaEvents);
			collectionsQueue.Enqueue(this._labCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._languageCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._languageCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile________);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents___);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents____);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents_);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents);
			collectionsQueue.Enqueue(this._lookupCollectionViaEvents__);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile___);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents____);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPriorityInQueue_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaPriorityInQueue);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents___);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEvents__);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._roleCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._scheduleMethodCollectionViaEvents);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._customerProfile = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._events = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._priorityInQueue = (EntityCollection<PriorityInQueueEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._communicationModeCollectionViaEvents = (EntityCollection<CommunicationModeEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomerResultCollectionViaPriorityInQueue = (EntityCollection<EventCustomerResultEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventTypeCollectionViaEvents = (EntityCollection<EventTypeEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaEvents = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._labCollectionViaCustomerProfile = (EntityCollection<LabEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCallQueueCustomer = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaEvents__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents____ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPriorityInQueue_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaPriorityInQueue = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents___ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEvents__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._scheduleMethodCollectionViaEvents = (EntityCollection<ScheduleMethodEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomer != null)
			{
				return true;
			}
			if (this._customerProfile != null)
			{
				return true;
			}
			if (this._events != null)
			{
				return true;
			}
			if (this._priorityInQueue != null)
			{
				return true;
			}
			if (this._accountCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._addressCollectionViaCustomerProfile != null)
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
			if (this._campaignCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._communicationModeCollectionViaEvents != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._eventCustomerResultCollectionViaPriorityInQueue != null)
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
			if (this._eventTypeCollectionViaEvents != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaEvents != null)
			{
				return true;
			}
			if (this._labCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._languageCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._languageCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents != null)
			{
				return true;
			}
			if (this._lookupCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents____ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPriorityInQueue_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaPriorityInQueue != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents___ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEvents__ != null)
			{
				return true;
			}
			if (this._prospectCustomerCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._roleCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._scheduleMethodCollectionViaEvents != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CommunicationModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))) : null);
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
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("Events", _events);
			toReturn.Add("PriorityInQueue", _priorityInQueue);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCustomerProfile", _activityTypeCollectionViaCustomerProfile);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("AddressCollectionViaCustomerProfile", _addressCollectionViaCustomerProfile);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("CommunicationModeCollectionViaEvents", _communicationModeCollectionViaEvents);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("EventCustomerResultCollectionViaPriorityInQueue", _eventCustomerResultCollectionViaPriorityInQueue);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("EventTypeCollectionViaEvents", _eventTypeCollectionViaEvents);
			toReturn.Add("HafTemplateCollectionViaEvents", _hafTemplateCollectionViaEvents);
			toReturn.Add("LabCollectionViaCustomerProfile", _labCollectionViaCustomerProfile);
			toReturn.Add("LanguageCollectionViaCallQueueCustomer", _languageCollectionViaCallQueueCustomer);
			toReturn.Add("LanguageCollectionViaCustomerProfile", _languageCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile____", _lookupCollectionViaCustomerProfile____);
			toReturn.Add("LookupCollectionViaCustomerProfile________", _lookupCollectionViaCustomerProfile________);
			toReturn.Add("LookupCollectionViaEvents___", _lookupCollectionViaEvents___);
			toReturn.Add("LookupCollectionViaEvents____", _lookupCollectionViaEvents____);
			toReturn.Add("LookupCollectionViaEvents_", _lookupCollectionViaEvents_);
			toReturn.Add("LookupCollectionViaEvents", _lookupCollectionViaEvents);
			toReturn.Add("LookupCollectionViaEvents__", _lookupCollectionViaEvents__);
			toReturn.Add("LookupCollectionViaCustomerProfile______", _lookupCollectionViaCustomerProfile______);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCustomerProfile_", _lookupCollectionViaCustomerProfile_);
			toReturn.Add("LookupCollectionViaCustomerProfile_______", _lookupCollectionViaCustomerProfile_______);
			toReturn.Add("LookupCollectionViaCustomerProfile", _lookupCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile_____", _lookupCollectionViaCustomerProfile_____);
			toReturn.Add("LookupCollectionViaCustomerProfile___", _lookupCollectionViaCustomerProfile___);
			toReturn.Add("LookupCollectionViaCustomerProfile__", _lookupCollectionViaCustomerProfile__);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents____", _organizationRoleUserCollectionViaEvents____);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaPriorityInQueue_", _organizationRoleUserCollectionViaPriorityInQueue_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaPriorityInQueue", _organizationRoleUserCollectionViaPriorityInQueue);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents___", _organizationRoleUserCollectionViaEvents___);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents", _organizationRoleUserCollectionViaEvents);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents_", _organizationRoleUserCollectionViaEvents_);
			toReturn.Add("OrganizationRoleUserCollectionViaEvents__", _organizationRoleUserCollectionViaEvents__);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);
			toReturn.Add("RoleCollectionViaCustomerProfile", _roleCollectionViaCustomerProfile);
			toReturn.Add("ScheduleMethodCollectionViaEvents", _scheduleMethodCollectionViaEvents);
			toReturn.Add("CriticalCustomerCommunicationRecord", _criticalCustomerCommunicationRecord);
			toReturn.Add("HospitalPartnerEventNotes", _hospitalPartnerEventNotes);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomer!=null)
			{
				_callQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_priorityInQueue!=null)
			{
				_priorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaCallQueueCustomer!=null)
			{
				_accountCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCustomerProfile!=null)
			{
				_activityTypeCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCallQueueCustomer!=null)
			{
				_activityTypeCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaCustomerProfile!=null)
			{
				_addressCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteriaCollectionViaCallQueueCustomer!=null)
			{
				_callQueueCriteriaCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_campaignCollectionViaCallQueueCustomer!=null)
			{
				_campaignCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_communicationModeCollectionViaEvents!=null)
			{
				_communicationModeCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCallQueueCustomer!=null)
			{
				_customerProfileCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomerResultCollectionViaPriorityInQueue!=null)
			{
				_eventCustomerResultCollectionViaPriorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomersCollectionViaCallQueueCustomer!=null)
			{
				_eventCustomersCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaCallQueueCustomer!=null)
			{
				_eventsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_eventTypeCollectionViaEvents!=null)
			{
				_eventTypeCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaEvents!=null)
			{
				_hafTemplateCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_labCollectionViaCustomerProfile!=null)
			{
				_labCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCallQueueCustomer!=null)
			{
				_languageCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCustomerProfile!=null)
			{
				_languageCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile____!=null)
			{
				_lookupCollectionViaCustomerProfile____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile________!=null)
			{
				_lookupCollectionViaCustomerProfile________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents___!=null)
			{
				_lookupCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents____!=null)
			{
				_lookupCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents_!=null)
			{
				_lookupCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents!=null)
			{
				_lookupCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaEvents__!=null)
			{
				_lookupCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile______!=null)
			{
				_lookupCollectionViaCustomerProfile______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_!=null)
			{
				_lookupCollectionViaCustomerProfile_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_______!=null)
			{
				_lookupCollectionViaCustomerProfile_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile!=null)
			{
				_lookupCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_____!=null)
			{
				_lookupCollectionViaCustomerProfile_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile___!=null)
			{
				_lookupCollectionViaCustomerProfile___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile__!=null)
			{
				_lookupCollectionViaCustomerProfile__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents____!=null)
			{
				_organizationRoleUserCollectionViaEvents____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPriorityInQueue_!=null)
			{
				_organizationRoleUserCollectionViaPriorityInQueue_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaPriorityInQueue!=null)
			{
				_organizationRoleUserCollectionViaPriorityInQueue.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents___!=null)
			{
				_organizationRoleUserCollectionViaEvents___.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents!=null)
			{
				_organizationRoleUserCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents_!=null)
			{
				_organizationRoleUserCollectionViaEvents_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEvents__!=null)
			{
				_organizationRoleUserCollectionViaEvents__.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaCustomerProfile!=null)
			{
				_roleCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_scheduleMethodCollectionViaEvents!=null)
			{
				_scheduleMethodCollectionViaEvents.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_criticalCustomerCommunicationRecord!=null)
			{
				_criticalCustomerCommunicationRecord.ActiveContext = base.ActiveContext;
			}
			if(_hospitalPartnerEventNotes!=null)
			{
				_hospitalPartnerEventNotes.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callQueueCustomer = null;
			_customerProfile = null;
			_events = null;
			_priorityInQueue = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCustomerProfile = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_addressCollectionViaCustomerProfile = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_communicationModeCollectionViaEvents = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_eventCustomerResultCollectionViaPriorityInQueue = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_eventTypeCollectionViaEvents = null;
			_hafTemplateCollectionViaEvents = null;
			_labCollectionViaCustomerProfile = null;
			_languageCollectionViaCallQueueCustomer = null;
			_languageCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile____ = null;
			_lookupCollectionViaCustomerProfile________ = null;
			_lookupCollectionViaEvents___ = null;
			_lookupCollectionViaEvents____ = null;
			_lookupCollectionViaEvents_ = null;
			_lookupCollectionViaEvents = null;
			_lookupCollectionViaEvents__ = null;
			_lookupCollectionViaCustomerProfile______ = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCustomerProfile_ = null;
			_lookupCollectionViaCustomerProfile_______ = null;
			_lookupCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile_____ = null;
			_lookupCollectionViaCustomerProfile___ = null;
			_lookupCollectionViaCustomerProfile__ = null;
			_organizationRoleUserCollectionViaEvents____ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaPriorityInQueue_ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaPriorityInQueue = null;
			_organizationRoleUserCollectionViaEvents___ = null;
			_organizationRoleUserCollectionViaEvents = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_organizationRoleUserCollectionViaEvents_ = null;
			_organizationRoleUserCollectionViaEvents__ = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_roleCollectionViaCustomerProfile = null;
			_scheduleMethodCollectionViaEvents = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser = null;
			_criticalCustomerCommunicationRecord = null;
			_hospitalPartnerEventNotes = null;
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

			_fieldsCustomProperties.Add("NoteId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Active", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "NotesDetails_", resetFKFields, new int[] { (int)NotesDetailsFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "NotesDetails", resetFKFields, new int[] { (int)NotesDetailsFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", NotesDetailsEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _criticalCustomerCommunicationRecord</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCriticalCustomerCommunicationRecord(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _criticalCustomerCommunicationRecord, new PropertyChangedEventHandler( OnCriticalCustomerCommunicationRecordPropertyChanged ), "CriticalCustomerCommunicationRecord", NotesDetailsEntity.Relations.CriticalCustomerCommunicationRecordEntityUsingNoteId, false, signalRelatedEntity, "NotesDetails", false, new int[] { (int)NotesDetailsFieldIndex.NoteId } );
			_criticalCustomerCommunicationRecord = null;
		}
		
		/// <summary> setups the sync logic for member _criticalCustomerCommunicationRecord</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCriticalCustomerCommunicationRecord(IEntity2 relatedEntity)
		{
			if(_criticalCustomerCommunicationRecord!=relatedEntity)
			{
				DesetupSyncCriticalCustomerCommunicationRecord(true, true);
				_criticalCustomerCommunicationRecord = (CriticalCustomerCommunicationRecordEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _criticalCustomerCommunicationRecord, new PropertyChangedEventHandler( OnCriticalCustomerCommunicationRecordPropertyChanged ), "CriticalCustomerCommunicationRecord", NotesDetailsEntity.Relations.CriticalCustomerCommunicationRecordEntityUsingNoteId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCriticalCustomerCommunicationRecordPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hospitalPartnerEventNotes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHospitalPartnerEventNotes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hospitalPartnerEventNotes, new PropertyChangedEventHandler( OnHospitalPartnerEventNotesPropertyChanged ), "HospitalPartnerEventNotes", NotesDetailsEntity.Relations.HospitalPartnerEventNotesEntityUsingNotesId, false, signalRelatedEntity, "NotesDetails", false, new int[] { (int)NotesDetailsFieldIndex.NoteId } );
			_hospitalPartnerEventNotes = null;
		}
		
		/// <summary> setups the sync logic for member _hospitalPartnerEventNotes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHospitalPartnerEventNotes(IEntity2 relatedEntity)
		{
			if(_hospitalPartnerEventNotes!=relatedEntity)
			{
				DesetupSyncHospitalPartnerEventNotes(true, true);
				_hospitalPartnerEventNotes = (HospitalPartnerEventNotesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hospitalPartnerEventNotes, new PropertyChangedEventHandler( OnHospitalPartnerEventNotesPropertyChanged ), "HospitalPartnerEventNotes", NotesDetailsEntity.Relations.HospitalPartnerEventNotesEntityUsingNotesId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHospitalPartnerEventNotesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NotesDetailsEntity</param>
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
		public  static NotesDetailsRelations Relations
		{
			get	{ return new NotesDetailsRelations(); }
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
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PriorityInQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPriorityInQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("PriorityInQueue")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.PriorityInQueueEntity, 0, null, null, null, null, "PriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCustomerProfile"), null, "ActivityTypeCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerProfile"), null, "AddressCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CommunicationMode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCommunicationModeCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<CommunicationModeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CommunicationModeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CommunicationModeEntity, 0, null, null, GetRelationsForField("CommunicationModeCollectionViaEvents"), null, "CommunicationModeCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomerResult' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomerResultCollectionViaPriorityInQueue
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.EventCustomerResultEntity, 0, null, null, GetRelationsForField("EventCustomerResultCollectionViaPriorityInQueue"), null, "EventCustomerResultCollectionViaPriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventTypeCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<EventTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.EventTypeEntity, 0, null, null, GetRelationsForField("EventTypeCollectionViaEvents"), null, "EventTypeCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaEvents"), null, "HafTemplateCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLabCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LabEntity, 0, null, null, GetRelationsForField("LabCollectionViaCustomerProfile"), null, "LabCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCallQueueCustomer"), null, "LanguageCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCustomerProfile"), null, "LanguageCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile____
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile____"), null, "LookupCollectionViaCustomerProfile____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile________
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile________"), null, "LookupCollectionViaCustomerProfile________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents___"), null, "LookupCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents____"), null, "LookupCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents_"), null, "LookupCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents"), null, "LookupCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaEvents__"), null, "LookupCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile______
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile______"), null, "LookupCollectionViaCustomerProfile______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_"), null, "LookupCollectionViaCustomerProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_______
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_______"), null, "LookupCollectionViaCustomerProfile_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile"), null, "LookupCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_____
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_____"), null, "LookupCollectionViaCustomerProfile_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile___
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile___"), null, "LookupCollectionViaCustomerProfile___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile__
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile__"), null, "LookupCollectionViaCustomerProfile__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents____
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents____"), null, "OrganizationRoleUserCollectionViaEvents____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPriorityInQueue_
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPriorityInQueue_"), null, "OrganizationRoleUserCollectionViaPriorityInQueue_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaPriorityInQueue
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.PriorityInQueueEntityUsingNoteId;
				intermediateRelation.SetAliases(string.Empty, "PriorityInQueue_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaPriorityInQueue"), null, "OrganizationRoleUserCollectionViaPriorityInQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents___
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents___"), null, "OrganizationRoleUserCollectionViaEvents___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents"), null, "OrganizationRoleUserCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents_
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents_"), null, "OrganizationRoleUserCollectionViaEvents_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEvents__
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEvents__"), null, "OrganizationRoleUserCollectionViaEvents__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CallQueueCustomerEntityUsingNotesId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.CustomerProfileEntityUsingDoNotContactReasonNotesId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaCustomerProfile"), null, "RoleCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleMethod' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleMethodCollectionViaEvents
		{
			get
			{
				IEntityRelation intermediateRelation = NotesDetailsEntity.Relations.EventsEntityUsingEmrNotesId;
				intermediateRelation.SetAliases(string.Empty, "Events_");
				return new PrefetchPathElement2(new EntityCollection<ScheduleMethodEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleMethodEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.ScheduleMethodEntity, 0, null, null, GetRelationsForField("ScheduleMethodCollectionViaEvents"), null, "ScheduleMethodCollectionViaEvents", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CriticalCustomerCommunicationRecord' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCriticalCustomerCommunicationRecord
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CriticalCustomerCommunicationRecordEntityFactory))),
					(IEntityRelation)GetRelationsForField("CriticalCustomerCommunicationRecord")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.CriticalCustomerCommunicationRecordEntity, 0, null, null, null, null, "CriticalCustomerCommunicationRecord", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalPartnerEventNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalPartnerEventNotes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HospitalPartnerEventNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalPartnerEventNotes")[0], (int)Falcon.Data.EntityType.NotesDetailsEntity, (int)Falcon.Data.EntityType.HospitalPartnerEventNotesEntity, 0, null, null, null, null, "HospitalPartnerEventNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NotesDetailsEntity.CustomProperties;}
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
			get { return NotesDetailsEntity.FieldsCustomProperties;}
		}

		/// <summary> The NoteId property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."NoteID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 NoteId
		{
			get { return (System.Int64)GetValue((int)NotesDetailsFieldIndex.NoteId, true); }
			set	{ SetValue((int)NotesDetailsFieldIndex.NoteId, value); }
		}

		/// <summary> The Notes property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)NotesDetailsFieldIndex.Notes, true); }
			set	{ SetValue((int)NotesDetailsFieldIndex.Notes, value); }
		}

		/// <summary> The DateCreated property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotesDetailsFieldIndex.DateCreated, false); }
			set	{ SetValue((int)NotesDetailsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)NotesDetailsFieldIndex.DateModified, false); }
			set	{ SetValue((int)NotesDetailsFieldIndex.DateModified, value); }
		}

		/// <summary> The Active property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."Active"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Active
		{
			get { return (System.Boolean)GetValue((int)NotesDetailsFieldIndex.Active, true); }
			set	{ SetValue((int)NotesDetailsFieldIndex.Active, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)NotesDetailsFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)NotesDetailsFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity NotesDetails<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblNotesDetails"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)NotesDetailsFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)NotesDetailsFieldIndex.ModifiedByOrgRoleUserId, value); }
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
					_callQueueCustomer.SetContainingEntityInfo(this, "NotesDetails");
				}
				return _callQueueCustomer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfile
		{
			get
			{
				if(_customerProfile==null)
				{
					_customerProfile = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfile.SetContainingEntityInfo(this, "NotesDetails");
				}
				return _customerProfile;
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
					_events.SetContainingEntityInfo(this, "NotesDetails");
				}
				return _events;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PriorityInQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PriorityInQueueEntity))]
		public virtual EntityCollection<PriorityInQueueEntity> PriorityInQueue
		{
			get
			{
				if(_priorityInQueue==null)
				{
					_priorityInQueue = new EntityCollection<PriorityInQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PriorityInQueueEntityFactory)));
					_priorityInQueue.SetContainingEntityInfo(this, "NotesDetails");
				}
				return _priorityInQueue;
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
		public virtual EntityCollection<ActivityTypeEntity> ActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				if(_activityTypeCollectionViaCustomerProfile==null)
				{
					_activityTypeCollectionViaCustomerProfile = new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory)));
					_activityTypeCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _activityTypeCollectionViaCustomerProfile;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaCustomerProfile
		{
			get
			{
				if(_addressCollectionViaCustomerProfile==null)
				{
					_addressCollectionViaCustomerProfile = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _addressCollectionViaCustomerProfile;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventCustomerResultEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventCustomerResultEntity))]
		public virtual EntityCollection<EventCustomerResultEntity> EventCustomerResultCollectionViaPriorityInQueue
		{
			get
			{
				if(_eventCustomerResultCollectionViaPriorityInQueue==null)
				{
					_eventCustomerResultCollectionViaPriorityInQueue = new EntityCollection<EventCustomerResultEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomerResultEntityFactory)));
					_eventCustomerResultCollectionViaPriorityInQueue.IsReadOnly=true;
				}
				return _eventCustomerResultCollectionViaPriorityInQueue;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaEvents
		{
			get
			{
				if(_hafTemplateCollectionViaEvents==null)
				{
					_hafTemplateCollectionViaEvents = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaEvents.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaEvents;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LabEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LabEntity))]
		public virtual EntityCollection<LabEntity> LabCollectionViaCustomerProfile
		{
			get
			{
				if(_labCollectionViaCustomerProfile==null)
				{
					_labCollectionViaCustomerProfile = new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory)));
					_labCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _labCollectionViaCustomerProfile;
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
		public virtual EntityCollection<LanguageEntity> LanguageCollectionViaCustomerProfile
		{
			get
			{
				if(_languageCollectionViaCustomerProfile==null)
				{
					_languageCollectionViaCustomerProfile = new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory)));
					_languageCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _languageCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile____
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile____==null)
				{
					_lookupCollectionViaCustomerProfile____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile____.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile________
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile________==null)
				{
					_lookupCollectionViaCustomerProfile________ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile________.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile________;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile______
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile______==null)
				{
					_lookupCollectionViaCustomerProfile______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile______.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile______;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_==null)
				{
					_lookupCollectionViaCustomerProfile_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_______
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_______==null)
				{
					_lookupCollectionViaCustomerProfile_______ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_______.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile==null)
				{
					_lookupCollectionViaCustomerProfile = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile_____
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile_____==null)
				{
					_lookupCollectionViaCustomerProfile_____ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile_____.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile___
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile___==null)
				{
					_lookupCollectionViaCustomerProfile___ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile___.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerProfile__
		{
			get
			{
				if(_lookupCollectionViaCustomerProfile__==null)
				{
					_lookupCollectionViaCustomerProfile__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerProfile__.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerProfile__;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPriorityInQueue_
		{
			get
			{
				if(_organizationRoleUserCollectionViaPriorityInQueue_==null)
				{
					_organizationRoleUserCollectionViaPriorityInQueue_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPriorityInQueue_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPriorityInQueue_;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaPriorityInQueue
		{
			get
			{
				if(_organizationRoleUserCollectionViaPriorityInQueue==null)
				{
					_organizationRoleUserCollectionViaPriorityInQueue = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaPriorityInQueue.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaPriorityInQueue;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaCustomerProfile
		{
			get
			{
				if(_roleCollectionViaCustomerProfile==null)
				{
					_roleCollectionViaCustomerProfile = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _roleCollectionViaCustomerProfile;
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "NotesDetails_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NotesDetails_");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "NotesDetails");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "NotesDetails");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CriticalCustomerCommunicationRecordEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CriticalCustomerCommunicationRecordEntity CriticalCustomerCommunicationRecord
		{
			get
			{
				return _criticalCustomerCommunicationRecord;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCriticalCustomerCommunicationRecord(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "NotesDetails");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_criticalCustomerCommunicationRecord !=null);
						DesetupSyncCriticalCustomerCommunicationRecord(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CriticalCustomerCommunicationRecord");
						}
					}
					else
					{
						if(_criticalCustomerCommunicationRecord!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "NotesDetails");
							SetupSyncCriticalCustomerCommunicationRecord(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HospitalPartnerEventNotesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HospitalPartnerEventNotesEntity HospitalPartnerEventNotes
		{
			get
			{
				return _hospitalPartnerEventNotes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHospitalPartnerEventNotes(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "NotesDetails");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_hospitalPartnerEventNotes !=null);
						DesetupSyncHospitalPartnerEventNotes(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("HospitalPartnerEventNotes");
						}
					}
					else
					{
						if(_hospitalPartnerEventNotes!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "NotesDetails");
							SetupSyncHospitalPartnerEventNotes(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.NotesDetailsEntity; }
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
