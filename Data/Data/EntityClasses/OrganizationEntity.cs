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
	/// Entity class which represents the entity 'Organization'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OrganizationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountCallCenterOrganizationEntity> _accountCallCenterOrganization;
		private EntityCollection<AccountTestHcpcsCodeEntity> _accountTestHcpcsCode;
		private EntityCollection<AfcampaignTemplateEntity> _afcampaignTemplate;
		private EntityCollection<AffiliateProfileEntity> _affiliateProfile;
		private EntityCollection<BlockedDaysFranchiseeEntity> _blockedDaysFranchisee;
		private EntityCollection<ContactFranchiseeAccessEntity> _contactFranchiseeAccess;
		private EntityCollection<EventAccountTestHcpcsCodeEntity> _eventAccountTestHcpcsCode;
		private EntityCollection<FranchiseeTerritoryEntity> _franchiseeTerritory;
		private EntityCollection<MarketingPrintOrderEntity> _marketingPrintOrder_;
		private EntityCollection<MarketingPrintOrderEntity> _marketingPrintOrder;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUser;
		private EntityCollection<PodDetailsEntity> _podDetails;
		private EntityCollection<ProspectListDetailsEntity> _prospectListDetails;
		private EntityCollection<ScheduleTemplateFranchiseeAccessEntity> _scheduleTemplateFranchiseeAccess;
		private EntityCollection<AccountEntity> _accountCollectionViaAccountCallCenterOrganization;
		private EntityCollection<ContactsEntity> _contactsCollectionViaContactFranchiseeAccess;
		private EntityCollection<EventsEntity> _eventsCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountCallCenterOrganization;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMarketingPrintOrder_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaMarketingPrintOrder;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountTestHcpcsCode_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountTestHcpcsCode;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAffiliateProfile;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaAccountCallCenterOrganization_;
		private EntityCollection<RoleEntity> _roleCollectionViaOrganizationRoleUser;
		private EntityCollection<ScheduleTemplateEntity> _scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess;
		private EntityCollection<TestHcpcsCodeEntity> _testHcpcsCodeCollectionViaAccountTestHcpcsCode;
		private EntityCollection<TestHcpcsCodeEntity> _testHcpcsCodeCollectionViaEventAccountTestHcpcsCode;
		private EntityCollection<UserEntity> _userCollectionViaOrganizationRoleUser;
		private EntityCollection<VanDetailsEntity> _vanDetailsCollectionViaPodDetails;
		private AddressEntity _address;
		private FileEntity _file_;
		private FileEntity _file;
		private OrganizationTypeEntity _organizationType;
		private AccountEntity _account;
		private HospitalFacilityEntity _hospitalFacility;
		private MedicalVendorProfileEntity _medicalVendorProfile;
		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static partial class MemberNames
		{
			/// <summary>Member name Address</summary>
			public static readonly string Address = "Address";
			/// <summary>Member name File_</summary>
			public static readonly string File_ = "File_";
			/// <summary>Member name File</summary>
			public static readonly string File = "File";
			/// <summary>Member name OrganizationType</summary>
			public static readonly string OrganizationType = "OrganizationType";
			/// <summary>Member name AccountCallCenterOrganization</summary>
			public static readonly string AccountCallCenterOrganization = "AccountCallCenterOrganization";
			/// <summary>Member name AccountTestHcpcsCode</summary>
			public static readonly string AccountTestHcpcsCode = "AccountTestHcpcsCode";
			/// <summary>Member name AfcampaignTemplate</summary>
			public static readonly string AfcampaignTemplate = "AfcampaignTemplate";
			/// <summary>Member name AffiliateProfile</summary>
			public static readonly string AffiliateProfile = "AffiliateProfile";
			/// <summary>Member name BlockedDaysFranchisee</summary>
			public static readonly string BlockedDaysFranchisee = "BlockedDaysFranchisee";
			/// <summary>Member name ContactFranchiseeAccess</summary>
			public static readonly string ContactFranchiseeAccess = "ContactFranchiseeAccess";
			/// <summary>Member name EventAccountTestHcpcsCode</summary>
			public static readonly string EventAccountTestHcpcsCode = "EventAccountTestHcpcsCode";
			/// <summary>Member name FranchiseeTerritory</summary>
			public static readonly string FranchiseeTerritory = "FranchiseeTerritory";
			/// <summary>Member name MarketingPrintOrder_</summary>
			public static readonly string MarketingPrintOrder_ = "MarketingPrintOrder_";
			/// <summary>Member name MarketingPrintOrder</summary>
			public static readonly string MarketingPrintOrder = "MarketingPrintOrder";
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name PodDetails</summary>
			public static readonly string PodDetails = "PodDetails";
			/// <summary>Member name ProspectListDetails</summary>
			public static readonly string ProspectListDetails = "ProspectListDetails";
			/// <summary>Member name ScheduleTemplateFranchiseeAccess</summary>
			public static readonly string ScheduleTemplateFranchiseeAccess = "ScheduleTemplateFranchiseeAccess";
			/// <summary>Member name AccountCollectionViaAccountCallCenterOrganization</summary>
			public static readonly string AccountCollectionViaAccountCallCenterOrganization = "AccountCollectionViaAccountCallCenterOrganization";
			/// <summary>Member name ContactsCollectionViaContactFranchiseeAccess</summary>
			public static readonly string ContactsCollectionViaContactFranchiseeAccess = "ContactsCollectionViaContactFranchiseeAccess";
			/// <summary>Member name EventsCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string EventsCollectionViaEventAccountTestHcpcsCode = "EventsCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode = "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountCallCenterOrganization</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountCallCenterOrganization = "OrganizationRoleUserCollectionViaAccountCallCenterOrganization";
			/// <summary>Member name OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_</summary>
			public static readonly string OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_";
			/// <summary>Member name OrganizationRoleUserCollectionViaMarketingPrintOrder_</summary>
			public static readonly string OrganizationRoleUserCollectionViaMarketingPrintOrder_ = "OrganizationRoleUserCollectionViaMarketingPrintOrder_";
			/// <summary>Member name OrganizationRoleUserCollectionViaMarketingPrintOrder</summary>
			public static readonly string OrganizationRoleUserCollectionViaMarketingPrintOrder = "OrganizationRoleUserCollectionViaMarketingPrintOrder";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountTestHcpcsCode_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountTestHcpcsCode_ = "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountTestHcpcsCode</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountTestHcpcsCode = "OrganizationRoleUserCollectionViaAccountTestHcpcsCode";
			/// <summary>Member name OrganizationRoleUserCollectionViaAffiliateProfile</summary>
			public static readonly string OrganizationRoleUserCollectionViaAffiliateProfile = "OrganizationRoleUserCollectionViaAffiliateProfile";
			/// <summary>Member name OrganizationRoleUserCollectionViaAccountCallCenterOrganization_</summary>
			public static readonly string OrganizationRoleUserCollectionViaAccountCallCenterOrganization_ = "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_";
			/// <summary>Member name RoleCollectionViaOrganizationRoleUser</summary>
			public static readonly string RoleCollectionViaOrganizationRoleUser = "RoleCollectionViaOrganizationRoleUser";
			/// <summary>Member name ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess</summary>
			public static readonly string ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess = "ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess";
			/// <summary>Member name TestHcpcsCodeCollectionViaAccountTestHcpcsCode</summary>
			public static readonly string TestHcpcsCodeCollectionViaAccountTestHcpcsCode = "TestHcpcsCodeCollectionViaAccountTestHcpcsCode";
			/// <summary>Member name TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode</summary>
			public static readonly string TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode = "TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode";
			/// <summary>Member name UserCollectionViaOrganizationRoleUser</summary>
			public static readonly string UserCollectionViaOrganizationRoleUser = "UserCollectionViaOrganizationRoleUser";
			/// <summary>Member name VanDetailsCollectionViaPodDetails</summary>
			public static readonly string VanDetailsCollectionViaPodDetails = "VanDetailsCollectionViaPodDetails";
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name HospitalFacility</summary>
			public static readonly string HospitalFacility = "HospitalFacility";
			/// <summary>Member name MedicalVendorProfile</summary>
			public static readonly string MedicalVendorProfile = "MedicalVendorProfile";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OrganizationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OrganizationEntity():base("OrganizationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OrganizationEntity(IEntityFields2 fields):base("OrganizationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OrganizationEntity</param>
		public OrganizationEntity(IValidator validator):base("OrganizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrganizationEntity(System.Int64 organizationId):base("OrganizationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OrganizationId = organizationId;
		}

		/// <summary> CTor</summary>
		/// <param name="organizationId">PK value for Organization which data should be fetched into this Organization object</param>
		/// <param name="validator">The custom validator object for this OrganizationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OrganizationEntity(System.Int64 organizationId, IValidator validator):base("OrganizationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OrganizationId = organizationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OrganizationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_accountCallCenterOrganization = (EntityCollection<AccountCallCenterOrganizationEntity>)info.GetValue("_accountCallCenterOrganization", typeof(EntityCollection<AccountCallCenterOrganizationEntity>));
				_accountTestHcpcsCode = (EntityCollection<AccountTestHcpcsCodeEntity>)info.GetValue("_accountTestHcpcsCode", typeof(EntityCollection<AccountTestHcpcsCodeEntity>));
				_afcampaignTemplate = (EntityCollection<AfcampaignTemplateEntity>)info.GetValue("_afcampaignTemplate", typeof(EntityCollection<AfcampaignTemplateEntity>));
				_affiliateProfile = (EntityCollection<AffiliateProfileEntity>)info.GetValue("_affiliateProfile", typeof(EntityCollection<AffiliateProfileEntity>));
				_blockedDaysFranchisee = (EntityCollection<BlockedDaysFranchiseeEntity>)info.GetValue("_blockedDaysFranchisee", typeof(EntityCollection<BlockedDaysFranchiseeEntity>));
				_contactFranchiseeAccess = (EntityCollection<ContactFranchiseeAccessEntity>)info.GetValue("_contactFranchiseeAccess", typeof(EntityCollection<ContactFranchiseeAccessEntity>));
				_eventAccountTestHcpcsCode = (EntityCollection<EventAccountTestHcpcsCodeEntity>)info.GetValue("_eventAccountTestHcpcsCode", typeof(EntityCollection<EventAccountTestHcpcsCodeEntity>));
				_franchiseeTerritory = (EntityCollection<FranchiseeTerritoryEntity>)info.GetValue("_franchiseeTerritory", typeof(EntityCollection<FranchiseeTerritoryEntity>));
				_marketingPrintOrder_ = (EntityCollection<MarketingPrintOrderEntity>)info.GetValue("_marketingPrintOrder_", typeof(EntityCollection<MarketingPrintOrderEntity>));
				_marketingPrintOrder = (EntityCollection<MarketingPrintOrderEntity>)info.GetValue("_marketingPrintOrder", typeof(EntityCollection<MarketingPrintOrderEntity>));
				_organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUser", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_podDetails = (EntityCollection<PodDetailsEntity>)info.GetValue("_podDetails", typeof(EntityCollection<PodDetailsEntity>));
				_prospectListDetails = (EntityCollection<ProspectListDetailsEntity>)info.GetValue("_prospectListDetails", typeof(EntityCollection<ProspectListDetailsEntity>));
				_scheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateFranchiseeAccessEntity>)info.GetValue("_scheduleTemplateFranchiseeAccess", typeof(EntityCollection<ScheduleTemplateFranchiseeAccessEntity>));
				_accountCollectionViaAccountCallCenterOrganization = (EntityCollection<AccountEntity>)info.GetValue("_accountCollectionViaAccountCallCenterOrganization", typeof(EntityCollection<AccountEntity>));
				_contactsCollectionViaContactFranchiseeAccess = (EntityCollection<ContactsEntity>)info.GetValue("_contactsCollectionViaContactFranchiseeAccess", typeof(EntityCollection<ContactsEntity>));
				_eventsCollectionViaEventAccountTestHcpcsCode = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<EventsEntity>));
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaMarketingPrintOrder_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMarketingPrintOrder_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaMarketingPrintOrder = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaMarketingPrintOrder", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAffiliateProfile = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAffiliateProfile", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaAccountCallCenterOrganization_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_roleCollectionViaOrganizationRoleUser = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaOrganizationRoleUser", typeof(EntityCollection<RoleEntity>));
				_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateEntity>)info.GetValue("_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess", typeof(EntityCollection<ScheduleTemplateEntity>));
				_testHcpcsCodeCollectionViaAccountTestHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>)info.GetValue("_testHcpcsCodeCollectionViaAccountTestHcpcsCode", typeof(EntityCollection<TestHcpcsCodeEntity>));
				_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>)info.GetValue("_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode", typeof(EntityCollection<TestHcpcsCodeEntity>));
				_userCollectionViaOrganizationRoleUser = (EntityCollection<UserEntity>)info.GetValue("_userCollectionViaOrganizationRoleUser", typeof(EntityCollection<UserEntity>));
				_vanDetailsCollectionViaPodDetails = (EntityCollection<VanDetailsEntity>)info.GetValue("_vanDetailsCollectionViaPodDetails", typeof(EntityCollection<VanDetailsEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
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
				_organizationType = (OrganizationTypeEntity)info.GetValue("_organizationType", typeof(OrganizationTypeEntity));
				if(_organizationType!=null)
				{
					_organizationType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hospitalFacility = (HospitalFacilityEntity)info.GetValue("_hospitalFacility", typeof(HospitalFacilityEntity));
				if(_hospitalFacility!=null)
				{
					_hospitalFacility.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_medicalVendorProfile = (MedicalVendorProfileEntity)info.GetValue("_medicalVendorProfile", typeof(MedicalVendorProfileEntity));
				if(_medicalVendorProfile!=null)
				{
					_medicalVendorProfile.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((OrganizationFieldIndex)fieldIndex)
			{
				case OrganizationFieldIndex.OrganizationTypeId:
					DesetupSyncOrganizationType(true, false);
					break;
				case OrganizationFieldIndex.BusinessAddressId:
					DesetupSyncAddress(true, false);
					break;
				case OrganizationFieldIndex.LogoImageId:
					DesetupSyncFile(true, false);
					break;
				case OrganizationFieldIndex.TeamImageId:
					DesetupSyncFile_(true, false);
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
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "File_":
					this.File_ = (FileEntity)entity;
					break;
				case "File":
					this.File = (FileEntity)entity;
					break;
				case "OrganizationType":
					this.OrganizationType = (OrganizationTypeEntity)entity;
					break;
				case "AccountCallCenterOrganization":
					this.AccountCallCenterOrganization.Add((AccountCallCenterOrganizationEntity)entity);
					break;
				case "AccountTestHcpcsCode":
					this.AccountTestHcpcsCode.Add((AccountTestHcpcsCodeEntity)entity);
					break;
				case "AfcampaignTemplate":
					this.AfcampaignTemplate.Add((AfcampaignTemplateEntity)entity);
					break;
				case "AffiliateProfile":
					this.AffiliateProfile.Add((AffiliateProfileEntity)entity);
					break;
				case "BlockedDaysFranchisee":
					this.BlockedDaysFranchisee.Add((BlockedDaysFranchiseeEntity)entity);
					break;
				case "ContactFranchiseeAccess":
					this.ContactFranchiseeAccess.Add((ContactFranchiseeAccessEntity)entity);
					break;
				case "EventAccountTestHcpcsCode":
					this.EventAccountTestHcpcsCode.Add((EventAccountTestHcpcsCodeEntity)entity);
					break;
				case "FranchiseeTerritory":
					this.FranchiseeTerritory.Add((FranchiseeTerritoryEntity)entity);
					break;
				case "MarketingPrintOrder_":
					this.MarketingPrintOrder_.Add((MarketingPrintOrderEntity)entity);
					break;
				case "MarketingPrintOrder":
					this.MarketingPrintOrder.Add((MarketingPrintOrderEntity)entity);
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)entity);
					break;
				case "PodDetails":
					this.PodDetails.Add((PodDetailsEntity)entity);
					break;
				case "ProspectListDetails":
					this.ProspectListDetails.Add((ProspectListDetailsEntity)entity);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					this.ScheduleTemplateFranchiseeAccess.Add((ScheduleTemplateFranchiseeAccessEntity)entity);
					break;
				case "AccountCollectionViaAccountCallCenterOrganization":
					this.AccountCollectionViaAccountCallCenterOrganization.IsReadOnly = false;
					this.AccountCollectionViaAccountCallCenterOrganization.Add((AccountEntity)entity);
					this.AccountCollectionViaAccountCallCenterOrganization.IsReadOnly = true;
					break;
				case "ContactsCollectionViaContactFranchiseeAccess":
					this.ContactsCollectionViaContactFranchiseeAccess.IsReadOnly = false;
					this.ContactsCollectionViaContactFranchiseeAccess.Add((ContactsEntity)entity);
					this.ContactsCollectionViaContactFranchiseeAccess.IsReadOnly = true;
					break;
				case "EventsCollectionViaEventAccountTestHcpcsCode":
					this.EventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.EventsCollectionViaEventAccountTestHcpcsCode.Add((EventsEntity)entity);
					this.EventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode":
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization":
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_":
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaMarketingPrintOrder_":
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaMarketingPrintOrder":
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaMarketingPrintOrder.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_":
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode":
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAffiliateProfile":
					this.OrganizationRoleUserCollectionViaAffiliateProfile.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAffiliateProfile.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAffiliateProfile.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_":
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaAccountCallCenterOrganization_.IsReadOnly = true;
					break;
				case "RoleCollectionViaOrganizationRoleUser":
					this.RoleCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.RoleCollectionViaOrganizationRoleUser.Add((RoleEntity)entity);
					this.RoleCollectionViaOrganizationRoleUser.IsReadOnly = true;
					break;
				case "ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess":
					this.ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly = false;
					this.ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.Add((ScheduleTemplateEntity)entity);
					this.ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly = true;
					break;
				case "TestHcpcsCodeCollectionViaAccountTestHcpcsCode":
					this.TestHcpcsCodeCollectionViaAccountTestHcpcsCode.IsReadOnly = false;
					this.TestHcpcsCodeCollectionViaAccountTestHcpcsCode.Add((TestHcpcsCodeEntity)entity);
					this.TestHcpcsCodeCollectionViaAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode":
					this.TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode.IsReadOnly = false;
					this.TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode.Add((TestHcpcsCodeEntity)entity);
					this.TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode.IsReadOnly = true;
					break;
				case "UserCollectionViaOrganizationRoleUser":
					this.UserCollectionViaOrganizationRoleUser.IsReadOnly = false;
					this.UserCollectionViaOrganizationRoleUser.Add((UserEntity)entity);
					this.UserCollectionViaOrganizationRoleUser.IsReadOnly = true;
					break;
				case "VanDetailsCollectionViaPodDetails":
					this.VanDetailsCollectionViaPodDetails.IsReadOnly = false;
					this.VanDetailsCollectionViaPodDetails.Add((VanDetailsEntity)entity);
					this.VanDetailsCollectionViaPodDetails.IsReadOnly = true;
					break;
				case "Account":
					this.Account = (AccountEntity)entity;
					break;
				case "HospitalFacility":
					this.HospitalFacility = (HospitalFacilityEntity)entity;
					break;
				case "MedicalVendorProfile":
					this.MedicalVendorProfile = (MedicalVendorProfileEntity)entity;
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
			return OrganizationEntity.GetRelationsForField(fieldName);
		}

		/// <summary>Gets the relation objects which represent the relation the fieldName specified is mapped on. </summary>
		/// <param name="fieldName">Name of the field mapped onto the relation of which the relation objects have to be obtained.</param>
		/// <returns>RelationCollection with relation object(s) which represent the relation the field is maped on</returns>
		public static RelationCollection GetRelationsForField(string fieldName)
		{
			RelationCollection toReturn = new RelationCollection();
			switch(fieldName)
			{
				case "Address":
					toReturn.Add(OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId);
					break;
				case "File_":
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingTeamImageId);
					break;
				case "File":
					toReturn.Add(OrganizationEntity.Relations.FileEntityUsingLogoImageId);
					break;
				case "OrganizationType":
					toReturn.Add(OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId);
					break;
				case "AccountCallCenterOrganization":
					toReturn.Add(OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId);
					break;
				case "AccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId);
					break;
				case "AfcampaignTemplate":
					toReturn.Add(OrganizationEntity.Relations.AfcampaignTemplateEntityUsingOwnerFranchiseeId);
					break;
				case "AffiliateProfile":
					toReturn.Add(OrganizationEntity.Relations.AffiliateProfileEntityUsingOwnerOrganizationId);
					break;
				case "BlockedDaysFranchisee":
					toReturn.Add(OrganizationEntity.Relations.BlockedDaysFranchiseeEntityUsingOrganizationId);
					break;
				case "ContactFranchiseeAccess":
					toReturn.Add(OrganizationEntity.Relations.ContactFranchiseeAccessEntityUsingOrganizationId);
					break;
				case "EventAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId);
					break;
				case "FranchiseeTerritory":
					toReturn.Add(OrganizationEntity.Relations.FranchiseeTerritoryEntityUsingOrganizationId);
					break;
				case "MarketingPrintOrder_":
					toReturn.Add(OrganizationEntity.Relations.MarketingPrintOrderEntityUsingPrintVendorOrganizationId);
					break;
				case "MarketingPrintOrder":
					toReturn.Add(OrganizationEntity.Relations.MarketingPrintOrderEntityUsingFranchiseeOrganizationId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(OrganizationEntity.Relations.OrganizationRoleUserEntityUsingOrganizationId);
					break;
				case "PodDetails":
					toReturn.Add(OrganizationEntity.Relations.PodDetailsEntityUsingOrganizationId);
					break;
				case "ProspectListDetails":
					toReturn.Add(OrganizationEntity.Relations.ProspectListDetailsEntityUsingOrganizationId);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					toReturn.Add(OrganizationEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingOrganizationId);
					break;
				case "AccountCollectionViaAccountCallCenterOrganization":
					toReturn.Add(OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId, "OrganizationEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.AccountEntityUsingAccountId, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "ContactsCollectionViaContactFranchiseeAccess":
					toReturn.Add(OrganizationEntity.Relations.ContactFranchiseeAccessEntityUsingOrganizationId, "OrganizationEntity__", "ContactFranchiseeAccess_", JoinHint.None);
					toReturn.Add(ContactFranchiseeAccessEntity.Relations.ContactsEntityUsingContactId, "ContactFranchiseeAccess_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.EventsEntityUsingEventId, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization":
					toReturn.Add(OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId, "OrganizationEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_":
					toReturn.Add(OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaMarketingPrintOrder_":
					toReturn.Add(OrganizationEntity.Relations.MarketingPrintOrderEntityUsingPrintVendorOrganizationId, "OrganizationEntity__", "MarketingPrintOrder_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "MarketingPrintOrder_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaMarketingPrintOrder":
					toReturn.Add(OrganizationEntity.Relations.MarketingPrintOrderEntityUsingFranchiseeOrganizationId, "OrganizationEntity__", "MarketingPrintOrder_", JoinHint.None);
					toReturn.Add(MarketingPrintOrderEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, "MarketingPrintOrder_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_":
					toReturn.Add(OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAffiliateProfile":
					toReturn.Add(OrganizationEntity.Relations.AffiliateProfileEntityUsingOwnerOrganizationId, "OrganizationEntity__", "AffiliateProfile_", JoinHint.None);
					toReturn.Add(AffiliateProfileEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, "AffiliateProfile_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_":
					toReturn.Add(OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId, "OrganizationEntity__", "AccountCallCenterOrganization_", JoinHint.None);
					toReturn.Add(AccountCallCenterOrganizationEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "AccountCallCenterOrganization_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaOrganizationRoleUser":
					toReturn.Add(OrganizationEntity.Relations.OrganizationRoleUserEntityUsingOrganizationId, "OrganizationEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.RoleEntityUsingRoleId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
					break;
				case "ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess":
					toReturn.Add(OrganizationEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingOrganizationId, "OrganizationEntity__", "ScheduleTemplateFranchiseeAccess_", JoinHint.None);
					toReturn.Add(ScheduleTemplateFranchiseeAccessEntity.Relations.ScheduleTemplateEntityUsingScheduleTemplateId, "ScheduleTemplateFranchiseeAccess_", string.Empty, JoinHint.None);
					break;
				case "TestHcpcsCodeCollectionViaAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "AccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(AccountTestHcpcsCodeEntity.Relations.TestHcpcsCodeEntityUsingTestHcpcsCodeId, "AccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode":
					toReturn.Add(OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId, "OrganizationEntity__", "EventAccountTestHcpcsCode_", JoinHint.None);
					toReturn.Add(EventAccountTestHcpcsCodeEntity.Relations.TestHcpcsCodeEntityUsingTestHcpcsCodeId, "EventAccountTestHcpcsCode_", string.Empty, JoinHint.None);
					break;
				case "UserCollectionViaOrganizationRoleUser":
					toReturn.Add(OrganizationEntity.Relations.OrganizationRoleUserEntityUsingOrganizationId, "OrganizationEntity__", "OrganizationRoleUser_", JoinHint.None);
					toReturn.Add(OrganizationRoleUserEntity.Relations.UserEntityUsingUserId, "OrganizationRoleUser_", string.Empty, JoinHint.None);
					break;
				case "VanDetailsCollectionViaPodDetails":
					toReturn.Add(OrganizationEntity.Relations.PodDetailsEntityUsingOrganizationId, "OrganizationEntity__", "PodDetails_", JoinHint.None);
					toReturn.Add(PodDetailsEntity.Relations.VanDetailsEntityUsingVanId, "PodDetails_", string.Empty, JoinHint.None);
					break;
				case "Account":
					toReturn.Add(OrganizationEntity.Relations.AccountEntityUsingAccountId);
					break;
				case "HospitalFacility":
					toReturn.Add(OrganizationEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId);
					break;
				case "MedicalVendorProfile":
					toReturn.Add(OrganizationEntity.Relations.MedicalVendorProfileEntityUsingOrganizationId);
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
				case "Address":
					SetupSyncAddress(relatedEntity);
					break;
				case "File_":
					SetupSyncFile_(relatedEntity);
					break;
				case "File":
					SetupSyncFile(relatedEntity);
					break;
				case "OrganizationType":
					SetupSyncOrganizationType(relatedEntity);
					break;
				case "AccountCallCenterOrganization":
					this.AccountCallCenterOrganization.Add((AccountCallCenterOrganizationEntity)relatedEntity);
					break;
				case "AccountTestHcpcsCode":
					this.AccountTestHcpcsCode.Add((AccountTestHcpcsCodeEntity)relatedEntity);
					break;
				case "AfcampaignTemplate":
					this.AfcampaignTemplate.Add((AfcampaignTemplateEntity)relatedEntity);
					break;
				case "AffiliateProfile":
					this.AffiliateProfile.Add((AffiliateProfileEntity)relatedEntity);
					break;
				case "BlockedDaysFranchisee":
					this.BlockedDaysFranchisee.Add((BlockedDaysFranchiseeEntity)relatedEntity);
					break;
				case "ContactFranchiseeAccess":
					this.ContactFranchiseeAccess.Add((ContactFranchiseeAccessEntity)relatedEntity);
					break;
				case "EventAccountTestHcpcsCode":
					this.EventAccountTestHcpcsCode.Add((EventAccountTestHcpcsCodeEntity)relatedEntity);
					break;
				case "FranchiseeTerritory":
					this.FranchiseeTerritory.Add((FranchiseeTerritoryEntity)relatedEntity);
					break;
				case "MarketingPrintOrder_":
					this.MarketingPrintOrder_.Add((MarketingPrintOrderEntity)relatedEntity);
					break;
				case "MarketingPrintOrder":
					this.MarketingPrintOrder.Add((MarketingPrintOrderEntity)relatedEntity);
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser.Add((OrganizationRoleUserEntity)relatedEntity);
					break;
				case "PodDetails":
					this.PodDetails.Add((PodDetailsEntity)relatedEntity);
					break;
				case "ProspectListDetails":
					this.ProspectListDetails.Add((ProspectListDetailsEntity)relatedEntity);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					this.ScheduleTemplateFranchiseeAccess.Add((ScheduleTemplateFranchiseeAccessEntity)relatedEntity);
					break;
				case "Account":
					SetupSyncAccount(relatedEntity);
					break;
				case "HospitalFacility":
					SetupSyncHospitalFacility(relatedEntity);
					break;
				case "MedicalVendorProfile":
					SetupSyncMedicalVendorProfile(relatedEntity);
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
				case "Address":
					DesetupSyncAddress(false, true);
					break;
				case "File_":
					DesetupSyncFile_(false, true);
					break;
				case "File":
					DesetupSyncFile(false, true);
					break;
				case "OrganizationType":
					DesetupSyncOrganizationType(false, true);
					break;
				case "AccountCallCenterOrganization":
					base.PerformRelatedEntityRemoval(this.AccountCallCenterOrganization, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AccountTestHcpcsCode":
					base.PerformRelatedEntityRemoval(this.AccountTestHcpcsCode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AfcampaignTemplate":
					base.PerformRelatedEntityRemoval(this.AfcampaignTemplate, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "AffiliateProfile":
					base.PerformRelatedEntityRemoval(this.AffiliateProfile, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "BlockedDaysFranchisee":
					base.PerformRelatedEntityRemoval(this.BlockedDaysFranchisee, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ContactFranchiseeAccess":
					base.PerformRelatedEntityRemoval(this.ContactFranchiseeAccess, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "EventAccountTestHcpcsCode":
					base.PerformRelatedEntityRemoval(this.EventAccountTestHcpcsCode, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FranchiseeTerritory":
					base.PerformRelatedEntityRemoval(this.FranchiseeTerritory, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingPrintOrder_":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrder_, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MarketingPrintOrder":
					base.PerformRelatedEntityRemoval(this.MarketingPrintOrder, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "OrganizationRoleUser":
					base.PerformRelatedEntityRemoval(this.OrganizationRoleUser, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "PodDetails":
					base.PerformRelatedEntityRemoval(this.PodDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectListDetails":
					base.PerformRelatedEntityRemoval(this.ProspectListDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ScheduleTemplateFranchiseeAccess":
					base.PerformRelatedEntityRemoval(this.ScheduleTemplateFranchiseeAccess, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "Account":
					DesetupSyncAccount(false, true);
					break;
				case "HospitalFacility":
					DesetupSyncHospitalFacility(false, true);
					break;
				case "MedicalVendorProfile":
					DesetupSyncMedicalVendorProfile(false, true);
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
			if(_account!=null)
			{
				toReturn.Add(_account);
			}

			if(_hospitalFacility!=null)
			{
				toReturn.Add(_hospitalFacility);
			}

			if(_medicalVendorProfile!=null)
			{
				toReturn.Add(_medicalVendorProfile);
			}

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_address!=null)
			{
				toReturn.Add(_address);
			}
			if(_file_!=null)
			{
				toReturn.Add(_file_);
			}
			if(_file!=null)
			{
				toReturn.Add(_file);
			}
			if(_organizationType!=null)
			{
				toReturn.Add(_organizationType);
			}






			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.AccountCallCenterOrganization);
			toReturn.Add(this.AccountTestHcpcsCode);
			toReturn.Add(this.AfcampaignTemplate);
			toReturn.Add(this.AffiliateProfile);
			toReturn.Add(this.BlockedDaysFranchisee);
			toReturn.Add(this.ContactFranchiseeAccess);
			toReturn.Add(this.EventAccountTestHcpcsCode);
			toReturn.Add(this.FranchiseeTerritory);
			toReturn.Add(this.MarketingPrintOrder_);
			toReturn.Add(this.MarketingPrintOrder);
			toReturn.Add(this.OrganizationRoleUser);
			toReturn.Add(this.PodDetails);
			toReturn.Add(this.ProspectListDetails);
			toReturn.Add(this.ScheduleTemplateFranchiseeAccess);

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
				info.AddValue("_accountCallCenterOrganization", ((_accountCallCenterOrganization!=null) && (_accountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_accountCallCenterOrganization:null);
				info.AddValue("_accountTestHcpcsCode", ((_accountTestHcpcsCode!=null) && (_accountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_accountTestHcpcsCode:null);
				info.AddValue("_afcampaignTemplate", ((_afcampaignTemplate!=null) && (_afcampaignTemplate.Count>0) && !this.MarkedForDeletion)?_afcampaignTemplate:null);
				info.AddValue("_affiliateProfile", ((_affiliateProfile!=null) && (_affiliateProfile.Count>0) && !this.MarkedForDeletion)?_affiliateProfile:null);
				info.AddValue("_blockedDaysFranchisee", ((_blockedDaysFranchisee!=null) && (_blockedDaysFranchisee.Count>0) && !this.MarkedForDeletion)?_blockedDaysFranchisee:null);
				info.AddValue("_contactFranchiseeAccess", ((_contactFranchiseeAccess!=null) && (_contactFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_contactFranchiseeAccess:null);
				info.AddValue("_eventAccountTestHcpcsCode", ((_eventAccountTestHcpcsCode!=null) && (_eventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_eventAccountTestHcpcsCode:null);
				info.AddValue("_franchiseeTerritory", ((_franchiseeTerritory!=null) && (_franchiseeTerritory.Count>0) && !this.MarkedForDeletion)?_franchiseeTerritory:null);
				info.AddValue("_marketingPrintOrder_", ((_marketingPrintOrder_!=null) && (_marketingPrintOrder_.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrder_:null);
				info.AddValue("_marketingPrintOrder", ((_marketingPrintOrder!=null) && (_marketingPrintOrder.Count>0) && !this.MarkedForDeletion)?_marketingPrintOrder:null);
				info.AddValue("_organizationRoleUser", ((_organizationRoleUser!=null) && (_organizationRoleUser.Count>0) && !this.MarkedForDeletion)?_organizationRoleUser:null);
				info.AddValue("_podDetails", ((_podDetails!=null) && (_podDetails.Count>0) && !this.MarkedForDeletion)?_podDetails:null);
				info.AddValue("_prospectListDetails", ((_prospectListDetails!=null) && (_prospectListDetails.Count>0) && !this.MarkedForDeletion)?_prospectListDetails:null);
				info.AddValue("_scheduleTemplateFranchiseeAccess", ((_scheduleTemplateFranchiseeAccess!=null) && (_scheduleTemplateFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_scheduleTemplateFranchiseeAccess:null);
				info.AddValue("_accountCollectionViaAccountCallCenterOrganization", ((_accountCollectionViaAccountCallCenterOrganization!=null) && (_accountCollectionViaAccountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_accountCollectionViaAccountCallCenterOrganization:null);
				info.AddValue("_contactsCollectionViaContactFranchiseeAccess", ((_contactsCollectionViaContactFranchiseeAccess!=null) && (_contactsCollectionViaContactFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_contactsCollectionViaContactFranchiseeAccess:null);
				info.AddValue("_eventsCollectionViaEventAccountTestHcpcsCode", ((_eventsCollectionViaEventAccountTestHcpcsCode!=null) && (_eventsCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode", ((_organizationRoleUserCollectionViaEventAccountTestHcpcsCode!=null) && (_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization", ((_organizationRoleUserCollectionViaAccountCallCenterOrganization!=null) && (_organizationRoleUserCollectionViaAccountCallCenterOrganization.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountCallCenterOrganization:null);
				info.AddValue("_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_", ((_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_!=null) && (_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_:null);
				info.AddValue("_organizationRoleUserCollectionViaMarketingPrintOrder_", ((_organizationRoleUserCollectionViaMarketingPrintOrder_!=null) && (_organizationRoleUserCollectionViaMarketingPrintOrder_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMarketingPrintOrder_:null);
				info.AddValue("_organizationRoleUserCollectionViaMarketingPrintOrder", ((_organizationRoleUserCollectionViaMarketingPrintOrder!=null) && (_organizationRoleUserCollectionViaMarketingPrintOrder.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaMarketingPrintOrder:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode_", ((_organizationRoleUserCollectionViaAccountTestHcpcsCode_!=null) && (_organizationRoleUserCollectionViaAccountTestHcpcsCode_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountTestHcpcsCode_:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountTestHcpcsCode", ((_organizationRoleUserCollectionViaAccountTestHcpcsCode!=null) && (_organizationRoleUserCollectionViaAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountTestHcpcsCode:null);
				info.AddValue("_organizationRoleUserCollectionViaAffiliateProfile", ((_organizationRoleUserCollectionViaAffiliateProfile!=null) && (_organizationRoleUserCollectionViaAffiliateProfile.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAffiliateProfile:null);
				info.AddValue("_organizationRoleUserCollectionViaAccountCallCenterOrganization_", ((_organizationRoleUserCollectionViaAccountCallCenterOrganization_!=null) && (_organizationRoleUserCollectionViaAccountCallCenterOrganization_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaAccountCallCenterOrganization_:null);
				info.AddValue("_roleCollectionViaOrganizationRoleUser", ((_roleCollectionViaOrganizationRoleUser!=null) && (_roleCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaOrganizationRoleUser:null);
				info.AddValue("_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess", ((_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess!=null) && (_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.Count>0) && !this.MarkedForDeletion)?_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess:null);
				info.AddValue("_testHcpcsCodeCollectionViaAccountTestHcpcsCode", ((_testHcpcsCodeCollectionViaAccountTestHcpcsCode!=null) && (_testHcpcsCodeCollectionViaAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_testHcpcsCodeCollectionViaAccountTestHcpcsCode:null);
				info.AddValue("_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode", ((_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode!=null) && (_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode.Count>0) && !this.MarkedForDeletion)?_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode:null);
				info.AddValue("_userCollectionViaOrganizationRoleUser", ((_userCollectionViaOrganizationRoleUser!=null) && (_userCollectionViaOrganizationRoleUser.Count>0) && !this.MarkedForDeletion)?_userCollectionViaOrganizationRoleUser:null);
				info.AddValue("_vanDetailsCollectionViaPodDetails", ((_vanDetailsCollectionViaPodDetails!=null) && (_vanDetailsCollectionViaPodDetails.Count>0) && !this.MarkedForDeletion)?_vanDetailsCollectionViaPodDetails:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_file_", (!this.MarkedForDeletion?_file_:null));
				info.AddValue("_file", (!this.MarkedForDeletion?_file:null));
				info.AddValue("_organizationType", (!this.MarkedForDeletion?_organizationType:null));
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_hospitalFacility", (!this.MarkedForDeletion?_hospitalFacility:null));
				info.AddValue("_medicalVendorProfile", (!this.MarkedForDeletion?_medicalVendorProfile:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OrganizationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OrganizationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OrganizationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountCallCenterOrganization' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountCallCenterOrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AccountTestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountTestHcpcsCodeFields.AccountId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AfcampaignTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAfcampaignTemplate()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AfcampaignTemplateFields.OwnerFranchiseeId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'AffiliateProfile' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAffiliateProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AffiliateProfileFields.OwnerOrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BlockedDaysFranchisee' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBlockedDaysFranchisee()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BlockedDaysFranchiseeFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ContactFranchiseeAccess' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ContactFranchiseeAccessFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EventAccountTestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(EventAccountTestHcpcsCodeFields.AccountId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FranchiseeTerritory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFranchiseeTerritory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FranchiseeTerritoryFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrder_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.PrintVendorOrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MarketingPrintOrder' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMarketingPrintOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MarketingPrintOrderFields.FranchiseeOrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'PodDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoPodDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(PodDetailsFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectListDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectListDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleTemplateFranchiseeAccess' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleTemplateFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ScheduleTemplateFranchiseeAccessFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccountCollectionViaAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AccountCollectionViaAccountCallCenterOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Contacts' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoContactsCollectionViaContactFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ContactsCollectionViaContactFranchiseeAccess"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountCallCenterOrganization()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountCallCenterOrganization"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMarketingPrintOrder_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMarketingPrintOrder_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaMarketingPrintOrder()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaMarketingPrintOrder"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountTestHcpcsCode_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAffiliateProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAffiliateProfile"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaAccountCallCenterOrganization_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ScheduleTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestHcpcsCodeCollectionViaAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestHcpcsCodeCollectionViaAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TestHcpcsCode' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTestHcpcsCodeCollectionViaEventAccountTestHcpcsCode()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'User' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUserCollectionViaOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UserCollectionViaOrganizationRoleUser"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'VanDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoVanDetailsCollectionViaPodDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("VanDetailsCollectionViaPodDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId, "OrganizationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.BusinessAddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.TeamImageId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'File' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FileFields.FileId, null, ComparisonOperator.Equal, this.LogoImageId));
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
		/// the related entity of type 'Account' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.AccountId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HospitalFacility' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHospitalFacility()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HospitalFacilityFields.HospitalFacilityId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MedicalVendorProfile' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMedicalVendorProfile()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MedicalVendorProfileFields.OrganizationId, null, ComparisonOperator.Equal, this.OrganizationId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.OrganizationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OrganizationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._accountCallCenterOrganization);
			collectionsQueue.Enqueue(this._accountTestHcpcsCode);
			collectionsQueue.Enqueue(this._afcampaignTemplate);
			collectionsQueue.Enqueue(this._affiliateProfile);
			collectionsQueue.Enqueue(this._blockedDaysFranchisee);
			collectionsQueue.Enqueue(this._contactFranchiseeAccess);
			collectionsQueue.Enqueue(this._eventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._franchiseeTerritory);
			collectionsQueue.Enqueue(this._marketingPrintOrder_);
			collectionsQueue.Enqueue(this._marketingPrintOrder);
			collectionsQueue.Enqueue(this._organizationRoleUser);
			collectionsQueue.Enqueue(this._podDetails);
			collectionsQueue.Enqueue(this._prospectListDetails);
			collectionsQueue.Enqueue(this._scheduleTemplateFranchiseeAccess);
			collectionsQueue.Enqueue(this._accountCollectionViaAccountCallCenterOrganization);
			collectionsQueue.Enqueue(this._contactsCollectionViaContactFranchiseeAccess);
			collectionsQueue.Enqueue(this._eventsCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountCallCenterOrganization);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMarketingPrintOrder_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaMarketingPrintOrder);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountTestHcpcsCode_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAffiliateProfile);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaAccountCallCenterOrganization_);
			collectionsQueue.Enqueue(this._roleCollectionViaOrganizationRoleUser);
			collectionsQueue.Enqueue(this._scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess);
			collectionsQueue.Enqueue(this._testHcpcsCodeCollectionViaAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._testHcpcsCodeCollectionViaEventAccountTestHcpcsCode);
			collectionsQueue.Enqueue(this._userCollectionViaOrganizationRoleUser);
			collectionsQueue.Enqueue(this._vanDetailsCollectionViaPodDetails);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._accountCallCenterOrganization = (EntityCollection<AccountCallCenterOrganizationEntity>) collectionsQueue.Dequeue();
			this._accountTestHcpcsCode = (EntityCollection<AccountTestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._afcampaignTemplate = (EntityCollection<AfcampaignTemplateEntity>) collectionsQueue.Dequeue();
			this._affiliateProfile = (EntityCollection<AffiliateProfileEntity>) collectionsQueue.Dequeue();
			this._blockedDaysFranchisee = (EntityCollection<BlockedDaysFranchiseeEntity>) collectionsQueue.Dequeue();
			this._contactFranchiseeAccess = (EntityCollection<ContactFranchiseeAccessEntity>) collectionsQueue.Dequeue();
			this._eventAccountTestHcpcsCode = (EntityCollection<EventAccountTestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._franchiseeTerritory = (EntityCollection<FranchiseeTerritoryEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrder_ = (EntityCollection<MarketingPrintOrderEntity>) collectionsQueue.Dequeue();
			this._marketingPrintOrder = (EntityCollection<MarketingPrintOrderEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUser = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._podDetails = (EntityCollection<PodDetailsEntity>) collectionsQueue.Dequeue();
			this._prospectListDetails = (EntityCollection<ProspectListDetailsEntity>) collectionsQueue.Dequeue();
			this._scheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateFranchiseeAccessEntity>) collectionsQueue.Dequeue();
			this._accountCollectionViaAccountCallCenterOrganization = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._contactsCollectionViaContactFranchiseeAccess = (EntityCollection<ContactsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaEventAccountTestHcpcsCode = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountCallCenterOrganization = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMarketingPrintOrder_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaMarketingPrintOrder = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountTestHcpcsCode_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountTestHcpcsCode = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAffiliateProfile = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaAccountCallCenterOrganization_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaOrganizationRoleUser = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess = (EntityCollection<ScheduleTemplateEntity>) collectionsQueue.Dequeue();
			this._testHcpcsCodeCollectionViaAccountTestHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._testHcpcsCodeCollectionViaEventAccountTestHcpcsCode = (EntityCollection<TestHcpcsCodeEntity>) collectionsQueue.Dequeue();
			this._userCollectionViaOrganizationRoleUser = (EntityCollection<UserEntity>) collectionsQueue.Dequeue();
			this._vanDetailsCollectionViaPodDetails = (EntityCollection<VanDetailsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._accountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._accountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._afcampaignTemplate != null)
			{
				return true;
			}
			if (this._affiliateProfile != null)
			{
				return true;
			}
			if (this._blockedDaysFranchisee != null)
			{
				return true;
			}
			if (this._contactFranchiseeAccess != null)
			{
				return true;
			}
			if (this._eventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._franchiseeTerritory != null)
			{
				return true;
			}
			if (this._marketingPrintOrder_ != null)
			{
				return true;
			}
			if (this._marketingPrintOrder != null)
			{
				return true;
			}
			if (this._organizationRoleUser != null)
			{
				return true;
			}
			if (this._podDetails != null)
			{
				return true;
			}
			if (this._prospectListDetails != null)
			{
				return true;
			}
			if (this._scheduleTemplateFranchiseeAccess != null)
			{
				return true;
			}
			if (this._accountCollectionViaAccountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._contactsCollectionViaContactFranchiseeAccess != null)
			{
				return true;
			}
			if (this._eventsCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountCallCenterOrganization != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMarketingPrintOrder_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaMarketingPrintOrder != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountTestHcpcsCode_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAffiliateProfile != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaAccountCallCenterOrganization_ != null)
			{
				return true;
			}
			if (this._roleCollectionViaOrganizationRoleUser != null)
			{
				return true;
			}
			if (this._scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess != null)
			{
				return true;
			}
			if (this._testHcpcsCodeCollectionViaAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._testHcpcsCodeCollectionViaEventAccountTestHcpcsCode != null)
			{
				return true;
			}
			if (this._userCollectionViaOrganizationRoleUser != null)
			{
				return true;
			}
			if (this._vanDetailsCollectionViaPodDetails != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountCallCenterOrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallCenterOrganizationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AfcampaignTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BlockedDaysFranchiseeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BlockedDaysFranchiseeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FranchiseeTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeTerritoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<VanDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VanDetailsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Address", _address);
			toReturn.Add("File_", _file_);
			toReturn.Add("File", _file);
			toReturn.Add("OrganizationType", _organizationType);
			toReturn.Add("AccountCallCenterOrganization", _accountCallCenterOrganization);
			toReturn.Add("AccountTestHcpcsCode", _accountTestHcpcsCode);
			toReturn.Add("AfcampaignTemplate", _afcampaignTemplate);
			toReturn.Add("AffiliateProfile", _affiliateProfile);
			toReturn.Add("BlockedDaysFranchisee", _blockedDaysFranchisee);
			toReturn.Add("ContactFranchiseeAccess", _contactFranchiseeAccess);
			toReturn.Add("EventAccountTestHcpcsCode", _eventAccountTestHcpcsCode);
			toReturn.Add("FranchiseeTerritory", _franchiseeTerritory);
			toReturn.Add("MarketingPrintOrder_", _marketingPrintOrder_);
			toReturn.Add("MarketingPrintOrder", _marketingPrintOrder);
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("PodDetails", _podDetails);
			toReturn.Add("ProspectListDetails", _prospectListDetails);
			toReturn.Add("ScheduleTemplateFranchiseeAccess", _scheduleTemplateFranchiseeAccess);
			toReturn.Add("AccountCollectionViaAccountCallCenterOrganization", _accountCollectionViaAccountCallCenterOrganization);
			toReturn.Add("ContactsCollectionViaContactFranchiseeAccess", _contactsCollectionViaContactFranchiseeAccess);
			toReturn.Add("EventsCollectionViaEventAccountTestHcpcsCode", _eventsCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode", _organizationRoleUserCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountCallCenterOrganization", _organizationRoleUserCollectionViaAccountCallCenterOrganization);
			toReturn.Add("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_", _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_);
			toReturn.Add("OrganizationRoleUserCollectionViaMarketingPrintOrder_", _organizationRoleUserCollectionViaMarketingPrintOrder_);
			toReturn.Add("OrganizationRoleUserCollectionViaMarketingPrintOrder", _organizationRoleUserCollectionViaMarketingPrintOrder);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_", _organizationRoleUserCollectionViaAccountTestHcpcsCode_);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountTestHcpcsCode", _organizationRoleUserCollectionViaAccountTestHcpcsCode);
			toReturn.Add("OrganizationRoleUserCollectionViaAffiliateProfile", _organizationRoleUserCollectionViaAffiliateProfile);
			toReturn.Add("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_", _organizationRoleUserCollectionViaAccountCallCenterOrganization_);
			toReturn.Add("RoleCollectionViaOrganizationRoleUser", _roleCollectionViaOrganizationRoleUser);
			toReturn.Add("ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess", _scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess);
			toReturn.Add("TestHcpcsCodeCollectionViaAccountTestHcpcsCode", _testHcpcsCodeCollectionViaAccountTestHcpcsCode);
			toReturn.Add("TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode", _testHcpcsCodeCollectionViaEventAccountTestHcpcsCode);
			toReturn.Add("UserCollectionViaOrganizationRoleUser", _userCollectionViaOrganizationRoleUser);
			toReturn.Add("VanDetailsCollectionViaPodDetails", _vanDetailsCollectionViaPodDetails);
			toReturn.Add("Account", _account);
			toReturn.Add("HospitalFacility", _hospitalFacility);
			toReturn.Add("MedicalVendorProfile", _medicalVendorProfile);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_accountCallCenterOrganization!=null)
			{
				_accountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_accountTestHcpcsCode!=null)
			{
				_accountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_afcampaignTemplate!=null)
			{
				_afcampaignTemplate.ActiveContext = base.ActiveContext;
			}
			if(_affiliateProfile!=null)
			{
				_affiliateProfile.ActiveContext = base.ActiveContext;
			}
			if(_blockedDaysFranchisee!=null)
			{
				_blockedDaysFranchisee.ActiveContext = base.ActiveContext;
			}
			if(_contactFranchiseeAccess!=null)
			{
				_contactFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_eventAccountTestHcpcsCode!=null)
			{
				_eventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_franchiseeTerritory!=null)
			{
				_franchiseeTerritory.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrder_!=null)
			{
				_marketingPrintOrder_.ActiveContext = base.ActiveContext;
			}
			if(_marketingPrintOrder!=null)
			{
				_marketingPrintOrder.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_podDetails!=null)
			{
				_podDetails.ActiveContext = base.ActiveContext;
			}
			if(_prospectListDetails!=null)
			{
				_prospectListDetails.ActiveContext = base.ActiveContext;
			}
			if(_scheduleTemplateFranchiseeAccess!=null)
			{
				_scheduleTemplateFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_accountCollectionViaAccountCallCenterOrganization!=null)
			{
				_accountCollectionViaAccountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_contactsCollectionViaContactFranchiseeAccess!=null)
			{
				_contactsCollectionViaContactFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_eventsCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountCallCenterOrganization!=null)
			{
				_organizationRoleUserCollectionViaAccountCallCenterOrganization.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_!=null)
			{
				_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMarketingPrintOrder_!=null)
			{
				_organizationRoleUserCollectionViaMarketingPrintOrder_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaMarketingPrintOrder!=null)
			{
				_organizationRoleUserCollectionViaMarketingPrintOrder.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountTestHcpcsCode_!=null)
			{
				_organizationRoleUserCollectionViaAccountTestHcpcsCode_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountTestHcpcsCode!=null)
			{
				_organizationRoleUserCollectionViaAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAffiliateProfile!=null)
			{
				_organizationRoleUserCollectionViaAffiliateProfile.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaAccountCallCenterOrganization_!=null)
			{
				_organizationRoleUserCollectionViaAccountCallCenterOrganization_.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaOrganizationRoleUser!=null)
			{
				_roleCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess!=null)
			{
				_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.ActiveContext = base.ActiveContext;
			}
			if(_testHcpcsCodeCollectionViaAccountTestHcpcsCode!=null)
			{
				_testHcpcsCodeCollectionViaAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode!=null)
			{
				_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode.ActiveContext = base.ActiveContext;
			}
			if(_userCollectionViaOrganizationRoleUser!=null)
			{
				_userCollectionViaOrganizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_vanDetailsCollectionViaPodDetails!=null)
			{
				_vanDetailsCollectionViaPodDetails.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_file_!=null)
			{
				_file_.ActiveContext = base.ActiveContext;
			}
			if(_file!=null)
			{
				_file.ActiveContext = base.ActiveContext;
			}
			if(_organizationType!=null)
			{
				_organizationType.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_hospitalFacility!=null)
			{
				_hospitalFacility.ActiveContext = base.ActiveContext;
			}
			if(_medicalVendorProfile!=null)
			{
				_medicalVendorProfile.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_accountCallCenterOrganization = null;
			_accountTestHcpcsCode = null;
			_afcampaignTemplate = null;
			_affiliateProfile = null;
			_blockedDaysFranchisee = null;
			_contactFranchiseeAccess = null;
			_eventAccountTestHcpcsCode = null;
			_franchiseeTerritory = null;
			_marketingPrintOrder_ = null;
			_marketingPrintOrder = null;
			_organizationRoleUser = null;
			_podDetails = null;
			_prospectListDetails = null;
			_scheduleTemplateFranchiseeAccess = null;
			_accountCollectionViaAccountCallCenterOrganization = null;
			_contactsCollectionViaContactFranchiseeAccess = null;
			_eventsCollectionViaEventAccountTestHcpcsCode = null;
			_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = null;
			_organizationRoleUserCollectionViaAccountCallCenterOrganization = null;
			_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = null;
			_organizationRoleUserCollectionViaMarketingPrintOrder_ = null;
			_organizationRoleUserCollectionViaMarketingPrintOrder = null;
			_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = null;
			_organizationRoleUserCollectionViaAccountTestHcpcsCode = null;
			_organizationRoleUserCollectionViaAffiliateProfile = null;
			_organizationRoleUserCollectionViaAccountCallCenterOrganization_ = null;
			_roleCollectionViaOrganizationRoleUser = null;
			_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess = null;
			_testHcpcsCodeCollectionViaAccountTestHcpcsCode = null;
			_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode = null;
			_userCollectionViaOrganizationRoleUser = null;
			_vanDetailsCollectionViaPodDetails = null;
			_address = null;
			_file_ = null;
			_file = null;
			_organizationType = null;
			_account = null;
			_hospitalFacility = null;
			_medicalVendorProfile = null;
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

			_fieldsCustomProperties.Add("OrganizationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Description", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BusinessAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BillingAddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FaxNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LogoImageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TeamImageId", fieldHashtable);
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
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId, true, signalRelatedEntity, "Organization", resetFKFields, new int[] { (int)OrganizationFieldIndex.BusinessAddressId } );		
			_address = null;
		}

		/// <summary> setups the sync logic for member _address</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncAddress(IEntity2 relatedEntity)
		{
			if(_address!=relatedEntity)
			{
				DesetupSyncAddress(true, true);
				_address = (AddressEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", OrganizationEntity.Relations.AddressEntityUsingBusinessAddressId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnAddressPropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", OrganizationEntity.Relations.FileEntityUsingTeamImageId, true, signalRelatedEntity, "Organization_", resetFKFields, new int[] { (int)OrganizationFieldIndex.TeamImageId } );		
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
				base.PerformSetupSyncRelatedEntity( _file_, new PropertyChangedEventHandler( OnFile_PropertyChanged ), "File_", OrganizationEntity.Relations.FileEntityUsingTeamImageId, true, new string[] {  } );
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
			base.PerformDesetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", OrganizationEntity.Relations.FileEntityUsingLogoImageId, true, signalRelatedEntity, "Organization", resetFKFields, new int[] { (int)OrganizationFieldIndex.LogoImageId } );		
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
				base.PerformSetupSyncRelatedEntity( _file, new PropertyChangedEventHandler( OnFilePropertyChanged ), "File", OrganizationEntity.Relations.FileEntityUsingLogoImageId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationType, new PropertyChangedEventHandler( OnOrganizationTypePropertyChanged ), "OrganizationType", OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, true, signalRelatedEntity, "Organization", resetFKFields, new int[] { (int)OrganizationFieldIndex.OrganizationTypeId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationType, new PropertyChangedEventHandler( OnOrganizationTypePropertyChanged ), "OrganizationType", OrganizationEntity.Relations.OrganizationTypeEntityUsingOrganizationTypeId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", OrganizationEntity.Relations.AccountEntityUsingAccountId, false, signalRelatedEntity, "Organization", false, new int[] { (int)OrganizationFieldIndex.OrganizationId } );
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
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", OrganizationEntity.Relations.AccountEntityUsingAccountId, false, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _hospitalFacility</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHospitalFacility(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hospitalFacility, new PropertyChangedEventHandler( OnHospitalFacilityPropertyChanged ), "HospitalFacility", OrganizationEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, false, signalRelatedEntity, "Organization", false, new int[] { (int)OrganizationFieldIndex.OrganizationId } );
			_hospitalFacility = null;
		}
		
		/// <summary> setups the sync logic for member _hospitalFacility</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHospitalFacility(IEntity2 relatedEntity)
		{
			if(_hospitalFacility!=relatedEntity)
			{
				DesetupSyncHospitalFacility(true, true);
				_hospitalFacility = (HospitalFacilityEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hospitalFacility, new PropertyChangedEventHandler( OnHospitalFacilityPropertyChanged ), "HospitalFacility", OrganizationEntity.Relations.HospitalFacilityEntityUsingHospitalFacilityId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHospitalFacilityPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _medicalVendorProfile</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMedicalVendorProfile(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _medicalVendorProfile, new PropertyChangedEventHandler( OnMedicalVendorProfilePropertyChanged ), "MedicalVendorProfile", OrganizationEntity.Relations.MedicalVendorProfileEntityUsingOrganizationId, false, signalRelatedEntity, "Organization", false, new int[] { (int)OrganizationFieldIndex.OrganizationId } );
			_medicalVendorProfile = null;
		}
		
		/// <summary> setups the sync logic for member _medicalVendorProfile</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMedicalVendorProfile(IEntity2 relatedEntity)
		{
			if(_medicalVendorProfile!=relatedEntity)
			{
				DesetupSyncMedicalVendorProfile(true, true);
				_medicalVendorProfile = (MedicalVendorProfileEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _medicalVendorProfile, new PropertyChangedEventHandler( OnMedicalVendorProfilePropertyChanged ), "MedicalVendorProfile", OrganizationEntity.Relations.MedicalVendorProfileEntityUsingOrganizationId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMedicalVendorProfilePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OrganizationEntity</param>
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
		public  static OrganizationRelations Relations
		{
			get	{ return new OrganizationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountCallCenterOrganization' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCallCenterOrganization
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountCallCenterOrganizationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountCallCenterOrganizationEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountCallCenterOrganization")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AccountCallCenterOrganizationEntity, 0, null, null, null, null, "AccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AccountTestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountTestHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("AccountTestHcpcsCode")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AccountTestHcpcsCodeEntity, 0, null, null, null, null, "AccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AfcampaignTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAfcampaignTemplate
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AfcampaignTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignTemplateEntityFactory))),
					(IEntityRelation)GetRelationsForField("AfcampaignTemplate")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AfcampaignTemplateEntity, 0, null, null, null, null, "AfcampaignTemplate", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'AffiliateProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAffiliateProfile
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("AffiliateProfile")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AffiliateProfileEntity, 0, null, null, null, null, "AffiliateProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BlockedDaysFranchisee' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBlockedDaysFranchisee
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<BlockedDaysFranchiseeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BlockedDaysFranchiseeEntityFactory))),
					(IEntityRelation)GetRelationsForField("BlockedDaysFranchisee")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.BlockedDaysFranchiseeEntity, 0, null, null, null, null, "BlockedDaysFranchisee", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ContactFranchiseeAccess' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactFranchiseeAccess
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory))),
					(IEntityRelation)GetRelationsForField("ContactFranchiseeAccess")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.ContactFranchiseeAccessEntity, 0, null, null, null, null, "ContactFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EventAccountTestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventAccountTestHcpcsCode
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory))),
					(IEntityRelation)GetRelationsForField("EventAccountTestHcpcsCode")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.EventAccountTestHcpcsCodeEntity, 0, null, null, null, null, "EventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FranchiseeTerritory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFranchiseeTerritory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FranchiseeTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeTerritoryEntityFactory))),
					(IEntityRelation)GetRelationsForField("FranchiseeTerritory")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.FranchiseeTerritoryEntity, 0, null, null, null, null, "FranchiseeTerritory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrder_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrder_")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, 0, null, null, null, null, "MarketingPrintOrder_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MarketingPrintOrder' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMarketingPrintOrder
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory))),
					(IEntityRelation)GetRelationsForField("MarketingPrintOrder")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.MarketingPrintOrderEntity, 0, null, null, null, null, "MarketingPrintOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'PodDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathPodDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("PodDetails")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.PodDetailsEntity, 0, null, null, null, null, "PodDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectListDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectListDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectListDetails")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.ProspectListDetailsEntity, 0, null, null, null, null, "ProspectListDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleTemplateFranchiseeAccess' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleTemplateFranchiseeAccess
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory))),
					(IEntityRelation)GetRelationsForField("ScheduleTemplateFranchiseeAccess")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.ScheduleTemplateFranchiseeAccessEntity, 0, null, null, null, null, "ScheduleTemplateFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Account' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAccountCollectionViaAccountCallCenterOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, GetRelationsForField("AccountCollectionViaAccountCallCenterOrganization"), null, "AccountCollectionViaAccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Contacts' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathContactsCollectionViaContactFranchiseeAccess
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.ContactFranchiseeAccessEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "ContactFranchiseeAccess_");
				return new PrefetchPathElement2(new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.ContactsEntity, 0, null, null, GetRelationsForField("ContactsCollectionViaContactFranchiseeAccess"), null, "ContactsCollectionViaContactFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaEventAccountTestHcpcsCode"), null, "EventsCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode"), null, "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountCallCenterOrganization
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountCallCenterOrganization"), null, "OrganizationRoleUserCollectionViaAccountCallCenterOrganization", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_"), null, "OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMarketingPrintOrder_
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.MarketingPrintOrderEntityUsingPrintVendorOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrder_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMarketingPrintOrder_"), null, "OrganizationRoleUserCollectionViaMarketingPrintOrder_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaMarketingPrintOrder
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.MarketingPrintOrderEntityUsingFranchiseeOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "MarketingPrintOrder_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaMarketingPrintOrder"), null, "OrganizationRoleUserCollectionViaMarketingPrintOrder", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountTestHcpcsCode_
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountTestHcpcsCode_"), null, "OrganizationRoleUserCollectionViaAccountTestHcpcsCode_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountTestHcpcsCode"), null, "OrganizationRoleUserCollectionViaAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAffiliateProfile
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AffiliateProfileEntityUsingOwnerOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "AffiliateProfile_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAffiliateProfile"), null, "OrganizationRoleUserCollectionViaAffiliateProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaAccountCallCenterOrganization_
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountCallCenterOrganizationEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "AccountCallCenterOrganization_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaAccountCallCenterOrganization_"), null, "OrganizationRoleUserCollectionViaAccountCallCenterOrganization_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.OrganizationRoleUserEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaOrganizationRoleUser"), null, "RoleCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ScheduleTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.ScheduleTemplateFranchiseeAccessEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "ScheduleTemplateFranchiseeAccess_");
				return new PrefetchPathElement2(new EntityCollection<ScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.ScheduleTemplateEntity, 0, null, null, GetRelationsForField("ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess"), null, "ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestHcpcsCodeCollectionViaAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.AccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "AccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, 0, null, null, GetRelationsForField("TestHcpcsCodeCollectionViaAccountTestHcpcsCode"), null, "TestHcpcsCodeCollectionViaAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TestHcpcsCode' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTestHcpcsCodeCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.EventAccountTestHcpcsCodeEntityUsingAccountId;
				intermediateRelation.SetAliases(string.Empty, "EventAccountTestHcpcsCode_");
				return new PrefetchPathElement2(new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.TestHcpcsCodeEntity, 0, null, null, GetRelationsForField("TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode"), null, "TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'User' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUserCollectionViaOrganizationRoleUser
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.OrganizationRoleUserEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "OrganizationRoleUser_");
				return new PrefetchPathElement2(new EntityCollection<UserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.UserEntity, 0, null, null, GetRelationsForField("UserCollectionViaOrganizationRoleUser"), null, "UserCollectionViaOrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'VanDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathVanDetailsCollectionViaPodDetails
		{
			get
			{
				IEntityRelation intermediateRelation = OrganizationEntity.Relations.PodDetailsEntityUsingOrganizationId;
				intermediateRelation.SetAliases(string.Empty, "PodDetails_");
				return new PrefetchPathElement2(new EntityCollection<VanDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VanDetailsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.VanDetailsEntity, 0, null, null, GetRelationsForField("VanDetailsCollectionViaPodDetails"), null, "VanDetailsCollectionViaPodDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddress
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))),
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("File_")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("File")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, null, null, "File", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationType")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.OrganizationTypeEntity, 0, null, null, null, null, "OrganizationType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HospitalFacility' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHospitalFacility
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HospitalFacilityEntityFactory))),
					(IEntityRelation)GetRelationsForField("HospitalFacility")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.HospitalFacilityEntity, 0, null, null, null, null, "HospitalFacility", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MedicalVendorProfile' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMedicalVendorProfile
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MedicalVendorProfileEntityFactory))),
					(IEntityRelation)GetRelationsForField("MedicalVendorProfile")[0], (int)Falcon.Data.EntityType.OrganizationEntity, (int)Falcon.Data.EntityType.MedicalVendorProfileEntity, 0, null, null, null, null, "MedicalVendorProfile", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OrganizationEntity.CustomProperties;}
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
			get { return OrganizationEntity.FieldsCustomProperties;}
		}

		/// <summary> The OrganizationId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."OrganizationID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OrganizationId
		{
			get { return (System.Int64)GetValue((int)OrganizationFieldIndex.OrganizationId, true); }
			set	{ SetValue((int)OrganizationFieldIndex.OrganizationId, value); }
		}

		/// <summary> The OrganizationTypeId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."OrganizationTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 OrganizationTypeId
		{
			get { return (System.Int64)GetValue((int)OrganizationFieldIndex.OrganizationTypeId, true); }
			set	{ SetValue((int)OrganizationFieldIndex.OrganizationTypeId, value); }
		}

		/// <summary> The Name property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.Name, true); }
			set	{ SetValue((int)OrganizationFieldIndex.Name, value); }
		}

		/// <summary> The Description property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."Description"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Description
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.Description, true); }
			set	{ SetValue((int)OrganizationFieldIndex.Description, value); }
		}

		/// <summary> The BusinessAddressId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."BusinessAddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BusinessAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.BusinessAddressId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.BusinessAddressId, value); }
		}

		/// <summary> The BillingAddressId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."BillingAddressId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> BillingAddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.BillingAddressId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.BillingAddressId, value); }
		}

		/// <summary> The PhoneNumber property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."PhoneNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneNumber
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.PhoneNumber, true); }
			set	{ SetValue((int)OrganizationFieldIndex.PhoneNumber, value); }
		}

		/// <summary> The FaxNumber property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."FaxNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String FaxNumber
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.FaxNumber, true); }
			set	{ SetValue((int)OrganizationFieldIndex.FaxNumber, value); }
		}

		/// <summary> The Email property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 128<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)OrganizationFieldIndex.Email, true); }
			set	{ SetValue((int)OrganizationFieldIndex.Email, value); }
		}

		/// <summary> The LogoImageId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."LogoImageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LogoImageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.LogoImageId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.LogoImageId, value); }
		}

		/// <summary> The TeamImageId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."TeamImageID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TeamImageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.TeamImageId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.TeamImageId, value); }
		}

		/// <summary> The DateCreated property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateCreated
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OrganizationFieldIndex.DateCreated, false); }
			set	{ SetValue((int)OrganizationFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)OrganizationFieldIndex.DateModified, false); }
			set	{ SetValue((int)OrganizationFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CreatedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.CreatedByOrgRoleUserId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OrganizationFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)OrganizationFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The IsActive property of the Entity Organization<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblOrganization"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)OrganizationFieldIndex.IsActive, true); }
			set	{ SetValue((int)OrganizationFieldIndex.IsActive, value); }
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
					_accountCallCenterOrganization.SetContainingEntityInfo(this, "Organization");
				}
				return _accountCallCenterOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountTestHcpcsCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountTestHcpcsCodeEntity))]
		public virtual EntityCollection<AccountTestHcpcsCodeEntity> AccountTestHcpcsCode
		{
			get
			{
				if(_accountTestHcpcsCode==null)
				{
					_accountTestHcpcsCode = new EntityCollection<AccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountTestHcpcsCodeEntityFactory)));
					_accountTestHcpcsCode.SetContainingEntityInfo(this, "Organization");
				}
				return _accountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AfcampaignTemplateEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AfcampaignTemplateEntity))]
		public virtual EntityCollection<AfcampaignTemplateEntity> AfcampaignTemplate
		{
			get
			{
				if(_afcampaignTemplate==null)
				{
					_afcampaignTemplate = new EntityCollection<AfcampaignTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AfcampaignTemplateEntityFactory)));
					_afcampaignTemplate.SetContainingEntityInfo(this, "Organization");
				}
				return _afcampaignTemplate;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AffiliateProfileEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AffiliateProfileEntity))]
		public virtual EntityCollection<AffiliateProfileEntity> AffiliateProfile
		{
			get
			{
				if(_affiliateProfile==null)
				{
					_affiliateProfile = new EntityCollection<AffiliateProfileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AffiliateProfileEntityFactory)));
					_affiliateProfile.SetContainingEntityInfo(this, "Organization");
				}
				return _affiliateProfile;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BlockedDaysFranchiseeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BlockedDaysFranchiseeEntity))]
		public virtual EntityCollection<BlockedDaysFranchiseeEntity> BlockedDaysFranchisee
		{
			get
			{
				if(_blockedDaysFranchisee==null)
				{
					_blockedDaysFranchisee = new EntityCollection<BlockedDaysFranchiseeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BlockedDaysFranchiseeEntityFactory)));
					_blockedDaysFranchisee.SetContainingEntityInfo(this, "Organization");
				}
				return _blockedDaysFranchisee;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactFranchiseeAccessEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactFranchiseeAccessEntity))]
		public virtual EntityCollection<ContactFranchiseeAccessEntity> ContactFranchiseeAccess
		{
			get
			{
				if(_contactFranchiseeAccess==null)
				{
					_contactFranchiseeAccess = new EntityCollection<ContactFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactFranchiseeAccessEntityFactory)));
					_contactFranchiseeAccess.SetContainingEntityInfo(this, "Organization");
				}
				return _contactFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventAccountTestHcpcsCodeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventAccountTestHcpcsCodeEntity))]
		public virtual EntityCollection<EventAccountTestHcpcsCodeEntity> EventAccountTestHcpcsCode
		{
			get
			{
				if(_eventAccountTestHcpcsCode==null)
				{
					_eventAccountTestHcpcsCode = new EntityCollection<EventAccountTestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventAccountTestHcpcsCodeEntityFactory)));
					_eventAccountTestHcpcsCode.SetContainingEntityInfo(this, "Organization");
				}
				return _eventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FranchiseeTerritoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FranchiseeTerritoryEntity))]
		public virtual EntityCollection<FranchiseeTerritoryEntity> FranchiseeTerritory
		{
			get
			{
				if(_franchiseeTerritory==null)
				{
					_franchiseeTerritory = new EntityCollection<FranchiseeTerritoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FranchiseeTerritoryEntityFactory)));
					_franchiseeTerritory.SetContainingEntityInfo(this, "Organization");
				}
				return _franchiseeTerritory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderEntity))]
		public virtual EntityCollection<MarketingPrintOrderEntity> MarketingPrintOrder_
		{
			get
			{
				if(_marketingPrintOrder_==null)
				{
					_marketingPrintOrder_ = new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory)));
					_marketingPrintOrder_.SetContainingEntityInfo(this, "Organization_");
				}
				return _marketingPrintOrder_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MarketingPrintOrderEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MarketingPrintOrderEntity))]
		public virtual EntityCollection<MarketingPrintOrderEntity> MarketingPrintOrder
		{
			get
			{
				if(_marketingPrintOrder==null)
				{
					_marketingPrintOrder = new EntityCollection<MarketingPrintOrderEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MarketingPrintOrderEntityFactory)));
					_marketingPrintOrder.SetContainingEntityInfo(this, "Organization");
				}
				return _marketingPrintOrder;
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
					_organizationRoleUser.SetContainingEntityInfo(this, "Organization");
				}
				return _organizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'PodDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(PodDetailsEntity))]
		public virtual EntityCollection<PodDetailsEntity> PodDetails
		{
			get
			{
				if(_podDetails==null)
				{
					_podDetails = new EntityCollection<PodDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(PodDetailsEntityFactory)));
					_podDetails.SetContainingEntityInfo(this, "Organization");
				}
				return _podDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectListDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectListDetailsEntity))]
		public virtual EntityCollection<ProspectListDetailsEntity> ProspectListDetails
		{
			get
			{
				if(_prospectListDetails==null)
				{
					_prospectListDetails = new EntityCollection<ProspectListDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory)));
					_prospectListDetails.SetContainingEntityInfo(this, "Organization");
				}
				return _prospectListDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleTemplateFranchiseeAccessEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleTemplateFranchiseeAccessEntity))]
		public virtual EntityCollection<ScheduleTemplateFranchiseeAccessEntity> ScheduleTemplateFranchiseeAccess
		{
			get
			{
				if(_scheduleTemplateFranchiseeAccess==null)
				{
					_scheduleTemplateFranchiseeAccess = new EntityCollection<ScheduleTemplateFranchiseeAccessEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateFranchiseeAccessEntityFactory)));
					_scheduleTemplateFranchiseeAccess.SetContainingEntityInfo(this, "Organization");
				}
				return _scheduleTemplateFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AccountEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AccountEntity))]
		public virtual EntityCollection<AccountEntity> AccountCollectionViaAccountCallCenterOrganization
		{
			get
			{
				if(_accountCollectionViaAccountCallCenterOrganization==null)
				{
					_accountCollectionViaAccountCallCenterOrganization = new EntityCollection<AccountEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AccountEntityFactory)));
					_accountCollectionViaAccountCallCenterOrganization.IsReadOnly=true;
				}
				return _accountCollectionViaAccountCallCenterOrganization;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ContactsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ContactsEntity))]
		public virtual EntityCollection<ContactsEntity> ContactsCollectionViaContactFranchiseeAccess
		{
			get
			{
				if(_contactsCollectionViaContactFranchiseeAccess==null)
				{
					_contactsCollectionViaContactFranchiseeAccess = new EntityCollection<ContactsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ContactsEntityFactory)));
					_contactsCollectionViaContactFranchiseeAccess.IsReadOnly=true;
				}
				return _contactsCollectionViaContactFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_eventsCollectionViaEventAccountTestHcpcsCode==null)
				{
					_eventsCollectionViaEventAccountTestHcpcsCode = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _eventsCollectionViaEventAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode==null)
				{
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAccountTestHcpcsCode;
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
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaEventAccountTestHcpcsCode_
		{
			get
			{
				if(_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_==null)
				{
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaEventAccountTestHcpcsCode_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaEventAccountTestHcpcsCode_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMarketingPrintOrder_
		{
			get
			{
				if(_organizationRoleUserCollectionViaMarketingPrintOrder_==null)
				{
					_organizationRoleUserCollectionViaMarketingPrintOrder_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMarketingPrintOrder_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMarketingPrintOrder_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaMarketingPrintOrder
		{
			get
			{
				if(_organizationRoleUserCollectionViaMarketingPrintOrder==null)
				{
					_organizationRoleUserCollectionViaMarketingPrintOrder = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaMarketingPrintOrder.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaMarketingPrintOrder;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountTestHcpcsCode_
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountTestHcpcsCode_==null)
				{
					_organizationRoleUserCollectionViaAccountTestHcpcsCode_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountTestHcpcsCode_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountTestHcpcsCode_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAccountTestHcpcsCode
		{
			get
			{
				if(_organizationRoleUserCollectionViaAccountTestHcpcsCode==null)
				{
					_organizationRoleUserCollectionViaAccountTestHcpcsCode = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaAffiliateProfile
		{
			get
			{
				if(_organizationRoleUserCollectionViaAffiliateProfile==null)
				{
					_organizationRoleUserCollectionViaAffiliateProfile = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaAffiliateProfile.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaAffiliateProfile;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaOrganizationRoleUser
		{
			get
			{
				if(_roleCollectionViaOrganizationRoleUser==null)
				{
					_roleCollectionViaOrganizationRoleUser = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaOrganizationRoleUser.IsReadOnly=true;
				}
				return _roleCollectionViaOrganizationRoleUser;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ScheduleTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ScheduleTemplateEntity))]
		public virtual EntityCollection<ScheduleTemplateEntity> ScheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess
		{
			get
			{
				if(_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess==null)
				{
					_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess = new EntityCollection<ScheduleTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ScheduleTemplateEntityFactory)));
					_scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess.IsReadOnly=true;
				}
				return _scheduleTemplateCollectionViaScheduleTemplateFranchiseeAccess;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestHcpcsCodeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestHcpcsCodeEntity))]
		public virtual EntityCollection<TestHcpcsCodeEntity> TestHcpcsCodeCollectionViaAccountTestHcpcsCode
		{
			get
			{
				if(_testHcpcsCodeCollectionViaAccountTestHcpcsCode==null)
				{
					_testHcpcsCodeCollectionViaAccountTestHcpcsCode = new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory)));
					_testHcpcsCodeCollectionViaAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _testHcpcsCodeCollectionViaAccountTestHcpcsCode;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TestHcpcsCodeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TestHcpcsCodeEntity))]
		public virtual EntityCollection<TestHcpcsCodeEntity> TestHcpcsCodeCollectionViaEventAccountTestHcpcsCode
		{
			get
			{
				if(_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode==null)
				{
					_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode = new EntityCollection<TestHcpcsCodeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TestHcpcsCodeEntityFactory)));
					_testHcpcsCodeCollectionViaEventAccountTestHcpcsCode.IsReadOnly=true;
				}
				return _testHcpcsCodeCollectionViaEventAccountTestHcpcsCode;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'VanDetailsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(VanDetailsEntity))]
		public virtual EntityCollection<VanDetailsEntity> VanDetailsCollectionViaPodDetails
		{
			get
			{
				if(_vanDetailsCollectionViaPodDetails==null)
				{
					_vanDetailsCollectionViaPodDetails = new EntityCollection<VanDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VanDetailsEntityFactory)));
					_vanDetailsCollectionViaPodDetails.IsReadOnly=true;
				}
				return _vanDetailsCollectionViaPodDetails;
			}
		}

		/// <summary> Gets / sets related entity of type 'AddressEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual AddressEntity Address
		{
			get
			{
				return _address;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncAddress(value);
				}
				else
				{
					if(value==null)
					{
						if(_address != null)
						{
							_address.UnsetRelatedEntity(this, "Organization");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Organization");
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
							_file_.UnsetRelatedEntity(this, "Organization_");
						}
					}
					else
					{
						if(_file_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Organization_");
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
							_file.UnsetRelatedEntity(this, "Organization");
						}
					}
					else
					{
						if(_file!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Organization");
						}
					}
				}
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
							_organizationType.UnsetRelatedEntity(this, "Organization");
						}
					}
					else
					{
						if(_organizationType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Organization");
						}
					}
				}
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
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Organization");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_account !=null);
						DesetupSyncAccount(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("Account");
						}
					}
					else
					{
						if(_account!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Organization");
							SetupSyncAccount(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HospitalFacilityEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HospitalFacilityEntity HospitalFacility
		{
			get
			{
				return _hospitalFacility;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHospitalFacility(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Organization");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_hospitalFacility !=null);
						DesetupSyncHospitalFacility(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("HospitalFacility");
						}
					}
					else
					{
						if(_hospitalFacility!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Organization");
							SetupSyncHospitalFacility(relatedEntity);
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MedicalVendorProfileEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MedicalVendorProfileEntity MedicalVendorProfile
		{
			get
			{
				return _medicalVendorProfile;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMedicalVendorProfile(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Organization");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_medicalVendorProfile !=null);
						DesetupSyncMedicalVendorProfile(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("MedicalVendorProfile");
						}
					}
					else
					{
						if(_medicalVendorProfile!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Organization");
							SetupSyncMedicalVendorProfile(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.OrganizationEntity; }
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
