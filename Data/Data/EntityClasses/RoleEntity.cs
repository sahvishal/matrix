///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:46
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
	/// Entity class which represents the entity 'Role'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class RoleEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ContactsEntity> _contacts_;
		private EntityCollection<ContactsEntity> _contacts;
		private EntityCollection<CustomerProfileEntity> _customerProfile;
		private EntityCollection<HostFacilityRankingEntity> _hostFacilityRanking;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUser;
		private EntityCollection<RoleEntity> _role_;
		private EntityCollection<RoleAccessControlObjectEntity> _roleAccessControlObject;
		private EntityCollection<RolePermisibleAccessControlObjectEntity> _rolePermisibleAccessControlObject;
		private EntityCollection<RoleScopeOptionEntity> _roleScopeOption;
		private EntityCollection<UserEntity> _user;
		private EntityCollection<AccessControlObjectEntity> _accessControlObjectCollectionViaRolePermisibleAccessControlObject;
		private EntityCollection<AccessControlObjectEntity> _accessControlObjectCollectionViaRoleAccessControlObject;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCustomerProfile;
		private EntityCollection<AddressEntity> _addressCollectionViaCustomerProfile;
		private EntityCollection<AddressEntity> _addressCollectionViaUser;
		private EntityCollection<ContactTypeEntity> _contactTypeCollectionViaContacts;
		private EntityCollection<ContactTypeEntity> _contactTypeCollectionViaContacts_;
		private EntityCollection<LabEntity> _labCollectionViaCustomerProfile;
		private EntityCollection<LanguageEntity> _languageCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaRoleScopeOption;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostFacilityRanking_;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostFacilityRanking;
		private EntityCollection<LookupEntity> _lookupCollectionViaRoleAccessControlObject_;
		private EntityCollection<LookupEntity> _lookupCollectionViaRoleAccessControlObject;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile___;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile__;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile________;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile______;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCustomerProfile;
		private EntityCollection<OrganizationEntity> _organizationCollectionViaOrganizationRoleUser;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHostFacilityRanking;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaUser;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaUser_;
		private EntityCollection<OrganizationTypeEntity> _organizationTypeCollectionViaRole;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaHostFacilityRanking;
		private EntityCollection<UserEntity> _userCollectionViaOrganizationRoleUser;
		private OrganizationTypeEntity _organizationType;
		private RoleEntity _role;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name OrganizationType</summary>
			public static readonly string OrganizationType = "OrganizationType";
			/// <summary>Member name Role</summary>
			public static readonly string Role = "Role";
			/// <summary>Member name Contacts_</summary>
			public static readonly string Contacts_ = "Contacts_";
			/// <summary>Member name Contacts</summary>
			public static readonly string Contacts = "Contacts";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name HostFacilityRanking</summary>
			public static readonly string HostFacilityRanking = "HostFacilityRanking";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name Role_</summary>
			public static readonly string Role_ = "Role_";
			/// <summary>Member name RoleAccessControlObject</summary>
			public static readonly string RoleAccessControlObject = "RoleAccessControlObject";
			/// <summary>Member name RolePermisibleAccessControlObject</summary>
			public static readonly string RolePermisibleAccessControlObject = "RolePermisibleAccessControlObject";
			/// <summary>Member name RoleScopeOption</summary>
			public static readonly string RoleScopeOption = "RoleScopeOption";
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name AccessControlObjectCollectionViaRolePermisibleAccessControlObject</summary>
			public static readonly string AccessControlObjectCollectionViaRolePermisibleAccessControlObject = "AccessControlObjectCollectionViaRolePermisibleAccessControlObject";
			/// <summary>Member name AccessControlObjectCollectionViaRoleAccessControlObject</summary>
			public static readonly string AccessControlObjectCollectionViaRoleAccessControlObject = "AccessControlObjectCollectionViaRoleAccessControlObject";
			/// <summary>Member name ActivityTypeCollectionViaCustomerProfile</summary>
			public static readonly string ActivityTypeCollectionViaCustomerProfile = "ActivityTypeCollectionViaCustomerProfile";
			/// <summary>Member name AddressCollectionViaCustomerProfile</summary>
			public static readonly string AddressCollectionViaCustomerProfile = "AddressCollectionViaCustomerProfile";
			/// <summary>Member name AddressCollectionViaUser</summary>
			public static readonly string AddressCollectionViaUser = "AddressCollectionViaUser";
			/// <summary>Member name ContactTypeCollectionViaContacts</summary>
			public static readonly string ContactTypeCollectionViaContacts = "ContactTypeCollectionViaContacts";
			/// <summary>Member name ContactTypeCollectionViaContacts_</summary>
			public static readonly string ContactTypeCollectionViaContacts_ = "ContactTypeCollectionViaContacts_";
			/// <summary>Member name LabCollectionViaCustomerProfile</summary>
			public static readonly string LabCollectionViaCustomerProfile = "LabCollectionViaCustomerProfile";
			/// <summary>Member name LanguageCollectionViaCustomerProfile</summary>
			public static readonly string LanguageCollectionViaCustomerProfile = "LanguageCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaRoleScopeOption</summary>
			public static readonly string LookupCollectionViaRoleScopeOption = "LookupCollectionViaRoleScopeOption";
			/// <summary>Member name LookupCollectionViaHostFacilityRanking_</summary>
			public static readonly string LookupCollectionViaHostFacilityRanking_ = "LookupCollectionViaHostFacilityRanking_";
			/// <summary>Member name LookupCollectionViaHostFacilityRanking</summary>
			public static readonly string LookupCollectionViaHostFacilityRanking = "LookupCollectionViaHostFacilityRanking";
			/// <summary>Member name LookupCollectionViaRoleAccessControlObject_</summary>
			public static readonly string LookupCollectionViaRoleAccessControlObject_ = "LookupCollectionViaRoleAccessControlObject_";
			/// <summary>Member name LookupCollectionViaRoleAccessControlObject</summary>
			public static readonly string LookupCollectionViaRoleAccessControlObject = "LookupCollectionViaRoleAccessControlObject";
			/// <summary>Member name LookupCollectionViaCustomerProfile_____</summary>
			public static readonly string LookupCollectionViaCustomerProfile_____ = "LookupCollectionViaCustomerProfile_____";
			/// <summary>Member name LookupCollectionViaCustomerProfile</summary>
			public static readonly string LookupCollectionViaCustomerProfile = "LookupCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile___</summary>
			public static readonly string LookupCollectionViaCustomerProfile___ = "LookupCollectionViaCustomerProfile___";
			/// <summary>Member name LookupCollectionViaCustomerProfile__</summary>
			public static readonly string LookupCollectionViaCustomerProfile__ = "LookupCollectionViaCustomerProfile__";
			/// <summary>Member name LookupCollectionViaCustomerProfile_</summary>
			public static readonly string LookupCollectionViaCustomerProfile_ = "LookupCollectionViaCustomerProfile_";
			/// <summary>Member name LookupCollectionViaCustomerProfile____</summary>
			public static readonly string LookupCollectionViaCustomerProfile____ = "LookupCollectionViaCustomerProfile____";
			/// <summary>Member name LookupCollectionViaCustomerProfile_______</summary>
			public static readonly string LookupCollectionViaCustomerProfile_______ = "LookupCollectionViaCustomerProfile_______";
			/// <summary>Member name LookupCollectionViaCustomerProfile________</summary>
			public static readonly string LookupCollectionViaCustomerProfile________ = "LookupCollectionViaCustomerProfile________";
			/// <summary>Member name LookupCollectionViaCustomerProfile______</summary>
			public static readonly string LookupCollectionViaCustomerProfile______ = "LookupCollectionViaCustomerProfile______";
			/// <summary>Member name NotesDetailsCollectionViaCustomerProfile</summary>
			public static readonly string NotesDetailsCollectionViaCustomerProfile = "NotesDetailsCollectionViaCustomerProfile";
			/// <summary>Member name OrganizationCollectionViaOrganizationRoleUser</summary>
			public static readonly string OrganizationCollectionViaOrganizationRoleUser = "OrganizationCollectionViaOrganizationRoleUser";
			/// <summary>Member name OrganizationRoleUserCollectionViaHostFacilityRanking</summary>
			public static readonly string OrganizationRoleUserCollectionViaHostFacilityRanking = "OrganizationRoleUserCollectionViaHostFacilityRanking";
			/// <summary>Member name OrganizationRoleUserCollectionViaUser</summary>
			public static readonly string OrganizationRoleUserCollectionViaUser = "OrganizationRoleUserCollectionViaUser";
			/// <summary>Member name OrganizationRoleUserCollectionViaUser_</summary>
			public static readonly string OrganizationRoleUserCollectionViaUser_ = "OrganizationRoleUserCollectionViaUser_";
			/// <summary>Member name OrganizationTypeCollectionViaRole</summary>
			public static readonly string OrganizationTypeCollectionViaRole = "OrganizationTypeCollectionViaRole";
			/// <summary>Member name ProspectsCollectionViaHostFacilityRanking</summary>
			public static readonly string ProspectsCollectionViaHostFacilityRanking = "ProspectsCollectionViaHostFacilityRanking";
			/// <summary>Member name UserCollectionViaOrganizationRoleUser</summary>
			public static readonly string UserCollectionViaOrganizationRoleUser = "UserCollectionViaOrganizationRoleUser";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static RoleEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public RoleEntity():base("RoleEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public RoleEntity(IEntityFields2 fields):base("RoleEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		public RoleEntity(IValidator validator):base("RoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="roleId">PK value for Role which data should be fetched into this Role object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RoleEntity(System.Int64 roleId):base("RoleEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.RoleId = roleId;
		}

		/// <summary> CTor</summary>
		/// <param name="roleId">PK value for Role which data should be fetched into this Role object</param>
		/// <param name="validator">The custom validator object for this RoleEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public RoleEntity(System.Int64 roleId, IValidator validator):base("RoleEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.RoleId = roleId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected RoleEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_contacts_ = (EntityCollection<ContactsEntity>)info.GetValue("_contacts_", typeof(EntityCollection<ContactsEntity>));
				_contacts = (EntityCollection<ContactsEntity>)info.GetValue("_contacts", typeof(EntityCollection<ContactsEntity>));
				_customerProfile = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfile", typeof(EntityCollection<CustomerProfileEntity>));
				_hostFacilityRanking = (EntityCollection<HostFacilityRankingEntity>)info.GetValue("_hostFacilityRanking", typeof(EntityCollection<HostFacilityRankingEntity>));
				_organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUser", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_role_ = (EntityCollection<RoleEntity>)info.GetValue("_role_", typeof(EntityCollection<RoleEntity>));
				_roleAccessControlObject = (EntityCollection<RoleAccessControlObjectEntity>)info.GetValue("_roleAccessControlObject", typeof(EntityCollection<RoleAccessControlObjectEntity>));
				_rolePermisibleAccessControlObject = (EntityCollection<RolePermisibleAccessControlObjectEntity>)info.GetValue("_rolePermisibleAccessControlObject", typeof(EntityCollection<RolePermisibleAccessControlObjectEntity>));
				_roleScopeOption = (EntityCollection<RoleScopeOptionEntity>)info.GetValue("_roleScopeOption", typeof(EntityCollection<RoleScopeOptionEntity>));
				_user = (EntityCollection<UserEntity>)info.GetValue("_user", typeof(EntityCollection<UserEntity>));
				_accessControlObjectCollectionViaRolePermisibleAccessControlObject = (EntityCollection<AccessControlObjectEntity>)info.GetValue("_accessControlObjectCollectionViaRolePermisibleAccessControlObject", typeof(EntityCollection<AccessControlObjectEntity>));
				_accessControlObjectCollectionViaRoleAccessControlObject = (EntityCollection<AccessControlObjectEntity>)info.GetValue("_accessControlObjectCollectionViaRoleAccessControlObject", typeof(EntityCollection<AccessControlObjectEntity>));
				_activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCustomerProfile", typeof(EntityCollection<ActivityTypeEntity>));
				_addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaCustomerProfile", typeof(EntityCollection<AddressEntity>));
				_addressCollectionViaUser = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaUser", typeof(EntityCollection<AddressEntity>));
				_contactTypeCollectionViaContacts = (EntityCollection<ContactTypeEntity>)info.GetValue("_contactTypeCollectionViaContacts", typeof(EntityCollection<ContactTypeEntity>));
				_contactTypeCollectionViaContacts_ = (EntityCollection<ContactTypeEntity>)info.GetValue("_contactTypeCollectionViaContacts_", typeof(EntityCollection<ContactTypeEntity>));
				_labCollectionViaCustomerProfile = (EntityCollection<LabEntity>)info.GetValue("_labCollectionViaCustomerProfile", typeof(EntityCollection<LabEntity>));
				_languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCustomerProfile", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaRoleScopeOption = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRoleScopeOption", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostFacilityRanking_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostFacilityRanking_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostFacilityRanking = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostFacilityRanking", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaRoleAccessControlObject_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRoleAccessControlObject_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaRoleAccessControlObject = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaRoleAccessControlObject", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile______", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCustomerProfile", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationCollectionViaOrganizationRoleUser = (EntityCollection<OrganizationEntity>)info.GetValue("_organizationCollectionViaOrganizationRoleUser", typeof(EntityCollection<OrganizationEntity>));
				_organizationRoleUserCollectionViaHostFacilityRanking = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHostFacilityRanking", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaUser = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaUser", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaUser_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaUser_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationTypeCollectionViaRole = (EntityCollection<OrganizationTypeEntity>)info.GetValue("_organizationTypeCollectionViaRole", typeof(EntityCollection<OrganizationTypeEntity>));
				_prospectsCollectionViaHostFacilityRanking = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaHostFacilityRanking", typeof(EntityCollection<ProspectsEntity>));
				_userCollectionViaOrganizationRoleUser = (EntityCollection<UserEntity>)info.GetValue("_userCollectionViaOrganizationRoleUser", typeof(EntityCollection<UserEntity>));
				_organizationType = (OrganizationTypeEntity)info.GetValue("_organizationType", typeof(OrganizationTypeEntity));
				if(_organizationType!=null)
				{
					_organizationType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_role = (RoleEntity)info.GetValue("_role", typeof(RoleEntity));
				if(_role!=null)
				{
					_role.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((RoleFieldIndex)fieldIndex)
			{
				case RoleFieldIndex.OrganizationTypeId:
					DesetupSyncOrganizationType(true, false);
					break;
				case RoleFieldIndex.ParentId:
					DesetupSyncRole(true, false);
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
				case "OrganizationType":
					this.OrganizationType = (OrganizationTypeEntity)entity;
					break;
				case "Role":
					this.Role = (RoleEntity)entity;
					break;
				case "Contacts_":
					this.Contacts_.Add((ContactsEntity)entity);
					break;
				case "Contacts":
					this.Contacts.Add((ContactsEntity)entity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)entity);
					break;
				case "HostFacilityRanking":
					this.HostFacilityRanking.Add((HostFacilityRankingEntity)entity);
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)entity);
					break;
				case "Role_":
					this.Role_.Add((RoleEntity)entity);
					break;
				case "RoleAccessControlObject":
					this.RoleAccessControlObject.Add((RoleAccessControlObjectEntity)entity);
					break;
				case "RolePermisibleAccessControlObject":
					this.RolePermisibleAccessControlObject.Add((RolePermisibleAccessControlObjectEntity)entity);
					break;
				case "RoleScopeOption":
					this.RoleScopeOption.Add((RoleScopeOptionEntity)entity);
					break;
				case "User":
					this.User.Add((UserEntity)entity);
					break;
				case "AccessControlObjectCollectionViaRolePermisibleAccessControlObject":
					this.AccessControlObjectCollectionViaRolePermisibleAccessControlObject.IsReadOnly = false;
					this.AccessControlObjectCollectionViaRolePermisibleAccessControlObject.Add((AccessControlObjectEntity)entity);
					this.AccessControlObjectCollectionViaRolePermisibleAccessControlObject.IsReadOnly = true;
					break;
				case "AccessControlObjectCollectionViaRoleAccessControlObject":
					this.AccessControlObjectCollectionViaRoleAccessControlObject.IsReadOnly = false;
					this.AccessControlObjectCollectionViaRoleAccessControlObject.Add((AccessControlObjectEntity)entity);
					this.AccessControlObjectCollectionViaRoleAccessControlObject.IsReadOnly = true;
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = false;
					this.ActivityTypeCollectionViaCustomerProfile.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "AddressCollectionViaCustomerProfile":
					this.AddressCollectionViaCustomerProfile.IsReadOnly = false;
					this.AddressCollectionViaCustomerProfile.Add((AddressEntity)entity);
					this.AddressCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "AddressCollectionViaUser":
					this.AddressCollectionViaUser.IsReadOnly = false;
					this.AddressCollectionViaUser.Add((AddressEntity)entity);
					this.AddressCollectionViaUser.IsReadOnly = true;
					break;
				case "ContactTypeCollectionViaContacts":
					this.ContactTypeCollectionViaContacts.IsReadOnly = false;
					this.ContactTypeCollectionViaContacts.Add((ContactTypeEntity)entity);
					this.ContactTypeCollectionViaContacts.IsReadOnly = true;
					break;
				case "ContactTypeCollectionViaContacts_":
					this.ContactTypeCollectionViaContacts_.IsReadOnly = false;
					this.ContactTypeCollectionViaContacts_.Add((ContactTypeEntity)entity);
					this.ContactTypeCollectionViaContacts_.IsReadOnly = true;
					break;
				case "LabCollectionViaCustomerProfile":
					this.LabCollectionViaCustomerProfile.IsReadOnly = false;
					this.LabCollectionViaCustomerProfile.Add((LabEntity)entity);
					this.LabCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LanguageCollectionViaCustomerProfile":
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = false;
					this.LanguageCollectionViaCustomerProfile.Add((LanguageEntity)entity);
					this.LanguageCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaRoleScopeOption":
					this.LookupCollectionViaRoleScopeOption.IsReadOnly = false;
					this.LookupCollectionViaRoleScopeOption.Add((LookupEntity)entity);
					this.LookupCollectionViaRoleScopeOption.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostFacilityRanking_":
					this.LookupCollectionViaHostFacilityRanking_.IsReadOnly = false;
					this.LookupCollectionViaHostFacilityRanking_.Add((LookupEntity)entity);
					this.LookupCollectionViaHostFacilityRanking_.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostFacilityRanking":
					this.LookupCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.LookupCollectionViaHostFacilityRanking.Add((LookupEntity)entity);
					this.LookupCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "LookupCollectionViaRoleAccessControlObject_":
					this.LookupCollectionViaRoleAccessControlObject_.IsReadOnly = false;
					this.LookupCollectionViaRoleAccessControlObject_.Add((LookupEntity)entity);
					this.LookupCollectionViaRoleAccessControlObject_.IsReadOnly = true;
					break;
				case "LookupCollectionViaRoleAccessControlObject":
					this.LookupCollectionViaRoleAccessControlObject.IsReadOnly = false;
					this.LookupCollectionViaRoleAccessControlObject.Add((LookupEntity)entity);
					this.LookupCollectionViaRoleAccessControlObject.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_____":
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_____.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile":
					this.LookupCollectionViaCustomerProfile.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile_":
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile____":
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile______":
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile______.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = false;
					this.NotesDetailsCollectionViaCustomerProfile.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "OrganizationCollectionViaOrganizationRoleUser":
					this.OrganizationCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.OrganizationCollectionViaOrganizationRoleUser.Add((OrganizationEntity)entity);
					this.OrganizationCollectionViaOrganizationRoleUser.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHostFacilityRanking":
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaUser":
					this.OrganizationRoleUserCollectionViaUser.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaUser.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaUser.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaUser_":
					this.OrganizationRoleUserCollectionViaUser_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaUser_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaUser_.IsReadOnly = true;
					break;
				case "OrganizationTypeCollectionViaRole":
					this.OrganizationTypeCollectionViaRole.IsReadOnly = false;
					this.OrganizationTypeCollectionViaRole.Add((OrganizationTypeEntity)entity);
					this.OrganizationTypeCollectionViaRole.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaHostFacilityRanking":
					this.ProspectsCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.ProspectsCollectionViaHostFacilityRanking.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "UserCollectionViaOrganizationRoleUser":
					this.UserCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.UserCollectionViaOrganizationRoleUser.Add((UserEntity)entity);
					this.UserCollectionViaOrganizationRoleUser.IsReadOnly = true;
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
			return RoleEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "OrganizationType":
					toReturn.Add(RoleEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId);
					break;
				case "Role":
					toReturn.Add(RoleEntity.Relations.RoleEntityUsingRoleIdParentId);
					break;
				case "Contacts_":
					toReturn.Add(RoleEntity.Relations.ContactsEntityUsingModifiedRoleId);
					break;
				case "Contacts":
					toReturn.Add(RoleEntity.Relations.ContactsEntityUsingAddedRoleId);
					break;
				case "CustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId);
					break;
				case "HostFacilityRanking":
					toReturn.Add(RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(RoleEntity.Relations.OrganizationRoleUserEntityUsingRoleId);
					break;
				case "Role_":
					toReturn.Add(RoleEntity.Relations.RoleEntityUsingParentId);
					break;
				case "RoleAccessControlObject":
					toReturn.Add(RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId);
					break;
				case "RolePermisibleAccessControlObject":
					toReturn.Add(RoleEntity.Relations.RolePermisibleAccessControlObjectEntityUsingRoleId);
					break;
				case "RoleScopeOption":
					toReturn.Add(RoleEntity.Relations.RoleScopeOptionEntityUsingRoleId);
					break;
				case "User":
					toReturn.Add(RoleEntity.Relations.UserEntityUsingDefaultRoleId);
					break;
				case "AccessControlObjectCollectionViaRolePermisibleAccessControlObject":
					toReturn.Add(RoleEntity.Relations.RolePermisibleAccessControlObjectEntityUsingRoleId, "RoleEntity__", "RolePermisibleAccessControlObject_", JoinHint.None);
					toReturn.Add(RolePermisibleAccessControlObjectEntity.Relations.AccessControlObjectEntityUsingAccessControlObjectId, "RolePermisibleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "AccessControlObjectCollectionViaRoleAccessControlObject":
					toReturn.Add(RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId, "RoleEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.AccessControlObjectEntityUsingAccessControlObjectId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.ActivityTypeEntityUsingActivityId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.AddressEntityUsingBillingAddressId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "AddressCollectionViaUser":
					toReturn.Add(RoleEntity.Relations.UserEntityUsingDefaultRoleId, "RoleEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.AddressEntityUsingHomeAddressId, "User_", string.Empty, JoinHint.None);
					break;
				case "ContactTypeCollectionViaContacts":
					toReturn.Add(RoleEntity.Relations.ContactsEntityUsingAddedRoleId, "RoleEntity__", "Contacts_", JoinHint.None);
					toReturn.Add(ContactsEntity.Relations.ContactTypeEntityUsingContactTypeId, "Contacts_", string.Empty, JoinHint.None);
					break;
				case "ContactTypeCollectionViaContacts_":
					toReturn.Add(RoleEntity.Relations.ContactsEntityUsingModifiedRoleId, "RoleEntity__", "Contacts_", JoinHint.None);
					toReturn.Add(ContactsEntity.Relations.ContactTypeEntityUsingContactTypeId, "Contacts_", string.Empty, JoinHint.None);
					break;
				case "LabCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LabEntityUsingLabId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LanguageEntityUsingLanguageId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaRoleScopeOption":
					toReturn.Add(RoleEntity.Relations.RoleScopeOptionEntityUsingRoleId, "RoleEntity__", "RoleScopeOption_", JoinHint.None);
					toReturn.Add(RoleScopeOptionEntity.Relations.LookupEntityUsingScopeId, "RoleScopeOption_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostFacilityRanking_":
					toReturn.Add(RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole, "RoleEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.LookupEntityUsingRanking, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostFacilityRanking":
					toReturn.Add(RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole, "RoleEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.LookupEntityUsingInternetAccess, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaRoleAccessControlObject_":
					toReturn.Add(RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId, "RoleEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.LookupEntityUsingScopeId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaRoleAccessControlObject":
					toReturn.Add(RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId, "RoleEntity__", "RoleAccessControlObject_", JoinHint.None);
					toReturn.Add(RoleAccessControlObjectEntity.Relations.LookupEntityUsingPermissionTypeId, "RoleAccessControlObject_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_____":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneOfficeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile___":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneCellConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile__":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingMemberUploadSourceId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile____":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneHomeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_______":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactReasonId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile________":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingProductTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile______":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPreferredContactType, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					toReturn.Add(RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId, "RoleEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.NotesDetailsEntityUsingDoNotContactReasonNotesId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "OrganizationCollectionViaOrganizationRoleUser":
					toReturn.Add(RoleEntity.Relations.OrganizationRoleUserEntityUsingRoleId, "RoleEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.OrganizationEntityUsingOrganizationId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHostFacilityRanking":
					toReturn.Add(RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole, "RoleEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.OrganizationRoleUserEntityUsingRankedByOrganizationRoleUserId, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaUser":
					toReturn.Add(RoleEntity.Relations.UserEntityUsingDefaultRoleId, "RoleEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "User_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaUser_":
					toReturn.Add(RoleEntity.Relations.UserEntityUsingDefaultRoleId, "RoleEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "User_", string.Empty, JoinHint.None);
					break;
				case "OrganizationTypeCollectionViaRole":
					toReturn.Add(RoleEntity.Relations.RoleEntityUsingParentId, "RoleEntity__", "Role_", JoinHint.None);
					toReturn.Add(RoleEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, "Role_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaHostFacilityRanking":
					toReturn.Add(RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole, "RoleEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.ProspectsEntityUsingHostId, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "UserCollectionViaOrganizationRoleUser":
					toReturn.Add(RoleEntity.Relations.OrganizationRoleUserEntityUsingRoleId, "RoleEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.UserEntityUsingUserId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
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
				case "OrganizationType":
					SetupSyncOrganizationType(relatedEntity);
					break;
				case "Role":
					SetupSyncRole(relatedEntity);
					break;
				case "Contacts_":
					this.Contacts_.Add((ContactsEntity)relatedEntity);
					break;
				case "Contacts":
					this.Contacts.Add((ContactsEntity)relatedEntity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)relatedEntity);
					break;
				case "HostFacilityRanking":
					this.HostFacilityRanking.Add((HostFacilityRankingEntity)relatedEntity);
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)relatedEntity);
					break;
				case "Role_":
					this.Role_.Add((RoleEntity)relatedEntity);
					break;
				case "RoleAccessControlObject":
					this.RoleAccessControlObject.Add((RoleAccessControlObjectEntity)relatedEntity);
					break;
				case "RolePermisibleAccessControlObject":
					this.RolePermisibleAccessControlObject.Add((RolePermisibleAccessControlObjectEntity)relatedEntity);
					break;
				case "RoleScopeOption":
					this.RoleScopeOption.Add((RoleScopeOptionEntity)relatedEntity);
					break;
				case "User":
					this.User.Add((UserEntity)relatedEntity);
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
				case "OrganizationType":
					DesetupSyncOrganizationType(false, true);
					break;
				case "Role":
					DesetupSyncRole(false, true);
					break;
				case "Contacts_":
					base.PerformRelatedEntityRemoval(this.Contacts_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Contacts":
					base.PerformRelatedEntityRemoval(this.Contacts, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerProfile":
					base.PerformRelatedEntityRemoval(this.CustomerProfile, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostFacilityRanking":
					base.PerformRelatedEntityRemoval(this.HostFacilityRanking, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OrganizationRoleUser":
					base.PerformRelatedEntityRemoval(this.OrganizationRoleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Role_":
					base.PerformRelatedEntityRemoval(this.Role_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleAccessControlObject":
					base.PerformRelatedEntityRemoval(this.RoleAccessControlObject, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RolePermisibleAccessControlObject":
					base.PerformRelatedEntityRemoval(this.RolePermisibleAccessControlObject, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "RoleScopeOption":
					base.PerformRelatedEntityRemoval(this.RoleScopeOption, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "User":
					base.PerformRelatedEntityRemoval(this.User, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_organizationType!=null)
			{
				toReturn.Add(_organizationType);
			}
			if(_role!=null)
			{
				toReturn.Add(_role);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Contacts_);
			toReturn.Add(this.Contacts);
			toReturn.Add(this.CustomerProfile);
			toReturn.Add(this.HostFacilityRanking);
			toReturn.Add(this.OrganizationRoleUser);
			toReturn.Add(this.Role_);
			toReturn.Add(this.RoleAccessControlObject);
			toReturn.Add(this.RolePermisibleAccessControlObject);
			toReturn.Add(this.RoleScopeOption);
			toReturn.Add(this.User);

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
				info.AddValue("_contacts_", ((_contacts_!=null) && (_contacts_.Count>0) && !this.MarkedForDeletion)?_contacts_:null);
				info.AddValue("_contacts", ((_contacts!=null) && (_contacts.Count>0) && !this.MarkedForDeletion)?_contacts:null);
				info.AddValue("_customerProfile", ((_customerProfile!=null) && (_customerProfile.Count>0) && !this.MarkedForDeletion)?_customerProfile:null);
				info.AddValue("_hostFacilityRanking", ((_hostFacilityRanking!=null) && (_hostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_hostFacilityRanking:null);
				info.AddValue("_organizationRoleUser", ((_organizationRoleUser!=null) && (_organizationRoleUser.Count>0) && !this.MarkedForDeletion)?_organizationRoleUser:null);
				info.AddValue("_role_", ((_role_!=null) && (_role_.Count>0) && !this.MarkedForDeletion)?_role_:null);
				info.AddValue("_roleAccessControlObject", ((_roleAccessControlObject!=null) && (_roleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_roleAccessControlObject:null);
				info.AddValue("_rolePermisibleAccessControlObject", ((_rolePermisibleAccessControlObject!=null) && (_rolePermisibleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_rolePermisibleAccessControlObject:null);
				info.AddValue("_roleScopeOption", ((_roleScopeOption!=null) && (_roleScopeOption.Count>0) && !this.MarkedForDeletion)?_roleScopeOption:null);
				info.AddValue("_user", ((_user!=null) && (_user.Count>0) && !this.MarkedForDeletion)?_user:null);
				info.AddValue("_accessControlObjectCollectionViaRolePermisibleAccessControlObject", ((_accessControlObjectCollectionViaRolePermisibleAccessControlObject!=null) && (_accessControlObjectCollectionViaRolePermisibleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_accessControlObjectCollectionViaRolePermisibleAccessControlObject:null);
				info.AddValue("_accessControlObjectCollectionViaRoleAccessControlObject", ((_accessControlObjectCollectionViaRoleAccessControlObject!=null) && (_accessControlObjectCollectionViaRoleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_accessControlObjectCollectionViaRoleAccessControlObject:null);
				info.AddValue("_activityTypeCollectionViaCustomerProfile", ((_activityTypeCollectionViaCustomerProfile!=null) && (_activityTypeCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCustomerProfile:null);
				info.AddValue("_addressCollectionViaCustomerProfile", ((_addressCollectionViaCustomerProfile!=null) && (_addressCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaCustomerProfile:null);
				info.AddValue("_addressCollectionViaUser", ((_addressCollectionViaUser!=null) && (_addressCollectionViaUser.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaUser:null);
				info.AddValue("_contactTypeCollectionViaContacts", ((_contactTypeCollectionViaContacts!=null) && (_contactTypeCollectionViaContacts.Count>0) && !this.MarkedForDeletion)?_contactTypeCollectionViaContacts:null);
				info.AddValue("_contactTypeCollectionViaContacts_", ((_contactTypeCollectionViaContacts_!=null) && (_contactTypeCollectionViaContacts_.Count>0) && !this.MarkedForDeletion)?_contactTypeCollectionViaContacts_:null);
				info.AddValue("_labCollectionViaCustomerProfile", ((_labCollectionViaCustomerProfile!=null) && (_labCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_labCollectionViaCustomerProfile:null);
				info.AddValue("_languageCollectionViaCustomerProfile", ((_languageCollectionViaCustomerProfile!=null) && (_languageCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaRoleScopeOption", ((_lookupCollectionViaRoleScopeOption!=null) && (_lookupCollectionViaRoleScopeOption.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRoleScopeOption:null);
				info.AddValue("_lookupCollectionViaHostFacilityRanking_", ((_lookupCollectionViaHostFacilityRanking_!=null) && (_lookupCollectionViaHostFacilityRanking_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostFacilityRanking_:null);
				info.AddValue("_lookupCollectionViaHostFacilityRanking", ((_lookupCollectionViaHostFacilityRanking!=null) && (_lookupCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostFacilityRanking:null);
				info.AddValue("_lookupCollectionViaRoleAccessControlObject_", ((_lookupCollectionViaRoleAccessControlObject_!=null) && (_lookupCollectionViaRoleAccessControlObject_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRoleAccessControlObject_:null);
				info.AddValue("_lookupCollectionViaRoleAccessControlObject", ((_lookupCollectionViaRoleAccessControlObject!=null) && (_lookupCollectionViaRoleAccessControlObject.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaRoleAccessControlObject:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_____", ((_lookupCollectionViaCustomerProfile_____!=null) && (_lookupCollectionViaCustomerProfile_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile", ((_lookupCollectionViaCustomerProfile!=null) && (_lookupCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile___", ((_lookupCollectionViaCustomerProfile___!=null) && (_lookupCollectionViaCustomerProfile___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile___:null);
				info.AddValue("_lookupCollectionViaCustomerProfile__", ((_lookupCollectionViaCustomerProfile__!=null) && (_lookupCollectionViaCustomerProfile__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile__:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_", ((_lookupCollectionViaCustomerProfile_!=null) && (_lookupCollectionViaCustomerProfile_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_:null);
				info.AddValue("_lookupCollectionViaCustomerProfile____", ((_lookupCollectionViaCustomerProfile____!=null) && (_lookupCollectionViaCustomerProfile____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_______", ((_lookupCollectionViaCustomerProfile_______!=null) && (_lookupCollectionViaCustomerProfile_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile________", ((_lookupCollectionViaCustomerProfile________!=null) && (_lookupCollectionViaCustomerProfile________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile________:null);
				info.AddValue("_lookupCollectionViaCustomerProfile______", ((_lookupCollectionViaCustomerProfile______!=null) && (_lookupCollectionViaCustomerProfile______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile______:null);
				info.AddValue("_notesDetailsCollectionViaCustomerProfile", ((_notesDetailsCollectionViaCustomerProfile!=null) && (_notesDetailsCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCustomerProfile:null);
				info.AddValue("_organizationCollectionViaOrganizationRoleUser", ((_organizationCollectionViaOrganizationRoleUser!=null) && (_organizationCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_organizationCollectionViaOrganizationRoleUser:null);
				info.AddValue("_organizationRoleUserCollectionViaHostFacilityRanking", ((_organizationRoleUserCollectionViaHostFacilityRanking!=null) && (_organizationRoleUserCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHostFacilityRanking:null);
				info.AddValue("_organizationRoleUserCollectionViaUser", ((_organizationRoleUserCollectionViaUser!=null) && (_organizationRoleUserCollectionViaUser.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaUser:null);
				info.AddValue("_organizationRoleUserCollectionViaUser_", ((_organizationRoleUserCollectionViaUser_!=null) && (_organizationRoleUserCollectionViaUser_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaUser_:null);
				info.AddValue("_organizationTypeCollectionViaRole", ((_organizationTypeCollectionViaRole!=null) && (_organizationTypeCollectionViaRole.Count>0) && !this.MarkedForDeletion)?_organizationTypeCollectionViaRole:null);
				info.AddValue("_prospectsCollectionViaHostFacilityRanking", ((_prospectsCollectionViaHostFacilityRanking!=null) && (_prospectsCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaHostFacilityRanking:null);
				info.AddValue("_userCollectionViaOrganizationRoleUser", ((_userCollectionViaOrganizationRoleUser!=null) && (_userCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_userCollectionViaOrganizationRoleUser:null);
				info.AddValue("_organizationType", (!this.MarkedForDeletion?_organizationType:null));
				info.AddValue("_role", (!this.MarkedForDeletion?_role:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary> Method which will construct a filter (predicate expression) for the unique constraint defined on the fields:
		/// Name .</summary>
		/// <returns>true if succeeded and the contents is read, false otherwise</returns>
		public IPredicateExpression ConstructFilterForUCName()
		{
			IPredicateExpression filter = new PredicateExpression();
			filter.Add(new FieldCompareValuePredicate(base.Fields[(int)RoleFieldIndex.Name], null, ComparisonOperator.Equal)); 
			return filter;
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(RoleFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(RoleFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new RoleRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Contacts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContacts_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactsFields.ModifiedRoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Contacts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactsFields.AddedRoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.AddedByRoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostFacilityRanking' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostFacilityRankingFields.RankedByRole, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.ParentId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RoleAccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleAccessControlObjectFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RolePermisibleAccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRolePermisibleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RolePermisibleAccessControlObjectFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'RoleScopeOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleScopeOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleScopeOptionFields.RoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.DefaultRoleId, null, ComparisonOperator.Equal, this.RoleId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessControlObjectCollectionViaRolePermisibleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccessControlObjectCollectionViaRolePermisibleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccessControlObject' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccessControlObjectCollectionViaRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccessControlObjectCollectionViaRoleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactTypeCollectionViaContacts()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ContactTypeCollectionViaContacts"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactTypeCollectionViaContacts_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ContactTypeCollectionViaContacts_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lab' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLabCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LabCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRoleScopeOption()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRoleScopeOption"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostFacilityRanking_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostFacilityRanking_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRoleAccessControlObject_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRoleAccessControlObject_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaRoleAccessControlObject()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaRoleAccessControlObject"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaUser_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationTypeCollectionViaRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationTypeCollectionViaRole"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UserCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.RoleId, "RoleEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationTypeFields.OrganizationTypeId, null, ComparisonOperator.Equal, this.OrganizationTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Role' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRole()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(RoleFields.RoleId, null, ComparisonOperator.Equal, this.ParentId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.RoleEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._contacts_);
			collectionsQueue.Enqueue(this._contacts);
			collectionsQueue.Enqueue(this._customerProfile);
			collectionsQueue.Enqueue(this._hostFacilityRanking);
			collectionsQueue.Enqueue(this._organizationRoleUser);
			collectionsQueue.Enqueue(this._role_);
			collectionsQueue.Enqueue(this._roleAccessControlObject);
			collectionsQueue.Enqueue(this._rolePermisibleAccessControlObject);
			collectionsQueue.Enqueue(this._roleScopeOption);
			collectionsQueue.Enqueue(this._user);
			collectionsQueue.Enqueue(this._accessControlObjectCollectionViaRolePermisibleAccessControlObject);
			collectionsQueue.Enqueue(this._accessControlObjectCollectionViaRoleAccessControlObject);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._addressCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._addressCollectionViaUser);
			collectionsQueue.Enqueue(this._contactTypeCollectionViaContacts);
			collectionsQueue.Enqueue(this._contactTypeCollectionViaContacts_);
			collectionsQueue.Enqueue(this._labCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._languageCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaRoleScopeOption);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostFacilityRanking_);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._lookupCollectionViaRoleAccessControlObject_);
			collectionsQueue.Enqueue(this._lookupCollectionViaRoleAccessControlObject);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile___);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile__);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile________);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile______);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._organizationCollectionViaOrganizationRoleUser);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaUser);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaUser_);
			collectionsQueue.Enqueue(this._organizationTypeCollectionViaRole);
			collectionsQueue.Enqueue(this._prospectsCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._userCollectionViaOrganizationRoleUser);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._contacts_ = (EntityCollection<ContactsEntity>) collectionsQueue.Dequeue();
			this._contacts = (EntityCollection<ContactsEntity>) collectionsQueue.Dequeue();
			this._customerProfile = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._hostFacilityRanking = (EntityCollection<HostFacilityRankingEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._role_ = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._roleAccessControlObject = (EntityCollection<RoleAccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._rolePermisibleAccessControlObject = (EntityCollection<RolePermisibleAccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._roleScopeOption = (EntityCollection<RoleScopeOptionEntity>) collectionsQueue.Dequeue();
			this._user = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
			this._accessControlObjectCollectionViaRolePermisibleAccessControlObject = (EntityCollection<AccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._accessControlObjectCollectionViaRoleAccessControlObject = (EntityCollection<AccessControlObjectEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaCustomerProfile = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaUser = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._contactTypeCollectionViaContacts = (EntityCollection<ContactTypeEntity>) collectionsQueue.Dequeue();
			this._contactTypeCollectionViaContacts_ = (EntityCollection<ContactTypeEntity>) collectionsQueue.Dequeue();
			this._labCollectionViaCustomerProfile = (EntityCollection<LabEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRoleScopeOption = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostFacilityRanking_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostFacilityRanking = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRoleAccessControlObject_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaRoleAccessControlObject = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationCollectionViaOrganizationRoleUser = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHostFacilityRanking = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaUser = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaUser_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationTypeCollectionViaRole = (EntityCollection<OrganizationTypeEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaHostFacilityRanking = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._userCollectionViaOrganizationRoleUser = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._contacts_ != null)
			{
				return true;
			}
			if (this._contacts != null)
			{
				return true;
			}
			if (this._customerProfile != null)
			{
				return true;
			}
			if (this._hostFacilityRanking != null)
			{
				return true;
			}
			if (this._organizationRoleUser != null)
			{
				return true;
			}
			if (this._role_ != null)
			{
				return true;
			}
			if (this._roleAccessControlObject != null)
			{
				return true;
			}
			if (this._rolePermisibleAccessControlObject != null)
			{
				return true;
			}
			if (this._roleScopeOption != null)
			{
				return true;
			}
			if (this._user != null)
			{
				return true;
			}
			if (this._accessControlObjectCollectionViaRolePermisibleAccessControlObject != null)
			{
				return true;
			}
			if (this._accessControlObjectCollectionViaRoleAccessControlObject != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._addressCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._addressCollectionViaUser != null)
			{
				return true;
			}
			if (this._contactTypeCollectionViaContacts != null)
			{
				return true;
			}
			if (this._contactTypeCollectionViaContacts_ != null)
			{
				return true;
			}
			if (this._labCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._languageCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRoleScopeOption != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostFacilityRanking_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRoleAccessControlObject_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaRoleAccessControlObject != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_____ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile != null)
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
			if (this._lookupCollectionViaCustomerProfile_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile____ != null)
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
			if (this._lookupCollectionViaCustomerProfile______ != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._organizationCollectionViaOrganizationRoleUser != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaUser != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaUser_ != null)
			{
				return true;
			}
			if (this._organizationTypeCollectionViaRole != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._userCollectionViaOrganizationRoleUser != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostFacilityRankingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostFacilityRankingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleScopeOptionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OrganizationType", _organizationType);
			toReturn.Add("Role", _role);
			toReturn.Add("Contacts_", _contacts_);
			toReturn.Add("Contacts", _contacts);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("HostFacilityRanking", _hostFacilityRanking);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("Role_", _role_);
			toReturn.Add("RoleAccessControlObject", _roleAccessControlObject);
			toReturn.Add("RolePermisibleAccessControlObject", _rolePermisibleAccessControlObject);
			toReturn.Add("RoleScopeOption", _roleScopeOption);
			toReturn.Add("User", _user);
			toReturn.Add("AccessControlObjectCollectionViaRolePermisibleAccessControlObject", _accessControlObjectCollectionViaRolePermisibleAccessControlObject);
			toReturn.Add("AccessControlObjectCollectionViaRoleAccessControlObject", _accessControlObjectCollectionViaRoleAccessControlObject);
			toReturn.Add("ActivityTypeCollectionViaCustomerProfile", _activityTypeCollectionViaCustomerProfile);
			toReturn.Add("AddressCollectionViaCustomerProfile", _addressCollectionViaCustomerProfile);
			toReturn.Add("AddressCollectionViaUser", _addressCollectionViaUser);
			toReturn.Add("ContactTypeCollectionViaContacts", _contactTypeCollectionViaContacts);
			toReturn.Add("ContactTypeCollectionViaContacts_", _contactTypeCollectionViaContacts_);
			toReturn.Add("LabCollectionViaCustomerProfile", _labCollectionViaCustomerProfile);
			toReturn.Add("LanguageCollectionViaCustomerProfile", _languageCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaRoleScopeOption", _lookupCollectionViaRoleScopeOption);
			toReturn.Add("LookupCollectionViaHostFacilityRanking_", _lookupCollectionViaHostFacilityRanking_);
			toReturn.Add("LookupCollectionViaHostFacilityRanking", _lookupCollectionViaHostFacilityRanking);
			toReturn.Add("LookupCollectionViaRoleAccessControlObject_", _lookupCollectionViaRoleAccessControlObject_);
			toReturn.Add("LookupCollectionViaRoleAccessControlObject", _lookupCollectionViaRoleAccessControlObject);
			toReturn.Add("LookupCollectionViaCustomerProfile_____", _lookupCollectionViaCustomerProfile_____);
			toReturn.Add("LookupCollectionViaCustomerProfile", _lookupCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile___", _lookupCollectionViaCustomerProfile___);
			toReturn.Add("LookupCollectionViaCustomerProfile__", _lookupCollectionViaCustomerProfile__);
			toReturn.Add("LookupCollectionViaCustomerProfile_", _lookupCollectionViaCustomerProfile_);
			toReturn.Add("LookupCollectionViaCustomerProfile____", _lookupCollectionViaCustomerProfile____);
			toReturn.Add("LookupCollectionViaCustomerProfile_______", _lookupCollectionViaCustomerProfile_______);
			toReturn.Add("LookupCollectionViaCustomerProfile________", _lookupCollectionViaCustomerProfile________);
			toReturn.Add("LookupCollectionViaCustomerProfile______", _lookupCollectionViaCustomerProfile______);
			toReturn.Add("NotesDetailsCollectionViaCustomerProfile", _notesDetailsCollectionViaCustomerProfile);
			toReturn.Add("OrganizationCollectionViaOrganizationRoleUser", _organizationCollectionViaOrganizationRoleUser);
			toReturn.Add("OrganizationRoleUserCollectionViaHostFacilityRanking", _organizationRoleUserCollectionViaHostFacilityRanking);
			toReturn.Add("OrganizationRoleUserCollectionViaUser", _organizationRoleUserCollectionViaUser);
			toReturn.Add("OrganizationRoleUserCollectionViaUser_", _organizationRoleUserCollectionViaUser_);
			toReturn.Add("OrganizationTypeCollectionViaRole", _organizationTypeCollectionViaRole);
			toReturn.Add("ProspectsCollectionViaHostFacilityRanking", _prospectsCollectionViaHostFacilityRanking);
			toReturn.Add("UserCollectionViaOrganizationRoleUser", _userCollectionViaOrganizationRoleUser);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_contacts_!=null)
			{
				_contacts_.ActiveContext = base.ActiveContext;
			}
			if(_contacts!=null)
			{
				_contacts.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_hostFacilityRanking!=null)
			{
				_hostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_role_!=null)
			{
				_role_.ActiveContext = base.ActiveContext;
			}
			if(_roleAccessControlObject!=null)
			{
				_roleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_rolePermisibleAccessControlObject!=null)
			{
				_rolePermisibleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_roleScopeOption!=null)
			{
				_roleScopeOption.ActiveContext = base.ActiveContext;
			}
			if(_user!=null)
			{
				_user.ActiveContext = base.ActiveContext;
			}
			if(_accessControlObjectCollectionViaRolePermisibleAccessControlObject!=null)
			{
				_accessControlObjectCollectionViaRolePermisibleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_accessControlObjectCollectionViaRoleAccessControlObject!=null)
			{
				_accessControlObjectCollectionViaRoleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCustomerProfile!=null)
			{
				_activityTypeCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaCustomerProfile!=null)
			{
				_addressCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaUser!=null)
			{
				_addressCollectionViaUser.ActiveContext = base.ActiveContext;
			}
			if(_contactTypeCollectionViaContacts!=null)
			{
				_contactTypeCollectionViaContacts.ActiveContext = base.ActiveContext;
			}
			if(_contactTypeCollectionViaContacts_!=null)
			{
				_contactTypeCollectionViaContacts_.ActiveContext = base.ActiveContext;
			}
			if(_labCollectionViaCustomerProfile!=null)
			{
				_labCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCustomerProfile!=null)
			{
				_languageCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRoleScopeOption!=null)
			{
				_lookupCollectionViaRoleScopeOption.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostFacilityRanking_!=null)
			{
				_lookupCollectionViaHostFacilityRanking_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostFacilityRanking!=null)
			{
				_lookupCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRoleAccessControlObject_!=null)
			{
				_lookupCollectionViaRoleAccessControlObject_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaRoleAccessControlObject!=null)
			{
				_lookupCollectionViaRoleAccessControlObject.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_____!=null)
			{
				_lookupCollectionViaCustomerProfile_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile!=null)
			{
				_lookupCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile___!=null)
			{
				_lookupCollectionViaCustomerProfile___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile__!=null)
			{
				_lookupCollectionViaCustomerProfile__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_!=null)
			{
				_lookupCollectionViaCustomerProfile_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile____!=null)
			{
				_lookupCollectionViaCustomerProfile____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_______!=null)
			{
				_lookupCollectionViaCustomerProfile_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile________!=null)
			{
				_lookupCollectionViaCustomerProfile________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile______!=null)
			{
				_lookupCollectionViaCustomerProfile______.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCustomerProfile!=null)
			{
				_notesDetailsCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationCollectionViaOrganizationRoleUser!=null)
			{
				_organizationCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHostFacilityRanking!=null)
			{
				_organizationRoleUserCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaUser!=null)
			{
				_organizationRoleUserCollectionViaUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaUser_!=null)
			{
				_organizationRoleUserCollectionViaUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationTypeCollectionViaRole!=null)
			{
				_organizationTypeCollectionViaRole.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaHostFacilityRanking!=null)
			{
				_prospectsCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_userCollectionViaOrganizationRoleUser!=null)
			{
				_userCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationType!=null)
			{
				_organizationType.ActiveContext = base.ActiveContext;
			}
			if(_role!=null)
			{
				_role.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_contacts_ = null;
			_contacts = null;
			_customerProfile = null;
			_hostFacilityRanking = null;
			_organizationRoleUser = null;
			_role_ = null;
			_roleAccessControlObject = null;
			_rolePermisibleAccessControlObject = null;
			_roleScopeOption = null;
			_user = null;
			_accessControlObjectCollectionViaRolePermisibleAccessControlObject = null;
			_accessControlObjectCollectionViaRoleAccessControlObject = null;
			_activityTypeCollectionViaCustomerProfile = null;
			_addressCollectionViaCustomerProfile = null;
			_addressCollectionViaUser = null;
			_contactTypeCollectionViaContacts = null;
			_contactTypeCollectionViaContacts_ = null;
			_labCollectionViaCustomerProfile = null;
			_languageCollectionViaCustomerProfile = null;
			_lookupCollectionViaRoleScopeOption = null;
			_lookupCollectionViaHostFacilityRanking_ = null;
			_lookupCollectionViaHostFacilityRanking = null;
			_lookupCollectionViaRoleAccessControlObject_ = null;
			_lookupCollectionViaRoleAccessControlObject = null;
			_lookupCollectionViaCustomerProfile_____ = null;
			_lookupCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile___ = null;
			_lookupCollectionViaCustomerProfile__ = null;
			_lookupCollectionViaCustomerProfile_ = null;
			_lookupCollectionViaCustomerProfile____ = null;
			_lookupCollectionViaCustomerProfile_______ = null;
			_lookupCollectionViaCustomerProfile________ = null;
			_lookupCollectionViaCustomerProfile______ = null;
			_notesDetailsCollectionViaCustomerProfile = null;
			_organizationCollectionViaOrganizationRoleUser = null;
			_organizationRoleUserCollectionViaHostFacilityRanking = null;
			_organizationRoleUserCollectionViaUser = null;
			_organizationRoleUserCollectionViaUser_ = null;
			_organizationTypeCollectionViaRole = null;
			_prospectsCollectionViaHostFacilityRanking = null;
			_userCollectionViaOrganizationRoleUser = null;
			_organizationType = null;
			_role = null;

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

			_fieldsCustomProperties.Add("RoleId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Alias", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DefaultPage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShellType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsSystemRole", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsTwoFactorAuthrequired", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsPinRequired", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _organizationType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationType, new PropertyChangedEventHandler( OnOrganizationTypePropertyChanged ), "OrganizationType", RoleEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, true, signalRelatedEntity, "Role", resetFKFields, new int[] { (int)RoleFieldIndex.OrganizationTypeId } );		
			_organizationType = null;
		}

		/// <summary> setups the sync logic for member _organizationType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOrganizationType(IEntity2 relatedEntity)
		{
			if(_organizationType!=relatedEntity)
			{
				DesetupSyncOrganizationType(true, true);
				_organizationType = (OrganizationTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _organizationType, new PropertyChangedEventHandler( OnOrganizationTypePropertyChanged ), "OrganizationType", RoleEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOrganizationTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _role</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncRole(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", RoleEntity.Relations.RoleEntityUsingRoleIdParentId, true, signalRelatedEntity, "Role_", resetFKFields, new int[] { (int)RoleFieldIndex.ParentId } );		
			_role = null;
		}

		/// <summary> setups the sync logic for member _role</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncRole(IEntity2 relatedEntity)
		{
			if(_role!=relatedEntity)
			{
				DesetupSyncRole(true, true);
				_role = (RoleEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _role, new PropertyChangedEventHandler( OnRolePropertyChanged ), "Role", RoleEntity.Relations.RoleEntityUsingRoleIdParentId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnRolePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this RoleEntity</param>
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
		public  static RoleRelations Relations
		{
			get	{ return new RoleRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContacts_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Contacts_")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ContactsEntity, 0, null, null, null, null, "Contacts_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContacts
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Contacts")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ContactsEntity, 0, null, null, null, null, "Contacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostFacilityRanking' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostFacilityRanking
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostFacilityRankingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostFacilityRankingEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostFacilityRanking")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.HostFacilityRankingEntity, 0, null, null, null, null, "HostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUser
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role_")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleAccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleAccessControlObject
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("RoleAccessControlObject")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.RoleAccessControlObjectEntity, 0, null, null, null, null, "RoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RolePermisibleAccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRolePermisibleAccessControlObject
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory))),
					(IEntityRelation)GetRelationsForField("RolePermisibleAccessControlObject")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.RolePermisibleAccessControlObjectEntity, 0, null, null, null, null, "RolePermisibleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'RoleScopeOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleScopeOption
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<RoleScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleScopeOptionEntityFactory))),
					(IEntityRelation)GetRelationsForField("RoleScopeOption")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.RoleScopeOptionEntity, 0, null, null, null, null, "RoleScopeOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUser
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))),
					(IEntityRelation)GetRelationsForField("User")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.UserEntity, 0, null, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessControlObjectCollectionViaRolePermisibleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RolePermisibleAccessControlObjectEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "RolePermisibleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.AccessControlObjectEntity, 0, null, null, GetRelationsForField("AccessControlObjectCollectionViaRolePermisibleAccessControlObject"), null, "AccessControlObjectCollectionViaRolePermisibleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccessControlObject' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccessControlObjectCollectionViaRoleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.AccessControlObjectEntity, 0, null, null, GetRelationsForField("AccessControlObjectCollectionViaRoleAccessControlObject"), null, "AccessControlObjectCollectionViaRoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCustomerProfile"), null, "ActivityTypeCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaCustomerProfile"), null, "AddressCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaUser
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.UserEntityUsingDefaultRoleId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaUser"), null, "AddressCollectionViaUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactTypeCollectionViaContacts
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.ContactsEntityUsingAddedRoleId;
				intermediateRelation.SetAliases(string.Empty, "Contacts_");
				return new PrefetchPathElement2(new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ContactTypeEntity, 0, null, null, GetRelationsForField("ContactTypeCollectionViaContacts"), null, "ContactTypeCollectionViaContacts", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactTypeCollectionViaContacts_
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.ContactsEntityUsingModifiedRoleId;
				intermediateRelation.SetAliases(string.Empty, "Contacts_");
				return new PrefetchPathElement2(new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ContactTypeEntity, 0, null, null, GetRelationsForField("ContactTypeCollectionViaContacts_"), null, "ContactTypeCollectionViaContacts_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLabCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LabEntity, 0, null, null, GetRelationsForField("LabCollectionViaCustomerProfile"), null, "LabCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCustomerProfile"), null, "LanguageCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRoleScopeOption
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RoleScopeOptionEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "RoleScopeOption_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRoleScopeOption"), null, "LookupCollectionViaRoleScopeOption", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostFacilityRanking_
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostFacilityRanking_"), null, "LookupCollectionViaHostFacilityRanking_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostFacilityRanking"), null, "LookupCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRoleAccessControlObject_
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRoleAccessControlObject_"), null, "LookupCollectionViaRoleAccessControlObject_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaRoleAccessControlObject
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RoleAccessControlObjectEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "RoleAccessControlObject_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaRoleAccessControlObject"), null, "LookupCollectionViaRoleAccessControlObject", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_____
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_____"), null, "LookupCollectionViaCustomerProfile_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile"), null, "LookupCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile___
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile___"), null, "LookupCollectionViaCustomerProfile___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile__
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile__"), null, "LookupCollectionViaCustomerProfile__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_"), null, "LookupCollectionViaCustomerProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile____
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile____"), null, "LookupCollectionViaCustomerProfile____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_______
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_______"), null, "LookupCollectionViaCustomerProfile_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile________
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile________"), null, "LookupCollectionViaCustomerProfile________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile______
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile______"), null, "LookupCollectionViaCustomerProfile______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.CustomerProfileEntityUsingAddedByRoleId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCustomerProfile"), null, "NotesDetailsCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.OrganizationRoleUserEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, GetRelationsForField("OrganizationCollectionViaOrganizationRoleUser"), null, "OrganizationCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHostFacilityRanking"), null, "OrganizationRoleUserCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaUser
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.UserEntityUsingDefaultRoleId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaUser"), null, "OrganizationRoleUserCollectionViaUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaUser_
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.UserEntityUsingDefaultRoleId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaUser_"), null, "OrganizationRoleUserCollectionViaUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationTypeCollectionViaRole
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.RoleEntityUsingParentId;
				intermediateRelation.SetAliases(string.Empty, "Role_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, GetRelationsForField("OrganizationTypeCollectionViaRole"), null, "OrganizationTypeCollectionViaRole", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.HostFacilityRankingEntityUsingRankedByRole;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaHostFacilityRanking"), null, "ProspectsCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = RoleEntity.Relations.OrganizationRoleUserEntityUsingRoleId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.UserEntity, 0, null, null, GetRelationsForField("UserCollectionViaOrganizationRoleUser"), null, "UserCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("OrganizationType")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, null, null, "OrganizationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRole
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))),
					(IEntityRelation)GetRelationsForField("Role")[0], (int)Falcon.Data.EntityType.RoleEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, null, null, "Role", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return RoleEntity.CustomProperties;}
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
			get { return RoleEntity.FieldsCustomProperties;}
		}

		/// <summary> The RoleId property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."RoleID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 RoleId
		{
			get { return (System.Int64)GetValue((int)RoleFieldIndex.RoleId, true); }
			set	{ SetValue((int)RoleFieldIndex.RoleId, value); }
		}

		/// <summary> The OrganizationTypeId property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."OrganizationTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OrganizationTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)RoleFieldIndex.OrganizationTypeId, false); }
			set	{ SetValue((int)RoleFieldIndex.OrganizationTypeId, value); }
		}

		/// <summary> The Name property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.Name, true); }
			set	{ SetValue((int)RoleFieldIndex.Name, value); }
		}

		/// <summary> The Alias property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."Alias"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Alias
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.Alias, true); }
			set	{ SetValue((int)RoleFieldIndex.Alias, value); }
		}

		/// <summary> The DateCreated property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)RoleFieldIndex.DateCreated, true); }
			set	{ SetValue((int)RoleFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)RoleFieldIndex.DateModified, true); }
			set	{ SetValue((int)RoleFieldIndex.DateModified, value); }
		}

		/// <summary> The Description property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.Description, true); }
			set	{ SetValue((int)RoleFieldIndex.Description, value); }
		}

		/// <summary> The DefaultPage property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."DefaultPage"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DefaultPage
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.DefaultPage, true); }
			set	{ SetValue((int)RoleFieldIndex.DefaultPage, value); }
		}

		/// <summary> The IsActive property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)RoleFieldIndex.IsActive, true); }
			set	{ SetValue((int)RoleFieldIndex.IsActive, value); }
		}

		/// <summary> The ShellType property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."ShellType"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ShellType
		{
			get { return (System.String)GetValue((int)RoleFieldIndex.ShellType, true); }
			set	{ SetValue((int)RoleFieldIndex.ShellType, value); }
		}

		/// <summary> The ParentId property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."ParentId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentId
		{
			get { return (Nullable<System.Int64>)GetValue((int)RoleFieldIndex.ParentId, false); }
			set	{ SetValue((int)RoleFieldIndex.ParentId, value); }
		}

		/// <summary> The IsSystemRole property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."IsSystemRole"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsSystemRole
		{
			get { return (System.Boolean)GetValue((int)RoleFieldIndex.IsSystemRole, true); }
			set	{ SetValue((int)RoleFieldIndex.IsSystemRole, value); }
		}

		/// <summary> The IsTwoFactorAuthrequired property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."IsTwoFactorAuthrequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsTwoFactorAuthrequired
		{
			get { return (System.Boolean)GetValue((int)RoleFieldIndex.IsTwoFactorAuthrequired, true); }
			set	{ SetValue((int)RoleFieldIndex.IsTwoFactorAuthrequired, value); }
		}

		/// <summary> The IsPinRequired property of the Entity Role<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblRole"."IsPinRequired"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsPinRequired
		{
			get { return (System.Boolean)GetValue((int)RoleFieldIndex.IsPinRequired, true); }
			set	{ SetValue((int)RoleFieldIndex.IsPinRequired, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactsEntity))]
		public virtual EntityCollection<ContactsEntity> Contacts_
		{
			get
			{
				if(_contacts_==null)
				{
					_contacts_ = new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory)));
					_contacts_.SetContainingEntityInfo(this, "Role_");
				}
				return _contacts_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactsEntity))]
		public virtual EntityCollection<ContactsEntity> Contacts
		{
			get
			{
				if(_contacts==null)
				{
					_contacts = new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory)));
					_contacts.SetContainingEntityInfo(this, "Role");
				}
				return _contacts;
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
					_customerProfile.SetContainingEntityInfo(this, "Role");
				}
				return _customerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostFacilityRankingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostFacilityRankingEntity))]
		public virtual EntityCollection<HostFacilityRankingEntity> HostFacilityRanking
		{
			get
			{
				if(_hostFacilityRanking==null)
				{
					_hostFacilityRanking = new EntityCollection<HostFacilityRankingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostFacilityRankingEntityFactory)));
					_hostFacilityRanking.SetContainingEntityInfo(this, "Role");
				}
				return _hostFacilityRanking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUser
		{
			get
			{
				if(_organizationRoleUser==null)
				{
					_organizationRoleUser = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUser.SetContainingEntityInfo(this, "Role");
				}
				return _organizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> Role_
		{
			get
			{
				if(_role_==null)
				{
					_role_ = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_role_.SetContainingEntityInfo(this, "Role");
				}
				return _role_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleAccessControlObjectEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleAccessControlObjectEntity))]
		public virtual EntityCollection<RoleAccessControlObjectEntity> RoleAccessControlObject
		{
			get
			{
				if(_roleAccessControlObject==null)
				{
					_roleAccessControlObject = new EntityCollection<RoleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleAccessControlObjectEntityFactory)));
					_roleAccessControlObject.SetContainingEntityInfo(this, "Role");
				}
				return _roleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RolePermisibleAccessControlObjectEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RolePermisibleAccessControlObjectEntity))]
		public virtual EntityCollection<RolePermisibleAccessControlObjectEntity> RolePermisibleAccessControlObject
		{
			get
			{
				if(_rolePermisibleAccessControlObject==null)
				{
					_rolePermisibleAccessControlObject = new EntityCollection<RolePermisibleAccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RolePermisibleAccessControlObjectEntityFactory)));
					_rolePermisibleAccessControlObject.SetContainingEntityInfo(this, "Role");
				}
				return _rolePermisibleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleScopeOptionEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleScopeOptionEntity))]
		public virtual EntityCollection<RoleScopeOptionEntity> RoleScopeOption
		{
			get
			{
				if(_roleScopeOption==null)
				{
					_roleScopeOption = new EntityCollection<RoleScopeOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleScopeOptionEntityFactory)));
					_roleScopeOption.SetContainingEntityInfo(this, "Role");
				}
				return _roleScopeOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> User
		{
			get
			{
				if(_user==null)
				{
					_user = new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory)));
					_user.SetContainingEntityInfo(this, "Role");
				}
				return _user;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccessControlObjectEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccessControlObjectEntity))]
		public virtual EntityCollection<AccessControlObjectEntity> AccessControlObjectCollectionViaRolePermisibleAccessControlObject
		{
			get
			{
				if(_accessControlObjectCollectionViaRolePermisibleAccessControlObject==null)
				{
					_accessControlObjectCollectionViaRolePermisibleAccessControlObject = new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory)));
					_accessControlObjectCollectionViaRolePermisibleAccessControlObject.IsReadOnly=true;
				}
				return _accessControlObjectCollectionViaRolePermisibleAccessControlObject;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccessControlObjectEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccessControlObjectEntity))]
		public virtual EntityCollection<AccessControlObjectEntity> AccessControlObjectCollectionViaRoleAccessControlObject
		{
			get
			{
				if(_accessControlObjectCollectionViaRoleAccessControlObject==null)
				{
					_accessControlObjectCollectionViaRoleAccessControlObject = new EntityCollection<AccessControlObjectEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccessControlObjectEntityFactory)));
					_accessControlObjectCollectionViaRoleAccessControlObject.IsReadOnly=true;
				}
				return _accessControlObjectCollectionViaRoleAccessControlObject;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaUser
		{
			get
			{
				if(_addressCollectionViaUser==null)
				{
					_addressCollectionViaUser = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaUser.IsReadOnly=true;
				}
				return _addressCollectionViaUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactTypeEntity))]
		public virtual EntityCollection<ContactTypeEntity> ContactTypeCollectionViaContacts
		{
			get
			{
				if(_contactTypeCollectionViaContacts==null)
				{
					_contactTypeCollectionViaContacts = new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory)));
					_contactTypeCollectionViaContacts.IsReadOnly=true;
				}
				return _contactTypeCollectionViaContacts;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactTypeEntity))]
		public virtual EntityCollection<ContactTypeEntity> ContactTypeCollectionViaContacts_
		{
			get
			{
				if(_contactTypeCollectionViaContacts_==null)
				{
					_contactTypeCollectionViaContacts_ = new EntityCollection<ContactTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactTypeEntityFactory)));
					_contactTypeCollectionViaContacts_.IsReadOnly=true;
				}
				return _contactTypeCollectionViaContacts_;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRoleScopeOption
		{
			get
			{
				if(_lookupCollectionViaRoleScopeOption==null)
				{
					_lookupCollectionViaRoleScopeOption = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRoleScopeOption.IsReadOnly=true;
				}
				return _lookupCollectionViaRoleScopeOption;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostFacilityRanking_
		{
			get
			{
				if(_lookupCollectionViaHostFacilityRanking_==null)
				{
					_lookupCollectionViaHostFacilityRanking_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostFacilityRanking_.IsReadOnly=true;
				}
				return _lookupCollectionViaHostFacilityRanking_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostFacilityRanking
		{
			get
			{
				if(_lookupCollectionViaHostFacilityRanking==null)
				{
					_lookupCollectionViaHostFacilityRanking = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostFacilityRanking.IsReadOnly=true;
				}
				return _lookupCollectionViaHostFacilityRanking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRoleAccessControlObject_
		{
			get
			{
				if(_lookupCollectionViaRoleAccessControlObject_==null)
				{
					_lookupCollectionViaRoleAccessControlObject_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRoleAccessControlObject_.IsReadOnly=true;
				}
				return _lookupCollectionViaRoleAccessControlObject_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaRoleAccessControlObject
		{
			get
			{
				if(_lookupCollectionViaRoleAccessControlObject==null)
				{
					_lookupCollectionViaRoleAccessControlObject = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaRoleAccessControlObject.IsReadOnly=true;
				}
				return _lookupCollectionViaRoleAccessControlObject;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> OrganizationCollectionViaOrganizationRoleUser
		{
			get
			{
				if(_organizationCollectionViaOrganizationRoleUser==null)
				{
					_organizationCollectionViaOrganizationRoleUser = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organizationCollectionViaOrganizationRoleUser.IsReadOnly=true;
				}
				return _organizationCollectionViaOrganizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHostFacilityRanking
		{
			get
			{
				if(_organizationRoleUserCollectionViaHostFacilityRanking==null)
				{
					_organizationRoleUserCollectionViaHostFacilityRanking = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHostFacilityRanking.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHostFacilityRanking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaUser
		{
			get
			{
				if(_organizationRoleUserCollectionViaUser==null)
				{
					_organizationRoleUserCollectionViaUser = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaUser.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaUser_
		{
			get
			{
				if(_organizationRoleUserCollectionViaUser_==null)
				{
					_organizationRoleUserCollectionViaUser_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaUser_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaUser_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationTypeEntity))]
		public virtual EntityCollection<OrganizationTypeEntity> OrganizationTypeCollectionViaRole
		{
			get
			{
				if(_organizationTypeCollectionViaRole==null)
				{
					_organizationTypeCollectionViaRole = new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory)));
					_organizationTypeCollectionViaRole.IsReadOnly=true;
				}
				return _organizationTypeCollectionViaRole;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaHostFacilityRanking
		{
			get
			{
				if(_prospectsCollectionViaHostFacilityRanking==null)
				{
					_prospectsCollectionViaHostFacilityRanking = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaHostFacilityRanking.IsReadOnly=true;
				}
				return _prospectsCollectionViaHostFacilityRanking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UserEntity))]
		public virtual EntityCollection<UserEntity> UserCollectionViaOrganizationRoleUser
		{
			get
			{
				if(_userCollectionViaOrganizationRoleUser==null)
				{
					_userCollectionViaOrganizationRoleUser = new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory)));
					_userCollectionViaOrganizationRoleUser.IsReadOnly=true;
				}
				return _userCollectionViaOrganizationRoleUser;
			}
		}

		/// <summary> Gets / sets related entity of type 'OrganizationTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OrganizationTypeEntity OrganizationType
		{
			get
			{
				return _organizationType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOrganizationType(value);
				}
				else
				{
					if(value==null)
					{
						if(_organizationType != null)
						{
							_organizationType.UnsetRelatedEntity(this, "Role");
						}
					}
					else
					{
						if(_organizationType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Role");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'RoleEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual RoleEntity Role
		{
			get
			{
				return _role;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncRole(value);
				}
				else
				{
					if(value==null)
					{
						if(_role != null)
						{
							_role.UnsetRelatedEntity(this, "Role_");
						}
					}
					else
					{
						if(_role!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Role_");
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
			get { return (int)Falcon.Data.EntityType.RoleEntity; }
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
