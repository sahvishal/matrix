///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:43
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
	/// Entity class which represents the entity 'Address'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class AddressEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CustomerPrimaryCarePhysicianEntity> _customerPrimaryCarePhysician;
		private EntityCollection<CustomerPrimaryCarePhysicianEntity> _customerPrimaryCarePhysician_;
		private EntityCollection<CustomerProfileEntity> _customerProfile;
		private EntityCollection<HostPaymentEntity> _hostPayment;
		private EntityCollection<OrganizationEntity> _organization;
		private EntityCollection<ProspectsEntity> _prospects;
		private EntityCollection<ShippingDetailEntity> _shippingDetail;
		private EntityCollection<UserEntity> _user;
		private EntityCollection<ActivityTypeEntity> _activityTypeCollectionViaCustomerProfile;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<CustomerProfileEntity> _customerProfileCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<EventsEntity> _eventsCollectionViaHostPayment;
		private EntityCollection<FileEntity> _fileCollectionViaOrganization;
		private EntityCollection<FileEntity> _fileCollectionViaOrganization_;
		private EntityCollection<LabEntity> _labCollectionViaCustomerProfile;
		private EntityCollection<LanguageEntity> _languageCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile___;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile__;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_______;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPayment__;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPayment;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_____;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile______;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile________;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile;
		private EntityCollection<LookupEntity> _lookupCollectionViaCustomerProfile_;
		private EntityCollection<NotesDetailsEntity> _notesDetailsCollectionViaCustomerProfile;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHostPayment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaUser;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaUser_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaShippingDetail_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaProspects;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaShippingDetail;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____;
		private EntityCollection<OrganizationTypeEntity> _organizationTypeCollectionViaOrganization;
		private EntityCollection<PhysicianMasterEntity> _physicianMasterCollectionViaCustomerPrimaryCarePhysician_;
		private EntityCollection<PhysicianMasterEntity> _physicianMasterCollectionViaCustomerPrimaryCarePhysician;
		private EntityCollection<ProspectListDetailsEntity> _prospectListDetailsCollectionViaProspects;
		private EntityCollection<ProspectsEntity> _prospectsCollectionViaHostPayment;
		private EntityCollection<ProspectTypeEntity> _prospectTypeCollectionViaProspects;
		private EntityCollection<RoleEntity> _roleCollectionViaCustomerProfile;
		private EntityCollection<RoleEntity> _roleCollectionViaUser;
		private EntityCollection<ShippingOptionEntity> _shippingOptionCollectionViaShippingDetail;
		private CityEntity _city;
		private CountryEntity _country;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private StateEntity _state;
		private ZipEntity _zip;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name City</summary>
			public static readonly string City = "City";
			/// <summary>Member name Country</summary>
			public static readonly string Country = "Country";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name State</summary>
			public static readonly string State = "State";
			/// <summary>Member name Zip</summary>
			public static readonly string Zip = "Zip";
			/// <summary>Member name CustomerPrimaryCarePhysician</summary>
			public static readonly string CustomerPrimaryCarePhysician = "CustomerPrimaryCarePhysician";
			/// <summary>Member name CustomerPrimaryCarePhysician_</summary>
			public static readonly string CustomerPrimaryCarePhysician_ = "CustomerPrimaryCarePhysician_";
			/// <summary>Member name CustomerProfile</summary>
			public static readonly string CustomerProfile = "CustomerProfile";
			/// <summary>Member name HostPayment</summary>
			public static readonly string HostPayment = "HostPayment";
			/// <summary>Member name Organization</summary>
			public static readonly string Organization = "Organization";
			/// <summary>Member name Prospects</summary>
			public static readonly string Prospects = "Prospects";
			/// <summary>Member name ShippingDetail</summary>
			public static readonly string ShippingDetail = "ShippingDetail";
			/// <summary>Member name User</summary>
			public static readonly string User = "User";
			/// <summary>Member name ActivityTypeCollectionViaCustomerProfile</summary>
			public static readonly string ActivityTypeCollectionViaCustomerProfile = "ActivityTypeCollectionViaCustomerProfile";
			/// <summary>Member name CustomerProfileCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string CustomerProfileCollectionViaCustomerPrimaryCarePhysician_ = "CustomerProfileCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name CustomerProfileCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string CustomerProfileCollectionViaCustomerPrimaryCarePhysician = "CustomerProfileCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name EventsCollectionViaHostPayment</summary>
			public static readonly string EventsCollectionViaHostPayment = "EventsCollectionViaHostPayment";
			/// <summary>Member name FileCollectionViaOrganization</summary>
			public static readonly string FileCollectionViaOrganization = "FileCollectionViaOrganization";
			/// <summary>Member name FileCollectionViaOrganization_</summary>
			public static readonly string FileCollectionViaOrganization_ = "FileCollectionViaOrganization_";
			/// <summary>Member name LabCollectionViaCustomerProfile</summary>
			public static readonly string LabCollectionViaCustomerProfile = "LabCollectionViaCustomerProfile";
			/// <summary>Member name LanguageCollectionViaCustomerProfile</summary>
			public static readonly string LanguageCollectionViaCustomerProfile = "LanguageCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile____</summary>
			public static readonly string LookupCollectionViaCustomerProfile____ = "LookupCollectionViaCustomerProfile____";
			/// <summary>Member name LookupCollectionViaCustomerProfile___</summary>
			public static readonly string LookupCollectionViaCustomerProfile___ = "LookupCollectionViaCustomerProfile___";
			/// <summary>Member name LookupCollectionViaCustomerProfile__</summary>
			public static readonly string LookupCollectionViaCustomerProfile__ = "LookupCollectionViaCustomerProfile__";
			/// <summary>Member name LookupCollectionViaCustomerProfile_______</summary>
			public static readonly string LookupCollectionViaCustomerProfile_______ = "LookupCollectionViaCustomerProfile_______";
			/// <summary>Member name LookupCollectionViaHostPayment__</summary>
			public static readonly string LookupCollectionViaHostPayment__ = "LookupCollectionViaHostPayment__";
			/// <summary>Member name LookupCollectionViaHostPayment</summary>
			public static readonly string LookupCollectionViaHostPayment = "LookupCollectionViaHostPayment";
			/// <summary>Member name LookupCollectionViaCustomerProfile_____</summary>
			public static readonly string LookupCollectionViaCustomerProfile_____ = "LookupCollectionViaCustomerProfile_____";
			/// <summary>Member name LookupCollectionViaCustomerProfile______</summary>
			public static readonly string LookupCollectionViaCustomerProfile______ = "LookupCollectionViaCustomerProfile______";
			/// <summary>Member name LookupCollectionViaCustomerProfile________</summary>
			public static readonly string LookupCollectionViaCustomerProfile________ = "LookupCollectionViaCustomerProfile________";
			/// <summary>Member name LookupCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string LookupCollectionViaCustomerPrimaryCarePhysician_ = "LookupCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name LookupCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string LookupCollectionViaCustomerPrimaryCarePhysician = "LookupCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name LookupCollectionViaCustomerProfile</summary>
			public static readonly string LookupCollectionViaCustomerProfile = "LookupCollectionViaCustomerProfile";
			/// <summary>Member name LookupCollectionViaCustomerProfile_</summary>
			public static readonly string LookupCollectionViaCustomerProfile_ = "LookupCollectionViaCustomerProfile_";
			/// <summary>Member name NotesDetailsCollectionViaCustomerProfile</summary>
			public static readonly string NotesDetailsCollectionViaCustomerProfile = "NotesDetailsCollectionViaCustomerProfile";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__";
			/// <summary>Member name OrganizationRoleUserCollectionViaHostPayment</summary>
			public static readonly string OrganizationRoleUserCollectionViaHostPayment = "OrganizationRoleUserCollectionViaHostPayment";
			/// <summary>Member name OrganizationRoleUserCollectionViaUser</summary>
			public static readonly string OrganizationRoleUserCollectionViaUser = "OrganizationRoleUserCollectionViaUser";
			/// <summary>Member name OrganizationRoleUserCollectionViaUser_</summary>
			public static readonly string OrganizationRoleUserCollectionViaUser_ = "OrganizationRoleUserCollectionViaUser_";
			/// <summary>Member name OrganizationRoleUserCollectionViaShippingDetail_</summary>
			public static readonly string OrganizationRoleUserCollectionViaShippingDetail_ = "OrganizationRoleUserCollectionViaShippingDetail_";
			/// <summary>Member name OrganizationRoleUserCollectionViaProspects</summary>
			public static readonly string OrganizationRoleUserCollectionViaProspects = "OrganizationRoleUserCollectionViaProspects";
			/// <summary>Member name OrganizationRoleUserCollectionViaShippingDetail</summary>
			public static readonly string OrganizationRoleUserCollectionViaShippingDetail = "OrganizationRoleUserCollectionViaShippingDetail";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____</summary>
			public static readonly string OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ = "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____";
			/// <summary>Member name OrganizationTypeCollectionViaOrganization</summary>
			public static readonly string OrganizationTypeCollectionViaOrganization = "OrganizationTypeCollectionViaOrganization";
			/// <summary>Member name PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_</summary>
			public static readonly string PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_ = "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_";
			/// <summary>Member name PhysicianMasterCollectionViaCustomerPrimaryCarePhysician</summary>
			public static readonly string PhysicianMasterCollectionViaCustomerPrimaryCarePhysician = "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician";
			/// <summary>Member name ProspectListDetailsCollectionViaProspects</summary>
			public static readonly string ProspectListDetailsCollectionViaProspects = "ProspectListDetailsCollectionViaProspects";
			/// <summary>Member name ProspectsCollectionViaHostPayment</summary>
			public static readonly string ProspectsCollectionViaHostPayment = "ProspectsCollectionViaHostPayment";
			/// <summary>Member name ProspectTypeCollectionViaProspects</summary>
			public static readonly string ProspectTypeCollectionViaProspects = "ProspectTypeCollectionViaProspects";
			/// <summary>Member name RoleCollectionViaCustomerProfile</summary>
			public static readonly string RoleCollectionViaCustomerProfile = "RoleCollectionViaCustomerProfile";
			/// <summary>Member name RoleCollectionViaUser</summary>
			public static readonly string RoleCollectionViaUser = "RoleCollectionViaUser";
			/// <summary>Member name ShippingOptionCollectionViaShippingDetail</summary>
			public static readonly string ShippingOptionCollectionViaShippingDetail = "ShippingOptionCollectionViaShippingDetail";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static AddressEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public AddressEntity():base("AddressEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public AddressEntity(IEntityFields2 fields):base("AddressEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this AddressEntity</param>
		public AddressEntity(IValidator validator):base("AddressEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="addressId">PK value for Address which data should be fetched into this Address object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AddressEntity(System.Int64 addressId):base("AddressEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.AddressId = addressId;
		}

		/// <summary> CTor</summary>
		/// <param name="addressId">PK value for Address which data should be fetched into this Address object</param>
		/// <param name="validator">The custom validator object for this AddressEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public AddressEntity(System.Int64 addressId, IValidator validator):base("AddressEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.AddressId = addressId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected AddressEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_customerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>)info.GetValue("_customerPrimaryCarePhysician", typeof(EntityCollection<CustomerPrimaryCarePhysicianEntity>));
				_customerPrimaryCarePhysician_ = (EntityCollection<CustomerPrimaryCarePhysicianEntity>)info.GetValue("_customerPrimaryCarePhysician_", typeof(EntityCollection<CustomerPrimaryCarePhysicianEntity>));
				_customerProfile = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfile", typeof(EntityCollection<CustomerProfileEntity>));
				_hostPayment = (EntityCollection<HostPaymentEntity>)info.GetValue("_hostPayment", typeof(EntityCollection<HostPaymentEntity>));
				_organization = (EntityCollection<OrganizationEntity>)info.GetValue("_organization", typeof(EntityCollection<OrganizationEntity>));
				_prospects = (EntityCollection<ProspectsEntity>)info.GetValue("_prospects", typeof(EntityCollection<ProspectsEntity>));
				_shippingDetail = (EntityCollection<ShippingDetailEntity>)info.GetValue("_shippingDetail", typeof(EntityCollection<ShippingDetailEntity>));
				_user = (EntityCollection<UserEntity>)info.GetValue("_user", typeof(EntityCollection<UserEntity>));
				_activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>)info.GetValue("_activityTypeCollectionViaCustomerProfile", typeof(EntityCollection<ActivityTypeEntity>));
				_customerProfileCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<CustomerProfileEntity>));
				_customerProfileCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<CustomerProfileEntity>)info.GetValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<CustomerProfileEntity>));
				_eventsCollectionViaHostPayment = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaHostPayment", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaOrganization = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaOrganization", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaOrganization_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaOrganization_", typeof(EntityCollection<FileEntity>));
				_labCollectionViaCustomerProfile = (EntityCollection<LabEntity>)info.GetValue("_labCollectionViaCustomerProfile", typeof(EntityCollection<LabEntity>));
				_languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>)info.GetValue("_languageCollectionViaCustomerProfile", typeof(EntityCollection<LanguageEntity>));
				_lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile___", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostPayment__ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPayment__", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostPayment = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPayment", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_____", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile______", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile________", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaCustomerProfile_", typeof(EntityCollection<LookupEntity>));
				_notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>)info.GetValue("_notesDetailsCollectionViaCustomerProfile", typeof(EntityCollection<NotesDetailsEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHostPayment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHostPayment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaUser = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaUser", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaUser_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaUser_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaShippingDetail_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaShippingDetail_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaProspects", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaShippingDetail = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaShippingDetail", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationTypeCollectionViaOrganization = (EntityCollection<OrganizationTypeEntity>)info.GetValue("_organizationTypeCollectionViaOrganization", typeof(EntityCollection<OrganizationTypeEntity>));
				_physicianMasterCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<PhysicianMasterEntity>)info.GetValue("_physicianMasterCollectionViaCustomerPrimaryCarePhysician_", typeof(EntityCollection<PhysicianMasterEntity>));
				_physicianMasterCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<PhysicianMasterEntity>)info.GetValue("_physicianMasterCollectionViaCustomerPrimaryCarePhysician", typeof(EntityCollection<PhysicianMasterEntity>));
				_prospectListDetailsCollectionViaProspects = (EntityCollection<ProspectListDetailsEntity>)info.GetValue("_prospectListDetailsCollectionViaProspects", typeof(EntityCollection<ProspectListDetailsEntity>));
				_prospectsCollectionViaHostPayment = (EntityCollection<ProspectsEntity>)info.GetValue("_prospectsCollectionViaHostPayment", typeof(EntityCollection<ProspectsEntity>));
				_prospectTypeCollectionViaProspects = (EntityCollection<ProspectTypeEntity>)info.GetValue("_prospectTypeCollectionViaProspects", typeof(EntityCollection<ProspectTypeEntity>));
				_roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaCustomerProfile", typeof(EntityCollection<RoleEntity>));
				_roleCollectionViaUser = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaUser", typeof(EntityCollection<RoleEntity>));
				_shippingOptionCollectionViaShippingDetail = (EntityCollection<ShippingOptionEntity>)info.GetValue("_shippingOptionCollectionViaShippingDetail", typeof(EntityCollection<ShippingOptionEntity>));
				_city = (CityEntity)info.GetValue("_city", typeof(CityEntity));
				if(_city!=null)
				{
					_city.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_country = (CountryEntity)info.GetValue("_country", typeof(CountryEntity));
				if(_country!=null)
				{
					_country.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_state = (StateEntity)info.GetValue("_state", typeof(StateEntity));
				if(_state!=null)
				{
					_state.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_zip = (ZipEntity)info.GetValue("_zip", typeof(ZipEntity));
				if(_zip!=null)
				{
					_zip.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((AddressFieldIndex)fieldIndex)
			{
				case AddressFieldIndex.CityId:
					DesetupSyncCity(true, false);
					break;
				case AddressFieldIndex.StateId:
					DesetupSyncState(true, false);
					break;
				case AddressFieldIndex.CountryId:
					DesetupSyncCountry(true, false);
					break;
				case AddressFieldIndex.ZipId:
					DesetupSyncZip(true, false);
					break;
				case AddressFieldIndex.VerificationOrgRoleUserId:
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
				case "City":
					this.City = (CityEntity)entity;
					break;
				case "Country":
					this.Country = (CountryEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "State":
					this.State = (StateEntity)entity;
					break;
				case "Zip":
					this.Zip = (ZipEntity)entity;
					break;
				case "CustomerPrimaryCarePhysician":
					this.CustomerPrimaryCarePhysician.Add((CustomerPrimaryCarePhysicianEntity)entity);
					break;
				case "CustomerPrimaryCarePhysician_":
					this.CustomerPrimaryCarePhysician_.Add((CustomerPrimaryCarePhysicianEntity)entity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)entity);
					break;
				case "HostPayment":
					this.HostPayment.Add((HostPaymentEntity)entity);
					break;
				case "Organization":
					this.Organization.Add((OrganizationEntity)entity);
					break;
				case "Prospects":
					this.Prospects.Add((ProspectsEntity)entity);
					break;
				case "ShippingDetail":
					this.ShippingDetail.Add((ShippingDetailEntity)entity);
					break;
				case "User":
					this.User.Add((UserEntity)entity);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = false;
					this.ActivityTypeCollectionViaCustomerProfile.Add((ActivityTypeEntity)entity);
					this.ActivityTypeCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician_":
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician_.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician":
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.Add((CustomerProfileEntity)entity);
					this.CustomerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "EventsCollectionViaHostPayment":
					this.EventsCollectionViaHostPayment.IsReadOnly = false;
					this.EventsCollectionViaHostPayment.Add((EventsEntity)entity);
					this.EventsCollectionViaHostPayment.IsReadOnly = true;
					break;
				case "FileCollectionViaOrganization":
					this.FileCollectionViaOrganization.IsReadOnly = false;
					this.FileCollectionViaOrganization.Add((FileEntity)entity);
					this.FileCollectionViaOrganization.IsReadOnly = true;
					break;
				case "FileCollectionViaOrganization_":
					this.FileCollectionViaOrganization_.IsReadOnly = false;
					this.FileCollectionViaOrganization_.Add((FileEntity)entity);
					this.FileCollectionViaOrganization_.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile____":
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile____.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile____.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile_______":
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_______.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_______.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostPayment__":
					this.LookupCollectionViaHostPayment__.IsReadOnly = false;
					this.LookupCollectionViaHostPayment__.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPayment__.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostPayment":
					this.LookupCollectionViaHostPayment.IsReadOnly = false;
					this.LookupCollectionViaHostPayment.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPayment.IsReadOnly = true;
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
				case "LookupCollectionViaCustomerProfile________":
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile________.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile________.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician_":
					this.LookupCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.LookupCollectionViaCustomerPrimaryCarePhysician_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician":
					this.LookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.LookupCollectionViaCustomerPrimaryCarePhysician.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile":
					this.LookupCollectionViaCustomerProfile.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "LookupCollectionViaCustomerProfile_":
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = false;
					this.LookupCollectionViaCustomerProfile_.Add((LookupEntity)entity);
					this.LookupCollectionViaCustomerProfile_.IsReadOnly = true;
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = false;
					this.NotesDetailsCollectionViaCustomerProfile.Add((NotesDetailsEntity)entity);
					this.NotesDetailsCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHostPayment":
					this.OrganizationRoleUserCollectionViaHostPayment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHostPayment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHostPayment.IsReadOnly = true;
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
				case "OrganizationRoleUserCollectionViaShippingDetail_":
					this.OrganizationRoleUserCollectionViaShippingDetail_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaShippingDetail_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaShippingDetail_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaProspects.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaProspects.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail":
					this.OrganizationRoleUserCollectionViaShippingDetail.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaShippingDetail.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaShippingDetail.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____":
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.IsReadOnly = true;
					break;
				case "OrganizationTypeCollectionViaOrganization":
					this.OrganizationTypeCollectionViaOrganization.IsReadOnly = false;
					this.OrganizationTypeCollectionViaOrganization.Add((OrganizationTypeEntity)entity);
					this.OrganizationTypeCollectionViaOrganization.IsReadOnly = true;
					break;
				case "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_":
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = false;
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_.Add((PhysicianMasterEntity)entity);
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly = true;
					break;
				case "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician":
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = false;
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician.Add((PhysicianMasterEntity)entity);
					this.PhysicianMasterCollectionViaCustomerPrimaryCarePhysician.IsReadOnly = true;
					break;
				case "ProspectListDetailsCollectionViaProspects":
					this.ProspectListDetailsCollectionViaProspects.IsReadOnly = false;
					this.ProspectListDetailsCollectionViaProspects.Add((ProspectListDetailsEntity)entity);
					this.ProspectListDetailsCollectionViaProspects.IsReadOnly = true;
					break;
				case "ProspectsCollectionViaHostPayment":
					this.ProspectsCollectionViaHostPayment.IsReadOnly = false;
					this.ProspectsCollectionViaHostPayment.Add((ProspectsEntity)entity);
					this.ProspectsCollectionViaHostPayment.IsReadOnly = true;
					break;
				case "ProspectTypeCollectionViaProspects":
					this.ProspectTypeCollectionViaProspects.IsReadOnly = false;
					this.ProspectTypeCollectionViaProspects.Add((ProspectTypeEntity)entity);
					this.ProspectTypeCollectionViaProspects.IsReadOnly = true;
					break;
				case "RoleCollectionViaCustomerProfile":
					this.RoleCollectionViaCustomerProfile.IsReadOnly = false;
					this.RoleCollectionViaCustomerProfile.Add((RoleEntity)entity);
					this.RoleCollectionViaCustomerProfile.IsReadOnly = true;
					break;
				case "RoleCollectionViaUser":
					this.RoleCollectionViaUser.IsReadOnly = false;
					this.RoleCollectionViaUser.Add((RoleEntity)entity);
					this.RoleCollectionViaUser.IsReadOnly = true;
					break;
				case "ShippingOptionCollectionViaShippingDetail":
					this.ShippingOptionCollectionViaShippingDetail.IsReadOnly = false;
					this.ShippingOptionCollectionViaShippingDetail.Add((ShippingOptionEntity)entity);
					this.ShippingOptionCollectionViaShippingDetail.IsReadOnly = true;
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
			return AddressEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "City":
					toReturn.Add(AddressEntity.Relations.CityEntityUsingCityId);
					break;
				case "Country":
					toReturn.Add(AddressEntity.Relations.CountryEntityUsingCountryId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId);
					break;
				case "State":
					toReturn.Add(AddressEntity.Relations.StateEntityUsingStateId);
					break;
				case "Zip":
					toReturn.Add(AddressEntity.Relations.ZipEntityUsingZipId);
					break;
				case "CustomerPrimaryCarePhysician":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress);
					break;
				case "CustomerPrimaryCarePhysician_":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId);
					break;
				case "CustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId);
					break;
				case "HostPayment":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId);
					break;
				case "Organization":
					toReturn.Add(AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId);
					break;
				case "Prospects":
					toReturn.Add(AddressEntity.Relations.ProspectsEntityUsingAddressId);
					break;
				case "ShippingDetail":
					toReturn.Add(AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId);
					break;
				case "User":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingHomeAddressId);
					break;
				case "ActivityTypeCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.ActivityTypeEntityUsingActivityId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "CustomerProfileCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.CustomerProfileEntityUsingCustomerId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaHostPayment":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId, "AddressEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.EventsEntityUsingEventId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaOrganization":
					toReturn.Add(AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId, "AddressEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingLogoImageId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaOrganization_":
					toReturn.Add(AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId, "AddressEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingTeamImageId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "LabCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LabEntityUsingLabId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LanguageCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LanguageEntityUsingLanguageId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile____":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneHomeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile___":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneCellConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile__":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingMemberUploadSourceId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_______":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactReasonId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostPayment__":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId, "AddressEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingDepositType, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostPayment":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId, "AddressEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingStatus, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_____":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPhoneOfficeConsentId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile______":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingPreferredContactType, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile________":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingProductTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.LookupEntityUsingSource, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactTypeId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaCustomerProfile_":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.LookupEntityUsingDoNotContactUpdateSource, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "NotesDetailsCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.NotesDetailsEntityUsingDoNotContactReasonNotesId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHostPayment":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId, "AddressEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaUser":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingHomeAddressId, "AddressEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "User_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaUser_":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingHomeAddressId, "AddressEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, "User_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail_":
					toReturn.Add(AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId, "AddressEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.OrganizationRoleUserEntityUsingShippedByOrgRoleUserId, "ShippingDetail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaProspects":
					toReturn.Add(AddressEntity.Relations.ProspectsEntityUsingAddressId, "AddressEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaShippingDetail":
					toReturn.Add(AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId, "AddressEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "ShippingDetail_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingUpdatedByOrganizationRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.OrganizationRoleUserEntityUsingPcpAddressVerifiedBy, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "OrganizationTypeCollectionViaOrganization":
					toReturn.Add(AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId, "AddressEntity__", "Organization_", JoinHint.None);
					toReturn.Add(OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, "Organization_", string.Empty, JoinHint.None);
					break;
				case "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.PhysicianMasterEntityUsingPhysicianMasterId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician":
					toReturn.Add(AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress, "AddressEntity__", "CustomerPrimaryCarePhysician_", JoinHint.None);
					toReturn.Add(CustomerPrimaryCarePhysicianEntity.Relations.PhysicianMasterEntityUsingPhysicianMasterId, "CustomerPrimaryCarePhysician_", string.Empty, JoinHint.None);
					break;
				case "ProspectListDetailsCollectionViaProspects":
					toReturn.Add(AddressEntity.Relations.ProspectsEntityUsingAddressId, "AddressEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.ProspectListDetailsEntityUsingProspectListId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "ProspectsCollectionViaHostPayment":
					toReturn.Add(AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId, "AddressEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.ProspectsEntityUsingHostId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "ProspectTypeCollectionViaProspects":
					toReturn.Add(AddressEntity.Relations.ProspectsEntityUsingAddressId, "AddressEntity__", "Prospects_", JoinHint.None);
					toReturn.Add(ProspectsEntity.Relations.ProspectTypeEntityUsingProspectTypeId, "Prospects_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaCustomerProfile":
					toReturn.Add(AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId, "AddressEntity__", "CustomerProfile_", JoinHint.None);
					toReturn.Add(CustomerProfileEntity.Relations.RoleEntityUsingAddedByRoleId, "CustomerProfile_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaUser":
					toReturn.Add(AddressEntity.Relations.UserEntityUsingHomeAddressId, "AddressEntity__", "User_", JoinHint.None);
					toReturn.Add(UserEntity.Relations.RoleEntityUsingDefaultRoleId, "User_", string.Empty, JoinHint.None);
					break;
				case "ShippingOptionCollectionViaShippingDetail":
					toReturn.Add(AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId, "AddressEntity__", "ShippingDetail_", JoinHint.None);
					toReturn.Add(ShippingDetailEntity.Relations.ShippingOptionEntityUsingShippingOptionId, "ShippingDetail_", string.Empty, JoinHint.None);
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
				case "City":
					SetupSyncCity(relatedEntity);
					break;
				case "Country":
					SetupSyncCountry(relatedEntity);
					break;
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "State":
					SetupSyncState(relatedEntity);
					break;
				case "Zip":
					SetupSyncZip(relatedEntity);
					break;
				case "CustomerPrimaryCarePhysician":
					this.CustomerPrimaryCarePhysician.Add((CustomerPrimaryCarePhysicianEntity)relatedEntity);
					break;
				case "CustomerPrimaryCarePhysician_":
					this.CustomerPrimaryCarePhysician_.Add((CustomerPrimaryCarePhysicianEntity)relatedEntity);
					break;
				case "CustomerProfile":
					this.CustomerProfile.Add((CustomerProfileEntity)relatedEntity);
					break;
				case "HostPayment":
					this.HostPayment.Add((HostPaymentEntity)relatedEntity);
					break;
				case "Organization":
					this.Organization.Add((OrganizationEntity)relatedEntity);
					break;
				case "Prospects":
					this.Prospects.Add((ProspectsEntity)relatedEntity);
					break;
				case "ShippingDetail":
					this.ShippingDetail.Add((ShippingDetailEntity)relatedEntity);
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
				case "City":
					DesetupSyncCity(false, true);
					break;
				case "Country":
					DesetupSyncCountry(false, true);
					break;
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "State":
					DesetupSyncState(false, true);
					break;
				case "Zip":
					DesetupSyncZip(false, true);
					break;
				case "CustomerPrimaryCarePhysician":
					base.PerformRelatedEntityRemoval(this.CustomerPrimaryCarePhysician, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerPrimaryCarePhysician_":
					base.PerformRelatedEntityRemoval(this.CustomerPrimaryCarePhysician_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "CustomerProfile":
					base.PerformRelatedEntityRemoval(this.CustomerProfile, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostPayment":
					base.PerformRelatedEntityRemoval(this.HostPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Organization":
					base.PerformRelatedEntityRemoval(this.Organization, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Prospects":
					base.PerformRelatedEntityRemoval(this.Prospects, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ShippingDetail":
					base.PerformRelatedEntityRemoval(this.ShippingDetail, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_city!=null)
			{
				toReturn.Add(_city);
			}
			if(_country!=null)
			{
				toReturn.Add(_country);
			}
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_state!=null)
			{
				toReturn.Add(_state);
			}
			if(_zip!=null)
			{
				toReturn.Add(_zip);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CustomerPrimaryCarePhysician);
			toReturn.Add(this.CustomerPrimaryCarePhysician_);
			toReturn.Add(this.CustomerProfile);
			toReturn.Add(this.HostPayment);
			toReturn.Add(this.Organization);
			toReturn.Add(this.Prospects);
			toReturn.Add(this.ShippingDetail);
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
				info.AddValue("_customerPrimaryCarePhysician", ((_customerPrimaryCarePhysician!=null) && (_customerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_customerPrimaryCarePhysician:null);
				info.AddValue("_customerPrimaryCarePhysician_", ((_customerPrimaryCarePhysician_!=null) && (_customerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_customerPrimaryCarePhysician_:null);
				info.AddValue("_customerProfile", ((_customerProfile!=null) && (_customerProfile.Count>0) && !this.MarkedForDeletion)?_customerProfile:null);
				info.AddValue("_hostPayment", ((_hostPayment!=null) && (_hostPayment.Count>0) && !this.MarkedForDeletion)?_hostPayment:null);
				info.AddValue("_organization", ((_organization!=null) && (_organization.Count>0) && !this.MarkedForDeletion)?_organization:null);
				info.AddValue("_prospects", ((_prospects!=null) && (_prospects.Count>0) && !this.MarkedForDeletion)?_prospects:null);
				info.AddValue("_shippingDetail", ((_shippingDetail!=null) && (_shippingDetail.Count>0) && !this.MarkedForDeletion)?_shippingDetail:null);
				info.AddValue("_user", ((_user!=null) && (_user.Count>0) && !this.MarkedForDeletion)?_user:null);
				info.AddValue("_activityTypeCollectionViaCustomerProfile", ((_activityTypeCollectionViaCustomerProfile!=null) && (_activityTypeCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_activityTypeCollectionViaCustomerProfile:null);
				info.AddValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician_", ((_customerProfileCollectionViaCustomerPrimaryCarePhysician_!=null) && (_customerProfileCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_customerProfileCollectionViaCustomerPrimaryCarePhysician", ((_customerProfileCollectionViaCustomerPrimaryCarePhysician!=null) && (_customerProfileCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_customerProfileCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_eventsCollectionViaHostPayment", ((_eventsCollectionViaHostPayment!=null) && (_eventsCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaHostPayment:null);
				info.AddValue("_fileCollectionViaOrganization", ((_fileCollectionViaOrganization!=null) && (_fileCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaOrganization:null);
				info.AddValue("_fileCollectionViaOrganization_", ((_fileCollectionViaOrganization_!=null) && (_fileCollectionViaOrganization_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaOrganization_:null);
				info.AddValue("_labCollectionViaCustomerProfile", ((_labCollectionViaCustomerProfile!=null) && (_labCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_labCollectionViaCustomerProfile:null);
				info.AddValue("_languageCollectionViaCustomerProfile", ((_languageCollectionViaCustomerProfile!=null) && (_languageCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_languageCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile____", ((_lookupCollectionViaCustomerProfile____!=null) && (_lookupCollectionViaCustomerProfile____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile___", ((_lookupCollectionViaCustomerProfile___!=null) && (_lookupCollectionViaCustomerProfile___.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile___:null);
				info.AddValue("_lookupCollectionViaCustomerProfile__", ((_lookupCollectionViaCustomerProfile__!=null) && (_lookupCollectionViaCustomerProfile__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile__:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_______", ((_lookupCollectionViaCustomerProfile_______!=null) && (_lookupCollectionViaCustomerProfile_______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_______:null);
				info.AddValue("_lookupCollectionViaHostPayment__", ((_lookupCollectionViaHostPayment__!=null) && (_lookupCollectionViaHostPayment__.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPayment__:null);
				info.AddValue("_lookupCollectionViaHostPayment", ((_lookupCollectionViaHostPayment!=null) && (_lookupCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPayment:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_____", ((_lookupCollectionViaCustomerProfile_____!=null) && (_lookupCollectionViaCustomerProfile_____.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_____:null);
				info.AddValue("_lookupCollectionViaCustomerProfile______", ((_lookupCollectionViaCustomerProfile______!=null) && (_lookupCollectionViaCustomerProfile______.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile______:null);
				info.AddValue("_lookupCollectionViaCustomerProfile________", ((_lookupCollectionViaCustomerProfile________!=null) && (_lookupCollectionViaCustomerProfile________.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile________:null);
				info.AddValue("_lookupCollectionViaCustomerPrimaryCarePhysician_", ((_lookupCollectionViaCustomerPrimaryCarePhysician_!=null) && (_lookupCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_lookupCollectionViaCustomerPrimaryCarePhysician", ((_lookupCollectionViaCustomerPrimaryCarePhysician!=null) && (_lookupCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_lookupCollectionViaCustomerProfile", ((_lookupCollectionViaCustomerProfile!=null) && (_lookupCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile:null);
				info.AddValue("_lookupCollectionViaCustomerProfile_", ((_lookupCollectionViaCustomerProfile_!=null) && (_lookupCollectionViaCustomerProfile_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaCustomerProfile_:null);
				info.AddValue("_notesDetailsCollectionViaCustomerProfile", ((_notesDetailsCollectionViaCustomerProfile!=null) && (_notesDetailsCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_notesDetailsCollectionViaCustomerProfile:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__:null);
				info.AddValue("_organizationRoleUserCollectionViaHostPayment", ((_organizationRoleUserCollectionViaHostPayment!=null) && (_organizationRoleUserCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHostPayment:null);
				info.AddValue("_organizationRoleUserCollectionViaUser", ((_organizationRoleUserCollectionViaUser!=null) && (_organizationRoleUserCollectionViaUser.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaUser:null);
				info.AddValue("_organizationRoleUserCollectionViaUser_", ((_organizationRoleUserCollectionViaUser_!=null) && (_organizationRoleUserCollectionViaUser_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaUser_:null);
				info.AddValue("_organizationRoleUserCollectionViaShippingDetail_", ((_organizationRoleUserCollectionViaShippingDetail_!=null) && (_organizationRoleUserCollectionViaShippingDetail_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaShippingDetail_:null);
				info.AddValue("_organizationRoleUserCollectionViaProspects", ((_organizationRoleUserCollectionViaProspects!=null) && (_organizationRoleUserCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaProspects:null);
				info.AddValue("_organizationRoleUserCollectionViaShippingDetail", ((_organizationRoleUserCollectionViaShippingDetail!=null) && (_organizationRoleUserCollectionViaShippingDetail.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaShippingDetail:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____", ((_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____!=null) && (_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____:null);
				info.AddValue("_organizationTypeCollectionViaOrganization", ((_organizationTypeCollectionViaOrganization!=null) && (_organizationTypeCollectionViaOrganization.Count>0) && !this.MarkedForDeletion)?_organizationTypeCollectionViaOrganization:null);
				info.AddValue("_physicianMasterCollectionViaCustomerPrimaryCarePhysician_", ((_physicianMasterCollectionViaCustomerPrimaryCarePhysician_!=null) && (_physicianMasterCollectionViaCustomerPrimaryCarePhysician_.Count>0) && !this.MarkedForDeletion)?_physicianMasterCollectionViaCustomerPrimaryCarePhysician_:null);
				info.AddValue("_physicianMasterCollectionViaCustomerPrimaryCarePhysician", ((_physicianMasterCollectionViaCustomerPrimaryCarePhysician!=null) && (_physicianMasterCollectionViaCustomerPrimaryCarePhysician.Count>0) && !this.MarkedForDeletion)?_physicianMasterCollectionViaCustomerPrimaryCarePhysician:null);
				info.AddValue("_prospectListDetailsCollectionViaProspects", ((_prospectListDetailsCollectionViaProspects!=null) && (_prospectListDetailsCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_prospectListDetailsCollectionViaProspects:null);
				info.AddValue("_prospectsCollectionViaHostPayment", ((_prospectsCollectionViaHostPayment!=null) && (_prospectsCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_prospectsCollectionViaHostPayment:null);
				info.AddValue("_prospectTypeCollectionViaProspects", ((_prospectTypeCollectionViaProspects!=null) && (_prospectTypeCollectionViaProspects.Count>0) && !this.MarkedForDeletion)?_prospectTypeCollectionViaProspects:null);
				info.AddValue("_roleCollectionViaCustomerProfile", ((_roleCollectionViaCustomerProfile!=null) && (_roleCollectionViaCustomerProfile.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaCustomerProfile:null);
				info.AddValue("_roleCollectionViaUser", ((_roleCollectionViaUser!=null) && (_roleCollectionViaUser.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaUser:null);
				info.AddValue("_shippingOptionCollectionViaShippingDetail", ((_shippingOptionCollectionViaShippingDetail!=null) && (_shippingOptionCollectionViaShippingDetail.Count>0) && !this.MarkedForDeletion)?_shippingOptionCollectionViaShippingDetail:null);
				info.AddValue("_city", (!this.MarkedForDeletion?_city:null));
				info.AddValue("_country", (!this.MarkedForDeletion?_country:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_state", (!this.MarkedForDeletion?_state:null));
				info.AddValue("_zip", (!this.MarkedForDeletion?_zip:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(AddressFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(AddressFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new AddressRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerPrimaryCarePhysicianFields.Pcpaddress, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerPrimaryCarePhysician' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerPrimaryCarePhysicianFields.MailingAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CustomerProfileFields.BillingAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentFields.MailingAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Organization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.BusinessAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingDetail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShippingDetailFields.ShippingAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UserFields.HomeAddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActivityType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActivityTypeCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ActivityTypeCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CustomerProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCustomerProfileCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CustomerProfileCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lab' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLabCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LabCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Language' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPayment__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPayment__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaCustomerProfile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaCustomerProfile_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NotesDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNotesDetailsCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NotesDetailsCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaUser_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaUser_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaShippingDetail_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaShippingDetail_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaShippingDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationTypeCollectionViaOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationTypeCollectionViaOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianMaster' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianMasterCollectionViaCustomerPrimaryCarePhysician_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PhysicianMaster' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPhysicianMasterCollectionViaCustomerPrimaryCarePhysician()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectListDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectListDetailsCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectListDetailsCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Prospects' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectsCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectsCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectTypeCollectionViaProspects()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ProspectTypeCollectionViaProspects"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaCustomerProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaCustomerProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShippingOption' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShippingOptionCollectionViaShippingDetail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ShippingOptionCollectionViaShippingDetail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId, "AddressEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'City' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCity()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CityFields.CityId, null, ComparisonOperator.Equal, this.CityId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Country' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountry()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryFields.CountryId, null, ComparisonOperator.Equal, this.CountryId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.VerificationOrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'State' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoState()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(StateFields.StateId, null, ComparisonOperator.Equal, this.StateId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Zip' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoZip()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ZipFields.ZipId, null, ComparisonOperator.Equal, this.ZipId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.AddressEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._customerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._customerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._customerProfile);
			collectionsQueue.Enqueue(this._hostPayment);
			collectionsQueue.Enqueue(this._organization);
			collectionsQueue.Enqueue(this._prospects);
			collectionsQueue.Enqueue(this._shippingDetail);
			collectionsQueue.Enqueue(this._user);
			collectionsQueue.Enqueue(this._activityTypeCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._customerProfileCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._eventsCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._fileCollectionViaOrganization);
			collectionsQueue.Enqueue(this._fileCollectionViaOrganization_);
			collectionsQueue.Enqueue(this._labCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._languageCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile___);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile__);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_______);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPayment__);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_____);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile______);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile________);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._lookupCollectionViaCustomerProfile_);
			collectionsQueue.Enqueue(this._notesDetailsCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaUser);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaUser_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaShippingDetail_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaProspects);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaShippingDetail);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____);
			collectionsQueue.Enqueue(this._organizationTypeCollectionViaOrganization);
			collectionsQueue.Enqueue(this._physicianMasterCollectionViaCustomerPrimaryCarePhysician_);
			collectionsQueue.Enqueue(this._physicianMasterCollectionViaCustomerPrimaryCarePhysician);
			collectionsQueue.Enqueue(this._prospectListDetailsCollectionViaProspects);
			collectionsQueue.Enqueue(this._prospectsCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._prospectTypeCollectionViaProspects);
			collectionsQueue.Enqueue(this._roleCollectionViaCustomerProfile);
			collectionsQueue.Enqueue(this._roleCollectionViaUser);
			collectionsQueue.Enqueue(this._shippingOptionCollectionViaShippingDetail);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._customerPrimaryCarePhysician = (EntityCollection<CustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._customerPrimaryCarePhysician_ = (EntityCollection<CustomerPrimaryCarePhysicianEntity>) collectionsQueue.Dequeue();
			this._customerProfile = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._hostPayment = (EntityCollection<HostPaymentEntity>) collectionsQueue.Dequeue();
			this._organization = (EntityCollection<OrganizationEntity>) collectionsQueue.Dequeue();
			this._prospects = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._shippingDetail = (EntityCollection<ShippingDetailEntity>) collectionsQueue.Dequeue();
			this._user = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
			this._activityTypeCollectionViaCustomerProfile = (EntityCollection<ActivityTypeEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._customerProfileCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<CustomerProfileEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaHostPayment = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaOrganization = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaOrganization_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._labCollectionViaCustomerProfile = (EntityCollection<LabEntity>) collectionsQueue.Dequeue();
			this._languageCollectionViaCustomerProfile = (EntityCollection<LanguageEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile___ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPayment__ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPayment = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_____ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile______ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile________ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaCustomerProfile_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._notesDetailsCollectionViaCustomerProfile = (EntityCollection<NotesDetailsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHostPayment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaUser = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaUser_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaShippingDetail_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaProspects = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaShippingDetail = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationTypeCollectionViaOrganization = (EntityCollection<OrganizationTypeEntity>) collectionsQueue.Dequeue();
			this._physicianMasterCollectionViaCustomerPrimaryCarePhysician_ = (EntityCollection<PhysicianMasterEntity>) collectionsQueue.Dequeue();
			this._physicianMasterCollectionViaCustomerPrimaryCarePhysician = (EntityCollection<PhysicianMasterEntity>) collectionsQueue.Dequeue();
			this._prospectListDetailsCollectionViaProspects = (EntityCollection<ProspectListDetailsEntity>) collectionsQueue.Dequeue();
			this._prospectsCollectionViaHostPayment = (EntityCollection<ProspectsEntity>) collectionsQueue.Dequeue();
			this._prospectTypeCollectionViaProspects = (EntityCollection<ProspectTypeEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaCustomerProfile = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaUser = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._shippingOptionCollectionViaShippingDetail = (EntityCollection<ShippingOptionEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._customerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._customerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._customerProfile != null)
			{
				return true;
			}
			if (this._hostPayment != null)
			{
				return true;
			}
			if (this._organization != null)
			{
				return true;
			}
			if (this._prospects != null)
			{
				return true;
			}
			if (this._shippingDetail != null)
			{
				return true;
			}
			if (this._user != null)
			{
				return true;
			}
			if (this._activityTypeCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._customerProfileCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._eventsCollectionViaHostPayment != null)
			{
				return true;
			}
			if (this._fileCollectionViaOrganization != null)
			{
				return true;
			}
			if (this._fileCollectionViaOrganization_ != null)
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
			if (this._lookupCollectionViaCustomerProfile____ != null)
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
			if (this._lookupCollectionViaCustomerProfile_______ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPayment__ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPayment != null)
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
			if (this._lookupCollectionViaCustomerProfile________ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._lookupCollectionViaCustomerProfile_ != null)
			{
				return true;
			}
			if (this._notesDetailsCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHostPayment != null)
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
			if (this._organizationRoleUserCollectionViaShippingDetail_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaProspects != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaShippingDetail != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ != null)
			{
				return true;
			}
			if (this._organizationTypeCollectionViaOrganization != null)
			{
				return true;
			}
			if (this._physicianMasterCollectionViaCustomerPrimaryCarePhysician_ != null)
			{
				return true;
			}
			if (this._physicianMasterCollectionViaCustomerPrimaryCarePhysician != null)
			{
				return true;
			}
			if (this._prospectListDetailsCollectionViaProspects != null)
			{
				return true;
			}
			if (this._prospectsCollectionViaHostPayment != null)
			{
				return true;
			}
			if (this._prospectTypeCollectionViaProspects != null)
			{
				return true;
			}
			if (this._roleCollectionViaCustomerProfile != null)
			{
				return true;
			}
			if (this._roleCollectionViaUser != null)
			{
				return true;
			}
			if (this._shippingOptionCollectionViaShippingDetail != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("City", _city);
			toReturn.Add("Country", _country);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("State", _state);
			toReturn.Add("Zip", _zip);
			toReturn.Add("CustomerPrimaryCarePhysician", _customerPrimaryCarePhysician);
			toReturn.Add("CustomerPrimaryCarePhysician_", _customerPrimaryCarePhysician_);
			toReturn.Add("CustomerProfile", _customerProfile);
			toReturn.Add("HostPayment", _hostPayment);
			toReturn.Add("Organization", _organization);
			toReturn.Add("Prospects", _prospects);
			toReturn.Add("ShippingDetail", _shippingDetail);
			toReturn.Add("User", _user);
			toReturn.Add("ActivityTypeCollectionViaCustomerProfile", _activityTypeCollectionViaCustomerProfile);
			toReturn.Add("CustomerProfileCollectionViaCustomerPrimaryCarePhysician_", _customerProfileCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("CustomerProfileCollectionViaCustomerPrimaryCarePhysician", _customerProfileCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("EventsCollectionViaHostPayment", _eventsCollectionViaHostPayment);
			toReturn.Add("FileCollectionViaOrganization", _fileCollectionViaOrganization);
			toReturn.Add("FileCollectionViaOrganization_", _fileCollectionViaOrganization_);
			toReturn.Add("LabCollectionViaCustomerProfile", _labCollectionViaCustomerProfile);
			toReturn.Add("LanguageCollectionViaCustomerProfile", _languageCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile____", _lookupCollectionViaCustomerProfile____);
			toReturn.Add("LookupCollectionViaCustomerProfile___", _lookupCollectionViaCustomerProfile___);
			toReturn.Add("LookupCollectionViaCustomerProfile__", _lookupCollectionViaCustomerProfile__);
			toReturn.Add("LookupCollectionViaCustomerProfile_______", _lookupCollectionViaCustomerProfile_______);
			toReturn.Add("LookupCollectionViaHostPayment__", _lookupCollectionViaHostPayment__);
			toReturn.Add("LookupCollectionViaHostPayment", _lookupCollectionViaHostPayment);
			toReturn.Add("LookupCollectionViaCustomerProfile_____", _lookupCollectionViaCustomerProfile_____);
			toReturn.Add("LookupCollectionViaCustomerProfile______", _lookupCollectionViaCustomerProfile______);
			toReturn.Add("LookupCollectionViaCustomerProfile________", _lookupCollectionViaCustomerProfile________);
			toReturn.Add("LookupCollectionViaCustomerPrimaryCarePhysician_", _lookupCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("LookupCollectionViaCustomerPrimaryCarePhysician", _lookupCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("LookupCollectionViaCustomerProfile", _lookupCollectionViaCustomerProfile);
			toReturn.Add("LookupCollectionViaCustomerProfile_", _lookupCollectionViaCustomerProfile_);
			toReturn.Add("NotesDetailsCollectionViaCustomerProfile", _notesDetailsCollectionViaCustomerProfile);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__);
			toReturn.Add("OrganizationRoleUserCollectionViaHostPayment", _organizationRoleUserCollectionViaHostPayment);
			toReturn.Add("OrganizationRoleUserCollectionViaUser", _organizationRoleUserCollectionViaUser);
			toReturn.Add("OrganizationRoleUserCollectionViaUser_", _organizationRoleUserCollectionViaUser_);
			toReturn.Add("OrganizationRoleUserCollectionViaShippingDetail_", _organizationRoleUserCollectionViaShippingDetail_);
			toReturn.Add("OrganizationRoleUserCollectionViaProspects", _organizationRoleUserCollectionViaProspects);
			toReturn.Add("OrganizationRoleUserCollectionViaShippingDetail", _organizationRoleUserCollectionViaShippingDetail);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____", _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____);
			toReturn.Add("OrganizationTypeCollectionViaOrganization", _organizationTypeCollectionViaOrganization);
			toReturn.Add("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_", _physicianMasterCollectionViaCustomerPrimaryCarePhysician_);
			toReturn.Add("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician", _physicianMasterCollectionViaCustomerPrimaryCarePhysician);
			toReturn.Add("ProspectListDetailsCollectionViaProspects", _prospectListDetailsCollectionViaProspects);
			toReturn.Add("ProspectsCollectionViaHostPayment", _prospectsCollectionViaHostPayment);
			toReturn.Add("ProspectTypeCollectionViaProspects", _prospectTypeCollectionViaProspects);
			toReturn.Add("RoleCollectionViaCustomerProfile", _roleCollectionViaCustomerProfile);
			toReturn.Add("RoleCollectionViaUser", _roleCollectionViaUser);
			toReturn.Add("ShippingOptionCollectionViaShippingDetail", _shippingOptionCollectionViaShippingDetail);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_customerPrimaryCarePhysician!=null)
			{
				_customerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_customerPrimaryCarePhysician_!=null)
			{
				_customerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_customerProfile!=null)
			{
				_customerProfile.ActiveContext = base.ActiveContext;
			}
			if(_hostPayment!=null)
			{
				_hostPayment.ActiveContext = base.ActiveContext;
			}
			if(_organization!=null)
			{
				_organization.ActiveContext = base.ActiveContext;
			}
			if(_prospects!=null)
			{
				_prospects.ActiveContext = base.ActiveContext;
			}
			if(_shippingDetail!=null)
			{
				_shippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_user!=null)
			{
				_user.ActiveContext = base.ActiveContext;
			}
			if(_activityTypeCollectionViaCustomerProfile!=null)
			{
				_activityTypeCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_customerProfileCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_customerProfileCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_customerProfileCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaHostPayment!=null)
			{
				_eventsCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaOrganization!=null)
			{
				_fileCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaOrganization_!=null)
			{
				_fileCollectionViaOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_labCollectionViaCustomerProfile!=null)
			{
				_labCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_languageCollectionViaCustomerProfile!=null)
			{
				_languageCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile____!=null)
			{
				_lookupCollectionViaCustomerProfile____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile___!=null)
			{
				_lookupCollectionViaCustomerProfile___.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile__!=null)
			{
				_lookupCollectionViaCustomerProfile__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_______!=null)
			{
				_lookupCollectionViaCustomerProfile_______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPayment__!=null)
			{
				_lookupCollectionViaHostPayment__.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPayment!=null)
			{
				_lookupCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_____!=null)
			{
				_lookupCollectionViaCustomerProfile_____.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile______!=null)
			{
				_lookupCollectionViaCustomerProfile______.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile________!=null)
			{
				_lookupCollectionViaCustomerProfile________.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_lookupCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_lookupCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile!=null)
			{
				_lookupCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaCustomerProfile_!=null)
			{
				_lookupCollectionViaCustomerProfile_.ActiveContext = base.ActiveContext;
			}
			if(_notesDetailsCollectionViaCustomerProfile!=null)
			{
				_notesDetailsCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHostPayment!=null)
			{
				_organizationRoleUserCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaUser!=null)
			{
				_organizationRoleUserCollectionViaUser.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaUser_!=null)
			{
				_organizationRoleUserCollectionViaUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaShippingDetail_!=null)
			{
				_organizationRoleUserCollectionViaShippingDetail_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaProspects!=null)
			{
				_organizationRoleUserCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaShippingDetail!=null)
			{
				_organizationRoleUserCollectionViaShippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____!=null)
			{
				_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.ActiveContext = base.ActiveContext;
			}
			if(_organizationTypeCollectionViaOrganization!=null)
			{
				_organizationTypeCollectionViaOrganization.ActiveContext = base.ActiveContext;
			}
			if(_physicianMasterCollectionViaCustomerPrimaryCarePhysician_!=null)
			{
				_physicianMasterCollectionViaCustomerPrimaryCarePhysician_.ActiveContext = base.ActiveContext;
			}
			if(_physicianMasterCollectionViaCustomerPrimaryCarePhysician!=null)
			{
				_physicianMasterCollectionViaCustomerPrimaryCarePhysician.ActiveContext = base.ActiveContext;
			}
			if(_prospectListDetailsCollectionViaProspects!=null)
			{
				_prospectListDetailsCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_prospectsCollectionViaHostPayment!=null)
			{
				_prospectsCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_prospectTypeCollectionViaProspects!=null)
			{
				_prospectTypeCollectionViaProspects.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaCustomerProfile!=null)
			{
				_roleCollectionViaCustomerProfile.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaUser!=null)
			{
				_roleCollectionViaUser.ActiveContext = base.ActiveContext;
			}
			if(_shippingOptionCollectionViaShippingDetail!=null)
			{
				_shippingOptionCollectionViaShippingDetail.ActiveContext = base.ActiveContext;
			}
			if(_city!=null)
			{
				_city.ActiveContext = base.ActiveContext;
			}
			if(_country!=null)
			{
				_country.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_state!=null)
			{
				_state.ActiveContext = base.ActiveContext;
			}
			if(_zip!=null)
			{
				_zip.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_customerPrimaryCarePhysician = null;
			_customerPrimaryCarePhysician_ = null;
			_customerProfile = null;
			_hostPayment = null;
			_organization = null;
			_prospects = null;
			_shippingDetail = null;
			_user = null;
			_activityTypeCollectionViaCustomerProfile = null;
			_customerProfileCollectionViaCustomerPrimaryCarePhysician_ = null;
			_customerProfileCollectionViaCustomerPrimaryCarePhysician = null;
			_eventsCollectionViaHostPayment = null;
			_fileCollectionViaOrganization = null;
			_fileCollectionViaOrganization_ = null;
			_labCollectionViaCustomerProfile = null;
			_languageCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile____ = null;
			_lookupCollectionViaCustomerProfile___ = null;
			_lookupCollectionViaCustomerProfile__ = null;
			_lookupCollectionViaCustomerProfile_______ = null;
			_lookupCollectionViaHostPayment__ = null;
			_lookupCollectionViaHostPayment = null;
			_lookupCollectionViaCustomerProfile_____ = null;
			_lookupCollectionViaCustomerProfile______ = null;
			_lookupCollectionViaCustomerProfile________ = null;
			_lookupCollectionViaCustomerPrimaryCarePhysician_ = null;
			_lookupCollectionViaCustomerPrimaryCarePhysician = null;
			_lookupCollectionViaCustomerProfile = null;
			_lookupCollectionViaCustomerProfile_ = null;
			_notesDetailsCollectionViaCustomerProfile = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = null;
			_organizationRoleUserCollectionViaHostPayment = null;
			_organizationRoleUserCollectionViaUser = null;
			_organizationRoleUserCollectionViaUser_ = null;
			_organizationRoleUserCollectionViaShippingDetail_ = null;
			_organizationRoleUserCollectionViaProspects = null;
			_organizationRoleUserCollectionViaShippingDetail = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = null;
			_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ = null;
			_organizationTypeCollectionViaOrganization = null;
			_physicianMasterCollectionViaCustomerPrimaryCarePhysician_ = null;
			_physicianMasterCollectionViaCustomerPrimaryCarePhysician = null;
			_prospectListDetailsCollectionViaProspects = null;
			_prospectsCollectionViaHostPayment = null;
			_prospectTypeCollectionViaProspects = null;
			_roleCollectionViaCustomerProfile = null;
			_roleCollectionViaUser = null;
			_shippingOptionCollectionViaShippingDetail = null;
			_city = null;
			_country = null;
			_organizationRoleUser = null;
			_state = null;
			_zip = null;

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

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Address2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CityId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StateId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CountryId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Latitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Longitude", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VerificationOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsManuallyVerified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("UseLatLogForMapping", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NeedVerification", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _city</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCity(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", AddressEntity.Relations.CityEntityUsingCityId, true, signalRelatedEntity, "Address", resetFKFields, new int[] { (int)AddressFieldIndex.CityId } );		
			_city = null;
		}

		/// <summary> setups the sync logic for member _city</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCity(IEntity2 relatedEntity)
		{
			if(_city!=relatedEntity)
			{
				DesetupSyncCity(true, true);
				_city = (CityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _city, new PropertyChangedEventHandler( OnCityPropertyChanged ), "City", AddressEntity.Relations.CityEntityUsingCityId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _country</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCountry(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _country, new PropertyChangedEventHandler( OnCountryPropertyChanged ), "Country", AddressEntity.Relations.CountryEntityUsingCountryId, true, signalRelatedEntity, "Address", resetFKFields, new int[] { (int)AddressFieldIndex.CountryId } );		
			_country = null;
		}

		/// <summary> setups the sync logic for member _country</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCountry(IEntity2 relatedEntity)
		{
			if(_country!=relatedEntity)
			{
				DesetupSyncCountry(true, true);
				_country = (CountryEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _country, new PropertyChangedEventHandler( OnCountryPropertyChanged ), "Country", AddressEntity.Relations.CountryEntityUsingCountryId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCountryPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId, true, signalRelatedEntity, "Address", resetFKFields, new int[] { (int)AddressFieldIndex.VerificationOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", AddressEntity.Relations.OrganizationRoleUserEntityUsingVerificationOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _state</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncState(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _state, new PropertyChangedEventHandler( OnStatePropertyChanged ), "State", AddressEntity.Relations.StateEntityUsingStateId, true, signalRelatedEntity, "Address", resetFKFields, new int[] { (int)AddressFieldIndex.StateId } );		
			_state = null;
		}

		/// <summary> setups the sync logic for member _state</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncState(IEntity2 relatedEntity)
		{
			if(_state!=relatedEntity)
			{
				DesetupSyncState(true, true);
				_state = (StateEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _state, new PropertyChangedEventHandler( OnStatePropertyChanged ), "State", AddressEntity.Relations.StateEntityUsingStateId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnStatePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _zip</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncZip(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _zip, new PropertyChangedEventHandler( OnZipPropertyChanged ), "Zip", AddressEntity.Relations.ZipEntityUsingZipId, true, signalRelatedEntity, "Address", resetFKFields, new int[] { (int)AddressFieldIndex.ZipId } );		
			_zip = null;
		}

		/// <summary> setups the sync logic for member _zip</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncZip(IEntity2 relatedEntity)
		{
			if(_zip!=relatedEntity)
			{
				DesetupSyncZip(true, true);
				_zip = (ZipEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _zip, new PropertyChangedEventHandler( OnZipPropertyChanged ), "Zip", AddressEntity.Relations.ZipEntityUsingZipId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnZipPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this AddressEntity</param>
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
		public  static AddressRelations Relations
		{
			get	{ return new AddressRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerPrimaryCarePhysician
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerPrimaryCarePhysician")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, 0, null, null, null, null, "CustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerPrimaryCarePhysician' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerPrimaryCarePhysician_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory))),
					(IEntityRelation)GetRelationsForField("CustomerPrimaryCarePhysician_")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CustomerPrimaryCarePhysicianEntity, 0, null, null, null, null, "CustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("CustomerProfile")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, null, null, "CustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostPayment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostPayment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostPayment")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.HostPaymentEntity, 0, null, null, null, null, "HostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Organization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("Organization")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationEntity, 0, null, null, null, null, "Organization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspects
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))),
					(IEntityRelation)GetRelationsForField("Prospects")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, null, null, "Prospects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingDetail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingDetail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory))),
					(IEntityRelation)GetRelationsForField("ShippingDetail")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ShippingDetailEntity, 0, null, null, null, null, "ShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("User")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.UserEntity, 0, null, null, null, null, "User", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActivityType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActivityTypeCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<ActivityTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActivityTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ActivityTypeEntity, 0, null, null, GetRelationsForField("ActivityTypeCollectionViaCustomerProfile"), null, "ActivityTypeCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerPrimaryCarePhysician_"), null, "CustomerProfileCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CustomerProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCustomerProfileCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CustomerProfileEntity, 0, null, null, GetRelationsForField("CustomerProfileCollectionViaCustomerPrimaryCarePhysician"), null, "CustomerProfileCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaHostPayment"), null, "EventsCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaOrganization"), null, "FileCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaOrganization_"), null, "FileCollectionViaOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lab' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLabCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LabEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LabEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LabEntity, 0, null, null, GetRelationsForField("LabCollectionViaCustomerProfile"), null, "LabCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Language' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LanguageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, GetRelationsForField("LanguageCollectionViaCustomerProfile"), null, "LanguageCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile____
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile____"), null, "LookupCollectionViaCustomerProfile____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile___
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile___"), null, "LookupCollectionViaCustomerProfile___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile__
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile__"), null, "LookupCollectionViaCustomerProfile__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_______
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_______"), null, "LookupCollectionViaCustomerProfile_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPayment__
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPayment__"), null, "LookupCollectionViaHostPayment__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPayment"), null, "LookupCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_____
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_____"), null, "LookupCollectionViaCustomerProfile_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile______
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile______"), null, "LookupCollectionViaCustomerProfile______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile________
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile________"), null, "LookupCollectionViaCustomerProfile________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerPrimaryCarePhysician_"), null, "LookupCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerPrimaryCarePhysician"), null, "LookupCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile"), null, "LookupCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaCustomerProfile_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaCustomerProfile_"), null, "LookupCollectionViaCustomerProfile_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NotesDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNotesDetailsCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<NotesDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NotesDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.NotesDetailsEntity, 0, null, null, GetRelationsForField("NotesDetailsCollectionViaCustomerProfile"), null, "NotesDetailsCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHostPayment"), null, "OrganizationRoleUserCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaUser
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.UserEntityUsingHomeAddressId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaUser"), null, "OrganizationRoleUserCollectionViaUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaUser_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.UserEntityUsingHomeAddressId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaUser_"), null, "OrganizationRoleUserCollectionViaUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaShippingDetail_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaShippingDetail_"), null, "OrganizationRoleUserCollectionViaShippingDetail_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ProspectsEntityUsingAddressId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaProspects"), null, "OrganizationRoleUserCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaShippingDetail
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaShippingDetail"), null, "OrganizationRoleUserCollectionViaShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____"), null, "OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationTypeCollectionViaOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.OrganizationEntityUsingBusinessAddressId;
				intermediateRelation.SetAliases(string.Empty, "Organization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, GetRelationsForField("OrganizationTypeCollectionViaOrganization"), null, "OrganizationTypeCollectionViaOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianMaster' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianMasterCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.PhysicianMasterEntity, 0, null, null, GetRelationsForField("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_"), null, "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PhysicianMaster' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPhysicianMasterCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerPrimaryCarePhysicianEntityUsingPcpaddress;
				intermediateRelation.SetAliases(string.Empty, "CustomerPrimaryCarePhysician_");
				return new PrefetchPathElement2(new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.PhysicianMasterEntity, 0, null, null, GetRelationsForField("PhysicianMasterCollectionViaCustomerPrimaryCarePhysician"), null, "PhysicianMasterCollectionViaCustomerPrimaryCarePhysician", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectListDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectListDetailsCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ProspectsEntityUsingAddressId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ProspectListDetailsEntity, 0, null, null, GetRelationsForField("ProspectListDetailsCollectionViaProspects"), null, "ProspectListDetailsCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Prospects' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectsCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.HostPaymentEntityUsingMailingAddressId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ProspectsEntity, 0, null, null, GetRelationsForField("ProspectsCollectionViaHostPayment"), null, "ProspectsCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectTypeCollectionViaProspects
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ProspectsEntityUsingAddressId;
				intermediateRelation.SetAliases(string.Empty, "Prospects_");
				return new PrefetchPathElement2(new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ProspectTypeEntity, 0, null, null, GetRelationsForField("ProspectTypeCollectionViaProspects"), null, "ProspectTypeCollectionViaProspects", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaCustomerProfile
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.CustomerProfileEntityUsingBillingAddressId;
				intermediateRelation.SetAliases(string.Empty, "CustomerProfile_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaCustomerProfile"), null, "RoleCollectionViaCustomerProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaUser
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.UserEntityUsingHomeAddressId;
				intermediateRelation.SetAliases(string.Empty, "User_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaUser"), null, "RoleCollectionViaUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShippingOption' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShippingOptionCollectionViaShippingDetail
		{
			get
			{
				IEntityRelation intermediateRelation = AddressEntity.Relations.ShippingDetailEntityUsingShippingAddressId;
				intermediateRelation.SetAliases(string.Empty, "ShippingDetail_");
				return new PrefetchPathElement2(new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ShippingOptionEntity, 0, null, null, GetRelationsForField("ShippingOptionCollectionViaShippingDetail"), null, "ShippingOptionCollectionViaShippingDetail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'City' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCity
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CityEntityFactory))),
					(IEntityRelation)GetRelationsForField("City")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CityEntity, 0, null, null, null, null, "City", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Country' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountry
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CountryEntityFactory))),
					(IEntityRelation)GetRelationsForField("Country")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.CountryEntity, 0, null, null, null, null, "Country", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'State' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathState
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(StateEntityFactory))),
					(IEntityRelation)GetRelationsForField("State")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.StateEntity, 0, null, null, null, null, "State", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Zip' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathZip
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ZipEntityFactory))),
					(IEntityRelation)GetRelationsForField("Zip")[0], (int)Falcon.Data.EntityType.AddressEntity, (int)Falcon.Data.EntityType.ZipEntity, 0, null, null, null, null, "Zip", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return AddressEntity.CustomProperties;}
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
			get { return AddressEntity.FieldsCustomProperties;}
		}

		/// <summary> The AddressId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."AddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 AddressId
		{
			get { return (System.Int64)GetValue((int)AddressFieldIndex.AddressId, true); }
			set	{ SetValue((int)AddressFieldIndex.AddressId, value); }
		}

		/// <summary> The Address1 property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."Address1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Address1
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Address1, true); }
			set	{ SetValue((int)AddressFieldIndex.Address1, value); }
		}

		/// <summary> The Address2 property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."Address2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Address2
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Address2, true); }
			set	{ SetValue((int)AddressFieldIndex.Address2, value); }
		}

		/// <summary> The CityId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."CityID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CityId
		{
			get { return (System.Int64)GetValue((int)AddressFieldIndex.CityId, true); }
			set	{ SetValue((int)AddressFieldIndex.CityId, value); }
		}

		/// <summary> The StateId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."StateID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 StateId
		{
			get { return (System.Int64)GetValue((int)AddressFieldIndex.StateId, true); }
			set	{ SetValue((int)AddressFieldIndex.StateId, value); }
		}

		/// <summary> The CountryId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."CountryID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CountryId
		{
			get { return (System.Int64)GetValue((int)AddressFieldIndex.CountryId, true); }
			set	{ SetValue((int)AddressFieldIndex.CountryId, value); }
		}

		/// <summary> The ZipId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."ZipID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ZipId
		{
			get { return (System.Int64)GetValue((int)AddressFieldIndex.ZipId, true); }
			set	{ SetValue((int)AddressFieldIndex.ZipId, value); }
		}

		/// <summary> The IsActive property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)AddressFieldIndex.IsActive, true); }
			set	{ SetValue((int)AddressFieldIndex.IsActive, value); }
		}

		/// <summary> The DateCreated property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)AddressFieldIndex.DateCreated, true); }
			set	{ SetValue((int)AddressFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)AddressFieldIndex.DateModified, true); }
			set	{ SetValue((int)AddressFieldIndex.DateModified, value); }
		}

		/// <summary> The Latitude property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."Latitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Latitude
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Latitude, true); }
			set	{ SetValue((int)AddressFieldIndex.Latitude, value); }
		}

		/// <summary> The Longitude property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."Longitude"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Longitude
		{
			get { return (System.String)GetValue((int)AddressFieldIndex.Longitude, true); }
			set	{ SetValue((int)AddressFieldIndex.Longitude, value); }
		}

		/// <summary> The VerificationOrgRoleUserId property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."VerificationOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> VerificationOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)AddressFieldIndex.VerificationOrgRoleUserId, false); }
			set	{ SetValue((int)AddressFieldIndex.VerificationOrgRoleUserId, value); }
		}

		/// <summary> The IsManuallyVerified property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."IsManuallyVerified"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsManuallyVerified
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AddressFieldIndex.IsManuallyVerified, false); }
			set	{ SetValue((int)AddressFieldIndex.IsManuallyVerified, value); }
		}

		/// <summary> The UseLatLogForMapping property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."UseLatLogForMapping"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> UseLatLogForMapping
		{
			get { return (Nullable<System.Boolean>)GetValue((int)AddressFieldIndex.UseLatLogForMapping, false); }
			set	{ SetValue((int)AddressFieldIndex.UseLatLogForMapping, value); }
		}

		/// <summary> The NeedVerification property of the Entity Address<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblAddress"."NeedVerification"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean NeedVerification
		{
			get { return (System.Boolean)GetValue((int)AddressFieldIndex.NeedVerification, true); }
			set	{ SetValue((int)AddressFieldIndex.NeedVerification, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<CustomerPrimaryCarePhysicianEntity> CustomerPrimaryCarePhysician
		{
			get
			{
				if(_customerPrimaryCarePhysician==null)
				{
					_customerPrimaryCarePhysician = new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory)));
					_customerPrimaryCarePhysician.SetContainingEntityInfo(this, "Address");
				}
				return _customerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerPrimaryCarePhysicianEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerPrimaryCarePhysicianEntity))]
		public virtual EntityCollection<CustomerPrimaryCarePhysicianEntity> CustomerPrimaryCarePhysician_
		{
			get
			{
				if(_customerPrimaryCarePhysician_==null)
				{
					_customerPrimaryCarePhysician_ = new EntityCollection<CustomerPrimaryCarePhysicianEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerPrimaryCarePhysicianEntityFactory)));
					_customerPrimaryCarePhysician_.SetContainingEntityInfo(this, "Address_");
				}
				return _customerPrimaryCarePhysician_;
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
					_customerProfile.SetContainingEntityInfo(this, "Address");
				}
				return _customerProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostPaymentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostPaymentEntity))]
		public virtual EntityCollection<HostPaymentEntity> HostPayment
		{
			get
			{
				if(_hostPayment==null)
				{
					_hostPayment = new EntityCollection<HostPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentEntityFactory)));
					_hostPayment.SetContainingEntityInfo(this, "Address");
				}
				return _hostPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationEntity))]
		public virtual EntityCollection<OrganizationEntity> Organization
		{
			get
			{
				if(_organization==null)
				{
					_organization = new EntityCollection<OrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory)));
					_organization.SetContainingEntityInfo(this, "Address");
				}
				return _organization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> Prospects
		{
			get
			{
				if(_prospects==null)
				{
					_prospects = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospects.SetContainingEntityInfo(this, "Address");
				}
				return _prospects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingDetailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingDetailEntity))]
		public virtual EntityCollection<ShippingDetailEntity> ShippingDetail
		{
			get
			{
				if(_shippingDetail==null)
				{
					_shippingDetail = new EntityCollection<ShippingDetailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingDetailEntityFactory)));
					_shippingDetail.SetContainingEntityInfo(this, "Address");
				}
				return _shippingDetail;
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
					_user.SetContainingEntityInfo(this, "Address");
				}
				return _user;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_customerProfileCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_customerProfileCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CustomerProfileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CustomerProfileEntity))]
		public virtual EntityCollection<CustomerProfileEntity> CustomerProfileCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_customerProfileCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_customerProfileCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<CustomerProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CustomerProfileEntityFactory)));
					_customerProfileCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _customerProfileCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaHostPayment
		{
			get
			{
				if(_eventsCollectionViaHostPayment==null)
				{
					_eventsCollectionViaHostPayment = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaHostPayment.IsReadOnly=true;
				}
				return _eventsCollectionViaHostPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaOrganization
		{
			get
			{
				if(_fileCollectionViaOrganization==null)
				{
					_fileCollectionViaOrganization = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaOrganization.IsReadOnly=true;
				}
				return _fileCollectionViaOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaOrganization_
		{
			get
			{
				if(_fileCollectionViaOrganization_==null)
				{
					_fileCollectionViaOrganization_ = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaOrganization_.IsReadOnly=true;
				}
				return _fileCollectionViaOrganization_;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostPayment__
		{
			get
			{
				if(_lookupCollectionViaHostPayment__==null)
				{
					_lookupCollectionViaHostPayment__ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostPayment__.IsReadOnly=true;
				}
				return _lookupCollectionViaHostPayment__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostPayment
		{
			get
			{
				if(_lookupCollectionViaHostPayment==null)
				{
					_lookupCollectionViaHostPayment = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostPayment.IsReadOnly=true;
				}
				return _lookupCollectionViaHostPayment;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_lookupCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_lookupCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LookupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LookupEntity))]
		public virtual EntityCollection<LookupEntity> LookupCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_lookupCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_lookupCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _lookupCollectionViaCustomerPrimaryCarePhysician;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician__
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHostPayment
		{
			get
			{
				if(_organizationRoleUserCollectionViaHostPayment==null)
				{
					_organizationRoleUserCollectionViaHostPayment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHostPayment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHostPayment;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaShippingDetail_
		{
			get
			{
				if(_organizationRoleUserCollectionViaShippingDetail_==null)
				{
					_organizationRoleUserCollectionViaShippingDetail_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaShippingDetail_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaShippingDetail_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaProspects
		{
			get
			{
				if(_organizationRoleUserCollectionViaProspects==null)
				{
					_organizationRoleUserCollectionViaProspects = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaProspects.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaShippingDetail
		{
			get
			{
				if(_organizationRoleUserCollectionViaShippingDetail==null)
				{
					_organizationRoleUserCollectionViaShippingDetail = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaShippingDetail.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaShippingDetail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician___
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician____
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____
		{
			get
			{
				if(_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____==null)
				{
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaCustomerPrimaryCarePhysician_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationTypeEntity))]
		public virtual EntityCollection<OrganizationTypeEntity> OrganizationTypeCollectionViaOrganization
		{
			get
			{
				if(_organizationTypeCollectionViaOrganization==null)
				{
					_organizationTypeCollectionViaOrganization = new EntityCollection<OrganizationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationTypeEntityFactory)));
					_organizationTypeCollectionViaOrganization.IsReadOnly=true;
				}
				return _organizationTypeCollectionViaOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianMasterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianMasterEntity))]
		public virtual EntityCollection<PhysicianMasterEntity> PhysicianMasterCollectionViaCustomerPrimaryCarePhysician_
		{
			get
			{
				if(_physicianMasterCollectionViaCustomerPrimaryCarePhysician_==null)
				{
					_physicianMasterCollectionViaCustomerPrimaryCarePhysician_ = new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory)));
					_physicianMasterCollectionViaCustomerPrimaryCarePhysician_.IsReadOnly=true;
				}
				return _physicianMasterCollectionViaCustomerPrimaryCarePhysician_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PhysicianMasterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PhysicianMasterEntity))]
		public virtual EntityCollection<PhysicianMasterEntity> PhysicianMasterCollectionViaCustomerPrimaryCarePhysician
		{
			get
			{
				if(_physicianMasterCollectionViaCustomerPrimaryCarePhysician==null)
				{
					_physicianMasterCollectionViaCustomerPrimaryCarePhysician = new EntityCollection<PhysicianMasterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PhysicianMasterEntityFactory)));
					_physicianMasterCollectionViaCustomerPrimaryCarePhysician.IsReadOnly=true;
				}
				return _physicianMasterCollectionViaCustomerPrimaryCarePhysician;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectListDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectListDetailsEntity))]
		public virtual EntityCollection<ProspectListDetailsEntity> ProspectListDetailsCollectionViaProspects
		{
			get
			{
				if(_prospectListDetailsCollectionViaProspects==null)
				{
					_prospectListDetailsCollectionViaProspects = new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory)));
					_prospectListDetailsCollectionViaProspects.IsReadOnly=true;
				}
				return _prospectListDetailsCollectionViaProspects;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectsEntity))]
		public virtual EntityCollection<ProspectsEntity> ProspectsCollectionViaHostPayment
		{
			get
			{
				if(_prospectsCollectionViaHostPayment==null)
				{
					_prospectsCollectionViaHostPayment = new EntityCollection<ProspectsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory)));
					_prospectsCollectionViaHostPayment.IsReadOnly=true;
				}
				return _prospectsCollectionViaHostPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectTypeEntity))]
		public virtual EntityCollection<ProspectTypeEntity> ProspectTypeCollectionViaProspects
		{
			get
			{
				if(_prospectTypeCollectionViaProspects==null)
				{
					_prospectTypeCollectionViaProspects = new EntityCollection<ProspectTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory)));
					_prospectTypeCollectionViaProspects.IsReadOnly=true;
				}
				return _prospectTypeCollectionViaProspects;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaUser
		{
			get
			{
				if(_roleCollectionViaUser==null)
				{
					_roleCollectionViaUser = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaUser.IsReadOnly=true;
				}
				return _roleCollectionViaUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShippingOptionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShippingOptionEntity))]
		public virtual EntityCollection<ShippingOptionEntity> ShippingOptionCollectionViaShippingDetail
		{
			get
			{
				if(_shippingOptionCollectionViaShippingDetail==null)
				{
					_shippingOptionCollectionViaShippingDetail = new EntityCollection<ShippingOptionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShippingOptionEntityFactory)));
					_shippingOptionCollectionViaShippingDetail.IsReadOnly=true;
				}
				return _shippingOptionCollectionViaShippingDetail;
			}
		}

		/// <summary> Gets / sets related entity of type 'CityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CityEntity City
		{
			get
			{
				return _city;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCity(value);
				}
				else
				{
					if(value==null)
					{
						if(_city != null)
						{
							_city.UnsetRelatedEntity(this, "Address");
						}
					}
					else
					{
						if(_city!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Address");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CountryEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CountryEntity Country
		{
			get
			{
				return _country;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCountry(value);
				}
				else
				{
					if(value==null)
					{
						if(_country != null)
						{
							_country.UnsetRelatedEntity(this, "Address");
						}
					}
					else
					{
						if(_country!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Address");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Address");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Address");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'StateEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual StateEntity State
		{
			get
			{
				return _state;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncState(value);
				}
				else
				{
					if(value==null)
					{
						if(_state != null)
						{
							_state.UnsetRelatedEntity(this, "Address");
						}
					}
					else
					{
						if(_state!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Address");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ZipEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ZipEntity Zip
		{
			get
			{
				return _zip;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncZip(value);
				}
				else
				{
					if(value==null)
					{
						if(_zip != null)
						{
							_zip.UnsetRelatedEntity(this, "Address");
						}
					}
					else
					{
						if(_zip!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Address");
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
			get { return (int)Falcon.Data.EntityType.AddressEntity; }
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
