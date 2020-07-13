///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:51
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
	/// Entity class which represents the entity 'CallQueueCustomer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CallQueueCustomerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerCallEntity> _callQueueCustomerCall;
		private EntityCollection<CustomerCallQueueCallAttemptEntity> _customerCallQueueCallAttempt;
		private EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity> _healthPlanCallQueueCriteriaAssignment;
		private EntityCollection<SystemGeneratedCallQueueAssignmentEntity> _systemGeneratedCallQueueAssignment;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaSystemGeneratedCallQueueAssignment;
		private EntityCollection<CallsEntity> _callsCollectionViaCallQueueCustomerCall;
		private EntityCollection<CallsEntity> _callsCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
		private EntityCollection<SystemGeneratedCallQueueCriteriaEntity> _systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment;
		private EntityCollection<TagEntity> _tagCollectionViaCustomerCallQueueCallAttempt;
		private AccountEntity _account;
		private ActivityTypeEntity _activityType;
		private CallQueueEntity _callQueue;
		private CallQueueCriteriaEntity _callQueueCriteria;
		private CampaignEntity _campaign;
		private CustomerProfileEntity _customerProfile;
		private EventCustomersEntity _eventCustomers;
		private EventsEntity _events;
		private LanguageEntity _language;
		private LookupEntity _lookup;
		private NotesDetailsEntity _notesDetails;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private OrganizationRoleUserEntity _organizationRoleUser__;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private ProspectCustomerEntity _prospectCustomer;
		private CallQueueCustomerLockEntity _callQueueCustomerLock;
		
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
			/// <summary>Member name ActivityType</summary>
			public static readonly string ActivityType = "ActivityType";
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name CallQueueCriteria</summary>
			public static readonly string CallQueueCriteria = "CallQueueCriteria";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name EventCustomers</summary>
			public static readonly string EventCustomers = "EventCustomers";
			/// <summary>Member name Events</summary>
			public static readonly string Events = "Events";
			/// <summary>Member name Language</summary>
			public static readonly string Language = "Language";
			/// <summary>Member name Lookup</summary>
			public static readonly string Lookup = "Lookup";
			/// <summary>Member name NotesDetails</summary>
			public static readonly string NotesDetails = "NotesDetails";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name ProspectCustomer</summary>
			public static readonly string ProspectCustomer = "ProspectCustomer";
			/// <summary>Member name CallQueueCustomerCall</summary>
			public static readonly string CallQueueCustomerCall = "CallQueueCustomerCall";
			/// <summary>Member name CustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerCallQueueCallAttempt = "CustomerCallQueueCallAttempt";
			/// <summary>Member name HealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name SystemGeneratedCallQueueAssignment</summary>
			public static readonly string SystemGeneratedCallQueueAssignment = "SystemGeneratedCallQueueAssignment";
			/// <summary>Member name CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name CallQueueCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string CallQueueCollectionViaSystemGeneratedCallQueueAssignment = "CallQueueCollectionViaSystemGeneratedCallQueueAssignment";
			/// <summary>Member name CallsCollectionViaCallQueueCustomerCall</summary>
			public static readonly string CallsCollectionViaCallQueueCustomerCall = "CallsCollectionViaCallQueueCustomerCall";
			/// <summary>Member name CallsCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CallsCollectionViaCustomerCallQueueCallAttempt = "CallsCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CustomerProfileCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string CustomerProfileCollectionViaCustomerCallQueueCallAttempt = "CustomerProfileCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt = "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment</summary>
			public static readonly string SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment";
			/// <summary>Member name TagCollectionViaCustomerCallQueueCallAttempt</summary>
			public static readonly string TagCollectionViaCustomerCallQueueCallAttempt = "TagCollectionViaCustomerCallQueueCallAttempt";
			/// <summary>Member name CallQueueCustomerLock</summary>
			public static readonly string CallQueueCustomerLock = "CallQueueCustomerLock";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CallQueueCustomerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CallQueueCustomerEntity():base("CallQueueCustomerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CallQueueCustomerEntity(IEntityFields2 fields):base("CallQueueCustomerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CallQueueCustomerEntity</param>
		public CallQueueCustomerEntity(IValidator validator):base("CallQueueCustomerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="callQueueCustomerId">PK value for CallQueueCustomer which data should be fetched into this CallQueueCustomer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueCustomerEntity(System.Int64 callQueueCustomerId):base("CallQueueCustomerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CallQueueCustomerId = callQueueCustomerId;
		}

		/// <summary> CTor</summary>
		/// <param name="callQueueCustomerId">PK value for CallQueueCustomer which data should be fetched into this CallQueueCustomer object</param>
		/// <param name="validator">The custom validator object for this CallQueueCustomerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CallQueueCustomerEntity(System.Int64 callQueueCustomerId, IValidator validator):base("CallQueueCustomerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CallQueueCustomerId = callQueueCustomerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CallQueueCustomerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomerCall = (EntityCollection<CallQueueCustomerCallEntity>)info.GetValue("_callQueueCustomerCall", typeof(EntityCollection<CallQueueCustomerCallEntity>));
				_customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>)info.GetValue("_customerCallQueueCallAttempt", typeof(EntityCollection<CustomerCallQueueCallAttemptEntity>));
				_healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>)info.GetValue("_healthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>));
				_systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>)info.GetValue("_systemGeneratedCallQueueAssignment", typeof(EntityCollection<SystemGeneratedCallQueueAssignmentEntity>));
				_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<CallQueueEntity>));
				_callsCollectionViaCallQueueCustomerCall = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaCallQueueCustomerCall", typeof(EntityCollection<CallsEntity>));
				_callsCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>)info.GetValue("_callsCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CallsEntity>));
				_customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<CustomerProfileEntity>));
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>)info.GetValue("_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", typeof(EntityCollection<SystemGeneratedCallQueueCriteriaEntity>));
				_tagCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>)info.GetValue("_tagCollectionViaCustomerCallQueueCallAttempt", typeof(EntityCollection<TagEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_activityType = (ActivityTypeEntity)info.GetValue("_activityType", typeof(ActivityTypeEntity));
				if(_activityType!=null)
				{
					_activityType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueueCriteria = (CallQueueCriteriaEntity)info.GetValue("_callQueueCriteria", typeof(CallQueueCriteriaEntity));
				if(_callQueueCriteria!=null)
				{
					_callQueueCriteria.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_customerProfile = (CustomerProfileEntity)info.GetValue("_customerProfile", typeof(CustomerProfileEntity));
				if(_customerProfile!=null)
				{
					_customerProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_eventCustomers = (EventCustomersEntity)info.GetValue("_eventCustomers", typeof(EventCustomersEntity));
				if(_eventCustomers!=null)
				{
					_eventCustomers.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_events = (EventsEntity)info.GetValue("_events", typeof(EventsEntity));
				if(_events!=null)
				{
					_events.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_language = (LanguageEntity)info.GetValue("_language", typeof(LanguageEntity));
				if(_language!=null)
				{
					_language.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_lookup = (LookupEntity)info.GetValue("_lookup", typeof(LookupEntity));
				if(_lookup!=null)
				{
					_lookup.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_notesDetails = (NotesDetailsEntity)info.GetValue("_notesDetails", typeof(NotesDetailsEntity));
				if(_notesDetails!=null)
				{
					_notesDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospectCustomer = (ProspectCustomerEntity)info.GetValue("_prospectCustomer", typeof(ProspectCustomerEntity));
				if(_prospectCustomer!=null)
				{
					_prospectCustomer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueueCustomerLock = (CallQueueCustomerLockEntity)info.GetValue("_callQueueCustomerLock", typeof(CallQueueCustomerLockEntity));
				if(_callQueueCustomerLock!=null)
				{
					_callQueueCustomerLock.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CallQueueCustomerFieldIndex)fieldIndex)
			{
				case CallQueueCustomerFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case CallQueueCustomerFieldIndex.CustomerId:
					DesetupSyncCustomerProfile(true, false);
					break;
				case CallQueueCustomerFieldIndex.ProspectCustomerId:
					DesetupSyncProspectCustomer(true, false);
					break;
				case CallQueueCustomerFieldIndex.NotesId:
					DesetupSyncNotesDetails(true, false);
					break;
				case CallQueueCustomerFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case CallQueueCustomerFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser__(true, false);
					break;
				case CallQueueCustomerFieldIndex.AssignedToOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
					break;
				case CallQueueCustomerFieldIndex.CallQueueCriteriaId:
					DesetupSyncCallQueueCriteria(true, false);
					break;
				case CallQueueCustomerFieldIndex.EventId:
					DesetupSyncEvents(true, false);
					break;
				case CallQueueCustomerFieldIndex.HealthPlanId:
					DesetupSyncAccount(true, false);
					break;
				case CallQueueCustomerFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case CallQueueCustomerFieldIndex.ActivityId:
					DesetupSyncActivityType(true, false);
					break;
				case CallQueueCustomerFieldIndex.EventCustomerId:
					DesetupSyncEventCustomers(true, false);
					break;
				case CallQueueCustomerFieldIndex.DoNotContactUpdateSource:
					DesetupSyncLookup(true, false);
					break;
				case CallQueueCustomerFieldIndex.LanguageId:
					DesetupSyncLanguage(true, false);
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
				case "ActivityType":
					this.ActivityType = (ActivityTypeEntity)entity;
					break;
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "CallQueueCriteria":
					this.CallQueueCriteria = (CallQueueCriteriaEntity)entity;
					break;
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "CustomerProfile":
					this.CustomerProfile = (CustomerProfileEntity)entity;
					break;
				case "EventCustomers":
					this.EventCustomers = (EventCustomersEntity)entity;
					break;
				case "Events":
					this.Events = (EventsEntity)entity;
					break;
				case "Language":
					this.Language = (LanguageEntity)entity;
					break;
				case "Lookup":
					this.Lookup = (LookupEntity)entity;
					break;
				case "NotesDetails":
					this.NotesDetails = (NotesDetailsEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "ProspectCustomer":
					this.ProspectCustomer = (ProspectCustomerEntity)entity;
					break;
				case "CallQueueCustomerCall":
					this.CallQueueCustomerCall.Add((CallQueueCustomerCallEntity)entity);
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)entity);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaSystemGeneratedCallQueueAssignment":
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
					break;
				case "CallsCollectionViaCallQueueCustomerCall":
					this.CallsCollectionViaCallQueueCustomerCall.IsReadOnly = false;
					this.CallsCollectionViaCallQueueCustomerCall.Add((CallsEntity)entity);
					this.CallsCollectionViaCallQueueCustomerCall.IsReadOnly = true;
					break;
				case "CallsCollectionViaCustomerCallQueueCallAttempt":
					this.CallsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CallsCollectionViaCustomerCallQueueCallAttempt.Add((CallsEntity)entity);
					this.CallsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaEntity)entity);
					this.HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = false;
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueCriteriaEntity)entity);
					this.SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly = true;
					break;
				case "TagCollectionViaCustomerCallQueueCallAttempt":
					this.TagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = false;
					this.TagCollectionViaCustomerCallQueueCallAttempt.Add((TagEntity)entity);
					this.TagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly = true;
					break;
				case "CallQueueCustomerLock":
					this.CallQueueCustomerLock = (CallQueueCustomerLockEntity)entity;
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
			return CallQueueCustomerEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId);
					break;
				case "ActivityType":
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId);
					break;
				case "CallQueue":
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "CallQueueCriteria":
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId);
					break;
				case "Campaign":
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "CustomerProfile":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId);
					break;
				case "EventCustomers":
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId);
					break;
				case "Events":
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId);
					break;
				case "Language":
					toReturn.Add(CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId);
					break;
				case "Lookup":
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource);
					break;
				case "NotesDetails":
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "ProspectCustomer":
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId);
					break;
				case "CallQueueCustomerCall":
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCustomerCallEntityUsingCallQueueCustomerId);
					break;
				case "CustomerCallQueueCallAttempt":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId);
					break;
				case "SystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallsCollectionViaCallQueueCustomerCall":
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCustomerCallEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "CallQueueCustomerCall_", JoinHint.None);
					toReturn.Add(CallQueueCustomerCallEntity.Relations.CallsEntityUsingCallId, "CallQueueCustomerCall_", string.Empty, JoinHint.None);
					break;
				case "CallsCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CallsEntityUsingCallId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment":
					toReturn.Add(CallQueueCustomerEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "SystemGeneratedCallQueueAssignment_", JoinHint.None);
					toReturn.Add(SystemGeneratedCallQueueAssignmentEntity.Relations.SystemGeneratedCallQueueCriteriaEntityUsingCriteriaId, "SystemGeneratedCallQueueAssignment_", string.Empty, JoinHint.None);
					break;
				case "TagCollectionViaCustomerCallQueueCallAttempt":
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId, "CallQueueCustomerEntity__", "CustomerCallQueueCallAttempt_", JoinHint.None);
					toReturn.Add(CustomerCallQueueCallAttemptEntity.Relations.TagEntityUsingNotInterestedReasonId, "CustomerCallQueueCallAttempt_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerLock":
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCustomerLockEntityUsingCallQueueCustomerId);
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
				case "ActivityType":
					SetupSyncActivityType(relatedEntity);
					break;
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "CallQueueCriteria":
					SetupSyncCallQueueCriteria(relatedEntity);
					break;
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "CustomerProfile":
					SetupSyncCustomerProfile(relatedEntity);
					break;
				case "EventCustomers":
					SetupSyncEventCustomers(relatedEntity);
					break;
				case "Events":
					SetupSyncEvents(relatedEntity);
					break;
				case "Language":
					SetupSyncLanguage(relatedEntity);
					break;
				case "Lookup":
					SetupSyncLookup(relatedEntity);
					break;
				case "NotesDetails":
					SetupSyncNotesDetails(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "ProspectCustomer":
					SetupSyncProspectCustomer(relatedEntity);
					break;
				case "CallQueueCustomerCall":
					this.CallQueueCustomerCall.Add((CallQueueCustomerCallEntity)relatedEntity);
					break;
				case "CustomerCallQueueCallAttempt":
					this.CustomerCallQueueCallAttempt.Add((CustomerCallQueueCallAttemptEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "SystemGeneratedCallQueueAssignment":
					this.SystemGeneratedCallQueueAssignment.Add((SystemGeneratedCallQueueAssignmentEntity)relatedEntity);
					break;
				case "CallQueueCustomerLock":
					SetupSyncCallQueueCustomerLock(relatedEntity);
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
				case "ActivityType":
					DesetupSyncActivityType(false, true);
					break;
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "CallQueueCriteria":
					DesetupSyncCallQueueCriteria(false, true);
					break;
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "CustomerProfile":
					DesetupSyncCustomerProfile(false, true);
					break;
				case "EventCustomers":
					DesetupSyncEventCustomers(false, true);
					break;
				case "Events":
					DesetupSyncEvents(false, true);
					break;
				case "Language":
					DesetupSyncLanguage(false, true);
					break;
				case "Lookup":
					DesetupSyncLookup(false, true);
					break;
				case "NotesDetails":
					DesetupSyncNotesDetails(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "ProspectCustomer":
					DesetupSyncProspectCustomer(false, true);
					break;
				case "CallQueueCustomerCall":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomerCall, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerCallQueueCallAttempt":
					base.PerformRelatedEntityRemoval(this.CustomerCallQueueCallAttempt, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "SystemGeneratedCallQueueAssignment":
					base.PerformRelatedEntityRemoval(this.SystemGeneratedCallQueueAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CallQueueCustomerLock":
					DesetupSyncCallQueueCustomerLock(false, true);
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
			if(_callQueueCustomerLock!=null)
			{
				toReturn.Add(_callQueueCustomerLock);
			}

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
			if(_activityType!=null)
			{
				toReturn.Add(_activityType);
			}
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_callQueueCriteria!=null)
			{
				toReturn.Add(_callQueueCriteria);
			}
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_customerProfile!=null)
			{
				toReturn.Add(_customerProfile);
			}
			if(_eventCustomers!=null)
			{
				toReturn.Add(_eventCustomers);
			}
			if(_events!=null)
			{
				toReturn.Add(_events);
			}
			if(_language!=null)
			{
				toReturn.Add(_language);
			}
			if(_lookup!=null)
			{
				toReturn.Add(_lookup);
			}
			if(_notesDetails!=null)
			{
				toReturn.Add(_notesDetails);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_prospectCustomer!=null)
			{
				toReturn.Add(_prospectCustomer);
			}


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallQueueCustomerCall);
			toReturn.Add(this.CustomerCallQueueCallAttempt);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignment);
			toReturn.Add(this.SystemGeneratedCallQueueAssignment);

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
				info.AddValue("_callQueueCustomerCall", ((_callQueueCustomerCall!=null) && (_callQueueCustomerCall.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCall:null);
				info.AddValue("_customerCallQueueCallAttempt", ((_customerCallQueueCallAttempt!=null) && (_customerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerCallQueueCallAttempt:null);
				info.AddValue("_healthPlanCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_systemGeneratedCallQueueAssignment", ((_systemGeneratedCallQueueAssignment!=null) && (_systemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_systemGeneratedCallQueueAssignment:null);
				info.AddValue("_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_callQueueCollectionViaSystemGeneratedCallQueueAssignment", ((_callQueueCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_callQueueCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_callsCollectionViaCallQueueCustomerCall", ((_callsCollectionViaCallQueueCustomerCall!=null) && (_callsCollectionViaCallQueueCustomerCall.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaCallQueueCustomerCall:null);
				info.AddValue("_callsCollectionViaCustomerCallQueueCallAttempt", ((_callsCollectionViaCustomerCallQueueCallAttempt!=null) && (_callsCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_callsCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_customerProfileCollectionViaCustomerCallQueueCallAttempt", ((_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null) && (_customerProfileCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt", ((_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null) && (_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", ((_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment!=null) && (_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.Count>0) && !this.MarkedForDeletion)?_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment:null);
				info.AddValue("_tagCollectionViaCustomerCallQueueCallAttempt", ((_tagCollectionViaCustomerCallQueueCallAttempt!=null) && (_tagCollectionViaCustomerCallQueueCallAttempt.Count>0) && !this.MarkedForDeletion)?_tagCollectionViaCustomerCallQueueCallAttempt:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_activityType", (!this.MarkedForDeletion?_activityType:null));
				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_callQueueCriteria", (!this.MarkedForDeletion?_callQueueCriteria:null));
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_customerProfile", (!this.MarkedForDeletion?_customerProfile:null));
				info.AddValue("_eventCustomers", (!this.MarkedForDeletion?_eventCustomers:null));
				info.AddValue("_events", (!this.MarkedForDeletion?_events:null));
				info.AddValue("_language", (!this.MarkedForDeletion?_language:null));
				info.AddValue("_lookup", (!this.MarkedForDeletion?_lookup:null));
				info.AddValue("_notesDetails", (!this.MarkedForDeletion?_notesDetails:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_prospectCustomer", (!this.MarkedForDeletion?_prospectCustomer:null));
				info.AddValue("_callQueueCustomerLock", (!this.MarkedForDeletion?_callQueueCustomerLock:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CallQueueCustomerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CallQueueCustomerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CallQueueCustomerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomerCall' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerCallFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerCallQueueCallAttempt' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerCallQueueCallAttemptFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaAssignmentFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SystemGeneratedCallQueueAssignmentFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaCallQueueCustomerCall()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaCallQueueCustomerCall"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Calls' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallsCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallsCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SystemGeneratedCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Tag' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTagCollectionViaCustomerCallQueueCallAttempt()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TagCollectionViaCustomerCallQueueCallAttempt"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId, "CallQueueCustomerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.HealthPlanId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActivityTypeFields.Id, null, ComparisonOperator.Equal, this.ActivityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCriteriaFields.CallQueueCriteriaId, null, ComparisonOperator.Equal, this.CallQueueCriteriaId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Campaign' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaign()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CampaignFields.Id, null, ComparisonOperator.Equal, this.CampaignId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.CustomerId, null, ComparisonOperator.Equal, this.CustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomers()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventCustomersFields.EventCustomerId, null, ComparisonOperator.Equal, this.EventCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Events' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEvents()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventsFields.EventId, null, ComparisonOperator.Equal, this.EventId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Language' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.LanguageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Lookup' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LookupFields.LookupId, null, ComparisonOperator.Equal, this.DoNotContactUpdateSource));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NotesDetailsFields.NoteId, null, ComparisonOperator.Equal, this.NotesId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.AssignedToOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.CreatedByOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCustomerFields.ProspectCustomerId, null, ComparisonOperator.Equal, this.ProspectCustomerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CallQueueCustomerLock' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerLock()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerLockFields.CallQueueCustomerId, null, ComparisonOperator.Equal, this.CallQueueCustomerId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.CallQueueCustomerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomerCall);
			collectionsQueue.Enqueue(this._customerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._systemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._callQueueCollectionViaSystemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._callsCollectionViaCallQueueCustomerCall);
			collectionsQueue.Enqueue(this._callsCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);
			collectionsQueue.Enqueue(this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment);
			collectionsQueue.Enqueue(this._tagCollectionViaCustomerCallQueueCallAttempt);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomerCall = (EntityCollection<CallQueueCustomerCallEntity>) collectionsQueue.Dequeue();
			this._customerCallQueueCallAttempt = (EntityCollection<CustomerCallQueueCallAttemptEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._systemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueAssignmentEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaCallQueueCustomerCall = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._callsCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CallsEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = (EntityCollection<SystemGeneratedCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._tagCollectionViaCustomerCallQueueCallAttempt = (EntityCollection<TagEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callQueueCustomerCall != null)
			{
				return true;
			}
			if (this._customerCallQueueCallAttempt != null)
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
			if (this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaSystemGeneratedCallQueueAssignment != null)
			{
				return true;
			}
			if (this._callsCollectionViaCallQueueCustomerCall != null)
			{
				return true;
			}
			if (this._callsCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerCallQueueCallAttempt != null)
			{
				return true;
			}
			if (this._systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment != null)
			{
				return true;
			}
			if (this._tagCollectionViaCustomerCallQueueCallAttempt != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))) : null);
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
			toReturn.Add("ActivityType", _activityType);
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("CallQueueCriteria", _callQueueCriteria);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("EventCustomers", _eventCustomers);
			toReturn.Add("Events", _events);
			toReturn.Add("Language", _language);
			toReturn.Add("Lookup", _lookup);
			toReturn.Add("NotesDetails", _notesDetails);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("ProspectCustomer", _prospectCustomer);
			toReturn.Add("CallQueueCustomerCall", _callQueueCustomerCall);
			toReturn.Add("CustomerCallQueueCallAttempt", _customerCallQueueCallAttempt);
			toReturn.Add("HealthPlanCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaAssignment);
			toReturn.Add("SystemGeneratedCallQueueAssignment", _systemGeneratedCallQueueAssignment);
			toReturn.Add("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", _callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("CallQueueCollectionViaSystemGeneratedCallQueueAssignment", _callQueueCollectionViaSystemGeneratedCallQueueAssignment);
			toReturn.Add("CallsCollectionViaCallQueueCustomerCall", _callsCollectionViaCallQueueCustomerCall);
			toReturn.Add("CallsCollectionViaCustomerCallQueueCallAttempt", _callsCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CustomerProfileCollectionViaCustomerCallQueueCallAttempt", _customerProfileCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", _systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment);
			toReturn.Add("TagCollectionViaCustomerCallQueueCallAttempt", _tagCollectionViaCustomerCallQueueCallAttempt);
			toReturn.Add("CallQueueCustomerLock", _callQueueCustomerLock);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callQueueCustomerCall!=null)
			{
				_callQueueCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_customerCallQueueCallAttempt!=null)
			{
				_customerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_systemGeneratedCallQueueAssignment!=null)
			{
				_systemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_callQueueCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaCallQueueCustomerCall!=null)
			{
				_callsCollectionViaCallQueueCustomerCall.ActiveContext = base.ActiveContext;
			}
			if(_callsCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_callsCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_customerProfileCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment!=null)
			{
				_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment.ActiveContext = base.ActiveContext;
			}
			if(_tagCollectionViaCustomerCallQueueCallAttempt!=null)
			{
				_tagCollectionViaCustomerCallQueueCallAttempt.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_activityType!=null)
			{
				_activityType.ActiveContext = base.ActiveContext;
			}
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCriteria!=null)
			{
				_callQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_eventCustomers!=null)
			{
				_eventCustomers.ActiveContext = base.ActiveContext;
			}
			if(_events!=null)
			{
				_events.ActiveContext = base.ActiveContext;
			}
			if(_language!=null)
			{
				_language.ActiveContext = base.ActiveContext;
			}
			if(_lookup!=null)
			{
				_lookup.ActiveContext = base.ActiveContext;
			}
			if(_notesDetails!=null)
			{
				_notesDetails.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomer!=null)
			{
				_prospectCustomer.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerLock!=null)
			{
				_callQueueCustomerLock.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callQueueCustomerCall = null;
			_customerCallQueueCallAttempt = null;
			_healthPlanCallQueueCriteriaAssignment = null;
			_systemGeneratedCallQueueAssignment = null;
			_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_callQueueCollectionViaSystemGeneratedCallQueueAssignment = null;
			_callsCollectionViaCallQueueCustomerCall = null;
			_callsCollectionViaCustomerCallQueueCallAttempt = null;
			_customerProfileCollectionViaCustomerCallQueueCallAttempt = null;
			_healthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = null;
			_systemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment = null;
			_tagCollectionViaCustomerCallQueueCallAttempt = null;
			_account = null;
			_activityType = null;
			_callQueue = null;
			_callQueueCriteria = null;
			_campaign = null;
			_customerProfile = null;
			_eventCustomers = null;
			_events = null;
			_language = null;
			_lookup = null;
			_notesDetails = null;
			_organizationRoleUser = null;
			_organizationRoleUser__ = null;
			_organizationRoleUser_ = null;
			_prospectCustomer = null;
			_callQueueCustomerLock = null;
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

			_fieldsCustomProperties.Add("CallQueueCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Attempts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NotesId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AssignedToOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallQueueCriteriaId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastUpdatedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FirstName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MiddleName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneHome", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Tag", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsEligble", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsIncorrectPhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsLanguageBarrier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActivityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactReasonId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallCount", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallStatus", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ContactedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Disposition", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CallBackRequestedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentCancellationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EventCustomerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AppointmentDateTimeWithTimeZone", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DoNotContactUpdateSource", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IncorrectPhoneNumberMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageBarrierMarkedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoShowDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TargetedYear", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTargeted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProductTypeId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.HealthPlanId } );		
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
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _activityType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActivityType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _activityType, new PropertyChangedEventHandler( OnActivityTypePropertyChanged ), "ActivityType", CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.ActivityId } );		
			_activityType = null;
		}

		/// <summary> setups the sync logic for member _activityType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActivityType(IEntity2 relatedEntity)
		{
			if(_activityType!=relatedEntity)
			{
				DesetupSyncActivityType(true, true);
				_activityType = (ActivityTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _activityType, new PropertyChangedEventHandler( OnActivityTypePropertyChanged ), "ActivityType", CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActivityTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.CallQueueId } );		
			_callQueue = null;
		}

		/// <summary> setups the sync logic for member _callQueue</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueue(IEntity2 relatedEntity)
		{
			if(_callQueue!=relatedEntity)
			{
				DesetupSyncCallQueue(true, true);
				_callQueue = (CallQueueEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueuePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _callQueueCriteria</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueueCriteria(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueueCriteria, new PropertyChangedEventHandler( OnCallQueueCriteriaPropertyChanged ), "CallQueueCriteria", CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.CallQueueCriteriaId } );		
			_callQueueCriteria = null;
		}

		/// <summary> setups the sync logic for member _callQueueCriteria</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueueCriteria(IEntity2 relatedEntity)
		{
			if(_callQueueCriteria!=relatedEntity)
			{
				DesetupSyncCallQueueCriteria(true, true);
				_callQueueCriteria = (CallQueueCriteriaEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueueCriteria, new PropertyChangedEventHandler( OnCallQueueCriteriaPropertyChanged ), "CallQueueCriteria", CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueueCriteriaPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.CampaignId } );		
			_campaign = null;
		}

		/// <summary> setups the sync logic for member _campaign</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCampaign(IEntity2 relatedEntity)
		{
			if(_campaign!=relatedEntity)
			{
				DesetupSyncCampaign(true, true);
				_campaign = (CampaignEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCampaignPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _customerProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCustomerProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.CustomerId } );		
			_customerProfile = null;
		}

		/// <summary> setups the sync logic for member _customerProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCustomerProfile(IEntity2 relatedEntity)
		{
			if(_customerProfile!=relatedEntity)
			{
				DesetupSyncCustomerProfile(true, true);
				_customerProfile = (CustomerProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _customerProfile, new PropertyChangedEventHandler( OnCustomerProfilePropertyChanged ), "CustomerProfile", CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCustomerProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _eventCustomers</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEventCustomers(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.EventCustomerId } );		
			_eventCustomers = null;
		}

		/// <summary> setups the sync logic for member _eventCustomers</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEventCustomers(IEntity2 relatedEntity)
		{
			if(_eventCustomers!=relatedEntity)
			{
				DesetupSyncEventCustomers(true, true);
				_eventCustomers = (EventCustomersEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _eventCustomers, new PropertyChangedEventHandler( OnEventCustomersPropertyChanged ), "EventCustomers", CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventCustomersPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _events</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncEvents(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.EventId } );		
			_events = null;
		}

		/// <summary> setups the sync logic for member _events</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncEvents(IEntity2 relatedEntity)
		{
			if(_events!=relatedEntity)
			{
				DesetupSyncEvents(true, true);
				_events = (EventsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _events, new PropertyChangedEventHandler( OnEventsPropertyChanged ), "Events", CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnEventsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _language</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLanguage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _language, new PropertyChangedEventHandler( OnLanguagePropertyChanged ), "Language", CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.LanguageId } );		
			_language = null;
		}

		/// <summary> setups the sync logic for member _language</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncLanguage(IEntity2 relatedEntity)
		{
			if(_language!=relatedEntity)
			{
				DesetupSyncLanguage(true, true);
				_language = (LanguageEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _language, new PropertyChangedEventHandler( OnLanguagePropertyChanged ), "Language", CallQueueCustomerEntity.Relations.LanguageEntityUsingLanguageId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnLanguagePropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.DoNotContactUpdateSource } );		
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
				base.PerformSetupSyncRelatedEntity( _lookup, new PropertyChangedEventHandler( OnLookupPropertyChanged ), "Lookup", CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _notesDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNotesDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _notesDetails, new PropertyChangedEventHandler( OnNotesDetailsPropertyChanged ), "NotesDetails", CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.NotesId } );		
			_notesDetails = null;
		}

		/// <summary> setups the sync logic for member _notesDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNotesDetails(IEntity2 relatedEntity)
		{
			if(_notesDetails!=relatedEntity)
			{
				DesetupSyncNotesDetails(true, true);
				_notesDetails = (NotesDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _notesDetails, new PropertyChangedEventHandler( OnNotesDetailsPropertyChanged ), "NotesDetails", CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNotesDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.AssignedToOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "CallQueueCustomer__", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.ModifiedByOrgRoleUserId } );		
			_organizationRoleUser__ = null;
		}

		/// <summary> setups the sync logic for member _organizationRoleUser__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationRoleUser__(IEntity2 relatedEntity)
		{
			if(_organizationRoleUser__!=relatedEntity)
			{
				DesetupSyncOrganizationRoleUser__(true, true);
				_organizationRoleUser__ = (OrganizationRoleUserEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationRoleUser__PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "CallQueueCustomer_", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _prospectCustomer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspectCustomer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospectCustomer, new PropertyChangedEventHandler( OnProspectCustomerPropertyChanged ), "ProspectCustomer", CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, true, signalRelatedEntity, "CallQueueCustomer", resetFKFields, new int[] { (int)CallQueueCustomerFieldIndex.ProspectCustomerId } );		
			_prospectCustomer = null;
		}

		/// <summary> setups the sync logic for member _prospectCustomer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspectCustomer(IEntity2 relatedEntity)
		{
			if(_prospectCustomer!=relatedEntity)
			{
				DesetupSyncProspectCustomer(true, true);
				_prospectCustomer = (ProspectCustomerEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospectCustomer, new PropertyChangedEventHandler( OnProspectCustomerPropertyChanged ), "ProspectCustomer", CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectCustomerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _callQueueCustomerLock</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueueCustomerLock(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueueCustomerLock, new PropertyChangedEventHandler( OnCallQueueCustomerLockPropertyChanged ), "CallQueueCustomerLock", CallQueueCustomerEntity.Relations.CallQueueCustomerLockEntityUsingCallQueueCustomerId, false, signalRelatedEntity, "CallQueueCustomer", false, new int[] { (int)CallQueueCustomerFieldIndex.CallQueueCustomerId } );
			_callQueueCustomerLock = null;
		}
		
		/// <summary> setups the sync logic for member _callQueueCustomerLock</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCallQueueCustomerLock(IEntity2 relatedEntity)
		{
			if(_callQueueCustomerLock!=relatedEntity)
			{
				DesetupSyncCallQueueCustomerLock(true, true);
				_callQueueCustomerLock = (CallQueueCustomerLockEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _callQueueCustomerLock, new PropertyChangedEventHandler( OnCallQueueCustomerLockPropertyChanged ), "CallQueueCustomerLock", CallQueueCustomerEntity.Relations.CallQueueCustomerLockEntityUsingCallQueueCustomerId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCallQueueCustomerLockPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CallQueueCustomerEntity</param>
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
		public  static CallQueueCustomerRelations Relations
		{
			get	{ return new CallQueueCustomerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomerCall' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCall
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomerCall")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueCustomerCallEntity, 0, null, null, null, null, "CallQueueCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerCallQueueCallAttempt' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerCallQueueCallAttempt
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerCallQueueCallAttempt")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CustomerCallQueueCallAttemptEntity, 0, null, null, null, null, "CustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("SystemGeneratedCallQueueAssignment")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueAssignmentEntity, 0, null, null, null, null, "SystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaSystemGeneratedCallQueueAssignment"), null, "CallQueueCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaCallQueueCustomerCall
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.CallQueueCustomerCallEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomerCall_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaCallQueueCustomerCall"), null, "CallsCollectionViaCallQueueCustomerCall", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Calls' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallsCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallsEntity, 0, null, null, GetRelationsForField("CallsCollectionViaCustomerCallQueueCallAttempt"), null, "CallsCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerCallQueueCallAttempt"), null, "CustomerProfileCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "HealthPlanCallQueueCriteriaCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt"), null, "OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SystemGeneratedCallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.SystemGeneratedCallQueueAssignmentEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "SystemGeneratedCallQueueAssignment_");
				return new PrefetchPathElement2(new EntityCollection<SystemGeneratedCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SystemGeneratedCallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.SystemGeneratedCallQueueCriteriaEntity, 0, null, null, GetRelationsForField("SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment"), null, "SystemGeneratedCallQueueCriteriaCollectionViaSystemGeneratedCallQueueAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Tag' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTagCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				IEntityRelation intermediateRelation = CallQueueCustomerEntity.Relations.CustomerCallQueueCallAttemptEntityUsingCallQueueCustomerId;
				intermediateRelation.SetAliases(string.Empty, "CustomerCallQueueCallAttempt_");
				return new PrefetchPathElement2(new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.TagEntity, 0, null, null, GetRelationsForField("TagCollectionViaCustomerCallQueueCallAttempt"), null, "TagCollectionViaCustomerCallQueueCallAttempt", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ActivityType")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, null, null, "ActivityType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueue
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteria
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCriteria")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, null, null, "CallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaign
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))),
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomers
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventCustomers")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, null, null, "EventCustomers", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEvents
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Events")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, null, null, "Events", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguage
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))),
					(IEntityRelation)GetRelationsForField("Language")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, null, null, "Language", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Lookup")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, null, null, "Lookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("NotesDetails")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, null, null, "NotesDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCustomer")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, null, null, "ProspectCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomerLock' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerLock
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerLockEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallQueueCustomerLock")[0], (int)Falcon.Data.EntityType.CallQueueCustomerEntity, (int)Falcon.Data.EntityType.CallQueueCustomerLockEntity, 0, null, null, null, null, "CallQueueCustomerLock", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CallQueueCustomerEntity.CustomProperties;}
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
			get { return CallQueueCustomerEntity.FieldsCustomProperties;}
		}

		/// <summary> The CallQueueCustomerId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallQueueCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CallQueueCustomerId
		{
			get { return (System.Int64)GetValue((int)CallQueueCustomerFieldIndex.CallQueueCustomerId, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallQueueCustomerId, value); }
		}

		/// <summary> The CallQueueId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)CallQueueCustomerFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallQueueId, value); }
		}

		/// <summary> The CustomerId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CustomerId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CustomerId, value); }
		}

		/// <summary> The ProspectCustomerId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ProspectCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.ProspectCustomerId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ProspectCustomerId, value); }
		}

		/// <summary> The Status property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Status
		{
			get { return (System.Int64)GetValue((int)CallQueueCustomerFieldIndex.Status, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.Status, value); }
		}

		/// <summary> The Attempts property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."Attempts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 Attempts
		{
			get { return (System.Int32)GetValue((int)CallQueueCustomerFieldIndex.Attempts, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.Attempts, value); }
		}

		/// <summary> The IsActive property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)CallQueueCustomerFieldIndex.IsActive, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IsActive, value); }
		}

		/// <summary> The NotesId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."NotesId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> NotesId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.NotesId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.NotesId, value); }
		}

		/// <summary> The DateCreated property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)CallQueueCustomerFieldIndex.DateCreated, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.DateModified, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The AssignedToOrgRoleUserId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."AssignedToOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AssignedToOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.AssignedToOrgRoleUserId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.AssignedToOrgRoleUserId, value); }
		}

		/// <summary> The CallQueueCriteriaId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallQueueCriteriaId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallQueueCriteriaId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CallQueueCriteriaId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallQueueCriteriaId, value); }
		}

		/// <summary> The CallDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime CallDate
		{
			get { return (System.DateTime)GetValue((int)CallQueueCustomerFieldIndex.CallDate, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallDate, value); }
		}

		/// <summary> The EventId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."EventId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.EventId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.EventId, value); }
		}

		/// <summary> The HealthPlanId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."HealthPlanId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HealthPlanId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.HealthPlanId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The CampaignId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CampaignId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CampaignId, value); }
		}

		/// <summary> The LastUpdatedOn property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."LastUpdatedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastUpdatedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.LastUpdatedOn, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.LastUpdatedOn, value); }
		}

		/// <summary> The FirstName property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."FirstName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FirstName
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.FirstName, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.FirstName, value); }
		}

		/// <summary> The MiddleName property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."MiddleName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MiddleName
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.MiddleName, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.MiddleName, value); }
		}

		/// <summary> The LastName property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."LastName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String LastName
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.LastName, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.LastName, value); }
		}

		/// <summary> The PhoneOffice property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneCell property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneHome property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."PhoneHome"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneHome
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.PhoneHome, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.PhoneHome, value); }
		}

		/// <summary> The ZipId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ZipId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ZipId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.ZipId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ZipId, value); }
		}

		/// <summary> The ZipCode property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.ZipCode, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ZipCode, value); }
		}

		/// <summary> The Tag property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."Tag"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Tag
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.Tag, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.Tag, value); }
		}

		/// <summary> The IsEligble property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IsEligble"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsEligble
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallQueueCustomerFieldIndex.IsEligble, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IsEligble, value); }
		}

		/// <summary> The IsIncorrectPhoneNumber property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IsIncorrectPhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsIncorrectPhoneNumber
		{
			get { return (System.Boolean)GetValue((int)CallQueueCustomerFieldIndex.IsIncorrectPhoneNumber, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IsIncorrectPhoneNumber, value); }
		}

		/// <summary> The IsLanguageBarrier property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IsLanguageBarrier"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsLanguageBarrier
		{
			get { return (System.Boolean)GetValue((int)CallQueueCustomerFieldIndex.IsLanguageBarrier, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IsLanguageBarrier, value); }
		}

		/// <summary> The ActivityId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ActivityId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ActivityId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.ActivityId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ActivityId, value); }
		}

		/// <summary> The DoNotContactTypeId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DoNotContactTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.DoNotContactTypeId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DoNotContactTypeId, value); }
		}

		/// <summary> The DoNotContactReasonId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DoNotContactReasonId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactReasonId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.DoNotContactReasonId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DoNotContactReasonId, value); }
		}

		/// <summary> The DoNotContactUpdateDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DoNotContactUpdateDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DoNotContactUpdateDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.DoNotContactUpdateDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DoNotContactUpdateDate, value); }
		}

		/// <summary> The CallCount property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallCount"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallCount
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CallCount, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallCount, value); }
		}

		/// <summary> The AppointmentDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."AppointmentDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> AppointmentDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.AppointmentDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.AppointmentDate, value); }
		}

		/// <summary> The CallStatus property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallStatus"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CallStatus
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.CallStatus, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallStatus, value); }
		}

		/// <summary> The ContactedDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ContactedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> ContactedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.ContactedDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ContactedDate, value); }
		}

		/// <summary> The Disposition property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."Disposition"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 400<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Disposition
		{
			get { return (System.String)GetValue((int)CallQueueCustomerFieldIndex.Disposition, true); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.Disposition, value); }
		}

		/// <summary> The CallBackRequestedDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."CallBackRequestedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CallBackRequestedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.CallBackRequestedDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.CallBackRequestedDate, value); }
		}

		/// <summary> The AppointmentCancellationDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."AppointmentCancellationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> AppointmentCancellationDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.AppointmentCancellationDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.AppointmentCancellationDate, value); }
		}

		/// <summary> The EventCustomerId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."EventCustomerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> EventCustomerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.EventCustomerId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.EventCustomerId, value); }
		}

		/// <summary> The AppointmentDateTimeWithTimeZone property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."AppointmentDateTimeWithTimeZone"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> AppointmentDateTimeWithTimeZone
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.AppointmentDateTimeWithTimeZone, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.AppointmentDateTimeWithTimeZone, value); }
		}

		/// <summary> The DoNotContactUpdateSource property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."DoNotContactUpdateSource"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> DoNotContactUpdateSource
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.DoNotContactUpdateSource, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.DoNotContactUpdateSource, value); }
		}

		/// <summary> The IncorrectPhoneNumberMarkedDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IncorrectPhoneNumberMarkedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> IncorrectPhoneNumberMarkedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.IncorrectPhoneNumberMarkedDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IncorrectPhoneNumberMarkedDate, value); }
		}

		/// <summary> The LanguageBarrierMarkedDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."LanguageBarrierMarkedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LanguageBarrierMarkedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.LanguageBarrierMarkedDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.LanguageBarrierMarkedDate, value); }
		}

		/// <summary> The LanguageId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LanguageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.LanguageId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.LanguageId, value); }
		}

		/// <summary> The NoShowDate property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."NoShowDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> NoShowDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)CallQueueCustomerFieldIndex.NoShowDate, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.NoShowDate, value); }
		}

		/// <summary> The TargetedYear property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."TargetedYear"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> TargetedYear
		{
			get { return (Nullable<System.Int32>)GetValue((int)CallQueueCustomerFieldIndex.TargetedYear, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.TargetedYear, value); }
		}

		/// <summary> The IsTargeted property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."IsTargeted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsTargeted
		{
			get { return (Nullable<System.Boolean>)GetValue((int)CallQueueCustomerFieldIndex.IsTargeted, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.IsTargeted, value); }
		}

		/// <summary> The ProductTypeId property of the Entity CallQueueCustomer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblCallQueueCustomer"."ProductTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProductTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)CallQueueCustomerFieldIndex.ProductTypeId, false); }
			set	{ SetValue((int)CallQueueCustomerFieldIndex.ProductTypeId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueCustomerCallEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueCustomerCallEntity))]
		public virtual EntityCollection<CallQueueCustomerCallEntity> CallQueueCustomerCall
		{
			get
			{
				if(_callQueueCustomerCall==null)
				{
					_callQueueCustomerCall = new EntityCollection<CallQueueCustomerCallEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerCallEntityFactory)));
					_callQueueCustomerCall.SetContainingEntityInfo(this, "CallQueueCustomer");
				}
				return _callQueueCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerCallQueueCallAttemptEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerCallQueueCallAttemptEntity))]
		public virtual EntityCollection<CustomerCallQueueCallAttemptEntity> CustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerCallQueueCallAttempt==null)
				{
					_customerCallQueueCallAttempt = new EntityCollection<CustomerCallQueueCallAttemptEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerCallQueueCallAttemptEntityFactory)));
					_customerCallQueueCallAttempt.SetContainingEntityInfo(this, "CallQueueCustomer");
				}
				return _customerCallQueueCallAttempt;
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
					_healthPlanCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "CallQueueCustomer");
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
					_systemGeneratedCallQueueAssignment.SetContainingEntityInfo(this, "CallQueueCustomer");
				}
				return _systemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				if(_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment==null)
				{
					_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallQueueEntity))]
		public virtual EntityCollection<CallQueueEntity> CallQueueCollectionViaSystemGeneratedCallQueueAssignment
		{
			get
			{
				if(_callQueueCollectionViaSystemGeneratedCallQueueAssignment==null)
				{
					_callQueueCollectionViaSystemGeneratedCallQueueAssignment = new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory)));
					_callQueueCollectionViaSystemGeneratedCallQueueAssignment.IsReadOnly=true;
				}
				return _callQueueCollectionViaSystemGeneratedCallQueueAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaCallQueueCustomerCall
		{
			get
			{
				if(_callsCollectionViaCallQueueCustomerCall==null)
				{
					_callsCollectionViaCallQueueCustomerCall = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaCallQueueCustomerCall.IsReadOnly=true;
				}
				return _callsCollectionViaCallQueueCustomerCall;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallsEntity))]
		public virtual EntityCollection<CallsEntity> CallsCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_callsCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_callsCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CallsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallsEntityFactory)));
					_callsCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _callsCollectionViaCustomerCallQueueCallAttempt;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_customerProfileCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_customerProfileCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerCallQueueCallAttempt;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerCallQueueCallAttempt;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'TagEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TagEntity))]
		public virtual EntityCollection<TagEntity> TagCollectionViaCustomerCallQueueCallAttempt
		{
			get
			{
				if(_tagCollectionViaCustomerCallQueueCallAttempt==null)
				{
					_tagCollectionViaCustomerCallQueueCallAttempt = new EntityCollection<TagEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TagEntityFactory)));
					_tagCollectionViaCustomerCallQueueCallAttempt.IsReadOnly=true;
				}
				return _tagCollectionViaCustomerCallQueueCallAttempt;
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
							_account.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ActivityTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ActivityTypeEntity ActivityType
		{
			get
			{
				return _activityType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncActivityType(value);
				}
				else
				{
					if(value==null)
					{
						if(_activityType != null)
						{
							_activityType.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_activityType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueEntity CallQueue
		{
			get
			{
				return _callQueue;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueue(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueue != null)
						{
							_callQueue.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueCriteriaEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueCriteriaEntity CallQueueCriteria
		{
			get
			{
				return _callQueueCriteria;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueueCriteria(value);
				}
				else
				{
					if(value==null)
					{
						if(_callQueueCriteria != null)
						{
							_callQueueCriteria.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_callQueueCriteria!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CampaignEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CampaignEntity Campaign
		{
			get
			{
				return _campaign;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCampaign(value);
				}
				else
				{
					if(value==null)
					{
						if(_campaign != null)
						{
							_campaign.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CustomerProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CustomerProfileEntity CustomerProfile
		{
			get
			{
				return _customerProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCustomerProfile(value);
				}
				else
				{
					if(value==null)
					{
						if(_customerProfile != null)
						{
							_customerProfile.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_customerProfile!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventCustomersEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventCustomersEntity EventCustomers
		{
			get
			{
				return _eventCustomers;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEventCustomers(value);
				}
				else
				{
					if(value==null)
					{
						if(_eventCustomers != null)
						{
							_eventCustomers.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_eventCustomers!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'EventsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual EventsEntity Events
		{
			get
			{
				return _events;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncEvents(value);
				}
				else
				{
					if(value==null)
					{
						if(_events != null)
						{
							_events.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_events!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'LanguageEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual LanguageEntity Language
		{
			get
			{
				return _language;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncLanguage(value);
				}
				else
				{
					if(value==null)
					{
						if(_language != null)
						{
							_language.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_language!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
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
							_lookup.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_lookup!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NotesDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NotesDetailsEntity NotesDetails
		{
			get
			{
				return _notesDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNotesDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_notesDetails != null)
						{
							_notesDetails.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_notesDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationRoleUserEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationRoleUserEntity OrganizationRoleUser__
		{
			get
			{
				return _organizationRoleUser__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationRoleUser__(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationRoleUser__ != null)
						{
							_organizationRoleUser__.UnsetRelatedEntity(this, "CallQueueCustomer__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer__");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "CallQueueCustomer_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer_");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectCustomerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectCustomerEntity ProspectCustomer
		{
			get
			{
				return _prospectCustomer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspectCustomer(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospectCustomer != null)
						{
							_prospectCustomer.UnsetRelatedEntity(this, "CallQueueCustomer");
						}
					}
					else
					{
						if(_prospectCustomer!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "CallQueueCustomer");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CallQueueCustomerLockEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CallQueueCustomerLockEntity CallQueueCustomerLock
		{
			get
			{
				return _callQueueCustomerLock;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCallQueueCustomerLock(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "CallQueueCustomer");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_callQueueCustomerLock !=null);
						DesetupSyncCallQueueCustomerLock(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("CallQueueCustomerLock");
						}
					}
					else
					{
						if(_callQueueCustomerLock!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "CallQueueCustomer");
							SetupSyncCallQueueCustomerLock(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.CallQueueCustomerEntity; }
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
