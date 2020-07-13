///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 27 June 2019 17:22:47
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
	/// Entity class which represents the entity 'Prospects'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ProspectsEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<AccountEntity> _account;
		private EntityCollection<HostEventDetailsEntity> _hostEventDetails;
		private EntityCollection<HostFacilityRankingEntity> _hostFacilityRanking;
		private EntityCollection<HostImageEntity> _hostImage;
		private EntityCollection<HostPaymentEntity> _hostPayment;
		private EntityCollection<ProspectActivityDetailsEntity> _prospectActivityDetails;
		private EntityCollection<ProspectCallDetailsEntity> _prospectCallDetails;
		private EntityCollection<ProspectContactEntity> _prospectContact;
		private EntityCollection<AddressEntity> _addressCollectionViaHostPayment;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount_;
		private EntityCollection<CheckListTemplateEntity> _checkListTemplateCollectionViaAccount;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount__;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount_;
		private EntityCollection<EmailTemplateEntity> _emailTemplateCollectionViaAccount___;
		private EntityCollection<EventsEntity> _eventsCollectionViaHostPayment;
		private EntityCollection<EventsEntity> _eventsCollectionViaHostEventDetails;
		private EntityCollection<FileEntity> _fileCollectionViaAccount__;
		private EntityCollection<FileEntity> _fileCollectionViaAccount________;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_;
		private EntityCollection<FileEntity> _fileCollectionViaAccount;
		private EntityCollection<FileEntity> _fileCollectionViaHostImage;
		private EntityCollection<FileEntity> _fileCollectionViaAccount____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount___;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_____;
		private EntityCollection<FileEntity> _fileCollectionViaAccount_______;
		private EntityCollection<FileEntity> _fileCollectionViaAccount______;
		private EntityCollection<FluConsentTemplateEntity> _fluConsentTemplateCollectionViaAccount;
		private EntityCollection<HafTemplateEntity> _hafTemplateCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaAccount;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostImage;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPayment;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostFacilityRanking;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostFacilityRanking_;
		private EntityCollection<LookupEntity> _lookupCollectionViaHostPayment_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHostFacilityRanking;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHostPayment;
		private EntityCollection<RoleEntity> _roleCollectionViaHostFacilityRanking;
		private EntityCollection<SurveyTemplateEntity> _surveyTemplateCollectionViaAccount;
		private AddressEntity _address;
		private OrganizationRoleUserEntity _organizationRoleUser;
		private ProspectListDetailsEntity _prospectListDetails;
		private ProspectTypeEntity _prospectType;
		private HostNotesEntity _hostNotes;
		
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
			/// <summary>Member name OrganizationRoleUser</summary>
			public static readonly string OrganizationRoleUser = "OrganizationRoleUser";
			/// <summary>Member name ProspectListDetails</summary>
			public static readonly string ProspectListDetails = "ProspectListDetails";
			/// <summary>Member name ProspectType</summary>
			public static readonly string ProspectType = "ProspectType";
			/// <summary>Member name Account</summary>
			public static readonly string Account = "Account";
			/// <summary>Member name HostEventDetails</summary>
			public static readonly string HostEventDetails = "HostEventDetails";
			/// <summary>Member name HostFacilityRanking</summary>
			public static readonly string HostFacilityRanking = "HostFacilityRanking";
			/// <summary>Member name HostImage</summary>
			public static readonly string HostImage = "HostImage";
			/// <summary>Member name HostPayment</summary>
			public static readonly string HostPayment = "HostPayment";
			/// <summary>Member name ProspectActivityDetails</summary>
			public static readonly string ProspectActivityDetails = "ProspectActivityDetails";
			/// <summary>Member name ProspectCallDetails</summary>
			public static readonly string ProspectCallDetails = "ProspectCallDetails";
			/// <summary>Member name ProspectContact</summary>
			public static readonly string ProspectContact = "ProspectContact";
			/// <summary>Member name AddressCollectionViaHostPayment</summary>
			public static readonly string AddressCollectionViaHostPayment = "AddressCollectionViaHostPayment";
			/// <summary>Member name CheckListTemplateCollectionViaAccount_</summary>
			public static readonly string CheckListTemplateCollectionViaAccount_ = "CheckListTemplateCollectionViaAccount_";
			/// <summary>Member name CheckListTemplateCollectionViaAccount</summary>
			public static readonly string CheckListTemplateCollectionViaAccount = "CheckListTemplateCollectionViaAccount";
			/// <summary>Member name EmailTemplateCollectionViaAccount__</summary>
			public static readonly string EmailTemplateCollectionViaAccount__ = "EmailTemplateCollectionViaAccount__";
			/// <summary>Member name EmailTemplateCollectionViaAccount</summary>
			public static readonly string EmailTemplateCollectionViaAccount = "EmailTemplateCollectionViaAccount";
			/// <summary>Member name EmailTemplateCollectionViaAccount_</summary>
			public static readonly string EmailTemplateCollectionViaAccount_ = "EmailTemplateCollectionViaAccount_";
			/// <summary>Member name EmailTemplateCollectionViaAccount___</summary>
			public static readonly string EmailTemplateCollectionViaAccount___ = "EmailTemplateCollectionViaAccount___";
			/// <summary>Member name EventsCollectionViaHostPayment</summary>
			public static readonly string EventsCollectionViaHostPayment = "EventsCollectionViaHostPayment";
			/// <summary>Member name EventsCollectionViaHostEventDetails</summary>
			public static readonly string EventsCollectionViaHostEventDetails = "EventsCollectionViaHostEventDetails";
			/// <summary>Member name FileCollectionViaAccount__</summary>
			public static readonly string FileCollectionViaAccount__ = "FileCollectionViaAccount__";
			/// <summary>Member name FileCollectionViaAccount________</summary>
			public static readonly string FileCollectionViaAccount________ = "FileCollectionViaAccount________";
			/// <summary>Member name FileCollectionViaAccount_</summary>
			public static readonly string FileCollectionViaAccount_ = "FileCollectionViaAccount_";
			/// <summary>Member name FileCollectionViaAccount</summary>
			public static readonly string FileCollectionViaAccount = "FileCollectionViaAccount";
			/// <summary>Member name FileCollectionViaHostImage</summary>
			public static readonly string FileCollectionViaHostImage = "FileCollectionViaHostImage";
			/// <summary>Member name FileCollectionViaAccount____</summary>
			public static readonly string FileCollectionViaAccount____ = "FileCollectionViaAccount____";
			/// <summary>Member name FileCollectionViaAccount___</summary>
			public static readonly string FileCollectionViaAccount___ = "FileCollectionViaAccount___";
			/// <summary>Member name FileCollectionViaAccount_____</summary>
			public static readonly string FileCollectionViaAccount_____ = "FileCollectionViaAccount_____";
			/// <summary>Member name FileCollectionViaAccount_______</summary>
			public static readonly string FileCollectionViaAccount_______ = "FileCollectionViaAccount_______";
			/// <summary>Member name FileCollectionViaAccount______</summary>
			public static readonly string FileCollectionViaAccount______ = "FileCollectionViaAccount______";
			/// <summary>Member name FluConsentTemplateCollectionViaAccount</summary>
			public static readonly string FluConsentTemplateCollectionViaAccount = "FluConsentTemplateCollectionViaAccount";
			/// <summary>Member name HafTemplateCollectionViaAccount</summary>
			public static readonly string HafTemplateCollectionViaAccount = "HafTemplateCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaAccount</summary>
			public static readonly string LookupCollectionViaAccount = "LookupCollectionViaAccount";
			/// <summary>Member name LookupCollectionViaHostImage</summary>
			public static readonly string LookupCollectionViaHostImage = "LookupCollectionViaHostImage";
			/// <summary>Member name LookupCollectionViaHostPayment</summary>
			public static readonly string LookupCollectionViaHostPayment = "LookupCollectionViaHostPayment";
			/// <summary>Member name LookupCollectionViaHostFacilityRanking</summary>
			public static readonly string LookupCollectionViaHostFacilityRanking = "LookupCollectionViaHostFacilityRanking";
			/// <summary>Member name LookupCollectionViaHostFacilityRanking_</summary>
			public static readonly string LookupCollectionViaHostFacilityRanking_ = "LookupCollectionViaHostFacilityRanking_";
			/// <summary>Member name LookupCollectionViaHostPayment_</summary>
			public static readonly string LookupCollectionViaHostPayment_ = "LookupCollectionViaHostPayment_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHostFacilityRanking</summary>
			public static readonly string OrganizationRoleUserCollectionViaHostFacilityRanking = "OrganizationRoleUserCollectionViaHostFacilityRanking";
			/// <summary>Member name OrganizationRoleUserCollectionViaHostPayment</summary>
			public static readonly string OrganizationRoleUserCollectionViaHostPayment = "OrganizationRoleUserCollectionViaHostPayment";
			/// <summary>Member name RoleCollectionViaHostFacilityRanking</summary>
			public static readonly string RoleCollectionViaHostFacilityRanking = "RoleCollectionViaHostFacilityRanking";
			/// <summary>Member name SurveyTemplateCollectionViaAccount</summary>
			public static readonly string SurveyTemplateCollectionViaAccount = "SurveyTemplateCollectionViaAccount";
			/// <summary>Member name HostNotes</summary>
			public static readonly string HostNotes = "HostNotes";
		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ProspectsEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ProspectsEntity():base("ProspectsEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ProspectsEntity(IEntityFields2 fields):base("ProspectsEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ProspectsEntity</param>
		public ProspectsEntity(IValidator validator):base("ProspectsEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="prospectId">PK value for Prospects which data should be fetched into this Prospects object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectsEntity(System.Int64 prospectId):base("ProspectsEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ProspectId = prospectId;
		}

		/// <summary> CTor</summary>
		/// <param name="prospectId">PK value for Prospects which data should be fetched into this Prospects object</param>
		/// <param name="validator">The custom validator object for this ProspectsEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ProspectsEntity(System.Int64 prospectId, IValidator validator):base("ProspectsEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ProspectId = prospectId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ProspectsEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_account = (EntityCollection<AccountEntity>)info.GetValue("_account", typeof(EntityCollection<AccountEntity>));
				_hostEventDetails = (EntityCollection<HostEventDetailsEntity>)info.GetValue("_hostEventDetails", typeof(EntityCollection<HostEventDetailsEntity>));
				_hostFacilityRanking = (EntityCollection<HostFacilityRankingEntity>)info.GetValue("_hostFacilityRanking", typeof(EntityCollection<HostFacilityRankingEntity>));
				_hostImage = (EntityCollection<HostImageEntity>)info.GetValue("_hostImage", typeof(EntityCollection<HostImageEntity>));
				_hostPayment = (EntityCollection<HostPaymentEntity>)info.GetValue("_hostPayment", typeof(EntityCollection<HostPaymentEntity>));
				_prospectActivityDetails = (EntityCollection<ProspectActivityDetailsEntity>)info.GetValue("_prospectActivityDetails", typeof(EntityCollection<ProspectActivityDetailsEntity>));
				_prospectCallDetails = (EntityCollection<ProspectCallDetailsEntity>)info.GetValue("_prospectCallDetails", typeof(EntityCollection<ProspectCallDetailsEntity>));
				_prospectContact = (EntityCollection<ProspectContactEntity>)info.GetValue("_prospectContact", typeof(EntityCollection<ProspectContactEntity>));
				_addressCollectionViaHostPayment = (EntityCollection<AddressEntity>)info.GetValue("_addressCollectionViaHostPayment", typeof(EntityCollection<AddressEntity>));
				_checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount_", typeof(EntityCollection<CheckListTemplateEntity>));
				_checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>)info.GetValue("_checkListTemplateCollectionViaAccount", typeof(EntityCollection<CheckListTemplateEntity>));
				_emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount__", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount_", typeof(EntityCollection<EmailTemplateEntity>));
				_emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>)info.GetValue("_emailTemplateCollectionViaAccount___", typeof(EntityCollection<EmailTemplateEntity>));
				_eventsCollectionViaHostPayment = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaHostPayment", typeof(EntityCollection<EventsEntity>));
				_eventsCollectionViaHostEventDetails = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaHostEventDetails", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaAccount__ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount__", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount________ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount________", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaHostImage = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaHostImage", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount___ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount___", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_____ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_____", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount_______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount_______", typeof(EntityCollection<FileEntity>));
				_fileCollectionViaAccount______ = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaAccount______", typeof(EntityCollection<FileEntity>));
				_fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>)info.GetValue("_fluConsentTemplateCollectionViaAccount", typeof(EntityCollection<FluConsentTemplateEntity>));
				_hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>)info.GetValue("_hafTemplateCollectionViaAccount", typeof(EntityCollection<HafTemplateEntity>));
				_lookupCollectionViaAccount = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaAccount", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostImage = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostImage", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostPayment = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPayment", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostFacilityRanking = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostFacilityRanking", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostFacilityRanking_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostFacilityRanking_", typeof(EntityCollection<LookupEntity>));
				_lookupCollectionViaHostPayment_ = (EntityCollection<LookupEntity>)info.GetValue("_lookupCollectionViaHostPayment_", typeof(EntityCollection<LookupEntity>));
				_organizationRoleUserCollectionViaHostFacilityRanking = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHostFacilityRanking", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHostPayment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHostPayment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_roleCollectionViaHostFacilityRanking = (EntityCollection<RoleEntity>)info.GetValue("_roleCollectionViaHostFacilityRanking", typeof(EntityCollection<RoleEntity>));
				_surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>)info.GetValue("_surveyTemplateCollectionViaAccount", typeof(EntityCollection<SurveyTemplateEntity>));
				_address = (AddressEntity)info.GetValue("_address", typeof(AddressEntity));
				if(_address!=null)
				{
					_address.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser!=null)
				{
					_organizationRoleUser.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospectListDetails = (ProspectListDetailsEntity)info.GetValue("_prospectListDetails", typeof(ProspectListDetailsEntity));
				if(_prospectListDetails!=null)
				{
					_prospectListDetails.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_prospectType = (ProspectTypeEntity)info.GetValue("_prospectType", typeof(ProspectTypeEntity));
				if(_prospectType!=null)
				{
					_prospectType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_hostNotes = (HostNotesEntity)info.GetValue("_hostNotes", typeof(HostNotesEntity));
				if(_hostNotes!=null)
				{
					_hostNotes.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ProspectsFieldIndex)fieldIndex)
			{
				case ProspectsFieldIndex.ProspectListId:
					DesetupSyncProspectListDetails(true, false);
					break;
				case ProspectsFieldIndex.ProspectTypeId:
					DesetupSyncProspectType(true, false);
					break;
				case ProspectsFieldIndex.AddressId:
					DesetupSyncAddress(true, false);
					break;
				case ProspectsFieldIndex.OrgRoleUserId:
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
				case "Address":
					this.Address = (AddressEntity)entity;
					break;
				case "OrganizationRoleUser":
					this.OrganizationRoleUser = (OrganizationRoleUserEntity)entity;
					break;
				case "ProspectListDetails":
					this.ProspectListDetails = (ProspectListDetailsEntity)entity;
					break;
				case "ProspectType":
					this.ProspectType = (ProspectTypeEntity)entity;
					break;
				case "Account":
					this.Account.Add((AccountEntity)entity);
					break;
				case "HostEventDetails":
					this.HostEventDetails.Add((HostEventDetailsEntity)entity);
					break;
				case "HostFacilityRanking":
					this.HostFacilityRanking.Add((HostFacilityRankingEntity)entity);
					break;
				case "HostImage":
					this.HostImage.Add((HostImageEntity)entity);
					break;
				case "HostPayment":
					this.HostPayment.Add((HostPaymentEntity)entity);
					break;
				case "ProspectActivityDetails":
					this.ProspectActivityDetails.Add((ProspectActivityDetailsEntity)entity);
					break;
				case "ProspectCallDetails":
					this.ProspectCallDetails.Add((ProspectCallDetailsEntity)entity);
					break;
				case "ProspectContact":
					this.ProspectContact.Add((ProspectContactEntity)entity);
					break;
				case "AddressCollectionViaHostPayment":
					this.AddressCollectionViaHostPayment.IsReadOnly = false;
					this.AddressCollectionViaHostPayment.Add((AddressEntity)entity);
					this.AddressCollectionViaHostPayment.IsReadOnly = true;
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
				case "EmailTemplateCollectionViaAccount__":
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount__.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount__.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount":
					this.EmailTemplateCollectionViaAccount.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount_":
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount_.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount_.IsReadOnly = true;
					break;
				case "EmailTemplateCollectionViaAccount___":
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = false;
					this.EmailTemplateCollectionViaAccount___.Add((EmailTemplateEntity)entity);
					this.EmailTemplateCollectionViaAccount___.IsReadOnly = true;
					break;
				case "EventsCollectionViaHostPayment":
					this.EventsCollectionViaHostPayment.IsReadOnly = false;
					this.EventsCollectionViaHostPayment.Add((EventsEntity)entity);
					this.EventsCollectionViaHostPayment.IsReadOnly = true;
					break;
				case "EventsCollectionViaHostEventDetails":
					this.EventsCollectionViaHostEventDetails.IsReadOnly = false;
					this.EventsCollectionViaHostEventDetails.Add((EventsEntity)entity);
					this.EventsCollectionViaHostEventDetails.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount__":
					this.FileCollectionViaAccount__.IsReadOnly = false;
					this.FileCollectionViaAccount__.Add((FileEntity)entity);
					this.FileCollectionViaAccount__.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount________":
					this.FileCollectionViaAccount________.IsReadOnly = false;
					this.FileCollectionViaAccount________.Add((FileEntity)entity);
					this.FileCollectionViaAccount________.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_":
					this.FileCollectionViaAccount_.IsReadOnly = false;
					this.FileCollectionViaAccount_.Add((FileEntity)entity);
					this.FileCollectionViaAccount_.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount":
					this.FileCollectionViaAccount.IsReadOnly = false;
					this.FileCollectionViaAccount.Add((FileEntity)entity);
					this.FileCollectionViaAccount.IsReadOnly = true;
					break;
				case "FileCollectionViaHostImage":
					this.FileCollectionViaHostImage.IsReadOnly = false;
					this.FileCollectionViaHostImage.Add((FileEntity)entity);
					this.FileCollectionViaHostImage.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount____":
					this.FileCollectionViaAccount____.IsReadOnly = false;
					this.FileCollectionViaAccount____.Add((FileEntity)entity);
					this.FileCollectionViaAccount____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount___":
					this.FileCollectionViaAccount___.IsReadOnly = false;
					this.FileCollectionViaAccount___.Add((FileEntity)entity);
					this.FileCollectionViaAccount___.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_____":
					this.FileCollectionViaAccount_____.IsReadOnly = false;
					this.FileCollectionViaAccount_____.Add((FileEntity)entity);
					this.FileCollectionViaAccount_____.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount_______":
					this.FileCollectionViaAccount_______.IsReadOnly = false;
					this.FileCollectionViaAccount_______.Add((FileEntity)entity);
					this.FileCollectionViaAccount_______.IsReadOnly = true;
					break;
				case "FileCollectionViaAccount______":
					this.FileCollectionViaAccount______.IsReadOnly = false;
					this.FileCollectionViaAccount______.Add((FileEntity)entity);
					this.FileCollectionViaAccount______.IsReadOnly = true;
					break;
				case "FluConsentTemplateCollectionViaAccount":
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = false;
					this.FluConsentTemplateCollectionViaAccount.Add((FluConsentTemplateEntity)entity);
					this.FluConsentTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "HafTemplateCollectionViaAccount":
					this.HafTemplateCollectionViaAccount.IsReadOnly = false;
					this.HafTemplateCollectionViaAccount.Add((HafTemplateEntity)entity);
					this.HafTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaAccount":
					this.LookupCollectionViaAccount.IsReadOnly = false;
					this.LookupCollectionViaAccount.Add((LookupEntity)entity);
					this.LookupCollectionViaAccount.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostImage":
					this.LookupCollectionViaHostImage.IsReadOnly = false;
					this.LookupCollectionViaHostImage.Add((LookupEntity)entity);
					this.LookupCollectionViaHostImage.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostPayment":
					this.LookupCollectionViaHostPayment.IsReadOnly = false;
					this.LookupCollectionViaHostPayment.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPayment.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostFacilityRanking":
					this.LookupCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.LookupCollectionViaHostFacilityRanking.Add((LookupEntity)entity);
					this.LookupCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostFacilityRanking_":
					this.LookupCollectionViaHostFacilityRanking_.IsReadOnly = false;
					this.LookupCollectionViaHostFacilityRanking_.Add((LookupEntity)entity);
					this.LookupCollectionViaHostFacilityRanking_.IsReadOnly = true;
					break;
				case "LookupCollectionViaHostPayment_":
					this.LookupCollectionViaHostPayment_.IsReadOnly = false;
					this.LookupCollectionViaHostPayment_.Add((LookupEntity)entity);
					this.LookupCollectionViaHostPayment_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHostFacilityRanking":
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHostPayment":
					this.OrganizationRoleUserCollectionViaHostPayment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHostPayment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHostPayment.IsReadOnly = true;
					break;
				case "RoleCollectionViaHostFacilityRanking":
					this.RoleCollectionViaHostFacilityRanking.IsReadOnly = false;
					this.RoleCollectionViaHostFacilityRanking.Add((RoleEntity)entity);
					this.RoleCollectionViaHostFacilityRanking.IsReadOnly = true;
					break;
				case "SurveyTemplateCollectionViaAccount":
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = false;
					this.SurveyTemplateCollectionViaAccount.Add((SurveyTemplateEntity)entity);
					this.SurveyTemplateCollectionViaAccount.IsReadOnly = true;
					break;
				case "HostNotes":
					this.HostNotes = (HostNotesEntity)entity;
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
			return ProspectsEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(ProspectsEntity.Relations.AddressEntityUsingAddressId);
					break;
				case "OrganizationRoleUser":
					toReturn.Add(ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId);
					break;
				case "ProspectListDetails":
					toReturn.Add(ProspectsEntity.Relations.ProspectListDetailsEntityUsingProspectListId);
					break;
				case "ProspectType":
					toReturn.Add(ProspectsEntity.Relations.ProspectTypeEntityUsingProspectTypeId);
					break;
				case "Account":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId);
					break;
				case "HostEventDetails":
					toReturn.Add(ProspectsEntity.Relations.HostEventDetailsEntityUsingHostId);
					break;
				case "HostFacilityRanking":
					toReturn.Add(ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId);
					break;
				case "HostImage":
					toReturn.Add(ProspectsEntity.Relations.HostImageEntityUsingHostId);
					break;
				case "HostPayment":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId);
					break;
				case "ProspectActivityDetails":
					toReturn.Add(ProspectsEntity.Relations.ProspectActivityDetailsEntityUsingProspectId);
					break;
				case "ProspectCallDetails":
					toReturn.Add(ProspectsEntity.Relations.ProspectCallDetailsEntityUsingProspectsId);
					break;
				case "ProspectContact":
					toReturn.Add(ProspectsEntity.Relations.ProspectContactEntityUsingProspectId);
					break;
				case "AddressCollectionViaHostPayment":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId, "ProspectsEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.AddressEntityUsingMailingAddressId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount_":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingCheckListTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "CheckListTemplateCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.CheckListTemplateEntityUsingExitInterviewTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount__":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingPcpCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingConfirmationSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount_":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingMemberCoverLetterTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EmailTemplateCollectionViaAccount___":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.EmailTemplateEntityUsingReminderSmsTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaHostPayment":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId, "ProspectsEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.EventsEntityUsingEventId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaHostEventDetails":
					toReturn.Add(ProspectsEntity.Relations.HostEventDetailsEntityUsingHostId, "ProspectsEntity__", "HostEventDetails_", JoinHint.None);
					toReturn.Add(HostEventDetailsEntity.Relations.EventsEntityUsingEventId, "HostEventDetails_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount__":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingPcpLetterPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount________":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingMemberLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingParticipantLetterId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCheckListFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaHostImage":
					toReturn.Add(ProspectsEntity.Relations.HostImageEntityUsingHostId, "ProspectsEntity__", "HostImage_", JoinHint.None);
					toReturn.Add(HostImageEntity.Relations.FileEntityUsingImageId, "HostImage_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount____":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingFluffLetterFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount___":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingSurveyPdfFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_____":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingCallCenterScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount_______":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingInboundCallScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaAccount______":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FileEntityUsingConfirmationScriptFileId, "Account_", string.Empty, JoinHint.None);
					break;
				case "FluConsentTemplateCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.FluConsentTemplateEntityUsingFluConsentTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HafTemplateCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.HafTemplateEntityUsingClinicalQuestionTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.LookupEntityUsingResultFormatTypeId, "Account_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostImage":
					toReturn.Add(ProspectsEntity.Relations.HostImageEntityUsingHostId, "ProspectsEntity__", "HostImage_", JoinHint.None);
					toReturn.Add(HostImageEntity.Relations.LookupEntityUsingHostImageType, "HostImage_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostPayment":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId, "ProspectsEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingDepositType, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostFacilityRanking":
					toReturn.Add(ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId, "ProspectsEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.LookupEntityUsingInternetAccess, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostFacilityRanking_":
					toReturn.Add(ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId, "ProspectsEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.LookupEntityUsingRanking, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "LookupCollectionViaHostPayment_":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId, "ProspectsEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.LookupEntityUsingStatus, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHostFacilityRanking":
					toReturn.Add(ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId, "ProspectsEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.OrganizationRoleUserEntityUsingRankedByOrganizationRoleUserId, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHostPayment":
					toReturn.Add(ProspectsEntity.Relations.HostPaymentEntityUsingHostId, "ProspectsEntity__", "HostPayment_", JoinHint.None);
					toReturn.Add(HostPaymentEntity.Relations.OrganizationRoleUserEntityUsingCreatorOrganizationRoleUserId, "HostPayment_", string.Empty, JoinHint.None);
					break;
				case "RoleCollectionViaHostFacilityRanking":
					toReturn.Add(ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId, "ProspectsEntity__", "HostFacilityRanking_", JoinHint.None);
					toReturn.Add(HostFacilityRankingEntity.Relations.RoleEntityUsingRankedByRole, "HostFacilityRanking_", string.Empty, JoinHint.None);
					break;
				case "SurveyTemplateCollectionViaAccount":
					toReturn.Add(ProspectsEntity.Relations.AccountEntityUsingConvertedHostId, "ProspectsEntity__", "Account_", JoinHint.None);
					toReturn.Add(AccountEntity.Relations.SurveyTemplateEntityUsingSurveyTemplateId, "Account_", string.Empty, JoinHint.None);
					break;
				case "HostNotes":
					toReturn.Add(ProspectsEntity.Relations.HostNotesEntityUsingHostId);
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
				case "OrganizationRoleUser":
					SetupSyncOrganizationRoleUser(relatedEntity);
					break;
				case "ProspectListDetails":
					SetupSyncProspectListDetails(relatedEntity);
					break;
				case "ProspectType":
					SetupSyncProspectType(relatedEntity);
					break;
				case "Account":
					this.Account.Add((AccountEntity)relatedEntity);
					break;
				case "HostEventDetails":
					this.HostEventDetails.Add((HostEventDetailsEntity)relatedEntity);
					break;
				case "HostFacilityRanking":
					this.HostFacilityRanking.Add((HostFacilityRankingEntity)relatedEntity);
					break;
				case "HostImage":
					this.HostImage.Add((HostImageEntity)relatedEntity);
					break;
				case "HostPayment":
					this.HostPayment.Add((HostPaymentEntity)relatedEntity);
					break;
				case "ProspectActivityDetails":
					this.ProspectActivityDetails.Add((ProspectActivityDetailsEntity)relatedEntity);
					break;
				case "ProspectCallDetails":
					this.ProspectCallDetails.Add((ProspectCallDetailsEntity)relatedEntity);
					break;
				case "ProspectContact":
					this.ProspectContact.Add((ProspectContactEntity)relatedEntity);
					break;
				case "HostNotes":
					SetupSyncHostNotes(relatedEntity);
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
				case "OrganizationRoleUser":
					DesetupSyncOrganizationRoleUser(false, true);
					break;
				case "ProspectListDetails":
					DesetupSyncProspectListDetails(false, true);
					break;
				case "ProspectType":
					DesetupSyncProspectType(false, true);
					break;
				case "Account":
					base.PerformRelatedEntityRemoval(this.Account, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostEventDetails":
					base.PerformRelatedEntityRemoval(this.HostEventDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostFacilityRanking":
					base.PerformRelatedEntityRemoval(this.HostFacilityRanking, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostImage":
					base.PerformRelatedEntityRemoval(this.HostImage, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostPayment":
					base.PerformRelatedEntityRemoval(this.HostPayment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectActivityDetails":
					base.PerformRelatedEntityRemoval(this.ProspectActivityDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectCallDetails":
					base.PerformRelatedEntityRemoval(this.ProspectCallDetails, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "ProspectContact":
					base.PerformRelatedEntityRemoval(this.ProspectContact, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HostNotes":
					DesetupSyncHostNotes(false, true);
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
			if(_hostNotes!=null)
			{
				toReturn.Add(_hostNotes);
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
			if(_organizationRoleUser!=null)
			{
				toReturn.Add(_organizationRoleUser);
			}
			if(_prospectListDetails!=null)
			{
				toReturn.Add(_prospectListDetails);
			}
			if(_prospectType!=null)
			{
				toReturn.Add(_prospectType);
			}


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.Account);
			toReturn.Add(this.HostEventDetails);
			toReturn.Add(this.HostFacilityRanking);
			toReturn.Add(this.HostImage);
			toReturn.Add(this.HostPayment);
			toReturn.Add(this.ProspectActivityDetails);
			toReturn.Add(this.ProspectCallDetails);
			toReturn.Add(this.ProspectContact);

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
				info.AddValue("_hostEventDetails", ((_hostEventDetails!=null) && (_hostEventDetails.Count>0) && !this.MarkedForDeletion)?_hostEventDetails:null);
				info.AddValue("_hostFacilityRanking", ((_hostFacilityRanking!=null) && (_hostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_hostFacilityRanking:null);
				info.AddValue("_hostImage", ((_hostImage!=null) && (_hostImage.Count>0) && !this.MarkedForDeletion)?_hostImage:null);
				info.AddValue("_hostPayment", ((_hostPayment!=null) && (_hostPayment.Count>0) && !this.MarkedForDeletion)?_hostPayment:null);
				info.AddValue("_prospectActivityDetails", ((_prospectActivityDetails!=null) && (_prospectActivityDetails.Count>0) && !this.MarkedForDeletion)?_prospectActivityDetails:null);
				info.AddValue("_prospectCallDetails", ((_prospectCallDetails!=null) && (_prospectCallDetails.Count>0) && !this.MarkedForDeletion)?_prospectCallDetails:null);
				info.AddValue("_prospectContact", ((_prospectContact!=null) && (_prospectContact.Count>0) && !this.MarkedForDeletion)?_prospectContact:null);
				info.AddValue("_addressCollectionViaHostPayment", ((_addressCollectionViaHostPayment!=null) && (_addressCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_addressCollectionViaHostPayment:null);
				info.AddValue("_checkListTemplateCollectionViaAccount_", ((_checkListTemplateCollectionViaAccount_!=null) && (_checkListTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount_:null);
				info.AddValue("_checkListTemplateCollectionViaAccount", ((_checkListTemplateCollectionViaAccount!=null) && (_checkListTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_checkListTemplateCollectionViaAccount:null);
				info.AddValue("_emailTemplateCollectionViaAccount__", ((_emailTemplateCollectionViaAccount__!=null) && (_emailTemplateCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount__:null);
				info.AddValue("_emailTemplateCollectionViaAccount", ((_emailTemplateCollectionViaAccount!=null) && (_emailTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount:null);
				info.AddValue("_emailTemplateCollectionViaAccount_", ((_emailTemplateCollectionViaAccount_!=null) && (_emailTemplateCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount_:null);
				info.AddValue("_emailTemplateCollectionViaAccount___", ((_emailTemplateCollectionViaAccount___!=null) && (_emailTemplateCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_emailTemplateCollectionViaAccount___:null);
				info.AddValue("_eventsCollectionViaHostPayment", ((_eventsCollectionViaHostPayment!=null) && (_eventsCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaHostPayment:null);
				info.AddValue("_eventsCollectionViaHostEventDetails", ((_eventsCollectionViaHostEventDetails!=null) && (_eventsCollectionViaHostEventDetails.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaHostEventDetails:null);
				info.AddValue("_fileCollectionViaAccount__", ((_fileCollectionViaAccount__!=null) && (_fileCollectionViaAccount__.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount__:null);
				info.AddValue("_fileCollectionViaAccount________", ((_fileCollectionViaAccount________!=null) && (_fileCollectionViaAccount________.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount________:null);
				info.AddValue("_fileCollectionViaAccount_", ((_fileCollectionViaAccount_!=null) && (_fileCollectionViaAccount_.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_:null);
				info.AddValue("_fileCollectionViaAccount", ((_fileCollectionViaAccount!=null) && (_fileCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount:null);
				info.AddValue("_fileCollectionViaHostImage", ((_fileCollectionViaHostImage!=null) && (_fileCollectionViaHostImage.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaHostImage:null);
				info.AddValue("_fileCollectionViaAccount____", ((_fileCollectionViaAccount____!=null) && (_fileCollectionViaAccount____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount____:null);
				info.AddValue("_fileCollectionViaAccount___", ((_fileCollectionViaAccount___!=null) && (_fileCollectionViaAccount___.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount___:null);
				info.AddValue("_fileCollectionViaAccount_____", ((_fileCollectionViaAccount_____!=null) && (_fileCollectionViaAccount_____.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_____:null);
				info.AddValue("_fileCollectionViaAccount_______", ((_fileCollectionViaAccount_______!=null) && (_fileCollectionViaAccount_______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount_______:null);
				info.AddValue("_fileCollectionViaAccount______", ((_fileCollectionViaAccount______!=null) && (_fileCollectionViaAccount______.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaAccount______:null);
				info.AddValue("_fluConsentTemplateCollectionViaAccount", ((_fluConsentTemplateCollectionViaAccount!=null) && (_fluConsentTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_fluConsentTemplateCollectionViaAccount:null);
				info.AddValue("_hafTemplateCollectionViaAccount", ((_hafTemplateCollectionViaAccount!=null) && (_hafTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_hafTemplateCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaAccount", ((_lookupCollectionViaAccount!=null) && (_lookupCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaAccount:null);
				info.AddValue("_lookupCollectionViaHostImage", ((_lookupCollectionViaHostImage!=null) && (_lookupCollectionViaHostImage.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostImage:null);
				info.AddValue("_lookupCollectionViaHostPayment", ((_lookupCollectionViaHostPayment!=null) && (_lookupCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPayment:null);
				info.AddValue("_lookupCollectionViaHostFacilityRanking", ((_lookupCollectionViaHostFacilityRanking!=null) && (_lookupCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostFacilityRanking:null);
				info.AddValue("_lookupCollectionViaHostFacilityRanking_", ((_lookupCollectionViaHostFacilityRanking_!=null) && (_lookupCollectionViaHostFacilityRanking_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostFacilityRanking_:null);
				info.AddValue("_lookupCollectionViaHostPayment_", ((_lookupCollectionViaHostPayment_!=null) && (_lookupCollectionViaHostPayment_.Count>0) && !this.MarkedForDeletion)?_lookupCollectionViaHostPayment_:null);
				info.AddValue("_organizationRoleUserCollectionViaHostFacilityRanking", ((_organizationRoleUserCollectionViaHostFacilityRanking!=null) && (_organizationRoleUserCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHostFacilityRanking:null);
				info.AddValue("_organizationRoleUserCollectionViaHostPayment", ((_organizationRoleUserCollectionViaHostPayment!=null) && (_organizationRoleUserCollectionViaHostPayment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHostPayment:null);
				info.AddValue("_roleCollectionViaHostFacilityRanking", ((_roleCollectionViaHostFacilityRanking!=null) && (_roleCollectionViaHostFacilityRanking.Count>0) && !this.MarkedForDeletion)?_roleCollectionViaHostFacilityRanking:null);
				info.AddValue("_surveyTemplateCollectionViaAccount", ((_surveyTemplateCollectionViaAccount!=null) && (_surveyTemplateCollectionViaAccount.Count>0) && !this.MarkedForDeletion)?_surveyTemplateCollectionViaAccount:null);
				info.AddValue("_address", (!this.MarkedForDeletion?_address:null));
				info.AddValue("_organizationRoleUser", (!this.MarkedForDeletion?_organizationRoleUser:null));
				info.AddValue("_prospectListDetails", (!this.MarkedForDeletion?_prospectListDetails:null));
				info.AddValue("_prospectType", (!this.MarkedForDeletion?_prospectType:null));
				info.AddValue("_hostNotes", (!this.MarkedForDeletion?_hostNotes:null));
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ProspectsFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ProspectsFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ProspectsRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Account' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AccountFields.ConvertedHostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostEventDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostEventDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostEventDetailsFields.HostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostFacilityRanking' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostFacilityRankingFields.HostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostImage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostImage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostImageFields.HostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HostPayment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostPaymentFields.HostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectActivityDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectActivityDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectActivityDetailsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectCallDetails' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectCallDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectCallDetailsFields.ProspectsId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ProspectContact' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectContact()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectContactFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Address' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddressCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("AddressCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CheckListTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCheckListTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CheckListTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'EmailTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEmailTemplateCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EmailTemplateCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaHostEventDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaHostEventDetails"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount________"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaHostImage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaHostImage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount___"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_____"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount_______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaAccount______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaAccount______"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FluConsentTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFluConsentTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FluConsentTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HafTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHafTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("HafTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostImage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostImage"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostFacilityRanking_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostFacilityRanking_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Lookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLookupCollectionViaHostPayment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LookupCollectionViaHostPayment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHostPayment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHostPayment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Role' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoRoleCollectionViaHostFacilityRanking()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("RoleCollectionViaHostFacilityRanking"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurveyTemplate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurveyTemplateCollectionViaAccount()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("SurveyTemplateCollectionViaAccount"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectsFields.ProspectId, null, ComparisonOperator.Equal, this.ProspectId, "ProspectsEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Address' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoAddress()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(AddressFields.AddressId, null, ComparisonOperator.Equal, this.AddressId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.OrgRoleUserId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ProspectListDetails' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectListDetails()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectListDetailsFields.ProspectFileId, null, ComparisonOperator.Equal, this.ProspectListId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ProspectType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoProspectType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ProspectTypeFields.ProspectTypeId, null, ComparisonOperator.Equal, this.ProspectTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HostNotes' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHostNotes()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HostNotesFields.HostId, null, ComparisonOperator.Equal, this.ProspectId));
			return bucket;
		}
	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.ProspectsEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ProspectsEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._account);
			collectionsQueue.Enqueue(this._hostEventDetails);
			collectionsQueue.Enqueue(this._hostFacilityRanking);
			collectionsQueue.Enqueue(this._hostImage);
			collectionsQueue.Enqueue(this._hostPayment);
			collectionsQueue.Enqueue(this._prospectActivityDetails);
			collectionsQueue.Enqueue(this._prospectCallDetails);
			collectionsQueue.Enqueue(this._prospectContact);
			collectionsQueue.Enqueue(this._addressCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._checkListTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount__);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount_);
			collectionsQueue.Enqueue(this._emailTemplateCollectionViaAccount___);
			collectionsQueue.Enqueue(this._eventsCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._eventsCollectionViaHostEventDetails);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount__);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount________);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount);
			collectionsQueue.Enqueue(this._fileCollectionViaHostImage);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount___);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_____);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount_______);
			collectionsQueue.Enqueue(this._fileCollectionViaAccount______);
			collectionsQueue.Enqueue(this._fluConsentTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._hafTemplateCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaAccount);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostImage);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostFacilityRanking_);
			collectionsQueue.Enqueue(this._lookupCollectionViaHostPayment_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHostPayment);
			collectionsQueue.Enqueue(this._roleCollectionViaHostFacilityRanking);
			collectionsQueue.Enqueue(this._surveyTemplateCollectionViaAccount);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._account = (EntityCollection<AccountEntity>) collectionsQueue.Dequeue();
			this._hostEventDetails = (EntityCollection<HostEventDetailsEntity>) collectionsQueue.Dequeue();
			this._hostFacilityRanking = (EntityCollection<HostFacilityRankingEntity>) collectionsQueue.Dequeue();
			this._hostImage = (EntityCollection<HostImageEntity>) collectionsQueue.Dequeue();
			this._hostPayment = (EntityCollection<HostPaymentEntity>) collectionsQueue.Dequeue();
			this._prospectActivityDetails = (EntityCollection<ProspectActivityDetailsEntity>) collectionsQueue.Dequeue();
			this._prospectCallDetails = (EntityCollection<ProspectCallDetailsEntity>) collectionsQueue.Dequeue();
			this._prospectContact = (EntityCollection<ProspectContactEntity>) collectionsQueue.Dequeue();
			this._addressCollectionViaHostPayment = (EntityCollection<AddressEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount_ = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._checkListTemplateCollectionViaAccount = (EntityCollection<CheckListTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount__ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount_ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._emailTemplateCollectionViaAccount___ = (EntityCollection<EmailTemplateEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaHostPayment = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaHostEventDetails = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount__ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount________ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaHostImage = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount___ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_____ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount_______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaAccount______ = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fluConsentTemplateCollectionViaAccount = (EntityCollection<FluConsentTemplateEntity>) collectionsQueue.Dequeue();
			this._hafTemplateCollectionViaAccount = (EntityCollection<HafTemplateEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaAccount = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostImage = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPayment = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostFacilityRanking = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostFacilityRanking_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._lookupCollectionViaHostPayment_ = (EntityCollection<LookupEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHostFacilityRanking = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHostPayment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._roleCollectionViaHostFacilityRanking = (EntityCollection<RoleEntity>) collectionsQueue.Dequeue();
			this._surveyTemplateCollectionViaAccount = (EntityCollection<SurveyTemplateEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._account != null)
			{
				return true;
			}
			if (this._hostEventDetails != null)
			{
				return true;
			}
			if (this._hostFacilityRanking != null)
			{
				return true;
			}
			if (this._hostImage != null)
			{
				return true;
			}
			if (this._hostPayment != null)
			{
				return true;
			}
			if (this._prospectActivityDetails != null)
			{
				return true;
			}
			if (this._prospectCallDetails != null)
			{
				return true;
			}
			if (this._prospectContact != null)
			{
				return true;
			}
			if (this._addressCollectionViaHostPayment != null)
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
			if (this._emailTemplateCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._emailTemplateCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._eventsCollectionViaHostPayment != null)
			{
				return true;
			}
			if (this._eventsCollectionViaHostEventDetails != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount__ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount________ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount != null)
			{
				return true;
			}
			if (this._fileCollectionViaHostImage != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount___ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_____ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount_______ != null)
			{
				return true;
			}
			if (this._fileCollectionViaAccount______ != null)
			{
				return true;
			}
			if (this._fluConsentTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._hafTemplateCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaAccount != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostImage != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPayment != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostFacilityRanking_ != null)
			{
				return true;
			}
			if (this._lookupCollectionViaHostPayment_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHostPayment != null)
			{
				return true;
			}
			if (this._roleCollectionViaHostFacilityRanking != null)
			{
				return true;
			}
			if (this._surveyTemplateCollectionViaAccount != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostEventDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostEventDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostFacilityRankingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostFacilityRankingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostImageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostImageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HostPaymentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostPaymentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectActivityDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectCallDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCallDetailsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ProspectContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))) : null);
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
			toReturn.Add("OrganizationRoleUser", _organizationRoleUser);
			toReturn.Add("ProspectListDetails", _prospectListDetails);
			toReturn.Add("ProspectType", _prospectType);
			toReturn.Add("Account", _account);
			toReturn.Add("HostEventDetails", _hostEventDetails);
			toReturn.Add("HostFacilityRanking", _hostFacilityRanking);
			toReturn.Add("HostImage", _hostImage);
			toReturn.Add("HostPayment", _hostPayment);
			toReturn.Add("ProspectActivityDetails", _prospectActivityDetails);
			toReturn.Add("ProspectCallDetails", _prospectCallDetails);
			toReturn.Add("ProspectContact", _prospectContact);
			toReturn.Add("AddressCollectionViaHostPayment", _addressCollectionViaHostPayment);
			toReturn.Add("CheckListTemplateCollectionViaAccount_", _checkListTemplateCollectionViaAccount_);
			toReturn.Add("CheckListTemplateCollectionViaAccount", _checkListTemplateCollectionViaAccount);
			toReturn.Add("EmailTemplateCollectionViaAccount__", _emailTemplateCollectionViaAccount__);
			toReturn.Add("EmailTemplateCollectionViaAccount", _emailTemplateCollectionViaAccount);
			toReturn.Add("EmailTemplateCollectionViaAccount_", _emailTemplateCollectionViaAccount_);
			toReturn.Add("EmailTemplateCollectionViaAccount___", _emailTemplateCollectionViaAccount___);
			toReturn.Add("EventsCollectionViaHostPayment", _eventsCollectionViaHostPayment);
			toReturn.Add("EventsCollectionViaHostEventDetails", _eventsCollectionViaHostEventDetails);
			toReturn.Add("FileCollectionViaAccount__", _fileCollectionViaAccount__);
			toReturn.Add("FileCollectionViaAccount________", _fileCollectionViaAccount________);
			toReturn.Add("FileCollectionViaAccount_", _fileCollectionViaAccount_);
			toReturn.Add("FileCollectionViaAccount", _fileCollectionViaAccount);
			toReturn.Add("FileCollectionViaHostImage", _fileCollectionViaHostImage);
			toReturn.Add("FileCollectionViaAccount____", _fileCollectionViaAccount____);
			toReturn.Add("FileCollectionViaAccount___", _fileCollectionViaAccount___);
			toReturn.Add("FileCollectionViaAccount_____", _fileCollectionViaAccount_____);
			toReturn.Add("FileCollectionViaAccount_______", _fileCollectionViaAccount_______);
			toReturn.Add("FileCollectionViaAccount______", _fileCollectionViaAccount______);
			toReturn.Add("FluConsentTemplateCollectionViaAccount", _fluConsentTemplateCollectionViaAccount);
			toReturn.Add("HafTemplateCollectionViaAccount", _hafTemplateCollectionViaAccount);
			toReturn.Add("LookupCollectionViaAccount", _lookupCollectionViaAccount);
			toReturn.Add("LookupCollectionViaHostImage", _lookupCollectionViaHostImage);
			toReturn.Add("LookupCollectionViaHostPayment", _lookupCollectionViaHostPayment);
			toReturn.Add("LookupCollectionViaHostFacilityRanking", _lookupCollectionViaHostFacilityRanking);
			toReturn.Add("LookupCollectionViaHostFacilityRanking_", _lookupCollectionViaHostFacilityRanking_);
			toReturn.Add("LookupCollectionViaHostPayment_", _lookupCollectionViaHostPayment_);
			toReturn.Add("OrganizationRoleUserCollectionViaHostFacilityRanking", _organizationRoleUserCollectionViaHostFacilityRanking);
			toReturn.Add("OrganizationRoleUserCollectionViaHostPayment", _organizationRoleUserCollectionViaHostPayment);
			toReturn.Add("RoleCollectionViaHostFacilityRanking", _roleCollectionViaHostFacilityRanking);
			toReturn.Add("SurveyTemplateCollectionViaAccount", _surveyTemplateCollectionViaAccount);
			toReturn.Add("HostNotes", _hostNotes);
			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_hostEventDetails!=null)
			{
				_hostEventDetails.ActiveContext = base.ActiveContext;
			}
			if(_hostFacilityRanking!=null)
			{
				_hostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_hostImage!=null)
			{
				_hostImage.ActiveContext = base.ActiveContext;
			}
			if(_hostPayment!=null)
			{
				_hostPayment.ActiveContext = base.ActiveContext;
			}
			if(_prospectActivityDetails!=null)
			{
				_prospectActivityDetails.ActiveContext = base.ActiveContext;
			}
			if(_prospectCallDetails!=null)
			{
				_prospectCallDetails.ActiveContext = base.ActiveContext;
			}
			if(_prospectContact!=null)
			{
				_prospectContact.ActiveContext = base.ActiveContext;
			}
			if(_addressCollectionViaHostPayment!=null)
			{
				_addressCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount_!=null)
			{
				_checkListTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_checkListTemplateCollectionViaAccount!=null)
			{
				_checkListTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount__!=null)
			{
				_emailTemplateCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount!=null)
			{
				_emailTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount_!=null)
			{
				_emailTemplateCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_emailTemplateCollectionViaAccount___!=null)
			{
				_emailTemplateCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaHostPayment!=null)
			{
				_eventsCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaHostEventDetails!=null)
			{
				_eventsCollectionViaHostEventDetails.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount__!=null)
			{
				_fileCollectionViaAccount__.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount________!=null)
			{
				_fileCollectionViaAccount________.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_!=null)
			{
				_fileCollectionViaAccount_.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount!=null)
			{
				_fileCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaHostImage!=null)
			{
				_fileCollectionViaHostImage.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount____!=null)
			{
				_fileCollectionViaAccount____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount___!=null)
			{
				_fileCollectionViaAccount___.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_____!=null)
			{
				_fileCollectionViaAccount_____.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount_______!=null)
			{
				_fileCollectionViaAccount_______.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaAccount______!=null)
			{
				_fileCollectionViaAccount______.ActiveContext = base.ActiveContext;
			}
			if(_fluConsentTemplateCollectionViaAccount!=null)
			{
				_fluConsentTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_hafTemplateCollectionViaAccount!=null)
			{
				_hafTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaAccount!=null)
			{
				_lookupCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostImage!=null)
			{
				_lookupCollectionViaHostImage.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPayment!=null)
			{
				_lookupCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostFacilityRanking!=null)
			{
				_lookupCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostFacilityRanking_!=null)
			{
				_lookupCollectionViaHostFacilityRanking_.ActiveContext = base.ActiveContext;
			}
			if(_lookupCollectionViaHostPayment_!=null)
			{
				_lookupCollectionViaHostPayment_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHostFacilityRanking!=null)
			{
				_organizationRoleUserCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHostPayment!=null)
			{
				_organizationRoleUserCollectionViaHostPayment.ActiveContext = base.ActiveContext;
			}
			if(_roleCollectionViaHostFacilityRanking!=null)
			{
				_roleCollectionViaHostFacilityRanking.ActiveContext = base.ActiveContext;
			}
			if(_surveyTemplateCollectionViaAccount!=null)
			{
				_surveyTemplateCollectionViaAccount.ActiveContext = base.ActiveContext;
			}
			if(_address!=null)
			{
				_address.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser!=null)
			{
				_organizationRoleUser.ActiveContext = base.ActiveContext;
			}
			if(_prospectListDetails!=null)
			{
				_prospectListDetails.ActiveContext = base.ActiveContext;
			}
			if(_prospectType!=null)
			{
				_prospectType.ActiveContext = base.ActiveContext;
			}
			if(_hostNotes!=null)
			{
				_hostNotes.ActiveContext = base.ActiveContext;
			}
		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_account = null;
			_hostEventDetails = null;
			_hostFacilityRanking = null;
			_hostImage = null;
			_hostPayment = null;
			_prospectActivityDetails = null;
			_prospectCallDetails = null;
			_prospectContact = null;
			_addressCollectionViaHostPayment = null;
			_checkListTemplateCollectionViaAccount_ = null;
			_checkListTemplateCollectionViaAccount = null;
			_emailTemplateCollectionViaAccount__ = null;
			_emailTemplateCollectionViaAccount = null;
			_emailTemplateCollectionViaAccount_ = null;
			_emailTemplateCollectionViaAccount___ = null;
			_eventsCollectionViaHostPayment = null;
			_eventsCollectionViaHostEventDetails = null;
			_fileCollectionViaAccount__ = null;
			_fileCollectionViaAccount________ = null;
			_fileCollectionViaAccount_ = null;
			_fileCollectionViaAccount = null;
			_fileCollectionViaHostImage = null;
			_fileCollectionViaAccount____ = null;
			_fileCollectionViaAccount___ = null;
			_fileCollectionViaAccount_____ = null;
			_fileCollectionViaAccount_______ = null;
			_fileCollectionViaAccount______ = null;
			_fluConsentTemplateCollectionViaAccount = null;
			_hafTemplateCollectionViaAccount = null;
			_lookupCollectionViaAccount = null;
			_lookupCollectionViaHostImage = null;
			_lookupCollectionViaHostPayment = null;
			_lookupCollectionViaHostFacilityRanking = null;
			_lookupCollectionViaHostFacilityRanking_ = null;
			_lookupCollectionViaHostPayment_ = null;
			_organizationRoleUserCollectionViaHostFacilityRanking = null;
			_organizationRoleUserCollectionViaHostPayment = null;
			_roleCollectionViaHostFacilityRanking = null;
			_surveyTemplateCollectionViaAccount = null;
			_address = null;
			_organizationRoleUser = null;
			_prospectListDetails = null;
			_prospectType = null;
			_hostNotes = null;
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

			_fieldsCustomProperties.Add("ProspectId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectListId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectStage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PropectsState", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsHost", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Status", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ProspectTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOffice", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneCell", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PhoneOther", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WebSite", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrganizationName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Notes", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("AddressIdmailling", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActualMembersHip", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ActualAttendance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WillPromote", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Mapurl", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherEmail", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MethodObtainedId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("County", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateHostConverted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Fudate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsActive", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ReasonWillPromote", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TaxIdNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CompanyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Department", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Ext", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Small", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Industry", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("WebsiteJobOpenings", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("YearlyRevRange", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmployeeRange", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GroupDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Fax", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _address</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAddress(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", ProspectsEntity.Relations.AddressEntityUsingAddressId, true, signalRelatedEntity, "Prospects", resetFKFields, new int[] { (int)ProspectsFieldIndex.AddressId } );		
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
				base.PerformSetupSyncRelatedEntity( _address, new PropertyChangedEventHandler( OnAddressPropertyChanged ), "Address", ProspectsEntity.Relations.AddressEntityUsingAddressId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, true, signalRelatedEntity, "Prospects", resetFKFields, new int[] { (int)ProspectsFieldIndex.OrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser, new PropertyChangedEventHandler( OnOrganizationRoleUserPropertyChanged ), "OrganizationRoleUser", ProspectsEntity.Relations.OrganizationRoleUserEntityUsingOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _prospectListDetails</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspectListDetails(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospectListDetails, new PropertyChangedEventHandler( OnProspectListDetailsPropertyChanged ), "ProspectListDetails", ProspectsEntity.Relations.ProspectListDetailsEntityUsingProspectListId, true, signalRelatedEntity, "Prospects", resetFKFields, new int[] { (int)ProspectsFieldIndex.ProspectListId } );		
			_prospectListDetails = null;
		}

		/// <summary> setups the sync logic for member _prospectListDetails</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspectListDetails(IEntity2 relatedEntity)
		{
			if(_prospectListDetails!=relatedEntity)
			{
				DesetupSyncProspectListDetails(true, true);
				_prospectListDetails = (ProspectListDetailsEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospectListDetails, new PropertyChangedEventHandler( OnProspectListDetailsPropertyChanged ), "ProspectListDetails", ProspectsEntity.Relations.ProspectListDetailsEntityUsingProspectListId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectListDetailsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _prospectType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncProspectType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _prospectType, new PropertyChangedEventHandler( OnProspectTypePropertyChanged ), "ProspectType", ProspectsEntity.Relations.ProspectTypeEntityUsingProspectTypeId, true, signalRelatedEntity, "Prospects", resetFKFields, new int[] { (int)ProspectsFieldIndex.ProspectTypeId } );		
			_prospectType = null;
		}

		/// <summary> setups the sync logic for member _prospectType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncProspectType(IEntity2 relatedEntity)
		{
			if(_prospectType!=relatedEntity)
			{
				DesetupSyncProspectType(true, true);
				_prospectType = (ProspectTypeEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _prospectType, new PropertyChangedEventHandler( OnProspectTypePropertyChanged ), "ProspectType", ProspectsEntity.Relations.ProspectTypeEntityUsingProspectTypeId, true, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnProspectTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _hostNotes</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHostNotes(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _hostNotes, new PropertyChangedEventHandler( OnHostNotesPropertyChanged ), "HostNotes", ProspectsEntity.Relations.HostNotesEntityUsingHostId, false, signalRelatedEntity, "Prospects", false, new int[] { (int)ProspectsFieldIndex.ProspectId } );
			_hostNotes = null;
		}
		
		/// <summary> setups the sync logic for member _hostNotes</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHostNotes(IEntity2 relatedEntity)
		{
			if(_hostNotes!=relatedEntity)
			{
				DesetupSyncHostNotes(true, true);
				_hostNotes = (HostNotesEntity)relatedEntity;
				base.PerformSetupSyncRelatedEntity( _hostNotes, new PropertyChangedEventHandler( OnHostNotesPropertyChanged ), "HostNotes", ProspectsEntity.Relations.HostNotesEntityUsingHostId, false, new string[] {  } );
			}
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHostNotesPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ProspectsEntity</param>
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
		public  static ProspectsRelations Relations
		{
			get	{ return new ProspectsRelations(); }
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostEventDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostEventDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostEventDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostEventDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostEventDetails")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HostEventDetailsEntity, 0, null, null, null, null, "HostEventDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HostFacilityRanking")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HostFacilityRankingEntity, 0, null, null, null, null, "HostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostImage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostImage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HostImageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostImageEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostImage")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HostImageEntity, 0, null, null, null, null, "HostImage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HostPayment")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HostPaymentEntity, 0, null, null, null, null, "HostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectActivityDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectActivityDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectActivityDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectActivityDetails")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.ProspectActivityDetailsEntity, 0, null, null, null, null, "ProspectActivityDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectCallDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectCallDetails
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectCallDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCallDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectCallDetails")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.ProspectCallDetailsEntity, 0, null, null, null, null, "ProspectCallDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectContact' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectContact
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ProspectContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectContact")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.ProspectContactEntity, 0, null, null, null, null, "ProspectContact", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Address' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathAddressCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostPaymentEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, GetRelationsForField("AddressCollectionViaHostPayment"), null, "AddressCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount_"), null, "CheckListTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CheckListTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCheckListTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<CheckListTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CheckListTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.CheckListTemplateEntity, 0, null, null, GetRelationsForField("CheckListTemplateCollectionViaAccount"), null, "CheckListTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount__"), null, "EmailTemplateCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount"), null, "EmailTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount_"), null, "EmailTemplateCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'EmailTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEmailTemplateCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<EmailTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EmailTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EmailTemplateEntity, 0, null, null, GetRelationsForField("EmailTemplateCollectionViaAccount___"), null, "EmailTemplateCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostPaymentEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaHostPayment"), null, "EventsCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaHostEventDetails
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostEventDetailsEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostEventDetails_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaHostEventDetails"), null, "EventsCollectionViaHostEventDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount__
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount__"), null, "FileCollectionViaAccount__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount________
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount________"), null, "FileCollectionViaAccount________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_"), null, "FileCollectionViaAccount_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount"), null, "FileCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaHostImage
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostImageEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostImage_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaHostImage"), null, "FileCollectionViaHostImage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount____
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount____"), null, "FileCollectionViaAccount____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount___
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount___"), null, "FileCollectionViaAccount___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_____
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_____"), null, "FileCollectionViaAccount_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount_______
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount_______"), null, "FileCollectionViaAccount_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaAccount______
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaAccount______"), null, "FileCollectionViaAccount______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FluConsentTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFluConsentTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<FluConsentTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FluConsentTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.FluConsentTemplateEntity, 0, null, null, GetRelationsForField("FluConsentTemplateCollectionViaAccount"), null, "FluConsentTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HafTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHafTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HafTemplateEntity, 0, null, null, GetRelationsForField("HafTemplateCollectionViaAccount"), null, "HafTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaAccount"), null, "LookupCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostImage
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostImageEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostImage_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostImage"), null, "LookupCollectionViaHostImage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostPaymentEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPayment"), null, "LookupCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostFacilityRanking"), null, "LookupCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostFacilityRanking_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostFacilityRanking_"), null, "LookupCollectionViaHostFacilityRanking_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Lookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLookupCollectionViaHostPayment_
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostPaymentEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.LookupEntity, 0, null, null, GetRelationsForField("LookupCollectionViaHostPayment_"), null, "LookupCollectionViaHostPayment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHostFacilityRanking"), null, "OrganizationRoleUserCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHostPayment
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostPaymentEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostPayment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHostPayment"), null, "OrganizationRoleUserCollectionViaHostPayment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Role' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathRoleCollectionViaHostFacilityRanking
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.HostFacilityRankingEntityUsingHostId;
				intermediateRelation.SetAliases(string.Empty, "HostFacilityRanking_");
				return new PrefetchPathElement2(new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.RoleEntity, 0, null, null, GetRelationsForField("RoleCollectionViaHostFacilityRanking"), null, "RoleCollectionViaHostFacilityRanking", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurveyTemplate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurveyTemplateCollectionViaAccount
		{
			get
			{
				IEntityRelation intermediateRelation = ProspectsEntity.Relations.AccountEntityUsingConvertedHostId;
				intermediateRelation.SetAliases(string.Empty, "Account_");
				return new PrefetchPathElement2(new EntityCollection<SurveyTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurveyTemplateEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.SurveyTemplateEntity, 0, null, null, GetRelationsForField("SurveyTemplateCollectionViaAccount"), null, "SurveyTemplateCollectionViaAccount", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Address")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.AddressEntity, 0, null, null, null, null, "Address", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectListDetails' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectListDetails
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectListDetailsEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectListDetails")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.ProspectListDetailsEntity, 0, null, null, null, null, "ProspectListDetails", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ProspectType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathProspectType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ProspectTypeEntityFactory))),
					(IEntityRelation)GetRelationsForField("ProspectType")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.ProspectTypeEntity, 0, null, null, null, null, "ProspectType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HostNotes' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHostNotes
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HostNotesEntityFactory))),
					(IEntityRelation)GetRelationsForField("HostNotes")[0], (int)Falcon.Data.EntityType.ProspectsEntity, (int)Falcon.Data.EntityType.HostNotesEntity, 0, null, null, null, null, "HostNotes", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToOne);
			}
		}

		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ProspectsEntity.CustomProperties;}
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
			get { return ProspectsEntity.FieldsCustomProperties;}
		}

		/// <summary> The ProspectId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ProspectID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ProspectId
		{
			get { return (System.Int64)GetValue((int)ProspectsFieldIndex.ProspectId, true); }
			set	{ SetValue((int)ProspectsFieldIndex.ProspectId, value); }
		}

		/// <summary> The ProspectListId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ProspectListID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectListId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.ProspectListId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.ProspectListId, value); }
		}

		/// <summary> The ProspectStage property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ProspectStage"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectStage
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.ProspectStage, false); }
			set	{ SetValue((int)ProspectsFieldIndex.ProspectStage, value); }
		}

		/// <summary> The DateCreated property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)ProspectsFieldIndex.DateCreated, true); }
			set	{ SetValue((int)ProspectsFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateModified
		{
			get { return (System.DateTime)GetValue((int)ProspectsFieldIndex.DateModified, true); }
			set	{ SetValue((int)ProspectsFieldIndex.DateModified, value); }
		}

		/// <summary> The PropectsState property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."PropectsState"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PropectsState
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.PropectsState, true); }
			set	{ SetValue((int)ProspectsFieldIndex.PropectsState, value); }
		}

		/// <summary> The IsHost property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."IsHost"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Boolean> IsHost
		{
			get { return (Nullable<System.Boolean>)GetValue((int)ProspectsFieldIndex.IsHost, false); }
			set	{ SetValue((int)ProspectsFieldIndex.IsHost, value); }
		}

		/// <summary> The Status property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Status"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Status
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Status, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Status, value); }
		}

		/// <summary> The ProspectTypeId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ProspectTypeID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ProspectTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.ProspectTypeId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.ProspectTypeId, value); }
		}

		/// <summary> The EmailId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."EMailID"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailId
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.EmailId, true); }
			set	{ SetValue((int)ProspectsFieldIndex.EmailId, value); }
		}

		/// <summary> The PhoneOffice property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."PhoneOffice"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOffice
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.PhoneOffice, true); }
			set	{ SetValue((int)ProspectsFieldIndex.PhoneOffice, value); }
		}

		/// <summary> The PhoneCell property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."PhoneCell"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneCell
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.PhoneCell, true); }
			set	{ SetValue((int)ProspectsFieldIndex.PhoneCell, value); }
		}

		/// <summary> The PhoneOther property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."PhoneOther"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String PhoneOther
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.PhoneOther, true); }
			set	{ SetValue((int)ProspectsFieldIndex.PhoneOther, value); }
		}

		/// <summary> The WebSite property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."WebSite"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String WebSite
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.WebSite, true); }
			set	{ SetValue((int)ProspectsFieldIndex.WebSite, value); }
		}

		/// <summary> The OrganizationName property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."OrganizationName"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OrganizationName
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.OrganizationName, true); }
			set	{ SetValue((int)ProspectsFieldIndex.OrganizationName, value); }
		}

		/// <summary> The Notes property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Notes"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 5000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Notes
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Notes, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Notes, value); }
		}

		/// <summary> The AddressId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."AddressID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AddressId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.AddressId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.AddressId, value); }
		}

		/// <summary> The AddressIdmailling property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."AddressIDMailling"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> AddressIdmailling
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.AddressIdmailling, false); }
			set	{ SetValue((int)ProspectsFieldIndex.AddressIdmailling, value); }
		}

		/// <summary> The ActualMembersHip property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ActualMembersHIP"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> ActualMembersHip
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ProspectsFieldIndex.ActualMembersHip, false); }
			set	{ SetValue((int)ProspectsFieldIndex.ActualMembersHip, value); }
		}

		/// <summary> The ActualAttendance property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ActualAttendance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> ActualAttendance
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ProspectsFieldIndex.ActualAttendance, false); }
			set	{ SetValue((int)ProspectsFieldIndex.ActualAttendance, value); }
		}

		/// <summary> The WillPromote property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."WillPromote"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> WillPromote
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProspectsFieldIndex.WillPromote, false); }
			set	{ SetValue((int)ProspectsFieldIndex.WillPromote, value); }
		}

		/// <summary> The Mapurl property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."MAPUrl"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 3000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Mapurl
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Mapurl, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Mapurl, value); }
		}

		/// <summary> The OtherEmail property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."OtherEmail"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OtherEmail
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.OtherEmail, true); }
			set	{ SetValue((int)ProspectsFieldIndex.OtherEmail, value); }
		}

		/// <summary> The MethodObtainedId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."MethodObtainedID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MethodObtainedId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.MethodObtainedId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.MethodObtainedId, value); }
		}

		/// <summary> The County property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."County"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 500<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String County
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.County, true); }
			set	{ SetValue((int)ProspectsFieldIndex.County, value); }
		}

		/// <summary> The DateHostConverted property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."DateHostConverted"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateHostConverted
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectsFieldIndex.DateHostConverted, false); }
			set	{ SetValue((int)ProspectsFieldIndex.DateHostConverted, value); }
		}

		/// <summary> The Fudate property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."FUDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Fudate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ProspectsFieldIndex.Fudate, false); }
			set	{ SetValue((int)ProspectsFieldIndex.Fudate, value); }
		}

		/// <summary> The IsActive property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."IsActive"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsActive
		{
			get { return (System.Boolean)GetValue((int)ProspectsFieldIndex.IsActive, true); }
			set	{ SetValue((int)ProspectsFieldIndex.IsActive, value); }
		}

		/// <summary> The ReasonWillPromote property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."ReasonWillPromote"<br/>
		/// Table field type characteristics (type, precision, scale, length): Text, 0, 0, 2147483647<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ReasonWillPromote
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.ReasonWillPromote, true); }
			set	{ SetValue((int)ProspectsFieldIndex.ReasonWillPromote, value); }
		}

		/// <summary> The TaxIdNumber property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."TaxIdNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String TaxIdNumber
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.TaxIdNumber, true); }
			set	{ SetValue((int)ProspectsFieldIndex.TaxIdNumber, value); }
		}

		/// <summary> The CompanyId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."CompanyID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CompanyId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.CompanyId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.CompanyId, value); }
		}

		/// <summary> The Department property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Department"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Department
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Department, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Department, value); }
		}

		/// <summary> The Ext property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Ext"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Ext
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Ext, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Ext, value); }
		}

		/// <summary> The Small property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Small"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Small
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Small, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Small, value); }
		}

		/// <summary> The Industry property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Industry"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Industry
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Industry, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Industry, value); }
		}

		/// <summary> The WebsiteJobOpenings property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."WebsiteJobOpenings"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> WebsiteJobOpenings
		{
			get { return (Nullable<System.Int32>)GetValue((int)ProspectsFieldIndex.WebsiteJobOpenings, false); }
			set	{ SetValue((int)ProspectsFieldIndex.WebsiteJobOpenings, value); }
		}

		/// <summary> The YearlyRevRange property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."YearlyRevRange"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String YearlyRevRange
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.YearlyRevRange, true); }
			set	{ SetValue((int)ProspectsFieldIndex.YearlyRevRange, value); }
		}

		/// <summary> The EmployeeRange property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."EmployeeRange"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmployeeRange
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.EmployeeRange, true); }
			set	{ SetValue((int)ProspectsFieldIndex.EmployeeRange, value); }
		}

		/// <summary> The GroupDescription property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."GroupDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GroupDescription
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.GroupDescription, true); }
			set	{ SetValue((int)ProspectsFieldIndex.GroupDescription, value); }
		}

		/// <summary> The OrgRoleUserId property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."OrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> OrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ProspectsFieldIndex.OrgRoleUserId, false); }
			set	{ SetValue((int)ProspectsFieldIndex.OrgRoleUserId, value); }
		}

		/// <summary> The Fax property of the Entity Prospects<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblProspects"."Fax"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 20<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Fax
		{
			get { return (System.String)GetValue((int)ProspectsFieldIndex.Fax, true); }
			set	{ SetValue((int)ProspectsFieldIndex.Fax, value); }
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
					_account.SetContainingEntityInfo(this, "Prospects");
				}
				return _account;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostEventDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostEventDetailsEntity))]
		public virtual EntityCollection<HostEventDetailsEntity> HostEventDetails
		{
			get
			{
				if(_hostEventDetails==null)
				{
					_hostEventDetails = new EntityCollection<HostEventDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostEventDetailsEntityFactory)));
					_hostEventDetails.SetContainingEntityInfo(this, "Prospects");
				}
				return _hostEventDetails;
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
					_hostFacilityRanking.SetContainingEntityInfo(this, "Prospects");
				}
				return _hostFacilityRanking;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HostImageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HostImageEntity))]
		public virtual EntityCollection<HostImageEntity> HostImage
		{
			get
			{
				if(_hostImage==null)
				{
					_hostImage = new EntityCollection<HostImageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HostImageEntityFactory)));
					_hostImage.SetContainingEntityInfo(this, "Prospects");
				}
				return _hostImage;
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
					_hostPayment.SetContainingEntityInfo(this, "Prospects");
				}
				return _hostPayment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectActivityDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectActivityDetailsEntity))]
		public virtual EntityCollection<ProspectActivityDetailsEntity> ProspectActivityDetails
		{
			get
			{
				if(_prospectActivityDetails==null)
				{
					_prospectActivityDetails = new EntityCollection<ProspectActivityDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectActivityDetailsEntityFactory)));
					_prospectActivityDetails.SetContainingEntityInfo(this, "Prospects");
				}
				return _prospectActivityDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectCallDetailsEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectCallDetailsEntity))]
		public virtual EntityCollection<ProspectCallDetailsEntity> ProspectCallDetails
		{
			get
			{
				if(_prospectCallDetails==null)
				{
					_prospectCallDetails = new EntityCollection<ProspectCallDetailsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectCallDetailsEntityFactory)));
					_prospectCallDetails.SetContainingEntityInfo(this, "Prospects");
				}
				return _prospectCallDetails;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ProspectContactEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ProspectContactEntity))]
		public virtual EntityCollection<ProspectContactEntity> ProspectContact
		{
			get
			{
				if(_prospectContact==null)
				{
					_prospectContact = new EntityCollection<ProspectContactEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ProspectContactEntityFactory)));
					_prospectContact.SetContainingEntityInfo(this, "Prospects");
				}
				return _prospectContact;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'AddressEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(AddressEntity))]
		public virtual EntityCollection<AddressEntity> AddressCollectionViaHostPayment
		{
			get
			{
				if(_addressCollectionViaHostPayment==null)
				{
					_addressCollectionViaHostPayment = new EntityCollection<AddressEntity>(EntityFactoryCache2.GetEntityFactory(typeof(AddressEntityFactory)));
					_addressCollectionViaHostPayment.IsReadOnly=true;
				}
				return _addressCollectionViaHostPayment;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaHostEventDetails
		{
			get
			{
				if(_eventsCollectionViaHostEventDetails==null)
				{
					_eventsCollectionViaHostEventDetails = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaHostEventDetails.IsReadOnly=true;
				}
				return _eventsCollectionViaHostEventDetails;
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
		public virtual EntityCollection<FileEntity> FileCollectionViaHostImage
		{
			get
			{
				if(_fileCollectionViaHostImage==null)
				{
					_fileCollectionViaHostImage = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaHostImage.IsReadOnly=true;
				}
				return _fileCollectionViaHostImage;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'HafTemplateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HafTemplateEntity))]
		public virtual EntityCollection<HafTemplateEntity> HafTemplateCollectionViaAccount
		{
			get
			{
				if(_hafTemplateCollectionViaAccount==null)
				{
					_hafTemplateCollectionViaAccount = new EntityCollection<HafTemplateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HafTemplateEntityFactory)));
					_hafTemplateCollectionViaAccount.IsReadOnly=true;
				}
				return _hafTemplateCollectionViaAccount;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostImage
		{
			get
			{
				if(_lookupCollectionViaHostImage==null)
				{
					_lookupCollectionViaHostImage = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostImage.IsReadOnly=true;
				}
				return _lookupCollectionViaHostImage;
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
		public virtual EntityCollection<LookupEntity> LookupCollectionViaHostPayment_
		{
			get
			{
				if(_lookupCollectionViaHostPayment_==null)
				{
					_lookupCollectionViaHostPayment_ = new EntityCollection<LookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LookupEntityFactory)));
					_lookupCollectionViaHostPayment_.IsReadOnly=true;
				}
				return _lookupCollectionViaHostPayment_;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'RoleEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(RoleEntity))]
		public virtual EntityCollection<RoleEntity> RoleCollectionViaHostFacilityRanking
		{
			get
			{
				if(_roleCollectionViaHostFacilityRanking==null)
				{
					_roleCollectionViaHostFacilityRanking = new EntityCollection<RoleEntity>(EntityFactoryCache2.GetEntityFactory(typeof(RoleEntityFactory)));
					_roleCollectionViaHostFacilityRanking.IsReadOnly=true;
				}
				return _roleCollectionViaHostFacilityRanking;
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
							_address.UnsetRelatedEntity(this, "Prospects");
						}
					}
					else
					{
						if(_address!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Prospects");
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
							_organizationRoleUser.UnsetRelatedEntity(this, "Prospects");
						}
					}
					else
					{
						if(_organizationRoleUser!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Prospects");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectListDetailsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectListDetailsEntity ProspectListDetails
		{
			get
			{
				return _prospectListDetails;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspectListDetails(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospectListDetails != null)
						{
							_prospectListDetails.UnsetRelatedEntity(this, "Prospects");
						}
					}
					else
					{
						if(_prospectListDetails!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Prospects");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ProspectTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ProspectTypeEntity ProspectType
		{
			get
			{
				return _prospectType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncProspectType(value);
				}
				else
				{
					if(value==null)
					{
						if(_prospectType != null)
						{
							_prospectType.UnsetRelatedEntity(this, "Prospects");
						}
					}
					else
					{
						if(_prospectType!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "Prospects");
						}
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HostNotesEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HostNotesEntity HostNotes
		{
			get
			{
				return _hostNotes;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHostNotes(value);
					if((SerializationHelper.Optimization == SerializationOptimization.Fast) && (value!=null))
					{
						value.SetRelatedEntity(this, "Prospects");
					}
				}
				else
				{
					if(value==null)
					{
						bool raisePropertyChanged = (_hostNotes !=null);
						DesetupSyncHostNotes(true, true);
						if(raisePropertyChanged)
						{
							OnPropertyChanged("HostNotes");
						}
					}
					else
					{
						if(_hostNotes!=value)
						{
							IEntity2 relatedEntity = (IEntity2)value;
							relatedEntity.SetRelatedEntity(this, "Prospects");
							SetupSyncHostNotes(relatedEntity);
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
			get { return (int)Falcon.Data.EntityType.ProspectsEntity; }
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
