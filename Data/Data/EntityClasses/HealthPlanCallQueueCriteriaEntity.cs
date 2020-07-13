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
	/// Entity class which represents the entity 'HealthPlanCallQueueCriteria'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class HealthPlanCallQueueCriteriaEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity> _callRoundCallQueueCriteriaAssignment;
		private EntityCollection<FillEventCallQueueCriteriaAssignmentEntity> _fillEventCallQueueCriteriaAssignment;
		private EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity> _healthPlanCallQueueCriteriaAssignment;
		private EntityCollection<HealthPlanCriteriaAssignmentEntity> _healthPlanCriteriaAssignment;
		private EntityCollection<HealthPlanCriteriaAssignmentUploadEntity> _healthPlanCriteriaAssignmentUpload;
		private EntityCollection<HealthPlanCriteriaDirectMailEntity> _healthPlanCriteriaDirectMail;
		private EntityCollection<HealthPlanCriteriaTeamAssignmentEntity> _healthPlanCriteriaTeamAssignment;
		private EntityCollection<HealthPlanFillEventCallQueueEntity> _healthPlanFillEventCallQueue;
		private EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity> _languageBarrierCallQueueCriteriaAssignment;
		private EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity> _mailRoundCallQueueCriteriaAssignment;
		private EntityCollection<NoShowCallQueueCriteriaAssignmentEntity> _noShowCallQueueCriteriaAssignment;
		private EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity> _uncontactedCustomerCallQueueCriteriaAssignment;
		private EntityCollection<CallCenterTeamEntity> _callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment;
		private EntityCollection<CallQueueEntity> _callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<CallQueueCustomerEntity> _callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment;
		private EntityCollection<CallRoundCallQueueEntity> _callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment;
		private EntityCollection<CampaignActivityEntity> _campaignActivityCollectionViaHealthPlanCriteriaDirectMail;
		private EntityCollection<EventsEntity> _eventsCollectionViaHealthPlanFillEventCallQueue;
		private EntityCollection<FileEntity> _fileCollectionViaHealthPlanCriteriaAssignmentUpload;
		private EntityCollection<FillEventCallQueueEntity> _fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment;
		private EntityCollection<LanguageBarrierCallQueueEntity> _languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment;
		private EntityCollection<MailRoundCallQueueEntity> _mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment;
		private EntityCollection<NoShowCallQueueEntity> _noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment;
		private EntityCollection<OrganizationRoleUserEntity> _organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload;
		private EntityCollection<UncontactedCustomerCallQueueEntity> _uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment;
		private AccountEntity _account;
		private CallQueueEntity _callQueue;
		private CampaignEntity _campaign;
		private LanguageEntity _language;
		private OrganizationRoleUserEntity _organizationRoleUser_;
		private OrganizationRoleUserEntity _organizationRoleUser__;

		
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
			/// <summary>Member name CallQueue</summary>
			public static readonly string CallQueue = "CallQueue";
			/// <summary>Member name Campaign</summary>
			public static readonly string Campaign = "Campaign";
			/// <summary>Member name Language</summary>
			public static readonly string Language = "Language";
			/// <summary>Member name OrganizationRoleUser_</summary>
			public static readonly string OrganizationRoleUser_ = "OrganizationRoleUser_";
			/// <summary>Member name OrganizationRoleUser__</summary>
			public static readonly string OrganizationRoleUser__ = "OrganizationRoleUser__";
			/// <summary>Member name CallRoundCallQueueCriteriaAssignment</summary>
			public static readonly string CallRoundCallQueueCriteriaAssignment = "CallRoundCallQueueCriteriaAssignment";
			/// <summary>Member name FillEventCallQueueCriteriaAssignment</summary>
			public static readonly string FillEventCallQueueCriteriaAssignment = "FillEventCallQueueCriteriaAssignment";
			/// <summary>Member name HealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string HealthPlanCallQueueCriteriaAssignment = "HealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name HealthPlanCriteriaAssignment</summary>
			public static readonly string HealthPlanCriteriaAssignment = "HealthPlanCriteriaAssignment";
			/// <summary>Member name HealthPlanCriteriaAssignmentUpload</summary>
			public static readonly string HealthPlanCriteriaAssignmentUpload = "HealthPlanCriteriaAssignmentUpload";
			/// <summary>Member name HealthPlanCriteriaDirectMail</summary>
			public static readonly string HealthPlanCriteriaDirectMail = "HealthPlanCriteriaDirectMail";
			/// <summary>Member name HealthPlanCriteriaTeamAssignment</summary>
			public static readonly string HealthPlanCriteriaTeamAssignment = "HealthPlanCriteriaTeamAssignment";
			/// <summary>Member name HealthPlanFillEventCallQueue</summary>
			public static readonly string HealthPlanFillEventCallQueue = "HealthPlanFillEventCallQueue";
			/// <summary>Member name LanguageBarrierCallQueueCriteriaAssignment</summary>
			public static readonly string LanguageBarrierCallQueueCriteriaAssignment = "LanguageBarrierCallQueueCriteriaAssignment";
			/// <summary>Member name MailRoundCallQueueCriteriaAssignment</summary>
			public static readonly string MailRoundCallQueueCriteriaAssignment = "MailRoundCallQueueCriteriaAssignment";
			/// <summary>Member name NoShowCallQueueCriteriaAssignment</summary>
			public static readonly string NoShowCallQueueCriteriaAssignment = "NoShowCallQueueCriteriaAssignment";
			/// <summary>Member name UncontactedCustomerCallQueueCriteriaAssignment</summary>
			public static readonly string UncontactedCustomerCallQueueCriteriaAssignment = "UncontactedCustomerCallQueueCriteriaAssignment";
			/// <summary>Member name CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment</summary>
			public static readonly string CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment = "CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment";
			/// <summary>Member name CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment</summary>
			public static readonly string CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment";
			/// <summary>Member name CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment</summary>
			public static readonly string CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment = "CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment";
			/// <summary>Member name CampaignActivityCollectionViaHealthPlanCriteriaDirectMail</summary>
			public static readonly string CampaignActivityCollectionViaHealthPlanCriteriaDirectMail = "CampaignActivityCollectionViaHealthPlanCriteriaDirectMail";
			/// <summary>Member name EventsCollectionViaHealthPlanFillEventCallQueue</summary>
			public static readonly string EventsCollectionViaHealthPlanFillEventCallQueue = "EventsCollectionViaHealthPlanFillEventCallQueue";
			/// <summary>Member name FileCollectionViaHealthPlanCriteriaAssignmentUpload</summary>
			public static readonly string FileCollectionViaHealthPlanCriteriaAssignmentUpload = "FileCollectionViaHealthPlanCriteriaAssignmentUpload";
			/// <summary>Member name FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment</summary>
			public static readonly string FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment = "FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment";
			/// <summary>Member name LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment</summary>
			public static readonly string LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment = "LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment";
			/// <summary>Member name MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment</summary>
			public static readonly string MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment = "MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment";
			/// <summary>Member name NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment</summary>
			public static readonly string NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment = "NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ = "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment = "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ = "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment";
			/// <summary>Member name OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload</summary>
			public static readonly string OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload = "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload";
			/// <summary>Member name UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment</summary>
			public static readonly string UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment = "UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static HealthPlanCallQueueCriteriaEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public HealthPlanCallQueueCriteriaEntity():base("HealthPlanCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public HealthPlanCallQueueCriteriaEntity(IEntityFields2 fields):base("HealthPlanCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this HealthPlanCallQueueCriteriaEntity</param>
		public HealthPlanCallQueueCriteriaEntity(IValidator validator):base("HealthPlanCallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for HealthPlanCallQueueCriteria which data should be fetched into this HealthPlanCallQueueCriteria object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HealthPlanCallQueueCriteriaEntity(System.Int64 id):base("HealthPlanCallQueueCriteriaEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for HealthPlanCallQueueCriteria which data should be fetched into this HealthPlanCallQueueCriteria object</param>
		/// <param name="validator">The custom validator object for this HealthPlanCallQueueCriteriaEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public HealthPlanCallQueueCriteriaEntity(System.Int64 id, IValidator validator):base("HealthPlanCallQueueCriteriaEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected HealthPlanCallQueueCriteriaEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_callRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>)info.GetValue("_callRoundCallQueueCriteriaAssignment", typeof(EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>));
				_fillEventCallQueueCriteriaAssignment = (EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>)info.GetValue("_fillEventCallQueueCriteriaAssignment", typeof(EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>));
				_healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>)info.GetValue("_healthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>));
				_healthPlanCriteriaAssignment = (EntityCollection<HealthPlanCriteriaAssignmentEntity>)info.GetValue("_healthPlanCriteriaAssignment", typeof(EntityCollection<HealthPlanCriteriaAssignmentEntity>));
				_healthPlanCriteriaAssignmentUpload = (EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>)info.GetValue("_healthPlanCriteriaAssignmentUpload", typeof(EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>));
				_healthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCriteriaDirectMailEntity>)info.GetValue("_healthPlanCriteriaDirectMail", typeof(EntityCollection<HealthPlanCriteriaDirectMailEntity>));
				_healthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>)info.GetValue("_healthPlanCriteriaTeamAssignment", typeof(EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>));
				_healthPlanFillEventCallQueue = (EntityCollection<HealthPlanFillEventCallQueueEntity>)info.GetValue("_healthPlanFillEventCallQueue", typeof(EntityCollection<HealthPlanFillEventCallQueueEntity>));
				_languageBarrierCallQueueCriteriaAssignment = (EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>)info.GetValue("_languageBarrierCallQueueCriteriaAssignment", typeof(EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>));
				_mailRoundCallQueueCriteriaAssignment = (EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>)info.GetValue("_mailRoundCallQueueCriteriaAssignment", typeof(EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>));
				_noShowCallQueueCriteriaAssignment = (EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>)info.GetValue("_noShowCallQueueCriteriaAssignment", typeof(EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>));
				_uncontactedCustomerCallQueueCriteriaAssignment = (EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>)info.GetValue("_uncontactedCustomerCallQueueCriteriaAssignment", typeof(EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>));
				_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<CallCenterTeamEntity>)info.GetValue("_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment", typeof(EntityCollection<CallCenterTeamEntity>));
				_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueEntity>)info.GetValue("_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<CallQueueEntity>));
				_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueCustomerEntity>)info.GetValue("_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", typeof(EntityCollection<CallQueueCustomerEntity>));
				_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueEntity>)info.GetValue("_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment", typeof(EntityCollection<CallRoundCallQueueEntity>));
				_campaignActivityCollectionViaHealthPlanCriteriaDirectMail = (EntityCollection<CampaignActivityEntity>)info.GetValue("_campaignActivityCollectionViaHealthPlanCriteriaDirectMail", typeof(EntityCollection<CampaignActivityEntity>));
				_eventsCollectionViaHealthPlanFillEventCallQueue = (EntityCollection<EventsEntity>)info.GetValue("_eventsCollectionViaHealthPlanFillEventCallQueue", typeof(EntityCollection<EventsEntity>));
				_fileCollectionViaHealthPlanCriteriaAssignmentUpload = (EntityCollection<FileEntity>)info.GetValue("_fileCollectionViaHealthPlanCriteriaAssignmentUpload", typeof(EntityCollection<FileEntity>));
				_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment = (EntityCollection<FillEventCallQueueEntity>)info.GetValue("_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment", typeof(EntityCollection<FillEventCallQueueEntity>));
				_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment = (EntityCollection<LanguageBarrierCallQueueEntity>)info.GetValue("_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment", typeof(EntityCollection<LanguageBarrierCallQueueEntity>));
				_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment = (EntityCollection<MailRoundCallQueueEntity>)info.GetValue("_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment", typeof(EntityCollection<MailRoundCallQueueEntity>));
				_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment = (EntityCollection<NoShowCallQueueEntity>)info.GetValue("_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment", typeof(EntityCollection<NoShowCallQueueEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload = (EntityCollection<OrganizationRoleUserEntity>)info.GetValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload", typeof(EntityCollection<OrganizationRoleUserEntity>));
				_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment = (EntityCollection<UncontactedCustomerCallQueueEntity>)info.GetValue("_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment", typeof(EntityCollection<UncontactedCustomerCallQueueEntity>));
				_account = (AccountEntity)info.GetValue("_account", typeof(AccountEntity));
				if(_account!=null)
				{
					_account.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_callQueue = (CallQueueEntity)info.GetValue("_callQueue", typeof(CallQueueEntity));
				if(_callQueue!=null)
				{
					_callQueue.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_campaign = (CampaignEntity)info.GetValue("_campaign", typeof(CampaignEntity));
				if(_campaign!=null)
				{
					_campaign.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_language = (LanguageEntity)info.GetValue("_language", typeof(LanguageEntity));
				if(_language!=null)
				{
					_language.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser_ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser_", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser_!=null)
				{
					_organizationRoleUser_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_organizationRoleUser__ = (OrganizationRoleUserEntity)info.GetValue("_organizationRoleUser__", typeof(OrganizationRoleUserEntity));
				if(_organizationRoleUser__!=null)
				{
					_organizationRoleUser__.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((HealthPlanCallQueueCriteriaFieldIndex)fieldIndex)
			{
				case HealthPlanCallQueueCriteriaFieldIndex.CallQueueId:
					DesetupSyncCallQueue(true, false);
					break;
				case HealthPlanCallQueueCriteriaFieldIndex.HealthPlanId:
					DesetupSyncAccount(true, false);
					break;
				case HealthPlanCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser_(true, false);
					break;
				case HealthPlanCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId:
					DesetupSyncOrganizationRoleUser__(true, false);
					break;
				case HealthPlanCallQueueCriteriaFieldIndex.CampaignId:
					DesetupSyncCampaign(true, false);
					break;
				case HealthPlanCallQueueCriteriaFieldIndex.LanguageId:
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
				case "CallQueue":
					this.CallQueue = (CallQueueEntity)entity;
					break;
				case "Campaign":
					this.Campaign = (CampaignEntity)entity;
					break;
				case "Language":
					this.Language = (LanguageEntity)entity;
					break;
				case "OrganizationRoleUser_":
					this.OrganizationRoleUser_ = (OrganizationRoleUserEntity)entity;
					break;
				case "OrganizationRoleUser__":
					this.OrganizationRoleUser__ = (OrganizationRoleUserEntity)entity;
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					this.CallRoundCallQueueCriteriaAssignment.Add((CallRoundCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "FillEventCallQueueCriteriaAssignment":
					this.FillEventCallQueueCriteriaAssignment.Add((FillEventCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "HealthPlanCriteriaAssignment":
					this.HealthPlanCriteriaAssignment.Add((HealthPlanCriteriaAssignmentEntity)entity);
					break;
				case "HealthPlanCriteriaAssignmentUpload":
					this.HealthPlanCriteriaAssignmentUpload.Add((HealthPlanCriteriaAssignmentUploadEntity)entity);
					break;
				case "HealthPlanCriteriaDirectMail":
					this.HealthPlanCriteriaDirectMail.Add((HealthPlanCriteriaDirectMailEntity)entity);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					this.HealthPlanCriteriaTeamAssignment.Add((HealthPlanCriteriaTeamAssignmentEntity)entity);
					break;
				case "HealthPlanFillEventCallQueue":
					this.HealthPlanFillEventCallQueue.Add((HealthPlanFillEventCallQueueEntity)entity);
					break;
				case "LanguageBarrierCallQueueCriteriaAssignment":
					this.LanguageBarrierCallQueueCriteriaAssignment.Add((LanguageBarrierCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "MailRoundCallQueueCriteriaAssignment":
					this.MailRoundCallQueueCriteriaAssignment.Add((MailRoundCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "NoShowCallQueueCriteriaAssignment":
					this.NoShowCallQueueCriteriaAssignment.Add((NoShowCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "UncontactedCustomerCallQueueCriteriaAssignment":
					this.UncontactedCustomerCallQueueCriteriaAssignment.Add((UncontactedCustomerCallQueueCriteriaAssignmentEntity)entity);
					break;
				case "CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment":
					this.CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = false;
					this.CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.Add((CallCenterTeamEntity)entity);
					this.CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = true;
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((CallQueueEntity)entity);
					this.CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment":
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = false;
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.Add((CallQueueCustomerEntity)entity);
					this.CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment":
					this.CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly = false;
					this.CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.Add((CallRoundCallQueueEntity)entity);
					this.CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "CampaignActivityCollectionViaHealthPlanCriteriaDirectMail":
					this.CampaignActivityCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly = false;
					this.CampaignActivityCollectionViaHealthPlanCriteriaDirectMail.Add((CampaignActivityEntity)entity);
					this.CampaignActivityCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly = true;
					break;
				case "EventsCollectionViaHealthPlanFillEventCallQueue":
					this.EventsCollectionViaHealthPlanFillEventCallQueue.IsReadOnly = false;
					this.EventsCollectionViaHealthPlanFillEventCallQueue.Add((EventsEntity)entity);
					this.EventsCollectionViaHealthPlanFillEventCallQueue.IsReadOnly = true;
					break;
				case "FileCollectionViaHealthPlanCriteriaAssignmentUpload":
					this.FileCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly = false;
					this.FileCollectionViaHealthPlanCriteriaAssignmentUpload.Add((FileEntity)entity);
					this.FileCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly = true;
					break;
				case "FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment":
					this.FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.IsReadOnly = false;
					this.FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.Add((FillEventCallQueueEntity)entity);
					this.FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment":
					this.LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.IsReadOnly = false;
					this.LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.Add((LanguageBarrierCallQueueEntity)entity);
					this.LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment":
					this.MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.IsReadOnly = false;
					this.MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.Add((MailRoundCallQueueEntity)entity);
					this.MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment":
					this.NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.IsReadOnly = false;
					this.NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.Add((NoShowCallQueueEntity)entity);
					this.NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly = true;
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload":
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly = false;
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.Add((OrganizationRoleUserEntity)entity);
					this.OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly = true;
					break;
				case "UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment":
					this.UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.IsReadOnly = false;
					this.UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.Add((UncontactedCustomerCallQueueEntity)entity);
					this.UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.IsReadOnly = true;
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
			return HealthPlanCallQueueCriteriaEntity.GetRelationsForField(fieldName);
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
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId);
					break;
				case "CallQueue":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId);
					break;
				case "Campaign":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId);
					break;
				case "Language":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId);
					break;
				case "OrganizationRoleUser_":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId);
					break;
				case "OrganizationRoleUser__":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "FillEventCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.FillEventCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "HealthPlanCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId);
					break;
				case "HealthPlanCriteriaAssignmentUpload":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId);
					break;
				case "HealthPlanCriteriaDirectMail":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCriteriaId);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId);
					break;
				case "HealthPlanFillEventCallQueue":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanFillEventCallQueueEntityUsingCriteriaId);
					break;
				case "LanguageBarrierCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageBarrierCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "MailRoundCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.MailRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "NoShowCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.NoShowCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "UncontactedCustomerCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.UncontactedCustomerCallQueueCriteriaAssignmentEntityUsingCriteriaId);
					break;
				case "CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.CallCenterTeamEntityUsingTeamId, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.CallQueueEntityUsingCallQueueId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCallQueueCriteriaAssignmentEntity.Relations.CallQueueCustomerEntityUsingCallQueueCustomerId, "HealthPlanCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "CallRoundCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(CallRoundCallQueueCriteriaAssignmentEntity.Relations.CallRoundCallQueueEntityUsingCallRoundCallQueueId, "CallRoundCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "CampaignActivityCollectionViaHealthPlanCriteriaDirectMail":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaDirectMail_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaDirectMailEntity.Relations.CampaignActivityEntityUsingCampaignActivityId, "HealthPlanCriteriaDirectMail_", string.Empty, JoinHint.None);
					break;
				case "EventsCollectionViaHealthPlanFillEventCallQueue":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanFillEventCallQueueEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanFillEventCallQueue_", JoinHint.None);
					toReturn.Add(HealthPlanFillEventCallQueueEntity.Relations.EventsEntityUsingEventId, "HealthPlanFillEventCallQueue_", string.Empty, JoinHint.None);
					break;
				case "FileCollectionViaHealthPlanCriteriaAssignmentUpload":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaAssignmentUpload_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaAssignmentUploadEntity.Relations.FileEntityUsingFileId, "HealthPlanCriteriaAssignmentUpload_", string.Empty, JoinHint.None);
					break;
				case "FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.FillEventCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "FillEventCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(FillEventCallQueueCriteriaAssignmentEntity.Relations.FillEventCallQueueEntityUsingFillEventCallQueueId, "FillEventCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.LanguageBarrierCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "LanguageBarrierCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(LanguageBarrierCallQueueCriteriaAssignmentEntity.Relations.LanguageBarrierCallQueueEntityUsingLanguageBarrierCallQueueId, "LanguageBarrierCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.MailRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "MailRoundCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(MailRoundCallQueueCriteriaAssignmentEntity.Relations.MailRoundCallQueueEntityUsingMailRoundCallQueueId, "MailRoundCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.NoShowCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "NoShowCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(NoShowCallQueueCriteriaAssignmentEntity.Relations.NoShowCallQueueEntityUsingNoShowCallQueueId, "NoShowCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaAssignmentEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "HealthPlanCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaAssignmentEntity.Relations.OrganizationRoleUserEntityUsingAssignedToOrgRoleUserId, "HealthPlanCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaAssignmentEntity.Relations.OrganizationRoleUserEntityUsingModifiedBy, "HealthPlanCriteriaAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaTeamAssignment_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaTeamAssignmentEntity.Relations.OrganizationRoleUserEntityUsingCreatedBy, "HealthPlanCriteriaTeamAssignment_", string.Empty, JoinHint.None);
					break;
				case "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "HealthPlanCriteriaAssignmentUpload_", JoinHint.None);
					toReturn.Add(HealthPlanCriteriaAssignmentUploadEntity.Relations.OrganizationRoleUserEntityUsingUploadedByOrgRoleUserId, "HealthPlanCriteriaAssignmentUpload_", string.Empty, JoinHint.None);
					break;
				case "UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment":
					toReturn.Add(HealthPlanCallQueueCriteriaEntity.Relations.UncontactedCustomerCallQueueCriteriaAssignmentEntityUsingCriteriaId, "HealthPlanCallQueueCriteriaEntity__", "UncontactedCustomerCallQueueCriteriaAssignment_", JoinHint.None);
					toReturn.Add(UncontactedCustomerCallQueueCriteriaAssignmentEntity.Relations.UncontactedCustomerCallQueueEntityUsingUncontactedCustomerId, "UncontactedCustomerCallQueueCriteriaAssignment_", string.Empty, JoinHint.None);
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
				case "CallQueue":
					SetupSyncCallQueue(relatedEntity);
					break;
				case "Campaign":
					SetupSyncCampaign(relatedEntity);
					break;
				case "Language":
					SetupSyncLanguage(relatedEntity);
					break;
				case "OrganizationRoleUser_":
					SetupSyncOrganizationRoleUser_(relatedEntity);
					break;
				case "OrganizationRoleUser__":
					SetupSyncOrganizationRoleUser__(relatedEntity);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					this.CallRoundCallQueueCriteriaAssignment.Add((CallRoundCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "FillEventCallQueueCriteriaAssignment":
					this.FillEventCallQueueCriteriaAssignment.Add((FillEventCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					this.HealthPlanCallQueueCriteriaAssignment.Add((HealthPlanCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaAssignment":
					this.HealthPlanCriteriaAssignment.Add((HealthPlanCriteriaAssignmentEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaAssignmentUpload":
					this.HealthPlanCriteriaAssignmentUpload.Add((HealthPlanCriteriaAssignmentUploadEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaDirectMail":
					this.HealthPlanCriteriaDirectMail.Add((HealthPlanCriteriaDirectMailEntity)relatedEntity);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					this.HealthPlanCriteriaTeamAssignment.Add((HealthPlanCriteriaTeamAssignmentEntity)relatedEntity);
					break;
				case "HealthPlanFillEventCallQueue":
					this.HealthPlanFillEventCallQueue.Add((HealthPlanFillEventCallQueueEntity)relatedEntity);
					break;
				case "LanguageBarrierCallQueueCriteriaAssignment":
					this.LanguageBarrierCallQueueCriteriaAssignment.Add((LanguageBarrierCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "MailRoundCallQueueCriteriaAssignment":
					this.MailRoundCallQueueCriteriaAssignment.Add((MailRoundCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "NoShowCallQueueCriteriaAssignment":
					this.NoShowCallQueueCriteriaAssignment.Add((NoShowCallQueueCriteriaAssignmentEntity)relatedEntity);
					break;
				case "UncontactedCustomerCallQueueCriteriaAssignment":
					this.UncontactedCustomerCallQueueCriteriaAssignment.Add((UncontactedCustomerCallQueueCriteriaAssignmentEntity)relatedEntity);
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
				case "CallQueue":
					DesetupSyncCallQueue(false, true);
					break;
				case "Campaign":
					DesetupSyncCampaign(false, true);
					break;
				case "Language":
					DesetupSyncLanguage(false, true);
					break;
				case "OrganizationRoleUser_":
					DesetupSyncOrganizationRoleUser_(false, true);
					break;
				case "OrganizationRoleUser__":
					DesetupSyncOrganizationRoleUser__(false, true);
					break;
				case "CallRoundCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.CallRoundCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "FillEventCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.FillEventCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaAssignmentUpload":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaAssignmentUpload, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaDirectMail":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaDirectMail, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanCriteriaTeamAssignment":
					base.PerformRelatedEntityRemoval(this.HealthPlanCriteriaTeamAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "HealthPlanFillEventCallQueue":
					base.PerformRelatedEntityRemoval(this.HealthPlanFillEventCallQueue, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "LanguageBarrierCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.LanguageBarrierCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "MailRoundCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.MailRoundCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "NoShowCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.NoShowCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
					break;
				case "UncontactedCustomerCallQueueCriteriaAssignment":
					base.PerformRelatedEntityRemoval(this.UncontactedCustomerCallQueueCriteriaAssignment, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_callQueue!=null)
			{
				toReturn.Add(_callQueue);
			}
			if(_campaign!=null)
			{
				toReturn.Add(_campaign);
			}
			if(_language!=null)
			{
				toReturn.Add(_language);
			}
			if(_organizationRoleUser_!=null)
			{
				toReturn.Add(_organizationRoleUser_);
			}
			if(_organizationRoleUser__!=null)
			{
				toReturn.Add(_organizationRoleUser__);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CallRoundCallQueueCriteriaAssignment);
			toReturn.Add(this.FillEventCallQueueCriteriaAssignment);
			toReturn.Add(this.HealthPlanCallQueueCriteriaAssignment);
			toReturn.Add(this.HealthPlanCriteriaAssignment);
			toReturn.Add(this.HealthPlanCriteriaAssignmentUpload);
			toReturn.Add(this.HealthPlanCriteriaDirectMail);
			toReturn.Add(this.HealthPlanCriteriaTeamAssignment);
			toReturn.Add(this.HealthPlanFillEventCallQueue);
			toReturn.Add(this.LanguageBarrierCallQueueCriteriaAssignment);
			toReturn.Add(this.MailRoundCallQueueCriteriaAssignment);
			toReturn.Add(this.NoShowCallQueueCriteriaAssignment);
			toReturn.Add(this.UncontactedCustomerCallQueueCriteriaAssignment);

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
				info.AddValue("_callRoundCallQueueCriteriaAssignment", ((_callRoundCallQueueCriteriaAssignment!=null) && (_callRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_fillEventCallQueueCriteriaAssignment", ((_fillEventCallQueueCriteriaAssignment!=null) && (_fillEventCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_fillEventCallQueueCriteriaAssignment:null);
				info.AddValue("_healthPlanCallQueueCriteriaAssignment", ((_healthPlanCallQueueCriteriaAssignment!=null) && (_healthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_healthPlanCriteriaAssignment", ((_healthPlanCriteriaAssignment!=null) && (_healthPlanCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaAssignment:null);
				info.AddValue("_healthPlanCriteriaAssignmentUpload", ((_healthPlanCriteriaAssignmentUpload!=null) && (_healthPlanCriteriaAssignmentUpload.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaAssignmentUpload:null);
				info.AddValue("_healthPlanCriteriaDirectMail", ((_healthPlanCriteriaDirectMail!=null) && (_healthPlanCriteriaDirectMail.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaDirectMail:null);
				info.AddValue("_healthPlanCriteriaTeamAssignment", ((_healthPlanCriteriaTeamAssignment!=null) && (_healthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_healthPlanCriteriaTeamAssignment:null);
				info.AddValue("_healthPlanFillEventCallQueue", ((_healthPlanFillEventCallQueue!=null) && (_healthPlanFillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_healthPlanFillEventCallQueue:null);
				info.AddValue("_languageBarrierCallQueueCriteriaAssignment", ((_languageBarrierCallQueueCriteriaAssignment!=null) && (_languageBarrierCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_languageBarrierCallQueueCriteriaAssignment:null);
				info.AddValue("_mailRoundCallQueueCriteriaAssignment", ((_mailRoundCallQueueCriteriaAssignment!=null) && (_mailRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_mailRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_noShowCallQueueCriteriaAssignment", ((_noShowCallQueueCriteriaAssignment!=null) && (_noShowCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_noShowCallQueueCriteriaAssignment:null);
				info.AddValue("_uncontactedCustomerCallQueueCriteriaAssignment", ((_uncontactedCustomerCallQueueCriteriaAssignment!=null) && (_uncontactedCustomerCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_uncontactedCustomerCallQueueCriteriaAssignment:null);
				info.AddValue("_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment", ((_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment!=null) && (_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment:null);
				info.AddValue("_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", ((_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment!=null) && (_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment:null);
				info.AddValue("_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment", ((_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment!=null) && (_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_campaignActivityCollectionViaHealthPlanCriteriaDirectMail", ((_campaignActivityCollectionViaHealthPlanCriteriaDirectMail!=null) && (_campaignActivityCollectionViaHealthPlanCriteriaDirectMail.Count>0) && !this.MarkedForDeletion)?_campaignActivityCollectionViaHealthPlanCriteriaDirectMail:null);
				info.AddValue("_eventsCollectionViaHealthPlanFillEventCallQueue", ((_eventsCollectionViaHealthPlanFillEventCallQueue!=null) && (_eventsCollectionViaHealthPlanFillEventCallQueue.Count>0) && !this.MarkedForDeletion)?_eventsCollectionViaHealthPlanFillEventCallQueue:null);
				info.AddValue("_fileCollectionViaHealthPlanCriteriaAssignmentUpload", ((_fileCollectionViaHealthPlanCriteriaAssignmentUpload!=null) && (_fileCollectionViaHealthPlanCriteriaAssignmentUpload.Count>0) && !this.MarkedForDeletion)?_fileCollectionViaHealthPlanCriteriaAssignmentUpload:null);
				info.AddValue("_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment", ((_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment!=null) && (_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment:null);
				info.AddValue("_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment", ((_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment!=null) && (_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment:null);
				info.AddValue("_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment", ((_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment!=null) && (_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment:null);
				info.AddValue("_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment", ((_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment!=null) && (_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", ((_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_", ((_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment", ((_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__", ((_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", ((_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment:null);
				info.AddValue("_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload", ((_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload!=null) && (_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.Count>0) && !this.MarkedForDeletion)?_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload:null);
				info.AddValue("_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment", ((_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment!=null) && (_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.Count>0) && !this.MarkedForDeletion)?_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment:null);
				info.AddValue("_account", (!this.MarkedForDeletion?_account:null));
				info.AddValue("_callQueue", (!this.MarkedForDeletion?_callQueue:null));
				info.AddValue("_campaign", (!this.MarkedForDeletion?_campaign:null));
				info.AddValue("_language", (!this.MarkedForDeletion?_language:null));
				info.AddValue("_organizationRoleUser_", (!this.MarkedForDeletion?_organizationRoleUser_:null));
				info.AddValue("_organizationRoleUser__", (!this.MarkedForDeletion?_organizationRoleUser__:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(HealthPlanCallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(HealthPlanCallQueueCriteriaFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new HealthPlanCallQueueCriteriaRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallRoundCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallRoundCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FillEventCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFillEventCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FillEventCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaAssignmentFields.HealthPlanCriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaAssignmentUpload' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaAssignmentUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaAssignmentUploadFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaDirectMail' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaDirectMailFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanCriteriaTeamAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCriteriaTeamAssignmentFields.HealthPlanCriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HealthPlanFillEventCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHealthPlanFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanFillEventCallQueueFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LanguageBarrierCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageBarrierCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageBarrierCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MailRoundCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMailRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MailRoundCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NoShowCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoShowCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoShowCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UncontactedCustomerCallQueueCriteriaAssignment' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUncontactedCustomerCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(UncontactedCustomerCallQueueCriteriaAssignmentFields.CriteriaId, null, ComparisonOperator.Equal, this.Id));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallCenterTeam' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallQueueCustomer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CallRoundCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CampaignActivity' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCampaignActivityCollectionViaHealthPlanCriteriaDirectMail()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("CampaignActivityCollectionViaHealthPlanCriteriaDirectMail"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Events' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoEventsCollectionViaHealthPlanFillEventCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("EventsCollectionViaHealthPlanFillEventCallQueue"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'File' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFileCollectionViaHealthPlanCriteriaAssignmentUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FileCollectionViaHealthPlanCriteriaAssignmentUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FillEventCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LanguageBarrierCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MailRoundCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'NoShowCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'UncontactedCustomerCallQueue' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoUncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.AddRange(GetRelationsForFieldOfType("UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment"));
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HealthPlanCallQueueCriteriaFields.Id, null, ComparisonOperator.Equal, this.Id, "HealthPlanCallQueueCriteriaEntity__"));
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
		/// the related entity of type 'CallQueue' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCallQueue()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CallQueueFields.CallQueueId, null, ComparisonOperator.Equal, this.CallQueueId));
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
		/// the related entity of type 'Language' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLanguage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(LanguageFields.Id, null, ComparisonOperator.Equal, this.LanguageId));
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
		/// the related entity of type 'OrganizationRoleUser' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOrganizationRoleUser__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OrganizationRoleUserFields.OrganizationRoleUserId, null, ComparisonOperator.Equal, this.ModifiedByOrgRoleUserId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._callRoundCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._fillEventCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._healthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._healthPlanCriteriaAssignment);
			collectionsQueue.Enqueue(this._healthPlanCriteriaAssignmentUpload);
			collectionsQueue.Enqueue(this._healthPlanCriteriaDirectMail);
			collectionsQueue.Enqueue(this._healthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._healthPlanFillEventCallQueue);
			collectionsQueue.Enqueue(this._languageBarrierCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._mailRoundCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._noShowCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._uncontactedCustomerCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._campaignActivityCollectionViaHealthPlanCriteriaDirectMail);
			collectionsQueue.Enqueue(this._eventsCollectionViaHealthPlanFillEventCallQueue);
			collectionsQueue.Enqueue(this._fileCollectionViaHealthPlanCriteriaAssignmentUpload);
			collectionsQueue.Enqueue(this._fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment);
			collectionsQueue.Enqueue(this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload);
			collectionsQueue.Enqueue(this._uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._callRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._fillEventCallQueueCriteriaAssignment = (EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCallQueueCriteriaAssignment = (EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaAssignment = (EntityCollection<HealthPlanCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaAssignmentUpload = (EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaDirectMail = (EntityCollection<HealthPlanCriteriaDirectMailEntity>) collectionsQueue.Dequeue();
			this._healthPlanCriteriaTeamAssignment = (EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>) collectionsQueue.Dequeue();
			this._healthPlanFillEventCallQueue = (EntityCollection<HealthPlanFillEventCallQueueEntity>) collectionsQueue.Dequeue();
			this._languageBarrierCallQueueCriteriaAssignment = (EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._mailRoundCallQueueCriteriaAssignment = (EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._noShowCallQueueCriteriaAssignment = (EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._uncontactedCustomerCallQueueCriteriaAssignment = (EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>) collectionsQueue.Dequeue();
			this._callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<CallCenterTeamEntity>) collectionsQueue.Dequeue();
			this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueEntity>) collectionsQueue.Dequeue();
			this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = (EntityCollection<CallQueueCustomerEntity>) collectionsQueue.Dequeue();
			this._callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment = (EntityCollection<CallRoundCallQueueEntity>) collectionsQueue.Dequeue();
			this._campaignActivityCollectionViaHealthPlanCriteriaDirectMail = (EntityCollection<CampaignActivityEntity>) collectionsQueue.Dequeue();
			this._eventsCollectionViaHealthPlanFillEventCallQueue = (EntityCollection<EventsEntity>) collectionsQueue.Dequeue();
			this._fileCollectionViaHealthPlanCriteriaAssignmentUpload = (EntityCollection<FileEntity>) collectionsQueue.Dequeue();
			this._fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment = (EntityCollection<FillEventCallQueueEntity>) collectionsQueue.Dequeue();
			this._languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment = (EntityCollection<LanguageBarrierCallQueueEntity>) collectionsQueue.Dequeue();
			this._mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment = (EntityCollection<MailRoundCallQueueEntity>) collectionsQueue.Dequeue();
			this._noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment = (EntityCollection<NoShowCallQueueEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload = (EntityCollection<OrganizationRoleUserEntity>) collectionsQueue.Dequeue();
			this._uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment = (EntityCollection<UncontactedCustomerCallQueueEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._callRoundCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._fillEventCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaAssignment != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaAssignmentUpload != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaDirectMail != null)
			{
				return true;
			}
			if (this._healthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._healthPlanFillEventCallQueue != null)
			{
				return true;
			}
			if (this._languageBarrierCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._mailRoundCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._noShowCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._uncontactedCustomerCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._campaignActivityCollectionViaHealthPlanCriteriaDirectMail != null)
			{
				return true;
			}
			if (this._eventsCollectionViaHealthPlanFillEventCallQueue != null)
			{
				return true;
			}
			if (this._fileCollectionViaHealthPlanCriteriaAssignmentUpload != null)
			{
				return true;
			}
			if (this._fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment != null)
			{
				return true;
			}
			if (this._organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload != null)
			{
				return true;
			}
			if (this._uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentUploadEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HealthPlanFillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanFillEventCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueCriteriaAssignmentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallCenterTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterTeamEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory))) : null);
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
			toReturn.Add("CallQueue", _callQueue);
			toReturn.Add("Campaign", _campaign);
			toReturn.Add("Language", _language);
			toReturn.Add("OrganizationRoleUser_", _organizationRoleUser_);
			toReturn.Add("OrganizationRoleUser__", _organizationRoleUser__);
			toReturn.Add("CallRoundCallQueueCriteriaAssignment", _callRoundCallQueueCriteriaAssignment);
			toReturn.Add("FillEventCallQueueCriteriaAssignment", _fillEventCallQueueCriteriaAssignment);
			toReturn.Add("HealthPlanCallQueueCriteriaAssignment", _healthPlanCallQueueCriteriaAssignment);
			toReturn.Add("HealthPlanCriteriaAssignment", _healthPlanCriteriaAssignment);
			toReturn.Add("HealthPlanCriteriaAssignmentUpload", _healthPlanCriteriaAssignmentUpload);
			toReturn.Add("HealthPlanCriteriaDirectMail", _healthPlanCriteriaDirectMail);
			toReturn.Add("HealthPlanCriteriaTeamAssignment", _healthPlanCriteriaTeamAssignment);
			toReturn.Add("HealthPlanFillEventCallQueue", _healthPlanFillEventCallQueue);
			toReturn.Add("LanguageBarrierCallQueueCriteriaAssignment", _languageBarrierCallQueueCriteriaAssignment);
			toReturn.Add("MailRoundCallQueueCriteriaAssignment", _mailRoundCallQueueCriteriaAssignment);
			toReturn.Add("NoShowCallQueueCriteriaAssignment", _noShowCallQueueCriteriaAssignment);
			toReturn.Add("UncontactedCustomerCallQueueCriteriaAssignment", _uncontactedCustomerCallQueueCriteriaAssignment);
			toReturn.Add("CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment", _callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment);
			toReturn.Add("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", _callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", _callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment);
			toReturn.Add("CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment", _callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment);
			toReturn.Add("CampaignActivityCollectionViaHealthPlanCriteriaDirectMail", _campaignActivityCollectionViaHealthPlanCriteriaDirectMail);
			toReturn.Add("EventsCollectionViaHealthPlanFillEventCallQueue", _eventsCollectionViaHealthPlanFillEventCallQueue);
			toReturn.Add("FileCollectionViaHealthPlanCriteriaAssignmentUpload", _fileCollectionViaHealthPlanCriteriaAssignmentUpload);
			toReturn.Add("FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment", _fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment);
			toReturn.Add("LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment", _languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment);
			toReturn.Add("MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment", _mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment);
			toReturn.Add("NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment", _noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_", _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment", _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__", _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment);
			toReturn.Add("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload", _organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload);
			toReturn.Add("UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment", _uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_callRoundCallQueueCriteriaAssignment!=null)
			{
				_callRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_fillEventCallQueueCriteriaAssignment!=null)
			{
				_fillEventCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCallQueueCriteriaAssignment!=null)
			{
				_healthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaAssignment!=null)
			{
				_healthPlanCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaAssignmentUpload!=null)
			{
				_healthPlanCriteriaAssignmentUpload.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaDirectMail!=null)
			{
				_healthPlanCriteriaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanCriteriaTeamAssignment!=null)
			{
				_healthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_healthPlanFillEventCallQueue!=null)
			{
				_healthPlanFillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_languageBarrierCallQueueCriteriaAssignment!=null)
			{
				_languageBarrierCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_mailRoundCallQueueCriteriaAssignment!=null)
			{
				_mailRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_noShowCallQueueCriteriaAssignment!=null)
			{
				_noShowCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_uncontactedCustomerCallQueueCriteriaAssignment!=null)
			{
				_uncontactedCustomerCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment!=null)
			{
				_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment!=null)
			{
				_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment!=null)
			{
				_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_campaignActivityCollectionViaHealthPlanCriteriaDirectMail!=null)
			{
				_campaignActivityCollectionViaHealthPlanCriteriaDirectMail.ActiveContext = base.ActiveContext;
			}
			if(_eventsCollectionViaHealthPlanFillEventCallQueue!=null)
			{
				_eventsCollectionViaHealthPlanFillEventCallQueue.ActiveContext = base.ActiveContext;
			}
			if(_fileCollectionViaHealthPlanCriteriaAssignmentUpload!=null)
			{
				_fileCollectionViaHealthPlanCriteriaAssignmentUpload.ActiveContext = base.ActiveContext;
			}
			if(_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment!=null)
			{
				_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment!=null)
			{
				_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment!=null)
			{
				_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment!=null)
			{
				_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload!=null)
			{
				_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.ActiveContext = base.ActiveContext;
			}
			if(_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment!=null)
			{
				_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.ActiveContext = base.ActiveContext;
			}
			if(_account!=null)
			{
				_account.ActiveContext = base.ActiveContext;
			}
			if(_callQueue!=null)
			{
				_callQueue.ActiveContext = base.ActiveContext;
			}
			if(_campaign!=null)
			{
				_campaign.ActiveContext = base.ActiveContext;
			}
			if(_language!=null)
			{
				_language.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser_!=null)
			{
				_organizationRoleUser_.ActiveContext = base.ActiveContext;
			}
			if(_organizationRoleUser__!=null)
			{
				_organizationRoleUser__.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_callRoundCallQueueCriteriaAssignment = null;
			_fillEventCallQueueCriteriaAssignment = null;
			_healthPlanCallQueueCriteriaAssignment = null;
			_healthPlanCriteriaAssignment = null;
			_healthPlanCriteriaAssignmentUpload = null;
			_healthPlanCriteriaDirectMail = null;
			_healthPlanCriteriaTeamAssignment = null;
			_healthPlanFillEventCallQueue = null;
			_languageBarrierCallQueueCriteriaAssignment = null;
			_mailRoundCallQueueCriteriaAssignment = null;
			_noShowCallQueueCriteriaAssignment = null;
			_uncontactedCustomerCallQueueCriteriaAssignment = null;
			_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment = null;
			_callQueueCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_callQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment = null;
			_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment = null;
			_campaignActivityCollectionViaHealthPlanCriteriaDirectMail = null;
			_eventsCollectionViaHealthPlanFillEventCallQueue = null;
			_fileCollectionViaHealthPlanCriteriaAssignmentUpload = null;
			_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment = null;
			_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment = null;
			_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment = null;
			_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = null;
			_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload = null;
			_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment = null;
			_account = null;
			_callQueue = null;
			_campaign = null;
			_language = null;
			_organizationRoleUser_ = null;
			_organizationRoleUser__ = null;

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

			_fieldsCustomProperties.Add("CallQueueId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Percentage", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("NoOfDays", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("RoundOfCalls", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("HealthPlanId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CustomTags", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDefault", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsQueueGenerated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LastQueueGeneratedDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateCreated", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DateModified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedByOrgRoleUserId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ZipCode", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Radius", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("IsDeleted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CampaignId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CriteriaName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _account</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncAccount(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.HealthPlanId } );		
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
				base.PerformSetupSyncRelatedEntity( _account, new PropertyChangedEventHandler( OnAccountPropertyChanged ), "Account", HealthPlanCallQueueCriteriaEntity.Relations.AccountEntityUsingHealthPlanId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _callQueue</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCallQueue(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.CallQueueId } );		
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
				base.PerformSetupSyncRelatedEntity( _callQueue, new PropertyChangedEventHandler( OnCallQueuePropertyChanged ), "CallQueue", HealthPlanCallQueueCriteriaEntity.Relations.CallQueueEntityUsingCallQueueId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _campaign</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCampaign(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.CampaignId } );		
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
				base.PerformSetupSyncRelatedEntity( _campaign, new PropertyChangedEventHandler( OnCampaignPropertyChanged ), "Campaign", HealthPlanCallQueueCriteriaEntity.Relations.CampaignEntityUsingCampaignId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _language</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncLanguage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _language, new PropertyChangedEventHandler( OnLanguagePropertyChanged ), "Language", HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.LanguageId } );		
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
				base.PerformSetupSyncRelatedEntity( _language, new PropertyChangedEventHandler( OnLanguagePropertyChanged ), "Language", HealthPlanCallQueueCriteriaEntity.Relations.LanguageEntityUsingLanguageId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria_", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser_, new PropertyChangedEventHandler( OnOrganizationRoleUser_PropertyChanged ), "OrganizationRoleUser_", HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingCreatedByOrgRoleUserId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _organizationRoleUser__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOrganizationRoleUser__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, signalRelatedEntity, "HealthPlanCallQueueCriteria__", resetFKFields, new int[] { (int)HealthPlanCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId } );		
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
				base.PerformSetupSyncRelatedEntity( _organizationRoleUser__, new PropertyChangedEventHandler( OnOrganizationRoleUser__PropertyChanged ), "OrganizationRoleUser__", HealthPlanCallQueueCriteriaEntity.Relations.OrganizationRoleUserEntityUsingModifiedByOrgRoleUserId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this HealthPlanCallQueueCriteriaEntity</param>
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
		public  static HealthPlanCallQueueCriteriaRelations Relations
		{
			get	{ return new HealthPlanCallQueueCriteriaRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallRoundCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("CallRoundCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallRoundCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "CallRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FillEventCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFillEventCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("FillEventCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.FillEventCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "FillEventCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					(IEntityRelation)GetRelationsForField("HealthPlanCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "HealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaAssignmentEntity, 0, null, null, null, null, "HealthPlanCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaAssignmentUpload' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaAssignmentUpload
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentUploadEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaAssignmentUpload")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaAssignmentUploadEntity, 0, null, null, null, null, "HealthPlanCriteriaAssignmentUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaDirectMail' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaDirectMail
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaDirectMail")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaDirectMailEntity, 0, null, null, null, null, "HealthPlanCriteriaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanCriteriaTeamAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanCriteriaTeamAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanCriteriaTeamAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanCriteriaTeamAssignmentEntity, 0, null, null, null, null, "HealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HealthPlanFillEventCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHealthPlanFillEventCallQueue
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<HealthPlanFillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanFillEventCallQueueEntityFactory))),
					(IEntityRelation)GetRelationsForField("HealthPlanFillEventCallQueue")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.HealthPlanFillEventCallQueueEntity, 0, null, null, null, null, "HealthPlanFillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LanguageBarrierCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageBarrierCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("LanguageBarrierCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.LanguageBarrierCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "LanguageBarrierCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MailRoundCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMailRoundCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("MailRoundCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.MailRoundCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "MailRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NoShowCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoShowCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("NoShowCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.NoShowCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "NoShowCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UncontactedCustomerCallQueueCriteriaAssignment' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUncontactedCustomerCallQueueCriteriaAssignment
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueCriteriaAssignmentEntityFactory))),
					(IEntityRelation)GetRelationsForField("UncontactedCustomerCallQueueCriteriaAssignment")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.UncontactedCustomerCallQueueCriteriaAssignmentEntity, 0, null, null, null, null, "UncontactedCustomerCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallCenterTeam' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallCenterTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterTeamEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallCenterTeamEntity, 0, null, null, GetRelationsForField("CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment"), null, "CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, GetRelationsForField("CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "CallQueueCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallQueueCustomer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallQueueCustomerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallQueueCustomerEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueCustomerEntity, 0, null, null, GetRelationsForField("CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment"), null, "CallQueueCustomerCollectionViaHealthPlanCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CallRoundCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.CallRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "CallRoundCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallRoundCallQueueEntity, 0, null, null, GetRelationsForField("CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment"), null, "CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CampaignActivity' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCampaignActivityCollectionViaHealthPlanCriteriaDirectMail
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaDirectMailEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaDirectMail_");
				return new PrefetchPathElement2(new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CampaignActivityEntity, 0, null, null, GetRelationsForField("CampaignActivityCollectionViaHealthPlanCriteriaDirectMail"), null, "CampaignActivityCollectionViaHealthPlanCriteriaDirectMail", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Events' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathEventsCollectionViaHealthPlanFillEventCallQueue
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanFillEventCallQueueEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanFillEventCallQueue_");
				return new PrefetchPathElement2(new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.EventsEntity, 0, null, null, GetRelationsForField("EventsCollectionViaHealthPlanFillEventCallQueue"), null, "EventsCollectionViaHealthPlanFillEventCallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'File' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFileCollectionViaHealthPlanCriteriaAssignmentUpload
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaAssignmentUpload_");
				return new PrefetchPathElement2(new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.FileEntity, 0, null, null, GetRelationsForField("FileCollectionViaHealthPlanCriteriaAssignmentUpload"), null, "FileCollectionViaHealthPlanCriteriaAssignmentUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FillEventCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.FillEventCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "FillEventCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.FillEventCallQueueEntity, 0, null, null, GetRelationsForField("FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment"), null, "FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LanguageBarrierCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.LanguageBarrierCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "LanguageBarrierCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.LanguageBarrierCallQueueEntity, 0, null, null, GetRelationsForField("LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment"), null, "LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MailRoundCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.MailRoundCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "MailRoundCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.MailRoundCallQueueEntity, 0, null, null, GetRelationsForField("MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment"), null, "MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'NoShowCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.NoShowCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "NoShowCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.NoShowCallQueueEntity, 0, null, null, GetRelationsForField("NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment"), null, "NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaTeamAssignmentEntityUsingHealthPlanCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaTeamAssignment_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OrganizationRoleUser' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.HealthPlanCriteriaAssignmentUploadEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "HealthPlanCriteriaAssignmentUpload_");
				return new PrefetchPathElement2(new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, GetRelationsForField("OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload"), null, "OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'UncontactedCustomerCallQueue' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathUncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment
		{
			get
			{
				IEntityRelation intermediateRelation = HealthPlanCallQueueCriteriaEntity.Relations.UncontactedCustomerCallQueueCriteriaAssignmentEntityUsingCriteriaId;
				intermediateRelation.SetAliases(string.Empty, "UncontactedCustomerCallQueueCriteriaAssignment_");
				return new PrefetchPathElement2(new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory))), intermediateRelation,
					(int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.UncontactedCustomerCallQueueEntity, 0, null, null, GetRelationsForField("UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment"), null, "UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					(IEntityRelation)GetRelationsForField("Account")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.AccountEntity, 0, null, null, null, null, "Account", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("CallQueue")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CallQueueEntity, 0, null, null, null, null, "CallQueue", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Campaign")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.CampaignEntity, 0, null, null, null, null, "Campaign", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("Language")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.LanguageEntity, 0, null, null, null, null, "Language", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser_")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					(IEntityRelation)GetRelationsForField("OrganizationRoleUser__")[0], (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity, (int)Falcon.Data.EntityType.OrganizationRoleUserEntity, 0, null, null, null, null, "OrganizationRoleUser__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return HealthPlanCallQueueCriteriaEntity.CustomProperties;}
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
			get { return HealthPlanCallQueueCriteriaEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 Id
		{
			get { return (System.Int64)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Id, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Id, value); }
		}

		/// <summary> The CallQueueId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."CallQueueId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CallQueueId
		{
			get { return (System.Int64)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CallQueueId, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CallQueueId, value); }
		}

		/// <summary> The Percentage property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."Percentage"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 18, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> Percentage
		{
			get { return (Nullable<System.Decimal>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Percentage, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Percentage, value); }
		}

		/// <summary> The NoOfDays property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."NoOfDays"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 NoOfDays
		{
			get { return (System.Int32)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.NoOfDays, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.NoOfDays, value); }
		}

		/// <summary> The RoundOfCalls property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."RoundOfCalls"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 RoundOfCalls
		{
			get { return (System.Int32)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.RoundOfCalls, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.RoundOfCalls, value); }
		}

		/// <summary> The StartDate property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."StartDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> StartDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.StartDate, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.StartDate, value); }
		}

		/// <summary> The EndDate property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."EndDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EndDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.EndDate, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.EndDate, value); }
		}

		/// <summary> The HealthPlanId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."HealthPlanId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> HealthPlanId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.HealthPlanId, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.HealthPlanId, value); }
		}

		/// <summary> The CustomTags property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."CustomTags"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 512<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CustomTags
		{
			get { return (System.String)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CustomTags, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CustomTags, value); }
		}

		/// <summary> The IsDefault property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."IsDefault"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDefault
		{
			get { return (System.Boolean)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsDefault, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsDefault, value); }
		}

		/// <summary> The IsQueueGenerated property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."IsQueueGenerated"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsQueueGenerated
		{
			get { return (System.Boolean)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsQueueGenerated, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsQueueGenerated, value); }
		}

		/// <summary> The LastQueueGeneratedDate property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."LastQueueGeneratedDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> LastQueueGeneratedDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.LastQueueGeneratedDate, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.LastQueueGeneratedDate, value); }
		}

		/// <summary> The DateCreated property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."DateCreated"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime DateCreated
		{
			get { return (System.DateTime)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.DateCreated, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.DateCreated, value); }
		}

		/// <summary> The DateModified property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."DateModified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> DateModified
		{
			get { return (Nullable<System.DateTime>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.DateModified, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.DateModified, value); }
		}

		/// <summary> The CreatedByOrgRoleUserId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."CreatedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CreatedByOrgRoleUserId
		{
			get { return (System.Int64)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CreatedByOrgRoleUserId, value); }
		}

		/// <summary> The ModifiedByOrgRoleUserId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."ModifiedByOrgRoleUserId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ModifiedByOrgRoleUserId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.ModifiedByOrgRoleUserId, value); }
		}

		/// <summary> The ZipCode property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."ZipCode"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 55<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String ZipCode
		{
			get { return (System.String)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.ZipCode, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.ZipCode, value); }
		}

		/// <summary> The Radius property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."Radius"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> Radius
		{
			get { return (Nullable<System.Int32>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Radius, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.Radius, value); }
		}

		/// <summary> The IsDeleted property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."IsDeleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean IsDeleted
		{
			get { return (System.Boolean)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsDeleted, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.IsDeleted, value); }
		}

		/// <summary> The CampaignId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."CampaignId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CampaignId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CampaignId, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CampaignId, value); }
		}

		/// <summary> The CriteriaName property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."CriteriaName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 255<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CriteriaName
		{
			get { return (System.String)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CriteriaName, true); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.CriteriaName, value); }
		}

		/// <summary> The LanguageId property of the Entity HealthPlanCallQueueCriteria<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TblHealthPlanCallQueueCriteria"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> LanguageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)HealthPlanCallQueueCriteriaFieldIndex.LanguageId, false); }
			set	{ SetValue((int)HealthPlanCallQueueCriteriaFieldIndex.LanguageId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallRoundCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallRoundCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity> CallRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_callRoundCallQueueCriteriaAssignment==null)
				{
					_callRoundCallQueueCriteriaAssignment = new EntityCollection<CallRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueCriteriaAssignmentEntityFactory)));
					_callRoundCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _callRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FillEventCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FillEventCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<FillEventCallQueueCriteriaAssignmentEntity> FillEventCallQueueCriteriaAssignment
		{
			get
			{
				if(_fillEventCallQueueCriteriaAssignment==null)
				{
					_fillEventCallQueueCriteriaAssignment = new EntityCollection<FillEventCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueCriteriaAssignmentEntityFactory)));
					_fillEventCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _fillEventCallQueueCriteriaAssignment;
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
					_healthPlanCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaAssignmentEntity))]
		public virtual EntityCollection<HealthPlanCriteriaAssignmentEntity> HealthPlanCriteriaAssignment
		{
			get
			{
				if(_healthPlanCriteriaAssignment==null)
				{
					_healthPlanCriteriaAssignment = new EntityCollection<HealthPlanCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentEntityFactory)));
					_healthPlanCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaAssignmentUploadEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaAssignmentUploadEntity))]
		public virtual EntityCollection<HealthPlanCriteriaAssignmentUploadEntity> HealthPlanCriteriaAssignmentUpload
		{
			get
			{
				if(_healthPlanCriteriaAssignmentUpload==null)
				{
					_healthPlanCriteriaAssignmentUpload = new EntityCollection<HealthPlanCriteriaAssignmentUploadEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaAssignmentUploadEntityFactory)));
					_healthPlanCriteriaAssignmentUpload.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanCriteriaAssignmentUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaDirectMailEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaDirectMailEntity))]
		public virtual EntityCollection<HealthPlanCriteriaDirectMailEntity> HealthPlanCriteriaDirectMail
		{
			get
			{
				if(_healthPlanCriteriaDirectMail==null)
				{
					_healthPlanCriteriaDirectMail = new EntityCollection<HealthPlanCriteriaDirectMailEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaDirectMailEntityFactory)));
					_healthPlanCriteriaDirectMail.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanCriteriaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanCriteriaTeamAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanCriteriaTeamAssignmentEntity))]
		public virtual EntityCollection<HealthPlanCriteriaTeamAssignmentEntity> HealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_healthPlanCriteriaTeamAssignment==null)
				{
					_healthPlanCriteriaTeamAssignment = new EntityCollection<HealthPlanCriteriaTeamAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanCriteriaTeamAssignmentEntityFactory)));
					_healthPlanCriteriaTeamAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanCriteriaTeamAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HealthPlanFillEventCallQueueEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HealthPlanFillEventCallQueueEntity))]
		public virtual EntityCollection<HealthPlanFillEventCallQueueEntity> HealthPlanFillEventCallQueue
		{
			get
			{
				if(_healthPlanFillEventCallQueue==null)
				{
					_healthPlanFillEventCallQueue = new EntityCollection<HealthPlanFillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HealthPlanFillEventCallQueueEntityFactory)));
					_healthPlanFillEventCallQueue.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _healthPlanFillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageBarrierCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageBarrierCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity> LanguageBarrierCallQueueCriteriaAssignment
		{
			get
			{
				if(_languageBarrierCallQueueCriteriaAssignment==null)
				{
					_languageBarrierCallQueueCriteriaAssignment = new EntityCollection<LanguageBarrierCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueCriteriaAssignmentEntityFactory)));
					_languageBarrierCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _languageBarrierCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MailRoundCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MailRoundCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity> MailRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_mailRoundCallQueueCriteriaAssignment==null)
				{
					_mailRoundCallQueueCriteriaAssignment = new EntityCollection<MailRoundCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueCriteriaAssignmentEntityFactory)));
					_mailRoundCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _mailRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoShowCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoShowCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<NoShowCallQueueCriteriaAssignmentEntity> NoShowCallQueueCriteriaAssignment
		{
			get
			{
				if(_noShowCallQueueCriteriaAssignment==null)
				{
					_noShowCallQueueCriteriaAssignment = new EntityCollection<NoShowCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueCriteriaAssignmentEntityFactory)));
					_noShowCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _noShowCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UncontactedCustomerCallQueueCriteriaAssignmentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UncontactedCustomerCallQueueCriteriaAssignmentEntity))]
		public virtual EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity> UncontactedCustomerCallQueueCriteriaAssignment
		{
			get
			{
				if(_uncontactedCustomerCallQueueCriteriaAssignment==null)
				{
					_uncontactedCustomerCallQueueCriteriaAssignment = new EntityCollection<UncontactedCustomerCallQueueCriteriaAssignmentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueCriteriaAssignmentEntityFactory)));
					_uncontactedCustomerCallQueueCriteriaAssignment.SetContainingEntityInfo(this, "HealthPlanCallQueueCriteria");
				}
				return _uncontactedCustomerCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CallCenterTeamEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallCenterTeamEntity))]
		public virtual EntityCollection<CallCenterTeamEntity> CallCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment==null)
				{
					_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment = new EntityCollection<CallCenterTeamEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallCenterTeamEntityFactory)));
					_callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly=true;
				}
				return _callCenterTeamCollectionViaHealthPlanCriteriaTeamAssignment;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CallRoundCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CallRoundCallQueueEntity))]
		public virtual EntityCollection<CallRoundCallQueueEntity> CallRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment==null)
				{
					_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment = new EntityCollection<CallRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CallRoundCallQueueEntityFactory)));
					_callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _callRoundCallQueueCollectionViaCallRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CampaignActivityEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CampaignActivityEntity))]
		public virtual EntityCollection<CampaignActivityEntity> CampaignActivityCollectionViaHealthPlanCriteriaDirectMail
		{
			get
			{
				if(_campaignActivityCollectionViaHealthPlanCriteriaDirectMail==null)
				{
					_campaignActivityCollectionViaHealthPlanCriteriaDirectMail = new EntityCollection<CampaignActivityEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CampaignActivityEntityFactory)));
					_campaignActivityCollectionViaHealthPlanCriteriaDirectMail.IsReadOnly=true;
				}
				return _campaignActivityCollectionViaHealthPlanCriteriaDirectMail;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'EventsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(EventsEntity))]
		public virtual EntityCollection<EventsEntity> EventsCollectionViaHealthPlanFillEventCallQueue
		{
			get
			{
				if(_eventsCollectionViaHealthPlanFillEventCallQueue==null)
				{
					_eventsCollectionViaHealthPlanFillEventCallQueue = new EntityCollection<EventsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(EventsEntityFactory)));
					_eventsCollectionViaHealthPlanFillEventCallQueue.IsReadOnly=true;
				}
				return _eventsCollectionViaHealthPlanFillEventCallQueue;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FileEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FileEntity))]
		public virtual EntityCollection<FileEntity> FileCollectionViaHealthPlanCriteriaAssignmentUpload
		{
			get
			{
				if(_fileCollectionViaHealthPlanCriteriaAssignmentUpload==null)
				{
					_fileCollectionViaHealthPlanCriteriaAssignmentUpload = new EntityCollection<FileEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FileEntityFactory)));
					_fileCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly=true;
				}
				return _fileCollectionViaHealthPlanCriteriaAssignmentUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FillEventCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FillEventCallQueueEntity))]
		public virtual EntityCollection<FillEventCallQueueEntity> FillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment
		{
			get
			{
				if(_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment==null)
				{
					_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment = new EntityCollection<FillEventCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FillEventCallQueueEntityFactory)));
					_fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _fillEventCallQueueCollectionViaFillEventCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LanguageBarrierCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LanguageBarrierCallQueueEntity))]
		public virtual EntityCollection<LanguageBarrierCallQueueEntity> LanguageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment
		{
			get
			{
				if(_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment==null)
				{
					_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment = new EntityCollection<LanguageBarrierCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LanguageBarrierCallQueueEntityFactory)));
					_languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _languageBarrierCallQueueCollectionViaLanguageBarrierCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MailRoundCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MailRoundCallQueueEntity))]
		public virtual EntityCollection<MailRoundCallQueueEntity> MailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment
		{
			get
			{
				if(_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment==null)
				{
					_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment = new EntityCollection<MailRoundCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MailRoundCallQueueEntityFactory)));
					_mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _mailRoundCallQueueCollectionViaMailRoundCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoShowCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoShowCallQueueEntity))]
		public virtual EntityCollection<NoShowCallQueueEntity> NoShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment
		{
			get
			{
				if(_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment==null)
				{
					_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment = new EntityCollection<NoShowCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoShowCallQueueEntityFactory)));
					_noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _noShowCallQueueCollectionViaNoShowCallQueueCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment_
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignment__
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__ = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaAssignment__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaTeamAssignment;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OrganizationRoleUserEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OrganizationRoleUserEntity))]
		public virtual EntityCollection<OrganizationRoleUserEntity> OrganizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload
		{
			get
			{
				if(_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload==null)
				{
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload = new EntityCollection<OrganizationRoleUserEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OrganizationRoleUserEntityFactory)));
					_organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload.IsReadOnly=true;
				}
				return _organizationRoleUserCollectionViaHealthPlanCriteriaAssignmentUpload;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'UncontactedCustomerCallQueueEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(UncontactedCustomerCallQueueEntity))]
		public virtual EntityCollection<UncontactedCustomerCallQueueEntity> UncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment
		{
			get
			{
				if(_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment==null)
				{
					_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment = new EntityCollection<UncontactedCustomerCallQueueEntity>(EntityFactoryCache2.GetEntityFactory(typeof(UncontactedCustomerCallQueueEntityFactory)));
					_uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment.IsReadOnly=true;
				}
				return _uncontactedCustomerCallQueueCollectionViaUncontactedCustomerCallQueueCriteriaAssignment;
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
							_account.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria");
						}
					}
					else
					{
						if(_account!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria");
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
							_callQueue.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria");
						}
					}
					else
					{
						if(_callQueue!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria");
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
							_campaign.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria");
						}
					}
					else
					{
						if(_campaign!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria");
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
							_language.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria");
						}
					}
					else
					{
						if(_language!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria");
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
							_organizationRoleUser_.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria_");
						}
					}
					else
					{
						if(_organizationRoleUser_!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria_");
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
							_organizationRoleUser__.UnsetRelatedEntity(this, "HealthPlanCallQueueCriteria__");
						}
					}
					else
					{
						if(_organizationRoleUser__!=value)
						{
							((IEntity2)value).SetRelatedEntity(this, "HealthPlanCallQueueCriteria__");
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
			get { return (int)Falcon.Data.EntityType.HealthPlanCallQueueCriteriaEntity; }
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
