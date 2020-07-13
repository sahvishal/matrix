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
	/// Entity class which represents the entity 'Language'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class LanguageEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomer;
		private EntityCollection<CustomerProfileEntity> _customerProfile;
		private EntityCollection<HealthPlanCallQueueCriteriaEntity> _healthPlanCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<AccountEntity> _accountCollectionViaCallQueueCustomer;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCustomerProfile;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCallQueueCustomer;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerProfile;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaCallQueueCustomer;
		private EntityCollection<CallQueueCriteriaEntity> _callQueueCriteriaCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaCallQueueCustomer;
		private EntityCollection<CampaignEntity> _campaignCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCallQueueCustomer;
		private EntityCollection<EventCustomersEntity> _eventCustomersCollectionViaCallQueueCustomer;
		private EntityCollection<EventsEntity> _eventsCollectionViaCallQueueCustomer;
		private EntityCollection<LabEntity> _labCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCallQueueCustomer;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile________;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile___;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile__;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCallQueueCustomer;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCustomerProfile;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCallQueueCustomer;
		private EntityCollection<ProspectCustomerEntity> _prospectCustomerCollectionViaCallQueueCustomer;
		private EntityCollection<RoleEntity> _roleCollectionViaCustomerProfile;
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name CallQueueCustomer</summary>
			public static readonly string CallQueueCustomer = "CallQueueCustomer";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name HealthPlanCallQueueCriteria</summary>
			public static readonly string HealthPlanCallQueueCriteria = "HealthPlanCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string AccountCollectionViaHealthPlanCallQueueCriteria = "AccountCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name AccountCollectionViaCallQueueCustomer</summary>
			public static readonly string AccountCollectionViaCallQueueCustomer = "AccountCollectionViaCallQueueCustomer";
			/// <summary>Member name ActivityTypeCollectionViaCustomerProfile</summary>
			public static readonly string ActivityTypeCollectionViaCustomerProfile = "ActivityTypeCollectionViaCustomerProfile";
			/// <summary>Member name ActivityTypeCollectionViaCallQueueCustomer</summary>
			public static readonly string ActivityTypeCollectionViaCallQueueCustomer = "ActivityTypeCollectionViaCallQueueCustomer";
			/// <summary>Member name AddressCollectionViaCustomerProfile</summary>
			public static readonly string AddressCollectionViaCustomerProfile = "AddressCollectionViaCustomerProfile";
			/// <summary>Member name CallQueueCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CallQueueCollectionViaHealthPlanCallQueueCriteria = "CallQueueCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CallQueueCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCollectionViaCallQueueCustomer = "CallQueueCollectionViaCallQueueCustomer";
			/// <summary>Member name CallQueueCriteriaCollectionViaCallQueueCustomer</summary>
			public static readonly string CallQueueCriteriaCollectionViaCallQueueCustomer = "CallQueueCriteriaCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaCallQueueCustomer</summary>
			public static readonly string CampaignCollectionViaCallQueueCustomer = "CampaignCollectionViaCallQueueCustomer";
			/// <summary>Member name CampaignCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string CampaignCollectionViaHealthPlanCallQueueCriteria = "CampaignCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name CustomerProfileCollectionViaCallQueueCustomer</summary>
			public static readonly string CustomerProfileCollectionViaCallQueueCustomer = "CustomerProfileCollectionViaCallQueueCustomer";
			/// <summary>Member name EventCustomersCollectionViaCallQueueCustomer</summary>
			public static readonly string EventCustomersCollectionViaCallQueueCustomer = "EventCustomersCollectionViaCallQueueCustomer";
			/// <summary>Member name EventsCollectionViaCallQueueCustomer</summary>
			public static readonly string EventsCollectionViaCallQueueCustomer = "EventsCollectionViaCallQueueCustomer";
			/// <summary>Member name LabCollectionViaCustomerProfile</summary>
			public static readonly string LabCollectionViaCustomerProfile = "LabCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile_</summary>
			public static readonly string LookupCollectionViaCustomerProfile_ = "LookupCollectionViaCustomerProfile_";
			/// <summary>Member name LookupCollectionViaCustomerProfile_____</summary>
			public static readonly string LookupCollectionViaCustomerProfile_____ = "LookupCollectionViaCustomerProfile_____";
			/// <summary>Member name LookupCollectionViaCustomerProfile______</summary>
			public static readonly string LookupCollectionViaCustomerProfile______ = "LookupCollectionViaCustomerProfile______";
			/// <summary>Member name LookupCollectionViaCallQueueCustomer</summary>
			public static readonly string LookupCollectionViaCallQueueCustomer = "LookupCollectionViaCallQueueCustomer";
			/// <summary>Member name LookupCollectionViaCustomerProfile_______</summary>
			public static readonly string LookupCollectionViaCustomerProfile_______ = "LookupCollectionViaCustomerProfile_______";
			/// <summary>Member name LookupCollectionViaCustomerProfile________</summary>
			public static readonly string LookupCollectionViaCustomerProfile________ = "LookupCollectionViaCustomerProfile________";
			/// <summary>Member name LookupCollectionViaCustomerProfile___</summary>
			public static readonly string LookupCollectionViaCustomerProfile___ = "LookupCollectionViaCustomerProfile___";
			/// <summary>Member name LookupCollectionViaCustomerProfile</summary>
			public static readonly string LookupCollectionViaCustomerProfile = "LookupCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile____</summary>
			public static readonly string LookupCollectionViaCustomerProfile____ = "LookupCollectionViaCustomerProfile____";
			/// <summary>Member name LookupCollectionViaCustomerProfile__</summary>
			public static readonly string LookupCollectionViaCustomerProfile__ = "LookupCollectionViaCustomerProfile__";
			/// <summary>Member name NotesDetailsCollectionViaCallQueueCustomer</summary>
			public static readonly string NotesDetailsCollectionViaCallQueueCustomer = "NotesDetailsCollectionViaCallQueueCustomer";
			/// <summary>Member name NotesDetailsCollectionViaCustomerProfile</summary>
			public static readonly string NotesDetailsCollectionViaCustomerProfile = "NotesDetailsCollectionViaCustomerProfile";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer__ = "OrganizationRoleUserCollectionViaCallQueueCustomer__";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria = "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer_ = "OrganizationRoleUserCollectionViaCallQueueCustomer_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCallQueueCustomer</summary>
			public static readonly string OrganizationRoleUserCollectionViaCallQueueCustomer = "OrganizationRoleUserCollectionViaCallQueueCustomer";
			/// <summary>Member name ProspectCustomerCollectionViaCallQueueCustomer</summary>
			public static readonly string ProspectCustomerCollectionViaCallQueueCustomer = "ProspectCustomerCollectionViaCallQueueCustomer";
			/// <summary>Member name RoleCollectionViaCustomerProfile</summary>
			public static readonly string RoleCollectionViaCustomerProfile = "RoleCollectionViaCustomerProfile";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static LanguageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public LanguageEntity():base("LanguageEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public LanguageEntity(IEntityFields2 fields):base("LanguageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this LanguageEntity</param>
		public LanguageEntity(IValidator validator):base("LanguageEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Language which data should be fetched into this Language object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public LanguageEntity(System.Int64 id):base("LanguageEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for Language which data should be fetched into this Language object</param>
		/// <param name="validator">The custom validator object for this LanguageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public LanguageEntity(System.Int64 id, IValidator validator):base("LanguageEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected LanguageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomer", typeof(EntityCollection<CallQueueCustomerEntity>));
				_customerProfile = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfile", typeof(EntityCollection<CustomerProfileEntity>));
				_healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>)info.GetValue("_healthPlanCallQueueCriteria", typeof(EntityCollection<HealthPlanCallQueueCriteriaEntity>));
				_accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<AccountEntity>));
				_accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaCallQueueCustomer", typeof(EntityCollection<AccountEntity>));
				_activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCustomerProfile", typeof(EntityCollection<ActivityTypeEntity>));
				_activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCallQueueCustomer", typeof(EntityCollection<ActivityTypeEntity>));
				_addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerProfile", typeof(EntityCollection<AddressEntity>));
				_callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>)info.GetValue("_callQueueCriteriaCollectionViaCallQueueCustomer", typeof(EntityCollection<CallQueueCriteriaEntity>));
				_campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaCallQueueCustomer", typeof(EntityCollection<CampaignEntity>));
				_campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>)info.GetValue("_campaignCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<CampaignEntity>));
				_customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCallQueueCustomer", typeof(EntityCollection<CustomerProfileEntity>));
				_eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>)info.GetValue("_eventCustomersCollectionViaCallQueueCustomer", typeof(EntityCollection<EventCustomersEntity>));
				_eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaCallQueueCustomer", typeof(EntityCollection<EventsEntity>));
				_labCollectionViaCustomerProfile = (EntityCollection<LabEntity>)info.GetValue("_labCollectionViaCustomerProfile", typeof(EntityCollection<LabEntity>));
				_lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCallQueueCustomer", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile__", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCallQueueCustomer", typeof(EntityCollection<NotesDetailsEntity>));
				_notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCustomerProfile", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCallQueueCustomer", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>)info.GetValue("_prospectCustomerCollectionViaCallQueueCustomer", typeof(EntityCollection<ProspectCustomerEntity>));
				_roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaCustomerProfile", typeof(EntityCollection<RoleEntity>));
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
			switch((LanguageFieldIndex)fieldIndex)
			{
				case LanguageFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser(true, false);
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
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)entity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)entity);
					break;
				case "HealthPlanCallQueueCriteria":
					this.HealthPlanCallQueueCriteria.Add((HealthPlanCallQueueCriteriaEntity)entity);
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
				case "CallQueueCollectionViaHealthPlanCallQueueCriteria":
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
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
				case "CampaignCollectionViaHealthPlanCallQueueCriteria":
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.Add((CampaignEntity)entity);
					this.CampaignCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
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
				case "LabCollectionViaCustomerProfile":
					this.LabCollectionViaCustomerProfile.IsReadOnly = false;
					this.LabCollectionViaCustomerProfile.Add((LabEntity)entity);
					this.LabCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_":
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_____":
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile_______":
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile________":
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile________.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile___":
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile___.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile___.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile":
					this.LookupCollectionViaCustomerProfile.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile____":
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile__":
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile__.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile__.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.NotesDetailsCollectionViaCallQueueCustomer.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCallQueueCustomer.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = false;
					this.NotesDetailsCollectionViaCustomerProfile.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCallQueueCustomer.IsReadOnly = true;
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

				default:
					break;
			}
		}
		
		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public override RelationCollection GetRelationsForFieldOfType(string fieldName)
		{
			return LanguageEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationRoleUser":
					toReturn.Add(LanguageEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "CallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId);
					break;
				case "CustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId);
					break;
				case "HealthPlanCallQueueCriteria":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId);
					break;
				case "AccountCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId, "LanguageEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "AccountCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.AccountEntityUsingHealthPlanId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.ActivityTypeEntityUsingActivityId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ActivityTypeEntityUsingActivityId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.AddressEntityUsingBillingAddressId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId, "LanguageEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueEntityUsingCallQueueId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCriteriaCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CallQueueCriteriaEntityUsingCallQueueCriteriaId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CampaignEntityUsingCampaignId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "CampaignCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId, "LanguageEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.CustomerProfileEntityUsingCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventCustomersCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventCustomersEntityUsingEventCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.EventsEntityUsingEventId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LabCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LabEntityUsingLabId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_____":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneOfficeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile______":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPreferredContactType, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_______":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactReasonId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile________":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingProductTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile___":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneCellConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile____":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneHomeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile__":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingMemberUploadSourceId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.NotesDetailsEntityUsingNotesId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.NotesDetailsEntityUsingDoNotContactReasonNotesId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId, "LanguageEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer__":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria":
					toReturn.Add(LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId, "LanguageEntity__", "HealthPlanCallQueueCriteria_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "HealthPlanCallQueueCriteria_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer_":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "ProspectCustomerCollectionViaCallQueueCustomer":
					toReturn.Add(LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId, "LanguageEntity__", "CallQueueCustomer_", JoinHint.None);
					toReturn.Add(CallQueueCustomerEntity.Relations.ProspectCustomerEntityUsingProspectCustomerId, "CallQueueCustomer_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaCustomerProfile":
					toReturn.Add(LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId, "LanguageEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.RoleEntityUsingAddedByRoleId, "CustomerProfile_", string.Empty, JoinHint.None);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "CallQueueCustomer":
					this.CallQueueCustomer.Add((CallQueueCustomerEntity)relatedEntity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "CallQueueCustomer":
					base.PerformRelatedEntityRemoval(this.CallQueueCustomer, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerProfile":
					base.PerformRelatedEntityRemoval(this.CustomerProfile, relatedEntity, signalRelatedEntityManyToOne);
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
				info.AddValue("_customerProfile", ((_customerProfile!=null) && (_customerProfile.Count>0) && !this.MarkedForDeletion)?_customerProfile:null);
				info.AddValue("_healthPlanCallQueueCriteria", ((_healthPlanCallQueueCriteria!=null) && (_healthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaHealthPlanCallQueueCriteria", ((_accountCollectionViaHealthPlanCallQueueCriteria!=null) && (_accountCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_accountCollectionViaCallQueueCustomer", ((_accountCollectionViaCallQueueCustomer!=null) && (_accountCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaCallQueueCustomer:null);
				info.AddValue("_activityTypeCollectionViaCustomerProfile", ((_activityTypeCollectionViaCustomerProfile!=null) && (_activityTypeCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCustomerProfile:null);
				info.AddValue("_activityTypeCollectionViaCallQueueCustomer", ((_activityTypeCollectionViaCallQueueCustomer!=null) && (_activityTypeCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCallQueueCustomer:null);
				info.AddValue("_addressCollectionViaCustomerProfile", ((_addressCollectionViaCustomerProfile!=null) && (_addressCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerProfile:null);
				info.AddValue("_callQueueCollectionViaHealthPlanCallQueueCriteria", ((_callQueueCollectionViaHealthPlanCallQueueCriteria!=null) && (_callQueueCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_callQueueCollectionViaCallQueueCustomer", ((_callQueueCollectionViaCallQueueCustomer!=null) && (_callQueueCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaCallQueueCustomer:null);
				info.AddValue("_callQueueCriteriaCollectionViaCallQueueCustomer", ((_callQueueCriteriaCollectionViaCallQueueCustomer!=null) && (_callQueueCriteriaCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_callQueueCriteriaCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaCallQueueCustomer", ((_campaignCollectionViaCallQueueCustomer!=null) && (_campaignCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaCallQueueCustomer:null);
				info.AddValue("_campaignCollectionViaHealthPlanCallQueueCriteria", ((_campaignCollectionViaHealthPlanCallQueueCriteria!=null) && (_campaignCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_campaignCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_customerProfileCollectionViaCallQueueCustomer", ((_customerProfileCollectionViaCallQueueCustomer!=null) && (_customerProfileCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventCustomersCollectionViaCallQueueCustomer", ((_eventCustomersCollectionViaCallQueueCustomer!=null) && (_eventCustomersCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventCustomersCollectionViaCallQueueCustomer:null);
				info.AddValue("_eventsCollectionViaCallQueueCustomer", ((_eventsCollectionViaCallQueueCustomer!=null) && (_eventsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaCallQueueCustomer:null);
				info.AddValue("_labCollectionViaCustomerProfile", ((_labCollectionViaCustomerProfile!=null) && (_labCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_labCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_", ((_lookupCollectionViaCustomerProfile_!=null) && (_lookupCollectionViaCustomerProfile_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_____", ((_lookupCollectionViaCustomerProfile_____!=null) && (_lookupCollectionViaCustomerProfile_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile______", ((_lookupCollectionViaCustomerProfile______!=null) && (_lookupCollectionViaCustomerProfile______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile______:null);
				info.AddValue("_lookupCollectionViaCallQueueCustomer", ((_lookupCollectionViaCallQueueCustomer!=null) && (_lookupCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCallQueueCustomer:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_______", ((_lookupCollectionViaCustomerProfile_______!=null) && (_lookupCollectionViaCustomerProfile_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile________", ((_lookupCollectionViaCustomerProfile________!=null) && (_lookupCollectionViaCustomerProfile________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile________:null);
				info.AddValue("_lookupCollectionViaCustomerProfile___", ((_lookupCollectionViaCustomerProfile___!=null) && (_lookupCollectionViaCustomerProfile___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile___:null);
				info.AddValue("_lookupCollectionViaCustomerProfile", ((_lookupCollectionViaCustomerProfile!=null) && (_lookupCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile____", ((_lookupCollectionViaCustomerProfile____!=null) && (_lookupCollectionViaCustomerProfile____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile__", ((_lookupCollectionViaCustomerProfile__!=null) && (_lookupCollectionViaCustomerProfile__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile__:null);
				info.AddValue("_notesDetailsCollectionViaCallQueueCustomer", ((_notesDetailsCollectionViaCallQueueCustomer!=null) && (_notesDetailsCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCallQueueCustomer:null);
				info.AddValue("_notesDetailsCollectionViaCustomerProfile", ((_notesDetailsCollectionViaCustomerProfile!=null) && (_notesDetailsCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCustomerProfile:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer__", ((_organizationRoleUserCollectionViaCallQueueCustomer__!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer__:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria", ((_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null) && (_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer_", ((_organizationRoleUserCollectionViaCallQueueCustomer_!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer_:null);
				info.AddValue("_organizationRoleUserCollectionViaCallQueueCustomer", ((_organizationRoleUserCollectionViaCallQueueCustomer!=null) && (_organizationRoleUserCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCallQueueCustomer:null);
				info.AddValue("_prospectCustomerCollectionViaCallQueueCustomer", ((_prospectCustomerCollectionViaCallQueueCustomer!=null) && (_prospectCustomerCollectionViaCallQueueCustomer.Count>0) && !this.MarkedForDeletion)?_prospectCustomerCollectionViaCallQueueCustomer:null);
				info.AddValue("_roleCollectionViaCustomerProfile", ((_roleCollectionViaCustomerProfile!=null) && (_roleCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaCustomerProfile:null);
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
		public bool TestOriginalFieldValueForNull(LanguageFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(LanguageFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new LanguageRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueCustomerFields.LanguageId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.LanguageId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.LanguageId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCriteria' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCriteriaCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCriteriaCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Campaign' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventCustomers' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventCustomersCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventCustomersCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lab' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLabCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LabCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCustomerCollectionViaCallQueueCustomer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectCustomerCollectionViaCallQueueCustomer"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.Id, "LanguageEntity__"));
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

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.LanguageEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callQueueCustomer);
			collectionsQueue.Enqueue(this._customerProfile);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._accountCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._callQueueCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._callQueueCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._callQueueCriteriaCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._campaignCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventCustomersCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._eventsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._labCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile________);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile___);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile__);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._prospectCustomerCollectionViaCallQueueCustomer);
			collectionsQueue.Enqueue(this._roleCollectionViaCustomerProfile);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callQueueCustomer = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._customerProfile = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteria = (EntityCollection<HealthPlanCallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaCallQueueCustomer = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCallQueueCustomer = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaCallQueueCustomer = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCriteriaCollectionViaCallQueueCustomer = (EntityCollection<CallQueueCriteriaEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaCallQueueCustomer = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._campaignCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<CampaignEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCallQueueCustomer = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventCustomersCollectionViaCallQueueCustomer = (EntityCollection<EventCustomersEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaCallQueueCustomer = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._labCollectionViaCustomerProfile = (EntityCollection<LabEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCallQueueCustomer = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCallQueueCustomer = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCallQueueCustomer = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._prospectCustomerCollectionViaCallQueueCustomer = (EntityCollection<ProspectCustomerEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
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
			if (this._healthPlanCallQueueCriteria != null)
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
			if (this._callQueueCollectionViaHealthPlanCallQueueCriteria != null)
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
			if (this._campaignCollectionViaHealthPlanCallQueueCriteria != null)
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
			if (this._labCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_____ != null)
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
			if (this._lookupCollectionViaCustomerProfile_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile___ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile__ != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCallQueueCustomer != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCallQueueCriteria != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCallQueueCustomer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("CallQueueCustomer", _callQueueCustomer);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("HealthPlanCallQueueCriteria", _healthPlanCallQueueCriteria);
			toReturn.Add("AccountCollectionViaHealthPlanCallQueueCriteria", _accountCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("AccountCollectionViaCallQueueCustomer", _accountCollectionViaCallQueueCustomer);
			toReturn.Add("ActivityTypeCollectionViaCustomerProfile", _activityTypeCollectionViaCustomerProfile);
			toReturn.Add("ActivityTypeCollectionViaCallQueueCustomer", _activityTypeCollectionViaCallQueueCustomer);
			toReturn.Add("AddressCollectionViaCustomerProfile", _addressCollectionViaCustomerProfile);
			toReturn.Add("CallQueueCollectionViaHealthPlanCallQueueCriteria", _callQueueCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CallQueueCollectionViaCallQueueCustomer", _callQueueCollectionViaCallQueueCustomer);
			toReturn.Add("CallQueueCriteriaCollectionViaCallQueueCustomer", _callQueueCriteriaCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaCallQueueCustomer", _campaignCollectionViaCallQueueCustomer);
			toReturn.Add("CampaignCollectionViaHealthPlanCallQueueCriteria", _campaignCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("CustomerProfileCollectionViaCallQueueCustomer", _customerProfileCollectionViaCallQueueCustomer);
			toReturn.Add("EventCustomersCollectionViaCallQueueCustomer", _eventCustomersCollectionViaCallQueueCustomer);
			toReturn.Add("EventsCollectionViaCallQueueCustomer", _eventsCollectionViaCallQueueCustomer);
			toReturn.Add("LabCollectionViaCustomerProfile", _labCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile_", _lookupCollectionViaCustomerProfile_);
			toReturn.Add("LookupCollectionViaCustomerProfile_____", _lookupCollectionViaCustomerProfile_____);
			toReturn.Add("LookupCollectionViaCustomerProfile______", _lookupCollectionViaCustomerProfile______);
			toReturn.Add("LookupCollectionViaCallQueueCustomer", _lookupCollectionViaCallQueueCustomer);
			toReturn.Add("LookupCollectionViaCustomerProfile_______", _lookupCollectionViaCustomerProfile_______);
			toReturn.Add("LookupCollectionViaCustomerProfile________", _lookupCollectionViaCustomerProfile________);
			toReturn.Add("LookupCollectionViaCustomerProfile___", _lookupCollectionViaCustomerProfile___);
			toReturn.Add("LookupCollectionViaCustomerProfile", _lookupCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile____", _lookupCollectionViaCustomerProfile____);
			toReturn.Add("LookupCollectionViaCustomerProfile__", _lookupCollectionViaCustomerProfile__);
			toReturn.Add("NotesDetailsCollectionViaCallQueueCustomer", _notesDetailsCollectionViaCallQueueCustomer);
			toReturn.Add("NotesDetailsCollectionViaCustomerProfile", _notesDetailsCollectionViaCustomerProfile);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer__", _organizationRoleUserCollectionViaCallQueueCustomer__);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", _organizationRoleUserCollectionViaHealthPlanCallQueueCriteria);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer_", _organizationRoleUserCollectionViaCallQueueCustomer_);
			toReturn.Add("OrganizationRoleUserCollectionViaCallQueueCustomer", _organizationRoleUserCollectionViaCallQueueCustomer);
			toReturn.Add("ProspectCustomerCollectionViaCallQueueCustomer", _prospectCustomerCollectionViaCallQueueCustomer);
			toReturn.Add("RoleCollectionViaCustomerProfile", _roleCollectionViaCustomerProfile);

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
			if(_healthPlanCallQueueCriteria!=null)
			{
				_healthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_accountCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
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
			if(_callQueueCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_callQueueCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
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
			if(_campaignCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_campaignCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
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
			if(_labCollectionViaCustomerProfile!=null)
			{
				_labCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_!=null)
			{
				_lookupCollectionViaCustomerProfile_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_____!=null)
			{
				_lookupCollectionViaCustomerProfile_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile______!=null)
			{
				_lookupCollectionViaCustomerProfile______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCallQueueCustomer!=null)
			{
				_lookupCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_______!=null)
			{
				_lookupCollectionViaCustomerProfile_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile________!=null)
			{
				_lookupCollectionViaCustomerProfile________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile___!=null)
			{
				_lookupCollectionViaCustomerProfile___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile!=null)
			{
				_lookupCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile____!=null)
			{
				_lookupCollectionViaCustomerProfile____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile__!=null)
			{
				_lookupCollectionViaCustomerProfile__.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCallQueueCustomer!=null)
			{
				_notesDetailsCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCustomerProfile!=null)
			{
				_notesDetailsCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer__!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer_!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCallQueueCustomer!=null)
			{
				_organizationRoleUserCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_prospectCustomerCollectionViaCallQueueCustomer!=null)
			{
				_prospectCustomerCollectionViaCallQueueCustomer.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaCustomerProfile!=null)
			{
				_roleCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
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
			_customerProfile = null;
			_healthPlanCallQueueCriteria = null;
			_accountCollectionViaHealthPlanCallQueueCriteria = null;
			_accountCollectionViaCallQueueCustomer = null;
			_activityTypeCollectionViaCustomerProfile = null;
			_activityTypeCollectionViaCallQueueCustomer = null;
			_addressCollectionViaCustomerProfile = null;
			_callQueueCollectionViaHealthPlanCallQueueCriteria = null;
			_callQueueCollectionViaCallQueueCustomer = null;
			_callQueueCriteriaCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaCallQueueCustomer = null;
			_campaignCollectionViaHealthPlanCallQueueCriteria = null;
			_customerProfileCollectionViaCallQueueCustomer = null;
			_eventCustomersCollectionViaCallQueueCustomer = null;
			_eventsCollectionViaCallQueueCustomer = null;
			_labCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile_ = null;
			_lookupCollectionViaCustomerProfile_____ = null;
			_lookupCollectionViaCustomerProfile______ = null;
			_lookupCollectionViaCallQueueCustomer = null;
			_lookupCollectionViaCustomerProfile_______ = null;
			_lookupCollectionViaCustomerProfile________ = null;
			_lookupCollectionViaCustomerProfile___ = null;
			_lookupCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile____ = null;
			_lookupCollectionViaCustomerProfile__ = null;
			_notesDetailsCollectionViaCallQueueCustomer = null;
			_notesDetailsCollectionViaCustomerProfile = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria_ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer__ = null;
			_organizationRoleUserCollectionViaHealthPlanCallQueueCriteria = null;
			_organizationRoleUserCollectionViaCallQueueCustomer_ = null;
			_organizationRoleUserCollectionViaCallQueueCustomer = null;
			_prospectCustomerCollectionViaCallQueueCustomer = null;
			_roleCollectionViaCustomerProfile = null;
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

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", LanguageEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "Language", resetFKFields, new int[] { (int)LanguageFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", LanguageEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this LanguageEntity</param>
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
		public  static LanguageRelations Relations
		{
			get	{ return new LanguageRelations(); }
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
					(IEntityRelation)GetRelationsForField("CallQueueCustomer")[0], (int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, null, null, "CallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteria")[0], (int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaHealthPlanCallQueueCriteria"), null, "AccountCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaCallQueueCustomer"), null, "AccountCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCustomerProfile"), null, "ActivityTypeCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCallQueueCustomer"), null, "ActivityTypeCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerProfile"), null, "AddressCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaHealthPlanCallQueueCriteria"), null, "CallQueueCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaCallQueueCustomer"), null, "CallQueueCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCriteria' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCriteriaCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCriteriaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCriteriaEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CallQueueCriteriaEntity, 0, null, null, GetRelationsForField("CallQueueCriteriaCollectionViaCallQueueCustomer"), null, "CallQueueCriteriaCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaCallQueueCustomer"), null, "CampaignCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Campaign' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<CampaignEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, GetRelationsForField("CampaignCollectionViaHealthPlanCallQueueCriteria"), null, "CampaignCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCallQueueCustomer"), null, "CustomerProfileCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventCustomers' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventCustomersCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventCustomersEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventCustomersEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.EventCustomersEntity, 0, null, null, GetRelationsForField("EventCustomersCollectionViaCallQueueCustomer"), null, "EventCustomersCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaCallQueueCustomer"), null, "EventsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLabCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LabEntity, 0, null, null, GetRelationsForField("LabCollectionViaCustomerProfile"), null, "LabCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_"), null, "LookupCollectionViaCustomerProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_____
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_____"), null, "LookupCollectionViaCustomerProfile_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile______
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile______"), null, "LookupCollectionViaCustomerProfile______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCallQueueCustomer"), null, "LookupCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_______
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_______"), null, "LookupCollectionViaCustomerProfile_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile________
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile________"), null, "LookupCollectionViaCustomerProfile________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile___
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile___"), null, "LookupCollectionViaCustomerProfile___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile"), null, "LookupCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile____
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile____"), null, "LookupCollectionViaCustomerProfile____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile__
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile__"), null, "LookupCollectionViaCustomerProfile__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCallQueueCustomer"), null, "NotesDetailsCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCustomerProfile"), null, "NotesDetailsCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer__
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer__"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.HealthPlanCallQueueCriteriaEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteria_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria"), null, "OrganizationRoleUserCollectionViaHealthPlanCallQueueCriteria", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer_
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer_"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCallQueueCustomer"), null, "OrganizationRoleUserCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCustomerCollectionViaCallQueueCustomer
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CallQueueCustomerEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CallQueueCustomer_");
				return new PrefetchPathElement2(new EntityCollection<ProspectCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.ProspectCustomerEntity, 0, null, null, GetRelationsForField("ProspectCustomerCollectionViaCallQueueCustomer"), null, "ProspectCustomerCollectionViaCallQueueCustomer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = LanguageEntity.Relations.CustomerProfileEntityUsingLanguageId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaCustomerProfile"), null, "RoleCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.LanguageEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return LanguageEntity.CustomProperties;}
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
			get { return LanguageEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)LanguageFieldIndex.Id, true); }
			set	{ SetValue((int)LanguageFieldIndex.Id, value); }
		}

		/// <summary> The Name property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)LanguageFieldIndex.Name, true); }
			set	{ SetValue((int)LanguageFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)LanguageFieldIndex.Alias, true); }
			set	{ SetValue((int)LanguageFieldIndex.Alias, value); }
		}

		/// <summary> The DateCreated property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)LanguageFieldIndex.DateCreated, true); }
			set	{ SetValue((int)LanguageFieldIndex.DateCreated, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)LanguageFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)LanguageFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The IsActive property of the Entity Language<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblLanguage"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)LanguageFieldIndex.IsActive, true); }
			set	{ SetValue((int)LanguageFieldIndex.IsActive, value); }
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
					_callQueueCustomer.SetContainingEntityInfo(this, "Language");
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
					_customerProfile.SetContainingEntityInfo(this, "Language");
				}
				return _customerProfile;
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
					_healthPlanCallQueueCriteria.SetContainingEntityInfo(this, "Language");
				}
				return _healthPlanCallQueueCriteria;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'NotesDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NotesDetailsEntity))]
		public virtual EntityCollection<NotesDetailsEntity> NotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				if(_notesDetailsCollectionViaCustomerProfile==null)
				{
					_notesDetailsCollectionViaCustomerProfile = new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory)));
					_notesDetailsCollectionViaCustomerProfile.IsReadOnly=true;
				}
				return _notesDetailsCollectionViaCustomerProfile;
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Language");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Language");
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
			get { return (int)Falcon.Data.EntityType.LanguageEntity; }
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
